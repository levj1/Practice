using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    public class Student: Person
    {
        public int[] Score;
        public Student(string f, string l, long id, int[] test)
            : base(f, l, id) { Score = test; }
        
        public char GetLetterGrade()
        {
            int sum = 0;
            int average = 0;
            for (int i = 0; i < Score.Length; i++)
            {
                sum += Score[i];
                average++;
            }

            int grade = sum / average;

            if (grade <= 100 && grade >= 90)
            {
                return 'O';
            }
            else if (grade < 90 && grade >= 80)
            {
                return 'E';
            }
            else if (grade < 80 && grade >= 70)
            {
                return 'A';
            }
            else if (grade < 70 && grade >= 55)
            {
                return 'D';
            }
            else if (grade < 55 && grade >= 40)
            {
                return 'P';
            }
            else
            {
                return 'T';
            }
        }

        public void PrintGradeLetter()
        {
            Console.WriteLine("Grade: " + GetLetterGrade());
        }
    }
}
