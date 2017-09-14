<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobsPizza.Default" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Papa Bob's Pizza</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="page-header">
                <h1>Papa Bob's Pizza</h1>
                <p class="lead">Pizza to Code by</p>
            </div>

            <div class="form-group">
                <label>Size:</label>
                <asp:DropDownList ID="pizzaSizeDropDownList" runat="server" OnSelectedIndexChanged="RecalculateTotalCost" AutoPostBack="true" CssClass="form-control">
                    <asp:ListItem Text="Choose a pizza size..." Value="" Selected="True" />
                    <asp:ListItem Text="Small (12 inch - $12)" Value="Small"/>
                    <asp:ListItem Text="Medium (14 inch - $14)" Value="Medium"/>
                    <asp:ListItem Text="Small (16 inch - $16)" Value="Large"/>
                </asp:DropDownList>                
            </div>

            <div class="form-group">
                <label>Crust:</label>
                <asp:DropDownList ID="crustTypeDropDownList" runat="server" OnSelectedIndexChanged="RecalculateTotalCost" AutoPostBack="true" CssClass="form-control">
                    <asp:ListItem Text="Choose a crust type..." Value="" Selected="true" />
                    <asp:ListItem Text="Regular" Value="Regular"/>
                    <asp:ListItem Text="Thin" Value="Thin"/>
                    <asp:ListItem Text="Thick (+ $2)" Value="Thick"/>
                </asp:DropDownList>
            </div>

            <div class="checkbox"><label><asp:CheckBox  ID="sausageCheckBox"  OnCheckedChanged="RecalculateTotalCost" AutoPostBack="true" runat="server"  />Sausage (+ $2)</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="pepperoniCheckBox"  OnCheckedChanged="RecalculateTotalCost" AutoPostBack="true" runat="server" />Pepperoni (+ $1.50)</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="onionsCheckBox"  OnCheckedChanged="RecalculateTotalCost" AutoPostBack="true" runat="server" />Onions (+ $1)</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="greenPeppersCheckBox"  OnCheckedChanged="RecalculateTotalCost" AutoPostBack="true" runat="server" />Green Peppers(+ $1)</label></div>

            <h3>Deliver To:</h3>

            <div class="form-group">
                <label>Name:</label>
                <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Address:</label>
                <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Zip:</label>
                <asp:TextBox ID="zipTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Phone:</label>
                <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <h3>Payment:</h3>
            
            <div class="radio"><label><asp:RadioButton ID="cashRadioButton" GroupName="PaymentGroup" runat="server" />Cash:</label></div>
            <div class="radio"><label><asp:RadioButton ID="creditRadioButton" GroupName="PaymentGroup" runat="server" />Credit:</label></div>

            <asp:Button ID="orderButton" Text="Order" OnClick="OnClick_orderButton" runat="server" CssClass="btn btn-lg btn-primary" />
            <br />
            <br />

            <asp:Label ID="inputValidationLabel" runat="server" CssClass="bg-danger"/>

            <h3>Total Cost: <asp:Label ID="totalCostLabel" runat="server"/></h3>
            

        </div>
    </form>

    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    
</body>
</html>
