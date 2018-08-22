<%@ Page Language="VB" CodeFile="login.aspx.vb" Inherits="_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>

    <!-- meta -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport"       content="width=device-width, initial-scale=1.0"/>
    <meta name="description"    content="Spot The Ball"/>
    <meta name="keywords"       content="Spot the Ball "/>
    <meta name="author"         content="Tentacle Solutions"/>

    <!-- Site title -->
    <title>Spot The Ball Software</title>

    <!-- favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="#"/>

   
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700' rel='stylesheet' type='text/css'/>

    <link rel="stylesheet" href="css/new.css"/> <!-- Resource style -->


</head>

<body>
<form runat="server">
  

    <asp:TextBox ID="TB_Email" runat="server"></asp:TextBox>

    <asp:TextBox ID="TB_Password"  runat="server"></asp:TextBox>
 
    <asp:Label ID="LABEL_Login" runat="server" Text=""></asp:Label>

    <asp:Button ID="BUT_Login" runat="server" Text="Login" />



    <a href="#" >Forgot Password?</a>

    <div id="DIV_Reset_Password" >

 <asp:TextBox ID="TB_Email_Reset" runat="server"></asp:TextBox>
         <asp:Button ID="BUT_Reset" runat="server" Text="Reset" />
    </div>




</form>
    

</body>

</html>
