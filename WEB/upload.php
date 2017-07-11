<?php
  ob_start();
  session_start();
  require_once 'dbconnect.php';

  // if session is not set this will redirect to login page
  if( !isset($_SESSION['user']) ) {
    header("Location: index.php");
    exit;

  }
?>

<style type="text/css">
</style>

<form action="addexec.php" method="post" enctype="multipart/form-data" name="addroom">
 Select Image: <br />
 <input type="file" name="image" class="ed"><br />
 <br />
 <input type="submit" name="Submit" value="Upload" id="button1" />
 </form>
