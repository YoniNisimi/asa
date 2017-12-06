using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InsertNewProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Product p = new Product(pname.Text, pdesc.Text, categories.SelectedValue, double.Parse(pprice.Text));
        outputLBL.Text = p.GetInfo();
    }
}