using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Store : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    Production.Song[] songs;
    int index = 0;
    Production.ProductionWS service = new Production.ProductionWS();
    string serviceurl;
    protected ShoppingBag ShoppingBag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = CategoryHelper.GetAllCategories().Tables[0];
            DataRow row = dt.NewRow();
            row["categoryID"] = 999;
            row["categoryName"] = "הכל";
            dt.Rows.InsertAt(row, 0);
            this.DropDownList1.DataSource = dt;
            this.DropDownList1.DataValueField = "categoryID";
            this.DropDownList1.DataTextField = "categoryName";
            this.DropDownList1.DataBind();
            this.DataList1.DataSource = AlbumHelper.GetAllAlbumWithCategoryName(999);
            this.DataList1.DataBind();
        }

        else
            InitShopBag();

    } //הפעולה מאתחלת את החנות והפריטים בה
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CategoryId = int.Parse(this.DropDownList1.SelectedValue.ToString());
        if (CategoryId == 999)
        {
            this.DataList1.DataSource = AlbumHelper.GetAllAlbumWithCategoryName(999);

        }
        else
        {
            this.DataList1.DataSource = AlbumHelper.GetAllAlbumWithCategoryName(CategoryId);

        }

        this.DataList1.DataBind();
    } //הפעולה מציגה את האלבומים בקטגוריה שנבחרה
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string albumName = ((Label)this.DataList1.SelectedItem.FindControl("lbAlbumName")).Text;
        songs = this.service.GetAlbumSongs(albumName);
        serviceurl = service.GetWSUrl();
        this.GridView1.DataSource = songs;
        this.GridView1.DataBind();
    }
    private void InitShopBag()
    {
        if (Session["myShoppingBag"] == null)
        {
            Customer c = (Customer)Session["userLogged"];
            this.ShoppingBag = new ShoppingBag(c);
        }
        else
        {
            this.ShoppingBag = (ShoppingBag)Session["myShoppingBag"];
        }
    } //הפעולה מאתחלת את סל הקניות

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataListItem item = e.Item;
        Image img = item.FindControl("imgAlbum") as Image;
        Label lbAlbumName = item.FindControl("lbAlbumName") as Label;
        string albumName = lbAlbumName.Text;
        Byte[] albumPicBytes = this.service.GetAlbumImage(albumName);
        string base64String = Convert.ToBase64String(albumPicBytes, 0, albumPicBytes.Length);
        img.ImageUrl = "data:image/jpeg;base64," + base64String;

    } //הפעולה מציגה כל אלבום מתוך המסד נתונים

    protected void btAddToCart_Click(object sender, EventArgs e)
    {

        foreach (DataListItem item in this.DataList1.Items)
        {

            CheckBox cbAddProduct = item.FindControl("cbAddToCart") as CheckBox;
            if (cbAddProduct.Checked)
            {
                string albumName = ((Label)item.FindControl("lbAlbumName")).Text;
                string cName = ((Label)item.FindControl("lbIdCat")).Text;
                int price = int.Parse(((Label)item.FindControl("lbPrice")).Text);
                Image pic = (Image)item.FindControl("ImgItem");
                int albumId = int.Parse(((Label)item.FindControl("Label3")).Text);
                AlbumInCart s = new AlbumInCart(albumName, price, cName, albumId);
                this.ShoppingBag.AddProduct(s);

            }
        }

        Session["myShoppingBag"] = this.ShoppingBag;
        Response.Redirect("ShopCart.aspx");
    }
    protected void lbAlbumId_Click(object sender, EventArgs e)
    {
        Button btsia = sender as Button;
        Session["btsia"] = null;
        Session["btsia"] = btsia.Text;
        Response.Redirect("SongsInAlbum.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header &&
          e.Row.RowType != DataControlRowType.Footer &&
          e.Row.RowType != DataControlRowType.Pager)
        {
            if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate) &&
                e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Normal))
            {
                WebVideo.WVC wvc = e.Row.Cells[3].FindControl("WVC1") as WebVideo.WVC;
                Customer c = Session["userLogged"] as Customer;
                if (c != null)
                {
                    if (c.Premission == 2 || c.Premission == 3)
                    {
                        wvc.FilePath = "http://" + serviceurl + "/SongProductionWS/audio/" + songs[index - 1].longsongurl as string;
                    }
                    else
                    {
                        wvc.FilePath = "http://" + serviceurl + "/SongProductionWS/audio/" + songs[index - 1].shortsongurl as string;
                    }
                }
                else
                {
                    wvc.FilePath = "http://" + serviceurl + "/SongProductionWS/audio/" + songs[index - 1].shortsongurl as string;
                }
            }
        }
        this.index++;
    }
} //הפעולה מוסיפה את כל הפריטים שנבחרו בחנות אל סל הקניות