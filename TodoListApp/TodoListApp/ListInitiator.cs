using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp
{
    public class ListInitiator
    {
        public TodoList GetProgrammingTodoList()
        {
            return new TodoList()
            {
                Id = 1,
                Items = new List<Item>
                {
                    new Item {ID = 1, Name = "SRS", Position = 1},
                    new Item { ID = 2, Name = "Use Case", Position = 2},
                    new Item { ID = 3, Name = "Class Diagram", Position = 3}
                },
                Name = "programming"
            };
        }

        public TodoList GetChurchList()
        {
            return new TodoList()
            {
                Id = 1,
                Items = new List<Item>
                {
                    new Item {ID = 1, Name = "Bible", Position = 1},
                    new Item { ID = 2, Name = "Prayer", Position = 2},
                    new Item { ID = 3, Name = "Meditation", Position = 3}
                },
                Name = "Church"
            };
        }
    }
}
