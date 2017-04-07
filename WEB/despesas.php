<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Início</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="jquery.touchSwipe.min.js"></script>
	<link rel="stylesheet" href="style.css" type="text/css" />
	</head>
	
<body>


<?php
/* Attempt MySQL server connection. Assuming you are running MySQL
server with default setting (user 'root' with no password) */
$link = mysqli_connect("localhost", "root", "", "frotas");
 
// Check connection
if($link === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
 
ob_start();
	session_start();
	require_once 'dbconnect.php';
	
	// if session is not set this will redirect to login page
	if( !isset($_SESSION['user']) ) {
		header("Location: index.php");
		exit;
	} 
  

// Attempt select query execution
<<<<<<< HEAD
$sql = "SELECT * from despesas, veiculos, fornecedores, utilizador, tipodesp WHERE Efetuada='Sim' and despesas.codVei=veiculos.codVei AND despesas.codForn=fornecedores.CodForn and despesas.CodUser=utilizador.CodUser and despesas.CodTipoD=tipodesp.CodTipoD and utilizador.CodUser=".$_SESSION['user'] . " ORDER BY CodDesp DESC LIMIT 2 ";
=======
$sql = "SELECT * from despesas, veiculos, fornecedores, utilizador, tipodesp WHERE despesas.codVei=veiculos.codVei AND despesas.codForn=fornecedores.CodForn and despesas.CodUser=utilizador.CodUser and despesas.CodTipoD=tipodesp.CodTipoD and utilizador.CodUser=".$_SESSION['user'] . " ORDER BY CodDesp DESC LIMIT 2 ";
>>>>>>> refs/remotes/origin/master
if($result = mysqli_query($link, $sql)){
    if(mysqli_num_rows($result) > 0){
        echo "<table>";
            echo "<tr>";
                echo "<th>Data Efectuada</th>";
                echo "<th>Veiculo (KM)</th>";
                echo "<th>Valor (€)</th>";
				echo "<th>Veículo</th>";
				echo "<th>Fornecedor</th>";
				echo "<th>Despesa</th>";
<<<<<<< HEAD
				echo "<th>Notas</th>";
				echo "<th>Opção</th>";
=======
>>>>>>> refs/remotes/origin/master
            echo "</tr>";
        while($row = mysqli_fetch_array($result)){
            echo "<tr>";
                echo "<td>" . $row['Data_Efetuada'] . "</td>";
                echo "<td>" . $row['Veiculo_Km'] . "</td>";
                echo "<td>" . $row['Valor'] . "</td>";
                echo "<td>" . $row['Matricula'] . "</td>";
				echo "<td>" . $row['nomef'] . "</td>";
				echo "<td>" . $row['nome'] . "</td>";
<<<<<<< HEAD
				echo "<td>" . $row['Nota'] . "</td>";
				echo "<td>" . "<a href='#.php?id=".$row['CodDesp']."' target='_blank'><img src='logos/view.png' class='imgg' /></a>" . "</td>"; 
=======
>>>>>>> refs/remotes/origin/master
            echo "</tr>";
			
        }
        // Close result set
        mysqli_free_result($result);
    } else{
                echo "<table>";
            echo "<tr>";
                echo "<th>Data Efectuada</th>";
                echo "<th>Veiculo (KM)</th>";
                echo "<th>Valor (€)</th>";
				echo "<th>Veículo</th>";
				echo "<th>Fornecedor</th>";
				echo "<th>Despesa</th>";
				echo "<th>Efectuada</th>";
				echo "<th>Agendamento (KM)</th>";
				echo "<th>Data Agendada</th>";
            echo "</tr>";
    }
} else{
    echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
 
// Close connection
mysqli_close($link);
?>
</body>
</html>