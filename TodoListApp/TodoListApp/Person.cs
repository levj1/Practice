using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp
{
    public class Person
    {
        public string Name { get; set; }
        public List<TodoList> TodoLists { get; set; }

        public Person()
        {

            TodoLists = new List<TodoList>();
        }

        public Person(string name)
        {
            Name = name;
            TodoLists = new List<TodoList>();
        }

        public void CreateTodoList(TodoList todo)
        {
            TodoLists.Add(todo);
        }

        public void DeleteTodoList(int id)
        {
            var todoToDelete = TodoLists.Select(l => l.Id == id);
         
        }

        public List<Item> SwapItemInList(Item item1, Item item2)
        {
            int swap = item2.Position;
            item2.Position = item1.Position;
            item1.Position = swap;

            return new List<Item> { item1, item2 };
        }
    }
}
