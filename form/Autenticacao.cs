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
using Microsoft.VisualBasic;


namespace Calopsite
{
    public partial class Autenticacao : Form
    {
        public Autenticacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD bd = new BD();
            Login login = new Login();

            login.usuario = txt_usuario.Text.ToLower();
            login.senha = txt_senha.Text;

            StringBuilder sb = new StringBuilder("SELECT ID_Usuario,VenAssinatura  FROM Login WHERE Usuario = @Usuario and senha = MD5(@Senha) LIMIT 1");
            MySqlCommand command = new MySqlCommand(sb.ToString());
            command.Parameters.Add("@Usuario", MySqlDbType.VarChar);
            command.Parameters["@Usuario"].Value = login.usuario;
            command.Parameters.Add("@Senha", MySqlDbType.VarChar);
            command.Parameters["@Senha"].Value = login.senha;
            try
            {
                DataTable dataTable = bd.executarConsulta(command);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {

                    DataRow[] rows = dataTable.Select();
                    string IdUsuario = (rows[0][0].ToString());
                    login.id_usuario = int.Parse(IdUsuario);
                    DateTime expiracao = DateTime.Parse(((rows[0][1].ToString())));
                    login.expiracao = expiracao;
                    double exp = (login.expiracao - DateTime.Now).TotalDays;
                    if (exp < 0) throw new ArgumentException("Usuario Expirado, renove sua assinatura");
                    else
                    {
                        Gerencia gerencia = new Gerencia(login.id_usuario, login.usuario, login.expiracao);
                        this.Hide();
                        gerencia.Closed += (s, args) => this.Close();
                        gerencia.Show();
                    }
                }
                else
                {
                    throw new ArgumentException("Usuario ou senha Incorretos");
                }
            }
            catch(ArgumentException err)
            {
                MessageBox.Show(err.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show("erro generico " + err.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            int tempo;
            try
            {
                if (txt_usuario.Text.Length < 3)
                    throw new ArgumentException("Usuario precisa ter mais que 3 caracteres");
                else if (txt_senha.Text.Length < 3)
                    throw new ArgumentException("Senha Precisa ter mais que 3 caracteres");
                else if (!login.validaUsuario(txt_usuario.Text)) throw new ArgumentException("Usuario invalido");

                BD bd = new BD();
                login.usuario = txt_usuario.Text.ToLower();
                login.senha = txt_senha.Text;


                StringBuilder sb = new StringBuilder("SELECT Usuario FROM Login WHERE Usuario = @Usuario LIMIT 1");
                MySqlCommand command = new MySqlCommand(sb.ToString());
                command.Parameters.Add("@Usuario", MySqlDbType.VarChar);
                command.Parameters["@Usuario"].Value = login.usuario;

                try
                {
                    DataTable dataTable = bd.executarConsulta(command);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        throw new ArgumentException("Usuário já existe");
                    }
                    tempo = int.Parse(Interaction.InputBox("Quanto tempo de assinatura?", "Assinatura", "Insira um numero aqui"));
                    sb = new StringBuilder("INSERT INTO Login (Usuario, Senha, VenAssinatura) VALUES (@Usuario, MD5(@Senha), @VenAssinatura)");
                    command = new MySqlCommand(sb.ToString());
                    command.Parameters.Add("@Usuario", MySqlDbType.VarChar);
                    command.Parameters["@Usuario"].Value = login.usuario;
                    command.Parameters.Add("@Senha", MySqlDbType.VarChar);
                    command.Parameters["@Senha"].Value = login.senha;
                    command.Parameters.Add("@VenAssinatura", MySqlDbType.VarChar);
                    command.Parameters["@VenAssinatura"].Value = login.adicionarAssinatura(tempo);
                    bd.executarComando(command);
                    sb = new StringBuilder("SELECT Usuario FROM Login WHERE Usuario = @Usuario LIMIT 1");
                    command = new MySqlCommand(sb.ToString());
                    command.Parameters.Add("@Usuario", MySqlDbType.VarChar);
                    command.Parameters["@Usuario"].Value = login.usuario;
                    dataTable = bd.executarConsulta(command);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show(String.Format("Usuario {0} inserido com sucesso!", login.usuario));
                    }
                    else
                    {
                        throw new ArgumentException("Não foi possivel inserir o usuário");
                    }

                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.ToString());
                } catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }   
            catch (ArgumentException err)
            {
                MessageBox.Show(err.ToString());
            }catch(FormatException err)
            {
                MessageBox.Show("valor invalido\n" + err);
            }
        }        
    }
}
