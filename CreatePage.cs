using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

class CrearPagina
    {
        private string _html;

        public CrearPagina(string templatePath)
        {
            using (FileStream fileStream = new FileStream(templatePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _html = reader.ReadToEnd();
                }
            }
        }

        public string Render(object values)
        {
            string output = _html;
            foreach (var p in values.GetType().GetProperties())
            {

                output = output.Replace("[" + p.Name + "]", (p.GetValue(values, null) as string) ?? string.Empty);
            }
            
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
