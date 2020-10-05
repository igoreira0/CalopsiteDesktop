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
    public partial class GerenciarGaiola : Form
    {
        private Login login = new Login();
        Gaiola gaiola = new Gaiola();
        public GerenciarGaiola(int ID_Usuario)
        {
            InitializeComponent();
            login.id_usuario = ID_Usuario;
        }

        private void GerenciarGaiola_Load(object sender, EventArgs e)
        {
            loadGaiolas();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                gaiola.id_gaiola = int.Parse(comboBox1.SelectedValue.ToString());
                label1.Text = "Gaiola ID: " + gaiola.id_gaiola;
                BD bd = new BD();
                StringBuilder str = new StringBuilder("SELECT * FROM Gaiola WHERE ID_Gaiola = @Value");
                MySqlCommand command = new MySqlCommand(str.ToString());
                command.Parameters.Add("@Value", MySqlDbType.Int32);
                command.Parameters["@Value"].Value = gaiola.id_gaiola;
                DataTable dtResultado = new DataTable();
                dtResultado.Clear();
                dtResultado = bd.executarConsulta(command);
                txtDescricao.Text = dtResultado.Rows[0]["Descricao"].ToString();
                txtFilhotes.Text = dtResultado.Rows[0]["Filhotes"].ToString();
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD bd = new BD();
            StringBuilder str = new StringBuilder("UPDATE Gaiola SET ");
            MySqlCommand command = null;

            if (gaiola.filhotes != int.Parse(txtFilhotes.Text))
            {
                gaiola.filhotes = int.Parse(txtFilhotes.Text);
                try
                {
                    if (gaiola.filhotes < 0) throw new ArgumentException("Valor Invalido");
                    str = new StringBuilder("UPDATE Gaiola SET Filhotes = @Filhote WHERE ID_Gaiola = @ID_Gaiola");
                    command = new MySqlCommand(str.ToString());
                    command.Parameters.Add("@Filhote", MySqlDbType.Int32);
                    command.Parameters["@Filhote"].Value = gaiola.filhotes;
                    command.Parameters.Add("@ID_Gaiola", MySqlDbType.Int32);
                    command.Parameters["@ID_Gaiola"].Value = gaiola.id_gaiola;
                    bd.executarComando(command);
                    MessageBox.Show("Filhotes Atualizado");
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.ToString());
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }

            }
            if (gaiola.descricao != txtDescricao.Text)
            {
                gaiola.descricao = txtDescricao.Text;
                try
                {
                    str = new StringBuilder("UPDATE Gaiola SET Descricao = @Descricao WHERE ID_Gaiola = @ID_Gaiola");
                    command = new MySqlCommand(str.ToString());
                    command.Parameters.Add("@Descricao", MySqlDbType.VarChar);
                    command.Parameters["@Descricao"].Value = gaiola.descricao;
                    command.Parameters.Add("@ID_Gaiola", MySqlDbType.Int32);
                    command.Parameters["@ID_Gaiola"].Value = gaiola.id_gaiola;
                    bd.executarComando(command);
                    MessageBox.Show("Descricao Atualizada");
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.ToString());
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }

            }
        }
            
    }
}
