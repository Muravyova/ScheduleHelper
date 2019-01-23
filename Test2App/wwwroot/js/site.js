const shobj = document.querySelectorAll('.shedule-obj');
var check = [];
const days = document.querySelectorAll('.weekdays');

NodeList.prototype.forEach = Array.prototype.forEach;

//обработка hover
function z(event) {
    var target = event.target;
    target.style.zIndex = parseInt(target.style.zIndex) + 100;
}

function zmin(event) {
    var target = event.target;
    target.style.zIndex = parseInt(target.style.zIndex) - 100;
}

//если нажать на элемент, он выйдет на 10 пунктов вперед
shobj.forEach(function (sho) {
    sho.addEventListener("click", () => {
        sho.style.zIndex = parseInt(sho.style.zIndex) + 10;
    })
})

//обработка внешнего вида элементов
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

//обработка перекрытий
days.forEach(function (day) {
    var day_obj = day.childNodes;
    var same = []; //счетчик объестов с одинаковым временем(час)
    var qu = []; //очередь часов
    var objects = []; //очередь объектов, которые начинаются в один час
    //находим все перекрывающиеся объекты
    day_obj.forEach(function (obj) {
        var hour = null;
        for (var i = 0; i < obj.childNodes.length; i++) {
            if (obj.childNodes[i].className == "hidden time") {
                hour = parseInt(obj.childNodes[i].innerHTML, 10);
                if (same[hour] >= 0) {
                    if (same[hour] == 0) { qu.push(hour); }
                    same[hour]++;
                } else {
                    same[hour] = 0;
                }
            }
        }
    });
    //собираем одинаковые элементы
    day_obj.forEach(function (obj) {
        var hour = null;
        for (var i = 0; i < obj.childNodes.length; i++) {
            if (obj.childNodes[i].className == "hidden time") {
                hour = parseInt(obj.childNodes[i].innerHTML, 10);
                if (same[hour] > 0) {
                    objects.push(obj);
                } 
            }
        }
    });
    var m0 = 0, m15 = 0, m30 = 0, m45 = 0;
    var m0d = 0; m15d = 0, m30d = 0, m45d = 0;
    for (var h = parseInt(0, 10); h < same.length; h++) {
        if (same[h] > 0) {
            var ind = 0;
            while (1) {
                if (qu[ind] == h) { break; }
                ind++;
            }
            if (ind > -1) {
                var wobj = objects;//плучили массив с объектами одного времени
                console.log(wobj);
                for (var d = 0; d < same[h]; d++) { objects.shift; }
                for (var l = 0; l < wobj.length; l++) {//проходим через этот массив
                    var i = 0;
                    var time = null;
                    var min = null;
                    var dur = null;
                    while (1) { //находим минуты и длительность 
                        if (wobj[l].childNodes[i].className == "hidden time") {
                            time = wobj[l].childNodes[i].innerHTML;
                            min = parseInt(wobj[l].childNodes[i].innerHTML.slice(-2), 10);
                        } else if (wobj[l].childNodes[i].className == "hidden dur") {
                            time += wobj[l].childNodes[i].innerHTML;
                            dur = parseInt(wobj[l].childNodes[i].innerHTML, 10);
                            break;
                        }
                        i++;
                    }

                    if (dur == 60) {
                        if (min == 0) {
                            if ((m0 > 0) && (m0 < 5)) {
                                wobj[l].style.zIndex = 120 + m0;
                                wobj[l].style.width = 150 - m0 * 10 + "px";
                            } else {
                                wobj[l].style.zIndex = 120;
                            }
                            m0++;
                        } else if (min == 15) {
                            if ((m15 > 0) && (m15 < 5)) {
                                wobj[l].style.zIndex = 100 + m15;
                                wobj[l].style.width = 150 - m15 * 10 + "px";
                            } else {
                                wobj[l].style.zIndex = 100;
                            }
                            m15++;
                        } else if (min == 30) {
                            if ((m30 > 0) && (m30 < 5)) {
                                wobj[l].style.zIndex = 80 + m30;
                                wobj[l].style.width = 150 - m30 * 20 + "px";
                            } else {
                                wobj[l].style.zIndex = 80;
                            }
                            m30++;
                        } else if (min == 45) {
                            if ((m15 > 0) && (m45 < 5)) {
                                wobj[l].style.zIndex = 60 + m45;
                                wobj[l].style.width = 150 - m45 * 20 + "px";
                            } else {
                                wobj[l].style.zIndex = 60;
                            }
                            m45++;
                        }
                    } else {
                        if (min == 0) {
                            if ((m0 > 0) && (m30 > 0)) {
                                wobj[l].style.top = parseInt(wobj[l].style.top, 10) +  5 + "px";
                            }
                            wobj[l].style.zIndex = 80 + m30 + m0d;
                            if ((m0d > 0) && (m0d < 5)) {
                                wobj[l].style.width = 150 - m0d * 20 + "px";
                            }  
                            m0d++;
                        } else if (min == 15) {
                            if ((m15 > 0) && (m45 > 0)) {
                                wobj[l].style.top = parseInt(wobj[l].style.top, 10) + 5 + "px";
                            }
                            wobj[l].style.zIndex = 60 + m45 + m15d;
                            if ((m15d > 0) && (m15d < 5)) {
                                wobj[l].style.width = 150 - m15d * 20 + "px";
                            }
                            m15d++;
                        } else if (min == 30) {
                            if ((m30d > 0) && (m30d < 5)) {
                                wobj[l].style.width = 150 - m30d * 20 + "px";
                            }
                            wobj[l].style.zIndex = 40 + m30d;
                            m30d++;
                        } else if (min == 45) {
                            if ((m45d > 0) && (m45d < 5)) {
                                wobj[l].style.width = 150 - m45d * 20 + "px";
                            }
                            wobj[l].style.zIndex = 20 + m45d;
                            m45d++;
                        }
                    }
                }
            }
        }
    }
});