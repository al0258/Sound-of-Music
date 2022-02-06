<%@ Page Title="הסרת מוצרים" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RemoveProduct.aspx.cs" Inherits="RemoveProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel ID="pl_RemoveProducts" runat="server" Width="100%">
    <table dir="rtl" align="center">
        <tr>
            <td colspan="2">
                <asp:Label ID="lbAlbums" runat="server" 
                    style="font-weight: 700; color: #3399FF; font-size: larger;">מחק שירים מהחנות</asp:Label>
            </td>
        </tr>
        <tr>
            <td width="50%" align="left">
                <asp:Label ID="lbCateg" runat="server" 
                    style="font-weight: 700; color: black; font-size: medium;">בחר קטגוריה: </asp:Label>
            </td>
            <td width="50%" align="right">
                <asp:DropDownList ID="ddl_Categories" runat="server" OnSelectedIndexChanged="ddl_Categories_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gv_RemoveProducts" runat="server" BackColor="White" dir="rtl"  onrowdatabound="gv_RemoveProducts_RowDataBound"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" OnRowDeleting="gv_RemoveProducts_RowDeleting"
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="תמונת אלבום">
                            <ItemTemplate>
                                    <asp:Image runat="server" Text="" ID="albumImg"></asp:Image>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="albumId" HeaderText="קוד האלבום" />
                        <asp:BoundField DataField="albumName" HeaderText="שם האלבום" />
                        <asp:BoundField DataField="albumLength" HeaderText="אורך האלבום" />
                        <asp:BoundField DataField="albumArtist" HeaderText="שם אומן" />
                        <asp:BoundField DataField="price" HeaderText="מחיר אלבום" />
                        <asp:CommandField DeleteText="מחק" ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Panel>
    <asp:Label ID="lbPrem" runat="server" 
        style="color: Red; font-weight: 700; font-size: x-large" ForeColor="Red" dir="rtl">אין לך הרשאה לראות דף זה.</asp:Label>
    <asp:Label ID="lblMsg" runat="server" style="color: black; font-weight: 700; font-size: x-large" ForeColor="Black" dir="rtl" Text=""></asp:Label>
</asp:Content>

