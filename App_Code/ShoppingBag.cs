using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for ShoppingBag
/// </summary>
public class ShoppingBag
{
    private ArrayList AlbumsInCart; //מערך אלבומים בסל הקניות
    private Customer customer; //לקוח

	public ShoppingBag(Customer cust)
	{
        this.AlbumsInCart = new ArrayList();
        this.customer = cust;
	} //פעולה בונה המקבלת לקוח

    public ArrayList Products
    {
        get 
        {
            return AlbumsInCart;
        }

    } //פעולה שמחזירה מערך מוצרים

    public Customer CustId
    {
        get
        {
            return this.customer;
        }
        
    } //פעולה שמחזירה לקוח

    public int SearchProduct(int AlbumId)
    {
        for (int i = 0; i < AlbumsInCart.Count; i++)
        {
            if (((AlbumInCart)AlbumsInCart[i]).AlbumId == AlbumId)
                return i;

        }
        return -1;
    } //פעולה שמקבלת קוד זיהוי אלבום ומחזירה את קוד הזיהוי אם הוא קיים במערך האלבומים אחרת -1

    public void SearchAndDeleteProduct(int AlbumId)
    {
        for (int i = 0; i < AlbumsInCart.Count; i++)
        {
            if (((AlbumInCart)AlbumsInCart[i]).AlbumId == AlbumId)
                AlbumsInCart.RemoveAt(i);
        }
    } //פעולה שמקבלת קוד זיהוי אלבום ומוחקת את האלבום מתוך מערך האלבומים

    public void AddProduct(AlbumInCart cartItem)
    {
        int index = SearchProduct(cartItem.AlbumId);
        if (index == -1)
        {
            AlbumsInCart.Add(cartItem);

        }
    } //פעולה שמקבלת אלבום בסל ומוסיפה אותו אל מערך האלבומים

    public double GetFinalPrice()
    {
        double sum = 0;
        for (int i = 0; i < AlbumsInCart.Count; i++)
        {
            sum = sum + ((AlbumInCart)AlbumsInCart[i]).Price;
        }
        return sum; 
    } //פעולה שמחזירה את המחיר הכולל של הסל

    public bool IsEmpty()
    {
        bool flag = false;
        if (this.AlbumsInCart.Count == 0)
            flag = true;

        return flag;
    } //פעולה שבודקת האם סל הקניות ריק ומחזירה אמת אם כן אחרת שקר

    public int ItemsCount()
    {
        if (AlbumsInCart.Count != null)
        {
            return this.AlbumsInCart.Count;
        }
        return 0;
    } //פעולה שמחזירה את מספר האלבומים בסל הקניות

    public AlbumInCart GetProduct(int prodID)
    {
        AlbumInCart Aic = (AlbumInCart)this.AlbumsInCart[prodID];
        if (Aic != null)
            return Aic;
        return null;
    } //פעולה המקבלת קוד זיהוי מוצר ומחזירה את המוצר בסל

}

