﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula1105
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                TxtData.Text = DateTime.Now.ToString();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DateTime data = CalDataInicio.SelectedDate;
            TxtData.Text = data.ToString();
            // ou TxtData.Text = CalDataInicio.SelectedDate.ToString();
        }
    }
}