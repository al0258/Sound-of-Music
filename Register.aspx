<%@ Page Title="הרשמה" Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" debug="True" %>
    
<asp:content ID="Content2" contentplaceholderid="head" runat="server">    
    <style type="text/css">
        .tbSmall {
        width: 60px;
        }
    </style>
</asp:content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
    <table dir="rtl" cellpadding="5" align="center">
        <tr align="center">
            <td colspan="2">
                
                <font face="Tahoma" color="navy" size="9"><u>הרשמה</u></font>
            </td>
        </tr>
        <tr>
            <td>
                <font face="arial" color="black">*אימייל:</font>
            </td>
            <td>
                <asp:TextBox ID="Email" runat="server" dir="ltr"></asp:TextBox>
<%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Email" ErrorMessage="לא הוכנס אימייל" 
                    ondatabinding="RequiredFieldValidator1_DataBinding"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                <font face="arial" color="black">*שם פרטי:</font>
            </td>
            <td>
                <asp:TextBox ID="Fname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <font face="arial" color="black">*שם משפחה:</font>
            </td>
            <td>
                <asp:TextBox ID="Lname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <font face="arial" color="black">*סיסמא:</font>
            </td>
            <td>
                <asp:TextBox ID="Pass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <font face="arial" color="black">*אימות סיסמא:</font>
            </td>
            <td>
                <asp:TextBox ID="ConfirmPass" runat="server"></asp:TextBox>
<%--                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="ConfirmPass" ControlToValidate="Pass" 
                    ErrorMessage="לא תואם לסיסמא"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="ConfirmPass" ErrorMessage="לא הוכנס אימות סיסמא"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>

        <tr align="center">
            <td colspan="2" style="font-size: small">
                <asp:Button ID="Submit" runat="server" Text="שלח" onclick="Submit_Clicked" />
                *חובה למלא שדה זה.</td>
        </tr>
    </table>
        </asp:Panel>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Content>
