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
	$res=mysql_query("SELECT * FROM utilizador WHERE CodUser=".$_SESSION['user']);
	$userRow=mysql_fetch_array($res);
	
?>
<?php

	if ( isset($_POST['btn-signup']) ) {
		
		// clean user inputs to prevent sql injections
		$pass = trim($_POST['pass']);
		$pass = strip_tags($pass);
		$pass = htmlspecialchars($pass);
		
		$email = trim($_POST['email']);
		$email = strip_tags($email);
		$email = htmlspecialchars($email);
		
		$adress = trim($_POST['adress']);
		$adress= strip_tags($adress);
		$adress = htmlspecialchars($adress);
		
		$nomep = trim($_POST['nomep']);
		$nomep= strip_tags($nomep);
		$nomep = htmlspecialchars($nomep);
		
		$date = trim($_POST['Date']);
		$date= strip_tags($date);
		$date = htmlspecialchars($date);
		
		$gender = trim($_POST['Gender']);
		$gender= strip_tags($gender);
		$gender = htmlspecialchars($gender);
		
		$notes = trim($_POST['Notes']);
		$notes= strip_tags($notes);
		$notes = htmlspecialchars($notes);

		$notess = trim($_POST['Notess']);
		$notess= strip_tags($notess);
		$notess = htmlspecialchars($notess);
		
		if (empty($pass)){
			$error = true;
			$passError = "Please enter password.";
		} else if(strlen($pass) < 6) {
			$error = true;
			$passError = "Password must have atleast 6 characters.";
		}
		
		//basic email validation
		if ( !filter_var($email,FILTER_VALIDATE_EMAIL) ) {
			$error = true;
			$emailError = "Please enter valid email address.";
		} else {
			// check email exist or not
			$query = "SELECT Email FROM utilizador WHERE Email='$email'";
			$result = mysql_query($query);
			$count = mysql_num_rows($result);
			if($count!=0){
				$error = true;
				$emailError = "Provided Email is already in use.";
			}
		}
		
		// password encrypt using SHA256();
		$password = hash('sha256', $pass);
		
		if( !$error ) {
			
			$query = ("UPDATE utilizador SET Senha='$password', Email='$email', Rua='$adress', Genero='$gender', Notas_contacto='$notes', Notas_Contracto='$notess', Nome_Proprio='$nomep', Data_Nascimento='$date' WHERE CodUser=".$_SESSION['user']);
			$res = mysql_query($query);
				
			if ($res) {
				$errTyp = "success";
				$errMSG = "sf";
				unset($name);
				unset($email);
				unset($adress);
				unset($pass);
				unset($nomep);
			} else {
				$errTyp = "danger";
				$errMSG = "Something went wrong, try again later...";	
			}	
				
		}
		
		
	}
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Perfil - <?php echo $userRow['Nome_Registo']; ?></title>
<link rel="stylesheet" href="assets/css/bootstrap.min.css" type="text/css"  />
<link rel="stylesheet" href="style.css" type="text/css" />
<link rel="stylesheet" href="circle.css" type="text/css" />

 <style type="text/css">

            .clearfix:before,.clearfix:after {content: " "; display: table;}
            .clearfix:after {clear: both;}
            .clearfix {*zoom: 1;}

        </style>


</head>
<body>

	<nav class="navbar navbar-default navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="home.php">Início</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          <ul class="nav navbar-nav">
            <li class=""><a href="#">Suporte</a></li>
            <li><a href="#">texto</a></li>
            <li><a href="manageuser.php">Texto</a></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
            
            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
			 			  <span class=""></span><img src="logos/perfil.png">&nbsp;&nbsp;<span class=""></span></a>
              <ul class="dropdown-menu">
				<li><a href="#"><span class=""></span>&#9742; Serviços</a></li>
                <li><a href="perfil.php"><span class="glyphicon glyphicon-user"></span>&nbsp;Perfil</a></li>
				<li><a href="logout.php?logout"><span class="glyphicon glyphicon-log-out"></span>&nbsp;Sair</a></li>
              </ul>
            </li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav> 

		
		
	
	<div id="wrapper">

	<div class="container">
    
    	<div class="page-header">
    	<h3>Alterar Perfil</h3>
    	</div>



	<div id="login-form">
    <form method="post" action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>" autocomplete="off">
    
    	<div class="col-md-12">
           
			 <input type="email" name="email" class="" placeholder="Email" maxlength="40" value="<?php echo $email ?>" />
			 <input type="password" name="pass" class="" placeholder="Password" maxlength="15" />
			 <input type="adress" name="adress" class="" placeholder="Morada" maxlength="100" value="<?php echo $adress ?>" />
			 <input type="text" name="nomep" class="" placeholder="Nome Próprio" maxlength="100" value="<?php echo $nomep ?>" />
		 <p>
        <textarea rows="4" cols="63" name="Notes"> Notas 2
		</textarea>

		<textarea rows="4" cols="63" name="Notess"> Notas 1
		</textarea>
		</p>
		
		<input type="date" placeholder="Data Nascimento" name="Date" value="<?php echo $date ?>" />
        </div>
	<br>
	<p></p>
	
		
	<br>
	
	<input type="radio" name="Gender" value="Masculino" checked="checked" />Masculino<input type="radio" name="Gender" value="Feminino" />Feminino
	
   <br>
         <button type="submit" class="btnreg" name="btn-signup">Editar</button>
				   
        <button class="btnlogin" type=button onClick="parent.location='perfil.php'">Voltar</button>   
            <div class="form-group">
            </div>
   
    </form>
    </div>	

</div>
</div>
    

	
	
    </div>
	
	
 

	
    <script src="assets/jquery-1.11.3-jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    
</body>
</html>
<?php ob_end_flush(); ?>