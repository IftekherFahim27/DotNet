using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class Item
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; } = "";

        public int Unit { get; set; }

        public int Quantity { get; set; }


        public string ImageFileNames { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
    }
}
