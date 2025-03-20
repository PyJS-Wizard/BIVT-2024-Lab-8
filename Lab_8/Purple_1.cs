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
    public class Purple_1 : Purple {
        private string _output;
  
        public string Output => _output;

        public Purple_1(string input) : base(input) {
            _output = String.Empty;
        }

        private void ReverseStringBuilder(StringBuilder array) {
            for (int k = 0; k < array.Length / 2; k++)
                (array[k], array[^(k + 1)]) = (array[^(k + 1)], array[k]);
        }
        public override void Review() {
            if (Input == null) return;
            
            var resultString = new StringBuilder();
            var curWord = new StringBuilder();

            for (int i = 0; i < Input.Length; i++) {
                char curChar = Input[i];

                if (IsInWord(curChar)) 
                    curWord.Append(curChar);
                else {
                    ReverseStringBuilder(curWord);

                    resultString.Append(curWord);
                    resultString.Append(curChar);
                    
                    curWord.Clear();
                }

            }

            ReverseStringBuilder(curWord);
            resultString.Append(curWord);

           _output = resultString.ToString();
        }

        public override string ToString() {
            return _output;
        }
    }
}