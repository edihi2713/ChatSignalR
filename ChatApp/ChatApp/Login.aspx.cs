﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatApp
{
    public partial class Login : System.Web.UI.Page
    {

        ConnClass ConnC = new ConnClass();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string Query = "select * from tbl_Users where Email='" + txtEmail.Value + "' and Password='" + txtPassword.Value + "'";
            if (ConnC.IsExist(Query))
            {
                string UserName = ConnC.GetColumnVal(Query, "UserName");
                Session["UserName"] = UserName;
                Session["Email"] = txtEmail.Value;
                Response.Redirect("Chat.aspx");
            }
            else
                txtEmail.Value = "Invalid Email or Password!!";
        }

    }
}