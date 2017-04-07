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
		
	
		// if there's no error, continue to signup
		if( !$error ) {
			
			$query = "INSERT INTO despesas (codForn, codVei, CodUser, CodTipoD) VALUES ( '$email', '$veiculo', '$userid', '$tipod')";
			$res = mysql_query($query);
				
			if ($res) {
				$errTyp = "Concluído!";
				$errMSG = "Registo concluído com sucesso, agora pode entrar.";
				unset($fornecedor);
			} else {
				$errTyp = "Erro";
				$errMSG = "Alguma coisa está mal, tente novamente mais tarde...";
				
			}	
				
		}
		
		
	}
	
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Registar</title>
<link rel="stylesheet" href="assets/css/bootstrap.min.css" type="text/css"  />
<link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body style="background-color:#f7f7f7;>

<div class="container">

	<div id="login-form">
    <form method="post" action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>" autocomplete="off">
    
    	<div class="col-md-12">
        
        	<div class="form-group">

            </div>
        
        
            
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
            
			

		<h6>Registar Utilizador</h6>
            <div class="form-group">
            	<div class="">
			
			<br>
			
	<?php
    echo "<select name=email>";
	$q = mysql_query ("select CodForn, nomef from fornecedores");
	$num = mysql_num_rows ($q);
	for ($i = 0; $i < $num; $i++)
	{
		$reg = mysql_fetch_assoc($q);
		echo "<option value='" . $reg['CodForn'] ."'>" . $reg['nomef'] ."</option>";
	}
	echo "</select>";
	?>
	
	<?php
    echo "<select name=tipod>";
	$q = mysql_query ("select CodTipoD, nome from tipodesp");
	$num = mysql_num_rows ($q);
	for ($i = 0; $i < $num; $i++)
	{
		$reg = mysql_fetch_assoc($q);
		echo "<option value='" . $reg['CodTipoD'] ."'>" . $reg['nome'] ."</option>";
	}
	echo "</select>";
	?>
	
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
	
            </div>

			
			<br>
         <button type="submit" class="btnreg" name="btn-signup">Registar</button>
				   
            <div class="form-group">
            </div>
			
        </div> 
		

		
		
    </form>

    </form>
    </div>	

</div>

</body>
</html>
<?php ob_end_flush(); ?>