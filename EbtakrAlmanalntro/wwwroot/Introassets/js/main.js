$(".bars,.navbar-layer").click(function () {
    $(".nav-list.respon").toggleClass("navBar2open");
    $(".navbar-layer").toggleClass("navbar-layeropen");
    $(".bars").toggleClass("x-bars")
    $(".bars").css("z-index", "99")
});

function resize() {
    var heights = window.innerHeight;
    document.getElementById("header").style.height = heights + "px";
}
resize();
window.onresize = function () {
    resize();
};

window.addEventListener("scroll", function () {
    if (window.scrollY > 80) {
        $('#fixedHead').addClass("fixedhead")
    } else {
        $('#fixedHead').removeClass("fixedhead")
    }
});

$(document).ready(function () {
    var currentLocation = window.location.pathname;
    $(".about a").on("click", function () {
        if (currentLocation == '/' || currentLocation == '/EbtakrAlmanalntro/Index') {
            $([document.documentElement, document.body]).animate({
                scrollTop: $("#about").offset().top - ($("#fixedHead").outerHeight(true) + 5)
            }, 500);
        }
        else {
            window.location.href = '/EbtakrAlmanalntro/Index#about';
        }
    })


})
$(document).ready(function () {
    var currentLocation = window.location.pathname;

    $(".how").on("click", function () {
        if (currentLocation == '/' || currentLocation == '/EbtakrAlmanalntro/Index') {

            $([document.documentElement, document.body]).animate({
                scrollTop: $("#how").offset().top - ($("#fixedHead").outerHeight(true) + 5)
            }, 500);
        }
        else {
            window.location.href = '/EbtakrAlmanalntro/Index#how';
        }
    })
})
$(document).ready(function () {
    var currentLocation = window.location.pathname;

    $(".slider").on("click", function () {
        if (currentLocation == '/' || currentLocation == '/EbtakrAlmanalntro/Index') {

            $([document.documentElement, document.body]).animate({
                scrollTop: $("#slider").offset().top - ($("#fixedHead").outerHeight(true) + 5)
            }, 500);
        }
        else {
            window.location.href = '/EbtakrAlmanalntro/Index#slider';
        }
    })
})
$(document).ready(function () {
    var currentLocation = window.location.pathname;

    $(".contact").on("click", function () {
        if (currentLocation == '/' || currentLocation == '/EbtakrAlmanalntro/Index') {

            $([document.documentElement, document.body]).animate({
                scrollTop: $("#contact").offset().top - ($("#fixedHead").outerHeight(true) + 5)
            }, 500);
        }
        else {
            window.location.href = '/EbtakrAlmanalntro/Index#contact';
        }
    })
})

// var myElement = document.getElementById('element_within_div');
// var topPos = myElement.offsetTop;