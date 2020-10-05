using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calopsite.entity
{
    class Passaro
    {
        private int ID_passaro;
        private int Proprietario;
        private string sexo;
        private string Descricao;
        private string Mutacao;
        private bool Ocupado;
        public int id_passaro { get => ID_passaro; set => ID_passaro = value; }
        public int id_Proprietario { get => Proprietario; set => Proprietario = value; }
        public string sexoP { get => sexo; set => sexo = value; }
        public string mutacao { get => Mutacao; set => Mutacao = value; }
        public string descricao { get => Descricao; set => Descricao = value; }
        private bool ocupado{ get => Ocupado; set => Ocupado = value; }


}

}
