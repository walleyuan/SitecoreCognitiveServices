$(document).ready(function () {
    $(".nav-btn").click(function () {
        var selected = "selected";
        var tab = $(this).attr("rel");
        $(".nav-btn").removeClass(selected);
        $(".tab-content").removeClass(selected);
        $(".tab-content." + tab).addClass(selected);
        $(this).addClass(selected);
    });

    $(".reanalyze-all-form")
        .submit(function(event) {
            event.preventDefault();
            alert("Handler for .submit() called.");
        });
});