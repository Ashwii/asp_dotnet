using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;


 

namespace asp_dotnet.Models

{
  public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Get(int id);
        TodoItem Add(TodoItem item);
        void Remove(int id);
        bool Update(TodoItem item);
    }

}