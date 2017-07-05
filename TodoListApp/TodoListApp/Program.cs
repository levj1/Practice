using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a person
            Person james = new Person("james");
            ListInitiator initiator = new ListInitiator();
            james.TodoLists.Add(initiator.GetProgrammingTodoList());

            james.TodoLists.Add(initiator.GetChurchList());


            // Print list
            PrintTodoList printjob = new PrintTodoList();
            printjob.PrintList(james);
            
            Console.ReadLine();
        }
    }
}
