using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using asp_dotnet.Models;

namespace asp_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
   public class TodoItemController : Controller
{
    static readonly ITodoItemRepository repository = new TodoItemRepository();

    // GET ITEMS
    //=======================
    [HttpGet] 
     public IEnumerable<TodoItem> GetAllProducts()
    {
        return repository.GetAll();
    }
    //==================================================================================
    // GET ITEMS WITH ID
    // =====================
     [HttpGet("{id}")]
    public TodoItem GetProduct(int id)
    {
    TodoItem item = repository.Get(id);
    if (item == null)
    {
        Console.WriteLine("Item not Found"); 
    }
    return item;
    }
    // =================================================================================
    // POST ITEMS
    // ==================

    [HttpPost]
    public TodoItem PostProduct(TodoItem item)
    {
    item = repository.Add(item);
    return item;
    }
    // ====================================================================================
    // UPDATE ITEM
    // ====================

    [HttpPut("{id}")]
    public void PutProduct(int id, TodoItem product)
    {
    product.Id = id;
    if (!repository.Update(product))
    {
        Console.WriteLine("Item not Found"); 
    }
    }
    // =====================================================================================
    // DELETE ITEM
    // ==================
   [HttpDelete("{id}")]
    public void DeleteProduct(int id)
    {
    TodoItem item = repository.Get(id);
    if (item == null)
    {
        Console.WriteLine("Item not Found"); 
    }
    repository.Remove(id);
    }
    // ====================================================================================
} 

}