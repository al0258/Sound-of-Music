<%@ Page Title="היסטוריית הזמנות" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderHistory.aspx.cs" Inherits="OrderHistory" %>
<%@ Register Assembly="AjaxControltoolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajax"%>
<%@ Register Assembly="WebVideo" Namespace="WebVideo" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<ajax:ToolkitScriptManager id="script1" runat="server"></ajax:ToolkitScriptManager>
<div>
    <asp:Panel ID="plShowAlbumsInOrder" runat="server">
        <table dir="rtl" align="center">
            <tr>
                <td>  
                    <asp:Label ID="lbTitle" runat="server" Text="שגיאה במספר הזמנה" Font-Bold="True" Font-Names="Arial"
                    Font-Size="X-Large" ForeColor="SteelBlue"></asp:Label>
                </td>
            </tr>      
            <tr>
                <td>
                    <asp:GridView ID="gvShowAlbumsInOrder" runat="server" AutoGenerateColumns="False" onrowdatabound="gvShowAlbumsInOrder_RowDataBound"
                    CellPadding="4" Font-Size="Medium" GridLines="None" ForeColor="#333333" AllowPaging="True" PageSize="5" ShowFooter="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="תמונת אלבום">
                                <ItemTemplate>
                                    <asp:ImageButton ID="albumImg" runat="server" OnClick="albumImg_Click"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="albumName" HeaderText="שם מוצר" />
                            <asp:BoundField DataField="OrderId" HeaderText="מספר הזמנה">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="מחיר">
                                <ItemTemplate>
                                    ₪<asp:Label ID="LabelPrice" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="LabelSum" runat="server" dir="rtl" Text=""></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="albumId" HeaderText="קוד מוצר">
                                <ItemStyle Font-Bold="True" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr align="center">
                <td >
                <asp:Button ID="btn_CloseProdsGridView" runat="server" style="font-weight: 700; " 
                Text="סגור"  onclick="btn_CloseProdsGridView_Click"/>
                </td>          
            </tr>
            <tr align="center">
                <td >
                <asp:GridView ID="GridView2" runat="server" dir="rtl" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="שם שיר" />
                <asp:BoundField DataField="Album" HeaderText="שם אלבום" />
                <asp:BoundField DataField="SongLength" HeaderText="אורך שיר" />
                <asp:TemplateField HeaderText="נגן שיר">
                    <ItemTemplate>
                        <cc1:WVC ID="WVC1" runat="server" BackColor="Black" BorderStyle="Ridge" FilePath="Songs/5.wav"
                                    Height="50" ShowControls="False" ShowPositionControls="False" ShowStatusBar="False"
                                    ShowTracker="False" Width="100" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                </td>          
            </tr>
        </table>
    </asp:Panel>
</div>

<asp:Panel ID="plShowOrders" runat="server">
<div align="center"> 
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4"
            onpageindexchanging="GridView1_PageIndexChanging" 
            onselectedindexchanging="GridView1_SelectedIndexChanging" dir="rtl" GridLines="None" Width="50%" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField HeaderText="מספר הזמנה" DataField="OrderId" 
                SortExpression="OrderId" >
            <HeaderStyle Font-Size="Larger" HorizontalAlign="Right" />
            <ItemStyle Font-Bold="True" HorizontalAlign="Justify" />
            </asp:BoundField>
            <asp:BoundField HeaderText="תאריך הזמנה" DataField="orderDate" 
                SortExpression="orderDate" >
            <HeaderStyle Font-Size="Larger" HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="email" HeaderText="אימייל" SortExpression="email" >
            <HeaderStyle Font-Size="Larger" HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="מחיר סופי">
                <ItemTemplate>
                    ₪<asp:Label ID="Label1" runat="server" Text='<%# Bind("totalPrice") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Size="Larger" HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:BoundField DataField="paymentStatus" HeaderText="שולם או נדחה" 
                SortExpression="paymentStatus" >
            <HeaderStyle Font-Size="Larger" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lb_ViewAlbums" runat="server" CommandName="select"><font face="Arial">צפה במוצרים</font></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="LightBlue" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</div>
</asp:Panel>

<asp:Label ID="lblPrem" runat="server" Font-Bold="True" Font-Size="20pt" 
    ForeColor="Red" Text="הינך צריך להתחבר על מנת לצפות בדף זה." dir="rtl" 
    Visible="False"></asp:Label>

<asp:Button ID="popupBt" runat="server" style="display:none;"/>
    <ajax:ModalPopupExtender id="ModalPopupExtender2" runat="server"
        TargetControlID="popupBt" PopupControlID="plShowAlbumsInOrder" 
        BackgroundCssClass="modalBackgound" OnOkScript="__doPostBack('btnshow','')"></ajax:ModalPopupExtender>
</asp:Content>

