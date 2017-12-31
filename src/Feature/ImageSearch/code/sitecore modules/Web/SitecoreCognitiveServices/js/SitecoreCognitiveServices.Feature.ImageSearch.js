jQuery.noConflict();

//nav
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
});

//reanalyze
jQuery(document).ready(function () {
    //handles analyze all form
    var anlyzeAllForm = ".analyze-all-form";
    jQuery(anlyzeAllForm + " button")
        .click(function (event) {
            event.preventDefault();

            var idValue = jQuery(anlyzeAllForm + " #id").attr("value");
            var langValue = jQuery(anlyzeAllForm + " #language").attr("value");
            var dbValue = jQuery(anlyzeAllForm + " #database").attr("value");

            jQuery(".form").hide();
            jQuery(".progress-indicator").show();

            jQuery.post(
                jQuery(anlyzeAllForm).attr("action"),
                {
                    id: idValue,
                    language: langValue,
                    database: dbValue
                }
            ).done(function (r) {
                jQuery(".result-count").text(r.ItemCount);
                jQuery(".progress-indicator").hide();
                jQuery(".result-display").show();
            });
        });
});

//set alt tags
jQuery(document).ready(function () {
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
});

//image search
jQuery(document).ready(function () {
    var config = {
        '.chosen-select': { width: "100%" }
    }
    var results = [];
    for (var selector in config) {
        var elements = jQuery(selector);
        for (var i = 0; i < elements.length; i++) {
            results.push(new Chosen(elements[i], config[selector]));
        }
    }

    jQuery(".slider-range").each(function () {
        jQuery(this).slider({
            range: true,
            min: 0,
            max: 100,
            values: [0, 100],
            slide: function (event, ui) {
                var parent = jQuery(this).parent('.emotion-item');
                var filterValue = jQuery(parent).find(".filter-value");
                var rangeVal = ui.values[0] + " - " + ui.values[1];
                rangeVal += (filterValue.data("field") == "age") ? "" : "%";
                filterValue.html(rangeVal);
                filterValue.data('min', ui.values[0]);
                filterValue.data('max', ui.values[1]);
            }
        });

        var parent = jQuery(this).parent('.emotion-item');
        var filterValue = jQuery(parent).find(".filter-value");
        var htmlVal = "0 - 100";
        htmlVal += (filterValue.data("field") == "age") ? "" : "%";
        filterValue.html(htmlVal);
        filterValue.data('min', 0);
        filterValue.data('max', 100);
    });

    //closes modal and send selected image back to RTE
    var imageSearchForm = ".image-search-form";
    var rteSearchForm = ".rte-search-form";
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

    function RefreshQuery(){
        pageNum = 1;
        RunQuery();
    }

    var imageSearchSelect = ".filter-section select";
    jQuery(imageSearchSelect).change(function () {
        RefreshQuery();
    });
    
    jQuery(".slider-range, .chosen-results").mouseup(function (e) {
        if(e.which != 1) 
            return;
        
        RefreshQuery();
    });
    
    //performs search on 'enter-press' on the form
    jQuery(imageSearchForm + " .search-submit, " + imageSearchForm + " .cognitiveSearchButton")
        .click(function (event) {
            event.preventDefault();
                 
            RefreshQuery()
        });

    //performs image search
    var pageNum = 1;
    var pageSize = 35;
    var pageCount = 1;
    var searchResults;
    function RunQuery() {
        var textValue = jQuery(imageSearchForm + " .rte-search-input").val();
        var langValue = jQuery(imageSearchForm + " #language").attr("value");
        var dbValue = jQuery(imageSearchForm + " #database").attr("value");
        var gender = jQuery(imageSearchForm + " #gender").val();
        var glasses = jQuery(imageSearchForm + " #glasses").val();
        var size = jQuery(imageSearchForm + " #size").val();

        jQuery(rteSearchForm + " .progress-indicator").show();
        jQuery(".result-items").hide();

        var tags = GetTagParameters();
        var ranges = GetRangeParameters();

        jQuery.post(
            jQuery(imageSearchForm).attr("action"),
                {
                    formParameters: [],
                    tagParameters: tags,
                    rangeParameters: ranges,
                    gender: gender,
                    glasses: glasses,
                    size: size,
                    language: langValue,
                    db: dbValue,
                    page: pageNum,
                    pageLength: pageSize
                }
            ).done(function (r) {
                searchResults = r;

                jQuery(".pagenum").text(pageNum);
                pageCount = Math.ceil(r.ResultCount / pageSize);
                jQuery(".pagecount").text(pageCount);

                jQuery(".result-count").text(r.ResultCount);
                jQuery(".result-items").text("");
                jQuery(".result-items").show();

                for (var i = 0; i < r.Results.length; i++) {
                    var d = r.Results[i];
                    if (d.Url != undefined) {
                        jQuery(".result-items").append("<div class='result-img-wrap'><img src=\"" + d.Url + "\" alt=\"" + d.Alt + "\" title=\"" + d.Alt + "\" /></div>");
                    }
                }

                jQuery(".result-img-wrap")
                    .on("click", function () {
                        jQuery(".result-items .selected").removeClass("selected");
                        jQuery(this).addClass("selected");
                    });

                jQuery(".search-choice-close")
                    .on('click', function () {
                        setTimeout(RefreshQuery, 100);
                });
            }).always(function () {
                jQuery(rteSearchForm + " .progress-indicator").hide();
            });
    }

    //changes the current page
    var prevBtn = ".result-nav-prev";
    var nextBtn = ".result-nav-next";
    jQuery(prevBtn).click(function (e) {
        if (pageNum < 2)
            return;

        pageNum--;
        RunQuery();
    });

    jQuery(nextBtn).click(function (e) {
        if ((pageNum+1) > pageCount)
            return;

        pageNum++;
        RunQuery();
    });

    function GetRangeParameters() {
        var params = [];

        //tags
        var filterElements = jQuery('.filter-value');
        if (filterElements.length > 0) {

            filterElements.each(function () {
                var values = [];
                values.push(jQuery(this).data('min'));
                values.push(jQuery(this).data('max'));

                params.push({
                    key: jQuery(this).data('field'),
                    value: values
                });
            });
        }

        return params;
    }

    function GetTagParameters() {
        var params = [];
        params.push({
            key: "tags",
            value: [""]
        });

        //tags
        var tagElements = jQuery('.search-choice span');
        if (tagElements.length > 0) {

            var values = [];

            tagElements.each(function () {
                var text = jQuery(this).text();
                text = text.substring(0, text.indexOf(' ('));
                text = text.toLowerCase();
                values.push(text);
            });

            params.push({
                key: "tags",
                value: values
            });
        }

        return params;
    }

    //get results for the first load
    if (jQuery(imageSearchForm).length)
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