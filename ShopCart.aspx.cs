using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShopCart : System.Web.UI.Page
{
    protected ShoppingBag Shoppingbag;
    Production.ProductionWS service = new Production.ProductionWS();
    protected void Page_Load(object sender, EventArgs e)
    {
        Shoppingbag = (ShoppingBag)Session["myShoppingBag"];
        if (Shoppingbag == null)
        {
            this.lbEmpty.Visible = true;
            this.Show_CheckOut.Visible = false;
        }
        else
        {
            this.GridView1.DataSource = Shoppingbag.Products;
            this.GridView1.DataBind();
        }
        if (!IsPostBack)
        {
            for (int i = 0; i <= 12; i++)
            {
                int year = int.Parse(DateTime.Now.Year.ToString()) + i;
                this.ddl_ExpDate_Year.Items.Add(year.ToString());
                if (i > 0)
                {
                    this.ddl_ExpDate_Month.Items.Add(i.ToString());
                }
            }
        }
    } //הפעולה בודקת אם סל הקניות ריק ומאתחלת לחצנים בדף
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header &&
           e.Row.RowType != DataControlRowType.Footer &&
           e.Row.RowType != DataControlRowType.Pager)
        {
            if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate) &&
                e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Normal))
            {
                Image albumImg = e.Row.Cells[3].FindControl("albumImg") as Image;
                albumImg.Width = Unit.Pixel(70);
                albumImg.Height = Unit.Pixel(70);
                string albumName = e.Row.Cells[2].Text;
                Byte[] albumPicBytes = this.service.GetAlbumImage(albumName);
                string base64String = Convert.ToBase64String(albumPicBytes, 0, albumPicBytes.Length);
                albumImg.ImageUrl = "data:image/jpeg;base64," + base64String;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            double sum = this.Shoppingbag.GetFinalPrice();
            Label lblAmount = e.Row.FindControl("LabelSum") as Label;
            lblAmount.Text = "מחיר כולל: " + "₪" + sum.ToString();
        }
    } //הפעולה יוצרת את הגריד וויו בו מוצגים המוצרים
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Show_CheckOut_Click(object sender, EventArgs e)
    {
        this.Payment_Credit.Visible = true;
        this.Show_CheckOut.Visible = false;
        Customer c = Session["userLogged"] as Customer;
        string tbEmail = c.Email;
        this.tb_Email.Text = tbEmail.First().ToString().ToUpper() + String.Join("", tbEmail.Skip(1));
    } //הפעולה מראה למשתמש את פאנל הקנייה
    protected void Cancel_Click(object sender, EventArgs e)
    {
        this.Show_CheckOut.Visible = true;
        this.Payment_Credit.Visible = false;
        this.lblOrderStatus.Visible = false;
    } //הפעולה מבטלת את הקנייה
    protected void CheckOut_Click(object sender, EventArgs e)
    {
        if ((this.tb_CreditCardNum.Text != "") && (this.tb_LastDigits.Text != ""))
        {
            paymentService.CreditService service = new paymentService.CreditService();
            Customer c = (Customer)Session["userLogged"];
            int CreditCardNumber = int.Parse(this.tb_CreditCardNum.Text);
            int LastDigits = int.Parse(this.tb_LastDigits.Text);
            double toPay = this.Shoppingbag.GetFinalPrice();
            string expDatestr = this.ddl_ExpDate_Month.Text + "/" + this.ddl_ExpDate_Year.Text;
            DateTime expDate = DateTime.Parse(expDatestr);
            string str = service.UpdateCustomerCredit(CreditCardNumber, LastDigits, toPay, DateTime.Now, expDate);
            if (str == "התשלום עבר בהצלחה!")
            {
                Customer cust = Session["userLogged"] as Customer;
                Order order = new Order();
                order.Email = cust.Email;
                order.OrderDate = DateTime.Now;
                order.PaymentStatus = "Payed";
                order.TotalPrice = toPay;
                OrderHelper orderhlp = new OrderHelper(order);
                if (orderhlp.InsertToDB(this.Shoppingbag))
                {
                    lblOrderStatus.Visible = true;
                    lblOrderStatus.Text = str;
                    str = null;
                }
            }
            else
            {
                lblOrderStatus.Visible = true;
                lblOrderStatus.Text = str;
                str = null;
            }
        }
        else
        {
            this.lblOrderStatus.Text = "שדות כרטיס האשראי לא מולאו כראוי!";
            this.lblOrderStatus.Visible = true;
        }
    } //הפעולה בודקת את השדות שמולאו ואת פרטי כרטיס האשראי ואם הקנייה הצליחה היא יוצרת הזמנה חדשה
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int albumId = int.Parse(this.GridView1.Rows[e.RowIndex].Cells[1].Text);
        this.Shoppingbag.SearchAndDeleteProduct(albumId);
        this.GridView1.DataSource = Shoppingbag.Products;
        this.GridView1.DataBind();
    } //הפעולה מוחקת את האלבום מהסל קניות
}