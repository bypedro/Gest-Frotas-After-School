<!DOCTYPE html>
<?php
	ob_start();
	session_start();
	require_once 'dbconnect.php';
	
	// if session is not set this will redirect to login page
	if( !isset($_SESSION['user']) ) {
		header("Location: index.php");
		exit;
	}
	// select loggedin users detail
<<<<<<< HEAD
	$res=mysql_query("SELECT * FROM utilizador, cidade, tipouser, pais WHERE pais.CodPais=cidade.CodPais and tipouser.CodTipoU=utilizador.CodTipoU and cidade.CodCi=utilizador.CodCi and utilizador.CodUser=".$_SESSION['user']);
	$userRow=mysql_fetch_array($res);
	

?>

=======
	$res=mysql_query("SELECT * FROM utilizador WHERE CodUser=".$_SESSION['user']);
	$userRow=mysql_fetch_array($res);
?>
>>>>>>> refs/remotes/origin/master
<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Início</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="jquery.touchSwipe.min.js"></script>
	<link rel="stylesheet" href="style.css" type="text/css" />
	<link rel="stylesheet" href="circle.css" type="text/css" />
      
    
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
    <div class="container">
      <div id="sidebar">
		<center><img src="https://image.flaticon.com/icons/svg/265/265729.svg"></center>
          <ul>
         
<<<<<<< HEAD
<li><a href="demo3.php">Início</a></li>
              <li><a href="demo5.php">Serviços</a></li>
			  <li><a href="demo2.php">Perfil</a></li>
			  <li><a href="demo4.php">Histórico</a></li>
              <li><a href="logout.php?logout">Sair</a></li>
			  		  	<?php
	$q = mysql_query ("SELECT CodTipoU from utilizador where CodTipoU=1 and CodUser=".$_SESSION['user']);
	$num = mysql_num_rows ($q);
	if($num == '1')	
	{
	echo '<a href="admin/index.php" target="_blank">';
	echo '<input name="admin" type="submit" class="btnadmin" value="Painel Administrador" />' ;
	echo '</a>';
	}
	?>
          </ul>
=======
              <li><a href="demo3.php">Início</a></li>
              <li><a href="#">Serviços</a></li>
              <li><a href="#">Despesas</a></li>
			  <li><a href="demo2.php">Perfil</a></li>
			  <li><a href="#">Histórico</a></li>
              <li><a href="logout.php?logout">Sair</a></li>
>>>>>>> refs/remotes/origin/master
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
              
				<h2>Perfil</h2>
		
		 <div class="page-header">
		</div>
		
    	<div class="page-header">
		
		
			
		

		<ul class="tab">
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Geral')" id="defaultOpen">Dados Gerais</a></li>
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Pessoal')">Dados Pessoais</a></li>
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'notas')">Notas</a></li>

	</ul>
    	
		</div>

	<div id="Geral" class="tabcontent">
  <p><table cellspacing='0'>
			<tr><th>ID</th><td><?php echo $userRow['CodUser']; ?></td></tr>
			<tr><th>Utilizador</th><td><?php echo $userRow['Nome_Registo']; ?></td></tr>
			<tr><th>Email</th><td><?php echo $userRow['Email']; ?></td></tr>
<<<<<<< HEAD
			<tr><th>País</th><td><?php echo $userRow['Nomep']; ?></td></tr>
=======
			<tr><th>País</th><td><?php echo $userRow['']; ?></td></tr>
>>>>>>> refs/remotes/origin/master
			<tr><th>Género</th><td><?php echo $userRow['Genero']; ?></td></tr>
			<tr><th>Data Contratação</th><td><?php echo $userRow['Data_Contratacao']; ?></td></tr>
			</table>
			</p>
	<br>
	<p align="right">
		<button class="btnnn" type=button onClick="parent.location='#.php'">?</button>
		<button class="btnn" type=button onClick="parent.location='editarperfil.php'">&#10000; Alterar</button>
	</p>
	</div>
	
	<div id="Pessoal" class="tabcontent">
  <p><table cellspacing='0'>
			<tr><th>Nome Próprio</th><td><?php echo $userRow['Nome_Proprio']; ?></td></tr>
			<tr><th>Apelido</th><td><?php echo $userRow['Apelido']; ?></td></tr>
			<tr><th>Data Nascimento</th><td><?php echo $userRow['Data_Nascimento']; ?></td></tr>
			<tr><th>Habilitações</th><td><?php echo $userRow['Habilitacoes']; ?></td></tr>
			<tr><th>Pagamentos</th><td><?php echo $userRow['Pagamentos_Hora']; ?>€</td></tr>
			<tr><th>Morada</th><td><?php echo $userRow['Rua']; ?></td></tr>
			<tr><th>Telemóvel</th><td><?php echo $userRow['N_Telemovel']; ?></td></tr>
			<tr><th>Telefone</th><td><?php echo $userRow['N_Telefone']; ?></td></tr>
			</table>
			</p>
	<br>
	<p align="right">
		<button class="btnnn" type=button onClick="parent.location='#.php'">?</button>
		<button class="btnn" type=button onClick="parent.location='editarperfil.php' ">&#10000; Alterar</button>
	</p>
	</div>
	
	
	<div id="notas" class="tabcontent">
	<p><table cellspacing='0'>
			<tr><th>Notas Contacto</th><td><?php echo $userRow['Notas_contacto']; ?></td></tr>
			<tr><th>Notas Contracto</th><td><?php echo $userRow['Notas_Contracto']; ?></td></tr>
			</table>
			</p>
	<br>
	<p align="right">
		<button class="btnnn" type=button onClick="parent.location='#.php'">?</button>
		<button class="btnn" type=button onClick="parent.location='editarperfil.php'">&#10000; Alterar</button>
	</p>
	</div>
	

	
	</div>
	<script>
	
	function openCity(evt, cityName) {
		var i, tabcontent, tablinks;
		tabcontent = document.getElementsByClassName("tabcontent");
		for (i = 0; i < tabcontent.length; i++) {
			tabcontent[i].style.display = "none";
		}
		tablinks = document.getElementsByClassName("tablinks");
		for (i = 0; i < tablinks.length; i++) {
			tablinks[i].className = tablinks[i].className.replace(" active", "");
		}
		document.getElementById(cityName).style.display = "block";
		evt.currentTarget.className += " active";
	}

	// Get the element with id="defaultOpen" and click on it
	document.getElementById("defaultOpen").click();
	</script>
			 
		</div>
      </div>
    </div>
  </body>
</html>