using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calopsite.entity
{
    class Gaiola
    {
        private int ID_Gaiola;
        private string Descricao;
        private int Filhotes;

        public int id_gaiola { get => ID_Gaiola; set => ID_Gaiola = value; }
        public string descricao { get => Descricao; set => Descricao = value; }
        public int filhotes { get => Filhotes; set => Filhotes = value; }


    }
}
