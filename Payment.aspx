<%@ Page Title="" Language="C#" MasterPageFile="MyMaster.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function IdValidation(src, arg) { // src is the element that the control is validating, arg has 2 properties, Value and IsValid.
            Sum = 0;
            Bikoret = arg.Value % 10;
            id = parseInt(arg.Value);
            while (id > 0) {
                Sum += id % 10;
                id = parseInt(id / 10);

            }
            Num = Sum % 7;
            if (Bikoret == Num) {
                arg.IsValid = true;
            }
            else {
                arg.IsValid = false;
            }
        }

        function validateLength(src, arg) { // src is the element that the control is validating, arg has 2 properties, Value and IsValid.
            if (arg.Value.length != 10) {
                arg.IsValid = false;
            }
        }


        function CreditValidation(src, arg) {
            if (arg.Value.length < 8 || arg.Value.length > 16) {
                arg.IsValid = false;
            }
        }


    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="payment">
        <h1>Payment</h1>
        Full Name  
           <br />
        <asp:TextBox CssClass="middle" ID="name" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="nameVLD" runat="server"
            ControlToValidate="name" ErrorMessage="Enter your name"></asp:RequiredFieldValidator>
        <br />

        Address
          <br />
        <asp:TextBox CssClass="middle" ID="address" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="addressVLD" runat="server"
            ControlToValidate="address" ErrorMessage="Enter your address"></asp:RequiredFieldValidator>
        <br />
        Email
          <br />
        <input type="email" class="middle" id="Email" runat="server" />
        <asp:RequiredFieldValidator ID="emailVLD" runat="server"
            ControlToValidate="Email" ErrorMessage="Please Enter your Email"></asp:RequiredFieldValidator>
        <br />
        Delivery Date
    <asp:Calendar CssClass="middle" ID="Date" runat="server"></asp:Calendar>
        <br />
        Payment Method: 
        <br />
    Credit Card <asp:RadioButton ID="CreditRD" runat="server" CssClass="middle" OnCheckedChanged="CreditRD_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
   
     Phone<asp:RadioButton ID="PhoneRD" runat="server" OnCheckedChanged="PhoneRD_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
<%--        <br />--%>
        <input type="number" id="Phone" runat="server" visible="false" />
        <%--<asp:TextBox CssClass="text" ID="Phone" runat="server" Visible="false">Phone (must be 10 digits)</asp:TextBox>--%>
        <asp:RequiredFieldValidator ID="PhoneMust" runat="server"
            ControlToValidate="Phone" ErrorMessage="You must enter phone number"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="phoneNumberVLD" runat="server"
            ControlToValidate="Phone" ErrorMessage="You must enter 10 digits" ClientValidationFunction="validateLength">
        </asp:CustomValidator>
        <asp:DropDownList ID="NumPays" runat="server" Visible="false">
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="3"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox CssClass="text" ID="CreditNum" runat="server" Visible="false">Credit Number</asp:TextBox>--%>
        <input type="number" class="text" id="CreditNum" runat="server" visible="false" />
        <asp:CustomValidator ID="CreditNumVLD" runat="server"
            ControlToValidate="CreditNum" ErrorMessage="Must be between 8-16 digits" ClientValidationFunction="CreditValidation"></asp:CustomValidator>
        <%--<asp:TextBox CssClass="text" ID="TextBox1" runat="server" Visible="false">ID</asp:TextBox>--%>
       <%-- <br />--%>
        <%--<input type="number" CssClass="text" ID="CustomerId" runat="server" Visible="false">ID</input>--%>
        <asp:TextBox CssClass="text" ID="CustomerId" runat="server" Visible="false">ID</asp:TextBox>
        <asp:CustomValidator ID="CustomerIdVLD" runat="server"
            ControlToValidate="CustomerId" ErrorMessage="ID is not valid!" ClientValidationFunction="IdValidation"></asp:CustomValidator><br />
        <asp:DropDownList ID="CreditKind" runat="server" Visible="false">
            <asp:ListItem Text="Visa" Value="visa"></asp:ListItem>
            <asp:ListItem Text="Master Card" Value="masterCard"></asp:ListItem>
            <asp:ListItem Text="American Express" Value="american"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="sigrequest" runat="server" Text="Enter Signature Image Please"></asp:Label>
        <br />
        <asp:FileUpload ID="signature" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="signature"  ErrorMessage="Enter signature image"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="pricelbl" runat="server" Text="Total Price:"></asp:Label>
        <br /> <br />
        <asp:Button ID="Confirm" runat="server"  Text="Confirm" OnClick="Confirm_Click" />
        <br /> <br />
        <asp:Label ID="end" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

