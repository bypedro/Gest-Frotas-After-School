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

  $res=mysql_query("SELECT tipouser.designacao, utilizador.location, utilizador.Nome_Registo
                      FROM utilizador, tipouser
                        WHERE tipouser.CodTipoU=utilizador.CodTipoU and utilizador.CodUser=" .$_SESSION['user']);

	$userRow=mysql_fetch_array($res);

?>

<html >
<head>
  <meta charset="UTF-8">
  <title>Painel Utilizador</title>
  <link rel="stylesheet" href="css/style.css">
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
        <li><a href="#">Defenicoes</a></li>
        <li><a href="#">Sair</a></li>
    </ul>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>
  <script src="js/index.js"></script>

  <div class="container">

  <h1>Serviços <div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Nas despesas, na agenda e no abastecimento, aparecem somente os dois registos mais recentes.</span></div></h1>
    <div class="page-title">
    </div>
    <br>
  <button class="accordion"><img src="logos/calendar.png" class="imggg"><h3>SERVIÇO ATIVO</h3>  </button>
  <div class="panel">
  <iframe src="veiact.php" frameborder="0" width="100%" height="180px"></iframe>
  </div>

  <button class="accordion"><img src="logos/notes.png" class="imggg"><h3>DESPESAS</h3> </button>
  <div class="panel">
    <iframe src="despesas.php" frameborder="0" width="100%" height="250px"></iframe><h6>Mais despesas associadas: <?php despesacount(); ?> !</h6>
    <p align="right"><?php cantdeclare(); ?> <a href="listar_despesas.php"><img src="logos/file.png" title="Ver Lista" class="imgadd"></a></p>
  </div>

  <button class="accordion"><img src="logos/wrench.png" class="imggg"><h3>MANUTENÇÕES</h3> </button>
  <div class="panel">
    <iframe src="manutencao.php" frameborder="0" width="100%" height="250px"></iframe><h6>Mais manutenções associadas: <?php manucount(); ?> !</h6>
    <p align="right"><?php cantdeclare3(); ?><a href="listar_manutencao.php"><img src="logos/file.png" title="Ver Histórico" class="imgadd"></a></p>
  </div>

  <button class="accordion"><img src="logos/bell.png" class="imggg"><h3>AGENDA</h3>
  </button>
  <div class="panel">
    <iframe src="agenda.php" frameborder="0" width="100%" height="250px"></iframe><h6>Mais despesas agendadas: <?php agendacount(); ?> !</h6>
    <p align="right"><?php cantdeclare1(); ?>  <a href="listar_despesas_agendadas.php"><img src="logos/file.png" title="Ver Lista" class="imgadd"></a></p>
    <br>
      <iframe src="manutencao_agendadas.php" frameborder="0" width="100%" height="250px"></iframe><h6>Mais manutenções agendadas: <?php manucounts(); ?> !</h6>
      <p align="right"><?php cantdeclare4(); ?>  <a href="listar_manutencoes_agendadas.php"><img src="logos/file.png" title="Ver Lista" class="imgadd"></a></p>
  </div>

  <button class="accordion"><img src="logos/fuel.png" class="imggg"><h3>ABASTECIMENTO</h3> </button>
  <div class="panel">
    <iframe src="abast.php" frameborder="0" width="100%" height="250px"></iframe><h6>Mais abastecimentos associados: <?php abastcount(); ?> !</h6>
    <p align="right"><?php cantdeclare2(); ?><a href="listar_abastecimentos.php"><img src="logos/file.png" title="Ver Histórico" class="imgadd"></a></p>
  </div>



  <script>
  var acc = document.getElementsByClassName("accordion");
  var i;

  for (i = 0; i < acc.length; i++) {
    acc[i].onclick = function() {
      this.classList.toggle("active");
      var panel = this.nextElementSibling;
      if (panel.style.maxHeight){
        panel.style.maxHeight = null;
      } else {
        panel.style.maxHeight = panel.scrollHeight + "px";
      }
    }
  }
  </script>

</div>

</body>
</html>
