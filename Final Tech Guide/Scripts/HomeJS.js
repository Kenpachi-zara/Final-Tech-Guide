var x = 0;

function popup() {
    window.alert("Hello fuckers");
    window.location.reload(); // refreshes the page 
    window.location.href = ".html" // redirects 
}
function changeText() {

    document.getElementById("demo").innerHTML = "After clicking the button this appeared";
    // gets the element p with the id "demo"
}
function getText() {

    var text = document.getElementById("textBox").value;  // get the value of the textBox's value attribute
    document.getElementById("demo").innerHTML = text; // sets text on P elements with id demo
    document.getElementById("demo").style.color = "#ff0000"; // sets text on P elements with id demo
}



// down below is useless so far.
// Example starter JavaScript for disabling form submissions if there are invalid fields
function validate() {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
}
