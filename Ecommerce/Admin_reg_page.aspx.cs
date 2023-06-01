using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Admin_reg_page : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_id) from login_table";
            string regid = ob.fun_Scalar(sel);
            int reg_id = 0;
            if(regid=="")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                reg_id = newregid + 1;
            }
            string ins = "insert into admin_reg_table values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
            int i = ob.fun_NonQuery(ins);
            string inslog = "insert into  login_table values(" + reg_id + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','admin','active')";
            int j = ob.fun_NonQuery(inslog);
        }
    }
}