jQuery.noConflict();
jQuery(document).ready(function () {
    
    jQuery(".nav-btn")
        .click(function () {
            var selected = "selected";
            var tab = jQuery(this).attr("rel");
            jQuery(".nav-btn").removeClass(selected);
            jQuery(".tab-content").removeClass(selected);
            jQuery(".tab-content." + tab).addClass(selected);
            jQuery(this).addClass(selected);
        });

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

    var queryObj;
    var imageSearchForm = ".image-search-form";
    jQuery(imageSearchForm + " .form-submit")
        .click(function (event) {
            event.preventDefault();

            alert("image search form");
        });

    jQuery(imageSearchForm + " .form-cancel")
        .click(function (event) {
            event.preventDefault();

            alert("cancelling image search form");
            scCancel();
        });

    var imageSearchInput = ".rte-search-input";
    jQuery(imageSearchInput)
        .on('input', function (e) {
            clearTimeout(queryObj);
            queryObj = setTimeout(RunQuery, 500);
        });

    function RunQuery() {

        var queryText = jQuery(imageSearchInput).val();
        var langValue = jQuery(imageSearchForm + " #language").attr("value");
        var dbValue = jQuery(imageSearchForm + " #database").attr("value");

        jQuery(".progress-indicator").show();
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
                    jQuery(".result-items").append("<div class='result-img-wrap'><img src=" + d.url + " data-id=" + d.id + "/></div>");
                }

                jQuery(".result-img-wrap")
                    .on("click", function () {
                        jQuery(".result-items .selected").removeClass("selected");
                        jQuery(this).addClass("selected");
                    });
            }).always(function () {
                jQuery(".progress-indicator").hide();
            });
    }

    //get results for the first load
    RunQuery();
});

function getRadWindow() {
    
    if (window.parent.radWindow) 
        return window.parent.radWindow;
    
    if (window.parent.frameElement && window.parent.frameElement.radWindow) 
        return window.parent.frameElement.radWindow;
   
    return null;
}

var isRadWindow = true;
var radWindow = getRadWindow();

function scClose(image) {
    if (radWindow != null)
        radWindow.close({ imageTag: image });
    else 
        scCloseWebEdit(image);
}

function scCloseNoLink() {
    window.parent.close();
}

function scCancel() {
    radWindow.close();
}

function scCloseWebEdit(image) {
    window.parent.returnValue = image;
}

if (window.parent.focus && Prototype.Browser.Gecko) {
    window.parent.focus();
}