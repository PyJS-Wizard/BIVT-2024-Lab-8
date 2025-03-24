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
            = {'.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/'};
        public string Input => _input;

        public Purple(string input) {
            _input = input;
        }

        public abstract void Review();

        protected bool IsInWord(char c) {
            return char.IsLetter(c) || c == '-' || c == '\''; 
        }

        protected string FormatNumbers(string s) {  // not used for now
            if (string.IsNullOrEmpty(s)) return s;
                
            var result = new StringBuilder();
            int i = 0;
            bool lastIsPunctOrSpace = true;
            
            while (i < s.Length) {
                
                char cur = s[i];

                if (char.IsDigit(cur)) {
                    int start = i;
                    bool hasDecimalPoint = false;
                    
                    var provider = System.Globalization.CultureInfo.InvariantCulture;

                    for (; i < s.Length; i++) {
                        cur = s[i];

                        if ((cur == '.' || cur == ',') && !hasDecimalPoint) {
                            hasDecimalPoint = true;
                            if (cur == ',')   
                                provider = new System.Globalization.CultureInfo("ru-RU");  
                        } else if (!char.IsDigit(cur))
                            break;
                    }
                    
                    string numberStr = s[start..i];
                    string formattedString = numberStr;

                    if (lastIsPunctOrSpace && ((i < s.Length && (punctuationMarks.Contains(cur) || cur == ' ')) || (i == s.Length)))
                        formattedString = double.Parse(numberStr, provider).ToString("f4", provider);
                        
                    result.Append(formattedString);

                } else {
                    lastIsPunctOrSpace = punctuationMarks.Contains(cur) || cur == ' ';
                    result.Append(s[i++]);
                }

            }
            
            return result.ToString();
        }
    }
}