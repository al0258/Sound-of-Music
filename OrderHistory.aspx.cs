using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OrderHistory : System.Web.UI.Page
{
    int TotalSum = 0;
    int index = 0;
    string serviceurl;
    Production.Song[] songs;
    Production.ProductionWS service = new Production.ProductionWS();
    protected void Page_Load(object sender, EventArgs e)
    {
        Customer c = Session["userLogged"] as Customer;
        if ((!IsPostBack)&&(c!=null))
        {
            BindtheGridView();
        }
        if (c == null)
        {
            GridView1.Visible = false;
            lblPrem.Visible = true;
        }
    } //הפעולה קוראת לאיתחול טבלת ההזמנות

    public void BindtheGridView()
    {
        Customer c = Session["userLogged"] as Customer;
        DataSet ds = OrderHelper.GetOrdersByEmail(c.Email);
        this.GridView1.DataSource = ds.Tables[0];
        this.GridView1.DataBind();
    } //הפעולה מאתחלת את טבלת ההזמנות


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        BindtheGridView();
    } // הפעולה נותנת למשתמש אפשרות לערוך שורה בטבלה
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindtheGridView();

    } //הפעולה מבטלת את העריכה

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        BindtheGridView();
    } //הפעולה מחלקת את הטבלה לדפים

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        plShowOrders.Visible = false;
        GridViewRow row = this.GridView1.Rows[e.NewSelectedIndex];
        int oId = int.Parse(row.Cells[0].Text);
        DataTable dt = Order.GetProductsInOrderDetails(oId);
        
        Session["orderToPlay"] = dt;
        int count = dt.Rows.Count;
        this.gvShowAlbumsInOrder.DataSource = dt;
        this.gvShowAlbumsInOrder.DataBind();
        this.ModalPopupExtender2.Show();
        this.lbTitle.Text = "מוצרים בהזמנה מספר " + oId;
    } //בעת לחיצה על כפתור צפה במוצרים פעולה זו מתבצעת ופותחת גריד וויו חדש ובו המוצרים

    protected void btn_CloseProdsGridView_Click(object sender, EventArgs e)
    {
        this.ModalPopupExtender2.Hide();
        plShowOrders.Visible = true;
        this.GridView2.Visible = false;
    } //כפתור הביטול מסתיר את הגריד וויו עם המוצרים בהזמנה

    protected void gvShowAlbumsInOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header &&
           e.Row.RowType != DataControlRowType.Footer &&
           e.Row.RowType != DataControlRowType.Pager)
        {
            if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate) &&
                e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Normal))
            {
                AlbumHelper al = new AlbumHelper();
                ImageButton albumImg = e.Row.Cells[0].FindControl("albumImg") as ImageButton;
                albumImg.ToolTip = e.Row.Cells[1].Text;
                albumImg.Width = Unit.Pixel(70);
                albumImg.Height = Unit.Pixel(70);
                Byte[] albumPicBytes = this.service.GetAlbumImage(e.Row.Cells[1].Text);
                string base64String = Convert.ToBase64String(albumPicBytes, 0, albumPicBytes.Length);
                albumImg.ImageUrl = "data:image/jpeg;base64," + base64String;
                
                Label PriceSum = e.Row.Cells[3].FindControl("LabelPrice") as Label;
                TotalSum += int.Parse(PriceSum.Text);
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblAmount = e.Row.FindControl("LabelSum") as Label;
            lblAmount.Text = "מחיר כולל: " + "₪" + TotalSum.ToString();
        }
    } //הפעולה יוצרת את הגריד וויו בו מוצגים המוצרים

    protected void albumImg_Click(object sender, ImageClickEventArgs e)
    {
        string albumName = (sender as ImageButton).ToolTip;
        DataTable dt = Session["orderToPlay"] as DataTable;
        int count = dt.Rows.Count;
        this.gvShowAlbumsInOrder.Visible = true;
        this.gvShowAlbumsInOrder.DataSource = dt;
        this.gvShowAlbumsInOrder.DataBind();
        this.ModalPopupExtender2.Show();
        this.GridView2.Visible = true;
        songs = this.service.GetAlbumSongs(albumName);
        serviceurl = service.GetWSUrl();
        this.GridView2.DataSource = songs;
        this.GridView2.DataBind();

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header &&
          e.Row.RowType != DataControlRowType.Footer &&
          e.Row.RowType != DataControlRowType.Pager)
        {
            if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate) &&
                e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Normal))
            {
                WebVideo.WVC wvc = e.Row.Cells[3].FindControl("WVC1") as WebVideo.WVC;
                wvc.FilePath = "http://" + serviceurl + "/SongProductionWS/audio/" + songs[index - 1].longsongurl as string;
            }
        }
        this.index++;
    }
}