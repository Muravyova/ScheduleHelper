const shobj = document.querySelectorAll('.shedule-obj');
shobj.forEach(function (sho) {
    var time = null;
    var dur = null;
    var type = null;
    for (var i = 0; i < sho.childNodes.length; i++) {
        if (sho.childNodes[i].className == "hidden time") {
            time = sho.childNodes[i];
        } else
        if (sho.childNodes[i].className == "hidden dur") {
            dur = sho.childNodes[i];
        } else
            if (sho.childNodes[i].className == "hidden type") {
                type = sho.childNodes[i];
                break;
            }
    }    
    var int = parseInt(time.innerHTML, 10);
    var int1 = parseInt(dur.innerHTML, 10);
    switch (type.innerHTML) {
        case 'группа':
            sho.classList.add("yellow");
            break;
        case 'онлайн':
            sho.classList.add("green");
            break;
        case 'индивидуальное':
            sho.classList.add("blue");
            break;
        default:
            alert(type.innerHTML);
            break;
    }
    sho.style.top = 60 * (int-7) + "px";
    sho.style.height = int1 + "px";
});
//shobj.addEventListener("click", () => {
//    alert("Obj was found");
//})