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
    public partial class CadastroGaiola : Form
    {
        Login login = new Login();
        private Gaiola gaiola = null;
        private Passaro passaro = new Passaro();
        private Passaro passaro1 = new Passaro();
        private PassaroGaiola passaroGaiola = new PassaroGaiola();
        public CadastroGaiola(int ID_Usuario)
        {
            login.id_usuario = ID_Usuario;
            InitializeComponent();
        }

        private void CadastroGaiola_Load(object sender, EventArgs e)
        {
            LoadComb("Macho");
            LoadComb("Femea");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gaiola = new Gaiola();
            gaiola.descricao = textBox1.Text;
            BD bd = new BD();
            StringBuilder sb = new StringBuilder("INSERT INTO Gaiola (Descricao, Filhotes) VALUES (@Descricao, 0)");
            MySqlCommand command = new MySqlCommand(sb.ToString());
            command = new MySqlCommand(sb.ToString());
            command.Parameters.Add("@Descricao", MySqlDbType.VarChar);
            command.Parameters["@Descricao"].Value = gaiola.descricao;
            try
            {
                bd.executarComando(command);
                MessageBox.Show("Gaiola inserida");
            }
            catch (Exception err)
            {
                MessageBox.Show("Gaiola Não inserida" + err.ToString());
            }
            finally
            {
                this.Close();
            }
            passaro.id_passaro = int.Parse(comboBox1.SelectedValue.ToString());
            passaro1.id_passaro = int.Parse(comboBox2.SelectedValue.ToString());
            sb = new StringBuilder("Update Passaro SET Ocupado = true WHERE ID_Passaro = @ID_Passaro");
            command = new MySqlCommand(sb.ToString());
            command.Parameters.Add("@ID_Passaro", MySqlDbType.Int32);
            command.Parameters["@ID_Passaro"].Value = passaro.id_passaro;
            bd.executarComando(command);
            command.Parameters["@ID_Passaro"].Value = passaro1.id_passaro;
            bd.executarComando(command);
            DataTable dataTable = new DataTable();
            dataTable.Clear();
            sb = new StringBuilder("SELECT MAX(ID_Gaiola) FROM Gaiola");
            command = new MySqlCommand(sb.ToString());
            dataTable = bd.executarConsulta(command);
            passaroGaiola.id_gaiola = int.Parse(dataTable.Rows[0][0].ToString());
            passaroGaiola.id_passaro = passaro.id_passaro;
            sb = new StringBuilder("INSERT INTO Passaro_Gaiola (ID_Passaro, ID_Gaiola) VALUES (@ID_Passaro, @ID_Gaiola)");
            command = new MySqlCommand(sb.ToString());
            command.Parameters.Add("@ID_Passaro", MySqlDbType.Int32);
            command.Parameters["@ID_Passaro"].Value = passaroGaiola.id_passaro;
            command.Parameters.Add("@ID_Gaiola", MySqlDbType.Int32);
            command.Parameters["@ID_Gaiola"].Value = passaroGaiola.id_gaiola;
            bd.executarComando(command);
            passaroGaiola.id_passaro = passaro1.id_passaro;
            command.Parameters["@ID_Passaro"].Value = passaroGaiola.id_passaro;
            bd.executarComando(command);

        }

        private void LoadComb(String Sexo)
        {
            BD bd = new BD();
            StringBuilder str = new StringBuilder("SELECT Passaro.Descricao, Passaro.ID_Passaro FROM Passaro WHERE Passaro.Proprietario = @ID_Usuario AND Sexo = @Sexo  AND Ocupado = false");
            MySqlCommand command = new MySqlCommand(str.ToString());
            command.Parameters.Add("@ID_Usuario", MySqlDbType.Int32);
            command.Parameters["@ID_Usuario"].Value = login.id_usuario;
            command.Parameters.Add("@Sexo", MySqlDbType.VarChar);
            command.Parameters["@Sexo"].Value = Sexo;
            DataTable dtResultado = new DataTable();
            dtResultado.Clear();
            dtResultado = bd.executarConsulta(command);
            if(Sexo == "Macho")
            {
                comboBox1.DataSource = null;
                comboBox1.DataSource = dtResultado;
                comboBox1.ValueMember = "ID_Passaro";
                comboBox1.DisplayMember = "Descricao";
                try
                {
                    comboBox1.SelectedIndex = 0;
                }
                catch (Exception) { }
            }
            if(Sexo == "Femea")
            {
                comboBox2.DataSource = null;
                comboBox2.DataSource = dtResultado;
                comboBox2.ValueMember = "ID_Passaro";
                comboBox2.DisplayMember = "Descricao";
                try
                {
                    comboBox2.SelectedIndex = 0;
                }
                catch (Exception) { }
            }
            
            comboBox1.Refresh();
        }
        

        
    }
}
