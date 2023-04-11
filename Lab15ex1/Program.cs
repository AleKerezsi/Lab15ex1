using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab15ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStudents = new List<Student>()
            {
                new Student(){Id=Guid.NewGuid(),Prenume="John",Nume="Oak",Varsta=17,Specializare=Specializare.Informatica},
                new Student(){Id=Guid.NewGuid(),Prenume="Mihai",Nume="Moldovan",Varsta=37,Specializare=Specializare.Constructii},
                new Student(){Id=Guid.NewGuid(),Prenume="Daniela",Nume="Swift",Varsta=24,Specializare=Specializare.Litere},
                new Student(){Id=Guid.NewGuid(),Prenume="Radu",Nume="Pop",Varsta=97,Specializare=Specializare.Informatica},
                new Student(){Id=Guid.NewGuid(),Prenume="Mirabela",Nume="Alexandrescu-Gicu-Pop",Varsta=57,Specializare=Specializare.Constructii},
                new Student(){Id=Guid.NewGuid(),Prenume="Laura",Nume="Marian",Varsta=57,Specializare=Specializare.Constructii},

            };

            //Afisati cel mai in varsta student de la Informatica
            var celMaiBatranStudent = myStudents
                .Where(student => student.Specializare == Specializare.Informatica)
                .OrderByDescending(stud => stud.Varsta)
                .FirstOrDefault();
            Console.WriteLine("Cel mai batran student: " + celMaiBatranStudent);

            //Afisati cel mai tanar student

            //metoda 1
            var celMaiTanarStudentM1 = myStudents
                .OrderBy(student => student.Varsta)
                .FirstOrDefault();
            Console.WriteLine("Cel mai tanar student (metoda 1): " + celMaiTanarStudentM1);

            //metoda 2
            var celMaiTanarStudentM2 = myStudents
                .Where(student => student.Varsta == (myStudents.Min(s1 => s1.Varsta)))
                .FirstOrDefault();
            Console.WriteLine("Cel mai tanar student (metoda 2): " + celMaiTanarStudentM2);

            //metoda 3
            var celMaiTanarStudentM3 = myStudents
                .OrderByDescending(student => student.Varsta)
                .LastOrDefault();
            Console.WriteLine("Cel mai tanar student (metoda 3): " + celMaiTanarStudentM3);

            //Afisati in ordine crescatoare a varstei toti, studentii de la litere.

            var studentiDeLaLitere = myStudents
                .Where(student => student.Specializare == Specializare.Litere)
                .OrderBy(student => student.Varsta);

            Console.WriteLine("Studentii de la Litere: ");
            foreach (var student in studentiDeLaLitere) { Console.WriteLine(student); }

            //Afisati primul student de la constructii cu varsta de peste 20 de ani

            var primulSudentConstructiiPeste20Ani = myStudents
                .Where(student => student.Specializare == Specializare.Constructii && student.Varsta > 20)
                .FirstOrDefault();

            Console.WriteLine("Primul student de la Constructii cu varsta de peste 20 de ani: "+primulSudentConstructiiPeste20Ani);

            //Afisati studentii avand varsta egala cu varsta medie a studentilor
            var studentiCuVarstaMedie = myStudents
                .Where(student => student.Varsta == (myStudents.Average(s1 => s1.Varsta)));
            foreach(var student in studentiCuVarstaMedie) { Console.WriteLine("Student cu varsta egala cu varsta medie: " + student); }

            //Afisati, in ordinea descrescatoare a varstei, si in ordine alfabetica, dupa numele de familie si dupa numele mic, toti studentii cu varsta cuprinsa intre 18 si 35 de ani

            var studentiFacultate = myStudents
                .Where(student => student.Varsta >= 18 && student.Varsta <= 35)
                .OrderByDescending(student => student.Varsta)
                .ThenBy(student => student.Nume)
                .OrderBy(student => student.Prenume);

            foreach (var student in studentiFacultate) { Console.WriteLine("Student de la facultate:  " + student); }

            //Afisati ultimul elev din lista folosind linq
            var ultimulStudent = myStudents.LastOrDefault();
            Console.WriteLine("Ultimul student: " + ultimulStudent);

            //8.Afisati mesajul “Exista si minori” daca in lista creeata exista si persone cu varsta mai mica de 18 ani.In caz contar afesati “Nu exista minori”

            var existaMinori = myStudents
                .Any(student => student.Varsta < 18);

            if (existaMinori) Console.WriteLine("Avem studenti minori in lista de studenti");
            else Console.WriteLine("Nu avem studenti minori in lista de studenti");

            /*
             * 9. Folosind GroupBy, afisati toti studentii grupati
                in functie de varsta sub forma urmatoare
                Studentii cu varsta de 20 de ani
                Student1.toString
                Student2.toString
                Student3.toString
                Studentii cu varsta de 25 de ani
             */
            var results = myStudents.GroupBy(
               student => student.Varsta);

            foreach (var group in results)
            {
                Console.WriteLine($"Studentii cu varsta de {group.Key} ani:");

                foreach (var student in group)
                {
                    Console.WriteLine(student.ToString());
                }
                Console.WriteLine();
            }

        }
    }
}
