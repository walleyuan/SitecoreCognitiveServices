$(document).ready(function () {
    
    $(".nav-btn").click(function () {
        var selected = "selected";
        var tab = $(this).attr("rel");
        $(".nav-btn").removeClass(selected);
        $(".tab-content").removeClass(selected);
        $(".tab-content." + tab).addClass(selected);
        $(this).addClass(selected);
    });

    var reanlyzeForm = ".reanalyze-all-form";
    $(reanlyzeForm)
        .click(function(event) {
            event.preventDefault();
            
            var idValue = $(reanlyzeForm + " #id").attr("value");
            var langValue = $(reanlyzeForm + " #language").attr("value");
            var dbValue = $(reanlyzeForm + " #database").attr("value");
            
            $(".form").hide();
            $(".progress-indicator").show();

            $.post(
                $(reanlyzeForm).attr("action"),
                {
                    id: idValue,
                    language: langValue,
                    db: dbValue
                }
            ).done(function (r) {
                $(".resultCount").text(r.ItemCount);
                $(".progress-indicator").hide();
                $(".result-display").show();
            });
        });
});