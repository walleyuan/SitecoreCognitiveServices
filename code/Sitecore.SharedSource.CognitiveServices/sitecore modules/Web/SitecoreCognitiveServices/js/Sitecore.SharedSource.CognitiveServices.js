jQuery.noConflict();
jQuery(document).ready(function () {
    
    //toggles tabs based on nav clicks
    jQuery(".nav-btn")
        .click(function () {
            var selected = "selected";
            var tab = jQuery(this).attr("rel");
            jQuery(".nav-btn").removeClass(selected);
            jQuery(".tab-content").removeClass(selected);
            jQuery(".tab-content." + tab).addClass(selected);
            jQuery(this).addClass(selected);
        });

    //handles reanalyze all form
    var reanlyzeAllForm = ".reanalyze-all-form";
    jQuery(reanlyzeAllForm + " button")
        .click(function(event) {
            event.preventDefault();
            
            var idValue = jQuery(reanlyzeAllForm + " #id").attr("value");
            var langValue = jQuery(reanlyzeAllForm + " #language").attr("value");
            var dbValue = jQuery(reanlyzeAllForm + " #database").attr("value");
            
            jQuery(".form").hide();
            jQuery(".progress-indicator").show();

            jQuery.post(
                jQuery(reanlyzeAllForm).attr("action"),
                {
                    id: idValue,
                    language: langValue,
                    db: dbValue
                }
            ).done(function (r) {
                jQuery(".result-count").text(r.ItemCount);
                jQuery(".progress-indicator").hide();
                jQuery(".result-display").show();
            });
        });

    //handles the submit on the set all alts form
    var setAltsAllForm = ".set-alt-all-form";
    jQuery(setAltsAllForm + " button")
        .click(function (event) {
            event.preventDefault();

            var idValue = jQuery(setAltsAllForm + " #id").attr("value");
            var langValue = jQuery(setAltsAllForm + " #language").attr("value");
            var dbValue = jQuery(setAltsAllForm + " #database").attr("value");
            var thresholdValue = jQuery(setAltsAllForm + " #threshold").val();
            var overwriteValue = jQuery(setAltsAllForm + " #overwrite").is(':checked');

            jQuery(".form").hide();
            jQuery(".progress-indicator").show();

            jQuery.post(
                jQuery(setAltsAllForm).attr("action"),
                {
                    id: idValue,
                    language: langValue,
                    db: dbValue,
                    threshold: thresholdValue,
                    overwrite: overwriteValue
                }
            ).done(function (r) {
                jQuery(".result-modified").text(r.ItemsModified);
                jQuery(".result-count").text(r.ItemCount);
                jQuery(".progress-indicator").hide();
                jQuery(".result-display").show();
            }).always(function () {
                jQuery(".progress-indicator").hide();
            });
        });

    //closes modal and send selected image back to RTE
    var queryObj;
    var imageSearchForm = ".image-search-form";
    jQuery(imageSearchForm + " .form-submit")
        .click(function (event) {
            event.preventDefault();

            var img = jQuery(".result-items .selected");
            if (img.length)
                CloseRadWindow(jQuery(".result-items .selected").html());
            else
                alert("You need to select an image.");
        });

    //closes modal on cancel press
    jQuery(imageSearchForm + " .form-cancel")
        .click(function (event) {
            event.preventDefault();

            CloseRadWindow();
        });

    //will perform search if you type and wait
    var imageSearchInput = ".rte-search-input";
    jQuery(imageSearchInput)
        .on('input', function (e) {
            clearTimeout(queryObj);
            queryObj = setTimeout(RunQuery, 500);
        });

    //performs search on 'enter-press' on the form
    jQuery(imageSearchForm + " .search-submit")
        .click(function (event) {
            event.preventDefault();

            clearTimeout(queryObj);
            RunQuery();
        });

    //performs image search
    function RunQuery() {

        var queryText = jQuery(imageSearchInput).val();
        var langValue = jQuery(imageSearchForm + " #language").attr("value");
        var dbValue = jQuery(imageSearchForm + " #database").attr("value");

        jQuery(imageSearchForm + " .progress-indicator").show();
        jQuery(".search-results").hide();

        jQuery.post(
            jQuery(imageSearchForm).attr("action"),
                {
                    query: queryText,
                    language: langValue,
                    db: dbValue
                }
            ).done(function (r) {
                jQuery(".result-count").text(r.ResultCount);
                jQuery(".result-items").text("");
                jQuery(".search-results").show();
                for (var i = 0; i < r.Results.length; i++) {
                    var d = r.Results[i];
                    jQuery(".result-items").append("<div class='result-img-wrap'><img src=\"" + d.url + "\" alt=\"" + d.alt + "\" /></div>");
                }

                jQuery(".result-img-wrap")
                    .on("click", function () {
                        jQuery(".result-items .selected").removeClass("selected");
                        jQuery(this).addClass("selected");
                    });
            }).always(function () {
                jQuery(imageSearchForm + " .progress-indicator").hide();
            });
    }

    //get results for the first load
    RunQuery();
});

//closes the search modal and passes value back to the RTE
function CloseRadWindow(value) {

    var radWindow;

    if (window.radWindow)
        radWindow = window.radWindow;
    else if (window.frameElement && window.frameElement.radWindow)
        radWindow = window.frameElement.radWindow;
    else
        window.close();

    radWindow.Close(value);
}