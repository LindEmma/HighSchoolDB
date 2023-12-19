using HighSchoolDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HighSchoolDB.Logic
{
    internal class ViewGrade
    {
        HighSchoolContext context = new HighSchoolContext();

        //Shows the set grades
        public void ViewGrades()
        {
            string answer = "";
            do
            {
                Console.WriteLine("Vill du:\n1.Se snittbetyget i varje ämne?\n2.Se alla betyg satta i november?");
                answer = Console.ReadLine();
                if (answer != "1" && answer != "2")
                {
                    HelpfulMethods.ClearAgain();
                    Console.WriteLine();
                }
            } while (answer != "1" && answer != "2");
            Console.Clear();

            //Shows the average grade in chosen subject
            if (answer == "1")
            {
                int subjectCount;
                int choice;

                //shows list of subjects grouped by their id
                do {
                    Console.WriteLine("Alla ämnen:");
                    var subjects = context.Subjects.OrderBy(s => s.SubjectId);
                    subjectCount = context.Subjects.Count(); //stores the amount of subjects in subjectCount

                    foreach (var subject in subjects)
                    {
                        Console.WriteLine(subject.SubjectId + ". " + subject.SubjectName);
                    }
                    Console.WriteLine("Vilket ämne vill du se snittbetyget i? 1-" + subjectCount);
                    choice = HelpfulMethods.ReadInt();

                    if(choice < 1 || choice > subjectCount)
                    {
                        Console.Clear();
                        Console.WriteLine("Siffran du angav matchar inget ämne på listan, prova igen.\n");
                    }
                } while (choice<1||choice>subjectCount);

                // checks if the chosen subject has any set grades
                var check = context.Grades.Where(s => s.FkSubjectId == choice).IsNullOrEmpty();

                //if check is null nothing more happens, else average grade for chosen subject is shown 
                if (check == true)
                {
                    Console.WriteLine("Det finns inga satta betyg i ämnet");
                }
                else
                {
                    //grades returns a decimal, calculated with Average() from the chosen grade
                    var grades = context.Grades.Where(s => s.FkSubjectId == choice).Average(s => s.Grade1);
                    var gradeRounded = Math.Round(grades,2);
                    Console.WriteLine("Snittbetyget i ämnet är: "+gradeRounded);
                }
            }

            // Shows all set grades in november 2014 (used the dates from when I attended high school)
            // includes the grade, students name, subjects name and full date.
            else if (answer == "2")
            {
                var gradesInNov = context.Grades.Where(g => g.DateOfIssue.Month == 11 && g.DateOfIssue.Year == 2014)
                    .Include(s => s.FkSubject)
                    .Include(n => n.FkStudent);
                Console.WriteLine("Betyg (1-5)    Elev         Ämne        Datum");
                foreach (var gradeInNov in gradesInNov)
                {
                    Console.WriteLine(" " + gradeInNov.Grade1 + "      -      " + gradeInNov.FkStudent.FirstName + " " + gradeInNov.FkStudent.LastName +
                        " - " + gradeInNov.FkSubject.SubjectName + " - " + gradeInNov.DateOfIssue);
                }
            }
            HelpfulMethods.PressKey();
        }
    }
}
