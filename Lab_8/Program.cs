using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8 {
    class Program {
        static void Main(string[] args) {
            

            var testInput = "aaa*lli).**lll..ye)";
            var p = new Purple_4(testInput, new (string, char)[] {("Az", '*'), ("YY", ')'), ("uo", '.')});

            p.Review();


            System.Console.WriteLine(p.ToString());
        }
    }
}
