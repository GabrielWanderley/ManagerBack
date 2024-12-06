using AutoMapper;
using ManagerBack.Data;
using ManagerBack.Data.Dto;
using ManagerBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagerBack.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class SaleController : ControllerBase
    {
        private ManagerBackContext _context;
        private IMapper _mapper;

        public SaleController(ManagerBackContext context, IMapper mapper) 
        {

            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public IEnumerable<ReadSaleDto> GetSale([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadSaleDto>>(_context.Sales.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]

        public IActionResult GetSaleById(int id) 
        {
            var sale = _context.Sales.FirstOrDefault(sale => sale.Id == id);
            if (sale == null) return NotFound();
            var saleDto = _mapper.Map<ReadSaleDto>(sale);
            return Ok(saleDto);
        }

        [HttpGet("Product/{id}")]
        public IActionResult GetSaleByProductId(int id) 
        { 
           var sale = _context.Sales.Where(sale => sale.ProductId == id).ToList();
           if (sale == null) return NotFound();
           var saleDto = _mapper.Map<List<ReadSaleDto>>(sale);
           return Ok(saleDto);
        }

        [HttpPost]
        public IActionResult PostSale([FromBody] CreateSaleDto SaleDto)
        {
            Sale sale = _mapper.Map<Sale>(SaleDto);

            Product product = _context.Products.FirstOrDefault(pro => pro.Id == sale.ProductId);
            if (product == null) return NotFound("Produto não encontrado");
            if (product.Stock < sale.Amount) return BadRequest("Estoque insuficiente para realizar a venda.");
            if (sale.Amount <= 0) return BadRequest("Quantidade deve ser positiva.");

            product.Stock = product.Stock - sale.Amount;

            product.sold = product.sold + sale.Amount;

            sale.value = sale.Amount * product.Value;

            product.profit += sale.value;

            

            _context.Sales.Add(sale);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutSale(int id,[FromBody] UpdateSaleDto saleDto) 
        { 
            var sale = _context.Sales.FirstOrDefault(sale => sale.Id == id);
            if (sale == null) return NotFound();
            _mapper.Map(saleDto, sale);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteSale(int id)
        {
           var sale = _context.Sales.FirstOrDefault(sale => sale.Id == id);
            if(sale == null) return NotFound();

            Product product = _context.Products.FirstOrDefault(pro => pro.Id == sale.ProductId);

            product.Stock = product.Stock + sale.Amount;

            product.sold = product.sold - sale.Amount;

            product.profit -= sale.value;

            _context.Remove(sale);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
