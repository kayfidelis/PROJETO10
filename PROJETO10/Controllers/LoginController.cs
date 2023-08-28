using MySql.Data.MySqlClient;
using PROJETO10.acoes;
using PROJETO10.dados;
using PROJETO10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PROJETO10.Controllers
{
    public class LoginController : Controller
    {
       conexao con = new conexao();
        AcLogin log = new AcLogin();

        MySqlDataReader dr;
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificaUsuario(modelLogin user) 
        { 
            log.TestarUsuario(user);

            if(user.Usuario != null && user.senha != null)
            {
                Session["usuario"] = user.Usuario.ToString();
                Session["senha"] = user.senha.ToString();

                return RedirectToAction("Index", "Home");   
            }
            else 
            { 
                return RedirectToAction("Login","Login");
            }
        }

       

    }

   
}
