$(".login__btn--close").click(function () {
    $("#forgotten-container").fadeOut();
    document.getElementById("container").style.display = "block";
});


/* Forgotten Password */
$('#forgotten').click(function () {
    $("#container").fadeOut(function () {
        $("#forgotten-container").fadeIn();
    });
});