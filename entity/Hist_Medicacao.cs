using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calopsite.entity
{
    class Hist_Medicacao
    {
        private int ID_Medicacao;
        private int ID_Remedio;
        private int Quantidade;
        private int ID_Gaiola;

        public int id_medicacao { get => ID_Medicacao; set => ID_Medicacao = value; }
        public int id_remedio { get => ID_Remedio; set => ID_Remedio = value; }
        public int quantidade { get => Quantidade; set => Quantidade = value; }
        public int id_gaiola { get => ID_Gaiola; set => ID_Gaiola = value; }

        public bool checkQuantia(int qtdDisponivel, int qtdNecessaria)
        {
            return qtdDisponivel > qtdNecessaria ? true : false;
        }
        public float PrecoRemedio(int doseTotal,float qtdDose,float precoTotal)
        {
            return (precoTotal * qtdDose) / doseTotal;
        }
    }
}
