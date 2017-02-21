jQuery.noConflict();
jQuery(document).ready(function () {
    
    jQuery(".form-submit-image").click(function(e) {
        e.preventDefault();

        jQuery(".progress-indicator").show();
        jQuery(".image-result").hide();
        jQuery(".text-result").hide();

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
                jQuery(".image-result .image-file").html("<img src=\"" + giphyUrl + "\" />");
                jQuery(".image-details .adult span").text(r.IsAdultContent + " (" + Math.round(100 * r.AdultScore) + "%)");
                jQuery(".image-details .racy span").text(r.IsRacyContent + " (" + Math.round(100 * r.RacyScore) + "%)");
                jQuery(".image-result").show();
            });
        });

        jQuery(".progress-indicator").hide();
    });

    jQuery(".form-submit-text").click(function (e) {
        e.preventDefault();

    });
});