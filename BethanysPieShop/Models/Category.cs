using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }

        [Required (ErrorMessage ="Plaese Enter Name of Category")]
        [StringLength (50)]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Plaese Enter Description of Category")]
        [StringLength(50)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        public List<Pie>? Pies { get; set; }    }
}
