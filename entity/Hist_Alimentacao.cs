using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calopsite.entity
{
    class Hist_Alimentacao
    {
        private int ID_Alimentacao;
        private int ID_Racao;
        private float Peso;
        private int ID_Gaiola;

        public int id_alimentacao { get => ID_Alimentacao; set => ID_Alimentacao = value; }
        public int id_racao { get => ID_Racao; set => ID_Racao = value; }
        public float peso { get => Peso; set => Peso = value; }
        public int id_gaiola { get => ID_Gaiola; set => ID_Gaiola = value; }

        public bool checkQuantia(int qtdDisponivel, int qtdNecessaria)
        {
            return qtdDisponivel > qtdNecessaria ? true: false;
        }
        public float GastoAlimentacao(float precoRacao, float peso, float pesoFracio)
        {
            return (precoRacao * pesoFracio) / peso;
        }
    }
}
