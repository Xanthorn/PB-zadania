using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS_01.Models
{
    public partial class Candidate
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public List<ProgrammingLanguage> ProgrammingLanguages = new List<ProgrammingLanguage>();
    }
}
