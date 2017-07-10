<!DOCTYPE html>
	<?php
	ob_start();
	session_start();
	require_once 'dbconnect.php';
	
	$res=mysql_query("SELECT * FROM utilizador, cidade, tipouser, pais WHERE pais.CodPais=cidade.CodPais and tipouser.CodTipoU=utilizador.CodTipoU and cidade.CodCi=utilizador.CodCi and utilizador.CodUser=".$_SESSION['user']);
	$userRow=mysql_fetch_array($res);
	
	$result = mysql_query("select count(CodUser) as max_page from utilizador");
	$row = mysql_fetch_array($result);
	
	$q = mysql_query ("select count(CodVeiC) as max_act from veicondu where emuso='sim'");
	$rows = mysql_fetch_array($q);
	
	$qq = mysql_query ("select count(CodVeiC) as max_valor from veicondu where emuso='nao'");
	$rowss = mysql_fetch_array($qq);
	
	?>

<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Painel Administrador</title>
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
	  
	  .alert {
    padding: 20px;
    background-color: #3775c1;
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

   .clearfix:before,.clearfix:after {content: " "; display: table;}
            .clearfix:after {clear: both;}
            .clearfix {*zoom: 1;}

	  
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
          
		  
		 <div class="alert">
  <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span> 
  <strong>Bem Vindo - </strong> <?php echo $userRow['Nome_Registo']; ?> | <strong>Modificar - </strong> <?php echo $userRow['EmUso']; ?>
</div>
		  
		<h2>Painel Administrador</h2>
		<div class="page-title">
		</div>
			<div class="clearfix">
                <div class="c100 p25 green">
                    <span title="Número Utilizadores"><?php echo $row["max_page"]; ?></span>
                    <div class="slice">
                        <div class="bar"></div>
                        <div class="fill"></div>
                    </div>
				</div>
				
				<div class="c100 p25 orange">
                    <span title="Total Serviços Activos"><?php echo $rows["max_act"]; ?></span>
                    <div class="slice">
                        <div class="bar"></div>
                        <div class="fill"></div>
                    </div>
              
				</div>
				
				<div class="c100 p25 green">
                    <span title="Total Serviços Efetuados"><?php echo $rowss["max_valor"]; ?></span>
                    <div class="slice">
                        <div class="bar"></div>
                        <div class="fill"></div>
                    </div>
              
				</div>
				
				<div class="c100 p25 orange">
                    <span>50%</span>
                    <div class="slice">
                        <div class="bar"></div>
                        <div class="fill"></div>
                    </div>
              
				</div>

		</div>
		
      </div>
    </div>
  </body>
</html>