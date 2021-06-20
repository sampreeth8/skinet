using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Please enter name"), MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Invalid price")]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }

        [Required]
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
