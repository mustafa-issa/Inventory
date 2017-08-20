<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventorySystem.Login" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bootstrap 101 Template</title>

    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

      <style type="text/css">
          h1 {
              text-align:center;
              color:white;

          }
          body {
              background:rgb(215, 187, 219);
          }
          .form-control {
              border-radius:5px;
              background-color:white;
              color:#350531;
          }
          .btn {
              border-radius: 5px;
              background: rgba(146, 23, 151, 0.50);
              color: white;
              width: 100%;
          }
          form {
              background: rgba(236,236,236,0.98);
              padding: 100px;
              border-radius: 5px;
              box-shadow: 0 0px 12px rgba(0,0,0,.74);
          }

      </style>
<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
  <body><br />
    <h1>Please Login</h1><br />
      <div class="container">
          <div class="row">
              <div class="col-md-offset-3 col-md-6">
                  <form id="form1" runat="server">
  <div class="form-group">
    
    <input type="search" runat="server" class="form-control" id="exampleInputUN1" placeholder="User Name" >
  </div>
  <div class="form-group">
    
    <input type="password" runat="server" class="form-control" id="exampleInputPassword1" placeholder="Password">
  </div>
  
  
  <asp:Button ID="lginbtn" runat="server" type="submit" Text="Login" class="btn btn-default" OnClick="lginbtn_Click" />
                      
                      <asp:Label  ID="Label1" runat="server" style="text-align: center"></asp:Label>
                      
                  </form>
              </div>
          </div>
      </div>
      
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
  </body>
</html>
