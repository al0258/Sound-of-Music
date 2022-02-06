using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Album
{
    private string name; //שם האלבום
    private int albumSysId; //אלבום ID
    private int price; //מחיר אלבום
    private int catId; //קטגוריה ID
    private byte []  albumPic; //תמונת אלבום
    private double albumLength; //אורך אלבום
    private string albumArtist; //האמן שיצר את האלבום

    public Album()
    {
    } //פעולה בונה ריקה

    public Album( string name, int price, int catId, double albumLength, string albumArtist)
    {
        this.name = name;
        this.price = price;
        this.catId = catId;
        this.albumLength = albumLength;
        this.albumArtist = albumArtist;
    }

    public int AlbumId
    {
        get
        {
            return this.albumSysId;
        }
        set
        {
            this.albumSysId = value;
        }
    } //הפעולה מחזירה ומעדכנת קוד זיהוי אלבום

    public byte[] AlbumPic
    {
        get
        {
            return this.albumPic;
        }

        set
        {
            this.albumPic = value;
        }
    } //הפעולה מחזירה ומעדכנת את תמונת האלבום

    public string AlbumArtist
    {
        get
        {
            return this.albumArtist;
        }

        set
        {
            this.albumArtist = value;
        }
    } //הפעולה מחזירה ומעדכנת את אמן האלבום

    public double AlbumLength
    {
        get
        {
            return this.albumLength;
        }

        set
        {
            this.albumLength = value;
        }
    } //הפעולה מחזירה ומעדכנת את אורך האלבום

    public int CatId
    {
        get
        {
            return this.catId;
        }

        set
        {
            this.catId = value;
        }
    } //הפעולה מחזירה ומעדכנת את קוד זיהוי הקטגוריה

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
    } //הפעולה מחזירה ומעדכנת את שם האלבום

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
    } //הפעולה מחזירה ומעדכנת את מחיר האלבום
}

