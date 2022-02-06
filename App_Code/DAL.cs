using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

public class DAL
{
	public DAL()
	{   
        
	} //פעולה בונה ריקה

    private static string GetConnectionString()
    {
        string dbPath = HttpContext.Current.Server.MapPath("~/App_Data/SoM_db.accdb");
        string dbURL = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath;
        return dbURL;
    } //הפעולה מחזירה את נתיב מסד הנתונים

    public bool ExecuteNonQueryToDb(string sql)
    {
        OleDbConnection con = null;
        try
        {
            con = new OleDbConnection(GetConnectionString());
            OleDbCommand cmd = new OleDbCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        catch (Exception e)
        {
            return false;
        }

        finally { con.Close(); }
    } //הפעולה מקבלת שאילתה המכניסה ומעדכנת את מסד הנתונים מחזירה אמת אם התהליך הושלם בהצלחה אחרת שקר

    public object ExecuteScalarToDb(string sql)
    {
        OleDbConnection con = new OleDbConnection(GetConnectionString());
        OleDbCommand cmd = new OleDbCommand(sql, con);
        con.Open();
        object o = cmd.ExecuteScalar();
        con.Close();
        return o;
    } //הפעולה מקבלת שאילתה ומחזירה נתונים מתוך מסד הנתונים

    public OleDbDataReader ExecuteReaderToDb(string sql) 
    {
        OleDbConnection con = new OleDbConnection(GetConnectionString());
        OleDbCommand cmd = new OleDbCommand(sql, con);
        con.Open();
        OleDbDataReader dr;
        dr = cmd.ExecuteReader();
        return dr;
    } //בהתאם DataReader הפעולה מקבלת שאילתה ומחזירה

    public DataSet GetDataSet(string sql)
    {
        OleDbConnection con = new OleDbConnection(GetConnectionString());
        OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    } //בהתאם DataSet הפעולה מקבלת שאילתה ומחזירה טבלת

    public OleDbConnection GetConnection()
    {
        OleDbConnection con = new OleDbConnection(GetConnectionString());
        return con;
    } //הפעולה מחזירה את נתיב החיבור למסד הנתונים

}

