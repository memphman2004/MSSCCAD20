using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_4._2
{
    public class Student
    {
        public string StudentId { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal GPA { get; set; }

        // Extra properties allowed
        public System.DateTime CreatedAt { get; set; } = System.DateTime.Now;

        public override string ToString() => $"{StudentId} | {Name} | GPA: {GPA}";
    }
}
