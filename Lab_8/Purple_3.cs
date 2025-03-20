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
    public class Purple_3 : Purple {
        private string _output;
        private (string, char)[] _codes;

        public string Output => _output;
        public (string, char)[] Codes => _codes;

        public Purple_3(string input) : base(input) {
            _codes = new (string, char)[0];
            _output = String.Empty;
        }

        private void AddCode(string pair, char code) {
            Array.Resize(ref _codes, _codes.Length + 1);
            _codes[^1] = (pair, code);
        }
        public override void Review() {
            if (Input == null) return;
            _codes = new (string, char)[0];

            var pairs = new string[Input.Length - 1];
            var ASCIIRangeUsed = new bool[126 - 32 + 1];

            for (int i = 0; i < Input.Length; i++) {

                if (i < Input.Length - 1)
                    pairs[i] = string.Concat(Input[i], Input[i + 1]);

                if (Input[i] >= 32 && Input[i] <= 126) 
                    ASCIIRangeUsed[Input[i] - 32] = true; 
            }

            pairs = pairs.Where(p => p.All(Char.IsLetter))
                         .GroupBy(p => p)
                         .OrderByDescending(g => g.Count())
                         .Select(g => g.Key)
                         .ToArray();
            
            var resultString = new StringBuilder(Input);
            int ASCIIPointer = -1;

            foreach (var p in pairs) {
                if (!resultString.ToString().Contains(p)) continue;

                ASCIIPointer = Array.FindIndex(ASCIIRangeUsed, ASCIIPointer + 1, b => b == false);

                var encodedChar = (char)(ASCIIPointer + 32);
                AddCode(p, encodedChar);
                resultString.Replace(p, encodedChar.ToString());

                if (_codes.Length == 5) break;
            }

                
            _output = resultString.ToString();
        }

        public override string ToString() {
            return _output;
        }
    }
}