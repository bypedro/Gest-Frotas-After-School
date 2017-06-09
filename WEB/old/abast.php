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
$sql = "SELECT * FROM veiabast, utilizador, veiculos, fornecedores where veiabast.CodUser=utilizador.CodUser and veiabast.CodVei=veiculos.CodVei and veiabast.CodForn=fornecedores.CodForn and utilizador.CodUser=".$_SESSION['user'] . " ORDER BY CodVeiAbast DESC LIMIT 2 "  ;
if($result = mysqli_query($link, $sql)){
    if(mysqli_num_rows($result) > 0){
        echo "<table>";
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
        while($row = mysqli_fetch_array($result)){
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
        }
        echo "</table>";
        // Close result set
        mysqli_free_result($result);
    } else{
        echo "No records matching your query were found.";
    }
} else{
    echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
 
// Close connection
mysqli_close($link);
?>
</body>
</html>