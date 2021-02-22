// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//
//the following code creates the "tabs" of our calculator form & is modifed from W3Schools

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
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "Submit";
        document.getElementById("nextBtn").value = "Submit";
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
    }
    //trying to make buttons go away
    /*if (n == (x.length + 1)) {
        document.getElementById("prevBtn").style.display = "none";
        document.getElementById("nextBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").innerHTML = "i";
    }*/
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
        //TODO: may need to connect model here?
        document.getElementById("nextBtn").onclick = submitForm();

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
    for (i = 0; i < y.length; i++) {
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
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class to the current step:
    x[n].className += " active";
}

// displays current value of shade depth slider
var slider2 = document.getElementById("shade");
var output2 = document.getElementById("depth");
output2.innerHTML = slider2.value;
slider2.oninput = function () {
    output2.innerHTML = this.value;
}


// what happens when they click the submit button
function submitForm() {
    //this repopulates the text below the card tabs with the inputs and calculated results.
    recipeStatus.innerHTML = `Your recipe has been calculated!`;
    named.innerHTML = `Name: ${recipeName.value}`;
    fabricType.innerHTML = `Fabric / Fiber Type: ${fabric.value}`;
    fabricWeight.innerHTML = `Weight of Goods: ${quantity.value} grams`;
    dyeColor.innerHTML = `Dye Name: ${dye.value}`;
    colorType.innerHTML = `Color: ${color.value}`;
    shadeDepth.innerHTML = `Depth of Shade: ${shade.value}%`;
    dyeCalc.innerHTML = `Dye Amount: ${((shade.value)/100) * (quantity.value)} grams`;
    saltCalc.innerHTML = `Salt Amount: ${(quantity.value) * .5 } grams`;
    sodaAshCalc.innerHTML = `Soda Ash Amount: ${(quantity.value) * .09} grams`;
    waterCalc.innerHTML = `Water Amount: ${(quantity.value) * 20} mL`;
}

//TODO:  We need to find a way to model bind so that the inputs from the select lists will display the proper value. 
