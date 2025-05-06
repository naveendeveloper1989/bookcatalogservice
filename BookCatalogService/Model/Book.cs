
namespace BookCatalogService.Model;
public class Book{
    public Guid Id{ get; set; }
    public string? Title{ get; set; }
    public string? Author{ get; set; }
    public string? Isbn{ get; set; }
    public string? Description{ get; set; }
    public string? Publisher{ get; set; }
    public string? Category{ get; set; }
    public decimal Price{ get; set; }
    public decimal Rating{ get; set; }
    public int Stock{ get; set; }
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt{ get; set; }

}