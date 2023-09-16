using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace WebApplication2.Models
{
	public class Category
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        [Required]
        [DisplayName("category name")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [DisplayName("category abbreviation")]
        [MinLength(1)]
        [MaxLength(4)]
        
        [RegularExpression(@"[A-Z]+",ErrorMessage ="must be upper case caracters")]
        public string abb { get; set; }
    }
}
