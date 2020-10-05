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
    public partial class CadastroPassaro : Form
    {
        
        private Login login = null;
        private Passaro passaro = null;
        public CadastroPassaro(int ID_Usuario, string Usuario, DateTime Expiracao)
        {
            InitializeComponent();
            login = new Login();
            login.id_usuario = ID_Usuario;
            login.usuario = Usuario;
            login.expiracao = Expiracao;
        }

        private void CadastroPassaro_Load(object sender, EventArgs e)
        {
            passaro = new Passaro();
            passaro.id_Proprietario = login.id_usuario;
            radioButton3.Checked = true;
            comboBox1.Items.Add("Silvestre");
            comboBox1.Items.Add("Pérola");
            comboBox1.Items.Add("Lutino");
            comboBox1.Items.Add("Canela");
            comboBox1.Items.Add("Cara Branca");
            comboBox1.Items.Add("Arlequim");
            comboBox1.Items.Add("Fulvo");
            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BD bd = new BD();
                passaro.mutacao = comboBox1.SelectedItem.ToString();
                passaro.descricao = txtDescricao.Text;
                StringBuilder sb = new StringBuilder("INSERT INTO Passaro (Proprietario, Sexo, Mutacao, Descricao, Ocupado) VALUES (@Proprietario, @Sexo, @Mutacao, @Descricao, false)");
                MySqlCommand command = new MySqlCommand(sb.ToString());
                command.Parameters.Add("@Proprietario", MySqlDbType.Int32);
                command.Parameters["@Proprietario"].Value = login.id_usuario;
                command.Parameters.Add("@Sexo", MySqlDbType.VarChar);
                command.Parameters["@Sexo"].Value = passaro.sexoP;
                command.Parameters.Add("@Mutacao", MySqlDbType.VarChar);
                command.Parameters["@Mutacao"].Value = passaro.mutacao;
                command.Parameters.Add("@Descricao", MySqlDbType.VarChar);
                command.Parameters["@Descricao"].Value = passaro.descricao;
                bd.executarComando(command);
                MessageBox.Show("passaro inserido com sucesso");
                txtDescricao.Text = "";
            }
            catch(Exception)
            {
                MessageBox.Show("passaro não inserido");
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) passaro.sexoP = "Macho";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
             if (radioButton2.Checked) passaro.sexoP = "Femea";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) passaro.sexoP = "Desconhecido";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gerencia gerencia = new Gerencia(login.id_usuario, login.usuario, login.expiracao);
            this.Hide();
            gerencia.Closed += (s, args) => this.Close();
            gerencia.Show();
        }
    }
}
