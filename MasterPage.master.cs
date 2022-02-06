using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private Customer c = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userLogged"] == null)
        {
            populateMenuByPrem(0);
        }
        else
        {
            this.c = (Customer)Session["userLogged"];
            populateMenuByPrem(c.Premission);
        }

    } //הפעולה טוענת את התפריט על פי הרשאות המשתמש המחובר

    private void populateMenuByPrem(int prem)
    {
        if (prem == 0)
        {
            lbGreet.Text = "שלום אורח";
            lb_Logout.Visible = false;
            lb_Home.Visible = true;
            lb_Login.Visible = true;
            lb_Register.Visible = true;
            lb_Store.Visible = true;
            lb_Cart.Visible = false;
            lb_Manager.Visible = false;
            lb_EditProd.Visible = false;
            lb_OrderHistory.Visible = false;
        }

        if (prem == 1 || prem == 3)
        {
            lbGreet.Text = "שלום, " + this.c.Fname + "!";
            lb_Logout.Visible = true;
            lb_Home.Visible = true;
            lb_Login.Visible = false;
            lb_Register.Visible = false;
            lb_Store.Visible = true;
            lb_Cart.Visible = true;
            lb_Manager.Visible = false;
            lb_EditProd.Visible = false;
        }

        if (prem == 2)
        {
            lbGreet.Text = "שלום, " + this.c.Fname + "!";
            lb_Logout.Visible = true;
            lb_Home.Visible = true;
            lb_Login.Visible = false;
            lb_Register.Visible = false;
            lb_Store.Visible = true;
            lb_Cart.Visible = true;
            lb_Manager.Visible = true;
            lb_EditProd.Visible = true;
        }
    } //הפעולה מקבלת הרשאת משתמש ולפיו מראה את הדפים המתאימים

    protected void lb_Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Store.aspx");
    } //הפעולה מתנתקת מהSession
    protected void lb_Login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    } //הפעולה מעבירה את המשתמש לדף ההתחברות
    protected void lb_Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("Store.aspx");
    } //הפעולה מעבירה את המשתמש לדף הבית
    protected void lb_Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    } //הפעולה מעבירה את המשתמש לדף ההרשמה
    protected void lb_Store_Click(object sender, EventArgs e)
    {
        Response.Redirect("Store.aspx");
    } //הפעולה מעבירה את המשתמש לדף החנות
    protected void lb_Cart_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShopCart.aspx");
    } //הפעולה מעבירה את המשתמש לדף סל הקניות
    protected void ib_Logo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    } //הפעולה מעבירה את המשתמש לדף הבית
    protected void lb_Manager_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageUsers.aspx");
    } //הפעולה מעבירה את המשתמש לדף ניהול משתמשים
    protected void lb_EditProd_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditProducts.aspx");
    } //הפעולה מעבירה את המשתמש לדף עריכת מוצרים
    protected void lb_OrderHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderHistory.aspx");
    } //הפעולה מעבירה את המשתמש לדף היסטוריית הזמנות
}

