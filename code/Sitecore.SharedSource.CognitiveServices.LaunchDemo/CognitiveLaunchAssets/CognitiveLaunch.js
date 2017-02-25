jQuery.noConflict();
jQuery(document).ready(function () {
    
    /*** GIPHY MODERATOR ***/

    jQuery(".form-submit-image").click(function(e) {
        e.preventDefault();

        jQuery(".progress-indicator").show();
        
        jQuery.getJSON("//api.giphy.com/v1/gifs/random?tag=" + jQuery(".moderator-query").val() + "&api_key=dc6zaTOxFJmzC")
        .success(data => {
            if (data.data.length < 1)
                return;

            var giphyUrl = data.data.image_url;

            jQuery.post(
                jQuery(".moderator-search-form").attr("action"),
                {
                    url: giphyUrl
                }
            ).done(function (r) {
                var loc = "acceptable";
                var inner = "";
                if (r.IsAdultContent) {
                    loc = "adult";
                    inner = "<div class='left'>" + Math.round(100 * r.AdultScore) + "%</div>";
                } else if (r.IsRacyContent) {
                    loc = "racy";
                    inner = "<div class='left'>" + Math.round(100 * r.RacyScore) + "%</div>";
                } else {
                    inner = "<div class='left'>" + Math.round(100 * r.RacyScore) + "% Racy</div><div class='right'>" + Math.round(100 * r.AdultScore) + "% Adult</div>";
                }

                jQuery(".image-results ." + loc + " .list").prepend("<div class='image-wrapper'>" + inner + "<img src=\"" + giphyUrl + "\" /></div>");
            });
        });

        jQuery(".progress-indicator").hide();
    });
    
    /*** BING AUTO SUGGEST ***/

    var queryObj;
    var suggestForm = ".suggest-search-form";
    
    jQuery(suggestForm + " .form-submit") //will search if you push the button
        .click(function (event) {
            event.preventDefault();

            clearTimeout(queryObj);
            RunSuggestQuery();
        });

    jQuery(suggestForm) //will search if you type and wait
        .on('input', function (e) {
            clearTimeout(queryObj);
            queryObj = setTimeout(RunSuggestQuery, 500);
        });

    
    function RunSuggestQuery() { //performs image search

        var queryText = jQuery(suggestForm + " #text").val();
        
        jQuery(".suggest-list").hide();
        jQuery(".suggest-list").html("");

        jQuery.post(
            jQuery(suggestForm).attr("action"),
                {
                    text: queryText
                }
            ).done(function (r) {
                if (r.length === 0)
                    return;

                for (var i = 0; i < r.length; i++) {
                    var d = r[i];
                    jQuery(".suggest-list").append("<div class='suggest-result'><a href=\"" + d.Url + "\">"+ d.DisplayText + "</a>");
                }
                jQuery(".suggest-list").show();
            });
    }

    /*** BING IMAGE SEARCH ***/

    var imageForm = ".image-form";
    jQuery(imageForm + " .form-submit")
        .click(function (e) {
            e.preventDefault();

            jQuery(imageForm + " .results").html("");
            
            jQuery.post(
                jQuery(imageForm).attr("action"),
                {
                    query: jQuery(imageForm + " #text").val()
                }
            ).done(function (r) {
                if (r.length === 0)
                    return;

                for (var i = 0; i < r.length; i++) {
                    var d = r[i];
                    jQuery(imageForm + " .results").append("<img height='50' src=\"" + d.ThumbnailUrl + "\" />");
                }
            });
        });

    var trendForm = ".trend-form";
    jQuery(trendForm + " .form-submit")
        .click(function (e) {
            e.preventDefault();

            jQuery(trendForm + " .results").html("");

            jQuery.post(
                jQuery(trendForm).attr("action"), { }
            ).done(function (r) {
                if (r.length === 0)
                    return;

                for (var i = 0; i < r.length; i++) {
                    var d = r[i];
                    
                    jQuery(trendForm + " .results").append("<div class='result'><div>" + d.Title + "</div><div>");
                    for (var j = 0; j < d.Tiles.length; j++) {
                        var t = d.Tiles[j];
                        jQuery(trendForm + " .results").append("<img height='50' src=\"" + t.Image.ThumbnailUrl + "\" />");
                    }
                    jQuery(trendForm + " .results").append("</div></div>");
                    
                }
            });
        });

    var insightForm = ".insight-form";
    jQuery(insightForm + " .form-submit")
        .click(function (e) {
            e.preventDefault();

            jQuery(insightForm + " .results").html("");

            jQuery.post(
                jQuery(insightForm).attr("action"),
                {
                    url: jQuery(insightForm + " #text").val()
                }
            ).done(function (r) {
                if (r.length === 0)
                    return;

                for (var i = 0; i < r.length; i++) {
                    var d = r[i];
                    jQuery(insightForm + " .results").append("<img height='50' src=\"" + d.ThumbnailUrl + "\" />");
                }
            });
        });

    /*** BING SPELL CHECK ***/

    var spellCheckForm = ".spell-check-form";
    jQuery(spellCheckForm + " .form-submit")
        .click(function (e) {
            e.preventDefault();

            jQuery(spellCheckForm + " .suggestions").html("");

            jQuery.post(
                jQuery(spellCheckForm).attr("action"), { text: jQuery(spellCheckForm + " #text").val() }
            ).done(function (r) {
                for (var i = 0; i < r.length; i++) {
                    var token = r[i];
                    
                    var tokenLine = "<span class='token'>" + token.Token + ": </span>";
                    for (var j = 0; j < token.Suggestions.length; j++) {
                        var suggestion = token.Suggestions[j];

                        if (suggestion == undefined)
                            continue;

                        tokenLine += "<span class='suggestion'>" + suggestion.Suggestion + "</span>";   
                    }
                    jQuery(spellCheckForm + " .suggestions").append("<div class='spell-check-result'>" + tokenLine + "</div>");
                }
            });
        });

    /*** BING WEB SEARCH ***/

    var webSearchForm = ".web-search-form";
    jQuery(webSearchForm + " .form-submit")
        .click(function (e) {
            e.preventDefault();

            jQuery(webSearchForm + " .results").html("");

            jQuery.post(
                jQuery(webSearchForm).attr("action"), { text: jQuery(webSearchForm + " #text").val() }
            ).done(function (r) {
                for (var i = 0; i < r.length; i++) {
                    jQuery(webSearchForm + " .results").append("<div><a href='" + unescape(r[i].Url) + "'>" + r[i].Name+ "</a></div>");
                }
            });
        });

    /*** BING NEWS SEARCH ***/

    var newsSearchForm = ".news-search-form";
    jQuery(newsSearchForm + " .form-submit")
        .click(function (e) {
            e.preventDefault();

            jQuery(newsSearchForm + " .results").html("");

            jQuery.post(
                jQuery(newsSearchForm).attr("action"),
                {
                    text: jQuery(newsSearchForm + " #text").val()
                }
            ).done(function (r) {
                for (var i = 0; i < r.length; i++) {
                    var d = r[i];
                    jQuery(newsSearchForm + " .results").append("<div>" + (i+1) + ": <a href=\"" + d.Url + "\">" + d.Name + "</a></div>");
                }
            });
        });

    var newsTrendForm = ".news-trend-form";
    jQuery(newsTrendForm + " .form-submit")
        .click(function (e) {
            e.preventDefault();

            jQuery(newsTrendForm + " .results").html("");

            jQuery.post(
                jQuery(newsTrendForm).attr("action"), {}
            ).done(function (r) {
                for (var i = 0; i < r.length; i++) {
                    var d = r[i];

                    jQuery(newsTrendForm + " .results").append("<div>" + (i+1) + ": <a href='" + d.WebSearchUrl + "'>" + d.Name + " - " + d.Image.Provider[0].Name + "</a><div>");
                }
            });
        });

    var newsCatForm = ".news-category-form";
    jQuery(newsCatForm + " .form-submit")
        .click(function (e) {
            e.preventDefault();

            jQuery(newsCatForm + " .results").html("");

            jQuery.post(
                jQuery(newsCatForm).attr("action"),
                {
                    category: jQuery(newsCatForm + " #category").val()
                }
            ).done(function (r) {
                for (var i = 0; i < r.length; i++) {
                    var d = r[i];
                    jQuery(newsCatForm + " .results").append("<div>" + (i + 1) + ": <a href=\"" + d.Url + "\">" + d.Name + "</a></div>");
                }
            });
        });

});