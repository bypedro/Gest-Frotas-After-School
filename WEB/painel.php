<?php

  ob_start();
  session_start();
  require_once 'dbconnect.php';
  include 'functions.php';

  checkolddesp();
  
  // if session is not set this will redirect to login page
  if( !isset($_SESSION['user']) ) {
    header("Location: index.php");
    exit;
  }  
  
?>
<html style="overflow: hidden";>
<head>
  <meta charset="UTF-8">
  <title>Início</title>
      <link rel="stylesheet" href="css/style.css">
      <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Oswald" />
</head>

<body>
  <ul class="menu">

      <li title="home"><a href="#" class="menu-button home">menu</a></li>
      
      <li title="Home"><a href="#" class="ico"></a></li>
      <li title="pencil"><a href="services.php" class="services">pencil</a></li>
      <li title="about"><a href="#" class="perfil">about</a></li>
      <li title="archive"><a href="#" class="">archive</a></li>
      <li title="contact"><a href="#" class="">contact</a></li>
    </ul>
    
  <ul class="menu-bar">
        <li><a href="#" class="menu-button">Menu</a></li>
        <li><a href="#">Defenicoes</a></li>
        <li><a href="#">Sair</a></li>
  </ul>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>
  <script src="js/index.js"></script>

  <div class="container">

  <h1>Início<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
  <div class="page-title">
  </div>
  <br>

  <div class="boxtt">
  <h2>EM SERVIÇO</h2>
  <h4>SIM</h4>
  </div>

  <div class="boxt">
  <h2>CONCLUIDOS</h2>
  <h4>1</h4>
  </div>

  <div class="boxtttt">
  <h2>DESPESAS (€)</h2>
  <h4>1€</h4>
  </div>

  <table class="indextabel">
  <tr>
  <th class="trindex">DATA INICIAL</th>
  <td class="tdindex">00-00-0000</td>
  </tr>
  <tr>
  <th class="trindex">DATA FINAL ESPERADA</th>
  <td class="tdindex">00-00-0000</td>
  </tr>
  <tr>
  <th class="trindex">DESPESAS (€)</th>
  <td class="tdindex">234€</td>
  </tr>
  <tr> 
  <th class="tdindex">
    <table id="t01">
    <tr>
      <th class="sth">Efetuar</th>
      <th class="tth">Trocar</th> 
    </tr>
  </table>
  </th>
  </td>  
  </tr>
  </table>
  </div>

</body>
</html>
