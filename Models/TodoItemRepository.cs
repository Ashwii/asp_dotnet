using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;


namespace asp_dotnet.Models

{
   
      public class TodoItemRepository : ITodoItemRepository
    {
        private List<TodoItem> TodoItems = new List<TodoItem>();
        private int _nextId = 1;

        public TodoItemRepository()
        {
            Add(new TodoItem { Name = "Tomato soup", Category = "Groceries", Price = 1.39M });
            Add(new TodoItem { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
            Add(new TodoItem { Name = "Hammer", Category = "Hardware", Price = 16.99M });
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems;
        }

        public TodoItem Get(int id)
        {
            return TodoItems.Find(p => p.Id == id);
        }

        public TodoItem Add(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            TodoItems.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            TodoItems.RemoveAll(p => p.Id == id);
        }

        public bool Update(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = TodoItems.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            TodoItems.RemoveAt(index);
            TodoItems.Add(item);
            return true;
        }
    }

}