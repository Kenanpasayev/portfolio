using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication15.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [MinLength(5)]
        [MaxLength(25)]
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
