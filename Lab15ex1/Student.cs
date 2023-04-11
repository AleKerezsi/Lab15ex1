using System;
using System.Collections.Generic;
using System.Text;

namespace Lab15ex1
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public int Varsta { get; set; }

        public Specializare Specializare { get; set; }

        public override string ToString()
        {
            return $"{Id.ToString()},{Nume},{Prenume},{Varsta},{Specializare.ToString()}";
        }

    }
}
