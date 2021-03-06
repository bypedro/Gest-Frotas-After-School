<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Início</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="jquery.touchSwipe.min.js"></script>
	<link rel="stylesheet" href="css/style.css">
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
$sql = "SELECT despesas.CodDesp, despesas.Data_Agendada, despesas.Valor, veiculos.Matricula, fornecedores.nome AS nomef, tipodesp.nome, DATEDIFF(CURDATE(), data_agendada) as datediff
          FROM despesas, veiculos, fornecedores, utilizador, tipodesp
          WHERE data_agendada <= (CURDATE() - INTERVAL 5 DAY) AND Efetuada='Nao' AND despesas.codVei=veiculos.codVei
          AND despesas.codForn=fornecedores.CodForn AND despesas.CodUser=utilizador.CodUser
          AND despesas.CodTipoD=tipodesp.CodTipoD AND utilizador.CodUser = ".$_SESSION['user'] . " ORDER BY Data_Efetuada DESC";

if($result = mysqli_query($link, $sql)){
    if(mysqli_num_rows($result) > 0){
        echo "<table>";
        echo "<th  style=text-align:center;>Data Agendada</th>";
        echo "<th style=text-align:center;>Valor (€)</th>";
        echo "<th style=text-align:center;>Veículo</th>";
        echo "<th style=text-align:center;>Fornecedor</th>";
        echo "<th style=text-align:center;>Despesa</th>";
        echo "<th style=text-align:center;>Dias Passados</th>";
        echo "<th class='optionsop' style=text-align:center;>Opção</th>";
            echo "</tr>";
        while($row = mysqli_fetch_array($result)){
            echo "<tr>";
            echo "<td style=text-align:center;>" . $row['Data_Agendada'] . "</td>";
            echo "<td style=text-align:center;>" . $row['Valor'] . "</td>";
            echo "<td style=text-align:center;>" . $row['Matricula'] . "</td>";
            echo "<td style=text-align:center;>" . $row['nomef'] . "</td>";
            echo "<td style=text-align:center;>" . $row['nome'] . "</td>";
            echo "<td style=text-align:center;>" . $row['datediff'] . "</td>";
				        echo "<td class='options'>" . "<a href='edit.php?id=".$row['CodDesp']."' target='_blank'><img title='Editar Despesa Agendada' src='logos/edit.png' class='imgg' /></a>" . "<a href='done.php?id=".$row['CodDesp']."' target='_blank'><img title='Marcar Como Efetuado' src='logos/done.png' class='imgg' /></a>" . "<a href='delete.php?id=".$row['CodDesp']."' target='_blank'><img title='Remover' src='logos/remove.png' class='imgg' /></a>" . "</td>";
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
            echo "<th class='optionsop'>Opção</th>";
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
