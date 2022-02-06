using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for ProductHelper
/// </summary>
public class AlbumHelper
{
    private Album album; //יצירת אלבום
    
    public AlbumHelper()
    {
    } //פעולה בונה ריקה
	public AlbumHelper(Album album)
	{
        this.album = album;
	} //פעולה בונה המקבלת אלבום
    public Album Album
    {
        get
        {
            return this.album;
        }
    }  //הפעולה מחזירה את האלבום
    public static DataSet GetAllProducts()
    {
        string sql = string.Format("SELECT * FROM tblAlbums ");
        DAL dal = new DAL();
        DataSet ds = dal.GetDataSet(sql);
        return ds;
    } //הפעולה מחזירה את כל האלבומים

    public static DataSet GetAllAlbumWithCategoryName(int CategoryId)
    {
        string sql = "";
        if (CategoryId == 999)
            sql = string.Format("SELECT tblAlbums.albumId, tblAlbums.price, tblAlbums.albumArtist, tblAlbums.albumLength, tblAlbums.albumName, tblCategories.categoryName FROM tblAlbums INNER JOIN tblCategories ON tblAlbums.categoryID=tblCategories.categoryID WHERE tblAlbums.availableForSale");
        else
            sql = string.Format("SELECT tblAlbums.albumId, tblAlbums.price, tblAlbums.albumArtist,  tblAlbums.albumLength, tblAlbums.albumName, tblCategories.categoryName FROM tblAlbums INNER JOIN tblCategories ON tblAlbums.categoryID=tblCategories.categoryID WHERE tblAlbums.categoryID={0} AND tblAlbums.availableForSale", CategoryId);
        DAL dal = new DAL();
        DataSet ds = dal.GetDataSet(sql);
        return ds;
    } //הפעולה מקבלת קוד זיהוי קטגוריה ומחזירה את כל האלבומים 
 
    public static DataSet GetAllAlbums(int CategoryId)
    {
        string sql = string.Format("SELECT * FROM tblAlbums WHERE CategoryID={0}", CategoryId);
        DAL dal = new DAL();
        DataSet ds = dal.GetDataSet(sql);
        return ds;
    } //הפעולה מחזירה את כל האלבומים

    public void InsertToDB()
    {
        string sql = string.Format("INSERT INTO tblAlbums (albumName,  albumArtist, price, categoryID, albumLength) VALUES ('{0}','{1}', {2}, {3}, {4})", this.album.Name, this.album.AlbumArtist, this.album.Price, this.album.CatId, this.album.AlbumLength);
        DAL dal = new DAL();
        if (dal.ExecuteNonQueryToDb(sql))
        {
            sql = "SELECT MAX(albumId) FROM tblAlbums";
            int pId = int.Parse(dal.ExecuteScalarToDb(sql).ToString());
            this.album.AlbumId = pId;
        }

        else
        {
            this.album.AlbumId = -999;
        }
    } //הפעולה מכניסה אלבום לתוך מסד הנתונים

    public bool InsertToDB(Album [] albums)
    {
        DAL dal = new DAL();
        try
        {
            for (int i = 0; i < albums.Length; i++)
            {
                if (!IsExist(albums[i]))
                {
                    string sql = string.Format("INSERT INTO tblAlbums (albumName,  albumArtist, price, categoryID, albumLength) VALUES ('{0}','{1}', {2}, {3}, {4})", albums[i].Name, albums[i].AlbumArtist, albums[i].Price, albums[i].CatId, albums[i].AlbumLength);
                    if (dal.ExecuteNonQueryToDb(sql))
                    {
                        sql = "SELECT MAX(albumId) FROM tblAlbums";
                        int aid = int.Parse(dal.ExecuteScalarToDb(sql).ToString());
                        albums[i].AlbumId = aid;
                    }
                    else
                    {
                        albums[i].AlbumId = -999;
                        return false;
                    }
                }
                else
                {
                    string sql = string.Format("UPDATE tblAlbums SET availableForSale=1 WHERE albumName='{0}'", albums[i].Name);
                    dal.ExecuteNonQueryToDb(sql);
                    return true;
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    } // הפעולה מכניסה כמה אלבומים אל תוך מסד הנתונים ומחזירה אמת אם הם נכנסו אחרת שקר 
    public bool IsExist(Album al)
    {
        string sql = string.Format("SELECT albumName FROM tblAlbums WHERE albumName='{0}'", al.Name);
        DAL dal = new DAL();
        object o = dal.ExecuteScalarToDb(sql);
        if (o == null)
        {
            return false;
        }
        return true;
    } // הפעולה בודקת האם האלבום קיים במסד הנתונים

    public string GetAlbumNameWithID(int AlbumID)
    {
        string AlbumName = "";
        if (AlbumID != null)
        {
            string sql = string.Format("SELECT tblAlbums.albumName WHERE tblAlbums.albumId='{0}'", AlbumID);
            DAL dal = new DAL();
            AlbumName = (dal.GetDataSet(sql)).ToString();
            return AlbumName;
        }
        return AlbumName;
    } //הפעולה מקבלת קוד זיהוי קטגוריה ומחזירה את כל האלבומים 

}

