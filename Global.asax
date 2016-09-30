<%@ Application Language="C#" %>
<%@ Import Namespace="Counter" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    void Application_End(object sender, EventArgs e) 
    {
       

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Session.Timeout = 1;
        Session["IP"] = Request.UserHostAddress;
        Session["LoginTime"] = DateTime.Now;
        Session["Browser"] = Request.Browser.Browser;
        Session["OS"] = Request.Browser.Platform;
    }

    void Session_End(object sender, EventArgs e)
    {
        DB db = new DB();
        Session["LeaveTime"] = DateTime.Now;
        string ip = Session["IP"].ToString();
        string loginTime = Session["LoginTime"].ToString();
        string leaveTime = Session["LeaveTime"].ToString();
        string browser = Session["Browser"].ToString();
        string os = Session["OS"].ToString();

        db.ExSql("insert into tb_CounterInfo  (IP, LoginTime, LeaveTime, Browser, OS) values('" + ip + "','" + loginTime + "','" + leaveTime + "','" + browser + "','" + os + "')");
    }

</script>
