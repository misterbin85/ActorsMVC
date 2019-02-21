var mainContent;
var titleContent;

$(function () {
    mainContent = $("#MainContent"); // render partial views.
    titleContent = $("title"); // render titles.
});

$(function () {
    routingApp.run("#/Home/Index"); // default routing page.
});

var routingApp = $.sammy("#MainContent", function () {
    this.get("#/Home/All", function (context) {
        titleContent.html("Main Page");
        $.get("/Home/All", function (data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/Actors", function (context) {
        titleContent.html("Actors");
        $.get("/Home/Actors", function (data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/ActorInfo", function (context) {
        titleContent.html("ActorInfo");
        console.log(context.params.id);
        $.get("/Home/ActorInfo", { id: context.params.id },
            function (data) {
                context.$element().html(data);
            });
    });

    this.get("#/Home/Actresses", function (context) {
        titleContent.html("Actresses");
        $.get("/Home/Actresses", function (data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/Contact", function (context) {
        titleContent.html("Contact");
        $.get("/Home/Contact", function (data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/About", function (context) {
        titleContent.html("About");
        $.get("/Home/About", function (data) {
            context.$element().html(data);
        });
    });
});

function IfLinkNotExist(type, path) {
    if (!(type !== null && path !== null))
        return false;

    var isExist = true;

    if (type.toLowerCase() === "get") {
        if (routingApp.routes.get !== undefined) {
            $.map(routingApp.routes.get, function (item) {
                if (item.path.toString().replace("/#", "#").replace(/\\/g, '').replace("$/", "").indexOf(path) >= 0) {
                    isExist = false;
                }
            });
        }
    } else if (type.toLowerCase() === "post") {
        if (routingApp.routes.post !== undefined) {
            $.map(routingApp.routes.post, function (item) {
                if (item.path.toString().replace("/#", "#").replace(/\\/g, '').replace("$/", "").indexOf(path) >= 0) {
                    isExist = false;
                }
            });
        }
    }
    return isExist;
}