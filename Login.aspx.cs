using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DB db = new DB();
        string passWord = db.GetMD5(this.txtPwd.Text.Trim());
        DataSet ds = db.reDs("select * from tb_user where UserName='" + txtUserName.Text.Trim() + "' and PassWord='" + passWord + "'");

        if (ds.Tables[0].Rows.Count != 0)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Response.Write("<script>alert('login failure');location='Login.aspx'</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtPwd.Text = "";
        txtUserName.Text = "";
    }
}