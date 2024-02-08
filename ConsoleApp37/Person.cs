using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37 {
    internal class Person {
        public string? Fullname { get; set; }
        public byte Age { get; set; }

        public Person(string? fullname, byte age) {
            Fullname = fullname;
            Age = age;
        }

        override public string ToString() {
            return $"Fullname: {Fullname}, Age: {Age}";
        }
    }
}
