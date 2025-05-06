using BookCatalogService.Model;
using Microsoft.AspNetCore.Mvc;

namespace StudentVaccinationBackenAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookCatalogController : ControllerBase
{
    private readonly AppDbContext appDbContext;
    public BookCatalogController(AppDbContext _appDbContext)
    {
        appDbContext = _appDbContext;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        Guid guid = Guid.NewGuid();
     /*   Book book = new Book(){
            Id = guid,
            Title = "MicroService Book",
            Author = "Naveen",
            Isbn = "1234-5678-9876",
            Description = "Book for Microservice",
            Publisher = "ABC",
            Category = "Technology",
            Price = 600,
            Rating = 5,
            Stock = 10,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }; */
        List<Book> books = appDbContext.Books.ToList();
        return Ok(books);
    }
    [HttpPost]
    public IActionResult AddBook([FromBody] Book book){
        book.Id=Guid.NewGuid();
        appDbContext.Add(book);
        appDbContext.SaveChanges();
        return Ok();
    }
    [HttpPut]
    public IActionResult UpdateBook([FromBody] Book book){
        Book book1 = appDbContext.Books.Where(b=>b.Id==book.Id).FirstOrDefault();
        book1.Title=book.Title;
        book1.Author = book.Author;
        book1.Category = book.Category;
        book1.Description = book.Description;
        book1.Isbn = book.Isbn;
        book1.Price = book.Price;
        book1.Publisher = book.Publisher;
        book1.Rating = book.Rating;
        book1.UpdatedAt = DateTime.Now;
        appDbContext.Update(book1);
        appDbContext.SaveChanges();
        return Ok();
    }
    [HttpDelete("{bookid}")]
    public IActionResult DeleteBook(Guid bookid){
        Book book1 = appDbContext.Books.Where(b=>b.Id==bookid).FirstOrDefault();
        if(book1 is null)
            return NotFound("Book Not Found");
        appDbContext.Remove(book1);
        appDbContext.SaveChanges();
        return Ok();
    }

}
