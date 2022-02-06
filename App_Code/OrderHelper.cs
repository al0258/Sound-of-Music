using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for OrderHelper
/// </summary>
public class OrderHelper
{
    private Order order; //הזמנה

    public OrderHelper(Order order)
    {
        this.order = order;
    } //פעולה בונה המקבלת הזמנה

    private int GetOrderId()
    {
        int orderId = -1;
        string sql = string.Format("SELECT MAX(OrderId) From tblOrder where email='{0}'", this.order.Email);
        DAL dal = new DAL();
        Object o = dal.ExecuteScalarToDb(sql);
        if (o != null)
        {
            orderId = int.Parse(o.ToString());
        }
        return orderId;
    } //פעולה בונה המחזירה את קוד זיהוי ההזמנה

    public bool InsertToDB(ShoppingBag shopBag)
    {
        try
        {
            string sql = string.Format("INSERT INTO tblOrder (email, totalPrice, orderDate, paymentStatus) VALUES ('{0}', {1}, '{2}', '{3}')", this.order.Email, this.order.TotalPrice, this.order.OrderDate, this.order.PaymentStatus);
            DAL dal = new DAL();
            dal.ExecuteNonQueryToDb(sql);
            AlbumInOrder Aio = new AlbumInOrder();
            return Aio.InsertToDB(shopBag, GetOrderId());
        }
        catch
        {
            return false;
        }
    } //פעולה המכניסה את ההזמנה את מסד הנתונים מחזירה אמת אם ההכנסה התבצעה בהצלחה אחרת שקר

    public static DataSet GetOrders()
    {

        string sql = "SELECT * FROM tblOrder ";
        DAL dal = new DAL();
        DataSet ds = dal.GetDataSet(sql);
        return ds;
    } //DataSet פעולה המחזירה את כל ההזמנות בטבלת

    public static DataSet GetOrdersByEmail(string email)
    {

        string sql = string.Format("SELECT * FROM tblOrder WHERE email='{0}'",email);
        DAL dal = new DAL();
        DataSet ds = dal.GetDataSet(sql);
        return ds;
    } //פעולה המקבלת אימייל ומחזירה את כל ההזמנות השייכות לאימייל

}

