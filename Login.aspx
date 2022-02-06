<%@ Page Title="התחברות" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"  CodeFile="Login.aspx.cs" Inherits="Login" Debug="true" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
            <asp:Panel ID="Panel1" runat="server">
    <table dir="rtl" cellpadding="5" align="center">
        <tr align="center">
            <td colspan="2">
                <font face="David" color="navy" size="9"><u><i>כניסה</i></u></font>
            </td>
        </tr>
        <tr>
            <td>
                <font face="arial" color="black">אימייל:</font>
            </td>
            <td>
                <asp:TextBox ID="tb_Email" runat="server" dir="ltr"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <font face="arial" color="black">סיסמא:</font>
            </td>
            <td>
                <asp:TextBox ID="tb_Pass" runat="server" TextMode="Password" dir="ltr"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <asp:Button ID="Submit" runat="server" Text="התחבר" onclick="Login_Clicked" />
            </td>
        </tr>
    </table>
                </asp:Panel>
    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
</asp:Content>