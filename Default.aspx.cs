using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ShowProducts : System.Web.UI.Page
{

    Product p = new Product();
    List<Product> l = new List<Product>();
    Random rand = new Random();
    int ran;
    double discount;
    protected void Page_Load(object sender, EventArgs e)
    {
        DescriptionLbl.Text = "";
        GenerateList();
        //Cookies();
    }

    private void GenerateList()
    {
        int index = 0;
        l = p.GetProducts();
        

        Table tbl = new Table();
        tbl.CssClass = "table";
        Cookies();
        ph.Controls.Add(tbl);

        for (int i = 0; i < 10; i++)
        {

            TableRow tr = new TableRow();
            for (int j = 0; j < 5; j++)
            {


                TableCell tc = new TableCell();
                Image img = new Image();
                img.ImageUrl = l[index].ImagePath;
                tc.Controls.Add(img);


                Label title = new Label();
                title.Text = "</br> " + l[index].Title + " </br>";
                tc.Controls.Add(title);

                Label price = new Label();
                if (index==ran)
                {                   
                    price.Text = "Sale Price: " + (l[index].Price*discount).ToString() + "</br>";
                }
                else
                {
                    price.Text = "Price: " + l[index].Price.ToString() + "</br>";
                }
               
                tc.Controls.Add(price);

                Label inventory = new Label();
                inventory.Text = "Inventory: " + l[index].Inventory.ToString() + "</br>";
                tc.Controls.Add(inventory);

                if (l[index].Inventory > 0)
                {
                    CheckBox cb = new CheckBox();
                    cb.ID = "cb" + index.ToString();
                    tc.Controls.Add(cb);
                }
                else
                {
                    CheckBox cb = new CheckBox();
                    cb.ID = "cb" + index.ToString();
                    cb.Enabled = false;
                    tc.Controls.Add(cb);
                }
                tr.Cells.Add(tc);
                index++;

            }

            tbl.Rows.Add(tr);
        }
        ViewState["dynamictable"] = true;
    }


    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        SubmitBtn.Enabled = false;
        List<Product> ItemList = new List<Product>();
        for (int i = 0; i < l.Count; i++)
        {
            CheckBox cbx = (CheckBox)ph.FindControl("cb" + i.ToString());
            if (cbx != null)
            {
                if (cbx.Checked == true)
                {
                    ItemList.Add(l[i]);

                }
            }
        }

        Session["cart"] = ItemList;
        
        ph.Controls.Clear();

        Response.Redirect("Cart.aspx");

    }

    protected void Cookies()
    {
        var d = new HtmlGenericControl("div");
        d.ID = "offer";
        double offer;
        if (Request.Cookies["lastVisit"]==null )
        {
            discount = 0.5;
            Response.Cookies["lastVisit"].Value = DateTime.Now.ToString();
            Response.Cookies["lastVisit"].Expires = DateTime.Now.AddSeconds(20);
            //Response.Write("Welcome new guest  </br>");
            //Response.Write("Here is a special offer for you  </br>");
            ran = rand.Next(0, 50);
            double specialoffer = l[ran].Price;
            //Response.Write(" A chair for9 a dining area only for:" + specialoffer * newcust);
            
            
            offer = specialoffer * discount;
            d.InnerHtml = "<h4>Welcome new guest  </h4></br><h4> Here is a special offer for you </h4> </br> <h4>" + l[ran].Title + " only for:" + offer + "</h4>" ;
            ph.Controls.Add(d);

        }
        else  
        {
            discount = 0.8;
            string guest = Request.Cookies["lastVisit"].Value;
            //Response.Write("your last visit was " + guest + " </br>");
            //Response.Write("Welcome back guest  </br>");
            //Response.Write("Here is a special offer for you  </br>");
            ran = rand.Next(0, 50);
            double specialoffer = l[ran].Price;
            //Response.Write(" A chair for a dining area only for:" + specialoffer * oldcust);

            offer = specialoffer * discount;
            d.InnerHtml = "<h4>Welcome back guest</h4>  </br> <h4>Here is a special offer for you</h4>  </br> <h4> "+l[ran].Title+" only for:" + offer+"</h4>";
            ph.Controls.Add(d);
        }
    }

}