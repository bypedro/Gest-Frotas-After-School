<?php
	
	require_once 'dbconnect.php';

	$id=$_GET['id'];
	
	// select loggedin users detail
	$res=mysql_query("select * from veiculos, tipocom, tipovei where veiculos.CodTipoC=tipocom.CodTipoC and veiculos.CodTipoV=tipovei.CodTipoV and veiculos.codVei='$id'");
	$userRow=mysql_fetch_array($res);
	
?>
<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Editar Veículo</title>
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
          background: #3775c1;
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
         border-bottom: 1px solid #2d609e;
          -webkit-transition:  background 0.3s ease-in-out;
          -moz-transition:  background 0.3s ease-in-out;
          -ms-transition:  background 0.3s ease-in-out;
          -o-transition:  background 0.3s ease-in-out;
          transition:  background 0.3s ease-in-out;
      }
      #sidebar ul li:hover a {
          background: #2d609e;
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
color: #5a5a5a;;
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
	$matri=$_POST['matri'];
	$email=$_POST['email'];
	$ano=$_POST['ano'];
	$marca=$_POST['marca'];
	$cor=$_POST['cor'];
	$modelo=$_POST['modelo'];
	$tipod=$_POST['tipod'];
	$query3=mysql_query("update veiculos set Matricula='$matri', CodTipoC='$email', Ano='$ano', Marca='$marca', cor='$cor', Modelo='$modelo', CodTipoV='$tipod' where codVei='$id'");
	header("Refresh:0");
	if($query3)
	{
	
	}
	}
	$query1=mysql_query("select * from veiculos where codVei='$id'");
	$query2=mysql_fetch_array($query1);
	?>
    <div class="container">
      <div id="sidebar">
			<center><img src="https://image.flaticon.com/icons/svg/265/265668.svg"></center>
          <ul>
				<li><a href="index.php">Início</a></li>
              <li><a href="user_list_view.php">Utilizadores</a></li>
			  <li><a href="vehicle_list_view.php">Veículos</a></li>
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
              
		<h2>Editar Veículo</h2>
		<div class="page-title">
		</div>
		<br>
		<form method="post" action="">
		<table cellspacing='0'>
			<tr><th>Combustível</th><td><?php
		echo "<select name=email class=search_categories>";
		$q = mysql_query ("select CodTipoC, nomec from tipocom");
		$num = mysql_num_rows ($q);
		for ($i = 0; $i < $num; $i++)
		{
			$reg = mysql_fetch_assoc($q);
			echo "<option value='" . $reg['CodTipoC'] ."'>" . $reg['nomec'] ."</option>";
		}
		echo "</select>";
		?></td></tr>
		<tr><th>Veículo</th><td><?php
    echo "<select name=tipod class=search_categories>";
	$q = mysql_query ("select CodTipoV, nome from tipovei");
	$num = mysql_num_rows ($q);
	for ($i = 0; $i < $num; $i++)
	{
		$reg = mysql_fetch_assoc($q);
		echo "<option value='" . $reg['CodTipoV'] ."'>" . $reg['nome'] ."</option>";
	}
	echo "</select>";
	?></td></tr>
		<tr><th>Matrícula</th><td><input type="text"  name="matri" value="<?php echo $userRow['Matricula'] ?>" /> </td></tr>
		<tr><th>Marca</th><td><input type="text"  name="marca" value="<?php echo $userRow['Marca'] ?>" /> </td></tr>
		<tr><th>Modelo</th><td><input type="text"  name="modelo" value="<?php echo $userRow['Modelo'] ?>" /> </td></tr>
		<tr><th>Ano</th><td><input type="text"  name="ano" value="<?php echo $userRow['Ano'] ?>" /> </td></tr>
		<tr><th>Cor</th><td><input type="text"  name="cor" value="<?php echo $userRow['cor'] ?>" /> </td></tr>
		<br />
		</table>
		<br>
		<p align="right">
		<button type="submit" name="submit" class="btnnn" value="update">Editar<button/>
		<button class="btnn" type=button onClick="parent.location='vehicle_list_view.php'">Voltar</button>   
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