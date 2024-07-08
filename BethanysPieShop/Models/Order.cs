using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.Models
{
    public class Order
    {

        [BindNever]
        public int Id { get; set; }
        public List<OrderDetails>? OrderDetail { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name ="First Name")]
        [StringLength(15)]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(15)]
        public string LastName { get; set; } = string.Empty;
        [Required (ErrorMessage ="Please Enter Address")]
        [Display(Name ="Address 1")]
        [StringLength(50)]
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }

        [StringLength(10,MinimumLength =4)]
        [Required(ErrorMessage = "Please Enter ZipCode")]
        [Display(Name = "Zip Code")]
     
        public string ZipCode { get; set; } = string.Empty;
        [Required(ErrorMessage="Please Enter City")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter State")]
        [StringLength(10)]
        public string? State { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
    ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; } = string.Empty;
        [BindNever]
        public float OrderTotal { get; set; }
        [BindNever]

        public DateTime OrderPlaced { get; set; }

        


    }
}
