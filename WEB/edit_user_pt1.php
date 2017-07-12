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

?>
<html>
<head>
  <meta charset="UTF-8">
  <title>Editar utilizador</title>
  <link rel="stylesheet" href="css/style.css">
  <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Oswald" />
  <script src="js/validations.js"></script>
</head>

<body>

  <?php
  include('dbconnect.php');

  $query1=mysql_query("SELECT utilizador.senha, utilizador.Nome_Proprio, utilizador.Apelido, utilizador.Genero, utilizador.Data_Nascimento, utilizador.Rua, utilizador.N_Telemovel, utilizador.CodUser, utilizador.Nome_Registo, utilizador.Email, cidade.Nome, tipouser.designacao
                        FROM utilizador, cidade, tipouser, pais
                        WHERE pais.CodPais=cidade.CodPais and tipouser.CodTipoU=utilizador.CodTipoU and cidade.CodCi=utilizador.CodCi and utilizador.CodUser= " .$_SESSION['user']);
  $query2=mysql_fetch_array($query1);
  $error = false;
  if(isset($_POST['submit']))
  {
  $name=$_POST['name'];
  $email=$_POST['email'];
  $tipod=$_POST['tipod'];
  $nomep=$_POST['nomep'];
  $nomea=$_POST['nomea'];
  $genero=$_POST['genero'];
  $date=$_POST['date'];
  $street=$_POST['street'];
  $telemov=$_POST['telemov'];
  $senha=$_POST['senha'];

  $password = hash('sha256', $senha);

  $query = "SELECT senha FROM utilizador WHERE senha='$password'";
  $result = mysql_query($query);
  $count = mysql_num_rows($result);
  if($count!=0){
    echo "<script type='text/javascript'>alert('boas');</script>";
    $error = true;
  }

  $query3=mysql_query("UPDATE utilizador SET Genero='$genero', Data_Nascimento='$date', Rua='$street', N_Telemovel='$telemov', Nome_Proprio='$nomep', Apelido='$nomea', CodCi='$tipod', Email='$email', Nome_Registo='$name', senha='$password' WHERE CodUser = " .$_SESSION['user']);
  header("Location: perfil.php");
  if($query3)
  {

  }
  }




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
          <li><a href="logout.php">Sair</a></li>
    </ul>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>
  <script src="js/index.js"></script>

  <div class="container">

  <h1>Editar utilizador<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
  <div class="page-title">
  </div>
  <br>

  <form method="post" action="">
    <table cellspacing='0'>

    <tr><th>utilizador</th><td><input type="text" name="name" class="" placeholder="Utilizador" maxlength="50" value="<?php echo $query2['Nome_Registo'] ?>" /> </td></tr>
    <tr><th>Email</th><td><input type="text" name="email" class="" placeholder="Email" maxlength="50" value="<?php echo $query2['Email'] ?>" /> </td></tr>
    <br />
    <tr><th>Cidade</th><td><?php
    echo "<select name=tipod class=search_categories>";
    $q = mysql_query ("SELECT cidade.CodCi, cidade.nome, tipouser.designacao, utilizador.Nome_Registo
                        FROM utilizador, tipouser, cidade
                          WHERE tipouser.CodTipoU=utilizador.CodTipoU and utilizador.CodUser=" .$_SESSION['user']);
    $num = mysql_num_rows ($q);
    for ($i = 0; $i < $num; $i++)
    {
      $reg = mysql_fetch_assoc($q);
      echo "<option value='" . $reg['CodCi'] ."'>" . $reg['nome'] ."</option>";
    }
    echo "</select>";
    ?></td></tr>
    <tr><th>Nome Próprio</th><td><input type="text" name="nomep" class="" placeholder="Email" maxlength="50" value="<?php echo $query2['Nome_Proprio'] ?>" /> </td></tr>
    <tr><th>Apelido</th><td><input type="text" name="nomea" class="" placeholder="Email" maxlength="50" value="<?php echo $query2['Apelido'] ?>" /> </td></tr>
    <tr><th>Género</th><td><input type="text" name="genero" class="" placeholder="Email" maxlength="50" value="<?php echo $query2['Genero'] ?>" /> </td></tr>
    <tr><th>Data Nascimento</th><td><input type="date" id="subdate" name="date" value="<?php echo $query2['Data_Nascimento'] ?>" /> </td></tr>
    <tr><th>Morada</th><td><input type="text" name="street" class="" placeholder="Email" maxlength="50" value="<?php echo $query2['Rua'] ?>" /> </td></tr>
    <tr><th>Telemóvel</th><td><input type="text" name="telemov" class="" placeholder="Email" maxlength="50" value="<?php echo $query2['N_Telemovel'] ?>" /> </td></tr>
    <tr><th>Senha</th><td><input type="password" name="senha" class="" placeholder="Senha" maxlength="50" value="<?php echo $query2['senha'] ?>" /> </td></tr>
    <p align="right">
    <button type="submit" onclick=" return IsEmpty()" name="submit" class="btnnn" value="update">Editar</button>
    <button class="btnn" type=button onClick="parent.location='perfil.php'">Voltar</button>
    </P>
    </form>
    <?php

    ?>

  </div>

</body>
</html>
