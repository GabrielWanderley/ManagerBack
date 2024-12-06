using ManagerBack.Models;
using System.ComponentModel.DataAnnotations;

namespace ManagerBack.Data.Dto
{
    public class ReadProductDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é nescessario")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A quantidade de stock do produto é nescessaria")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "O valor do produto é nescessario")]

        public int Value { get; set; }

        [Required(ErrorMessage = "Precisa enviar uma imagem")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Precisa selecionar uma categoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Quantidade vendida é nescessario")]
        public int sold { get; set; }

        [Required(ErrorMessage = "Lucro é nescessario")]
        public int profit { get; set; }

        public ICollection<ReadSaleDto> Sales { get; set; }
    }
}
