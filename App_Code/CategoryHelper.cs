using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CategoryHelper
/// </summary>
public class CategoryHelper
{
    private Category category; //קטגוריה

    public CategoryHelper(Category cat) //פעולה בונה המקבלת קטגוריה
    {
        this.category = cat;
    }

    public static bool IsExist(string catname)
    {
        string sql = string.Format("SELECT categoryID FROM tblCategories WHERE categoryName='{0}'", catname);
        DAL dal = new DAL();
        object o = dal.ExecuteScalarToDb(sql);
        if ((o != null) && (!o.ToString().Equals("")))
            return true;
        return false;
    }  //פעולה המקבלת שם קטגוריה ובודקת אם הוא קיים במסד נתונים מחזירה אמת אם כן אחרת שקר

    public static int GetCategoryId(string catname)
    {
        string sql = string.Format("SELECT categoryID FROM tblCategories WHERE categoryName='{0}'", catname);
        DAL dal = new DAL();
        object o = dal.ExecuteScalarToDb(sql);
        if ((o != null) && (!o.ToString().Equals("")))
            return int.Parse(o.ToString());
        return -1;
    } //פעולה המקבלת שם קטגוריה ומחזירה את קוד הזיהוי שלה

    public bool InsertToDB()
    {
        try
        {
            if (!IsExist(this.category.Name))
            {
                string sql = string.Format("INSERT INTO tblCategories (categoryName) VALUES ('{0}')", this.category.Name);
                DAL dal = new DAL();
                dal.ExecuteNonQueryToDb(sql);
                sql = string.Format("SELECT categoryID FROM tblCategories WHERE categoryName='{0}'", this.category.Name);
                int newid = int.Parse(dal.ExecuteScalarToDb(sql).ToString());
                this.category.CatId = newid;

                return true;
            }
            else
            {
                string sql = string.Format("UPDATE tblCategories SET isAvailable=1 WHERE categoryName='{0}'", this.category.Name);
                DAL dal = new DAL();
                dal.ExecuteNonQueryToDb(sql);
                sql = string.Format("SELECT categoryID FROM tblCategories WHERE categoryName='{0}'", this.category.Name);
                int newid = int.Parse(dal.ExecuteScalarToDb(sql).ToString());
                this.category.CatId = newid;
                return true;
            }
        }
        catch
        {
            return false;
        }
    } //פעולה המכניסה את הקטגוריה אל תוך מסד הנתונים

    public static DataSet GetAllCategories()
    {
        string sql = string.Format("SELECT * FROM tblCategories WHERE isAvailable");
        DAL dal = new DAL();
        DataSet ds= dal.GetDataSet(sql);
        DataTable dt = ds.Tables[0];
        return ds;
    } //פעולה המחזירה את כל הקטגוריות

    public Category Category
    {
        get { return this.category; }
    } //פעולה המחזירה את הקטגוריה

    public static string GetCategoryNameWithID(int catID)
    {
        string sql = string.Format("SELECT categoryName FROM tblCategories WHERE categoryID={0}", catID);
        DAL dal = new DAL();
        object o = dal.ExecuteScalarToDb(sql);
        if ((o != null) && (!o.ToString().Equals("")))
            return o.ToString();
        return "";
    } //פעולה המקבלת שם קטגוריה ומחזירה את קוד הזיהוי שלה
}

