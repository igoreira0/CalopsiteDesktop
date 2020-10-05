using Calopsite.entity;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calopsite
{
    public partial class GerenciaPassaro : Form
    {
        private Login login = null;
        private Passaro passaro = null;
        private string sexo;
        public GerenciaPassaro(int ID_Usuario, string Usuario, DateTime Expiracao)
        {
            InitializeComponent();
            login = new Login();
            login.id_usuario = ID_Usuario;
            login.usuario = Usuario;
            login.expiracao = Expiracao;
        }
    

        private void GerenciaPassaro_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Silvestre");
            comboBox2.Items.Add("Pérola");
            comboBox2.Items.Add("Lutino");
            comboBox2.Items.Add("Canela");
            comboBox2.Items.Add("Cara Branca");
            comboBox2.Items.Add("Arlequim");
            comboBox2.Items.Add("Fulvo");
            comboBox2.Refresh();
            Refreshcmb1();
        }

        private void Refreshcmb1()
        {
            BD bd = new BD();
            StringBuilder str = new StringBuilder("SELECT DISTINCT Passaro.ID_Passaro, Passaro.Proprietario, Passaro.Sexo, Passaro.Descricao FROM Passaro, Login WHERE Passaro.Proprietario = @ID_Usuario");
            MySqlCommand command = new MySqlCommand(str.ToString());
            command.Parameters.Add("@ID_Usuario", MySqlDbType.Int32);
            command.Parameters["@ID_Usuario"].Value = login.id_usuario;
            DataTable dtResultado = new DataTable();
            dtResultado.Clear();
            dtResultado = bd.executarConsulta(command);
            comboBox1.DataSource = null;
            comboBox1.DataSource = dtResultado;
            comboBox1.ValueMember = "ID_Passaro";
            comboBox1.DisplayMember = "Descricao";
            try
            {
                comboBox1.SelectedIndex = 0;
            }catch(Exception){ }
            comboBox1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BD bd = new BD();
            StringBuilder str = new StringBuilder("SELECT * FROM Passaro WHERE ID_Passaro = @Value");
            MySqlCommand command = new MySqlCommand(str.ToString());

            try
            {
                command.Parameters.Add("@Value", MySqlDbType.Int32);
                command.Parameters["@Value"].Value = int.Parse(comboBox1.SelectedValue.ToString());
                DataTable dtResultado = new DataTable();
                dtResultado.Clear();
                dtResultado = bd.executarConsulta(command);
                passaro = new Passaro();
                passaro.id_passaro = int.Parse(dtResultado.Rows[0]["ID_Passaro"].ToString());
                passaro.sexoP = dtResultado.Rows[0]["Sexo"].ToString();
                switch (passaro.sexoP)
                {
                    case "Macho":
                        radioButton1.Checked = true;
                        break;
                    case "Femea":
                        radioButton2.Checked = true;
                        break;
                    case "Desconhecido":
                        radioButton3.Checked = true;
                        break;
                }
                passaro.mutacao = dtResultado.Rows[0]["Mutacao"].ToString();
                comboBox2.SelectedIndex = comboBox2.FindStringExact(passaro.mutacao);
                label2.Text = "ID: "+passaro.id_passaro.ToString();
                passaro.descricao = dtResultado.Rows[0]["Descricao"].ToString();
                txtDescricao.Text = passaro.descricao;
            }
            catch(NullReferenceException){}
            catch(Exception){}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gerencia gerencia = new Gerencia(login.id_usuario, login.usuario, login.expiracao);
            this.Hide();
            gerencia.Closed += (s, args) => this.Close();
            gerencia.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BD bd = new BD();
            StringBuilder str = new StringBuilder();
            MySqlCommand command = new MySqlCommand();

            if (passaro.mutacao != (comboBox2.SelectedItem.ToString()))
            {
                try
                {
                    str = new StringBuilder("UPDATE Passaro SET Mutacao = @Mutacao WHERE ID_Passaro = @ID_Passaro");
                    command = new MySqlCommand(str.ToString());
                    passaro.mutacao = comboBox2.SelectedItem.ToString();
                    command.Parameters.Add("@Mutacao", MySqlDbType.VarChar);
                    command.Parameters["@Mutacao"].Value = passaro.mutacao;
                    command.Parameters.Add("@ID_Passaro", MySqlDbType.Int32);
                    command.Parameters["@ID_Passaro"].Value = passaro.id_passaro;
                    bd.executarComando(command);
                    MessageBox.Show("Mutacao Atualizada");
                }
                catch (Exception)
                {
                    MessageBox.Show("Mutacao Não atualizada");
                }

            }
            if (passaro.sexoP != sexo)
            {
                try
                {
                    str = new StringBuilder("UPDATE Passaro SET Sexo = @Sexo WHERE ID_Passaro = @ID_Passaro");
                    command = new MySqlCommand(str.ToString());
                    passaro.sexoP = sexo;
                    command.Parameters.Add("@Sexo", MySqlDbType.VarChar);
                    command.Parameters["@Sexo"].Value = passaro.sexoP;
                    command.Parameters.Add("@ID_Passaro", MySqlDbType.Int32);
                    command.Parameters["@ID_Passaro"].Value = passaro.id_passaro;
                    bd.executarComando(command);
                    MessageBox.Show("Sexo Atualizado");
                }
                catch (Exception)
                {
                    MessageBox.Show("Sexo Não Atualizado");
                }

            }
            if (passaro.descricao != txtDescricao.Text)
            {
                try
                {
                    str = new StringBuilder("UPDATE Passaro SET Descricao = @Descricao WHERE ID_Passaro = @ID_Passaro");
                    command = new MySqlCommand(str.ToString());
                    passaro.descricao = txtDescricao.Text;
                    command.Parameters.Add("@Descricao", MySqlDbType.VarChar);
                    command.Parameters["@Descricao"].Value = passaro.descricao;
                    command.Parameters.Add("@ID_Passaro", MySqlDbType.Int32);
                    command.Parameters["@ID_Passaro"].Value = passaro.id_passaro;
                    bd.executarComando(command);
                    MessageBox.Show("Descricao Atualizada");
                }
                catch (Exception)
                {
                    MessageBox.Show("Descricao Não Atualizada");
                }
            }
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            Refreshcmb1();
        }
    

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Enabled) sexo = "Macho";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled) sexo = "Femea";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled) sexo = "Desconhecido";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD bd = new BD();
            StringBuilder str = new StringBuilder();
            MySqlCommand command = new MySqlCommand();
            str = new StringBuilder("DELETE FROM Passaro where ID_Passaro = @ID_Passaro");
            command = new MySqlCommand(str.ToString());
            command.Parameters.Add("@ID_Passaro", MySqlDbType.Int32);
            command.Parameters["@ID_Passaro"].Value = passaro.id_passaro;
            bd.executarComando(command);
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            Refreshcmb1();
        }
    }
}
