using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{

    private int catId; //קוד זיהוי קטגוריה
    private string name; //שם קטגוריה
    private string pic; //תמונת קטגוריה


	public Category(int id, string name, string pic)
	{
        this.catId = id;
        this.name = name;
        this.pic = pic;
	} //פעולה בונה המקבלת קוד זיהוי שם ותמונה

    public Category(string name)
    {
        
        this.name = name;
       
    } //פעולה המעדכנת את שם הקטגוריה

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
    } //פעולה המקבלת ומעדכנת קוד זיהוי קטגוריה

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
    } //פעולה המקבלת ומעדכנת שם קטגוריה

    public string Pic
    {
        get
        {
            return this.pic;
        }

        set
        {
            this.pic = value;
        }
        
    } //פעולה המקבלת ומעדכנת תמונת קטגוריה

}

