using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Customer c = Session["userLogged"] as Customer;
        if (c != null)
        {
            Panel1.Visible = false;
            this.lblMsg.Visible = true;
            this.lblMsg.Text = "אינך יכול לצפות בדף זה לאחר התחברות";
        }
        else
        {
            Panel1.Visible = true;
            lblMsg.Visible = false;
        }
    }
    protected void Submit_Clicked(object sender, EventArgs e)
    {
        Customer nc = new Customer();
        nc.Email = Email.Text;
        nc.DateJoined = DateTime.Now;
        nc.Fname = Fname.Text;
        nc.Lname = Lname.Text;
        nc.Password = Pass.Text;
        CustomerHelper custom_help1 = new CustomerHelper(nc);
        if (custom_help1.InsertToDB())
        {
            Response.Redirect("Login.aspx");
        }
        else
            Alert.Show("This email is already registered.");
    } //הפעולה בודקת האם המשתמש רשום כבר ומציגה הודעה בהתאם, אחרת רושמת משתמש חדש
}