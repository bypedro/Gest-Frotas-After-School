<!DOCTYPE html>
<?php
ob_start();
session_start();
$con=mysqli_connect("localhost","root","") or die(mysqli_error());
mysqli_select_db($con,"frotas") or die(mysqli_error($con));
?>
<html>
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <title>Início</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="jquery.touchSwipe.min.js"></script>
	<link rel="stylesheet" href="style.css" type="text/css" />
      
    
    <style type="text/css">
			body, html {
          height: 100%;
          margin: 0;
          
          font-family: helvetica;
          font-weight: 100;
      }
      .container {
          position: relative;
          height: 100%;
          width: 100%;
          left: 0;
          -webkit-transition:  left 0.4s ease-in-out;
          -moz-transition:  left 0.4s ease-in-out;
          -ms-transition:  left 0.4s ease-in-out;
          -o-transition:  left 0.4s ease-in-out;
          transition:  left 0.4s ease-in-out;
      }
      .container.open-sidebar {
          left: 240px;
      }
      
      .swipe-area {
          position: absolute;
          width: 50px;
          left: 0;
      top: 0;
          height: 100%;
          background: #f3f3f3;
          z-index: 0;
      }
      #sidebar {
          background: #DF314D;
          position: absolute;
          width: 240px;
          height: 100%;
          left: -240px;
          box-sizing: border-box;
          -moz-box-sizing: border-box;
      }
      #sidebar ul {
          margin: 0;
          padding: 0;
          list-style: none;
      }
      #sidebar ul li {
          margin: 0;
      }
      #sidebar ul li a {
          padding: 15px 20px;
          font-size: 16px;
          font-weight: 100;
          color: white;
          text-decoration: none;
          display: block;
          border-bottom: 1px solid #C9223D;
          -webkit-transition:  background 0.3s ease-in-out;
          -moz-transition:  background 0.3s ease-in-out;
          -ms-transition:  background 0.3s ease-in-out;
          -o-transition:  background 0.3s ease-in-out;
          transition:  background 0.3s ease-in-out;
      }
      #sidebar ul li:hover a {
          background: #C9223D;
      }
      .main-content {
          width: 100%;
          height: 100%;
          padding: 10px;
          box-sizing: border-box;
          -moz-box-sizing: border-box;
          position: relative;
      }
      .main-content .content{
          box-sizing: border-box;
          -moz-box-sizing: border-box;
      padding-left: 60px;
      width: 100%;
      }
      .main-content .content h1{
          font-weight: 400;
      }
      .main-content .content p{
          width: 100%;
          line-height: 160%;
      }
      .main-content #sidebar-toggle {
          background: #545353;
          border-radius: 3px;
          display: block;
          position: relative;
          padding: 10px 7px;
          float: left;
      }
      .main-content #sidebar-toggle .bar{
           display: block;
          width: 18px;
          margin-bottom: 3px;
          height: 2px;
          background-color: #fff;
          border-radius: 1px;   
      }
      .main-content #sidebar-toggle .bar:last-child{
           margin-bottom: 0;   
      }
	  
	  td a{font-size:16px; color:#1f1f1f; margin-left:5px; padding:5px 10px; text-decoration:none; border-radius: 10px;}
	  td a:hover{color:#3775c1;}
	  
	  
    </style>
    <script type="text/javascript">
      $(window).load(function(){
        $("[data-toggle]").click(function() {
          var toggle_el = $(this).data("toggle");
          $(toggle_el).toggleClass("open-sidebar");
        });
         $(".swipe-area").swipe({
              swipeStatus:function(event, phase, direction, distance, duration, fingers)
                  {
                      if (phase=="move" && direction =="right") {
                           $(".container").addClass("open-sidebar");
                           return false;
                      }
                      if (phase=="move" && direction =="left") {
                           $(".container").removeClass("open-sidebar");
                           return false;
                      }
                  }
          }); 
      });
      
    </script>
  </head>
<body>


<?php
	$start=0;
	$limit=7;
	$page=0;
	if(isset($_GET['page']))
	{
		$page=$_GET['page'];
		$start=($page-1)*$limit;
	}

 	$sql=mysqli_query($con, "SELECT * FROM utilizador, cidade, tipouser, pais WHERE pais.CodPais=cidade.CodPais and tipouser.CodTipoU=utilizador.CodTipoU and cidade.CodCi=utilizador.CodCi  ORDER BY CodUser ASC LIMIT $start, $limit") or die(mysqli_error($con));

?>
<table align='center' class='table-fill'>
	<?php
	echo "<tr>";
                echo "<th>ID</th>";
                echo "<th>Nome Registo</th>";
                echo "<th>Nome Próprio</th>";
				echo "<th>Apelido</th>";
				echo "<th>Genero</th>";
				echo "<th>Data_Nascimento</th>";
				echo "<th>Data Contratação</th>";
				echo "<th>Pagamento Hora</th>";
				echo "<th>Habilitações</th>";
				echo "<th>Opção</th>";
            echo "</tr>";
	
	?>
	<?php
			
		while($row=mysqli_fetch_assoc($sql))
		{
		
	?>
	<?php
	
	  echo "<tr>";
                echo "<td>" . $row['CodUser'] . "</td>";
                echo "<td>" . $row['Nome_Registo'] . "</td>";
                echo "<td>" . $row['Nome_Prorio'] . "</td>";
                echo "<td>" . $row['Apelido'] . "</td>";
				echo "<td>" . $row['Genero'] . "</td>";
				echo "<td>" . $row['Data_Nascimento'] . "</td>";
				echo "<td>" . $row['Data_Contratacao'] . "</td>";
				echo "<td>" . $row['Pagamentos_Hora'] . "</td>";
				echo "<td>" . $row['Hsbilitacoes'] . "</td>";
				echo "<td>" . "<a href='ver_despesa.php?id=".$row['CodDesp']."' target='_blank'><img src='logos/edit.png' class='imgg' /></a>" . "</td>"; 
            echo "</tr>";
	
	
	
	?>
	<?php
	
		}
	?>
			
	<tr>
		<td colspan='3'>
		
	<?php
		
	$rows=mysqli_num_rows(mysqli_query($con, "select * from utilizador"));
	$total=ceil($rows/$limit);
	if(isset($page))
	{
		if($page>1)
		{
			echo "<a href='?page=".($page-1)."' class='paging'>Anterior</a>";
		}
	}

	for($i=1;$i<=$total;$i++)
	{
		echo "<a class='paging' href='?page=".$i."'>".$i."</a>"; 
	}
	
	if($page!=$total)
	{
		echo "<a class='paging' href='?page=".($page+1)."' class=paging''>Próximo</a>";
	}
	
	?>
	</td>
	</tr>
</table>
</body>
</html>