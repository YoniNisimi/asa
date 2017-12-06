using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{

    static double cartprice;
    List<Product> mycart;

    protected void Page_Load(object sender, EventArgs e)
    {    
        {
            Cookies();
            if (Session["cart"] != null)
            {
                mycart = (List<Product>)Session["cart"];
                int rowSize;
                if (mycart.Count % 5 == 0)
                {
                    rowSize = mycart.Count / 5;
                }
                else
                {
                    rowSize = mycart.Count / 5 + 1;
                }

                int index = 0;
                Table tbl = new Table();
                tbl.CssClass = "table";
                ph.Controls.Add(tbl);

                for (int i = 0; i < rowSize; i++)
                {
                    TableRow tr = new TableRow();
                    for (int j = 0; j < 5; j++)
                    {
                        TableCell tc = new TableCell();
                        index = i * 5 + j;
                        if (index < mycart.Count)
                        {
                            Image img = new Image();
                            img.ImageUrl = mycart[index].ImagePath;
                            tc.Controls.Add(img);

                            Label title = new Label();
                            title.Text = "</br> " + mycart[index].Title + " </br>";
                            tc.Controls.Add(title);

                            Label price = new Label();
                            price.Text = "Price: " + mycart[index].Price.ToString() + "</br>";
                            tc.Controls.Add(price);

                            CheckBox cb = new CheckBox();
                            cb.AutoPostBack = true;
                            cb.Checked = true;
                            cb.CheckedChanged += CheckBox_CheckedChanged;
                            cb.ID = index.ToString();
                            tc.Controls.Add(cb);
                        }
                        tr.Cells.Add(tc);
                    }
                    tbl.Rows.Add(tr);

                }
                if (!IsPostBack)
                {
                    cartprice = 0;
                    for (int i = 0; i < mycart.Count; i++)
                    {
                        cartprice += mycart[i].Price;
                    }
                }                
                totalprice.Text = "Total Price: " + cartprice.ToString();
                ViewState["dynamictable"] = true;
            }
        }

    }

    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is CheckBox)
        {
            CheckBox cb = (CheckBox)sender;
            int index = Int32.Parse(cb.ID);
            if (cb.Checked == true)
            {
                cartprice += mycart[index].Price;
            }
            else
            {
                cartprice -= mycart[index].Price;
            }
            totalprice.Text = "Total Price: " + cartprice.ToString();//display the finale price after checking/unchecking
            Welcome.Text = "Cart Changes Saved";
        }
    }

    protected void Direct_to_Payment(object sender, EventArgs e)
    {
        Session["cart"] = totalprice.Text;
        Response.Redirect("Payment.aspx?Name=");
    }

    protected void Cookies()
    {
       
        
        if (Request.Cookies["lastBuy"] == null)
        {
            Response.Cookies["lastBuy"].Value = DateTime.Now.ToString();
            Response.Cookies["lastBuy"].Expires = DateTime.Now.AddSeconds(20);
            Welcome.Text = "Hi, This is your first time here";
           
        }
        else
        {
            Welcome.Text = "Welcome Back";//ttt
        }
    }

}