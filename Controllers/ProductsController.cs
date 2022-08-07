using Microsoft.AspNetCore.Mvc;

namespace MultitenantExample.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : Controller
{
    private readonly AppDbContext _db;
    
    public ProductsController(AppDbContext db)
    {
        _db = db;
    }
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_db.Products.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_db.Products.FirstOrDefault(x => x.Id == id));
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        _db.Products.Add(product);
        _db.SaveChanges();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _db.Products.Remove(_db.Products.FirstOrDefault(x => x.Id == id));
        _db.SaveChanges();
        return NoContent();
    }
}