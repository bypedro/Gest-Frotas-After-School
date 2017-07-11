<?php

  ob_start();
  session_start();
  require_once 'dbconnect.php';
  require 'functions.php';

  // if session is not set this will redirect to login page
  if( !isset($_SESSION['user']) ) {
    header("Location: index.php");
    exit;

}

$res=mysql_query("SELECT tipouser.designacao, utilizador.location, utilizador.Nome_Registo
                    FROM utilizador, tipouser
                      WHERE tipouser.CodTipoU=utilizador.CodTipoU and utilizador.CodUser=" .$_SESSION['user']);

$userRow=mysql_fetch_array($res);

  //exist_id();
  //edit_id();

?>
<html style="overflow: hidden";>
<head>
  <meta charset="UTF-8">
  <title>Editar Manutenção</title>
  <link rel="stylesheet" href="css/style.css">
  <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Oswald" />
  <script src="js/validations.js"></script>
</head>

<body>

  <?php
  include('dbconnect.php');
  if(isset($_GET['id']))
  {
  $id=$_GET['id'];




  if(isset($_POST['submit']))
  {
  $date=$_POST['date'];
  $query3=mysql_query("update manutencao set Data_Efetuada='$date', Data_Agendada='$date' where CodManu='$id'");
  header("Location: services.php");
  if($query3)
  {

  }
  }
  $query1=mysql_query("SELECT manutencao.CodManu as codmanu, manutencao.Data_Agendada as datea, manutencao.Valor as desp, tipomanu.nome as tipdesp, fornecedores.nome as nomef
                        FROM manutencao, veiculos, tipomanu, fornecedores
                        WHERE manutencao.CodVei=veiculos.codVei AND manutencao.CodTipoM=tipomanu.CodTipoM
                        AND manutencao.CodForn=fornecedores.CodForn AND manutencao.CodManu ='$id'");
  $query2=mysql_fetch_array($query1);

  ?>

  <div class="topnav">
    <div class="topp"><?php echo $userRow['Nome_Registo']; ?></div><div class="topd"><?php echo $userRow['designacao']; ?></div>
     <?php echo '<p><img class="imgmini" src="'.$userRow['location'].'"></p>'; ?>
  </div>

  <ul class="menu">
      <li title="home"><a href="#" class="menu-button home">menu</a></li>
      <li title="Home"><a href="painel.php" class="ico"></a></li>
      <?php   ifgest(); ?>
      <li title="about"><a href="perfil.php" class="perfil">about</a></li>
      <li title="archive"><a href="listar_servicos.php" class="history">archive</a></li>
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

  <h1>Editar Manutenção<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
  <div class="page-title">
  </div>
  <br>

   <th class="tdindex">
    <table id="t02">
    <tr>
      <th class="ttthh"><h5><br><div class="thref">Referência</div><?php echo $query2['codmanu'] ?></h5></th>
      <th class="tthhh"><h5><br><div class="thforn">Fornecedor</div><?php echo $query2['nomef'] ?></h5></th>
      <th class="tthh"><h5><br><div class="thforn">Manutenção</div><?php echo $query2['tipdesp'] ?></h5></th>
      <th class="sthh"><h5><br><div class="thforn">Valor</div><?php echo $query2['desp'] ?> €</h5></th>
    </tr>

    </table>

  <form method="post" action="">
    <table cellspacing='0'>
    <tr><th>Data Agendada</th><td><input type="date" id="subdate" onchange="checkDate()" name="date" value="<?php echo $query2['datea'] ?>" /> </td></tr>
    <br />

    <br>
    <p align="right">
    <button type="submit" onclick=" return IsEmpty()" name="submit" class="btnnn" value="update">Editar</button>
    <button class="btnn" type=button onClick="parent.location='services.php'">Voltar</button>
    </P>
    </form>
    <?php
    }
    ?>

  </div>

</body>
</html>
