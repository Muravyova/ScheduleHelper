const shobj = document.querySelectorAll('.shedule-obj');

shobj.forEach(function (sho) {
    sho.addEventListener("click", () => {
        sho.style.zIndex += 1;
    })
})

shobj.forEach(function (sho) {
    var time = null;
    var dur = null;
    var type = null;
    var pl = null;
    for (var i = 0; i < sho.childNodes.length; i++) {
        if (sho.childNodes[i].className == "hidden time") {
            time = sho.childNodes[i];
        } else
        if (sho.childNodes[i].className == "hidden dur") {
            dur = sho.childNodes[i];
        } else
            if (sho.childNodes[i].className == "hidden type") {
                type = sho.childNodes[i];
            } else
                if (sho.childNodes[i].className == "place") {
                    pl = sho.childNodes[i];
                    break;
                }
    }    
    var hour = parseInt(time.innerHTML, 10);
    var m = time.innerHTML.slice(-2);
    var min = parseInt(m, 10);
    var duration = parseInt(dur.innerHTML, 10);
    switch (type.innerHTML) {
        case 'Групповое занятие':
            sho.classList.add("yellow");
            break;
        case 'Онлайн':
            sho.classList.add("green");
            break;
        case 'Открытое мероприятие':
            sho.classList.add("violet");
            break;
        case 'Преподавательское':
            sho.classList.add("red");
            break;
        case 'Индивидуальное занятие':
            sho.classList.add("blue");
            break;
        default:
            break;
    }
    sho.style.top = 153 + (hour-6)*60 + min + "px";
    sho.style.height = duration + "px";
    if (duration > 60) {
        pl.style.bottom = -20 + "px";
    }
});
