<%@ Page Language="C#" MasterPageFile="~/counter.master" AutoEventWireup="true" CodeFile="BrowserCount.aspx.cs" Inherits="BrowserCount" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="font-size: 9pt; width: 508px">
        <tr>
            <td>browser statistics</td>
        </tr>
        <tr>
            <td>
                total<asp:Label ID="labBrowser" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <table style="font-size: 9pt; width: 472px">
                            <tr>
                                <td align="left" style="width: 85px">
                                    <asp:Label ID="labBrowser" runat="server" Text='<%# Eval("Browser") %>'></asp:Label></td>
                                <td align="left" style="width: 67px">
                                    <asp:Label ID="labCount" runat="server" Text='<%# Convert.ToString(Eval("count")) %>'></asp:Label></td>
                                <td align="left" style="width:200px">
                                    <asp:Image ID="imgPercent" runat="server" Height="9px" ImageUrl="~/Image/bar1.gif"
                                        Width='<%# Percent(Convert.ToString(Eval("count")))*150 %>' />
                                    <%# Convert.ToInt32(Percent(Convert.ToString (Eval("count"))) * 100)%>%</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table style="font-size: 9pt; width: 472px">
                            <tr>
                                <td align="left" style="width: 85px">
                                    browser name</td>
                                <td align="left" style="width: 67px">
                                    count</td>
                                <td align="left" style="width: 200px">
                                    persent</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <HeaderStyle Font-Bold="True" />
                </asp:DataList></td>
        </tr>
    </table>
</asp:Content>
