using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGQZ.ArqLimpia.BL.DTOs.StudentDTOs
{
    public class StudentUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearsOld { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string SecondNumber { get; set; }
    }
}
