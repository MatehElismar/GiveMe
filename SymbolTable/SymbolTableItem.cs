using System;

namespace GiveMe
{
    public class SymbolTableItem
    {
        public int Line{ get; set; } 

        public TokenType TokenType{ get; set; }
        public string Lexema{ get; set; } 

        public string Info{ get; set; }
        public SymbolTableItem()
        { 
        }

        public SymbolTableItem(int Line, TokenType TokenType, string Lexema, string Info = "")
        { 
            this.Line = Line;
            this.TokenType = TokenType;
            this.Lexema = Lexema;
            this.Info = Info;
        }
    }
}