using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;


/// <summary>
/// Summary description for Customer_Helper
/// </summary>
public class CustomerHelper
{
    private Customer c; //לקוח

    public CustomerHelper(Customer c)
	{
        this.c = c;
	} //פעולה בונה המקבלת לקוח

    public static bool IsExist(string email)
    {
        string sql = string.Format("SELECT fname FROM tblUsers WHERE email='{0}'", email);
        DAL dal = new DAL();
        object o = dal.ExecuteScalarToDb(sql);
        if ((o != null) && (!o.ToString().Equals("")))
            return true;
        return false;
    } //הפעולה מקבלת אימייל לקוח ובודקת האם הוא קיים במערכת מחזירה אמת אם כן אחרת שקר

    public bool InsertToDB()
    {
        if (!IsExist(this.c.Email))
        {
            string sql = string.Format("INSERT INTO tblUsers VALUES ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}')", this.c.Email, this.c.Fname, this.c.Lname, this.c.Password, this.c.Premission, this.c.DateJoined, this.c.LastOnline);
            DAL dal = new DAL();
            dal.ExecuteNonQueryToDb(sql);
            return true;
        }
        return false;
    } //הפעולה מכניסה את הלקוח אל מסד הנתונים

    public static Customer LoginCustomer(string email, string pass)
    {
        Customer c;
        if (email != null)
        {
            string sql = string.Format("SELECT password FROM tblUsers WHERE email='{0}'", email);
            DAL dal = new DAL();
            object o = dal.ExecuteScalarToDb(sql);
            string sql1 = string.Format("SELECT * FROM tblUsers WHERE email='{0}' AND password='{1}'", email, pass);
            if ((o != null) && (o.ToString().Equals(pass)))
            {
                OleDbDataReader dr = dal.ExecuteReaderToDb(sql1);
                c = new Customer();
                while (dr.Read())
                {
                    c.Email = dr["email"].ToString();
                    c.Fname = dr["fname"].ToString();
                    c.Lname = dr["lname"].ToString();
                    c.DateJoined = DateTime.Parse(dr["dateJoined"].ToString());
                    c.LastOnline = DateTime.Now;
                    c.Password = dr["password"].ToString();
                    c.Premission = int.Parse(dr["prem"].ToString());
                }
                string sql2 = string.Format("UPDATE tblUsers SET lastOnline='{0}' WHERE email='{1}'", c.LastOnline, c.Email);
                dal.ExecuteNonQueryToDb(sql2);
            }

            else
                c = null;
        }

        else
            c = null;

        return c;
    } //הפעולה מקבלת אימייל לקוח וסיסמא מעדכנת את הפעם האחרונה שבו היה מחובר ומחזירה את כל הפרטים על הלקוח

    public static DataSet GetCustomers()
    {

        string sql = "SELECT * FROM tblUsers ";
        DAL dal = new DAL();
        DataSet ds = dal.GetDataSet(sql);
        return ds;
    } //הפעולה מחזירה את כל הלקוחות

    public bool UpdateCustomer()
    {
        bool flag = false;
        try
        {
            string sql = string.Format("UPDATE tblUsers SET fname='{0}', lname='{1}', prem={2} WHERE email='{3}'", c.Fname, c.Lname, c.Premission, c.Email);
            DAL dal = new DAL();
            dal.ExecuteNonQueryToDb(sql);
            flag = true;
        }

        catch
        {
            flag = false;
        }
        return flag;
    } //הפעולה מעדכנת את הלקוח במסד הנתונים מחזירה אמת אם עודכן בהצלחה אחרת שקר

}

