<?php
include('dbconnect.php');
if (!isset($_FILES['image']['tmp_name'])) {
	echo "";
	}else{
	$file=$_FILES['image']['tmp_name'];
	$image= addslashes(file_get_contents($_FILES['image']['tmp_name']));
	$image_name= addslashes($_FILES['image']['name']);

			move_uploaded_file($_FILES["image"]["tmp_name"],"photos/" . $_FILES["image"]["name"]);

			$location="photos/" . $_FILES["image"]["name"];
			$caption=$_POST['caption'];

			$save=mysql_query("INSERT INTO photos (location, CodUser) VALUES ('$location', '1')");
			header("location: perfil.php");
			exit();
	}
?>
