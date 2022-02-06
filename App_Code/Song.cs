using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Song
/// </summary>
public class Song
{
    private string name; 
    private int songSysId;
    private int albumId; 
    private string albumName; 
    private double songLength;

    public Song()
	{
	}

    public Song(string name, int albumId, double songLength, string albumName)
    {
        this.name = name;
        this.albumId = albumId;
        this.songLength = songLength;
        this.albumName = albumName;
    }

    public int SongId
    {
        get
        {
            return this.songSysId;
        }
        set
        {
            this.songSysId = value;
        }
    } //הפעולה מחזירה ומעדכנת קוד זיהוי אלבום

    public string AlbumName
    {
        get
        {
            return this.albumName;
        }

        set
        {
            this.albumName = value;
        }
    } //הפעולה מחזירה ומעדכנת את אמן האלבום

    public double SongLength
    {
        get
        {
            return this.songLength;
        }

        set
        {
            this.songLength = value;
        }
    } //הפעולה מחזירה ומעדכנת את אורך האלבום

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
}