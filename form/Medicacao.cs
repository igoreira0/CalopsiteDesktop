using Calopsite.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calopsite
{
    public partial class Medicacao : Form
    {
        private Gaiola gaiola = new Gaiola();
        private Login login = new Login();
        private Hist_Medicacao hist_Medicacao = new Hist_Medicacao();
        public Medicacao(int ID_Usuario)
        {
            InitializeComponent();
            login.id_usuario = ID_Usuario;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gaiola.id_gaiola = int.Parse(comboBox1.SelectedValue.ToString());
                label2.Text = "Gaiola ID: " + gaiola.id_gaiola;
            }
            catch (Exception) { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Medicacao_Load(object sender, EventArgs e)
        {
            
            
            loadGaiolas();
            LoadMedicacao();
            
            
        }

        private void LoadMedicacao()
        {
            BD bd = new BD();
            StringBuilder str = new StringBuilder("SELECT ID_Insumo, Nome FROM Insumo WHERE Peso IS NULL");
            MySqlCommand command = new MySqlCommand(str.ToString());
            DataTable dtResultado = new DataTable();
            dtResultado.Clear();
            dtResultado = bd.executarConsulta(command);
            comboBox2.DataSource = null;
            comboBox2.DataSource = dtResultado;
            comboBox2.ValueMember = "ID_Insumo";
            comboBox2.DisplayMember = "Nome";
            comboBox2.Refresh();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                hist_Medicacao.id_medicacao = int.Parse(comboBox2.SelectedValue.ToString());
                hist_Medicacao.quantidade = int.Parse(textBox1.Text);
                hist_Medicacao.id_gaiola = gaiola.id_gaiola;
            }
            catch (Exception)
            {
                MessageBox.Show("Valor Invalido");
            }
            BD bd = new BD();
            StringBuilder str = new StringBuilder("INSERT INTO Hist_Medicacao (ID_Remedio, Quantidade, ID_Gaiola) VALUES (@ID_Medicacao, @Quantidade, @ID_Gaiola)");
            MySqlCommand command = new MySqlCommand(str.ToString());
            command.Parameters.Add("@ID_Medicacao", MySqlDbType.Int32);
            command.Parameters["@ID_Medicacao"].Value = hist_Medicacao.id_medicacao;
            command.Parameters.Add("@Quantidade", MySqlDbType.Int32);
            command.Parameters["@Quantidade"].Value = hist_Medicacao.quantidade;
            command.Parameters.Add("@ID_Gaiola", MySqlDbType.Int32);
            command.Parameters["@ID_Gaiola"].Value = hist_Medicacao.id_gaiola;
            try
            {
                bd.executarComando(command);
                MessageBox.Show("Medicacao realizada com sucesso");
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao inserir dado");
            }
        }
    }
}
