using System.ComponentModel.DataAnnotations;

namespace ManagerBack.Data.Dto
{
    public class CreateSaleDto
    {
        [Required(ErrorMessage = "A data é nescessaria")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "O id do produto é nescessario")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O nome do produto é nescessario")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "O valor do produto é nescessario")]
        public int value { get; set; }

        [Required(ErrorMessage = "A quantidade vendidad é nescessario")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Url nescessaria")]
        public string ProductUrl { get; set; }
    }
}
