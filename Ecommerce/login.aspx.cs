using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class login : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = "select count(Reg_id) from login_table where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
            string id = ob.fun_Scalar(query);
            int cid = Convert.ToInt32(id);
            if (cid == 1)
            {
                string query1 = "select Reg_id from login_table where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                string regid = ob.fun_Scalar(query1);
                Session["userid"] = regid;

                string query3 = "select Log_type from login_table where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                string logtype = ob.fun_Scalar(query3);
                if (logtype == "admin")
                {
                    Label6.Text = "Admin";
                }
                else if (logtype == "user")
                {
                    Label6.Text = "User";
                }
                else
                {
                    Label6.Text = "Invalid Username or Password";
                }
            }
        }
    }
}