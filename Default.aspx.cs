using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string M_Str_mindate;
    string M_Str_maxdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        DB db = new DB();
        labCountDate.Text = DateTime.Now.ToString();
        //number of visitors today
        M_Str_mindate = DateTime.Now.ToShortDateString() + " 0:00:00";
        M_Str_maxdate = DateTime.Now.AddDays(1).ToShortDateString() + " 0:00:00";
        DataSet ds = db.reDs("select * from tb_CounterInfo where LoginTime>='" + M_Str_mindate + "'and LoginTime<'" + M_Str_maxdate + "'");
        labCountDay.Text = ds.Tables[0].Rows.Count.ToString();

        //number of visits this week
        switch (DateTime.Now.DayOfWeek)
        {
            case DayOfWeek.Monday:
                M_Str_mindate = DateTime.Now.AddDays(0).ToShortDateString() + " 0:00:00";
                M_Str_maxdate = DateTime.Now.AddDays(6).ToShortDateString() + " 0:00:00";
                break;
            case DayOfWeek.Tuesday:
                M_Str_mindate = DateTime.Now.AddDays(-1).ToShortDateString() + " 0:00:00";
                M_Str_maxdate = DateTime.Now.AddDays(5).ToShortDateString() + " 0:00:00";
                break;
            case DayOfWeek.Wednesday:
                M_Str_mindate = DateTime.Now.AddDays(-2).ToShortDateString() + " 0:00:00";
                M_Str_maxdate = DateTime.Now.AddDays(4).ToShortDateString() + " 0:00:00";
                break;
            case DayOfWeek.Thursday:
                M_Str_mindate = DateTime.Now.AddDays(-3).ToShortDateString() + " 0:00:00";
                M_Str_maxdate = DateTime.Now.AddDays(3).ToShortDateString() + " 0:00:00";
                break;
            case DayOfWeek.Friday:
                M_Str_mindate = DateTime.Now.AddDays(-4).ToShortDateString() + " 0:00:00";
                M_Str_maxdate = DateTime.Now.AddDays(2).ToShortDateString() + " 0:00:00";
                break;
            case DayOfWeek.Saturday:
                M_Str_mindate = DateTime.Now.AddDays(-5).ToShortDateString() + " 0:00:00";
                M_Str_maxdate = DateTime.Now.AddDays(1).ToShortDateString() + " 0:00:00";
                break;
            case DayOfWeek.Sunday:
                M_Str_mindate = DateTime.Now.AddDays(-6).ToShortDateString() + " 0:00:00";
                M_Str_maxdate = DateTime.Now.AddDays(0).ToShortDateString() + " 0:00:00";
                break;
        }
        ds = db.reDs("select * from tb_CounterInfo where LoginTime>='" + M_Str_mindate + "'and LoginTime<'" + M_Str_maxdate + "'");
        labCountWeek.Text = ds.Tables[0].Rows.Count.ToString();
        //number of visits this month
        ds = db.reDs("select * from tb_CounterInfo where Year(LoginTime)=" + DateTime.Now.Year + " and Month(LoginTime)=" + DateTime.Now.Month.ToString());
        this.labCountMonth.Text = ds.Tables[0].Rows.Count.ToString();
        //max visits by day
        ds = db.reDs("SELECT COUNT(*) AS count, MAX(LoginTime) AS date FROM tb_CounterInfo GROUP BY YEAR(LoginTime), MONTH(LoginTime), DAY(LoginTime)");
        int P_Int_max = 0;
        string P_Str_date = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (!dr.IsNull(0))
            {
                if (P_Int_max <= Convert.ToInt32(dr[0]))
                {
                    P_Int_max = Convert.ToInt32(dr[0]);
                    P_Str_date = Convert.ToDateTime(dr[1]).ToShortDateString();
                }
            }
        }
        labMaxCountDay.Text = P_Int_max.ToString();
        //date of max visits by day
        DateTime P_Date_date = Convert.ToDateTime(P_Str_date);
        labMaxCountDayDate.Text = P_Date_date.Year + "/" + P_Date_date.Month + "/" + P_Date_date.Day + "/";
        //max visits by month
        P_Int_max = 0;
        P_Str_date = "";
        ds = db.reDs("SELECT YEAR(LoginTime) FROM tb_CounterInfo GROUP BY YEAR(LoginTime)");
        foreach (DataRow drYear in ds.Tables[0].Rows)
        {
            drYear[0].ToString();
            DataSet dsMonth = db.reDs("SELECT COUNT(*) as count, MAX(Month(LoginTime)) as month FROM tb_CounterInfo where YEAR(LoginTime)=" + drYear[0].ToString() + " GROUP BY Month(LoginTime)");
            foreach (DataRow drMonth in dsMonth.Tables[0].Rows)
            {
                if (!drMonth.IsNull(0))
                {
                    if (P_Int_max <= Convert.ToInt32(drMonth[0]))
                    {
                        P_Int_max = Convert.ToInt32(drMonth[0]);
                        P_Str_date = drYear[0].ToString() + "/" + drMonth[1].ToString() + "/";
                    }
                }
            }
        }
        labMaxCountMonth.Text = P_Int_max.ToString();
        //date of max visits by month
        labMaxCountMonthDate.Text = P_Str_date;

        //max visits by year
        ds = db.reDs("SELECT COUNT(*), MAX(Year(LoginTime)) FROM tb_CounterInfo GROUP BY Year(LoginTime)");
        P_Int_max = 0;
        P_Str_date = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (!dr.IsNull(0))
            {
                if (P_Int_max <= Convert.ToInt32(dr[0]))
                {
                    P_Int_max = Convert.ToInt32(dr[0]);
                    P_Str_date = dr[1].ToString() + "year";
                }
            }
        }
        labMaxCountYear.Text = P_Int_max.ToString();
        //date of max visits by year
        labMaxCountYearDate.Text = P_Str_date;
        //common browser
        ds = db.reDs("SELECT COUNT(*) AS count, Browser FROM tb_CounterInfo GROUP BY Browser");
        P_Int_max = 0;
        string P_Str_Browser = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (!dr.IsNull(0))
            {
                if (P_Int_max <= Convert.ToInt32(dr[0]))
                {
                    P_Int_max = Convert.ToInt32(dr[0]);
                    P_Str_Browser = dr[1].ToString();
                }
            }
        }
        this.labBrowser.Text = P_Str_Browser;
        //common os
        ds = db.reDs("SELECT COUNT(*) AS count, OS FROM tb_CounterInfo GROUP BY OS");
        P_Int_max = 0;
        string P_Str_OS = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (!dr.IsNull(0))
            {
                if (P_Int_max <= Convert.ToInt32(dr[0]))
                {
                    P_Int_max = Convert.ToInt32(dr[0]);
                    P_Str_OS = dr[1].ToString();
                }
            }
        }
        this.labOS.Text = P_Str_OS;
        //total nomber of visitors
        ds = db.reDs("select count(*) from tb_CounterInfo");
        this.labTotalCount.Text = ds.Tables[0].Rows[0][0].ToString();
    }
}