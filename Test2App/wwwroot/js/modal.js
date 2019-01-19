$('#open__btn').click(function () {
    $("#global-wrapper, #container").fadeIn();
    //$('#modal-wrapper').fadeIn();
    document.getElementById('global-wrapper').style.filter = 'blur(5px)';
    TweenMax.from("#container", .4, { scale: 0, ease: Sine.easeInOut });
    TweenMax.to("#container", .4, { scale: 1, ease: Sine.easeInOut });
});

$(".login__btn--close, .btn-danger").click(function () {
    TweenMax.from("#container", .4, { scale: 1, ease: Sine.easeInOut });
    TweenMax.to("#container", .4, { left: "0px", scale: 0, ease: Sine.easeInOut });
    $("#container").fadeOut(800);
    //$('#modal-wrapper').fadeOut(800);
    document.getElementById('global-wrapper').style.filter = 'none';
});
