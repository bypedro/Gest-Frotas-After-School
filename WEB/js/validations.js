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