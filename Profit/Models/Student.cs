using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profit.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Pin { get; set; }
        public string Institution { get; set; }
        public DateTime Year { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
