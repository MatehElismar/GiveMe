using System;
using System.Collections.Generic;
using C = System.Console;

namespace GiveMe
{
   
    public static class SymbolTable
    { 
        public static List<SymbolTableItem> Items{ get; set; }
        static SymbolTable()
        { 
            Items = new List<SymbolTableItem>();
        }

        new public static void ToString()
        { C.WriteLine("           TABLA DE SIMBOLOS               ");
            C.WriteLine("Linea       Tipo                Lexema");
            C.WriteLine("======================================");
            
            foreach (var item in Items)
            {
                C.CursorLeft = 0;
                C.Write(item.Line);
                C.CursorLeft = 11;
                C.Write(item.TokenType);
                C.CursorLeft = 23;
                C.Write(item.Lexema);
                C.CursorTop++;
            }
            C.WriteLine();
        }


        
    }
}