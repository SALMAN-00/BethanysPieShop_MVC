using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }

        [Required(ErrorMessage = "Plaese Enter Name of Pie")]
        [StringLength(50)]
        [Display(Name = "Pie Name")]
        public string Name { get; set; } = string.Empty;
		[Required(ErrorMessage = "Plaese Enter Short Description")]
		[Display(Name= "short Description")]
        public string? ShortDescription { get; set; }
		[Display(Name = "Long Description")]
		[Required(ErrorMessage = "Plaese Enter Long Description")]
		public string? LongDescription { get; set; }
        public string? AllergyInformation { get; set; }

		[Display(Name = "Price")]
		[Required(ErrorMessage = "Plaese Enter Price of Pie")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Plaese Enter Image")]
		[Display(Name = "Image Url")]
		public string? ImageUrl { get; set; }

		[Display(Name = "Image Thumbnail Url")]
		public string? ImageThumbnailUrl { get; set; }
        [Display(Name= "Pie Of The Week")]
        public bool IsPieOfTheWeek { get; set; }
        
        [Display(Name="Stock")]
        public bool InStock { get; set; }
         
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
