using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    public class Student: Person
    {
        int[] TestScores;
        public Student(string f, string l, int id, int[] scores)
            : base(f, l, id)
        {
            TestScores = scores;
        }
        public char Calculate()
        {
            int sum = 0;
            int average = 0;
            for (int i = 0; i < TestScores.Length; i++)
            {
                sum += TestScores[i];
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
                return 'P';
            }
            else if (grade < 55 && grade >= 40)
            {
                return 'D';
            }
            else
            {
                return 'T';
            }
        }
    }
}
