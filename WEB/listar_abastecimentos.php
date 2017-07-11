<?php
ob_start();
session_start();
$con=mysqli_connect("localhost","root","") or die(mysqli_error());
mysqli_select_db($con,"frotas") or die(mysqli_error($con));
  include 'functions.php';
$sql=mysqli_query($con, "SELECT tipouser.designacao, utilizador.location, utilizador.Nome_Registo
                    FROM utilizador, tipouser
                      WHERE tipouser.CodTipoU=utilizador.CodTipoU and utilizador.CodUser=" .$_SESSION['user']) or die(mysqli_error($con));
$usersRow=mysqli_fetch_assoc($sql);
?>
<html>
<head>
  <meta charset="UTF-8">
  <title>Lista Abastecimentos</title>
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

  <h1>Lista Abastecimentos<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
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

  $sql=mysqli_query($con, "SELECT veiabast.Data, veiabast.Veiculo_Km, veiabast.Quantidade, veiabast.Valor, fornecedores.nome as nomef, veiculos.Marca, veiculos.Matricula, veiabast.Notas
                            FROM veiabast, utilizador, veiculos, fornecedores
                            WHERE veiabast.CodUser=utilizador.CodUser AND veiabast.CodVei=veiculos.CodVei AND veiabast.CodForn=fornecedores.CodForn and utilizador.CodUser = " .$_SESSION['user'] . " ORDER BY veiabast.CodVeiAbast
                            DESC LIMIT $start, $limit") or die(mysqli_error($con));

?>
<button class="btnfilter" type=button onClick="showfilter()">Filtro</button>
<input type="text" id="myInput" onkeyup="myFunction()" placeholder="Procurar por data.." title="Type in a name">

<table align='center' id="myTable" class='table-fill'>
  <?php
  echo "<tr>";
  echo "<th>Data</th>";
  echo "<th>Veículo (KM)</th>";
  echo "<th>Quantidade (L)</th>";
  echo "<th>Valor (€)</th>";
  echo "<th>Fornecedor</th>";
  echo "<th>Veículo</th>";
  echo "<th>Matrícula</th>";
  echo "<th>Notas</th>";
  echo "</tr>";

  ?>
  <?php

    while($row=mysqli_fetch_assoc($sql))
    {

  ?>
  <?php

    echo "<tr>";
    echo "<td>" . $row['Data'] . "</td>";
    echo "<td>" . $row['Veiculo_Km'] . "</td>";
    echo "<td>" . $row['Quantidade'] . "</td>";
    echo "<td>" . $row['Valor'] . "</td>";
    echo "<td>" . $row['nomef'] . "</td>";
    echo "<td>" . $row['Marca'] . "</td>";
    echo "<td>" . $row['Matricula'] . "</td>";
    echo "<td>" . $row['Notas'] . "</td>";
    echo "</tr>";



  ?>
  <?php

    }
  ?>

  <tr>
    <td colspan='3'>

  <?php

  $rows=mysqli_num_rows(mysqli_query($con, "select * from veiabast where CodUser = " .$_SESSION['user']));
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
