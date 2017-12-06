<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        div {
            position: relative;
        }

        .products {
            float: left;
            text-align: center;
            width: 300px;
            height: 300px;
        }

        img {
            height: 150px;
            width: 200px;
        }

        .footer {
            bottom: 0px;
            margin-bottom: 0px;
        }

        .buy {
            position: center;
            align-self: center;
            text-align: center;
        }

        .table {
            position: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:PlaceHolder ID="ph" runat="server"></asp:PlaceHolder>
    <asp:Label ID="Welcome" runat="server" Text=""></asp:Label>
        <br />      <br />
      <asp:Label ID="totalprice" runat="server" Text="Total Price: "></asp:Label>
    <center>    
<asp:Button ID="confirm"  OnClick= "Direct_to_Payment"  CssClass="btn-primary" runat="server" text="Confirm"></asp:Button>
    </center>
</asp:Content>



