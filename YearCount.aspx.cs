using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YearCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int[] P_Int_month = new int[12];
            for (int i = 0; i < 12; i++)
            {
                P_Int_month[i] = i + 1;
            }
            DataList1.DataSource = P_Int_month;
            DataList1.DataBind();
            this.labYear.Text = DateTime.Now.Year + "year";
            this.labTotal.Text = Total().ToString();
        }
    }
    
    public int Total()
    {
        DB db = new DB();
        DataSet ds = db.reDs("select * from tb_CounterInfo where Year(LoginTime)=" + DateTime.Now.Year);
        int P_Int_total = ds.Tables[0].Rows.Count;
        return P_Int_total;
    }

    public string Year(int i)
    {
        string P_Str_time = "";
        if (i < 12 & i >= 0)
        {
            P_Str_time = Convert.ToString(i + 1);
        }
        return P_Str_time;
    }
    
    public int Count(int i)
    {
        DB db = new DB();
        int P_Int_count = 0;
        DataSet ds = db.reDs("select COUNT(*) AS count, Month( LoginTime) AS month from tb_CounterInfo where Year(LoginTime)=" + DateTime.Now.Year + "and Month(LoginTime)=" + (i + 1) + "Group By Month(LoginTime)");
        if (ds.Tables[0].Rows.Count != 0)
            P_Int_count = Convert.ToInt32(ds.Tables[0].Rows[0]["count"]);

        return P_Int_count;
    }
    
    public float Percent(int i)
    {
        float P_Fl_percent = 0;
        if (Total() != 0)
        {
            P_Fl_percent = Convert.ToSingle(Count(i)) / Convert.ToSingle(Total());
        }
        return P_Fl_percent;
    }
}