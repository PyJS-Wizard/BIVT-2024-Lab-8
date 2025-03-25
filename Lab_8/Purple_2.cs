using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Lab_8 {
    public class Purple_2 : Purple {               
        private string[] _output;
        public string[] Output => (string[])_output?.Clone();

        public Purple_2(string input) : base(input) {
            _output = Array.Empty<string>();
        }

        public override void Review() {
            if (Input == null) return;

            var spaceSplit = Input.Trim().Replace('\n', ' ').Split();

            var resultLines = new StringBuilder();
            var curLine = new StringBuilder();

            for (int i = 0; i < spaceSplit.Length; i++) {
                var word = spaceSplit[i];
                if (word.Length == 0) continue;

                int n = curLine.Length;
                if ((n + 1 + word.Length <= 50) || (n == 0 && word.Length >= 50)) {
                    if (n > 0) curLine.Append(' ');
                    curLine.Append(word);
                } 
                
                if (n + 1 + word.Length > 50 || i == spaceSplit.Length - 1) {
                    if (resultLines.Length > 0) resultLines.Append('\n');

                    resultLines.Append(curLine);
                    
                    curLine.Clear();
                    curLine.Append(word);

                    if (n + 1 + word.Length > 50 && i == spaceSplit.Length - 1) {
                        resultLines.Append("\n" + curLine);
                    }
                }
            }


            _output = resultLines.ToString().Split('\n');
        }

        public override string ToString() {
            if (_output == null) return null;
            
            return String.Join('\n', _output);
        }
    }
}

