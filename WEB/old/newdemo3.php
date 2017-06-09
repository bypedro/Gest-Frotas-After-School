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
	$res=mysql_query("SELECT * FROM veicondu, utilizador, veiculos, tipouser where utilizador.CodTipoU=tipouser.CodTipoU and veicondu.CodUser=utilizador.CodUser and veicondu.CodVei=veiculos.CodVei and EmUso='Sim' and utilizador.CodUser=".$_SESSION['user']);
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
	  
	  .alert {
    padding: 20px;
    background-color: #DF314D;
    color: white;
}

.closebtn {
    margin-left: 15px;
    color: white;
    font-weight: bold;
    float: right;
    font-size: 22px;
    line-height: 20px;
    cursor: pointer;
    transition: 0.3s;
}

.closebtn:hover {
    color: black;
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
      </div>
      <div class="main-content">
          <div class="swipe-area"></div>
          <a href="#" data-toggle=".container" id="sidebar-toggle">
              <span class="bar"></span>
              <span class="bar"></span>
              <span class="bar"></span>
          </a>
          <div class="content">
          
		  
		 <div class="alert">
  <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span> 
  <strong>Bem Vindo - </strong> <?php echo $userRow['Nome_Registo']; ?> | <strong>Serviço Ativo - </strong> <?php echo $userRow['EmUso']; ?>
</div>
		  
		<h2>Painel Utilizador</h2>
		<div class="page-title">
		</div>
		<div class="hover08 column">
			 <div class="boxt">
			 <figure><img src="https://image.flaticon.com/icons/svg/351/351758.svg"
			align="left" title="Veiculo Activo"></figure><br>
		<div class="page-box">
		</div>			
			<b><h1>Marca:</b> <?php echo $userRow['Marca']; ?></h1><p>
			<b><h1>Modelo:</b> <?php echo $userRow['Modelo']; ?></h1><p>
			<b><h1>Matrícula:</b> <?php echo $userRow['Matricula']; ?></h1>
		
			<p>
			<button class="" type=button onClick="parent.location='#'"></button>
			 </div>
			 
			 <div class="boxt">
			 <figure><img src="https://image.flaticon.com/icons/svg/252/252021.svg"
			align="left" title="Manutenção"></figure><br>
			<div class="page-box">
		</div>	
			<b><h1>Inspeção:</b> <?php echo $userRow['Proxima_Inspecao']; ?></h1><p>
			<b><h1>Manutenção:</b> </h1><p>
			<h1>Editar</h1>
			
			<button class="" type=button onClick="parent.location='#'"></button>
			 </div>
			  <div class="boxt">
			 <figure><img src="https://image.flaticon.com/icons/svg/140/140638.svg"
			align="left" title="Despesas"></figure><br>
			<div class="page-box">
		</div>	
			<b><h1>Abastecimento:</b> </h1><p>
			<b><h1>Manutenção:</b> </h1><p>
			<b><h1>Despesas:</b> </h1>
			
			<button class="" type=button onClick="parent.location='#'"></button>
			 </div>
			 
			  <div class="boxt">
			 <figure><img src="https://image.flaticon.com/icons/svg/340/340068.svg"
			align="left" title="Notas"></figure><br>
			<div class="page-box">
		</div>	
			<h1>Editar</h1><p>
			<h1> Editar</h1><p>
			<h1> Editar</h1>
			
			<button class="" type=button onClick="parent.location='#'"></button>
			 </div>
			 
		</div>
      </div>
    </div>
  </body>
</html>