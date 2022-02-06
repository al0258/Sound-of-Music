using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// The Customer class.
/// </summary>
public class Customer
{
    private string email; //אימייל לקוח
    private string password; //סיסמת לקוח
    private string fname; //שם פרטי לקוח
    private string lname; //שם משפחה לקוח
    private DateTime dateJoined; //תאריך הצטרפות לקוח
    private DateTime lastOnline; //תאריך אחרון שבו הלקוח היה פעיל
    private int premission = 1; //הרשאות של הלקוח

    public Customer()
    {

    } //פעולה בונה ריקה
    
    public DateTime DateJoined
    {
        get
        {
            return this.dateJoined;
        }

        set
        {
            this.dateJoined = value;
        }
    } //הפעולה מקבלת ומעדכנת את תאריך הצטרפות הלקוח

    public DateTime LastOnline
    {
        get
        {
            return this.lastOnline;
        }

        set
        {
            this.lastOnline = value;
        }
    } //הפעולה מקבלת ומעדכנת את הפעם האחרונה שבו הלקוח היה פעיל

    public string Password
    {
        get
        {
            return this.password;
        }

        set
        {
            this.password = value;
        }
    } //הפעולה מקבלת ומעדכנת את סיסמת הלקוח

    public string Email
    {
        get
        {
            return this.email;
        }

        set
        {
            this.email = value;
        }
    } //הפעולה מקבלת ומעדכנת את אימייל הלקוח

    public string Fname
    {
        get
        {
            return this.fname;
        }

        set
        {
            this.fname = value;
        }
    } //הפעולה מקבלת ומעדכנת את השם הפרטי של הלקוח

    public string Lname
    {
        get
        {
            return this.lname;
        }

        set
        {
            this.lname = value;
        }
    } //הפעולה מקבלת ומעדכנת את שם המשפחה של הלקוח

    public int Premission
    {
        get
        {
            return this.premission;
        }
        set
        {
            this.premission = value;
        }
    } //הפעולה מקבלת ומעדכנת את הרשאות הלקוח

}

