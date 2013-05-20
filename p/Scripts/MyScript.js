
var accordionMenuIndex = 0;

function GetAccordionMenuIndex() {
    accordionMenuIndex = $(".selector").accordion("option", "active");
}

function m(msg) {
    //$.jGrowl(msg, { pool: 2 });
}

$(function () {
    $("#accordionMenu").accordion({
        activate: function (event, ui) {
            accordionMenuIndex = $("#accordionMenu").accordion("option", "active");
        }
    });
    $("#accordionMenu").accordion({ active: accordionMenuIndex });
    //$("#accordionMenu").accordion("option", "active", accordionMenuIndex);
});
