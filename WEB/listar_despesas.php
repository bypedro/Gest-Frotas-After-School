<?php
ob_start();
session_start();
$con=mysqli_connect("localhost","root","") or die(mysqli_error());
mysqli_select_db($con,"frotas") or die(mysqli_error($con));
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

  <h1>Lista Despesas Agendadas<div class="tooltip"><img src="logos/info.png" class="imgaddd"><span class="tooltiptext">Home</span></div></h1>
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

  $sql=mysqli_query($con, "SELECT * from despesas, veiculos, fornecedores, utilizador, tipodesp WHERE Efetuada='Nao' AND despesas.codVei=veiculos.codVei AND despesas.codForn=fornecedores.CodForn AND despesas.CodUser=utilizador.CodUser AND despesas.CodTipoD=tipodesp.CodTipoD ORDER BY despesas.CodDesp DESC LIMIT $start, $limit") or die(mysqli_error($con));

?>

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
        echo "<th>Estado</th>";
        echo "<th class='optionsop'>Opção</th>";
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
        echo "<td>" . $row['Estado'] . "</td>";
        echo "<td class='options'>" . "<a href='edit.php?id=".$row['CodDesp']."' target='_blank'><img title='Editar Despesa Agendada' src='logos/edit.png' class='imgg' /></a>" . "<a href='done.php?id=".$row['CodDesp']."' target='_blank'><img title='Marcar Como Efetuado' src='logos/done.png' class='imgg' /></a>" . "<a href='delete.php?id=".$row['CodDesp']."' target='_blank'><img title='Remover' src='logos/remove.png' class='imgg' /></a>" . "</td>"; 
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
