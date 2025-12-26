using System.ComponentModel.DataAnnotations;

namespace AspDotNetCrudProject.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Pages { get; set; }
    }
}
