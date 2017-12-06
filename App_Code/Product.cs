using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }


    private string imagePath;

    public string ImagePath
    {
        get { return imagePath; }
        set { imagePath = value; }
    }


    private double price;

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    private int inventory;

    public int Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }

    string cat;
    string Description;
    double Tax = 1.17;
    public Category category = new Category();

    private Dictionary<string, string> attributes;

    public Dictionary<string, string> Attributes
    {
        get { return attributes; }
        set { attributes = value; }
    }


    public Product(int _categoryId, int _id, string _title, string _imagePath, double _price, int _inventory, Dictionary<string, string> _attr)
    {
        category.Id = _categoryId;
        Id = _id;
        Title = _title;
        ImagePath = _imagePath;
        Price = _price;
        Inventory = _inventory;
        Attributes = _attr;

    }

    public Product(string title, string desc,string _cat,double price)
    {
        Title = title;
         Description = desc;
         cat = _cat;
        Price = price*Tax;
    }

    public Product getProduct(int productId)
    {
        Product p = new Product();
        DBServices db = new DBServices();
        p= db.getProduct(p.Id);   //call the method getProduct from DBService
        return p;
    }
    public string GetInfo()
    {
        string lbl = "Product added " + Title + " priced " + Price + " NIS to category: " + cat + ", description: " + Description;
        return lbl;
    }

    public List<Product> GetProducts()
    {
        List<Product> l = new List<Product>();
        DBServices db = new DBServices();
        l = db.getList();
        return l;
    }
}