<?php
	ob_start();
	session_start();
	if( isset($_SESSION['user'])!="" ){
		header("Location: demo3.php");
	}
	include_once 'dbconnect.php';

	$error = false;

	if ( isset($_POST['btn-signup']) ) {
		
		// clean user inputs to prevent sql injections
		$name = trim($_POST['name']);
		$name = strip_tags($name);
		$name = htmlspecialchars($name);
		
		$email = trim($_POST['email']);
		$email = strip_tags($email);
		$email = htmlspecialchars($email);
		
		$pass = trim($_POST['pass']);
		$pass = strip_tags($pass);
		$pass = htmlspecialchars($pass);
		
		
		// basic name validation
		if (empty($name)) {
			$error = true;
			$nameError = "Introduza o seu nome completo.";
		} else if (strlen($name) < 3) {
			$error = true;
			$nameError = "Nome tem de ter pelo menos 3 carateres.";
		} else if (!preg_match("/^[a-zA-Z ]+$/",$name)) {
			$error = true;
			$nameError = "Name must contain alphabets and space.";
		}
		
		//basic email validation
		if ( !filter_var($email,FILTER_VALIDATE_EMAIL) ) {
			$error = true;
			$emailError = "Introduza um email válido.";
		} else {
			// check email exist or not
			$query = "SELECT Email FROM utilizador WHERE Email='$email'";
			$result = mysql_query($query);
			$count = mysql_num_rows($result);
			if($count!=0){
				$error = true;
				$emailError = "O email que digitou já está a ser usado.";
			}
		}
		// password validation
		if (empty($pass)){
			$error = true;
			$passError = "Introduza a sua password.";
		} else if(strlen($pass) < 6) {
			$error = true;
			$passError = "Password tem de ter pelo menos 6 carateres.";
		}
		
		// password encrypt using SHA256();
		$password = hash('sha256', $pass);
		
		// if there's no error, continue to signup
		if( !$error ) {
			
			$query = "INSERT INTO utilizador(Nome_Registo, Email, Senha, userPic) VALUES('$name','$email','$password', '$userpic')";
			$res = mysql_query($query);
				
			if ($res) {
				$errTyp = "Concluído!";
				$errMSG = "Registo concluído com sucesso, agora pode entrar.";
				unset($name);
				unset($email);
				unset($pass);
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
            
			
		<div class="boxxx">	
		<h6>Registar Utilizador</h6>
            <div class="form-group">
            	<div class="">
			
			<br>
                <span class=""><span class=""></span></span>
            	<input type="text" name="name" class="" placeholder="Utilizador" maxlength="50" value="<?php echo $name ?>" />
                </div>
                <span class="text-danger"><?php echo $nameError; ?></span>
            </div>
            
            <div class="form-group">
            	<div  class="">
                <span class=""><span class=""></span></span>
            	<input type="email" name="email" class="" placeholder="Email" maxlength="40" value="<?php echo $email ?>" />
                </div>
                <span class="text-danger"><?php echo $emailError; ?></span>
            </div>
            
            <div class="form-group">
            	<div class=""> 
                <span class=""><span class=""></span></span> 
            	<input type="password" name="pass" class="" placeholder="•••••••" maxlength="15" />
                </div>
                <span class="text-danger"><?php echo $passError; ?></span>
            </div>

			
			<br>
         <button type="submit" class="btnreg" name="btn-signup">Registar</button>
				   
        <button class="btnlogin" type=button onClick="parent.location='index.php'">Entrar</button>   
            <div class="form-group">
            </div>
			
        </div> 
		

		
		
    </form>
    </div>	
    </form>
    </div>	

</div>

</body>
</html>
<?php ob_end_flush(); ?>