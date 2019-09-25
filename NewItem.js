function MinDate() { //This function make the deadline to be in date not less from the date of today I make it to type of string for slice the data
    var deadline = document.getElementById("deadline");
    var date = new Date();
    var day = "", month = "", year = "";
    var t_month, t_day;
    for (var i = 0; i <= 3; i++)
        year += String(deadline.value[i]);
    for (i = 5; i <= 6; i++)
        month += String(deadline.value[i]);
    for (i = 8; i <= 9; i++)
        day += String(deadline.value[i]);
    if ((date.getMonth() + 1).toString.length ===1) {
        t_month = '0' + (date.getMonth() + 1).toString();
    }
    else
        t_month = date.getMonth() + 1;
    if (date.getDate().toString.lenght ===1)
        t_day = '0' + date.getDate().toString();
    else
        t_day = date.getDate();
    if (year <= date.getFullYear()) {
        if (month <= date.getMonth()+1) {
            if (day < date.getDate())
                deadline.value = String(date.getFullYear()) + '-' + t_month + '-' + t_day;
        }
    }
    if (year <= date.getFullYear()) {
        if (month < date.getMonth()+1)
            deadline.value = String(date.getFullYear()) + '-' + String(date.getMonth() + 1) + '-' + String(date.getDate());
    }
    if (year < date.getFullYear())
        deadline.value = String(date.getFullYear()) + '-' + String(date.getMonth() + 1) + '-' + String(date.getDate());
}
