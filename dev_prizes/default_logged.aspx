<%@ Page Language="VB" CodeFile="default_logged.aspx.vb" Inherits="_default_logged" %>

<!DOCTYPE html>
<html data-site="Reve House">
<head>
  <meta charset="utf-8">
  <title>Reve House</title>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <script src="js/pace.min.js"></script>
  <link href="css/pace.css" rel="stylesheet" />
  <link rel="stylesheet" type="text/css" href="css/normalize.css">
  <link rel="stylesheet" type="text/css" href="css/default.css">
  <link rel="stylesheet" type="text/css" href="css/style.css">
  <link rel="stylesheet" type="text/css" href="" id="templateColor">
  <link rel="stylesheet" type="text/css" href="css/owl.carousel.css">
  <link rel="stylesheet" type="text/css" href="css/owl.theme.css">
  <link rel="stylesheet" type="text/css" href="css/owl.transitions.css">
  <link rel="stylesheet" href="css/ionicons.css">
    <link href="css/ionicons2.css" rel="stylesheet" />
    <link href="css/new.css" rel="stylesheet" />
  
        <script>
            (function () {
                var wf = document.createElement('script');
                wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
                    '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
                wf.type = 'text/javascript';
                wf.async = 'true';
                var s = document.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(wf, s);
            })();</script>
    
    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.6.26/webfont.js"></script>
<script>
    WebFont.load({
        google: {
            families: ["Montserrat:400,700", "Merriweather:300,400,700,900", "Muli:300,300italic,regular,italic"]
        }
    });
</script>
    
  
<link rel="apple-touch-icon" sizes="57x57" href="images/apple-icon-57x57.png">
<link rel="apple-touch-icon" sizes="60x60" href="images/apple-icon-60x60.png">
<link rel="apple-touch-icon" sizes="72x72" href="images/apple-icon-72x72.png">
<link rel="apple-touch-icon" sizes="76x76" href="images/apple-icon-76x76.png">
<link rel="apple-touch-icon" sizes="114x114" href="images/apple-icon-114x114.png">
<link rel="apple-touch-icon" sizes="120x120" href="images/apple-icon-120x120.png">
<link rel="apple-touch-icon" sizes="144x144" href="images/apple-icon-144x144.png">
<link rel="apple-touch-icon" sizes="152x152" href="images/apple-icon-152x152.png">
<link rel="apple-touch-icon" sizes="180x180" href="images/apple-icon-180x180.png">
<link rel="icon" type="image/png" sizes="192x192"  href="images/android-icon-192x192.png">
<link rel="icon" type="image/png" sizes="32x32" href="images/favicon-32x32.png">
<link rel="icon" type="image/png" sizes="96x96" href="images/favicon-96x96.png">
<link rel="icon" type="image/png" sizes="16x16" href="images/favicon-16x16.png">
<link rel="manifest" href="images/manifest.json">
<meta name="msapplication-TileColor" content="#ffffff">
<meta name="msapplication-TileImage" content="images/ms-icon-144x144.png">
<meta name="theme-color" content="#ffffff">

  <script type="text/javascript" src="js/modernizr.js"></script>
  <link rel="shortcut icon" type="image/x-icon" href="#">


</head>

<body>
    <form runat="server">


      <div class="nav"  data-collapse="small" data-animation="over-right" data-duration="400" data-contain="1" data-animate="hidden4" >

    <div class="container" >
      <a class="nav-brand logo-contain" href="index.aspx">
      </a> 
        <div class="nav-login">
 <h5 style="color:#000;font-weight: 300;font-family: Montserrat, sans-serif;">Welcome&nbsp; <asp:Label ID="LABEL_Master1" runat="server" Text="Label"></asp:Label></h5><asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
 <h5 style="color:#000;font-weight: 300;padding-top:0px;font-family: Montserrat, sans-serif;">You have&nbsp;
            <asp:Label ID="LABEL_Master2" runat="server" Text="Label"></asp:Label>
       &nbsp;Credits</h5> </ContentTemplate>
    </asp:UpdatePanel>
        </div>

      <nav class="nav-menu menu-open" role="navigation" >
        
      <a class="nav-link" href="index.aspx">Home</a>
         <a class="nav-link" href="playgame.aspx">Play Game</a>
          
        <a class="nav-link" href="purchasecredits.aspx">Buy Credits</a>


          <div class="dropdown" >
<button class="dropbtn">My Account</button>
  <div class="dropdown-content">
    <a href="edit_details.aspx">Edit Details</a>
    <a href="change_password.aspx">Change Password</a>
    <a href="play_history.aspx">Play History</a>
      <a href="transaction_history.aspx">Transaction History</a>
  </div>
</div>


         
      
        <a class="nav-link" href="#contact" style="padding-right:35px;">Contact</a>
        
           <ul class="social" >
              <li>
                    <asp:Button ID="BUT_Logout" runat="server" class="button btn-smaller" Style="text-align:center" Text="Logout" />
              </li>
             
            </ul>
      </nav>
     
        


        <div id="please_verify" style="border:2px solid black;width:50%">


            You haven't verified your email address yet
            <br /><br />
Please verify your email address in our confirmation email.
                 <br /><br />
                  <asp:Label ID="LABEL_verification" runat="server" Text=""></asp:Label>
                  <br />
                  <asp:Button ID="BUT_resend_verification" runat="server" Text="Resend Verification Email" />
             <br /><br />
                 <a href="edit_details.aspx" class="btn">Change Email</a>
        </div>
   
    </div>
</div>

  <script type="text/javascript" src="js/jquery.min.js"></script>
  <script type="text/javascript" src="js/jquery.stellar.js"></script>
  <script type="text/javascript" src="js/main.js"></script>
  <script type="text/javascript" src="js/owl.carousel.js"></script>
  
  <!--[if lte IE 9]><script src="https://cdnjs.cloudflare.com/ajax/libs/placeholders/3.0.2/placeholders.min.js"></script><![endif]-->
        </form>


</body>
</html>