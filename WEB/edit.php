<?php
	
	ob_start();
	session_start();
	require_once 'dbconnect.php';
	
	// if session is not set this will redirect to login page
	if( !isset($_SESSION['user']) ) {
		header("Location: index.php");
		exit;
	}
	
	$id=$_GET['id'];
	
	// select loggedin users detail
	$res=mysql_query("SELECT * from despesas, veiculos, fornecedores, utilizador, tipodesp WHERE CodDesp='$id' and Efetuada='Nao' and despesas.codVei=veiculos.codVei AND despesas.codForn=fornecedores.CodForn and despesas.CodUser=utilizador.CodUser and despesas.CodTipoD=tipodesp.CodTipoD");
	$userRow=mysql_fetch_array($res);
	
?>
<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Início</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="jquery.touchSwipe.min.js"></script>
	<link rel="stylesheet" href="style.css" type="text/css" />
	
      
    
    <style type="text/css">
			body, html {
          height: 100%;
          margin: 0;
          overflow:hidden;
          font-family: helvetica;
          font-weight: 100;
      }
      .container {
          position: relative;
          height: 100%;
          width: 100%;
          left: 0;
          -webkit-transition:  left 0.4s ease-in-out;
          -moz-transition:  left 0.4s ease-in-out;
          -ms-transition:  left 0.4s ease-in-out;
          -o-transition:  left 0.4s ease-in-out;
          transition:  left 0.4s ease-in-out;
      }
      .container.open-sidebar {
          left: 240px;
      }
      
      .swipe-area {
          position: absolute;
          width: 50px;
          left: 0;
      top: 0;
          height: 100%;
          background: #f3f3f3;
          z-index: 0;
      }
      #sidebar {
          background: #DF314D;
          position: absolute;
          width: 240px;
          height: 100%;
          left: -240px;
          box-sizing: border-box;
          -moz-box-sizing: border-box;
      }
      #sidebar ul {
          margin: 0;
          padding: 0;
          list-style: none;
      }
      #sidebar ul li {
          margin: 0;
      }
      #sidebar ul li a {
          padding: 15px 20px;
          font-size: 16px;
          font-weight: 100;
          color: white;
          text-decoration: none;
          display: block;
          border-bottom: 1px solid #C9223D;
          -webkit-transition:  background 0.3s ease-in-out;
          -moz-transition:  background 0.3s ease-in-out;
          -ms-transition:  background 0.3s ease-in-out;
          -o-transition:  background 0.3s ease-in-out;
          transition:  background 0.3s ease-in-out;
      }
      #sidebar ul li:hover a {
          background: #C9223D;
      }
      .main-content {
          width: 100%;
          height: 100%;
          padding: 10px;
          box-sizing: border-box;
          -moz-box-sizing: border-box;
          position: relative;
      }
      .main-content .content{
          box-sizing: border-box;
          -moz-box-sizing: border-box;
      padding-left: 60px;
      width: 100%;
      }
      .main-content .content h1{
          font-weight: 400;
      }
      .main-content .content p{
          width: 100%;
          line-height: 160%;
      }
      .main-content #sidebar-toggle {
          background: #545353;
          border-radius: 3px;
          display: block;
          position: relative;
          padding: 10px 7px;
          float: left;
      }
      .main-content #sidebar-toggle .bar{
           display: block;
          width: 18px;
          margin-bottom: 3px;
          height: 2px;
          background-color: #fff;
          border-radius: 1px;   
      }
      .main-content #sidebar-toggle .bar:last-child{
           margin-bottom: 0;   
      }
	  
	button.accordion {
	background: #FFF url(logos/serv.png) no-repeat 1px ;
	margin-bottom: 5px;
    background-color: #eee;
    color: white;
    cursor: pointer;
    padding: 0.8%;
    width: 100%;
    border: none;
    text-align: left;
    outline: none;
    font-size: 15px;
    transition: 0.4s;
}

button.accordion.active, button.accordion:hover {
    background-color: #ddd;
}

button.accordion:after {
    content: '\002B';
    color: #777;
    font-weight: bold;
    float: right;
    margin-left: 5px;
}

button.accordion.active:after {
    content: "\2212";
}

