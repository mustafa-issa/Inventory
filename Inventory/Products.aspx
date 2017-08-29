<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Inventory.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        window.history.forward(0);
        function noBack() {
            window.history.forward();
        }
        function trim(id) {
            if (id != null)
                id.value = id.value.toString().replace(/^\s+|\s+$/g, "");
        }
    </script>
    <style type="text/css">
        .auto-style2 {
            color: #6B696B;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="auto-style2">
        <asp:Label ID="Label1" runat="server"></asp:Label></h2>
    <h1>Products
        
    </h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>   
             <div class="container">
          <div class="row">
              <div class="col-md-6" > 
            <asp:GridView ID="GridView1" BackColor="White" BorderColor="#DEDFDE"  OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false" ShowFooter="true" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="true" OnSorting="GridView1_Sorting" PageSize="10" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" runat="server" class="table-responsive" >
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            ID
                        </HeaderTemplate>

                        <ItemTemplate>
                            <asp:Label ID="lblProductID" runat="server" Text='<%#Bind("ProductId") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductID" Text='<%#Bind("ProductId") %>' runat="server" Width="20px"
                                Enabled="False"></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <h4><i>INSERT NEW RECORD </i></h4>
                        </FooterTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <HeaderTemplate>
                            Title
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server" Text='<%#Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTitle" Text='<%#Bind("Title") %>' runat="server" Width="80px"></asp:TextBox>

                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox></FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Description" SortExpression="Description">
                        <HeaderTemplate>
                            Description
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDesc" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDesc" Text='<%#Bind("Description") %>' runat="server" Width="80px"></asp:TextBox>

                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox></FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price" SortExpression="Price">
                        <HeaderTemplate>
                            Price
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%#Bind("Price") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrice" Text='<%#Bind("Price") %>' runat="server" Width="100px"></asp:TextBox>

                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox></FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                        <HeaderTemplate>
                            Quantity
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQuantity" Text='<%#Bind("Quantity") %>' runat="server" Width="30px"></asp:TextBox>

                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox></FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                        <HeaderTemplate>
                            Status
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStatus" Text='<%#Bind("Status") %>' runat="server" Width="30px"></asp:TextBox>

                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="TextBox5"></asp:TextBox></FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <HeaderTemplate>
                            Category
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCategory" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList CssClass="selectpicker" ID="ddlCategory" runat="server" DataTextField="Name" DataValueField="CategoryId"></asp:DropDownList>

                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList CssClass="selectpicker" ID="DropDownList1" runat="server" DataTextField="Name" DataValueField="CategoryId"></asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            Command Button
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CausesValidation="true"
                                OnClientClick="return confirm('Are you sure?')" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" OnClientClick="return confirm('row updated')" />
                            <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" OnClientClick="return confirm('Are You Sure you want to cancel editing?')" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Button runat="server" ID="btnSave" Text="ADD NEW PRODUCT" OnClick="btnSave_Click" CommandName="Footer" /></FooterTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
                  
              </div>
          </div>
      </div>
               
        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
