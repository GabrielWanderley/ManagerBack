using System.ComponentModel.DataAnnotations;

namespace ManagerBack.Data.Dto
{
    public class ReadSaleDto
    {

        public int Id { get; set; }
        public DateTime date { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int value { get; set; }
        public int Amount { get; set; }
        public string ProductUrl { get; set; }

    }
}
