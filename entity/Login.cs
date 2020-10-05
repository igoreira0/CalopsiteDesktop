using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calopsite.entity
{
    class Login
    {
        private int ID_Usuario;
        private string Usuario;
        private string Senha;
        private DateTime Date;


        public int id_usuario { get => ID_Usuario; set => ID_Usuario = value; }
        public string usuario { get => Usuario; set => Usuario = value; }
        public string senha { get => Senha; set => Senha = RetornarMD5(value); }
        public DateTime expiracao { get => Date; set => Date = value; }



        public string RetornarMD5(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return RetonarHash(md5Hash, Senha);
            }
        }

        public bool ComparaMD5(string senhabanco, string Senha_MD5)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var senha = RetornarMD5(senhabanco);
                if (VerificarHash(md5Hash, Senha_MD5, senha))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string RetonarHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private bool VerificarHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validaUsuario(string str)
        {
            List<string> invalidChars = new List<string>() { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-" , " ", ".", ","};
            foreach (string s in invalidChars)
            {
                if (str.Contains(s))
                {
                    
                    return false;
                }
            }
            return true;
        }
        public string adicionarAssinatura(double dias)
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(dias);
            string data = date.ToString("yyyy-MM-dd");
            return data;
        }
        

    }
}


