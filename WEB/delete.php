<?php
  ob_start();
  include("dbconnect.php");
  if(isset($_GET['id'])!="")
  {
  $delete=$_GET['id'];
  $delete=mysql_query("DELETE FROM despesas WHERE CodDesp='$delete'");
  if($delete)
  {
      header("Location:demo5.php");
  }
  else
  {
      echo mysql_error();
  }
  }
  ob_end_flush();
?>