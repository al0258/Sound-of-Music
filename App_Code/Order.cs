using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    private int orderId; //קוד זיהוי הזמנה
    private string email; //אימייל
    private double totalPrice; //מחיר כולל של ההזמנה
    private DateTime orderDate; //תאריך הזמנה
    private string paymentStatus; //מצב התשלום

    public Order()
    {
    } //פעולה בונה ריקה

    public Order(int orderId, string email, double totalPrice, DateTime orderDate, string paymentStatus)
	{
        this.orderId = orderId;
        this.email = email;
        this.totalPrice = totalPrice;
        this.orderDate = orderDate;
        this.paymentStatus = paymentStatus;
	} //פעולה בונה המקבלת קוד זיהוי הזמנה אימייל מחיר כולל תאריך ומצב הזמנה

    public int OrderId
    {
        get
        {
            return this.orderId;
        }
        set
        {
            this.orderId = value;
        }
    } //הפעולה מחזירה ומעדכנת את קוד זיהוי ההזמנה

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            this.email = value;
        }
    }  //הפעולה מחזירה ומעדכנת את האימייל

    public double TotalPrice
    {
        get
        {
            return this.totalPrice;
        }
        set
        {
            this.totalPrice = value;
        }
    } //הפעולה מחזירה ומעדכנת את המחיר הכולל של ההזמנה

    public DateTime OrderDate
    {
        get
        {
            return this.orderDate;
        }
        set
        {
            this.orderDate = value;
        }
    }  //הפעולה מחזירה ומעדכנת את תאריך ההזמנה

    public string PaymentStatus
    {
        get
        {
            return this.paymentStatus;
        }
        set
        {
            this.paymentStatus = value;
        }
    }  //הפעולה מחזירה ומעדכנת את מצב התשלום

    public static DataTable GetProductsInOrderDetails(int OrderId)
    {
        string sql = string.Format("SELECT tblAlbumsInOrder.*, tblAlbums.albumName FROM tblAlbumsInOrder,tblAlbums WHERE  tblAlbumsInOrder.albumId = tblAlbums.albumId and tblAlbumsInOrder.OrderId={0}", OrderId);
        DAL dal = new DAL();
        return dal.GetDataSet(sql).Tables[0];
    } //פעולה המקבלת קוד זיהוי הזמנה ומחזירה טבלה של כל המוצרים בהזמנה

}

