<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Inventory.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn 
        {
            background: rgba(146, 23, 151, 0.50);
            border: rgba(146, 23, 151, 0.50);
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h2><asp:Label ID="Label2" runat="server"></asp:Label></h2><br />

    <h1><b> Please enter a new Item </b>
        
    </h1><br />
    
       <div class="form-group">
  <label class="control-label" for="EnterName">Name</label>
  <input class="form-control" id="EnterName" type="text" runat="server"/>
</div>
    
     <div class="form-group">
  <label class="control-label" for="EnterCategory">Choose Category</label> <br />
  <asp:DropDownList ID="ddlCategory" CssClass="selectpicker" runat="server" DataTextField="Name" DataValueField="CategoryId" AppendDataBoundItems="True">
      
  </asp:DropDownList>
    
</div>

   


    <a href="Product1.aspx" class="btn  btn-primary btn-lg" runat="server" id="AddCategorybtn"  onserverclick="AddCategorybtn_ServerClick" style="background-color:#CD5C5C" >Add Category</a>



    <asp:Label ID="Label1" runat="server"></asp:Label>



</asp:Content>
