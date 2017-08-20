<%@ Page Title="" Language="C#" MasterPageFile="~/InventoryMaster.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="InventorySystem.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $('#<%=GridView1.ClientID %> .txtQty').blur(function () {
            var $tr = $(this).parents('tr');
            if ($tr.length > 0) {
                if (parseInt($tr.find('.avlQty').html()) < $(this).val()) {
                    alert('Qty must not exceed available quantity.');
                    var $ctrl = $(this);
                    window.setTimeout(function () {
                        $ctrl.focus();
                    }, 50);
                    return false;
                }
                $tr.find('.totalPrice').html(parseFloat($tr.find('.price').html()) * parseInt($(this).val()));
            }
            CalculateGrandTotal();
        });
        //To get grand Total
        function CalculateGrandTotal() {
            var grandTotal = 0.0;
            $('#<%=GridView1.ClientID %> tr:gt(0)').each(function () {
        grandTotal = grandTotal + parseFloat($(this).find('.totalPrice').length == 0 || !$(this).find('.totalPrice').html() ? 0 : $(this).find('.totalPrice').html());
    });
    $('#<%=GridView1.ClientID %> .grandtotal').html(grandTotal);
}
    </script>
    <script>
        $('#<%=GridView1.ClientID %> .txtQty').keydown(function (event) {
            // Allow: backspace, delete, tab, escape, and enter
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                // Allow: Ctrl+A
        (event.keyCode == 65 && event.ctrlKey === true) ||
                // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39)) {
                // let it happen, don't do anything
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true" >
        <Columns>
            
            <asp:BoundField DataField="Title" HeaderText="Name" />
            
            
            <asp:TemplateField HeaderText="Qty">
                <ItemTemplate>                
                    <asp:TextBox ID="TextBoxQty" CssClass="txtQty" runat="server" Text='<%# Eval("Quantity") %>' MaxLength="5" Width="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxQty" Display="Dynamic" ForeColor="Red" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Price" DataFormatString="{0:0.00}" ItemStyle-CssClass="price"
                HeaderText="Price" />

            <asp:TemplateField HeaderText="Net Price">
                <ItemTemplate>
                    <span class="totalPrice"></span> 
                </ItemTemplate>
                <FooterTemplate>
                   Total: <span class="grandtotal"></span> 
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>        
    </asp:GridView>

</asp:Content>
