using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var gradeRange = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();

            if (averageGrade >= grades[gradeRange - 1])
                return 'A';
            else if (averageGrade >= grades[(gradeRange * 2) - 1])
                return 'B';
            else if (averageGrade >= grades[(gradeRange * 3) - 1])
                return 'C';
            else if (averageGrade >= grades[(gradeRange * 4) - 1])
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
            base.CalculateStudentStatistics(name);
        }
    }
}
