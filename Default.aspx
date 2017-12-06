<%@ Page Title="" Language="C#" MasterPageFile="MyMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ShowProducts" %>

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
        .buy{
            position:center;
            align-self:center;
            text-align:center;
        }
        .table{
            position:center;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:PlaceHolder ID="ph" runat="server"></asp:PlaceHolder>
    <asp:Label ID="DescriptionLbl" runat="server" Text="Label"></asp:Label>
    <asp:PlaceHolder ID="Footer" runat="server"></asp:PlaceHolder>
    <center>
         <asp:Button ID="SubmitBtn" CssClass="btn-primary" runat="server" Text="Buy" OnClick="SubmitBtn_Click" />
    </center>
   
</asp:Content>

