using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var twentyPerCentStudents = Students.Count / 5;
           
            List<double> allGrades = new List<double>();
            foreach(var student in Students)
            {
                allGrades.Add(student.AverageGrade);
            }
            allGrades = allGrades.OrderByDescending(x=>x).ToList();
            if (averageGrade >= allGrades[twentyPerCentStudents - 1])
            {
                return 'A';
            }
            var fortyPerCentStudents = twentyPerCentStudents + twentyPerCentStudents - 1;
            if (averageGrade >= allGrades[fortyPerCentStudents] )
            {
                return 'B';
            }
            var sixtyPerCentStudents = twentyPerCentStudents * 3;
            if (averageGrade >= allGrades[sixtyPerCentStudents - 1])
            {
                return 'C';
            }
            var eightyPerCentStudents = twentyPerCentStudents * 4;
            if (averageGrade >= allGrades[eightyPerCentStudents - 1])
            {
                return 'D';
            }

            return 'F';
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
