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
	// select loggedin users detail
	$res=mysql_query("SELECT tipouser.designacao, utilizador.location, utilizador.senha, utilizador.CodUser, utilizador.Nome_Registo, utilizador.Nome_Proprio, utilizador.Apelido, utilizador.Genero, utilizador.Data_Nascimento, utilizador.Rua, utilizador.Email, tipouser.designacao, cidade.Nome, utilizador.N_Telemovel
                      FROM utilizador, cidade, tipouser, pais
                        WHERE pais.CodPais=cidade.CodPais and tipouser.CodTipoU=utilizador.CodTipoU and cidade.CodCi=utilizador.CodCi and utilizador.CodUser=" .$_SESSION['user']);

	$userRow=mysql_fetch_array($res);
adada
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

  <h1>Perfil<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
  <div class="page-title">
  </div>

	<br>

<ul class="tab">
<li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Geral')" id="defaultOpen">Dados Gerais</a></li>
<li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Pessoal')">Dados Pessoais</a></li>
<li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Password')">Senha / Imagem</a></li>

</ul>

  </div>

	<p align="right">
	<button class="btnperfil" type=button onClick="parent.location='edit_user_pt1.php'">Alterar Perfil</button>
	</P>
	</div>
<div id="Geral" class="tabcontent">
<p><table cellspacing='0'>
    <tr><th>ID</th><td class="perfiltab"><?php echo $userRow['CodUser']; ?></td></tr>
    <tr><th>Utilizador</th><td class="perfiltab"><?php echo $userRow['Nome_Registo']; ?></td></tr>
    <tr><th>Email</th><td class="perfiltab"><?php echo $userRow['Email']; ?></td></tr>
    <tr><th>Cidade</th><td class="perfiltab"><?php echo $userRow['Nome']; ?></td></tr>
    <tr><th>Tipo Utilizador</th><td class="perfiltab"><?php echo $userRow['designacao']; ?></td></tr>
    </table>
    </p>
<br>

</div>

<div id="Pessoal" class="tabcontent">
<p><table cellspacing='0'>
    <tr><th>Nome Próprio</th><td class="perfiltab"><?php echo $userRow['Nome_Proprio']; ?></td></tr>
    <tr><th>Apelido</th><td class="perfiltab"><?php echo $userRow['Apelido']; ?></td></tr>
    <tr><th>Género</th><td class="perfiltab"><?php echo $userRow['Genero']; ?></td></tr>
    <tr><th>Data Nascimento</th><td class="perfiltab"><?php echo $userRow['Data_Nascimento']; ?></td></tr>
    <tr><th>Morada</th><td class="perfiltab"><?php echo $userRow['Rua']; ?></td></tr>
    <tr><th>Telemóvel</th><td class="perfiltab"><?php echo $userRow['N_Telemovel']; ?></td></tr>
    </table>
    </p>
<br>

</div>

<div id="Password" class="tabcontent">
<p><table cellspacing='0'>
    <tr><th>Senha</th><td class="perfiltab">••••••••••••••</td></tr>
		<tr><th>Imagem</th><td class="perfiltab"><?php echo '<a href="upload.php"><p><img class="imgprofile" src="'.$userRow['location'].'"></p></a>'; ?></td></tr>
    </table>
    </p>
<br>


<script>
	function openCity(evt, cityName) {
		var i, tabcontent, tablinks;
		tabcontent = document.getElementsByClassName("tabcontent");
		for (i = 0; i < tabcontent.length; i++) {
			tabcontent[i].style.display = "none";
		}
		tablinks = document.getElementsByClassName("tablinks");
		for (i = 0; i < tablinks.length; i++) {
			tablinks[i].className = tablinks[i].className.replace(" active", "");
		}
		document.getElementById(cityName).style.display = "block";
		evt.currentTarget.className += " active";
	}

	// Get the element with id="defaultOpen" and click on it
	document.getElementById("defaultOpen").click();
	</script>
</body>
</html>
