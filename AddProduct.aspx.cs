using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;


public partial class InsertProduct : System.Web.UI.Page
{
    Production.ProductionWS pws = new Production.ProductionWS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateCategories();
            Customer c = (Customer)Session["userLogged"];
            Panel1.Visible = false;
            if ((c.Premission != null) && (c.Premission == 2))
            {
                lbPrem.Visible = false;
                Panel1.Visible = true;
            }
            else
            {
                Response.Redirect("Store.aspxs");
            }
        }
    } //הפעולה בודקת את הרשאת המשתמש ומציגה את הדף בהתאם


    private void populateCategoryAlbums(Production.Album [] albums)
    {
        this.GridView1.DataSource = albums;
        this.GridView1.DataBind();
    } //הפעולה מציגה את האלבומים הניתנים להוספה

    private void PopulateCategories()
    {
        string[] cats = this.pws.GetAlbumCategories();
        this.ddlCat.DataSource = cats;
        this.ddlCat.DataBind();
        ListItem item = new ListItem("", "-1");
        this.ddlCat.Items.Insert(0, item);
    } //הפעולה ממלאת את התפריט של הקטגוריות

    protected void btsend_Click(object sender, EventArgs e)
    {
        if (!IsSelected())
            return;
        Album [] albumsArr = new Album[this.GridView1.Rows.Count];
        string catName = this.ddlCat.SelectedValue;
        int catId = CategoryHelper.GetCategoryId(catName);
        if (catId == -1)
        {
            Category newCat = new Category(catName);
            CategoryHelper helper = new CategoryHelper(newCat);
            helper.InsertToDB();
            catId = newCat.CatId;
        }
        int i=0;
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            CheckBox ch = (CheckBox)row.Cells[0].FindControl("addAlbum");

            if (ch.Checked)
            {
                Album newAlbum = new Album(row.Cells[1].Text, int.Parse(row.Cells[4].Text), catId, double.Parse(row.Cells[2].Text), row.Cells[3].Text);
                albumsArr[i] = newAlbum;
                i++;
            }
           
        }
        AlbumHelper alHelp = new AlbumHelper();
        if (alHelp.InsertToDB(albumsArr))
        {
            Category newCat = new Category(catName);
            CategoryHelper helper = new CategoryHelper(newCat);
            helper.InsertToDB();
            catId = newCat.CatId;
            lbmsg.Text = "אלבומים נוספו בהצלחה לחנות!!";
        }
        else
            lbmsg.Text = "מוצרים לא נכנסו לחנות!!";

        lbmsg.Visible = true;
        
    } //הפעולה מנסה להוסיף את האלבומים שנבחרו לחנות ומציגה הודעה בהתאם

    private bool IsSelected()
    {
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            CheckBox ch = (CheckBox)row.Cells[0].FindControl("addAlbum");
            if (ch.Checked)
            {
                return true;
            }
        }
        return false;
    } //הפעולה בודקת האם המוצר נבחר ומחזירה אמת או שקר בהתאם

    private bool IsExisting()
    {
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            CheckBox ch = (CheckBox)row.Cells[0].FindControl("addAlbum");
            if (ch.Checked)
            {
                return true;
            }
        }
        return false;
    } //הפעולה בודקת האם המוצר קיים כבר בחנות ומחזירה אמת או שקר בהתאם

    protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string catName = this.ddlCat.SelectedValue;
        Production.Category catDetails = this.pws.GetCatDetails(catName);
        Session["selectedCat"] = catDetails;
        this.lbCat.Text = "קטגוריה: " + catName;
        this.lbAlbums.Text = "כמות שירים בקטגוריה זו: : " + catDetails.TotalAlbums;
        string base64String = Convert.ToBase64String(catDetails.Pic, 0, catDetails.Pic.Length);
        this.imgcatpic.ImageUrl = "data:image/jpeg;base64," +base64String ;
        double rate = catDetails.Rating;
        int fullStars = (int)rate;
        double left = rate - fullStars;
        TableRow row = new TableRow();
        for (int i = 0; i < fullStars; i++)
        {
            TableCell cell = new TableCell();
            System.Web.UI.WebControls.Image im = new System.Web.UI.WebControls.Image();
            im.ImageUrl = "Images/categoryPics/star.jpg";
            im.Height = Unit.Pixel(50);
            im.Width = Unit.Pixel(50);
            cell.Controls.AddAt(0, im);
            row.Cells.AddAt(i, cell);
        }
        if (left >=0.5)
        {
            TableCell cell = new TableCell();
            Image im = new Image();
            im.ImageUrl = "Images/categoryPics/starhalf.jpg";
            im.Height = Unit.Pixel(50);
            im.Width = Unit.Pixel(25);
            cell.Controls.AddAt(0, im);
            row.Cells.Add(cell);
        }
        this.tableRate.Rows.Add(row);
        this.tableRate.CellSpacing = 2;
        this.imgcatpic.Visible = true;
        populateCategoryAlbums(catDetails.CatAllAlbums);
    } //הפעולה מציגה בטבלה או האלבומים של הקטגוריה שנבחרה

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header &&
         e.Row.RowType != DataControlRowType.Footer &&
         e.Row.RowType != DataControlRowType.Pager)

        {
            if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate) &&
                e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Normal))
            {
                
                string albumName = e.Row.Cells[1].Text;
                Production.Album album = FindAlbum(albumName);
                ImageButton albumPic = (ImageButton)e.Row.Cells[4].FindControl("albumPic");
                albumPic.ToolTip = albumName;
                string base64String = Convert.ToBase64String(album.PicAlbum, 0, album.PicAlbum.Length);

                albumPic.ImageUrl = "data:image/jpeg;base64," + base64String;
                albumPic.Width = Unit.Pixel(80);
                albumPic.Height = Unit.Pixel(80);

            }
        }
    } //הפעולה יוצרת את הטבלה בה מוצגים האלבומים


    private Production.Album FindAlbum(string albumName)
    {
        Production.Category catDetails = Session["selectedCat"] as Production.Category;
        foreach (Production.Album album in catDetails.CatAllAlbums)
        {
            if (album.Name.Equals(albumName))
                return album;
        }

        return null;
    } //הפעולה מקבלת שם אלבום ואם הוא קיים היא מחזירה אותו
    protected void albumPic_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton albumPic = sender as ImageButton;
        string albumName = albumPic.ToolTip;
        string source = pws.GetAlbumSource(albumName);
    }
}