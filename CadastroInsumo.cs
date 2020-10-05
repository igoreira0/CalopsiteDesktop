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
    public partial class CadastroInsumo : Form
    {
        private Insumo insumo = new Insumo();
        public CadastroInsumo()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) Change2Medicacao();
        }

        private void Change2Racao()
        {
            label3.Text = "Peso: ";
        }
        private void Change2Medicacao()
        {
            label3.Text = "Doses: ";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) Change2Racao();

        }

        private void Insumo_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD bd = new BD();
            StringBuilder sb = new StringBuilder();
            insumo.nome = textBox1.Text;
            insumo.preco = float.Parse(textBox3.Text);    
            
            try
            {
                MySqlCommand command = null;
                if (radioButton2.Checked)
                {
                    sb = new StringBuilder("INSERT INTO Insumo (Nome, ");
                    sb.Append("Peso, Preco) VALUES (@Nome, @Value, @Preco)");
                    MessageBox.Show(sb.ToString());
                    command = new MySqlCommand(sb.ToString());
                    insumo.peso = float.Parse(textBox2.Text);
                    command.Parameters.Add("@Value", MySqlDbType.Float);
                    command.Parameters["@Value"].Value = insumo.peso;

                }
                else if (radioButton1.Checked)
                {
                    sb = new StringBuilder("INSERT INTO Insumo (Nome, ");
                    sb.Append("Quantidade, Preco) VALUES (@Nome, @Value, @Preco)");
                    MessageBox.Show(sb.ToString());
                    command = new MySqlCommand(sb.ToString());
                    insumo.quantidade = int.Parse(textBox2.Text);
                    if (insumo.quantidade <= 0) throw new ArgumentException("O valor inserido precisa ser maior que zero");
                    command.Parameters.Add("@Value", MySqlDbType.Int32);
                    command.Parameters["@Value"].Value = insumo.quantidade;
                }
                else
                {
                    throw new ArgumentException("O valor digitado precisa ser maior que 0");
                }
                command.Parameters.Add("@Nome", MySqlDbType.VarChar);
                command.Parameters["@Nome"].Value = insumo.nome;
                command.Parameters.Add("@Preco", MySqlDbType.Float);
                command.Parameters["@Preco"].Value = insumo.preco;
                try
                {
                    bd.executarComando(command);
                    MessageBox.Show("Insumo inserido com sucesso");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
            catch(ArgumentException err)
            {
                MessageBox.Show(err.ToString());
            }catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
