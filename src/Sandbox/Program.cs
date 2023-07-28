using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox
{
    class Program
    {
        private const string text =
            @"The Tao gave birth to machine language.  Machine language gave birth
to the assembler.
The assembler gave birth to the compiler.  Now there are ten thousand
languages.
Each language has its purpose, however humble.  Each language
expresses the Yin and Yang of software.  Each language has its place within
the Tao.
But do not program in COBOL if you can avoid it.
        -- Geoffrey James, 'The Tao of Programming' ";

        private const string text2 =
            @"C makes it easy for you to shoot yourself in the foot. C++ makes that harder, but when you do, it blows away your whole leg. (с) Bjarne Stroustrup";

        static void Main(string[] args)
        {
            var splited = text.Split(' ');
            var words = new List<string>();
            foreach (var s in splited)
            {
                if (!string.IsNullOrEmpty(s) && s.Any(x => char.IsLetter(x)))
                {
                    var tmp = s.Replace("\r\n", string.Empty);
                    words.Add(tmp);
                    Console.WriteLine(tmp);
                }
            }

            var listNonRepeatingCharsInWords = new StringBuilder();
            foreach (var word in words)
            {
                var res = FirstNonRepeatingSymbolInWord(word);
                listNonRepeatingCharsInWords.Append(res);
            }
            var result = FirstNonRepeatingSymbolInWord(listNonRepeatingCharsInWords.ToString());
            
            Console.WriteLine(result);
        }

        public static char FirstNonRepeatingSymbolInWord(string word)
        {
            // symbol and count of repeating
            Dictionary<char, int> groups = new Dictionary<char, int>();
            foreach (var symbol in word)
            {
                if (groups.ContainsKey(symbol))
                {
                    groups[symbol] += 1;
                }
                else
                {
                    groups.Add(symbol, 1);
                }
            }

            return groups.FirstOrDefault(x => x.Value == 1).Key;
        }
    }
}