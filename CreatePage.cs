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
