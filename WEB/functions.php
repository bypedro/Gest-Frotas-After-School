<head>
      <link rel="stylesheet" href="css/style.css">
      <script src="js/validations.js"></script>
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

function manucount() {

  $sql = mysql_query("SELECT COUNT(CodManu) as usermanu
                      FROM manutencao
                      WHERE efetuada='Sim' AND CodUser = ".$_SESSION['user']);

  $abastCount=mysql_fetch_assoc($sql);

  if($abastCount['usermanu'] >= 4){
      echo $abastCount['usermanu'] - 3;
  }else{
      echo $abastCount['usermanu'] = 0;
  }


}

function manucounts() {

  $sql = mysql_query("SELECT COUNT(CodManu) as usermanu
                      FROM manutencao
                      WHERE efetuada='Nao' AND CodUser = ".$_SESSION['user']);

  $abastCount=mysql_fetch_assoc($sql);

  if($abastCount['usermanu'] >= 4){
      echo $abastCount['usermanu'] - 3;
  }else{
      echo $abastCount['usermanu'] = 0;
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
                        SET efetuada = 'Sim'
                        WHERE efetuada='Nao' AND data_agendada = (CURDATE() - INTERVAL 8 DAY)");

  $sql6 = "SELECT data_agendada
            FROM despesas
            WHERE data_agendada = (CURDATE() - INTERVAL 7 DAY)
            AND efetuada = 'nao' AND CodUser = ".$_SESSION['user'];

  $sql7 = mysql_query("SELECT data_agendada, count(data_agendada) as counter
                        FROM despesas
                        WHERE data_agendada = (CURDATE() - INTERVAL 7 DAY)
                        AND efetuada = 'nao' AND CodUser = ".$_SESSION['user']);

  $userCount=mysql_fetch_assoc($sql7);
  $result6 = mysql_query($sql6);

  if(mysql_num_rows($result6) > 0){

    echo "<div class='alert'>
    <span></span>
    <strong>ATENÇÃO!</strong> Tem <strong>" . $userCount['counter'] . "</strong> despesas para efetuar até hoje referente ao dia <strong>" . $userCount['data_agendada'] . "</strong> !
  </div>";
  }

}

function ifgest(){
  $q = mysql_query ("SELECT CodTipoU from utilizador where CodTipoU=2 and CodUser=".$_SESSION['user']);
  $num = mysql_num_rows ($q);

  if($num == '1'){
    echo '<li title="pencil"><a href="services.php" class="offservices"></a></li>';

  }else {
    echo '<li title="pencil"><a href="services.php" class="services"></a></li>';
  }
}

 function gestalert() {
    $j = mysql_query ("SELECT utilizador.CodTipoU from utilizador where CodTipoU=2 and CodUser=".$_SESSION['user']);
    $nums = mysql_num_rows ($j);

    if($nums == '1'){
      echo "<div class='alert'>
      <span></span>
      <strong>Novo Utilizador!</strong> Para poder utilizar o sistema espere que o administrador <strong>ative</strong> a sua conta !
      </div>";
    }
  }

  function noservice(){
    $h = mysql_query ("SELECT CodVeic FROM veicondu WHERE EmUso='Sim' AND CodUser = ".$_SESSION['user']);
    $resulth = mysql_num_rows ($h);

    if($resulth == '0'){
      echo '<img src="logos/drop.png" id="idrop" class="imgdropoff" onclick="optionssho()">';
    }else{
      echo '<img src="logos/drop.png" id="idrop" class="imgdrop" onclick="optionssho()">';
    }
  }

  function cantdeclare(){
    $g = mysql_query ("SELECT CodVeic FROM veicondu WHERE EmUso='Sim' AND CodUser = ".$_SESSION['user']);
    $resultg = mysql_num_rows ($g);

    if($resultg == '1'){
      echo '<a href="inserir_despesa.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a>';
    }else{
      echo '<img src="logos/add.png" title="Adicionar Despesa" class="imgaddoff">';
    }
  }

  function cantdeclare1(){
    $f = mysql_query ("SELECT CodVeic FROM veicondu WHERE EmUso='Sim' AND CodUser = ".$_SESSION['user']);
    $resultf = mysql_num_rows ($f);

    if($resultf == '1'){
      echo '<a href="agendar_despesa.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a>';
    }else{
      echo '<img src="logos/add.png" title="Adicionar Despesa" class="imgaddoff">';
    }
  }

  function cantdeclare2(){
    $h = mysql_query ("SELECT CodVeic FROM veicondu WHERE EmUso='Sim' AND CodUser = ".$_SESSION['user']);
    $resulth = mysql_num_rows ($h);

    if($resulth == '1'){
      echo '<a href="inserir_abastecimento.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a>';
    }else{
      echo '<img src="logos/add.png" title="Adicionar Despesa" class="imgaddoff">';
    }
  }

  function cantdeclare3(){
    $h = mysql_query ("SELECT CodVeic FROM veicondu WHERE EmUso='Sim' AND CodUser = ".$_SESSION['user']);
    $resulth = mysql_num_rows ($h);

    if($resulth == '1'){
      echo '<a href="inserir_manutencao.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a>';
    }else{
      echo '<img src="logos/add.png" title="Adicionar Despesa" class="imgaddoff">';
    }
  }

  function cantdeclare4(){
    $h = mysql_query ("SELECT CodVeic FROM veicondu WHERE EmUso='Sim' AND CodUser = ".$_SESSION['user']);
    $resulth = mysql_num_rows ($h);

    if($resulth == '1'){
      echo '<a href="agendar_manutencao.php"><img src="logos/add.png" title="Adicionar Despesa" class="imgadd"></a>';
    }else{
      echo '<img src="logos/add.png" title="Adicionar Despesa" class="imgaddoff">';
    }
  }
