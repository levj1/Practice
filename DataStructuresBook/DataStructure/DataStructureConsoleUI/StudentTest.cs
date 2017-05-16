using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureConsoleUI
{
    public struct Student
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public Student(int id, string name)
        {
            TestId = id;
            Name = name;
        }
    }
    public class StudentTest
    {
        public Queue<Student> AllTests { get; set; }

        public StudentTest()
        {
            AllTests = new Queue<Student>();
        }

        public void TurnInTest(Student student)
        {
            AllTests.Enqueue(student);
        }

        public void LookAtATest(Student stud)
        {
            Student firstStudent = AllTests.Peek();
            bool foundTest = false;
            while(!foundTest)
            {
                if(firstStudent.TestId == stud.TestId)
                {
                    Console.WriteLine($"Found {firstStudent.Name} {firstStudent.TestId}");
                    AllTests.Dequeue();
                    foundTest = true;
                }
                else
                {
                    AllTests.Enqueue(firstStudent);
                    AllTests.Dequeue();
                    firstStudent = AllTests.Peek();              
                }
            }            
        }

        public void InsertATest(Student stud)
        {
            AllTests.Enqueue(stud);
        }
        
    }
}
