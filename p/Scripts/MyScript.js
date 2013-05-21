
function m(msg) {
    //$.jGrowl(msg, { pool: 2 });
}

$(function () {
    var accordionMenuIndex = parseInt(sessionStorage.getItem("accordionMenuIndex"));
    $("#accordionMenu").accordion({
        active: accordionMenuIndex,
        activate: function (event, ui) {
            var accordionMenuIndex = $("#accordionMenu").accordion("option", "active");
            sessionStorage.setItem("accordionMenuIndex", accordionMenuIndex);
        }
    });

    //keep footer below accordionMenu
    var hTop = $("header").position().top;
    var hHeight = $("header").innerHeight();
    var aTop = $("#accordionMenu").position().top;
    var aHeight = $("#accordionMenu").innerHeight();
    var bTop = $("#body").position().top;
    var bHeight = $("#body").innerHeight();
    var fTop = $("footer").position().top;
    var footerTop = aTop + aHeight;
    if (aHeight < bHeight) {
        footerTop = bTop + bHeight;
    }
    if (footerTop > fTop) {
        //$("footer").css({ top: (footerTop - fTop) + 'px' });
        //$("footer").css({ top: (footerTop) + 'px' });
        $("footer").css({ top: footerTop });
    }
    //

});
