<%@ Page Title="הוספת מוצרים" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="InsertProduct" %>
<%@ Register Assembly="WebVideo" Namespace="WebVideo" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 70%;
        }
        .auto-style1 {
            height: 36px;
        }
        .style6
        {
            height: 20px;
        }
        .style7
        {
            width: 252px;
        }
        .style8
        {
            width: 272px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel ID="Panel1" runat="server">
    <div style="height: 288px">
        <br />
        <table align="center" dir="rtl">
            <tr>
                <td colspan="4" class="auto-style1">
                    <asp:Label ID="Label1" runat="server" 
                        style="color: #FF9900; font-weight: 700; text-decoration: underline; font-size: xx-large" 
                        Text="העלאת שירים לחנות"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    בחר קטגוריה:<asp:DropDownList ID="ddlCat" runat="server" 
                        onselectedindexchanged="ddlCat_SelectedIndexChanged" AutoPostBack="True" dir="ltr">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                 <td>
                    <asp:Label ID="lbrate" runat="server" 
                        style="color: #669900; font-weight: 700; font-size: x-large">דירוג קטגוריה:</asp:Label>
                </td>
                <td align="center" class="style8">
                    <asp:Table ID="tableRate" runat="server" BorderColor="#999966" 
                        BorderStyle="Double" BorderWidth="2px">
                    </asp:Table>
                </td>
                <td class="style7">
                    <asp:Label ID="lbcatsongs" runat="server" 
                        style="color: #669900; font-weight: 700; font-size: x-large"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbCat" runat="server" 
                        style="color: #669900; font-weight: 700; font-size: x-large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Panel ID="plcatdetails" runat="server" Width="50%">
                        <table class="style5">
                            <tr>
                                <td>
                                    <asp:Image ID="imgcatpic" runat="server" Height="100px" Width="100px" 
                                        Visible="False" />
                                    <br />
                                    <asp:Label ID="lbAlbums" runat="server" 
                                        style="font-weight: 700; color: #3399FF; font-size: large;">בחר שירים לחנות</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" BackColor="White" dir="rtl"
                                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" 
                                        onrowdatabound="GridView1_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="תמונת אלבום">
                                                <ItemTemplate>
                                                     <asp:ImageButton runat="server" Text="" ID="albumPic" OnClick="albumPic_Click"></asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name" HeaderText="שם האלבום" />
                                            <asp:BoundField DataField="AlbumLength" HeaderText="אורך האלבום" />
                                            <asp:BoundField DataField="Artist" HeaderText="שם אומן" />
                                            <asp:BoundField DataField="AlbumPrice" HeaderText="מחיר אלבום" />
                                            <asp:TemplateField HeaderText="הוסף אלבום לחנות">
                                                <ItemTemplate>
                                                     <asp:CheckBox runat="server" Text="" ID="addAlbum"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6" colspan="2">
                    &nbsp;</td>
                <td class="style6" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btsend" runat="server" onclick="btsend_Click" 
                        style="color: #0066FF; font-weight: 700; background-color: #999966" 
                        Text="הוסף" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lbmsg" runat="server" 
                        style="color: #CC3300; font-weight: 700; font-size: x-large" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
    <asp:Label ID="lbPrem" runat="server" 
        style="color: Red; font-weight: 700; font-size: x-large" ForeColor="Red" dir="rtl">אין לך הרשאה לראות דף זה.</asp:Label>
</asp:Content>

