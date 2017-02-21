jQuery.noConflict();
jQuery(document).ready(function () {
    
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
});