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
          <li><a href="logout.php">Sair</a></li>
    </ul>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>
  <script src="js/index.js"></script>

  <div class="container">

  <h1>Lista Despesas<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
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

  $sql=mysqli_query($con, "SELECT despesas.CodDesp, despesas.Data_Agendada, despesas.Veiculo_Km_Agendado, despesas.Valor, veiculos.Matricula, fornecedores.nome as nomef, tipodesp.nome, despesas.Nota from despesas, veiculos, fornecedores, utilizador, tipodesp
                            WHERE Efetuada='Sim' AND despesas.codVei=veiculos.codVei AND despesas.codForn=fornecedores.CodForn AND despesas.CodUser=utilizador.CodUser AND despesas.CodTipoD=tipodesp.CodTipoD AND utilizador.CodUser=".$_SESSION['user'] . " ORDER BY despesas.CodDesp
                            DESC LIMIT $start, $limit") or die(mysqli_error($con));

?>
<button class="btnfilter" type=button onClick="showfilter()">Filtro</button>
<input type="text" id="myInput" onkeyup="myFunction()" placeholder="Procurar por data.." title="Type in a name">

<table align='center' id="myTable" class='table-fill'>
  <?php
  echo "<tr>";
        echo "<th>Data Agendada</th>";
        echo "<th>Veiculo (KM)</th>";
        echo "<th>Valor (€)</th>";
        echo "<th>Veículo</th>";
        echo "<th>Fornecedor</th>";
        echo "<th>Despesa</th>";
        echo "<th>Notas</th>";
  echo "</tr>";

  ?>
  <?php

    while($row=mysqli_fetch_assoc($sql))
    {

  ?>
  <?php

  echo "<tr>";
        echo "<td>" . $row['Data_Agendada'] . "</td>";
        echo "<td>" . $row['Veiculo_Km_Agendado'] . "</td>";
        echo "<td>" . $row['Valor'] . "</td>";
        echo "<td>" . $row['Matricula'] . "</td>";
        echo "<td>" . $row['nomef'] . "</td>";
        echo "<td>" . $row['nome'] . "</td>";
        echo "<td>" . $row['Nota'] . "</td>";
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
