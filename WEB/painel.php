<?php
  ob_start();
  session_start();
  require_once 'dbconnect.php';
  include 'functions.php';

  checkolddesp();
  gestalert();

  // if session is not set this will redirect to login page
  if( !isset($_SESSION['user']) ) {
    header("Location: index.php");
    exit;

  }

  $ress=mysql_query("SELECT tipouser.designacao, utilizador.location, utilizador.senha, utilizador.CodUser, utilizador.Nome_Registo, utilizador.Nome_Proprio, utilizador.Apelido, utilizador.Genero, utilizador.Data_Nascimento, utilizador.Rua, utilizador.Email, tipouser.designacao, cidade.Nome, utilizador.N_Telemovel
                      FROM utilizador, cidade, tipouser, pais
                        WHERE pais.CodPais=cidade.CodPais and tipouser.CodTipoU=utilizador.CodTipoU and cidade.CodCi=utilizador.CodCi and utilizador.CodUser=" .$_SESSION['user']);
  $userRow=mysql_fetch_array($ress);

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

  <h1>Painel<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
  <div class="page-title">
  </div>

	<br>

  <?php

  $sql1 = "SELECT CodVeiC FROM veicondu WHERE EmUso = 'sim' AND CodUser = " .$_SESSION['user'];

  $result1 = mysql_query($sql1);

  if(mysql_num_rows($result1) > 0){
    echo "<div class='boxtt'>";
    echo "<h2>EM SERVIÇO</h2>";
    echo "<h4>SIM</h4>";
    echo "</div>";

  }else{
    echo "<div class='boxtt'>";
    echo "<h2>EM SERVIÇO</h2>";
    echo "<h4>NAO</h4>";
    echo "</div>";
  }

  $res=mysql_query("SELECT count(CodVeiC) AS work_count FROM veicondu WHERE EmUso = 'Nao' AND CodUser =".$_SESSION['user']);
  $userRow=mysql_fetch_array($res);

  $res1=mysql_query("SELECT SUM(valor) AS work_value FROM despesas WHERE CodUser =".$_SESSION['user']);
  $userRow1=mysql_fetch_array($res1);

  $res2=mysql_query("SELECT NOW() as endate, quando_comecou, quando_acabou FROM veicondu WHERE EmUso = 'sim' AND CodUser = " .$_SESSION['user']);
  $userRow2=mysql_fetch_array($res2);

  ?>

  <div class="boxt">
  <h2>CONCLUIDOS</h2>
  <h4><?php echo $userRow['work_count'] ?></h4>
  </div>

  <div class="boxtttt">
  <h2>DESPESAS (€)</h2>
  <h4><?php echo $userRow1['work_value'] ?>€</h4>
  </div>

  <table class="indextabel">
  <tr>
  <th class="trindex">DATA INICIAL</th>
  <td class="tdindex"><?php echo $userRow2['quando_comecou'] ?></td>
  </tr>
  <tr>
  <th class="trindex">DATA FINAL ESPERADA</th>
  <td class="tdindex"><?php echo $userRow2['quando_acabou'] ?></td>
  </tr>
  <tr>
  <th class="trindex">OPÇÕES</th>
  <td class="tdindex">
    <?php noservice(); ?>
    <button src="logos/checked.png"  id="imdone" class="btnpainel" type=button><img src="logos/parked-car.png" class="imgdone">TERMINAR</button>
    <button class="btnpainel2" id="imdesp" type=button onClick="parent.location='inserir_despesa.php'"><img src="logos/painelfuel.png" class="imgaci">DESPESAS</button>
    <button class="btnpainel1" id="imaci" type=button onClick=""><img src="logos/tools.png" class="imgaci">ACIDENTE</button>
  </td>
  </tr>
  <tr>

    <div id="myModal" class="modal">

    <!-- Modal content -->
    <div class="modal-content">
      <span class="close">&times;</span>
      <button type="button" class="btnpop" data-dismiss="modal" onClick="parent.location='endrun.php'">Terminar</button>
      <h2>Deseja terminar o serviço?</h2>
      <div class="modal-footer">
        Fim Serviço: <b><?php echo $userRow2['endate'] ?></b>
    </div>

  </div>

  <!--<th class="tdindex">
    <table id="t01">
    <tr>
      <th class="sth">Efetuar</th>
      <th class="tth">Trocar</th>
    </tr>
  </table>
  </th>-->
  </td>
  </tr>
  </table>

  <div class="secondtitle">Despesas Urgentes</div>
  <iframe src="despesas_urgentes.php" frameborder="0" width="100%" height="100%"></iframe>
  </div>

  <script>
  // Get the modal
  var modal = document.getElementById('myModal');

  // Get the button that opens the modal
  var btn = document.getElementById("imdone");

  // Get the <span> element that closes the modal
  var span = document.getElementsByClassName("close")[0];

  // When the user clicks the button, open the modal
  btn.onclick = function() {
      modal.style.display = "block";
  }

  // When the user clicks on <span> (x), close the modal
  span.onclick = function() {
      modal.style.display = "none";
  }

  // When the user clicks anywhere outside of the modal, close it
  window.onclick = function(event) {
      if (event.target == modal) {
          modal.style.display = "none";
      }
  }

</script>

</body>
</html>
