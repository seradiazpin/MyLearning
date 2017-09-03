using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

class CrearPagina
    {
        private string _html;
        private string _htmltable;
        private string _htmlFila; 
        public CrearPagina(string templatePath)
        {
            _htmltable = "<table style='width: 100 % '><tr><th> Firstname </th><th> Lastname </th><th> Age </th></tr>";
            _htmlFila = "<tr><td> {0} </td ><td> {1} </td><td> {2} </td></tr> ";
            using (FileStream fileStream = new FileStream(templatePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _html = reader.ReadToEnd();
                }
            }
        }

        public void GenerarTabla(string []data)
        {
            _htmltable = string.Concat(_htmltable, string.Format(_htmlFila, data[0], data[1], data[2]));
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
            var template = new CrearPagina(@"Template.html");
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
