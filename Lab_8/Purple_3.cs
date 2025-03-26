using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
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
        public (string, char)[] Codes => ((string, char)[])_codes?.Clone();

        public Purple_3(string input) : base(input) {}

        private void AddCode(string pair, char code) {
            Array.Resize(ref _codes, _codes.Length + 1);
            _codes[^1] = (pair, code);
        }

        private bool[] GetASCIICharArray(string s) {
            var ASCIIRangeUsed = new bool[126 - 32 + 1];

            foreach (var c in s) {
                if (c >= 32 && c <= 126) 
                    ASCIIRangeUsed[c - 32] = true; 
            }
        
            return ASCIIRangeUsed;
        }
        public override void Review() {
            if (Input == null) return;

            _codes = new (string, char)[0];
            
            if (Input.Length == 0) {
                _output = Input;
                return;
            }
            
            var usedASCIIArray = GetASCIICharArray(Input);
            var ASCIILastUsedIndex = -1;

            var pairs = new string[Input.Length - 1];

            for (int i = 0; i < Input.Length; i++) {
                if (i < Input.Length - 1)
                    pairs[i] = string.Concat(Input[i], Input[i + 1]);
            }

            pairs = pairs.Where(p => p.All(char.IsLetter))
                         .GroupBy(p => p)
                         .OrderByDescending(g => g.Count())
                         .Take(5)
                         .Select(g => g.Key)
                         .ToArray();
            
            
            var resultString = new StringBuilder(Input);

            foreach (var p in pairs) {
                ASCIILastUsedIndex = Array.FindIndex(usedASCIIArray, ASCIILastUsedIndex + 1, c => c == false); 
                var encodedChar = (char)(ASCIILastUsedIndex + 32);
                AddCode(p, encodedChar);
                resultString.Replace(p, encodedChar.ToString());
            }

                
            _output = resultString.ToString();
        }

        public override string ToString() {
            return _output;
        }
    }
}