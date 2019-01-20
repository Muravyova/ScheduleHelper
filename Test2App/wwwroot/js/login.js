$('#login__btn').click(function () {
    $('#login__btn').fadeOut("slow", function () {
        $("#container").fadeIn();
        TweenMax.from("#container", .4, { scale: 0, ease: Sine.easeInOut });
        TweenMax.to("#container", .4, { scale: 1, ease: Sine.easeInOut });
    });
});

$(".login__btn--close").click(function () {
    TweenMax.from("#container", .4, { scale: 1, ease: Sine.easeInOut });
    TweenMax.to("#container", .4, { left: "0px", scale: 0, ease: Sine.easeInOut });
    $("#container, #forgotten-container").fadeOut(800, function () {
        $("#login__btn").fadeIn(800);
    });
});

/* Forgotten Password */
$('#forgotten').click(function () {
    $("#container").fadeOut(function () {
        $("#forgotten-container").fadeIn();
    });
});