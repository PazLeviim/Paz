function Done() {//This function like function in name Show() but it will turn on in every click on checkbox and when it checked the mission is complete
    var missions = document.getElementsByClassName("missions");
    var missions_done = document.getElementsByClassName("missions_done");
    var statuss = document.getElementsByClassName("statuss");
    for (var i = 0; i < missions.length; i++) {
        if (missions_done[i].checked) {
            missions[i].setAttribute("style", "color:rgba(0,255,32);");
            missions_done[i].setAttribute("value", "Done");
            statuss[i].innerHTML = "Done";
            if (!missions_done[i].hasAttribute("checked"))
            missions_done[i].setAttribute("checked","");

        }
        else {
            missions[i].setAttribute("style", "color:black");
            missions_done[i].setAttribute("value", "Not Done");
            statuss[i].innerHTML = "Not Done";
            if (missions_done[i].hasAttribute("checked"))
                missions_done[i].removeAttribute("checked","");
        }
    }
}
function Show() {
    window.onload;
    var statuss = document.getElementsByClassName("statuss");
    var missions = document.getElementsByClassName("missions");
    var missions_done = document.getElementsByClassName("missions_done");
    for (var i = 0; i < statuss.length; i++) {
        if (statuss[i].innerHTML==="Done") {
            missions[i].setAttribute("style", "color:rgba(0,255,32);");
            if (!missions_done[i].hasAttribute("checked"))
                missions_done[i].setAttribute("checked","");

        }
        else {
            missions[i].setAttribute("style", "color:black");
            missions_done[i].setAttribute("value", "Not Done");
            statuss[i].innerHTML = "Not Done";
            if (missions_done[i].hasAttribute("checked"))
                missions_done[i].removeAttribute("checked");
        }
    }
}
