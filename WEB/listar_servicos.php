<?php
ob_start();
session_start();
$con=mysqli_connect("localhost","root","") or die(mysqli_error());
mysqli_select_db($con,"frotas") or die(mysqli_error($con));
include 'functions.php';

  $ress=mysql_query("SELECT tipouser.designacao, utilizador.location, utilizador.Nome_Registo
                      FROM utilizador, tipouser
                        WHERE tipouser.CodTipoU=utilizador.CodTipoU and utilizador.CodUser=" .$_SESSION['user']);
  $usersRow=mysql_fetch_array($ress);
?>
<html style="overflow: hidden";>
<head>
  <meta charset="UTF-8">
  <title>Lista Despesas Agendadas</title>
      <link rel="stylesheet" href="css/style.css">
      <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Oswald" />
      <script src="js/validations.js"></script>
</head>

<body>

  <div class="topnav">
    <div class="topp"><?php echo $usersRow['Nome_Registo']; ?></div><div class="topd"><?php echo $usersRow['designacao']; ?></div>
     <?php echo '<p><img class="imgmini" src="'.$usersRow['location'].'"></p>'; ?>
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

      <h1>Listar Serviços<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
      <div class="page-title">
      </div>
      <br>

<?php
  $start=0;
  $limit=10;
  $page=0;
  if(isset($_GET['page']))
  {
    $page=$_GET['page'];
    $start=($page-1)*$limit;
  }

  $sql=mysqli_query($con, "SELECT veicondu.CodVeiC, veicondu.Quando_Comecou, veicondu.Quando_Acabou, veiculos.Matricula, veiculos.Modelo, veicondu.Notas
                            FROM veicondu, utilizador, veiculos
                            WHERE veicondu.CodUser=utilizador.CodUser AND veicondu.CodVei=veiculos.CodVei AND EmUso='Nao' AND utilizador.CodUser=".$_SESSION['user']  . " ORDER BY veicondu.CodVeiC
                            DESC LIMIT $start, $limit") or die(mysqli_error($con));

?>
<button class="btnfilter" type=button onClick="showfilter()">Filtro</button>
<input type="text" id="myInput" onkeyup="myFunction()" placeholder="Procurar por data.." title="Type in a name">

<table align='center' id="myTable" class='table-fill'>
  <?php
  echo "<tr>";
        echo "<th>Quando Começou</th>";
        echo "<th>Quando Acabou</th>";
        echo "<th>Matrícula</th>";
        echo "<th>Modelo</th>";
        echo "<th>Notas</th>";
        echo "<th class='optionsop'>Opção</th>";
  echo "</tr>";

  ?>
  <?php

    while($row=mysqli_fetch_assoc($sql))
    {

  ?>
  <?php

    echo "<tr>";
        echo "<td>" . $row['Quando_Comecou'] . "</td>";
        echo "<td>" . $row['Quando_Acabou'] . "</td>";
        echo "<td>" . $row['Matricula'] . "</td>";
        echo "<td>" . $row['Modelo'] . "</td>";
        echo "<td>" . $row['Notas'] . "</td>";
        echo "<td class='options'>" . "<a href='view.php?id=".$row['CodVeiC']."' target='_blank'><img title='Editar Despesa Agendada' src='logos/pdf.png' class='imgg' /></a>";
    echo "</tr>";



  ?>
  <?php

    }
  ?>

  <tr>
    <td colspan='3'>

  <?php

  $rows=mysqli_num_rows(mysqli_query($con, "select * from despesas WHERE Efetuada='Nao'"));
  $total=ceil($rows/$limit);
  if(isset($page))
  {
    if($page>1)
    {
      echo "<a href='?page=".($page-1)."' class='paging'>Anterior</a>";
    }
  }

  for($i=1;$i<=$total;$i++)
  {
    echo "<a class='paging' href='?page=".$i."'>".$i."</a>";
  }

  if($page!=$total)
  {
    echo "<a class='paging' href='?page=".($page+1)."' class=paging''>Próximo</a>";
  }

  ?>
  </td>
  </tr>
</table>
  </div>

</body>
</html>
