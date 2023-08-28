using MySql.Data.MySqlClient;
using PROJETO10.dados;
using PROJETO10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PROJETO10.acoes
{
    public class AcLogin
    {
        conexao con = new conexao();

        public modelLogin TestarUsuario(modelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from login where usuario = @usuario and senha = @senha", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.Usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = user.senha;
           
            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    modelLogin dto = new modelLogin();
                    {
                        dto.Usuario = Convert.ToString(leitor["usuario"]);
                        dto.senha = Convert.ToString(leitor["senha"]);
                    }


                }

            }
            else
            {
                user.Usuario = null;
                user.senha = null;
            }
            return user;
        }
    }
}