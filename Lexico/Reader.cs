using System;
using System.IO;
using System.Collections.Generic;
using C = System.Console;

namespace Lexico
{
    public class Reader
    {
        // Variables privadas 
        // ...
        //PROPERTIES
        // Archivo que se leera!
        public string File { get; set; }
        public List<string> SourceCode { get; set; }

        //CONSTRUCTORS
        public Reader()
        {
            this.SourceCode = new List<string>();
        }
        public Reader(string file)
        {
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
                        this.SourceCode.Add(source.ReadLine());
                    }

                    return this.SourceCode; 
                }
            }
            else C.WriteLine("No such file or directory\nfatal error: no input files\ncompilation terminated");
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

        //STATIC METHODS
    }
}
