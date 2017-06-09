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
	$res=mysql_query("SELECT * from utilizador, veiculos, tipocom, tipovei where veiculos.CodTipoV=tipovei.CodTipoV and veiculos.CodTipoC=tipocom.CodTipoC and CodUser=".$_SESSION['user']);
	$userRow=mysql_fetch_array($res);
	
	
?>
<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Serviços</title>
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

.tooltip {
	font-size: 51%;
    position: relative;
    display: inline-block;
}

.tooltip .tooltiptext {
    visibility: hidden;
    width: 338px;
    background-color: #555;
    color: #fff;
    text-align: center;
    border-radius: 6px;
    padding: 5px 0;
    position: absolute;
    z-index: 1;
    bottom: 125%;
    left: 50%;
    margin-left: -60px;
    opacity: 0;
    transition: opacity 1s;
}

.tooltip .tooltiptext::after {
    content: "";
    position: absolute;
    top: 100%;
    left: 18%;
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: #555 transparent transparent transparent;
}

.tooltip:hover .tooltiptext {
    visibility: visible;
    opacity: 1;
}

.imgaddd {
	margin: 0px 0px 0px 0px;
	width: 20px;
    height: 20px;
	  
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
	
         
		<h2>Serviços <div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Nas despesas, na agenda e no abastecimento, aparecem somente os dois registos mais recentes.</span></div>  </h2>
		<div class="page-title">
		</div>
		<br>
<button class="accordion"><img src="logos/calendar.png" class="imggg"><h3>SERVIÇO ATIVO</h3>  </button>
<div class="panel">
<iframe src="veiact.php" frameborder="0" width="100%" height="100%"></iframe>
</div>

<button class="accordion"><img src="logos/notes.png" class="imggg"><h3>DESPESAS </h3> </button>
<div class="panel">
  <iframe src="despesas.php" frameborder="0" width="100%" height="190px"></iframe>
  <p align="right"><a href="demo6.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a><a href="demo9.php"><img src="logos/file.png" title="Ver Histórico" class="imgadd"></a>
  </p>
</div>

<!--<button class="accordion"><img src="logos/crate.png" class="imggg"><h3>FORNECEDORES</h3> </button>
<div class="panel">
  <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
</div>-->

<button class="accordion"><img src="logos/bell.png" class="imggg"><h3>AGENDA</h3> </button>
<div class="panel">
  <iframe src="agenda.php" frameborder="0" width="100%" height="190px"></iframe>
  <p align="right"><a href="demo7.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a> <a href="demo10.php"><img src="logos/file.png" title="Ver Lista" class="imgadd"></a></p>
</div>

<button class="accordion"><img src="logos/fuel.png" class="imggg"><h3>ABASTECIMENTO</h3> </button>
<div class="panel">
  <iframe src="abast.php" frameborder="0" width="100%" height="100%"></iframe>
  <p align="right"><a href="demo8.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a> <a href="#.php"><img src="logos/file.png" title="Ver Histórico" class="imgadd"></a></p>
</div>


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