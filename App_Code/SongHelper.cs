using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SongHelper
/// </summary>
public class SongHelper
{
    private Song song;
    public SongHelper()
    {
    }
    public SongHelper(Song song)
    {
        this.song = song;
    } //פעולה בונה המקבלת אלבום
    public Song Song
    {
        get
        {
            return this.song;
        }
    }
    public static DataSet GetAllSongs()
    {
        string sql = string.Format("SELECT * FROM tblSongs ");
        DAL dal = new DAL();
        DataSet ds = dal.GetDataSet(sql);
        return ds;
    }

    public static DataSet GetAllSongsWithAlbumName(int AlbumID)
    {
        string sql = string.Format("SELECT tblSongs.songId, tblSongs.songName, tblSongs.songLength, tblSongs.albumId FROM tblSongs INNER JOIN tblAlbums ON tblSongs.albumId=tblAlbums.albumId WHERE tblSongs.albumId={0}", AlbumID);
        DAL dal = new DAL();
        DataSet ds = dal.GetDataSet(sql);
        return ds;
    } //הפעולה מקבלת קוד זיהוי קטגוריה ומחזירה את כל האלבומים 

    public void InsertToDB()
    {
        string sql = string.Format("INSERT INTO tblSongs (songName, songLength, albumId) VALUES ('{0}',{1}, {2})", this.song.Name, this.song.SongLength, this.song.AlbumId);
        DAL dal = new DAL();
        if (dal.ExecuteNonQueryToDb(sql))
        {
            sql = "SELECT MAX(songId) FROM tblSongs";
            int pId = int.Parse(dal.ExecuteScalarToDb(sql).ToString());
            this.song.SongId = pId;
        }

        else
        {
            this.song.SongId = -999;
        }
    } //הפעולה מכניסה אלבום לתוך מסד הנתונים

    public bool InsertToDB(Song[] songs)
    {
        DAL dal = new DAL();
        try
        {
            for (int i = 0; i < songs.Length; i++)
            {
                if (!IsExist(songs[i]))
                {
                    string sql = string.Format("INSERT INTO tblSongs (songName, songLength, albumId) VALUES ('{0}',{1}, {2})", songs[i].Name, songs[i].SongLength, songs[i].AlbumId);
                    if (dal.ExecuteNonQueryToDb(sql))
                    {
                        sql = "SELECT MAX(songId) FROM tblSongs";
                        int aid = int.Parse(dal.ExecuteScalarToDb(sql).ToString());
                        songs[i].AlbumId = aid;
                    }
                    else
                    {
                        songs[i].AlbumId = -999;
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    } // הפעולה מכניסה כמה אלבומים אל תוך מסד הנתונים ומחזירה אמת אם הם נכנסו אחרת שקר 
    public bool IsExist(Song al)
    {
        string sql = string.Format("SELECT songName FROM tblSongs WHERE songName='{0}'", al.Name);
        DAL dal = new DAL();
        object o = dal.ExecuteScalarToDb(sql);
        if (o == null)
        {
            return false;
        }
        return true;
    } // הפעולה בודקת האם האלבום קיים במסד הנתונים

    public string GetSongNameWithID(int SongID)
    {
        string SongName = "";
        if (SongID != null)
        {
            string sql = string.Format("SELECT tblSongs.songName WHERE tblSongs.songId='{0}'", SongID);
            DAL dal = new DAL();
            SongName = (dal.GetDataSet(sql)).ToString();
            return SongName;
        }
        return SongName;
    } //הפעולה מקבלת קוד זיהוי קטגוריה ומחזירה את כל האלבומים 

}