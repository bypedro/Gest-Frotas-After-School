<html>
<body>
<?php
include('dbconnect.php');
if(isset($_GET['id']))
{
$id=$_GET['id'];
$query1=mysql_query("update manutencao set efetuada='Sim' where CodManu='$id'");
if($query1)
{
header('location:services.php');
}
}
?>
</body>
</html>
