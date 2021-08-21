using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student
    {
        public static int Id = 0;
        public string Name { get; set; }
        public  int NumberGroup { get; set; }
        public byte[] Photo { get; set; }
        public Student(string Name, int NumberGroup, byte[] Photo)
        {
            Id++;
            this.Name = Name;
            this.NumberGroup = NumberGroup;
            this.Photo = Photo;
        }
    }
}
