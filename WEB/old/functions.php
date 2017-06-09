<?php 

require_once 'dbconnect.php';


function exist_id () {
	
  $id=$_GET['id'];	
  $sql1 = "SELECT CodDesp 
  		   FROM despesas 
  		   WHERE CodDesp = '$id' ";
  		   
  $result1 = mysql_query($sql1);

  if(mysql_num_rows($result1) >0){

  }else{
    header("Location: demo5.php");
  }

}

function edit_id () {

  $id=$_GET['id'];	
  $sql = mysql_query("SELECT despesas.CodDesp
                        FROM despesas 
                        INNER JOIN utilizador ON despesas.CodUser=utilizador.Coduser 
                        WHERE efetuada = 'Nao' AND  despesas.CodUser = ".$_SESSION['user']);

  while ($line = mysql_fetch_assoc($sql)) {

    var_dump($line['CodDesp']);
}

  //var_dump($id);
  die;
}