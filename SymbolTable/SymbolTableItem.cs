using System;

namespace GiveMe
{
    class SymbolTableItem
    {
        public int Line{ get; set; }
        public int Column{ get; set; }
        public string Lexema{ get; set; }
        public Consts.IDTYPES IDType{ get; set; }
        public SymbolTableItem()
        {

        }
    }
}