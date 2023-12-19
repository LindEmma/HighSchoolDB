using HighSchoolDB.Logic;

namespace HighSchoolDB
{
    internal class App
    {
        bool RunApp { get; set; }


        public App()
        {
            RunApp = true;
        }
        public void Quit()
        {
            RunApp = false;
        }

        public void Run()
        {
            while (RunApp == true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till skoldatabasen \n**** High School App ****\n");
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("(1) Visa personal");
                Console.WriteLine("(2) Visa alla elever");
                Console.WriteLine("(3) Visa eleverna i vald klass");
                Console.WriteLine("(4) Visa betyg");
                Console.WriteLine("(5) Lägg till ny elev");
                Console.WriteLine("(6) Lägg till ny personal");
                Console.WriteLine("(7) Stäng av programmet");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ViewPersonnel viewPersonnel = new ViewPersonnel();
                        viewPersonnel.ViewAllPersonnel();
                        break;
                    case "2":
                        ViewStudent view = new ViewStudent();
                        view.ViewAllStudents();
                        break;
                    case "3":
                        ViewStudent studclass = new ViewStudent();
                        studclass.ViewStudInClass();
                        break;
                    case "4":
                        ViewGrade viewgrades = new ViewGrade();
                        viewgrades.ViewGrades();
                        break;
                    case "5":
                        Add addstudent = new Add();
                        addstudent.AddStudentToDB();
                        break;
                    case "6":
                        Add addPersonnel = new Add();
                        addPersonnel.AddPersonnelToDB();
                        break;
                    case "7":
                        Console.WriteLine("Tack för att du använde High School App!");
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Välj ett av alternativen");
                        HelpfulMethods.PressKey();
                        break;

                }
            }
        }
    }
}
