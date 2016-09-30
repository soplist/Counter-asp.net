<%@ Page Language="C#" MasterPageFile="~/counter.master" AutoEventWireup="true" CodeFile="MonthCount.aspx.cs" Inherits="MonthCount" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="font-size: 9pt; width: 508px">
        <tr>
            <td>
                month statistics</td>
        </tr>
        <tr>
            <td>
                month:<asp:Label ID="labMonth" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;total<asp:Label
                    ID="labTotal" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <table style="font-size: 9pt; width: 472px">
                            <tr>
                                <td align="left" style="width: 85px">
                                    <asp:Label ID="labDate" runat="server" Text="<%# Month(Container.ItemIndex) %>"></asp:Label></td>
                                <td align="left" style="width: 67px">
                                    <asp:Label ID="labCount" runat="server" Text="<%# Count(Container.ItemIndex)%>"></asp:Label></td>
                                <td align="left" style="width: 200px">
                                    <asp:Image ID="imgPercent" runat="server" Height="9px" ImageUrl="~/Image/bar1.gif"
                                        Width="<%# Percent(Container.ItemIndex)*150 %>" />
                                    <%# Convert.ToInt32(Percent(Container.ItemIndex) * 100)%>
                                    %</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table style="font-size: 9pt; width: 472px">
                            <tr>
                                <td align="left" style="width: 85px">
                                    date</td>
                                <td align="left" style="width: 67px">
                                    count</td>
                                <td align="left" style="width: 200px">
                                    percent</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <HeaderStyle Font-Bold="True" />
                </asp:DataList></td>
        </tr>
    </table>
</asp:Content>
