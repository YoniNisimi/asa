using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cart"] != null)
        {
            string str=(string)Session["cart"];
            pricelbl.Text = str;
        }
    }

    protected void CreditRD_CheckedChanged(object sender, EventArgs e)
    {
        PhoneRD.Checked = false;
        Phone.Visible = false;
        NumPays.Visible = true;
        CreditNum.Visible = true;
        CustomerId.Visible = true;
        CreditKind.Visible = true;
    }

    protected void PhoneRD_CheckedChanged(object sender, EventArgs e)
    {
        CreditRD.Checked = false;
        Phone.Visible = true;
        NumPays.Visible = false;
        CreditNum.Visible = false;
        CustomerId.Visible = false;
        CreditKind.Visible = false;

    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        end.Text = "<h2>  Order Completed, Thank you  </h2>";
    }

    }