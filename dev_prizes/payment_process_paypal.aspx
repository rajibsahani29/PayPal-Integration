<%@ Page Language="VB" AutoEventWireup="false" CodeFile="payment_process_paypal.aspx.vb" Inherits="payment_process_paypal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox id="txtPaymentAmount" runat="server" ReadOnly="true" />
        <asp:Button ID="BUT_PayNow" runat="server" class="button btn-smaller" Text="Pay Now" /><br /><br />
        <asp:Button ID="BUT_Back" runat="server" class="button btn-smaller" Text="Back to Buy Credits Page" PostBackUrl="~/purchasecredits.aspx" />
    </div>
    </form>
</body>
</html>
