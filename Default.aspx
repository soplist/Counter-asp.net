<%@ Page Language="C#" MasterPageFile="~/counter.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td align="center">
                survey statistics:</td>
        </tr>
        <tr>
            <td align="left">
                statistics date:<asp:Label ID="labCountDate" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
                <table>
                    <tr>
                        <td>
                            number of visitors today:</td>
                        <td>
                            <asp:Label ID="labCountDay" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            number of visits this week:</td>
                        <td>
                            <asp:Label ID="labCountWeek" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            number of visits this month:</td>
                        <td>
                            <asp:Label ID="labCountMonth" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            max visits by day:</td>
                        <td>
                            <asp:Label ID="labMaxCountDay" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            max visits date:</td>
                        <td>
                            <asp:Label ID="labMaxCountDayDate" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            max visits by month:</td>
                        <td>
                            <asp:Label ID="labMaxCountMonth" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            max visits month:</td>
                        <td>
                            <asp:Label ID="labMaxCountMonthDate" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            max visits by year:</td>
                        <td>
                            <asp:Label ID="labMaxCountYear" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            max visits year:</td>
                        <td>
                            <asp:Label ID="labMaxCountYearDate" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            common browser:</td>
                        <td>
                            <asp:Label ID="labBrowser" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            Common os:</td>
                        <td>
                            <asp:Label ID="labOS" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            total nomber of visitors:</td>
                        <td>
                            <asp:Label ID="labTotalCount" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

