using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductInCart
/// </summary>
public class AlbumInCart
{
    private string name; //שם
    private int price; //מחיר
    private string categoryName; //שם קטגוריה 
    private int albumId; //קוד זיהוי אלבום

    public AlbumInCart(string name, int price, string categoryName, int albumId)
    {
        this.name = name;
        this.price = price;
        this.categoryName = categoryName;
        this.albumId = albumId;
    } //פעולה בונה המקבלת שם מחיר שם קטגוריה וקוד זיהוי קטגוריה

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
    } //הפעולה מחזירה ומעדכנת קוד זיהוי  אלבום

    public string CatName
    {
        get
        {
            return this.CatName;
        }
        set
        {
            this.CatName = value;
        }
    } //הפעולה מחזירה ומעדכנת שם קטגוריה

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            this.name = value;
        }
    }// הפעולה מחזירה ומעדכנת שם אלבום

    public int Price
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
   
}

