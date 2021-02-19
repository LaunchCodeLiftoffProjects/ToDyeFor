// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*
    var currentTab = 0; // Current tab is set to be the first tab (0)
    showTab(currentTab); // Display the current tab

        function showTab(n) {
            // This function will display the specified tab of the form ...
            var x = document.getElementsByClassName("tab");
            x[n].style.display = "block";
            // ... and fix the Previous/Next buttons:
            if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
            } else {
        document.getElementById("prevBtn").style.display = "inline";
            }
            if (n == (x.length -1)) {
        document.getElementById("nextBtn").innerHTML = "Submit";
                document.getElementById("nextBtn").value = "Submit";

            } else {
        document.getElementById("nextBtn").innerHTML = "Next";
            }
            // ... and run a function that displays the correct step indicator:
            fixStepIndicator(n)
        }

        function nextPrev(n) {
            // This function will figure out which tab to display
            var x = document.getElementsByClassName("tab");
            // Exit the function if any field in the current tab is invalid:
            if (n == 1 && !validateForm()) return false;
            // Hide the current tab:
            x[currentTab].style.display = "none";
            // Increase or decrease the current tab by 1:
            currentTab = currentTab + n;
            // if you have reached the end of the form... :
            if (currentTab >= x.length) {
        //...the form gets submitted:
        //need to connect to database here?
        document.getElementById("nextBtn").onclick = submitForm();
                document.getElementById("calculator").submitForm();

                return false;
            }
            // Otherwise, display the correct tab:
            showTab(currentTab);
        }



        function validateForm() {
            // This function deals with validation of the form fields
            var x, y, i, valid = true;
            x = document.getElementsByClassName("tab");
            y = x[currentTab].getElementsByTagName("input");
            // A loop that checks every input field in the current tab:
            for (i = 0; i < y.length; {
                // If a field is empty...
                if (y[i].value == "") {
        // add an "invalid" class to the field:
        y[i].className += " invalid";
                    // and set the current valid status to false:
                    valid = false;
                }
            }
            // If the valid status is true, mark the step as finished and valid:
            if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
            }
            return valid; // return the valid status
        }

        function fixStepIndicator(n) {
            // This function removes the "active" class of all steps...
            var i, x = document.getElementsByClassName("step");
            for (i = 0; i < x.length; {
        x[i].className = x[i].className.replace(" active", "");
            }
            //... and adds the "active" class to the current step:
            x[n].className += " active";
        }

        // displays current value of sliders

        @*var slider1 = document.getElementById("quantity");
        var output1 = document.getElementById("amount");

        output1.innerHTML = slider1.value;
        slider1.oninput = function () {
        output1.innerHTML = this.value;
        }*@

        var slider2 = document.getElementById("shade");
        var output2 = document.getElementById("depth");
        output2.innerHTML = slider2.value;
        slider2.oninput = function () {
        output2.innerHTML = this.value;
        }

        // what happens when they click the submit button
        function submitForm() {
        let confirmation = "You've submitted the following: ";
            let a = document.getElementById("name").value;
            let b = document.getElementById("fabric").value;
            let c = document.getElementById("dye").value;
            let d = document.getElementById("color").value;
            let e = document.getElementById("quantity").value;
            let f = document.getElementById("depth").value;
            alert(confirmation + " " + a + ", " + b + ", " + c + ", " + d + ", " + e + ", " + f);
        }


    */