<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>@ViewData("Title")</title>
    
    <link href="@Url.Content("~/Content/kendo/2017.2.504/" & Html.KendoCss.common)" rel="stylesheet" />
    <link href="@Url.Content("~/Content/kendo/2017.2.504/" & Html.KendoCss.style)" rel="stylesheet" />
    <link href="@Url.Content("~/Content/app.css")" rel="stylesheet" type="text/css" />

    <link rel="icon" type="image/png" href="~/favicon-16x16.png" sizes="16x16">
    <link href="@Url.Content("~/Content/font-awesome.css")" rel="stylesheet" />

    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/jquery.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/kendo.all.min.js")"></script>
    <script src="@Url.Content("~/Scripts/jszip.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/aspnetmvc.min.js")"></script>

    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/cultures/kendo.culture." & Culture & ".min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/messages/kendo.messages." & Culture & ".min.js")"></script>

    <script src="@Url.Content("~/Scripts/krendo.helper.js")"></script>
    <script src="@Url.Content("~/Scripts/google.map.helper.js")"></script>
    <script>
        var siteRoot = "@(Request.ApplicationPath)";
        kendo.culture("@Culture");
    </script>

    <style>
        body {
            display: -webkit-box;
            display: -moz-box;
            display: -ms-flexbox;
            display: -webkit-flex;
            display: flex;
            flex-direction: column;
        }

        #administration {
            display: -webkit-box;
            display: -moz-box;
            display: -ms-flexbox;
            display: -webkit-flex;
            display: flex;
            flex-direction: column;
            flex: auto;
        }

        #splitter {
            flex: auto;
        }
    </style>
