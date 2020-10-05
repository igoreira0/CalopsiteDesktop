using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calopsite.entity
{
    class Insumo
    {
        private int ID_Insumo;
        private string Nome;
        private int Quantidade;
        private float Peso;
        private float Preco;

        public int id_insumo { get => ID_Insumo; set => ID_Insumo = value; }
        public string nome { get => Nome; set => Nome = value; }
        public int quantidade { get => Quantidade; set => Quantidade = value; }
        public float peso { get => Peso; set => Peso = value; }
        public float preco { get => Preco; set => Preco = value; }


    }
}
