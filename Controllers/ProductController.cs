using AutoMapper;
using ManagerBack.Data;
using ManagerBack.Data.Dto;
using ManagerBack.Models;
using ManagerBack.Sistem;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace ManagerBack.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{

    private ManagerBackContext _context;
    private IMapper _mapper;

    public ProductController(ManagerBackContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadProductDto> GetProduct([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadProductDto>>(_context.Products.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id) 
    {
        var product = _context.Products.FirstOrDefault(com => com.Id == id);
        if (product == null) return NotFound();
        var productDto = _mapper.Map<ReadProductDto>(product);
        return Ok(productDto);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetProductByName(string name)
    {
        var product = _context.Products.Where(com => com.Name.Contains(name) ).ToList();
        if (product == null) return NotFound();
        var productDto = _mapper.Map<List<ReadProductDto>>(product);
        return Ok(productDto);
    }

    [HttpGet("Category/{name}")]
    public IActionResult GetProductByCategory(string name)
    {
        var product = _context.Products.Where(com => com.Category == name).ToList();
        if (product == null) return NotFound();
        var productDto = _mapper.Map<List<ReadProductDto>>(product);
        return Ok(productDto);
    }

    [HttpGet("sold/")]
    public IActionResult GetProductBySolds()
    {
        var product = _context.Products.OrderByDescending(pro => pro.sold).ToList();
        if (product == null) return NotFound();
        var productDto = _mapper.Map<List<ReadProductDto>>(product);
        return Ok(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto ProductDto)
    {
        var uploadImage = new UploadImage();
        var imageUrl = await uploadImage.UploadBase64Image(ProductDto.Url);
        ProductDto.Url = imageUrl;
        Product product = _mapper.Map<Product>(ProductDto);
        _context.Add(product);
        _context.SaveChanges();
        return Ok();

    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto) 
    {
        var product = _context.Products.FirstOrDefault(pro => pro.Id == id);
        if (product == null) return NotFound();
        
        //var uploadImage = new UploadImage();
        //var imageUrl = await uploadImage.UploadBase64Image(productDto.Url);
        //productDto.Url = imageUrl;

        _mapper.Map(productDto, product);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> ParseUpdateProduct(int id,JsonPatchDocument<UpdateProductDto> patch )
    {
        var product = _context.Products.FirstOrDefault(pro => pro.Id == id);
        if (product == null) return NotFound();

        var productDto = _mapper.Map<UpdateProductDto>(product);

        var uploadImage = new UploadImage();

        foreach (var item in patch.Operations) 
        { 
            if(item.path.Equals("/Url", StringComparison.OrdinalIgnoreCase) && item.value is string base64Image)
            {
                var imageUrl = await uploadImage.UploadBase64Image(base64Image);
                item.value = imageUrl;

            }
        }

        patch.ApplyTo(productDto, ModelState);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        _mapper.Map(productDto, product);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteProduct(int id) 
    { 
       var product = _context.Products.FirstOrDefault(pro => pro.Id == id);
       if (product == null) return NotFound();
       _context.Remove(product);
       _context.SaveChanges();
       return NoContent();
    }

}
