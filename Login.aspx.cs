using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
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
    protected void Login_Clicked(object sender, EventArgs e)
    {

        string email = tb_Email.Text;
        string pass = tb_Pass.Text;
        Customer c = CustomerHelper.LoginCustomer(email, pass);

        if (c != null)
        {
            Session["userLogged"] = c;
            Response.Redirect("Store.aspx");
        }

        else
        {
            Alert.Show("Email or password are wrong.");
        }
        
    } //הפעולה בודקת האם שם המשתמש שהוכנס והסיסמא הם נכונים ומציגה הודעה בהתאם
}