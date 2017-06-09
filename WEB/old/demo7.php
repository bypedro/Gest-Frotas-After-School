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
			
			$query = "INSERT INTO despesas (codForn, codVei, CodUser, CodTipoD, Data_Agendada, Veiculo_Km_Agendado, valor, Nota, Efetuada, Data_Efetuada, Veiculo_Km) VALUES ( '$email', '$veiculo', '$userid', '$tipod', '$date', '$veikm', '$valor', '$Notes', 'Nao', '$date', '$veikm')";
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
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Início <?php echo $userRow['Nome_Registo']; ?></title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="jquery.touchSwipe.min.js"></script>
	<link rel="stylesheet" href="style.css" type="text/css" />
	
      
    
    <style type="text/css">
			body, html {
          height: 100%;
          margin: 0;
          overflow:hidden;
          font-family: helvetica;
          font-weight: 100;
      }
      .container {
          position: relative;
          height: 100%;
          width: 100%;
          left: 0;
          -webkit-transition:  left 0.4s ease-in-out;
          -moz-transition:  left 0.4s ease-in-out;
          -ms-transition:  left 0.4s ease-in-out;
          -o-transition:  left 0.4s ease-in-out;
          transition:  left 0.4s ease-in-out;
      }
      .container.open-sidebar {
          left: 240px;
      }
      
      .swipe-area {
          position: absolute;
          width: 50px;
          left: 0;
      top: 0;
          height: 100%;
          background: #f3f3f3;
          z-index: 0;
      }
      #sidebar {
          background: #DF314D;
          position: absolute;
          width: 240px;
          height: 100%;
          left: -240px;
          box-sizing: border-box;
          -moz-box-sizing: border-box;
      }
      #sidebar ul {
          margin: 0;
          padding: 0;
          list-style: none;
      }
      #sidebar ul li {
          margin: 0;
      }
      #sidebar ul li a {
          padding: 15px 20px;
          font-size: 16px;
          font-weight: 100;
          color: white;
          text-decoration: none;
          display: block;
          border-bottom: 1px solid #C9223D;
          -webkit-transition:  background 0.3s ease-in-out;
          -moz-transition:  background 0.3s ease-in-out;
          -ms-transition:  background 0.3s ease-in-out;
          -o-transition:  background 0.3s ease-in-out;
          transition:  background 0.3s ease-in-out;
      }
      #sidebar ul li:hover a {
          background: #C9223D;
      }
      .main-content {
          width: 100%;
          height: 100%;
          padding: 10px;
          box-sizing: border-box;
          -moz-box-sizing: border-box;
          position: relative;
      }
      .main-content .content{
          box-sizing: border-box;
          -moz-box-sizing: border-box;
      padding-left: 60px;
      width: 100%;
      }
      .main-content .content h1{
          font-weight: 400;
      }
      .main-content .content p{
          width: 100%;
          line-height: 160%;
      }
      .main-content #sidebar-toggle {
          background: #545353;
          border-radius: 3px;
          display: block;
          position: relative;
          padding: 10px 7px;
          float: left;
      }
      .main-content #sidebar-toggle .bar{
           display: block;
          width: 18px;
          margin-bottom: 3px;
          height: 2px;
          background-color: #fff;
          border-radius: 1px;   
      }
      .main-content #sidebar-toggle .bar:last-child{
           margin-bottom: 0;   
      }
	  
	button.accordion {
	background: #FFF url(logos/serv.png) no-repeat 1px ;
	margin-bottom: 5px;
    background-color: #eee;
    color: white;
    cursor: pointer;
    padding: 0.8%;
    width: 100%;
    border: none;
    text-align: left;
    outline: none;
    font-size: 15px;
    transition: 0.4s;
}

button.accordion.active, button.accordion:hover {
    background-color: #ddd;
}

button.accordion:after {
    content: '\002B';
    color: #777;
    font-weight: bold;
    float: right;
    margin-left: 5px;
}

button.accordion.active:after {
    content: "\2212";
}

div.panel {
    padding: 12px 0px 0 0px;
    background-color: white;
    max-height: 0;
    overflow: hidden;
    transition: max-height 0.2s ease-out;
}

ul.tab li a:focus, .active {
        color: #000000 !important;
}

input, select {
    width: 100%;
}

