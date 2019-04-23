using System;
using System.IO;
using System.Collections.Generic;
using C = System.Console; 

namespace GiveMe
{
    public class Lexico
    {
        // Variables privadas 
        // ...
        //PROPERTIES
        // Archivo que se leera!
        public string File { get; set; }
        public List<string> SourceCode { get; set; }
        public List<string> OriginalCode { get; set; }

        //CONSTRUCTORS
        public Lexico()
        {
            this.OriginalCode = new List<string>();
            this.SourceCode = new List<string>();

        }
        public Lexico(string file)
        {
            this.OriginalCode = new List<string>();
            this.SourceCode = new List<string>();

            this.File = file;

        }

        //INSTANCE METHODS
        public List<string> Read()
        {
            if (System.IO.File.Exists(this.File))
            {
                using (var source = new StreamReader(this.File))
                {
                    while (!source.EndOfStream)
                    {
                        var line = source.ReadLine();
                        this.OriginalCode.Add(line);
                        this.SourceCode.Add(line);
                    }

                    // this.SourceCode = this.OriginalCode;
                    return this.OriginalCode; 
                }
            }
            else C.WriteLine("No such file or directory {0}\nfatal error: no input files\ncompilation terminated", this.File);
            return null;
        }

        public List<string> DeleteSpacesAndComments()
        {
            for (int i = 0; i < this.SourceCode.Count; i++)
            {
                // Variable temporal que almacena el el valor de la linea actual
                string line = this.SourceCode[i];
                // Eliminamos los espacion de la linea (para que los cambios se guarden llamamos al objeto original ya que la variable line solo es temporal [por valor]);
                line = line.Replace(" ", ""); 

                // Si es una linea vacia la la marcamos para eliminacion
                if (line.Length == 0)
                {
                    this.SourceCode[i] = "Eliminar";
                    continue;
                }
                // Si es una linea Comentario Tambien la la marcamos para eliminacion 
                if (line.Substring(0, 2) == "//")
                {
                    this.SourceCode[i] = "Eliminar";
                }
            }

            //Eliminamos todas las lineas de codigo que teniamos marcadas 
            this.SourceCode.RemoveAll(x => x == "Eliminar");
            return this.SourceCode;
        }

        public void ShowProcessedCode()
        {
            C.ForegroundColor = ConsoleColor.Green;
            C.WriteLine("{0} lineas de codigo", this.SourceCode.Count);
            C.WriteLine("\t\t===================Codigo Fuentte=========================\t\t");
            C.ForegroundColor = ConsoleColor.White;

            foreach (var item in this.SourceCode)
            {
                Console.WriteLine(item);
            }
        }

        public List<Token> GenerateTokenTree()
        {
            var tokens = new List<Token>();
            int lineNum = 0;
            foreach (var line in SourceCode)
            { 
                lineNum = OriginalCode.FindIndex(x => x == line) + 1;
                if(line[line.Length -1] == ',')
                {
                    Consts.throwError(lineNum,002);
                    return null;
                }
                var words = line.Split(" ");
                foreach (var w in words)
                { 
                    var t = new Token();
                    /* En cada pasada de ifs se le pone el tipo de token y el valor (si lo necesitan) 
                    sera la cantidad de elementos en la tabla de simbolos + 1,
                     que es la posicion que tendra el dato una vez que se agrege */
                    

                    if(w.Length == 0) continue;
                    var word = w; 
                    var comma = false;
                    if(word[word.Length -1] == ','){ 
                        // Esto identifica las comas que hay al final de una palabra ex: hola, perro,
                        //las elimina para que se pueda reconocer su tipoDeLexema
                        // y se marca para agregarse a la lista despues de agregar la palabra!
                        word = word.Remove(word.Length -1);
                        comma = true;  
                        //Simbolo lo encontrado despues de la <word>!! ( , ) 
                    }
                    if(Consts.Patterns.Find(x => x.Name == "ID").Match(word))
                    {
                        var e = new SymbolTableItem();
                        e.Lexema = word;
                        e.TokenType = TokenType.ID;
                        e.Line = lineNum;
                        SymbolTable.Items.Add(e);

                        // Token Info
                            t.Type = TokenType.ID;
                            t.Value = (SymbolTable.Items.Count -1).ToString();

                        if(Consts.KeyWords.Find(x => x.Lexema == word) != null)
                        {
                            // Es un ID Reservado
                            
                            //   C.WriteLine("KeyWord Found -> {0}", word);
                        }
                        else
                        {
                            // Es un ID crado por el usuario
                            // C.WriteLine("ID Found -> {0}", word);
                        } 
                    }
                    else if(Consts.Patterns.Find(x => x.Name == "NUMBER").Match(word))
                    {

                        // Es un numero

                        // Token Info
                            t.Type = TokenType.NUMBER;
                            t.Value = word;

                        // C.WriteLine("NUMBER Found -> {0}", word);
                    }
                    else if(Consts.Patterns.Find(x => x.Name == "LITERAL").Match(word))
                    {
                        // Es una cadena
                        //  Tabla De Simbolos Info
                        var e = new SymbolTableItem();
                        e.Lexema = word;
                        e.TokenType = TokenType.LITERAL;
                        e.Line = lineNum;
                        SymbolTable.Items.Add(e);

                        // Token Info
                            t.Type = TokenType.LITERAL;
                            t.Value = (SymbolTable.Items.Count -1).ToString();
                        // C.WriteLine("LITERAL Found -> {0}", word); 
                    }
                    else if(Consts.KeyWords.Find(x => x.Type == KeyWordType.Symbol && x.Lexema == word) != null )
                    {
                        // Es un SYMBOLO

                        // Token Info
                            t.Type = TokenType.SYMBOL;
                            t.Value = word;

                        // C.WriteLine("SYMBOL Found ({0})", word);

                    }
                    else if(Consts.KeyWords.Find(x => x.Type == KeyWordType.OperationMark && x.Lexema == word) != null )
                    {
                        // Es un operador

                        // Token Info
                            t.Type = TokenType.OPERATOR;
                            t.Value = word;
                        // C.WriteLine("OPERATOR Found ({0})", word);

                    }
                    else
                    {
                        // C.WriteLine("Unknown Word Found -> {0}", word);
                        Consts.throwError(lineNum, 001);
                        return null;
                    }


                    tokens.Add(t);

                    if(comma)
                    { 
                        // C.WriteLine("SYMBOL Found -> (,)");
                        tokens.Add(new Token(TokenType.SYMBOL, ","));
                    }   
                }
                // se acaba la linea / este token no aparecera en la representacion grafica (END = \n)
                tokens.Add(new Token(TokenType.SYMBOL, "END"));
            } 

            return tokens;
        }

        private void MatchWord(string word)
        {

        }

        //STATIC METHODS
    }
}
