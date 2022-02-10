<!DOCTYPE html>

<html class="flex-html">
<head>
    <meta name="viewport" content="width=device-width" />
    <title>@ViewData("Title")</title>

    <link href="@Url.Content("~/Content/kendo/2017.2.504/" & Html.KendoCss.common)" rel="stylesheet" />
    <link href="@Url.Content("~/Content/kendo/2017.2.504/" & Html.KendoCss.style)" rel="stylesheet" />
    <link href="@Url.Content("~/Content/app.css")" rel="stylesheet" type="text/css" />


    <link rel="icon" type="image/png" href="~/favicon-16x16.png" sizes="16x16">
    <link href="@Url.Content("~/Content/font-awesome.css")" rel="stylesheet" />

    <!-- kendo js -->
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/jquery.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/kendo.all.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/aspnetmvc.min.js")"></script>

    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/cultures/kendo.culture." & Culture & ".min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/messages/kendo.messages." & Culture & ".min.js")"></script>

    <script src="@Url.Content("~/Scripts/krendo.helper.js")"></script>
    <script src="@Url.Content("~/Scripts/google.map.helper.js")"></script>

    <script>
        var siteRoot = "@(Request.ApplicationPath)";
        kendo.culture("@Culture");

        function gpsMarker(GPSValid, AddrLocalGovernment) {
            if (GPSValid) {
                if (AddrLocalGovernment) {
                    return '<a data-bind="events: { click: setGps }" href="#" class="fa fa-map-marker" style="color: #033aff"></a>';
                } else {
                    return '<a data-bind="events: { click: setGps }" href="#" class="fa fa-map-marker" style="color: green"></a>';
                }
            } else {
                return '<a data-bind="events: { click: setGps }" href="#" class="fa fa-map-marker" style="color: red"></a>';
            }
        }

        //*************************************************************************************************************
        var settings = {
            splitter: {},
            grids: [],
            dashboard: [
                { "id": "sort_sp_DSHB_10_01", "col": 0, "index": 0, "toggle": false },
                { "id": "sort_sp_DSHB_10_04", "col": 0, "index": 1, "toggle": false },
                { "id": "sort_sp_DSHB_10_07", "col": 0, "index": 2, "toggle": false },
                { "id": "sort_sp_DSHB_10_02", "col": 1, "index": 3, "toggle": false },
                { "id": "sort_sp_DSHB_10_05", "col": 1, "index": 4, "toggle": false },
                { "id": "sort_sp_DSHB_10_08", "col": 1, "index": 5, "toggle": false },
                { "id": "sort_sp_DSHB_10_09", "col": 2, "index": 6, "toggle": false },
                { "id": "sort_sp_DSHB_10_03", "col": 2, "index": 7, "toggle": false },
                { "id": "sort_sp_DSHB_10_10", "col": 3, "index": 8, "toggle": false }
            ],
            sortable: [
            @Code
                Select Case Html.CurAction
                    Case "Dashboard"
                        @<text>{ "id": "sort_sp_DSHB_10_01", "index": 0, "toggle": false },</text>
                        @<text>{ "id": "sort_sp_DSHB_10_04", "index": 1, "toggle": false },</text>
                        @<text>{ "id": "sort_sp_DSHB_10_07", "index": 2, "toggle": false },</text>
                        @<text>{ "id": "sort_sp_DSHB_10_02", "index": 3, "toggle": false },</text>
                        @<text>{ "id": "sort_sp_DSHB_10_05", "index": 4, "toggle": false },</text>
                        @<text>{ "id": "sort_sp_DSHB_10_08", "index": 5, "toggle": false },</text>
                        @<text>{ "id": "sort_sp_DSHB_10_09", "index": 6, "toggle": false },</text>
                        @<text>{ "id": "sort_sp_DSHB_10_03", "index": 7, "toggle": false },</text>
                        @<text>{ "id": "sort_sp_DSHB_10_10", "index": 8, "toggle": false },</text>
                    Case "News"
                        @<text>{ "id": "B3_podzal_Seznam", "index": 0, "toggle": false },</text>
                        @<text>{ "id": "B3_podzal_DetailSpisu", "index": 1, "toggle": false },</text>
                        @<text>{ "id": "B3_podzal_DoslePlatby", "index": 2, "toggle": true },</text>
                    Case "PersonalVisit"
                        @<text>{ "id": "B3_podzal_DetailSpisu", "index": 0, "toggle": false },</text>
                        @<text>{ "id": "B3_podzal_Kontakty", "index": 1, "toggle": false },</text>
                        @<text>{ "id": "B3_podzal_DoslePlatby", "index": 2, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_DalsiOsoby", "index": 3, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Dokumentace", "index": 4, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Historie", "index": 5, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Seznam", "index": 6, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Terminy", "index": 7, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Specifikace", "index": 8, "toggle": true },</text>
                    Case "Agreements"
                        @<text>{ "id": "B3_podzal_DoslePlatby", "index": 0, "toggle": false },</text>
                        @<text>{ "id": "B3_podzal_DetailSpisu", "index": 1, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Kontakty", "index": 2, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_DalsiOsoby", "index": 3, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Dokumentace", "index": 4, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Historie", "index": 5, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Seznam", "index": 6, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Terminy", "index": 7, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Specifikace", "index": 8, "toggle": true },</text>
                    Case "ToProcess"
                        @<text>{ "id": "B3_podzal_DetailSpisu", "index": 0, "toggle": false },</text>
                        @<text>{ "id": "B3_podzal_Kontakty", "index": 1, "toggle": false },</text>
                        @<text>{ "id": "B3_podzal_DoslePlatby", "index": 2, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_DalsiOsoby", "index": 3, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Dokumentace", "index": 4, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Historie", "index": 5, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Seznam", "index": 6, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Terminy", "index": 7, "toggle": true },</text>
                        @<text>{ "id": "B3_podzal_Specifikace", "index": 8, "toggle": true },</text>
                    Case "Finished"
                End Select
            End Code
            ],
            visible1: true,
            visible2: false,
        };

        var options = localStorage["eos-splitter-@Html.CurAction"];
        if (options) {
            options = JSON.parse(options);
        } else {
            options = settings
        };

        function loadSettings() {
            if (options.grids) {
                $.each(options.grids, function (i, e) {
                    var obj = $("#" + e.id).data("kendoGrid");
                    if (obj) {
                        obj.setOptions(e.options);
                    };
                });
            };

            //rozlozeni velkeho splitru
            if (options.splitter) {
                var obj = $("#splitter").data("kendoSplitter");
                if (obj) {
                    $.each(options.splitter.panes, function (index, pane) {
                        var p = $("#splitter").children(".k-pane")[index];
                        if (pane.collapsible) {
                            if (pane.size > 0) {
                                obj["expand"](p);
                                obj.size(p, (pane.size + "px"));
                            } else {
                                obj["collapse"](p);
                                if ($(p)[0].id == "splitter-left-pane") {
                                    $("li[data-action=3] .fa").removeClass("fa-arrow-left").addClass("fa-arrow-right");
                                } else {
                                    $("li[data-action=4] .fa").removeClass("fa-arrow-right").addClass("fa-arrow-left");
                                }
                            };
                        };
                    });
                };
            };

            //sorteni a otvirani/zavirani podzalozek
            if (options.sortable) {
                $.each(options.sortable, function (index, pane) {
                    var obj = $("#" + pane.id);
                    if (obj) {
                        obj.attr("data-index", pane.index);
                        if (pane.toggle) {
                            obj.children(".panel-header").click();
                        };
                    };
                });
                $("#splitter-center-panels > div").sort(function (a, b) {
                    return a.dataset.index > b.dataset.index;
                }).appendTo('#splitter-center-panels');
            };

            if (options.dashboard) {
                var el = $("#body");
                if (el.length > 0) {
                    var sort = options.dashboard.sort(function (a, b) {
                        var x = a["index"]; var y = b["index"];
                        return ((x < y) ? -1 : ((x > y) ? 1 : 0));
                    });
                    $.each(sort, function (index, pane) {
                        var obj = $("#" + pane.id);
                        var col = $('[data-id="' + pane.col + '"]');
                        obj.appendTo(col);
                    })
                }
            }
        };

        function saveSettings() {
            kendo.ui.progress($("body"), true);

            try {
                $.each($(".k-grid"), function (i, e) {
                    var obj = $(this).data("kendoGrid");
                    var id = $(this)[0].id;
                    if (id) {
                        settings.grids.push({ id: id, options: obj.getOptions() });
                    };
                });
            } catch (ex) { console.log(ex) }

            try {
                var obj = $("#splitter").data("kendoSplitter");
                if (obj) {
                    $.each($("#splitter").children(".k-pane"), function (i, e) {
                        obj.options.panes[i].size = $(this).width();
                    });
                    settings.splitter = { panes: obj.options.panes };
                }
            } catch (ex) { console.log(ex) }

            try {
                var obj = $("#splitter-center-panels").data("kendoSortable");
                if (obj) {
                    var items = $(obj.options.connectWith + " " + obj.options.filter);
                    $.each(items, function (i, e) {
                        var id = $(this)[0].id;
                        if (id) {
                            var index = $(this).index();
                            $.grep(settings.sortable, function (pan) {
                                if (pan.id === id) {
                                    pan.index = index;
                                    pan.toggle = !$("#" + id).find(".panel-body").is(':visible');
                                }
                            });
                        };
                    });
                }
            } catch (ex) { console.log(ex) }

            try {
                var obj = $("#body").data("kendoSortable");
                if (obj) {
                    var items = obj.items();
                    $.each(items, function (i, e) {
                        var id = $(this)[0].id;
                        var col = $(this).closest(".col").data("id");
                        var index = obj.indexOf(this);
                        $.grep(settings.dashboard, function (pan) {
                            if (pan.id === id) {
                                pan.col = col;
                                pan.index = index;
                            }
                        });
                    })
                }
            } catch (ex) { console.log(ex) }

            try {
                localStorage["eos-splitter-@Html.CurAction"] = kendo.stringify(settings);
                setTimeout(function () {
                    kendo.ui.progress($("body"), false);
                }, 1000);
            } catch (ex) { console.log(ex) }

        };


    </script>
</head>

<body class="flex-body k-content" style="opacity: 0">
    <noscript>
        <meta http-equiv="refresh" content="0.0;url=http://www.enable-javascript.com/cs">
    </noscript>
    <!-- navbar -->
    @Code
        If Not Html.CurAction = "Registration" Then
        @<div id="head" class="k-header">
            <div id="appheader">
                <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 60 60">
                    <g fill="none" fill-rule="evenodd">
                        <path fill="#666366" d="M0 21.085V60h60V19a77.082 77.082 0 0 1-32.54 7.164A76.81 76.81 0 0 1 0 21.084"></path>
                        <path fill="#FFF" d="M53.48 35.912a15.25 15.25 0 0 0-5.43-.91c-2.89 0-6.32.85-6.32 4.33 0 3 3.69 3.54 6 3.82 1.74.27 4.09.27 4.09 2.63 0 2.57-2.65 3.12-4.71 3.12s-4.69-1.32-5-3.44c0-.15 0-.28-.15-.28s-.13.08-.23.47l-.73 2.53a15.94 15.94 0 0 0 6.23 1.25c3.08 0 6.94-1.12 6.94-4.86 0-1.34-.57-3.08-4.37-3.59-3.25-.45-5.69-.36-5.69-2.93 0-2.14 2.27-2.52 4-2.52 2.61 0 4 1.25 4.5 2.74.01.06.053.11.11.13a.6.6 0 0 0 .21-.45l.55-2.04zM35.16 42.22c0 3.16-1.32 6.68-5.18 6.68-3.86 0-5.18-3.52-5.18-6.68 0-3.16 1.32-6.68 5.18-6.68 3.86 0 5.18 3.52 5.18 6.68m2.84 0c0-4.37-3.86-7.22-8-7.22-4.14 0-8 2.84-8 7.22s3.86 7.21 8 7.21c4.14 0 8-2.84 8-7.21m-28-5.69h3.9c2 0 4.24.76 5.13 2.23a.36.36 0 0 0 .25.19.15.15 0 0 0 .11-.17 3 3 0 0 0-.19-.78l-.57-2h-12c-.32 0-.4 0-.4.13.1.095.225.16.36.19.85.21.93 1.12.93 2.5V46c0 1.93-.15 2.52-.93 3.14-.14.16-.59.29-.59.35a.79.79 0 0 0 .64.08h12.92l.93-3.06a1.06 1.06 0 0 0 0-.17.06.06 0 0 0-.06-.06 2.88 2.88 0 0 0-.57.45 9 9 0 0 1-5.5 2.27H12c-1.44 0-2-.34-2-1.89v-4.43h3.29c1.49 0 3.23.08 3.84 1.66.01.12.073.23.17.3.06 0 .08-.08.08-.44v-3.5c0-.21 0-.32-.08-.32a.23.23 0 0 0-.17.19c-.3.87-1.65 1.59-3.2 1.59H10v-5.63z"></path>
                        <path fill="#9C301A" d="M0 0v18.442A76.417 76.417 0 0 0 23.1 22 76.507 76.507 0 0 0 60 12.583V0H0z"></path>
                    </g></svg>
                @Html.Raw(String.Format("<span id='appname'>{0}</span> <span id='appdescription'>{1}</span>",Language.layoutmasTXT14,Language.layoutmasTXT15))
                @*@Html.Raw(String.Format(Language.layoutmasTXT1, Language.layoutmasTXT14, Language.layoutmasTXT15))*@
                <span class="k-link" style="float: right; padding-top: 25px;" data-bind="text: clock"></span>
                <span class="k-link" style="float: right; padding-top: 25px; margin-right: 20px" data-bind="text: logout"></span>
            </div>
            <ul id="layoutmenu" data-role="menu" data-scrollable="true" data-open-on-click="true" data-close-on-click="false">
                <li class="@(If(Html.CurAction = "Dashboard", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT2, "Dashboard", "Home")</li>
                <li class="@(If(Html.CurAction = "News", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT3, "News", "Home")</li>
                <li class="@(If(Html.CurAction = "PersonalVisit", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT4, "PersonalVisit", "Home")</li>
                <li class="@(If(Html.CurAction = "Agreements", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT5, "Agreements", "Home")</li>
                <li class="@(If(Html.CurAction = "ToProcess", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT6, "ToProcess", "Home")</li>
                <li class="@(If(Html.CurAction = "Finished", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT7, "Finished", "Home")</li>
                <li class="@(If(Html.CurAction = "CashRegister", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT8, "CashRegister", "Home")</li>
                <li class="@(If(Html.CurAction = "Reminder", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT9, "Reminder", "Home")</li>
                <li class="@(If(Html.CurAction = "Tracing", "k-state-selected", ""))">@Html.ActionLink(Language.layoutmasTXT10, "Tracing", "Home")</li>
                <li><div style="width:100px"></div></li>
                <li id="menu-separator"></li>
                @Code
                        If User.Identity.IsAuthenticated Then
                    @<li data-bind="events: { click: searchDialog }"><i class="fa fa-search" aria-hidden="true"></i> @Language.searchBtn</li>
                    @<li>
                        @Language.layoutmasTXT13
                        <ul>
                            <li data-bind="events: { click: defSettings }">@Language.layoutmasTXT17</li>
                            <li data-bind="events: { click: saveSettings }">@Language.layoutmasTXT18</li>
                            <li>@Language.layoutmasTXT19
                                <ul>
                                    <li>@Html.ActionLink("EOS profil", "ChangeTemplate", "Base", New With {.common = "kendo.common-material.min.css", .style = "agiloforeos.min.css"}, Nothing)</li>
                                    <li>@Html.ActionLink("Night profil", "ChangeTemplate", "Base", New With {.common = "kendo.common.min.css", .style = "agiloblack.min.css"}, Nothing)</li>
                                    <li>@Html.ActionLink("Grey profil", "ChangeTemplate", "Base", New With {.common = "kendo.common-material.min.css", .style = "kendo.materialag.min.css"}, Nothing)</li>
                                    <li>@Html.ActionLink("Blue profil", "ChangeTemplate", "Base", New With {.common = "kendo.common-material.min.css", .style = "agiloblue.min.css"}, Nothing)</li>
                                </ul>
                            </li>
                           @* <li>
                                <a class="k-link" href="@Url.Action("Dashboard", "Home")?q=1">Vrátit všechny spisy do stavu 11 pro testování aplikace</a></li>
                            <li>
                                <a class="k-link" href="@Url.Action("Dashboard", "Home")?q=2">Budou přesunuty první 2 spisy z OSN s platnou dohodou, tzn. má čekající SK</a></li>*@
                            @*<li>
                                <p>Emailová adresa pro odesílání žádostí o vrácení spisu</p>
                                <form method="post" action="@Url.Action("Dashboard", "Home")?e=0">
                                    <input type="email" name="email" class="k-textbox" value="@ViewBag.TestEmail" />
                                    <button type="submit" class="k-button">@Html.Raw(Language.btnSave)</button>
                                </form>
                            </li>*@
                        </ul>
                    </li>
                    @<li>@Language.layoutmasTXT12
                        <ul>
                            <li>@Language.layoutmasTXT20
                                <ul data-bind="source: files" data-template="filemanualpdf"></ul>
                            </li>
                            <li>
                                <a href="@Url.Action("EOSTRACE.html", "Help/IP")" target="_blank">@Html.Raw(Language.PopisProgramu)</a>
                            </li>
                            <li>
                                <a href="@Url.Action("EOSTRACETAB.html", "Help/TABLET")" target="_blank">@Html.Raw(Language.PopisTablet)</a>
                            </li>
                            <li>
                                <a href="#" data-bind="events: { click: about }">About</a>
                            </li>
                        </ul>
                    </li>  
                    @<li>
                        @User.Identity.Name
                        <ul>
                            <li>
                                <div class="user_inf">
                                    <div class="avatar-circle k-primary">
                                        <span class="initials">@ViewBag.UserInitials</span>
                                    </div>
                                    <p>@ViewBag.FullUserName</p>
                                    @Html.ActionLink(Language.layoutmasTXT11, "LogOut", "Account", New With {.ReturnUrl = Request.RawUrl}, New With {.class = "k-button k-primary"})
                                </div>
                            </li>
                        </ul>
                    </li>
                    @<li>
                        <img src="~/Images/Flags/@(Culture).png" />
                        @Culture
                        <ul>
                            <li class="k-item" role="menuitem"><a href="@(Url.Action("Translate", "Base"))?culture=cs-CZ">
                                <img class="k-image" alt="" src="@Url.Content("~/Images/Flags/cs-CZ.png")">
                                @(New System.Globalization.CultureInfo("cs-CZ").Name)</a></li>
                            <li class="k-item" role="menuitem"><a href="@(Url.Action("Translate", "Base"))?culture=en-GB">
                                <img class="k-image" alt="" src="@Url.Content("~/Images/Flags/en-GB.png")">
                                @(New System.Globalization.CultureInfo("en-GB").Name)</a></li>
                            <li class="k-item" role="menuitem"><a href="@(Url.Action("Translate", "Base"))?culture=de-DE">
                                <img class="k-image" alt="" src="@Url.Content("~/Images/Flags/de-DE.png")">
                                @(New System.Globalization.CultureInfo("de-DE").Name)</a></li>
                        </ul>
                    </li>
                        Else
                    @<li>@Html.ActionLink(Language.layoutmasTXT16, "Login", "Account")</li>
                        End If
                End Code
            </ul>
            <script id="filemanualpdf" type="text/html">
                <li class="k-item" role="menuitem"><a href="\\#" class="k-link" data-bind="html: Html, events: { click: getManualPDF }"></a></li>
            </script>
        </div>
        End If
        
        
        
    End Code
    <!-- navbar end -->

    @RenderBody()

    @Html.Partial("~/Views/Objects/About.vbhtml")
    @Html.Partial("~/Views/Objects/AddressParser.vbhtml") 
    @Html.Partial("~/Views/Objects/Notification.vbhtml")
    @Html.Partial("~/Views/Objects/ProgressBarDialog.vbhtml")
    @Html.Partial("~/Views/Objects/CustomAlert.vbhtml")
    @Html.Partial("~/Views/Objects/CustomConfirm.vbhtml")
    @Html.Partial("~/Views/Objects/CustomMessage.vbhtml")
    @Html.Partial("~/Views/Objects/SearchDialog.vbhtml") @*[sp_Get_GlobalFind]*@

    <script>
        var googleIsLoad = false;
        kendo.ui.progress($("html"), true);
        $(window).load(function () {
            $("body").fadeTo(1000, 1, function () {
                $(window).resize();
                kendo.ui.progress($("html"), false);

                $.ajax({
                    url: 'https://maps.googleapis.com/maps/api/js?v=3.exp&key=@(Html.Settings("GoogleApiKey"))&sensor=true&async=2',
                    dataType: 'script',
                    timeout: 10000,
                    success: function () {
                        googleIsLoad = true;
                        //urady();
                    },
                    error: function () {
                        console.log("googleapis error");
                        message(" @Html.Raw(SystemMessages.isOffLine) ", "warning");
                    }
                });
            });
        });

        @*function urady() {
            $.get('@Url.Action("Urady", "Api/Service")', null, function (result) {
                var geocoder = new google.maps.Geocoder();
                var count = 0;
                if (geocoder) {
                    var len = result.length,
                        loop = function (index, data) {
                            var addr = data[index]["AdresaUradu"];
                            console.log(addr)
                            geocoder.geocode({
                                address: addr
                            }, function (responses) {
                                if (responses && responses.length > 0) {
                                    var lat = responses[0].geometry.location.lat();
                                    var lng = responses[0].geometry.location.lng();
                                    setTimeout(function () {
                                        $.ajax({
                                            method: "GET",
                                            url: '@Url.Action("UUrad", "Api/Service")',
                                            data: { id: data[index]["IDUradu"], lat: lat, lng: lng }
                                        }).done(function () {
                                            count++
                                            index++
                                            console.clear();
                                            console.log(count);
                                            if (count == 100) {
                                                location.reload();
                                            }
                                            if (index < len) {
                                                loop(index, data);
                                            }
                                        });
                                    }, 1000);
                                } else {
                                    setTimeout(function () {
                                        count++
                                        index++
                                        console.clear();
                                        console.log(count);
                                        if (count == 100) {
                                            location.reload();
                                        }
                                        if (index < len) {
                                            loop(index, data);
                                        }
                                    }, 1000);
                                }
                            });
                        };
                    loop(0, result);
                }
            });
        }*@

        function printDocument(w) {
            //Wait until PDF is ready to print
            if (typeof w.print === 'undefined') {
                setTimeout(function () { printDocument(w); }, 1000);
            } else {
                w.print();
            }
        }

        //bind menu
        var head = kendo.observable({
            clock: "00:00",
            logout: "",
            about: function () {
                About();
            },
            defSettings: function (e) {
                localStorage.clear();
                location.reload();
            },
            saveSettings: function (e) {
                saveSettings();
            },
            searchDialog: function (e) {
                SearchDialog();
            },
            files: new kendo.data.DataSource({
                schema: {
                    model: {
                        id: "ID"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("GetManualFiles", "Base")",
                        dataType: "json"
                    }
                }
            }),
            getManualPDF: function (e) {
               window.open('@Url.Action("PDF", "Base")' + '?fileName=' + e.data.Name, '_blank');
            }
        });
        kendo.bind($("#head"), head);

        $(window).on('resize', function (e) {
            kendo.resize($('.k-grid'));
            kendo.resize($(".k-chart"));

            var winw=$(this).width(), menuliw = 0, resw = 0;
            $.each($("#layoutmenu > li"), function () {
                menuliw += $(this).width();
            })
            resw = winw - menuliw;
            setTimeout(function () {
                if (resw < 0) {
                    $("#menu-separator").width(0);
                } else {
                    $("#menu-separator").width(resw);
                }
            }, 500);
        });

       var styles = [
       'color: #9c301a',
       'text-shadow: rgb(204, 204, 204) 0px 1px 0px, rgb(201, 201, 201) 0px 2px 0px, rgb(187, 187, 187) 0px 3px 0px, rgb(185, 185, 185) 0px 4px 0px, rgb(170, 170, 170) 0px 5px 0px, rgba(0, 0, 0, 0.0980392) 0px 6px 1px, rgba(0, 0, 0, 0.0980392) 0px 0px 5px, rgba(0, 0, 0, 0.298039) 0px 1px 3px, rgba(0, 0, 0, 0.14902) 0px 3px 5px, rgba(0, 0, 0, 0.2) 0px 5px 10px, rgba(0, 0, 0, 0.2) 0px 10px 10px, rgba(0, 0, 0, 0.0980392) 0px 20px 20px;',
       'font-size: 48px',
       'font-weight: bold',
        ].join(';');
        console.log("%c@(Html.Raw(Language.appName))", styles);

        styles = [
       'color: #9c301a',
       'font-size: 24px',
       'font-weight: bold',
        ].join(';');
        console.log("%c@(Html.Raw(Language.consoleTXT2))", styles);

        styles = [
       'color: #9c301a',
       'font-size: 16px'
        ].join(';');
        console.log("%c@(Html.Raw(Language.consoleTXT3))", styles);

        window.onerror = function (messageOrEvent, source, lineno, colno, error) {
            //console.log(messageOrEvent);
            //console.log(source);
            //console.log(lineno);
            //console.log(colno);
            //console.log(error);
        }

        var isFocus = true;
        $(window).on("blur focus", function (e) {
            var prevType = $(this).data("prevType");
            if (prevType != e.type) {
                switch (e.type) {
                    case "blur":
                        //opustil zalozku
                        isFocus = false;
                        break;
                    case "focus":
                        //aktivoval zalozku
                        isFocus = true;
                        //if (typeof viewModel !== 'undefined') {
                        //    if (viewModel.Spisy) {
                        //        viewModel.Spisy.read();
                        //    }
                        //    if (viewModel.SpisyDL) {
                        //        viewModel.SpisyDL.read();
                        //    }
                        //};
                        break;
                };
            };
            $(this).data("prevType", e.type);
        });

        @*window.setInterval(function () {
            head.set("clock", kendo.toString(new Date(), "dddd d.M. yyyy HH:mm"), "@Culture")
            @Code
                If Not Html.CurAction = "Login" Then
                    @<text>
            if (isFocus) {
                CheckIdleTime();
            }
                    </text>
                End If
            End Code
        }, 1000);

        @Code
            If Not Html.CurAction = "Login" Then
                @<text>
        //aktivita uzivatele
        var IDLE_TIMEOUT = 901; //seconds 900=15min
        localStorage.setItem("eosIdleSecondsCounter", 0);
        $(window).on("click focus change", function (e) {
            localStorage.setItem("eosIdleSecondsCounter", 0);
        }).on("mousemove keyup", function (e) {
            localStorage.setItem("eosIdleSecondsCounter", 0);
        });

        function CheckIdleTime() {
            var c = localStorage["eosIdleSecondsCounter"];
            if (c) {
                c++;
                localStorage.setItem("eosIdleSecondsCounter", c);

                if (c >= IDLE_TIMEOUT) {
                    document.location.href = '@Url.Action("Logout", "Account")';
                }

                var sec_num = parseInt(IDLE_TIMEOUT - c, 10);
                var hours = Math.floor(sec_num / 3600);
                var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
                var seconds = sec_num - (hours * 3600) - (minutes * 60);
                if (hours < 10) { hours = "0" + hours; };
                if (minutes < 10) { minutes = "0" + minutes; };
                if (seconds < 10) { seconds = "0" + seconds; };

                $(".logouttime").text("@Html.Raw(Language.LogoutTime)" + minutes + ':' + seconds)
            };
        };
        </text>
            End If
        End Code*@

        $(function () {
            var string = kendo.ui.FilterMenu.prototype.options.operators.string;
            var number = kendo.ui.FilterMenu.prototype.options.operators.number;
            var date = kendo.ui.FilterMenu.prototype.options.operators.number;
            var enums = kendo.ui.FilterMenu.prototype.options.operators.enums;
            var messages = {
                "string": {
                    "contains": string.contains,
                    "eq": string.eq,
                    "neq": string.neq,
                    "startswith": string.startswith,
                    "doesnotcontain": string.doesnotcontain,
                    "endswith": string.endswith,
                    "isempty": "@SystemMessages.IsEmpty",
                    "isnotempty": "@SystemMessages.IsNotEmpty"
                },
                "number": {
                    "eq": number.eq,
                    "neq": number.neq,
                    "gte": number.gte,
                    "gt": number.gt,
                    "lte": number.lte,
                    "lt": number.lt,
                    "isnull": "@SystemMessages.IsEmpty",
                    "isnotnull": "@SystemMessages.IsNotEmpty"
                },
                "date": {
                    "eq": date.eq,
                    "neq": date.neq,
                    "gte": date.gte,
                    "gt": date.gt,
                    "lte": date.lte,
                    "lt": date.lt,
                    "isnull": "@SystemMessages.IsEmpty",
                    "isnotnull": "@SystemMessages.IsNotEmpty"
                },
                "enums": {
                    "eq": enums.eq,
                    "neq": enums.eq,
                    "isnull": "@SystemMessages.IsEmpty",
                    "isnotnull": "@SystemMessages.IsNotEmpty"
                }
            };
            kendo.ui.FilterMenu.prototype.options.operators = messages;
            $(".k-header-column-menu").addClass("k-link");

            @Code
            If Not Html.CurAction = "Login" Then
                @<text>
            localStorage.setItem("eoslogout", "0");
            autoLogout(@Html.AutoLogOfDelay, function (minutes, seconds) {
                head.set("clock", kendo.toString(new Date(), "dddd d.M. yyyy HH:mm"), "@Culture");
                head.set("logout", "@Html.Raw(Language.LogoutTime)" + minutes + ':' + seconds)
            })
            </text>
            End If
            End Code

            loadSettings();


            //var k = $("[class*=k-]");
            //console.log(k)
            
        });
        
        function autoLogout(secconds, callback) {
            var IDLE_TIMEOUT = secconds; //seconds 901=0-15min
            var eosIdleSecondsCounter = 0;

            $(window).on("click focus change", function (e) {
                eosIdleSecondsCounter = 0;
                localStorage.setItem("eoslogout", "0");
            }).on("mousemove keyup", function (e) {
                eosIdleSecondsCounter = 0;
                localStorage.setItem("eoslogout", "0");
            });

            window.setInterval(function () {
                eosIdleSecondsCounter++;

                var logout = localStorage.getItem("eoslogout");
                if (logout === "0") {
                    if (eosIdleSecondsCounter >= IDLE_TIMEOUT) {
                        localStorage.setItem("eoslogout", "1");
                        eosIdleSecondsCounter = 0;
                    }
                } else if (logout === "1") {
                    document.location.href = '@Url.Action("Logout", "Account")' + '?ReturnUrl=' + '@Request.RawUrl';
                }

                var sec_num = parseInt(IDLE_TIMEOUT - eosIdleSecondsCounter, 10);
                var hours = Math.floor(sec_num / 3600);
                var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
                var seconds = sec_num - (hours * 3600) - (minutes * 60);
                if (hours < 10) { hours = "0" + hours; };
                if (minutes < 10) { minutes = "0" + minutes; };
                if (seconds < 10) { seconds = "0" + seconds; };

                callback(minutes, seconds);
            }, 1000)
        }
    </script>
</body>
</html>
