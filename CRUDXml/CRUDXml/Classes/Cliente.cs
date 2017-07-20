using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXml.Classes
{
    public class Cliente
    {
        #region Atributos
        private string _nome;
        private string _email;
        #endregion

        #region Propriedades
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }
}
