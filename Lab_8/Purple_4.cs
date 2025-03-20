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
    public class Purple_4 : Purple {
        private string _output;
        private (string, char)[] _codes;
        public string Output => _output;

        public Purple_4(string input, (string, char)[] codes) : base(input) {
            _output = String.Empty;
            _codes = codes;
        }

        public override void Review() {
            if (Input == null || _codes == null) return;

            var resultString = new StringBuilder(Input);

            foreach (var pair in _codes) {
                var letters = pair.Item1;
                var cipheredChar = pair.Item2;

                resultString.Replace(cipheredChar.ToString(), letters);
            }

            _output = resultString.ToString();
        }

        public override string ToString() {
            return _output;
        }
    }
}