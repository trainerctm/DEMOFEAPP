using System.ComponentModel.DataAnnotations;

namespace DemoFEApp.Models {

    public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "You must set a name for your product.")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "You must set a price for your product.")]
    public decimal Price { get; set; }
    [Required]
    [Range(0, 1000, ErrorMessage = "The stock value must be between 0 and 1000.")]
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageFileName { get; set; }
}

}