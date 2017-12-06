<%@ Page Title="" Language="C#" MasterPageFile="MyMaster.master" AutoEventWireup="true" CodeFile="InsertNewProduct.aspx.cs" Inherits="InsertNewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function PriceVld(src, arg) {

            if (isNaN(arg.Value)) {
                arg.IsValid = false;
            }

        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="middle">
        <h1>Insert New Product</h1>
        <asp:TextBox CssClass="text" ID="pname" runat="server">Product Name</asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="pnvalidator" runat="server" ControlToValidate="pname" ErrorMessage="Enter product name"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox CssClass="text" ID="pprice" runat="server">Price</asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="ppricevaldiator" runat="server" ControlToValidate="pprice" ErrorMessage="Enter product price"></asp:RequiredFieldValidator>
         <asp:CustomValidator ID="PriceVLD" runat="server"
            ControlToValidate="pprice" ErrorMessage="Insert Numbers Only!" ClientValidationFunction="PriceVld"></asp:CustomValidator>
        <br />
        <asp:DropDownList CssClass="text" ID="categories" runat="server">
            <asp:ListItem Text="TV's" Value="TV's"></asp:ListItem>
            <asp:ListItem Text="Home Teather" Value="Home Teather"></asp:ListItem>
            <asp:ListItem Text="Washing Machines" Value="Washing Machines"></asp:ListItem>
            <asp:ListItem Text="Computers" Value="Computers"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:TextBox CssClass="text" ID="pdesc" runat="server">Description</asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="pdescvaldiator" runat="server" ControlToValidate="pdesc"  ErrorMessage="Enter product description"></asp:RequiredFieldValidator>
        <%-- <textarea id="ddd"></textarea>
        <textarea id="pdesc" cols="20" rows="2">תיאור המוצר</textarea>--%>
        <br />
        <br />
        <asp:Button CssClass="btn-primary" ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
        <br />
        <br />
        <asp:Label ID="outputLBL" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>



