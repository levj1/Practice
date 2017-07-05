using System.Collections.Generic;

namespace TodoListApp
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public TodoList()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }
}