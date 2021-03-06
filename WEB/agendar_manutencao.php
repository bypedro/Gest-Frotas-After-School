<?php
  ob_start();
  session_start();
  require_once 'dbconnect.php';
    include 'functions.php';

  // if session is not set this will redirect to login page
  if( !isset($_SESSION['user']) ) {
    header("Location: index.php");
    exit;
  }

  $id = $_SESSION['user'];
	// var_dump($id); die;
	$res=mysql_query("SELECT manutencao.Data_Efetuada, manutencao.Veiculo_Km, manutencao.Valor, veiculos.Matricula, tipomanu.nome, fornecedores.nome, manutencao.Nota FROM manutencao, veiculos, tipomanu, fornecedores, utilizador WHERE manutencao.CodVei=veiculos.codVei AND manutencao.CodTipoM=tipomanu.CodTipoM AND manutencao.CodForn=fornecedores.CodForn AND manutencao.CodUser=utilizador.CodUser");
	$userRow=mysql_fetch_array($res);

	$ress=mysql_query("SELECT tipouser.designacao, utilizador.location, utilizador.Nome_Registo
                      FROM utilizador, tipouser
                        WHERE tipouser.CodTipoU=utilizador.CodTipoU and utilizador.CodUser=" .$_SESSION['user']);
	$usersRow=mysql_fetch_array($ress);

  if ( isset($_POST['btn-signup']) ) {

    // clean user inputs to prevent sql injections
    $email = trim($_POST['email']);
    $email = strip_tags($email);
    $email = htmlspecialchars($email);

    $veiculo = trim($_POST['veiculo']);
    $veiculo = strip_tags($veiculo);
    $veiculo = htmlspecialchars($veiculo);

    $userid = trim($_POST['userid']);
    $userid = strip_tags($userid);
    $userid = htmlspecialchars($userid);

    $tipod = trim($_POST['tipod']);
    $tipod = strip_tags($tipod);
    $tipod = htmlspecialchars($tipod);

    $date = trim($_POST['date']);
    $date = strip_tags($date);
    $date = htmlspecialchars($date);

    $veikm = trim($_POST['veikm']);
    $veikm = strip_tags($veikm);
    $veikm = htmlspecialchars($veikm);

    $valor = trim($_POST['valor']);
    $valor = strip_tags($valor);
    $valor = htmlspecialchars($valor);

    $Notes = trim($_POST['Notes']);
    $Notes = strip_tags($Notes);
    $Notes = htmlspecialchars($Notes);


    // if there's no error, continue to signup
    if( !$error ) {

      $query = "INSERT INTO manutencao (codForn, codVei, CodUser, CodTipoM, Data_Agendada, Veiculo_Km_Agendado, valor, Nota, Efetuada, Data_Efetuada, Veiculo_Km)
                VALUES ( '$email', '$veiculo', '$userid', '$tipod', '$date', '$veikm', '$valor', '$Notes', 'Nao', '$date', '$veikm')";

      $res = mysql_query($query);

      if ($res) {
        $errTyp = "Concluído!";
        $errMSG = "Registo concluído com sucesso, agora pode entrar.";
        header("Location: services.php");
      } else {
        $errTyp = "Erro";
        $errMSG = "Alguma coisa está mal, tente novamente mais tarde...";

      }

    }


  }

?>
<html>
<head>
  <meta charset="UTF-8">
  <title>Agendar Manutenção</title>
      <link rel="stylesheet" href="css/style.css">
      <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Oswald" />
      <script src="js/validations.js"></script>
</head>

<body>

  <div class="topnav">
    <div class="topp"><?php echo $usersRow['Nome_Registo']; ?></div><div class="topd"><?php echo $usersRow['designacao']; ?></div>
     <?php echo '<p><img class="imgmini" src="'.$usersRow['location'].'"></p>'; ?>
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

  <h1>Agendar Manutenção<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
  <div class="page-title">
  </div>
  <br>

  <div class="boxagenda">
    <div class="textagenda">Valor Total (€) </div>
    <input type="count" placeholder="0 €" name="n2" readonly='readonly' id="total_price_amount"/>
  </div>

    <form method="post" action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>" autocomplete="off">

            <?php
      if ( isset($errMSG) ) {

        ?>
        <div class="form-group">
              <div class="alert alert-<?php echo ($errTyp=="success") ? "success" : $errTyp; ?>">
         <?php echo "<script type='text/javascript'>alert('$errMSG');</script>"; ?>
                </div>
              </div>
                <?php
      }
      ?>
  <br>
  <p></p>
  <table cellspacing='0'>
      <tr><th>Fornecedor</th><td><?php
    echo "<select name=email class=search_categories>";
  $q = mysql_query ("select CodForn, nome from fornecedores");
  $num = mysql_num_rows ($q);
  for ($i = 0; $i < $num; $i++)
  {
    $reg = mysql_fetch_assoc($q);
    echo "<option value='" . $reg['CodForn'] ."'>" . $reg['nome'] ."</option>";
  }
  echo "</select>";
  ?></td></tr>
      <tr><th>Tipo Manutenção</th><td><?php
    echo "<select name=tipod id=despt onchange=vhiden() class=search_categories>";
  $q = mysql_query ("select CodTipoM, nome from tipomanu");
  $num = mysql_num_rows ($q);
  for ($i = 0; $i < $num; $i++)
  {
    $reg = mysql_fetch_assoc($q);
    echo "<option value='" . $reg['CodTipoM'] ."'>" . $reg['nome'] ."</option>";
  }
  echo "</select>";
  ?></td></tr>
  <tr><th>Data Agendada</th><td><input type="date" onchange="checkDate()" id="subdate" name="date" value="<?php echo $date ?>" /> </td></tr>
  <tr id='hidensd'><th>Veículo (KM)</th><td><input type="text" id="terpo" onkeypress="validate(event)" placeholder="KM" maxlength="100"  name="veikm" value="<?php echo $veikm ?>" /> </td></tr>
  <tr><th>Valor (€)</th><td><input type="text" id="valued" onkeypress="validate(event)" onChange="counttoanother()" placeholder="€" maxlength="100"  name="valor" value="<?php echo $valor ?>" /> </td></tr>
  <tr><th>Notas</th><td><textarea rows="4" placeholder="€" cols="63" name="Notes"> </textarea> </td></tr>
  </table>
  <br>
  <p></p>

  <?php
    echo "<select name=veiculo style=display:none>";
  $q = mysql_query ("SELECT * FROM veicondu, utilizador, veiculos where veicondu.CodUser=utilizador.CodUser and veicondu.CodVei=veiculos.CodVei and EmUso='Sim' and utilizador.CodUser=".$_SESSION['user']);
  $num = mysql_num_rows ($q);
  for ($i = 0; $i < $num; $i++)
  {
    $reg = mysql_fetch_assoc($q);
    echo "<option value='" . $reg['codVei'] ."'>" . $reg['Matricula'] ."</option>";
  }
  echo "</select>";
  ?>

  <?php
    echo "<select name=userid style=display:none>";
  $q = mysql_query ("SELECT CodUser from utilizador where CodUser=".$_SESSION['user']);
  $num = mysql_num_rows ($q);
  for ($i = 0; $i < $num; $i++)
  {
    $reg = mysql_fetch_assoc($q);
    echo "<option value='" . $reg['CodUser'] ."'>" . $reg['CodUser'] ."</option>";
  }
  echo "</select>";
  ?>

  <p align="right">
     <button type="submit" class="btnnn" name="btn-signup">Registar Despesa</button>
     <button class="btnn" type=button onClick="parent.location='services.php'">Voltar</button>
  </p>


    </form>

  </div>

</body>
</html>
