using ProjetoHome2405DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoHome2405DB.View.Base
{
    public class BasePage : System.Web.UI.Page
    {
        //referência para o banco
        protected LojaDbEntities contexto = new LojaDbEntities();
    }
}