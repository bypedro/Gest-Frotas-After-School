<head>
      <link rel="stylesheet" href="css/style.css">
</head>

<?php 

  if( !isset($_SESSION['user']) ) {
    header("Location: index.php");
    exit;
  }

  require_once 'dbconnect.php';

function agendacount() {

  $sql = mysql_query("SELECT COUNT(CodDesp) AS userct 
                      FROM despesas 
                      WHERE Efetuada = 'nao' AND CodUser = ".$_SESSION['user']);

  $userCount=mysql_fetch_assoc($sql);

   if($userCount['userct'] >= 4){
      echo $userCount['userct'] - 3;
   }else{
      echo $userCount['userct'] = 0;
   }

}

function despesacount() {

  $sql = mysql_query("SELECT COUNT(CodDesp) AS userct 
                      FROM despesas 
                      WHERE Efetuada = 'sim' AND CodUser = ".$_SESSION['user']);

  $userCount=mysql_fetch_assoc($sql);
  
  if($userCount['userct'] >= 4){
      echo $userCount['userct'] - 3;
  }else{
      echo $userCount['userct'] = 0;
  }

}

function abastcount() {

  $sql = mysql_query("SELECT COUNT(CodVeiAbast) as useabast
                      FROM veiabast 
                      WHERE CodUser = ".$_SESSION['user']);

  $abastCount=mysql_fetch_assoc($sql);

  if($abastCount['useabast'] >= 4){
      echo $abastCount['useabast'] - 3;
  }else{
      echo $abastCount['useabast'] = 0;
  }
  

}


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

}

  //var_dump($id);
  die;
}

function checkolddesp () {

  $message = "yes";

  $sql5 = mysql_query("UPDATE despesas 
                        SET estado = 'Cancelado', efetuada = 'Sim' 
                        WHERE efetuada='Nao' AND data_agendada = (CURDATE() - INTERVAL 3 DAY)");

  $sql6 = "SELECT data_agendada 
            FROM despesas 
            WHERE data_agendada = (CURDATE() - INTERVAL 2 DAY)
            AND efetuada = 'nao' AND CodUser = ".$_SESSION['user'];

  $sql7 = mysql_query("SELECT data_agendada, count(data_agendada) as counter
                        FROM despesas 
                        WHERE data_agendada = (CURDATE() - INTERVAL 2 DAY)
                        AND efetuada = 'nao' AND CodUser = ".$_SESSION['user']);         
         
  $userCount=mysql_fetch_assoc($sql7);
  $result6 = mysql_query($sql6);

  if(mysql_num_rows($result6) > 0){
      echo "<div class='alert'>
      <span class='closebtn' onclick='this.parentElement.style.display='none';'>&times;</span> 
      <strong>ATENÇÃO!</strong> Tem <strong>" . $userCount['counter'] . "</strong> despesas para efetuar até hoje referente ao dia <strong>" . $userCount['data_agendada'] . "</strong> !
    </div>";
  }

}

