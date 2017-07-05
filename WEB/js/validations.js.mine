function checkDate() {

    var selectedText = document.getElementById('subdate').value;
    var selectedDate = new Date(selectedText);
	var now = new Date();
	if (selectedDate < now) {
        alert("Data nao pode ser passada!");
        document.getElementById("subdate").value = "";
   }
}

function IsEmpty(){

if(document.getElementById('subdate').value == "")
{
	alert("Data nao pode ficar vazia!");
	return false;
}
 	return true;
}

function validate(evt) {
	  var theEvent = evt || window.event;
	  var key = theEvent.keyCode || theEvent.which;
	  key = String.fromCharCode( key );
	  var regex = /[0-9]|\./;
	  if( !regex.test(key) ) {
		theEvent.returnValue = false;
		if(theEvent.preventDefault) theEvent.preventDefault();
	  }
}

function myFunction() {
  var input, filter, table, tr, td, i;
  input = document.getElementById("myInput");
  filter = input.value.toUpperCase();
  table = document.getElementById("myTable");
  tr = table.getElementsByTagName("tr");
  for (i = 0; i < tr.length; i++) {
    td = tr[i].getElementsByTagName("td")[0];
    if (td) {
      if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
        tr[i].style.display = "";
      } else {
        tr[i].style.display = "none";
      }
    }
  }
}

function vhiden(){
	var $id = document.getElementById('despt').value;
	var $txtbox = $('[id*="hidensd"]');

	if( $id == 2){
		$txtbox.hide();
	}
	else{
		$txtbox.show();
	}
}

function counttoanother(){
  $("#valued").on('keydown',function(){
      $("#total_price_amount").val($(this).val());
  });

}

function showfilter(){
  if(document.getElementById('myInput').style.display = 'none'){
    document.getElementById('myInput').style.display = 'block';
  }else{
    document.getElementById('myInput').style.display = 'none';
  }

}
