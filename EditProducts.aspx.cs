using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lb_AddProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProduct.aspx");
    }
    protected void lb_RemoveProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("RemoveProduct.aspx");
    }
}