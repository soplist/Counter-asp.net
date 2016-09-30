using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BrowserCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DB db = new DB();
            DataSet ds = db.reDs("SELECT COUNT(*) AS count, Browser FROM tb_CounterInfo GROUP BY Browser");
            DataList1.DataSource = ds;
            DataList1.DataBind();
            this.labBrowser.Text = Total().ToString();
        }
    }
    
    public int Total()
    {
        DB db = new DB();
        DataSet ds = db.reDs("select count(*) from tb_CounterInfo");
        int P_Int_total = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        return P_Int_total;
    }
    
    public float Percent(string P_str_count)
    {
        float P_Fl_percent = 0;
        if (Total() != 0)
        {
            P_Fl_percent = Convert.ToSingle(P_str_count) / Convert.ToSingle(Total());
        }
        return P_Fl_percent;
    }
}