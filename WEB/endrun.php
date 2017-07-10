<html>
<body>
<?php
ob_start();
session_start();
require_once 'dbconnect.php';

// if session is not set this will redirect to login page
if( !isset($_SESSION['user']) ) {
  header("Location: index.php");
  exit;
}

$query1=mysql_query("SELECT CodVeiC FROM  veicondu
                    WHERE EmUso='Sim' AND CodUser = ".$_SESSION['user']);
$userRow=mysql_fetch_array($query1);

$query2=mysql_query("UPDATE veicondu SET EmUso = 'Nao', Quando_Acabou = CURDATE() WHERE ".$_SESSION['user'] . " AND CodVeiC = " .$userRow['CodVeiC']);

if($query2)
{
header('location:painel.php');
}

?>
</body>
</html>
