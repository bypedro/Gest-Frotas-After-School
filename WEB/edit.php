<?php
  
  ob_start();
  session_start();
  require_once 'dbconnect.php';
  //require 'functions.php';
  
  // if session is not set this will redirect to login page
  if( !isset($_SESSION['user']) ) {
    header("Location: index.php");
    exit;

}


  //exist_id();
  //edit_id();

?>
<html style="overflow: hidden";>
<head>
  <meta charset="UTF-8">
  <title>Reagendar Servico</title>
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
  $query3=mysql_query("update despesas set Data_Efetuada='$date', Data_Agendada='$date' where CodDesp='$id'");
  header("Location: services.php");
  if($query3)
  {
  
  }
  }
  $query1=mysql_query("SELECT despesas.CodDesp as coddespesa, despesas.Valor as desp, despesas.Data_Agendada as datea, fornecedores.nomef as forn, tipodesp.nome as tipdesp, veiculos.Matricula as vei 
                      from despesas, fornecedores, tipodesp, veiculos 
                      where despesas.CodTipoD = tipodesp.CodTipoD and despesas.CodDesp = despesas.CodDesp and despesas.codVei = veiculos.codVei and despesas.CodDesp ='$id'");
  $query2=mysql_fetch_array($query1);
  ?>

  <ul class="menu">

      <li title="home"><a href="#" class="menu-button home">menu</a></li>
      
      <li title="Home"><a href="painel.php" class="ico"></a></li>
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

  <h1>Editar Agenda<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
  <div class="page-title">
  </div>
  <br>

   <th class="tdindex">
    <table id="t02">
    <tr>
      <th class="ttthh"><h5><br><?php echo $query2['coddespesa'] ?></h5></th>
      <th class="tthhh"><h5><br><?php echo $query2['forn'] ?></h5></th> 
      <th class="tthh"><h5><br><?php echo $query2['tipdesp'] ?></h5></th>
      <th class="sthh"><h5><br><?php echo $query2['desp'] ?> €</h5></th>
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
