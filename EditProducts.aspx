<%@ Page Title="עריכת מוצרים" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProducts.aspx.cs" Inherits="EditProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" dir="rtl" width="30%">
        <tr>
            <td width="50%">
                <asp:LinkButton ID="lb_AddProduct" runat="server" Font-Names="Arial" Font-Size="Larger" ForeColor="#009933" OnClick="lb_AddProduct_Click">הוסף מוצרים לחנות</asp:LinkButton>
            </td>
            <td width="50%">
                <asp:LinkButton ID="lb_RemoveProduct" runat="server" Font-Names="Arial" Font-Size="Larger" ForeColor="#ff0066" OnClick="lb_RemoveProduct_Click">מחק מוצר קיים</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

