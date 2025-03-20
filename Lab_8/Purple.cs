using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8 {
    public abstract class Purple {
        private string _input;
        protected static readonly char[] punctuationMarks 
            = {'.', '!', '?', ',', ':', '\\', ';', '–', '(', ')', '[', ']', '{', '}', '/'};
        public string Input => _input;

        public Purple(string input) {
            _input = input;
        }

        public abstract void Review();

        protected bool IsInWord(char c) {
            return char.IsLetter(c) || c == '-' || c == '\''; 
        }
    }
}