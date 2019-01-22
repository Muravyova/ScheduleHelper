const shobj = document.querySelectorAll('.shedule-obj');
var check = [];
const days = document.querySelectorAll('.weekdays');

NodeList.prototype.forEach = Array.prototype.forEach;

//function contains(a, obj) {
//    var i = a.length;
//    while (i--) {
//        if (a[i] === obj) {
//            return true;
//        }
//    }
//    return false;
//}


days.forEach(function (day) {
    var day_obj = day.childNodes;
    var same = [];
    for (var i = 0; i < day.childNodes.length; i++) {
        check[i] = 0;
    }
    day_obj.forEach(function (obj) {
        var time = null;
        for (var i = 0; i < obj.childNodes.length; i++)
        {
            if (obj.childNodes[i].className == "hidden time") {
                time = parseInt(obj.childNodes[i].innerHTML, 10);
                if (same[time] == 0) {
                    same[time]++;
                } else {
                    same[time] = 0;
                }
            }
        }
    });
    day_obj.forEach(function (obj) {
        var time = null;
        for (var i = 0; i < obj.childNodes.length; i++) {
            if (obj.childNodes[i].className == "hidden time") {
                time = parseInt(obj.childNodes[i].innerHTML, 10);
                if (same[time] > 0) {
                    obj.classList.add("hidden");
                    if (check[time] == 0) {
                        check[time]++;
                        var div = document.createElement('div');
                        div.style.top = 170 + (time - 6) * 60 + "px";
                        div.classList.add("shedule-obj");
                        div.classList.add("special");
                        div.innerHTML = "Перекрытие";
                        day.appendChild(div);
                    } 
                }
            }
        }
    });
    
});

var hid = document.querySelectorAll('.special');
hid.forEach(function (overlay) {
    overlay.addEventListener('click', () => {
        alert(1);
    })
});

shobj.forEach(function (sho) {
    sho.addEventListener("click", () => {
        sho.style.zIndex += 1;
    })
})

shobj.forEach(function (sho) {

    var day = null;
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
                if (sho.childNodes[i].className == "hidden day") {
                    day = sho.childNodes[i];
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
    sho.style.top = 170 + (hour-6)*60 + min + "px";
    sho.style.height = duration + "px";
    if (duration > 60) {
        pl.style.bottom = -20 + "px";
    }
    
});
