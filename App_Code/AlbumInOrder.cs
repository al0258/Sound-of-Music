using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for albumInOrder
/// </summary>
public class AlbumInOrder
{
    private int orderId; //קוד זיהוי הזמנה
    private int albumId; //קוד זיהוי אלבום
    private double price; //מחיר

    public AlbumInOrder()
    {
    } //פעולה בונה ריקה
    public AlbumInOrder(int orderId, int albumId, double price)
    {
        this.orderId = orderId;
        this.albumId = albumId;
        this.price = price;
    } //פעולה בונה המקבלת קוד זיהוי הזמנה קוד זיהוי אלבום ומחיר
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
    } //הפעולה מחזירה ומעדכנת קוד זיהוי הזמנה
    public int AlbumId
    {
        get
        {
            return this.albumId;
        }
        set
        {
            this.albumId = value;
        }
    } //הפעולה מחזירה ומעדכנת קוד זיהוי אלבום
    public double Price
    {
        get
        {
            return this.price;
        }
        set
        {
            this.price = value;
        }
    } //הפעולה מחזירה ומעדכנת מחיר
    public bool InsertToDB(ShoppingBag shopBag, int OrderID)
    {
        AlbumInCart Aic;
        int itemsInCart = shopBag.ItemsCount();
        try
        {
            for (int i = 0; i < itemsInCart; i++)
            {
                Aic = shopBag.GetProduct(i);
                if (Aic != null)
                {
                    string sql = string.Format("INSERT INTO tblAlbumsInOrder (OrderId, albumId, price) VALUES ({0}, {1}, {2})", OrderID, Aic.AlbumId, Aic.Price);
                    DAL dal = new DAL();
                    dal.ExecuteNonQueryToDb(sql);
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    } //הפעולה מכניסה את ההזמנה אל טבלת הזמנות
}

