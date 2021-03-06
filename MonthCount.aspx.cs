﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MonthCount : System.Web.UI.Page
{
    public static string M_Str_mindate;
    public static string M_Str_maxdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int P_Int_DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int[] P_Int_Day = new int[P_Int_DaysInMonth];
            for (int i = 0; i < P_Int_DaysInMonth; i++)
            {
                P_Int_Day[i] = i + 1;
            }
            DataList1.DataSource = P_Int_Day;
            DataList1.DataBind();
            labMonth.Text = DateTime.Now.Year + "-" + DateTime.Now.Month;
            M_Str_mindate = labMonth.Text + "-1 0:00:00";
            M_Str_maxdate = labMonth.Text + "-" + P_Int_DaysInMonth + " 23:59:59";

            this.labTotal.Text = Total().ToString();
        }
    }
    
    public int Total()
    {
        DB db = new DB();
        DataSet ds = db.reDs("select * from tb_CounterInfo where LoginTime>='" + M_Str_mindate + "'and LoginTime<'" + M_Str_maxdate + "'");
        int P_Int_total = ds.Tables[0].Rows.Count;//访问人数统计
        return P_Int_total;
    }

    public string Month(int i)
    {
        int P_Int_DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);//指定年和月中的天数
        string P_Str_day = "";
        if (i < P_Int_DaysInMonth & i >= 0)
        {
            P_Str_day = (i + 1).ToString();
        }
        return P_Str_day;
    }
    
    public int Count(int i)
    {
        DB db = new DB();
        int P_Int_count = 0;
        DataSet ds = db.reDs("select COUNT(*) AS count, DATEPART(dd, LoginTime) AS day from tb_CounterInfo where LoginTime>='" + M_Str_mindate + "'and LoginTime<'" + M_Str_maxdate + "' and DATEPART(dd,LoginTime)=" + (i + 1) + " GROUP BY DATEPART(dd, LoginTime)");
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