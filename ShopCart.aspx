<%@ Page Title="סל קניות" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShopCart.aspx.cs" Inherits="ShopCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <div dir="rtl">
            <table class="style5" align="center">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            style="color: #FF9900; font-weight: 700; text-decoration: underline; font-size: xx-large" 
                            Text="סל הקניות שלי"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" >
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                            CellPadding="3" onrowdatabound="GridView1_RowDataBound" ShowFooter="true"
                            onselectedindexchanged="GridView1_SelectedIndexChanged" 
                            onrowdeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/sys/delete.jpg" 
                                    ShowDeleteButton="True">
                                <ControlStyle Height="70px" Width="70px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="AlbumId" HeaderText="קוד אלבום" />
                                <asp:BoundField DataField="Name" HeaderText="שם אלבום" />
                                <asp:TemplateField HeaderText="מחיר ליחידה">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        ₪<asp:Label ID="Label1" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="server" Text="" ID="LabelSum" dir="rtl"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="תמונת מוצר">
                                    <ItemTemplate>
                                        <asp:Image ID="albumImg" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbEmpty" runat="server" 
                            style="color: #FF3300; font-weight: 700; font-size: xx-large" 
                            Text="סל הקניות ריק" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Show_CheckOut" runat="server" Text="קנה הכל" OnClick="Show_CheckOut_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Payment_Credit" runat="server" Visible="False" >
                            <table dir="rtl" align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="אימייל: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tb_Email" runat="server" dir="ltr" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="כרטיס אשראי: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tb_CreditCardNum" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="שלוש ספרות אחרונות: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tb_LastDigits" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr dir="ltr">
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="תוקף הכרטיס"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ExpDate_Month" runat="server">
                                        </asp:DropDownList>
                                        -
                                        <asp:DropDownList ID="ddl_ExpDate_Year" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        <asp:Button ID="Cancel" runat="server" Text="ביטול" OnClick="Cancel_Click" />
                                    </td>
                                    <td colspan="2">
                                        <asp:Button ID="CheckOut" runat="server" Text="בצע הזמנה" OnClick="CheckOut_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                            <asp:Label ID="lblOrderStatus" runat="server" 
                            style="color: #FF3300; font-weight: 700; font-size: xx-large" 
                            Text=" מצב הזמנה" Visible="False" dir="rtl"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>

</asp:Content>

