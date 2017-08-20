<%@ Page Title="" Language="C#" MasterPageFile="~/InventoryMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseVoucher.aspx.cs" Inherits="InventorySystem.PurchaseVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="http://localhost:64314/code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
			<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/jquery-ui.min.js" type="text/javascript"></script>


   <script type="text/javascript">
       $(function () {




           $("#<%= txtFoo.ClientID  %>").datepicker();




        });
    </script>
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
     
        <form class="form-horizontal">
  
    
    <div class="form-group">
      <label for="inputNumber" class="col-lg-2 control-label">Number</label>
      <div class="col-lg-10">
        <input type="text" class="form-control" id="inputNumber" value=""  maxlength="16" size="16" runat="server"/>
      </div>
    </div>
    <div class="form-group" >
      <label for="inputDate" class="col-lg-2 control-label" >Date</label>
      <div class="col-lg-10" >
         <div class="input-group">
    
             <input runat="server" class="form-control" type="text"   id="txtFoo" />
    <label class="input-group-addon btn" for="date"  >
       <span class="fa fa-calendar open-datetimepicker"></span>
    </label>
</div>
        
    
    
  

     
       
            
   
     
     
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          
            
              <asp:GridView ID="GridView2"  BackColor="White" EmptyDataText="no valyue" AutoGenerateColumns="false" ShowFooter="true"  AllowPaging="true" ShowHeaderWhenEmpty="true" OnRowDataBound="GridView2_RowDataBound" runat="server" Width="780px">
               
                        <FooterStyle BackColor="#6B696B" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                
                
                <Columns>
                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                                <HeaderTemplate>
                                    Title</HeaderTemplate>
                                <ItemTemplate>
                                  <asp:Label ID="lblTitle" runat="server" Text='<%#Bind("Title") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlTitle" runat="server" Width="80px" DataTextField="Title" DataValueField="ProductId" AutoPostBack="True" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged"></asp:DropDownList>
                                </ItemTemplate>
                                <EditItemTemplate>
                                   <asp:DropDownList ID="ddlTitle"  runat="server" DataTextField="Title" DataValueField="ProductId" Width="80px"></asp:DropDownList>
                                    
                                </EditItemTemplate>
                    <InsertItemTemplate></InsertItemTemplate>
                    <FooterTemplate><asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click"  CommandName="Footer"  /></FooterTemplate> 
                    
                            </asp:TemplateField>

                <asp:TemplateField HeaderText="Price" SortExpression="Price">
                                <HeaderTemplate>
                                    Price</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%#Bind("Price") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPrice" Text='<%#Bind("Price") %>' runat="server" Width="80px"></asp:TextBox>
                                    
                                </EditItemTemplate>
                   
                            </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                <HeaderTemplate>
                                    Quantity</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQuantity" Text='<%#Bind("Quantity") %>' OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true" runat="server" Width="80px"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtQuantity" Text='<%#Bind("Quantity") %>' runat="server" Width="80px"></asp:TextBox>
                                    
                                </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="total" runat="server" Text="Total Price :"></asp:Label></FooterTemplate>
                            </asp:TemplateField>
                     <asp:TemplateField HeaderText="TotalPrice" SortExpression="Total">
                                <HeaderTemplate>
                                    Total</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTotalPrice" Text='<%#Bind("TotalPrice") %>' runat="server" Width="80px"></asp:TextBox>
                                    
                                </EditItemTemplate>
                    <FooterTemplate> <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Bind("TotalPrice") %>'></asp:Label></FooterTemplate>
                            </asp:TemplateField>




                </Columns>
                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
      </div>

        </form>
</asp:Content>
