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
	$res=mysql_query("SELECT * FROM veiabast, utilizador, veiculos, fornecedores where veiabast.CodUser=utilizador.CodUser and veiabast.CodVei=veiculos.CodVei and veiabast.CodForn=fornecedores.CodForn");
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

		$quant = trim($_POST['quant']);
		$quant = strip_tags($quant);
		$quant = htmlspecialchars($quant);

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

			$query = "INSERT INTO veiabast (codForn, codVei, CodUser, Quantidade, Data, Veiculo_Km, Valor, Notas) VALUES ( '$email', '$veiculo', '$userid', '$quant', '$date', '$veikm', '$valor', '$Notes')";
			$res = mysql_query($query);

			if ($res) {
				$errTyp = "Concluído!";
				$errMSG = "Registo concluído com sucesso, agora pode entrar.";
				header("Location: demo5.php");
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
  <title>Início</title>
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
    <h1>Inserir Abastecimento<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
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
  	$q = mysql_query ("select CodForn, nome as nomef from fornecedores");
  	$num = mysql_num_rows ($q);
  	for ($i = 0; $i < $num; $i++)
  	{
  		$reg = mysql_fetch_assoc($q);
  		echo "<option value='" . $reg['CodForn'] ."'>" . $reg['nomef'] ."</option>";
  	}
  	echo "</select>";
  	?></td></tr>
  	<tr><th>Data</th><td><input type="date"  name="date" value="<?php echo $date ?>" /> </td></tr>
  	<tr><th>Veículo (KM)</th><td><input type="text" onkeypress="validate(event)" placeholder="KM" maxlength="100"  name="veikm" value="<?php echo $veikm ?>" /> </td></tr>
  	<tr><th>Quantidade (L)</th><td><input type="text" onkeypress="validate(event)" placeholder="L" maxlength="100"  name="quant" value="<?php echo $quant ?>" /> </td></tr>
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
           <button type="submit" class="btnnn" name="btn-signup">Registar Abastecimento</button>
  		 <button class="btnn" type=button onClick="parent.location='demo5.php'">Voltar</button>
  				 </p>


      </form>


</body>
</html>
