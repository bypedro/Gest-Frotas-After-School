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
  $res=mysql_query("SELECT * from despesas, veiculos, fornecedores, utilizador, tipodesp WHERE despesas.codVei=veiculos.codVei AND despesas.codForn=fornecedores.CodForn and despesas.CodUser=utilizador.CodUser and despesas.CodTipoD=tipodesp.CodTipoD");
  $userRow=mysql_fetch_array($res);

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
      
      $query = "INSERT INTO despesas (codForn, codVei, CodUser, CodTipoD, Data_Agendada, Veiculo_Km_Agendado, valor, Nota, Efetuada, Data_Efetuada, Veiculo_Km, Estado) 
                VALUES ( '$email', '$veiculo', '$userid', '$tipod', '$date', '$veikm', '$valor', '$Notes', 'Nao', '$date', '$veikm', 'Aguardar')";

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
<html style="overflow: hidden";>
<head>
  <meta charset="UTF-8">
  <title>Agendar Despesa</title>
      <link rel="stylesheet" href="css/style.css">
      <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Oswald" />
      <script src="js/validations.js"></script>
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
  $q = mysql_query ("select CodForn, nomef from fornecedores");
  $num = mysql_num_rows ($q);
  for ($i = 0; $i < $num; $i++)
  {
    $reg = mysql_fetch_assoc($q);
    echo "<option value='" . $reg['CodForn'] ."'>" . $reg['nomef'] ."</option>";
  }
  echo "</select>";
  ?></td></tr>
      <tr><th>Tipo Despesa</th><td><?php
    echo "<select name=tipod id=despt onchange=vhiden() class=search_categories>";
  $q = mysql_query ("select CodTipoD, nome from tipodesp");
  $num = mysql_num_rows ($q);
  for ($i = 0; $i < $num; $i++)
  {
    $reg = mysql_fetch_assoc($q);
    echo "<option value='" . $reg['CodTipoD'] ."'>" . $reg['nome'] ."</option>";
  }
  echo "</select>";
  ?></td></tr>
  <tr><th>Data Agendada</th><td><input type="date" onchange="checkDate()" id="subdate" name="date" value="<?php echo $date ?>" /> </td></tr>
  <tr id='hidensd'><th>Veículo (KM)</th><td><input type="text" id="terpo" onkeypress="validate(event)" placeholder="KM" maxlength="100"  name="veikm" value="<?php echo $veikm ?>" /> </td></tr>
  <tr><th>Valor (€)</th><td><input type="text" onkeypress="validate(event)" placeholder="€" maxlength="100"  name="valor" value="<?php echo $valor ?>" /> </td></tr>
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
