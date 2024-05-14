using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class ItemDto
    {
        [Required, MaxLength(150)]
        public string Name { get; set; } = "";
        [Required]
        public int Unit { get; set; }
        [Required]
        public int Quantity { get; set; }


        public List<IFormFile>? ImageFiles { get; set; }

        public int CategoryId { get; set; }
    }
}
