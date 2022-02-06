using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class RemoveProduct : System.Web.UI.Page
{
    Production.ProductionWS service = new Production.ProductionWS();
    protected void Page_Load(object sender, EventArgs e)
    {
        Customer c = (Customer)Session["userLogged"];
        if (!IsPostBack)
        {
            if ((c != null) && (c.Premission == 2))
            {
                DataTable dt = CategoryHelper.GetAllCategories().Tables[0];
                DataRow row = dt.NewRow();
                row["categoryID"] = 999;
                row["categoryName"] = "הכל";
                dt.Rows.InsertAt(row, 0);
                this.ddl_Categories.DataSource = dt;
                this.ddl_Categories.DataValueField = "categoryID";
                this.ddl_Categories.DataTextField = "categoryName";
                this.ddl_Categories.DataBind();
                BindtheGridView();
                lbPrem.Visible = false;
                pl_RemoveProducts.Visible = true;
            }
            else
            {
                pl_RemoveProducts.Visible = false;
                lbPrem.Visible = true;
            }
        }
    } //הפעולה בודקת את הרשאת המשתמש ומציגה את הדף בהתאם
    public void BindtheGridView()
    {
        Customer c = Session["userLogged"] as Customer;
        DataSet ds = AlbumHelper.GetAllAlbumWithCategoryName(int.Parse(this.ddl_Categories.SelectedValue.ToString()));
        this.gv_RemoveProducts.DataSource = ds.Tables[0];
        this.gv_RemoveProducts.DataBind();
    } //הפעולה מאתחלת את טבלת האלבומים
    protected void gv_RemoveProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Customer c = (Customer)Session["userLogged"];
        GridViewRow row = gv_RemoveProducts.Rows[e.RowIndex];
        string ac = row.Cells[1].Text;
        DAL dal = new DAL();
        string sql = "SELECT categoryID from tblAlbums WHERE albumId=" + ac;
        int catID = int.Parse(dal.ExecuteScalarToDb(sql).ToString());
        sql = "UPDATE tblAlbums SET availableForSale=0 WHERE albumId=" + ac;
        if (dal.ExecuteNonQueryToDb(sql))
        {
            this.gv_RemoveProducts.EditIndex = -1;
            BindtheGridView();
            this.lblMsg.Visible = true;
            this.lblMsg.Text = "המוצר נמחק בהצלחה!";
            if (AlbumHelper.GetAllAlbumWithCategoryName(catID).Tables[0].Rows.Count == 0)
            {
                sql = "UPDATE tblCategories SET isAvailable=0 WHERE categoryID=" + catID;
                dal.ExecuteNonQueryToDb(sql);
                DataTable dt = CategoryHelper.GetAllCategories().Tables[0];
                DataRow Row = dt.NewRow();
                Row["categoryID"] = 999;
                Row["categoryName"] = "הכל";
                dt.Rows.InsertAt(Row, 0);
                this.ddl_Categories.DataSource = dt;
                this.ddl_Categories.DataValueField = "categoryID";
                this.ddl_Categories.DataTextField = "categoryName";
                this.ddl_Categories.DataBind();
            }
        }
        else
        {
            this.lblMsg.Visible = true;
            this.lblMsg.Text = "שגיאה במחיקת המוצר.";
        }
    } //הפעולה מוחקת מוצר מהחנות
    protected void ddl_Categories_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CategoryId = int.Parse(this.ddl_Categories.SelectedValue.ToString());
        if (CategoryId == 999)
        {
            this.gv_RemoveProducts.DataSource = AlbumHelper.GetAllAlbumWithCategoryName(999);
        }
        else
        {
            this.gv_RemoveProducts.DataSource = AlbumHelper.GetAllAlbumWithCategoryName(CategoryId);
        }

        this.gv_RemoveProducts.DataBind();
    } //הפעולה מציגה את האלבומים בקטגוריה שנבחרה
    protected void gv_RemoveProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header &&
           e.Row.RowType != DataControlRowType.Footer &&
           e.Row.RowType != DataControlRowType.Pager)
        {
            if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate) &&
                e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Normal))
            {
                AlbumHelper al = new AlbumHelper();
                Image albumImg = e.Row.Cells[0].FindControl("albumImg") as Image;
                albumImg.Width = Unit.Pixel(70);
                albumImg.Height = Unit.Pixel(70);
                Byte[] albumPicBytes = this.service.GetAlbumImage(e.Row.Cells[2].Text);
                string base64String = Convert.ToBase64String(albumPicBytes, 0, albumPicBytes.Length);
                albumImg.ImageUrl = "data:image/jpeg;base64," + base64String;
            }
        }
    } //הפעולה יוצרת את הגריד וויו בו מוצגים המוצרים
}