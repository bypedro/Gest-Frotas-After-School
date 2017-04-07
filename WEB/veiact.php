<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Início</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="jquery.touchSwipe.min.js"></script>
	<link rel="stylesheet" href="style.css" type="text/css" />
<<<<<<< HEAD
	
	
=======
>>>>>>> refs/remotes/origin/master
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
 
<<<<<<< HEAD
=======

>>>>>>> refs/remotes/origin/master
 

// Attempt select query execution
$sql = "SELECT * FROM veicondu, utilizador, veiculos where veicondu.CodUser=utilizador.CodUser and veicondu.CodVei=veiculos.CodVei and EmUso='Sim' and utilizador.CodUser=".$_SESSION['user'] . " LIMIT 1 "  ;
if($result = mysqli_query($link, $sql)){
    if(mysqli_num_rows($result) > 0){
        echo "<table>";
            echo "<tr>";
                echo "<th>Quando Começou</th>";
<<<<<<< HEAD
                echo "<th>Marca</th>";
                echo "<th>Modelo</th>";
				echo "<th>Matricula</th>";
				echo "<th>Ano</th>";
				echo "<th>Notas</th>";
				echo "<th>Opção</th>";
				
=======
                echo "<th>Quando Acabou</th>";
                echo "<th>Trabalhador</th>";
				echo "<th>Matricula Veículo</th>";
				echo "<th>Notas</th>";
>>>>>>> refs/remotes/origin/master
            echo "</tr>";
        while($row = mysqli_fetch_array($result)){
            echo "<tr>";
                echo "<td>" . $row['Quando_Comecou'] . "</td>";
<<<<<<< HEAD
                echo "<td>" . $row['Marca'] . "</td>";
				echo "<td>" . $row['Modelo'] . "</td>";
                echo "<td>" . $row['Matricula'] . "</td>";
				echo "<td>" . $row['Ano'] . "</td>";
				echo "<td >" . $row['Notas'] . "</td>";
				echo "<td>" . "<a href='#.php?id=".$row['CodVeiC']."' target='_blank'><img src='logos/view.png' class='imgg' /></a>" . "</td>"; 
=======
                echo "<td>" . $row['Quando_Acabou'] . "</td>";
                echo "<td>" . $row['Nome_Registo'] . "</td>";
                echo "<td>" . $row['Matricula'] . "</td>";
				echo "<td>" . $row['Notas'] . "</td>";
>>>>>>> refs/remotes/origin/master

            echo "</tr>";
        }
        echo "</table>";
        // Close result set
        mysqli_free_result($result);
    } else{
        echo "<table>";
            echo "<tr>";
                echo "<th>Quando Começou</th>";
<<<<<<< HEAD
                echo "<th>Marca</th>";
                echo "<th>Modelo</th>";
				echo "<th>Matricula</th>";
				echo "<th>Notas</th>";
				
=======
                echo "<th>Quando Acabou</th>";
                echo "<th>Trabalhador</th>";
				echo "<th>Matricula Veículo</th>";
				echo "<th>Notas</th>";
>>>>>>> refs/remotes/origin/master
            echo "</tr>";
        echo "</table>";
    }
} else{
    echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
 
// Close connection
mysqli_close($link);
?>
</body>
</html>