div.panel {
    padding: 12px 0px 0 0px;
    background-color: white;
    max-height: 0;
    overflow: hidden;
    transition: max-height 0.2s ease-out;
}

ul.tab li a:focus, .active {
        color: #000000 !important;
}

input, select {
    width: 100%;
}

tr:hover {background-color: white}

.search_categories{
font-family: "Raleway";
    font-size: 14px;
    padding: 10px 10px 9px 14px;
    background: #fff;
        border: none;
    overflow: hidden;
    position: relative;
}

.search_categories .select{
    background:transparent;
      border:0;
  width: 120%;
  background:url('arrow.png') no-repeat;
  background-position:80% center;
}

.search_categories .select select{

  background: transparent;
  line-height: 1;
  border:none !important;
  padding: 0;
  border-radius: 0;
  width: 120%;
  position: relative;
  z-index: 10;
  font-size: 1em;
}

input[type=date] {
font-family: "Raleway";
font-size: 14px;
border: none;
 outline: none;
padding: 9px 0 3px 17px;
}

input[type=text] {
font-family: "Raleway";
border: none;
margin: 3px 20px 17px;
color: black;
padding: 8px 0px 0px 0px;
border: none;
font: 400 14px 'Cabin', sans-serif;
    background: #FFF;
	    max-width: 100%;

}
	  
	  
    </style>
    <script type="text/javascript">
      $(window).load(function(){
        $("[data-toggle]").click(function() {
          var toggle_el = $(this).data("toggle");
          $(toggle_el).toggleClass("open-sidebar");
        });
         $(".swipe-area").swipe({
              swipeStatus:function(event, phase, direction, distance, duration, fingers)
                  {
                      if (phase=="move" && direction =="right") {
                           $(".container").addClass("open-sidebar");
                           return false;
                      }
                      if (phase=="move" && direction =="left") {
                           $(".container").removeClass("open-sidebar");
                           return false;
                      }
                  }
          }); 
      });
      
    </script>
  </head>
  <body>
  
  <body>
	<?php
	include('dbconnect.php');
	if(isset($_GET['id']))
	{
	$id=$_GET['id'];
	if(isset($_POST['submit']))
	{
	$date=$_POST['date'];
	$query3=mysql_query("update despesas set Data_Efetuada='$date', Data_Agendada='$date' where CodDesp='$id'");
	header("Location: demo5.php");
	if($query3)
	{
	
	}
	}
	$query1=mysql_query("select * from despesas where CodDesp='$id'");
	$query2=mysql_fetch_array($query1);
	?>
    <div class="container">
      <div id="sidebar">
		<center><img src="https://image.flaticon.com/icons/svg/265/265729.svg"></center>
          <ul>
                 <li><a href="demo3.php">Início</a></li>
              <li><a href="demo5.php">Serviços</a></li>
			  <li><a href="demo2.php">Perfil</a></li>
			  <li><a href="demo4.php">Histórico</a></li>
              <li><a href="logout.php?logout">Sair</a></li>
          </ul>
      </div>
      <div class="main-content">
          <div class="swipe-area"></div>
          <a href="#" data-toggle=".container" id="sidebar-toggle">
              <span class="bar"></span>
              <span class="bar"></span>
              <span class="bar"></span>
          </a>
          <div class="content">
              
		<h2>Editar Agenda</h2>
		<div class="page-title">
		</div>
		<br>
		<form method="post" action="">
		<table cellspacing='0'>
	<tr><th>Data Agendada</th><td><input type="date"  name="date" value="<?php echo $userRow['Data_Agendada'] ?>" /> </td></tr>
		<br />
		</table>
		<br>
		<p align="right">
		<button type="submit" name="submit" class="btnnn" value="update">Editar<button/>
		<button class="btnn" type=button onClick="parent.location='demo5.php'">Voltar</button>   
		</P>
		</form>
		<?php
		}
		?>

<script>
var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].onclick = function() {
    this.classList.toggle("active");
    var panel = this.nextElementSibling;
    if (panel.style.maxHeight){
      panel.style.maxHeight = null;
    } else {
      panel.style.maxHeight = panel.scrollHeight + "px";
    } 
  }
}
</script>

		
		
      </div>
    </div>
  </body>
</html>