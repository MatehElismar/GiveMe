using System;
using C = System.Console;
using System.Text.RegularExpressions;

namespace GiveMe
{
    public class Pattern
    {

        public string Name{ get; set; }
        public string Exp{ get; set; }
        public Pattern(string Name, string Exp)
        {
            this.Name = Name;
            this.Exp = Exp;
        }

        public bool Match(string word)
        {  
            return Regex.IsMatch(word, this.Exp);
        }
    }
}