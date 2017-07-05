using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp
{
    public class PrintTodoList
    {
        public void PrintList(Person person)
        {
            if (person.TodoLists.Count == 0)
            {
                Console.WriteLine("{0} doesn't a todo list yet. Please create one", person.Name);
            }
            else
            {
                foreach (var todoList in person.TodoLists)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Todo - {0}", todoList.Name);
                    Console.WriteLine("-----------------------------------------");
                    foreach (var todoItem in todoList.Items)
                    {
                        Console.WriteLine("{0} - {1}", todoItem.Position, todoItem.Name);
                    }
                }
            }
        }
    }
}
