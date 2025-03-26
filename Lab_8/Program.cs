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

            string test = """Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова "fjǫrðr". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – "фьорды", в Шотландии – "фьордс", в Исландии – "фьордар". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.""";
            string expected = """Фь!ды – это ущелья, ф!#рующиеся ледника# и заполняющиеся м!ской водой. Наз$ние происходит от древнескандинавского сло$ "fjǫrðr". Эти глубокие заливы, окруженные высоки# г!а#, представляют зах$ты$ющие виды и природную красоту. Они популярны среди туристов и известны под разны# наз$ния#: в Н!вегии – "фь!ды", в Шотландии – "фь!дс", в Исландии – "фь!дар". Фь!ды играют $жную роль в культуре и туризме региона, продолжая вдохновлять людей со всего #ра.""";
            var p = new Purple_3(test);
            p.Review();
            System.Console.WriteLine(p.ToString());

        }

    }
}