tr:hover {background-color: white}

.search_categories{
font-family: "Raleway";
    font-size: 14px;
    padding: 10px 10px 9px 14px;
    background: #fff;
        border: none;
    overflow: hidden;
    position: relative;
}

.search_categories .select{
    background:transparent;
      border:0;
  width: 120%;
  background:url('arrow.png') no-repeat;
  background-position:80% center;
}

.search_categories .select select{

  background: transparent;
  line-height: 1;
  border:none !important;
  padding: 0;
  border-radius: 0;
  width: 120%;
  position: relative;
  z-index: 10;
  font-size: 1em;
}

input[type=date] {
font-family: "Raleway";
font-size: 14px;
border: none;
 outline: none;
padding: 9px 0 3px 17px;
}

input[type=text] {
font-family: "Raleway";
border: none;
margin: 3px 20px 17px;
color: black;
padding: 8px 0px 0px 0px;
border: none;
font: 400 14px 'Cabin', sans-serif;
    background: #FFF;
	    max-width: 100%;

}
	  
    </style>
    <script type="text/javascript">
      $(window).load(function(){
        $("[data-toggle]").click(function() {
          var toggle_el = $(this).data("toggle");
          $(toggle_el).toggleClass("open-sidebar");
        });
         $(".swipe-area").swipe({
              swipeStatus:function(event, phase, direction, distance, duration, fingers)
                  {
                      if (phase=="move" && direction =="right") {
                           $(".container").addClass("open-sidebar");
                           return false;
                      }
                      if (phase=="move" && direction =="left") {
                           $(".container").removeClass("open-sidebar");
                           return false;
                      }
                  }
          }); 
      });
      
	  
	  
		  function validate(evt) {
	  var theEvent = evt || window.event;
	  var key = theEvent.keyCode || theEvent.which;
	  key = String.fromCharCode( key );
	  var regex = /[0-9]|\./;
	  if( !regex.test(key) ) {
		theEvent.returnValue = false;
		if(theEvent.preventDefault) theEvent.preventDefault();
	  }
	}
    </script>
  </head>
  <body>
    <div class="container">
      <div id="sidebar">
		<center><img src="https://image.flaticon.com/icons/svg/265/265729.svg"></center>
          <ul>
  <li><a href="demo3.php">Início</a></li>
              <li><a href="demo5.php">Serviços</a></li>
			  <li><a href="demo2.php">Perfil</a></li>
			  <li><a href="demo4.php">Histórico</a></li>
              <li><a href="logout.php?logout">Sair</a></li>
			  		  	<?php
	$q = mysql_query ("SELECT CodTipoU from utilizador where CodTipoU=1 and CodUser=".$_SESSION['user']);
	$num = mysql_num_rows ($q);
	if($num == '1')	
	{
	echo '<a href="admin/index.php" target="_blank">';
	echo '<input name="admin" type="submit" class="btnadmin" value="Painel Administrador" />' ;
	echo '</a>';
	}
	?>
          </ul>
          </ul>
      </div>
      <div class="main-content">
          <div class="swipe-area"></div>
          <a href="#" data-toggle=".container" id="sidebar-toggle">
              <span class="bar"></span>
              <span class="bar"></span>
              <span class="bar"></span>
          </a>
          <div class="content">
              
		<h2>Agendar Despesa</h2>
		<div class="page-title">
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
    echo "<select name=tipod class=search_categories>";
	$q = mysql_query ("select CodTipoD, nome from tipodesp");
	$num = mysql_num_rows ($q);
	for ($i = 0; $i < $num; $i++)
	{
		$reg = mysql_fetch_assoc($q);
		echo "<option value='" . $reg['CodTipoD'] ."'>" . $reg['nome'] ."</option>";
	}
	echo "</select>";
	?></td></tr>
	<tr><th>Data Agendada</th><td><input type="date"  name="date" value="<?php echo $date ?>" /> </td></tr>
	<tr><th>Veículo (KM)</th><td><input type="text" onkeypress="validate(event)" placeholder="KM" maxlength="100"  name="veikm" value="<?php echo $veikm ?>" /> </td></tr>
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
		 <button class="btnn" type=button onClick="parent.location='demo5.php'">Voltar</button>  
				 </p> 
			

    </form>
  </body>
</html>