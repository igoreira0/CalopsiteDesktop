using Calopsite.entity;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calopsite
{
    public partial class Gerencia : Form
    {
        private Login login = null;
        private Gaiola gaiola = new Gaiola();
        
        public Gerencia(int ID_Usuario, string Usuario, DateTime expiracao)
        {
            InitializeComponent();
            login = new Login();
            login.id_usuario = ID_Usuario;
            login.usuario = Usuario;
            login.expiracao = expiracao;
        }

        private void loadGaiolas()
        {
            BD bd = new BD();
            StringBuilder str = new StringBuilder("SELECT DISTINCT Gaiola.Descricao, Gaiola.ID_Gaiola FROM Gaiola, Passaro, Passaro_Gaiola WHERE Passaro.Proprietario = @ID_Usuario AND Passaro.ID_Passaro = Passaro_Gaiola.ID_Passaro AND Passaro_Gaiola.ID_Gaiola = Gaiola.ID_Gaiola");
            MySqlCommand command = new MySqlCommand(str.ToString());
            command.Parameters.Add("@ID_Usuario", MySqlDbType.Int32);
            command.Parameters["@ID_Usuario"].Value = login.id_usuario;
            DataTable dtResultado = new DataTable();
            dtResultado.Clear();
            dtResultado = bd.executarConsulta(command);
            comboBox1.DataSource = null;
            comboBox1.DataSource = dtResultado;
            comboBox1.ValueMember = "ID_Gaiola";
            comboBox1.DisplayMember = "Descricao";
            comboBox1.Refresh();
        }
        private void Gerencia_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("Bem Vindo, você está logado como {0}", login.usuario.ToUpper());
            try
            {
                double exp = (login.expiracao - DateTime.Now).TotalDays;
                toolStripStatusLabel2.Text = String.Format("Faltam {0} dias para seu plano expirar.", Convert.ToInt32(exp)+1);
            }
            catch (ArgumentException err)
            {
                
                MessageBox.Show(err.ToString());
            }
            loadGaiolas();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void novoPassaroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroPassaro cad = new CadastroPassaro(login.id_usuario, login.usuario, login.expiracao);
            cad.Closed += (s, args) => this.Close();
            cad.Show();
        }

        private void retirarPassaroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GerenciaPassaro gerencia = new GerenciaPassaro(login.id_usuario, login.usuario, login.expiracao);
            gerencia.Closed += (s, args) => this.Close();
            gerencia.Show();
        }

        private void inserirNovaGaiolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroGaiola cadastroGaiola = new CadastroGaiola(login.id_usuario);
            cadastroGaiola.Show();
        }

        private void adicionarMedicamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroInsumo insumo = new CadastroInsumo();
            insumo.Show();
        }

        private void manejoGaiolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciarGaiola gerenciarGaiola = new GerenciarGaiola(login.id_usuario);
            gerenciarGaiola.Show();

        }

        private void alimentarGaiolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alimentacao alimentacao = new Alimentacao(login.id_usuario);
            alimentacao.Show();
        }

        private void medicarGaiolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medicacao medicacao = new Medicacao(login.id_usuario);
            medicacao.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gaiola.id_gaiola = int.Parse(comboBox1.SelectedValue.ToString());
                if (gaiola.id_gaiola < 1) throw new ArgumentException("loading");
                Hist_Alimentacao hist = new Hist_Alimentacao();
                Hist_Medicacao med = new Hist_Medicacao();
                BD bd = new BD();
                float precoRacao = 0;
                float precoDose = 0;
                StringBuilder str = new StringBuilder("SELECT DISTINCT Insumo.Preco, Hist_Alimentacao.Peso,Insumo.Peso as inPeso FROM Gaiola, Passaro, Passaro_Gaiola,Hist_Alimentacao,Insumo WHERE Passaro.Proprietario = @ID_Usuario AND Passaro.ID_Passaro = Passaro_Gaiola.ID_Passaro AND Passaro_Gaiola.ID_Gaiola = @Gaiola AND Gaiola.ID_Gaiola = Hist_Alimentacao.ID_Gaiola AND Hist_Alimentacao.ID_Racao = Insumo.ID_Insumo AND Insumo.Peso IS NOT NULL");
                MySqlCommand command = new MySqlCommand(str.ToString());
                command.Parameters.Add("@ID_Usuario", MySqlDbType.Int32);
                command.Parameters["@ID_Usuario"].Value = login.id_usuario;
                command.Parameters.Add("@Gaiola", MySqlDbType.Int32);
                command.Parameters["@Gaiola"].Value = gaiola.id_gaiola;
                DataTable dtResultado = new DataTable();
                dtResultado.Clear();
                dtResultado = bd.executarConsulta(command);
                for(int i = 0; i<dtResultado.Rows.Count; i++)
                {
                    precoRacao += hist.GastoAlimentacao(float.Parse(dtResultado.Rows[i]["Preco"].ToString()), float.Parse(dtResultado.Rows[i]["inPeso"].ToString()), float.Parse(dtResultado.Rows[i]["Peso"].ToString()));
                }
                label3.Text = "Gasto Alimentação: " + precoRacao;
                str = new StringBuilder("SELECT DISTINCT Insumo.Preco, Hist_Medicacao.Quantidade, Insumo.Quantidade as inQuantidade FROM Gaiola, Passaro, Passaro_Gaiola,Hist_Medicacao, Insumo WHERE Passaro.Proprietario = @ID_Usuario AND Passaro.ID_Passaro = Passaro_Gaiola.ID_Passaro AND Passaro_Gaiola.ID_Gaiola = @Gaiola AND Gaiola.ID_Gaiola = Hist_Medicacao.ID_Gaiola AND Hist_Medicacao.ID_Remedio = Insumo.ID_Insumo AND Insumo.Quantidade IS NOT NULL");
                command = new MySqlCommand(str.ToString());
                command.Parameters.Add("@ID_Usuario", MySqlDbType.Int32);
                command.Parameters["@ID_Usuario"].Value = login.id_usuario;
                command.Parameters.Add("@Gaiola", MySqlDbType.Int32);
                command.Parameters["@Gaiola"].Value = gaiola.id_gaiola;
                dtResultado = new DataTable();
                dtResultado.Clear();
                dtResultado = bd.executarConsulta(command);
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    precoDose += med.PrecoRemedio(int.Parse(dtResultado.Rows[i]["Quantidade"].ToString()), int.Parse(dtResultado.Rows[i]["inQuantidade"].ToString()), float.Parse(dtResultado.Rows[i]["Preco"].ToString()));
                }
                label4.Text = "Gasto Medicação: " + precoDose;
            }
            catch (Exception) { }

        }
    }
}