</head>
<body style="opacity: 0;">
    <div id="head" class="k-header">
        <div id="appheader">
            <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 60 60">
                <g fill="none" fill-rule="evenodd">
                    <path fill="#666366" d="M0 21.085V60h60V19a77.082 77.082 0 0 1-32.54 7.164A76.81 76.81 0 0 1 0 21.084"></path>
                    <path fill="#FFF" d="M53.48 35.912a15.25 15.25 0 0 0-5.43-.91c-2.89 0-6.32.85-6.32 4.33 0 3 3.69 3.54 6 3.82 1.74.27 4.09.27 4.09 2.63 0 2.57-2.65 3.12-4.71 3.12s-4.69-1.32-5-3.44c0-.15 0-.28-.15-.28s-.13.08-.23.47l-.73 2.53a15.94 15.94 0 0 0 6.23 1.25c3.08 0 6.94-1.12 6.94-4.86 0-1.34-.57-3.08-4.37-3.59-3.25-.45-5.69-.36-5.69-2.93 0-2.14 2.27-2.52 4-2.52 2.61 0 4 1.25 4.5 2.74.01.06.053.11.11.13a.6.6 0 0 0 .21-.45l.55-2.04zM35.16 42.22c0 3.16-1.32 6.68-5.18 6.68-3.86 0-5.18-3.52-5.18-6.68 0-3.16 1.32-6.68 5.18-6.68 3.86 0 5.18 3.52 5.18 6.68m2.84 0c0-4.37-3.86-7.22-8-7.22-4.14 0-8 2.84-8 7.22s3.86 7.21 8 7.21c4.14 0 8-2.84 8-7.21m-28-5.69h3.9c2 0 4.24.76 5.13 2.23a.36.36 0 0 0 .25.19.15.15 0 0 0 .11-.17 3 3 0 0 0-.19-.78l-.57-2h-12c-.32 0-.4 0-.4.13.1.095.225.16.36.19.85.21.93 1.12.93 2.5V46c0 1.93-.15 2.52-.93 3.14-.14.16-.59.29-.59.35a.79.79 0 0 0 .64.08h12.92l.93-3.06a1.06 1.06 0 0 0 0-.17.06.06 0 0 0-.06-.06 2.88 2.88 0 0 0-.57.45 9 9 0 0 1-5.5 2.27H12c-1.44 0-2-.34-2-1.89v-4.43h3.29c1.49 0 3.23.08 3.84 1.66.01.12.073.23.17.3.06 0 .08-.08.08-.44v-3.5c0-.21 0-.32-.08-.32a.23.23 0 0 0-.17.19c-.3.87-1.65 1.59-3.2 1.59H10v-5.63z"></path>
                    <path fill="#9C301A" d="M0 0v18.442A76.417 76.417 0 0 0 23.1 22 76.507 76.507 0 0 0 60 12.583V0H0z"></path>
                </g></svg>
            @Html.Raw(String.Format("<span id='appname'>{0}</span> <span id='appdescription'>{1}</span>",Language.layoutmasTXT14,Language.layoutmasTXT15))
            <span class="k-link" style="float: right; padding-top: 25px;" data-bind="text: clock"></span>
        </div>
        <ul id="layoutmenu" data-role="menu" data-scrollable="true" data-open-on-click="true" data-close-on-click="false">
            <li class="@(If(Html.CurAction = "Dashboard", "k-state-selected", ""))">@Html.ActionLink(Language.SVLinkTXT1, "Dashboard", "Administrator")</li>
            <li class="@(If(Html.CurAction = "FileAdministration", "k-state-selected", ""))">@Html.ActionLink(Language.SVLinkTXT2, "FileAdministration", "Administrator")</li>
            <li class="@(If(Html.CurAction = "AdministrationOfConstants", "k-state-selected", ""))">@Html.ActionLink(Language.SVLinkTXT3, "AdministrationOfConstants", "Administrator")</li>
            <li class="@(If(Html.CurAction = "GPSComparison", "k-state-selected", ""))">@Html.ActionLink(Language.SVLinkTXT4, "GPSComparison", "Administrator")</li>
            <li class="@(If(Html.CurAction = "SVCashRegister", "k-state-selected", ""))">@Html.ActionLink(Language.SVLinkTXT5, "SVCashRegister", "Administrator")</li>
            <li class="@(If(Html.CurAction = "SVDefect", "k-state-selected", ""))">@Html.ActionLink(Language.SVLinkTXT6, "SVDefect", "Administrator")</li>
            <li><div style="width:100px"></div></li>
            <li id="menu-separator"></li>
            @Code
                If User.Identity.IsAuthenticated Then
                @<li data-bind="events: { click: searchDialog }"><i class="fa fa-search" aria-hidden="true"></i> @Language.searchBtn</li>
                @<li>
                    @Language.layoutmasTXT13
                    <ul>
                        <li>@Html.ActionLink(Language.UserManagement, "UserManagement", "Account", Nothing, New With {.target = "_blank"})</li>
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
                    </ul>
                </li>
                @<li>@Language.layoutmasTXT12
                    <ul>
                        <li>@Language.layoutmasTXT20
                            <ul data-bind="source: files" data-template="filemanualpdf"></ul>
                        </li>
                        <li>
                            <a href="@Url.Action("EOSTRACE.html", "Help/SV")" target="_blank">@Html.Raw(Language.PopisProgramu)</a>
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
                        <li class="k-item" role="menuitem"><a href="@(Url.Action("Translate", "Base"))?culture=cs-CZ"><img class="k-image" alt="" src="@Url.Content("~/Images/Flags/cs-CZ.png")"> @(New System.Globalization.CultureInfo("cs-CZ").Name)</a></li>
                        <li class="k-item" role="menuitem"><a href="@(Url.Action("Translate", "Base"))?culture=en-GB"><img class="k-image" alt="" src="@Url.Content("~/Images/Flags/en-GB.png")"> @(New System.Globalization.CultureInfo("en-GB").Name)</a></li>
                        <li class="k-item" role="menuitem"><a href="@(Url.Action("Translate", "Base"))?culture=de-DE"><img class="k-image" alt="" src="@Url.Content("~/Images/Flags/de-DE.png")"> @(New System.Globalization.CultureInfo("de-DE").Name)</a></li>
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

    @RenderBody()

    @Html.Partial("~/Views/Objects/About.vbhtml")
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
                    },
                    error: function () {
                        message(" @Html.Raw(SystemMessages.isOffLine) ", "warning");
                    }
                });
            });
        });

        $(window).on('resize', function (e) {
            kendo.resize($('.k-grid'));
            kendo.resize($(".k-chart"));

            var winw = $(this).width(), menuliw = 0, resw = 0;
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
        });

        var menuModel = kendo.observable({
            clock: "00:00",
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
        kendo.bind($("#head"), menuModel);
        window.setInterval(function () {
            menuModel.set("clock", kendo.toString(new Date(), "dddd d.M. yyyy HH:mm"), "@Culture")
        }, 1000);

        function exportPDF(e) {
            var grid = $(e).closest(".k-grid").find(">table");
            var fileName = $(e).data("filename");
            kendo.drawing.drawDOM(grid, {
                author: "EOS",
                creator: "EOS",
                paperSize: "A4",
                scale: 0.7,
                landscape: false,
                repeatHeaders: true,
                margin: { left: "1cm", top: "1cm", right: "1cm", bottom: "1cm" }
            }).then(function (group) {
                return kendo.drawing.exportPDF(group);
            }).done(function (data) {
                kendo.saveAs({
                    dataURI: data,
                    fileName: fileName
                });
            });
        };

        function exportExcel(e) {
            var table = $("<table></table>")
            var parent = $(e).closest(".k-grid");
            var parentGrid = parent.data("kendoGrid");

            //head
            var head = parent.find("tr:first");
            var tr = $("<tr></tr>");
            head.find("th").each(function () {
                var field = $(this).data("field");
                if (field) {
                    tr.append("<th data-field='" + field + ">" + $(this).text() + "</th>")
                };
            })
            table.append(tr);

            //body
            parent.find("tr.k-master-row").each(function (e) {
                var row = this;
                tr = $("<tr></tr>")
                $(row).find("td:not('.k-hierarchy-cell')").each(function () {
                    tr.append("<td>" + $(this).text() + "</td>")
                })
                table.append(tr);

                var detail = $(row).next("tr.k-detail-row");
                if (detail) {
                    var child = detail.find(".k-detail-cell .k-grid");
                    child.find("tbody tr").each(function (e) {
                        row = this;
                        tr = $("<tr></tr>")
                        $(row).find("td").each(function () {
                            tr.append("<td>" + $(this).text() + "</td>")
                        })
                        table.append(tr);
                    })
                }
            })
            var exportgrid = $(table).kendoGrid({
                excel: {
                    fileName: "Northwind Product List.xlsx",
                    allPages: true,
                    filterable: true
                }
            });
            exportgrid.getKendoGrid().saveAsExcel();
        };
    </script>

    @Html.Partial("~/Views/Objects/AddressParser.vbhtml")
    @Html.Partial("~/Views/Objects/Notification.vbhtml")
    @Html.Partial("~/Views/Objects/ProgressBarDialog.vbhtml")
    @Html.Partial("~/Views/Objects/CustomConfirm.vbhtml")
    @Html.Partial("~/Views/Objects/OSNDatePlanDialog.vbhtml")
</body>
</html>
