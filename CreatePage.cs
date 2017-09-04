using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

class CrearPagina
    {
        private string _html;
        private string _htmltable;
        public CrearPagina(string templatePath)
        {
            _htmltable = "<table style='width: 100 % '><tr><th> Firstname </th><th> Lastname </th><th> Age </th></tr>";
            using (FileStream fileStream = new FileStream(templatePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _html = reader.ReadToEnd();
                }
            }
        }

        public void InsertarEnTabla(string formatoFila, string []data)
        {
            _htmltable = string.Concat(_htmltable, string.Format(formatoFila, data[0], data[1], data[2]));
        }

        public string Render(object values)
        {
            string output = _html;
            foreach (var p in values.GetType().GetProperties())
            {
                if(!p.Name.Equals("TABLA"))
                    output = output.Replace("[" + p.Name + "]", (p.GetValue(values, null) as string) ?? string.Empty);
            }
            _htmltable = string.Concat(_htmltable, "</table>");
            output = output.Replace("[TABLA]", _htmltable);
            return output;
        }
    }
/*
SE USA CON UN OBJETO CON LAS ETIQUETAS DEL TEMPLATE
 public class Program
    {
       static void Main()
        {
            var test = new[] {
                new[] { "here", "there", "mine" },
                new[] { "here1", "there1", "mine1" },
                new[] { "here2", "there1", "mine2" }
            };
            var template = new CrearPagina(@"Template.html");
            foreach(var ele in test)
            {
                template.InsertarEnTabla("<tr><td> {0} </td ><td> {1} </td><td><a href='https://google.com/?q={2}'> {2} </a></td></tr> ",ele);
            }
            var output = template.Render(new
            {
                TITLE = "My Web Page",
                TEST = "HOLA TEMPLATE",
                METAKEYWORDS = "Keyword1, Keyword2, Keyword3",
                BODY = "Body content goes here",
                ETC = "etc"
            });
            Console.WriteLine(output);
            File.WriteAllText(@"CentroPagos.html", output);
            Console.Read();
        }
    }

*/
