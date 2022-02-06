using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class ManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Customer c = (Customer)Session["userLogged"];
            if (c != null)
            {
                BindtheGridView();
                lbPrem.Visible = true;
                GridView1.Visible = false;
                if ((c.Premission != null) && (c.Premission == 2))
                {
                    lbPrem.Visible = false;
                    GridView1.Visible = true;
                }
            }
        }
    } //הפעולה בודקת האם למשתמש יש הרשאה לראות דף זה ומציגה אותו בהתאם

    private void BindtheGridView()
    {
        DataSet ds = CustomerHelper.GetCustomers();
        this.GridView1.DataSource = ds.Tables[0];
        this.GridView1.DataBind();
    } //הפעולה מאתחלת את טבלת המשתמשים
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        BindtheGridView();
    } //הפעולה נותנת אפשרות למנהל לערוך את פרטי המשתמשים
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

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Customer c = new Customer();
        GridViewRow row = GridView1.Rows[e.RowIndex];
        c.Email = row.Cells[1].Text;
        c.Fname = ((TextBox)row.Cells[2].Controls[0]).Text;
        c.Lname = ((TextBox)row.Cells[3].Controls[0]).Text;
        c.Password = ((TextBox)row.Cells[4].Controls[0]).Text;
        c.DateJoined = DateTime.Parse(row.Cells[5].Text);
        c.LastOnline = DateTime.Parse(row.Cells[6].Text);
        c.Premission = int.Parse(((TextBox)row.Cells[7].Controls[0]).Text);
        CustomerHelper ch = new CustomerHelper(c);
        if (ch.UpdateCustomer())
            lbres.Text = "לקוח " + c.Fname + ", עודכן בהצלחה!";
        else
        {
            lbres.ForeColor = Color.Red;
            lbres.Text = "שגיאה בעידכון";
        }
        this.GridView1.EditIndex = -1;
        BindtheGridView();
    } //הפעולה מעדכנת את מסד הנתונים במידע החדש שנערך עבור המשתמש

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Customer c = (Customer)Session["userLogged"];
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string st = row.Cells[1].Text;
        if (st != c.Email)
        {
            string sql = "DELETE from tblUsers WHERE email='" + st + "'";
            DAL dal = new DAL();
            dal.ExecuteNonQueryToDb(sql);
            this.GridView1.EditIndex = -1;
            BindtheGridView();
        }
        else
        {
            lbres.ForeColor = Color.Red;
            lbres.Font.Italic = true;
            lbres.Text = "אין ביכולתך למחוק את עצמך!";
            lbres.Visible = true;
        }
    } //הפעולה מוחקת משתמש

}