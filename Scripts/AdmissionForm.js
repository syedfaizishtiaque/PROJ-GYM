$(document).ready(function () {
    $('#Height').on('change', function () {
        CalculateBMI();
    });
    $('#Weight').on('change', function () {
        CalculateBMI();
    });
    $("#DOB").on("input", function () {
        var DOB = $("#DOB");
        if (!DOB.val()) {
            return;
        }
        CalculateAge();
    });
   
});

function CalculateBMI() {
    var Age = $('#Age');
    var height = $('#Height');
    var weight = $('#Weight');
    if (!height.val() && !weight.val() && !Age.val()) {
        return;
    }
    weight = weight.val();
    height = height.val();
    Age = Age.val();
    var bmi = weight / (((height / 3.28084) * (height / 3.28084)));
    $('#BMI').val(bmi.toFixed(2));
}
function CalculateAge() {
    var dob = new Date($('#DOB').val());
    var today = new Date();
    var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
    $('#Age').val(age);
}
