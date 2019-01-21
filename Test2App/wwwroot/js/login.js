$(".login__btn--close").click(function () {
    TweenMax.from("#container-login", .4, { scale: 1, ease: Sine.easeInOut });
    TweenMax.to("#container-login", .4, { left: "0px", scale: 0, ease: Sine.easeInOut });
    $("#forgotten-container").fadeOut(function () {
        $("#container-login").fadeIn();
        TweenMax.from("#container-login", .4, { scale: 1, ease: Sine.easeInOut });
        TweenMax.to("#container-login", .4, { scale: 1, ease: Sine.easeInOut });
    });
});

/* Forgotten Password */
$('#forgotten').click(function () {
    $("#container-login").fadeOut(function () {
        $("#forgotten-container").fadeIn();
    });
});