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
            if (averageGrade >= allGrades[twentyPerCentStudents])
            {
                return 'A';
            }
            var fortyPerCentStudents = twentyPerCentStudents * 2;
            if (averageGrade >= allGrades[fortyPerCentStudents] 
                && averageGrade < allGrades[twentyPerCentStudents])
            {
                return 'B';
            }
            var sixtyPerCentStudents = twentyPerCentStudents * 3;
            if (averageGrade >= allGrades[sixtyPerCentStudents] && averageGrade < allGrades[fortyPerCentStudents])
            {
                return 'C';
            }
        //    var eightyPerCentStudents = twentyPerCentStudents * 4;
        //    if (averageGrade >= allGrades[eightyPerCentStudents] && averageGrade < allGrades[sixtyPerCentStudents])
        //    {
         //       return 'D';
         //   }

            return 'F';
        }
    }
}
