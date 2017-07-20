using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ConfiguracaoXmlEtiquetas.Classes
{
    public class Etiquetas
    {
        private List<Etiqueta> etiquetas;
        public Etiquetas()
        {
            this.etiquetas = new List<Etiqueta>();
        }
        public void Adicionar(Etiqueta etiqueta)
        {
            if (etiquetas.Count(c => c.Descricao.Equals(etiqueta.Descricao)) > 0)
            {
                throw new Exception("Já existe um registro com este nome");
            }
            else
            {
                etiquetas.Add(etiqueta);
            }
        }

        public void Remover(Etiqueta etiqueta)
        {
            etiquetas.Remove(etiqueta);
        }

        public List<Etiqueta> ListarTodos()
        {
            return etiquetas;
        }

        public void Salvar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Etiqueta>));
            FileStream fs = new FileStream("E://Etiquetas.xml", FileMode.Truncate);
            ser.Serialize(fs, etiquetas);
            fs.Close();
        }

        public void Carregar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Etiqueta>));
            FileStream fs = new FileStream("E://Etiquetas.xml", FileMode.OpenOrCreate);
            try
            {
                etiquetas = ser.Deserialize(fs) as List<Etiqueta>;
            }
            catch (InvalidOperationException ex)
            {
                ser.Serialize(fs, etiquetas);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
