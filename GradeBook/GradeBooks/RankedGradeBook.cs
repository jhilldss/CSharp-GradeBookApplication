using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grade requires a minimum of 5 students");

            var allAveGrades = new List<double>();
            var StudentCount = Students.Count;
            var x = StudentCount * .2;
            int y = (int)x;

            foreach (var student in Students)
            {
                allAveGrades.Add(student.AverageGrade);
            }
            allAveGrades.Sort();
            allAveGrades.Reverse();

            switch(averageGrade)
            {
                case var d when d >= allAveGrades[(y * 1) - 1]:
                    return 'A';

                case var d when d >= allAveGrades[(y * 2) - 1]:
                    return 'B';

                case var d when d >= allAveGrades[(y * 3) - 1]:
                    return 'C';

                case var d when d >= allAveGrades[(y * 4) - 1]:
                    return 'D';

                default:
                    return 'F';

            }
            

        }
    }
}
