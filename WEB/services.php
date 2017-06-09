<!DOCTYPE html>

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
  $res=mysql_query("SELECT * from utilizador, veiculos, tipocom, tipovei where veiculos.CodTipoV=tipovei.CodTipoV and veiculos.CodTipoC=tipocom.CodTipoC and CodUser=".$_SESSION['user']);
  $userRow=mysql_fetch_array($res);
  
  
?>

<html >
<head>
  <meta charset="UTF-8">
  <title>Painel Utilizador</title>
  <link rel="stylesheet" href="css/style.css">
</head>

<body>
  <ul class="menu">

      <li title="home"><a href="#" class="menu-button home">menu</a></li>
      
      <li title="Home"><a href="painel.php" class="ico"></a></li>
      <li title="pencil"><a href="#" class="services">pencil</a></li>
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

  <h1>Serviços <div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Nas despesas, na agenda e no abastecimento, aparecem somente os dois registos mais recentes.</span></div></h1>
    <div class="page-title">
    </div>
    <br>
  <button class="accordion"><img src="logos/calendar.png" class="imggg"><h3>SERVIÇO ATIVO</h3>  </button>
  <div class="panel">
  <iframe src="veiact.php" frameborder="0" width="100%" height="100%"></iframe>
  </div>

  <button class="accordion"><img src="logos/notes.png" class="imggg"><h3>DESPESAS </h3> </button>
  <div class="panel">
    <iframe src="despesas.php" frameborder="0" width="100%" height="250px"></iframe><h6>Mais despesas associadas: <?php despesacount(); ?> !</h6>
    <p align="right"><a href="demo6.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a> <a href="demo9.php"><img src="logos/file.png" title="Ver Lista" class="imgadd"></a></p>
  </div>

  <button class="accordion"><img src="logos/bell.png" class="imggg"><h3>AGENDA</h3>
  </button>
  <div class="panel">
    <iframe src="agenda.php" frameborder="0" width="100%" height="250px"></iframe><h6>Mais agendas associadas: <?php agendacount(); ?> !</h6>
    <p align="right"><a href="agendar_despesa.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a> <a href="listar_despesas.php"><img src="logos/file.png" title="Ver Lista" class="imgadd"></a></p>
  </div>

  <button class="accordion"><img src="logos/fuel.png" class="imggg"><h3>ABASTECIMENTO</h3> </button>
  <div class="panel">
    <iframe src="abast.php" frameborder="0" width="100%" height="250px"></iframe><h6>Mais abastecimentos associados: <?php abastcount(); ?> !</h6>
    <p align="right"><a href="demo8.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a> <a href="#.php"><img src="logos/file.png" title="Ver Histórico" class="imgadd"></a></p>
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
