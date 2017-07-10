<html>
<body>
<?php
include('dbconnect.php');
if(isset($_GET['id']))
{
$id=$_GET['id'];
$query1=mysql_query("update despesas set efetuada='Sim', Estado='Efetuado' where CodDesp='$id'");
if($query1)
{
header('location:demo5.php');
}
}
?>
</body>
</html>