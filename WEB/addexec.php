<?php
ob_start();
session_start();
include('dbconnect.php');

$user_id = $_SESSION['user'];

if (!isset($_FILES['image']['tmp_name'])) {
	echo "";
	}else{
	$file=$_FILES['image']['tmp_name'];
	$image= addslashes(file_get_contents($_FILES['image']['tmp_name']));
	$image_name= addslashes($_FILES['image']['name']);

			move_uploaded_file($_FILES["image"]["tmp_name"],"photos/" . $_FILES["image"]["name"]);

			$location="photos/" . $_FILES["image"]["name"];
			$caption=$_POST['caption'];

			$save=mysql_query("UPDATE utilizador SET location='$location' WHERE CodUser = '$user_id'");
			header("location: perfil.php");
			exit();
	}
?>
