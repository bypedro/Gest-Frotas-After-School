<?php

  ob_start();
  session_start();
  require_once 'dbconnect.php';
  include 'functions.php';

  checkolddesp();

  // if session is not set this will redirect to login page
  if( !isset($_SESSION['user']) ) {
    header("Location: index.php");
    exit;
  }

?>
<html>
<head>
  <meta charset="UTF-8">
  <title>Início</title>
      <link rel="stylesheet" href="css/style.css">
      <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Oswald" />
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

  $res2=mysql_query("SELECT quando_comecou, quando_acabou FROM veicondu WHERE EmUso = 'sim' AND CodUser = " .$_SESSION['user']);
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
  <th class="trindex">DESPESAS (€)</th>
  <td class="tdindex">234€</td>
  </tr>
  <tr>
  <div class="secondtitle">Serviço Ativo</div>
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

</body>
</html>
