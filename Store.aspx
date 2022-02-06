<%@ Page Title="חנות" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Store.aspx.cs" Inherits="Store" %>
<%@ Register Assembly="WebVideo" Namespace="WebVideo" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style1 {
            width: 63px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div dir="rtl" align="center">
        <asp:Label ID="Label1" runat="server" Text="קטגוריות:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" 
            HorizontalAlign="Center" RepeatColumns="3" 
            onselectedindexchanged="DataList1_SelectedIndexChanged" 
            onitemdatabound="DataList1_ItemDataBound">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <SelectedItemStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
            <ItemStyle BackColor="#EFF3FB" />
            <ItemTemplate>

                <table dir="rtl">
                    <tr>
                        <td rowspan="5" class="style1">
                            <asp:Image ID="imgAlbum" runat="server" Width="90" Height="90"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <b>שם אלבום:</b>
                        </td>
                        <td>
                            <asp:Label ID="lbAlbumName" runat="server" dir="rtl" Text='<%#DataBinder.Eval(Container.DataItem , "albumName") %>'></asp:Label>
                        </td>
                    </tr>

                     <tr>
                        <td class="style1">
                            <b>שם יוצר:</b>
                        </td>
                        <td>
                            <asp:Label ID="albumArtist" runat="server" dir="rtl" Text='<%#DataBinder.Eval(Container.DataItem , "albumArtist") %>'></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="style1">
                            <b>קטגוריה:</b>
                        </td>
                        <td>
                            <asp:Label ID="lbIdCat" runat="server" dir="rtl" Text='<%#DataBinder.Eval(Container.DataItem , "categoryName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <b>מחיר:</b>
                        </td>
                        <td>
                            <asp:Label ID="lbPrice" runat="server" dir="rtl" Text='<%#DataBinder.Eval(Container.DataItem , "price") %>'></asp:Label>₪
                        </td>
                    </tr>
                    <tr>
                          
                        <td class="style1">
                            <asp:Label ID="Label3" runat="server" dir="rtl" Visible="false" Text  ='<%#DataBinder.Eval(Container.DataItem , "albumId") %>'></asp:Label>
                        </td>
                    </tr>
                      <tr>
                          
                        <td class="style1">
                            <b>Songs in album: </b>
                            </td>
                          <td>
                            <asp:Button ID="lbAlbumId" runat="server" dir="rtl" Visible="true" ToolTip='<%#DataBinder.Eval(Container.DataItem, "albumName") %>' Text="הצג שירים באלבום" CommandName="select"/>
                        </td>
                    </tr>
                    <%if (Session["userLogged"] != null)
                      {%>
                        <tr>
                  
                        
                    
                        <td colspan="3" align="center">
                            <asp:CheckBox ID="cbAddToCart" runat="server" />
                            <asp:Label ID="Label2" runat="server" Font-Italic="True" Text="הוסף לסל"></asp:Label>
                        </td
                          </tr>
                          <%} %>
                      </table>

            </ItemTemplate>
        </asp:DataList>

        <br />
        <asp:GridView ID="GridView1" runat="server" dir="rtl" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
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

                <%if (Session["userLogged"] != null)
                  {%>
        <asp:Button ID="btAddToCart" runat="server" Text="הוסף לסל" 
            onclick="btAddToCart_Click" BackColor="#99CCFF" Font-Italic="False" Font-Names="Tahoma" Font-Size="Large" Font-Underline="False" />
                    <%} %>
    </div>

    </asp:Content>

