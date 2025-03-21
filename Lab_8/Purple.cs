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
using System.Windows.Markup;

namespace Lab_8 {
    public abstract class Purple {
        private string _input;
        protected static readonly char[] punctuationMarks 
            = {'.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/', '-'}; /// REMOVE! "-"
        public string Input => _input;

        public Purple(string input) {
            _input = input;
        }

        public abstract void Review();

        protected bool IsInWord(char c) {
            return char.IsLetter(c) || c == '-' || c == '\''; 
        }

        public string FormatNumbers(string s) {
            if (string.IsNullOrEmpty(s)) return s;
                
            var result = new StringBuilder();
            int i = 0;
            
            while (i < s.Length) {

                if (char.IsDigit(s[i])) {
                    int start = i;
                    bool hasDecimalPoint = false;
                    
                    for (; i < s.Length; i++) {
                        if ((s[i] == '.' || s[i] == ',') && !hasDecimalPoint) 
                            hasDecimalPoint = true;
                        else if (!char.IsDigit(s[i]))
                            break;
                    }
                    
                    string numberStr = s[start..i];
                    string formattedString = numberStr;

                    if ((i < s.Length && (punctuationMarks.Contains(s[i]) || s[i] == ' ')) || (i == s.Length))
                        formattedString = double.Parse(numberStr).ToString("f4");

                    result.Append(formattedString);

                } else result.Append(s[i++]);

            }
            
            return result.ToString();
        }
    }
}