using HighSchoolDB.Models;

namespace HighSchoolDB.Logic
{
    internal class Add
    {
        //Method that adds a new student to the database
        public void AddStudentToDB()
        {
            using HighSchoolContext context = new HighSchoolContext();

            Console.WriteLine("Här kan du lägga till en ny elev i databasen! Fyll i uppgiftera nedan:");
            Console.WriteLine("Förnamn:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Efternamn:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Personnummer (12 siffror utan bindestreck eller mellanslag):");
            string personalNumber = Console.ReadLine();

            var stuClass = context.Classes.OrderBy(c => c.ClassId);
            foreach (var classes in stuClass)
            {
                Console.WriteLine(classes.ClassId + ". " + classes.ClassName);
            }
            Console.WriteLine("Vilken klass tillhör eleven? (1-9):");
            int fkClassID = HelpfulMethods.ReadInt();

            //Creates new student based in users variables
            // and saves it to the database
            context.Add(new Student(firstName, lastName, personalNumber, fkClassID));
            context.SaveChanges();
            Console.WriteLine("Eleven har blivit tillagd i databasen!");
            HelpfulMethods.PressKey();
        }

        // Method that adds new personnel to the database
        public void AddPersonnelToDB()
        {
            using HighSchoolContext context = new HighSchoolContext();
            int role, pCount;

            Console.WriteLine("Här kan du lägga till ny personal i databasen! Fyll i uppgiftera nedan:");
            Console.WriteLine("Förnamn:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Efternamn:");
            string lastName = Console.ReadLine();

            // Shows all titles to let user choose correctly from their ID
            Console.WriteLine("Vilken titel har personalen?");
            var pRoles = context.Roles.OrderBy(r => r.RoleId)/*.Include(s => s.Role1)*/;
            foreach (var pRole in pRoles)
            {
                Console.WriteLine(pRole.RoleId + ". " + pRole.Role1);
            }
            do
            {
                role = HelpfulMethods.ReadInt();
                pCount = context.Subjects.Count();
                Console.WriteLine("Vilken titel har personen? (1-" + pCount+":");

                if (role < 1 || role > pCount)
                {
                    Console.Clear();
                    Console.WriteLine("Vänligen välj 1-" + pCount);
                }
            } while (role < 1 || role > pCount);


            //Creates new personnel 
            // saves it to the database
            context.Add(new Personnel(firstName, lastName, role));
            context.SaveChanges();
            Console.WriteLine("Personalen har blivit tillagd i databasen!");
            HelpfulMethods.PressKey();
        }
    }
}
