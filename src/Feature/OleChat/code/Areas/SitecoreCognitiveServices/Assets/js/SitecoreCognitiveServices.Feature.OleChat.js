jQuery.noConflict();

//ole chat
jQuery(document).ready(function () {
    //ole chat
    var chatInput = ".chat-input";
    var chatForm = ".chat-form";
    var chatConversation = ".chat-conversation";
    var initText = ".init-text";
    var chatConversationData = {};

    jQuery(chatInput).focus();

    //initiate conversation
    SendChatRequest(jQuery(initText).text());

    //sends chat text on 'enter-press' on the form
    jQuery(chatForm + " .chat-submit")
        .click(function (event) {
            event.preventDefault();
            var queryValue = jQuery(chatInput).val();
            if (queryValue === "")
                return;

            jQuery(chatInput).val("");
            UpdateChatWindow(queryValue, null, "user");

            SendChatRequest(queryValue);
        });

    function SendChatRequest(queryValue) {
        var langValue = jQuery(".chat-lang").val();
        var dbValue = jQuery(".chat-db").val();
        var idValue = jQuery(".chat-id").val();

        jQuery(".message ul").removeClass("enabled").addClass("disabled");
        jQuery(".message .user-option, .message .user-selection").off("click");
        
        jQuery
            .post(jQuery(chatForm).attr("action"), GenerateActivity(queryValue, langValue, dbValue, idValue))
            .done(function (r) {
                chatConversationData = r.conversation;
                UpdateChatWindow(r.Text, r.ChannelData, "bot");
            })
            .fail(function (xhr, status, error) {
                var statusMsg = (xhr.status != null) 
                    ? xhr.status + ":" + error
                    : error;

                var troubleText = jQuery(".trouble-message").text();
                UpdateChatWindow(troubleText + "...<br/><br/>" + statusMsg, null, "bot");
            });
    }

    function UpdateChatWindow(text, channelData, type) {
        var convoBox = jQuery(chatConversation);
        convoBox.append("<div class='" + type + "'><span class='message'>" + text + "<span class='icon'></span></span></div>");

        if (channelData != null) {
            //options
            var optionSet = channelData.OptionSet;
            if (optionSet != null && optionSet.Options != null && optionSet.Options.length > 0)
                HandleOptions(type, optionSet, convoBox);

            //actions
            var action = channelData.Action;
            var selections = channelData.Selections;
            if (action != null && selections != null)
                HandlActions(type, action, selections, convoBox);
        }
        
        convoBox.scrollTop(convoBox[0].scrollHeight - convoBox.height());
    }

    function HandleOptions(type, optionSet, convoBox)
    {
        var optionList = "";
        if (optionSet.OptionType === "Link") {
            for (i = 0; i < optionSet.Options.length; i++) {
                optionList += "<li class='user-option' data-option='" + optionSet.Options[i] + "'>" + optionSet.Options[i] + "</li>";
            }
            convoBox.append("<div class='" + type + "'><span class='message'><ul class='enabled'>" + optionList + "</ul><span class='icon'></span></span></div>");

            jQuery(".enabled .user-option")
                .on('click', function ()
                {
                    var optionValue = jQuery(this).data("option");
                    UpdateChatWindow(optionValue, null, "user");
                    SendChatRequest(optionValue);
                });
        }
        if (optionSet.OptionType === "Radio") {

        }
        if (optionSet.OptionType === "Checkbox") {

        }
    }

    function HandlActions(type, action, selections, convoBox)
    {
        if (action === "logout")
        {
            var formData = {};
            formData.__RequestVerificationToken = jQuery("input[name=__RequestVerificationToken]").val();

            jQuery
                .post("/sitecore/shell/api/sitecore/Authentication/Logout?sc_database=master", formData)
                .done(function (msg) {
                    location.href = "/sitecore/login";
                });
        }
        else if (action === "confirm")
        {
            var clearText = jQuery(".clear-message").text();
            var continueText = jQuery(".continue-message").text();
            var cancelText = jQuery(".cancel-message").text();

            var selectionList = "";
            for (var i in selections) {
                selectionList += "<li class='user-selection' data-selection='" + clearText + " " + i + "'><b>" + i + "</b>: " + selections[i] + "</li>";
            }
            selectionList += "<li class='user-selection confirm-continue' data-selection='" + continueText + "'>" + continueText + "</li>";
            selectionList += "<li class='user-selection confirm-cancel' data-selection='" + cancelText + "'>" + cancelText + "</li>";
            convoBox.append("<div class='" + type + "'><span class='message'><ul class='enabled'>" + selectionList + "</ul><span class='icon'></span></span></div>");

            //click to clear a selection
            jQuery(".enabled .user-selection")
                .on('click', function () {
                    var selectionValue = jQuery(this).data("selection");
                    UpdateChatWindow(selectionValue, null, "user");
                    SendChatRequest(selectionValue);
                });
        }
    }

    function GenerateActivity(query, langValue, dbValue, idValue) {

        var data = {
            language: "en",
            database: "master",
            id: "{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}"
        };

        var activity = {
            type: "message",
            id: GenerateGuid(),
            timestamp: Date.now(),
            channelId: "ole",
            from: {
                id: "2c1c7fa3",
                name: "User1"
            },
            conversation: {
                isGroup: false,
                id: "8a684db8",
                name: "Conv1"
            },
            recipient: {
                id: "56800324",
                name: "Bot1"
            },
            text: query,
            attachments: [],
            entities: [],
            channelData: JSON.stringify(data)
        }

        return activity;
    }

    function GenerateGuid() {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
    }
});

//setup
jQuery(document).ready(function () {
    //handles setup form
    var setupForm = ".setup-form";
    jQuery(setupForm + " button")
        .click(function (event) {
            event.preventDefault();

            var overwriteValue = jQuery(setupForm + " input[name='overwriteOption']:checked").val();
            var luisValue = jQuery(setupForm + " #luisApi").val();
            var luisEndpointValue = jQuery(setupForm + " #luisApiEndpoint").val();
            var textAnalyticsValue = jQuery(setupForm + " #textAnalyticsApi").val();
            var textAnalyticsEndpointValue = jQuery(setupForm + " #textAnalyticsApiEndpoint").val();
            
            jQuery(".result-failure").hide();
            jQuery(".result-success").hide();
            jQuery(".progress-indicator").show();

            jQuery.post(
                jQuery(setupForm).attr("action"),
                {
                    overwriteOption: overwriteValue,
                    luisApi: luisValue,
                    luisApiEndpoint: luisEndpointValue,
                    textAnalyticsApi: textAnalyticsValue,
                    textAnalyticsApiEndpoint: textAnalyticsEndpointValue
                }
            ).done(function (r) {
                if (r.Failed) {
                    jQuery(".result-failure .item-list").text(r.Items);
                    jQuery(".result-failure").show();
                } else {
                    jQuery(".result-success").show();
                }

                jQuery(".progress-indicator").hide();
            });
        });
});