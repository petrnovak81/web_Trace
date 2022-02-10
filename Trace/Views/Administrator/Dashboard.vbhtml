@Code
    ViewData("Title") = "Dashboard"
    Layout = "~/Views/Shared/_AdminLayout.vbhtml"
End Code

<style>
    #body {
        height:100%;
        display: flex;
        flex-direction: column;
    }

    main {
        display: flex;
        flex-direction: row;
        height: 100%;
        width: 100%;
    }

    .col {
        flex: 1;
        display: flex;
        flex-direction: column; 
        overflow: auto; 
    }

    .cell {
        margin: 6px;
        /*background: #fff;*/
        -webkit-box-shadow: 0px 0px 8px 0px rgba(143,143,143,1);
        -moz-box-shadow: 0px 0px 8px 0px rgba(143,143,143,1);
        box-shadow: 0px 0px 8px 0px rgba(143,143,143,1);
    }

    .toolbar-chart {
        height: 100px;
    }

    .k-grid td.k-detail-cell {
    padding: 0;
}

    .k-grid td.k-detail-cell .k-grid-header {
        display: none;
    }

    .k-grid-content tr td {
    border-left-width: 1px;
}
</style>

<div id="body" class="k-content">
    <ul data-role="menu" style="border-top: 1px solid">
        <li class="k-item k-state-default" data-bind="html:dshTitle, events: { click: dshRefresh }"></li> 
        <li style="float: right;" class="k-item k-state-default" data-bind="events: { click: docManager }">@Html.Raw(Language.SVDashboardTXT11)</li>
    </ul>

    <main>
    <div class="col">
        <div class="cell">
            <!-- ******************************sp_DSHB_1_1******************************* -->
            <div data-role="grid" class="vertical-header"
            data-scrollable="false"
            data-selectable="true"
            style="height: 70%"
            data-columns="[
            { 'headerTemplate': '@(Html.ActionLink(Language.sp_DSHB_1_1LIN1, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_1"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold"}).ToHtmlString)', 'template': '@Html.Raw(Language.SVDashboardTXT16)' },
            { 'field': 'New', 'headerTemplate': '<span data-content=\'@Html.Raw(Language.SVDashboardTXT12)\' class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT12)</span>', 'template': '#=CellInt(New, \'center\')#', 'width': 30 },
            { 'field': 'Visits', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT13)</span>', 'template': '#=CellInt(Visits, \'center\')#', 'width': 30 },
            { 'field': 'Agreements', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT14)</span>', 'template': '#=CellInt(Agreements, \'center\')#', 'width': 30 },
            { 'field': 'ToProcess', 'headerTemplate':'<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT15)</span>', 'template': '#=CellInt(ToProcess, \'center\')#', 'width': 30 },
            { 'field': 'Suma', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT16)</span>', 'template': '#=CellInt(Suma, \'center\')#', 'width': 30 },
            { 'field': 'Closed', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT17)</span>', 'template': '#=CellInt(Closed, \'center\')#', 'width': 30 }
            ]"
            data-bind="source: sp_DSHB_1_1, events: {change: sp_DSHB_1_1_select, dataBound: sp_DSHB_1_1_DataBound }"></div>

            <script id="sp_DSHB_1_1_Detail" type="text/html">
            <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-selectable="true"
            data-columns="[
            { 'field': 'Name', 'template': '\\#=CellString(Name)\\#' },
            { 'field': 'New', 'template': '\\#=CellInt(New, \\'center\\')\\#', 'width': 30 },
            { 'field': 'Visits', 'template': '\\#=CellInt(Visits, \\'center\\')\\#', 'width': 30 },
            { 'field': 'Agreements', 'template': '\\#=CellInt(Agreements, \\'center\\')\\#', 'width': 30 },
            { 'field': 'ToProcess', 'template': '\\#=CellInt(ToProcess, \\'center\\')\\#', 'width': 30 },
            { 'field': 'Suma', 'template': '\\#=CellInt(Suma, \\'center\\')\\#', 'width': 30 },
            { 'field': 'Closed', 'template': '\\#=CellInt(Closed, \\'center\\')\\#', 'width': 30 }            
            ]"
            data-bind="source: sp_DSHB_1_1_Detail, events: { change: sp_DSHB_1_1_select }">
            </div>
            </script>
            <div data-role="chart"
            style="height: 30%"
            data-legend="{ position: 'bottom', visible: false }"
            data-series-defaults="{ type: 'bar', labels: { visible: true } }"
            data-series="[
            { 'field': 'New', 'name': '@Html.Raw(Language.SVDashboardTXT12)' },
            { 'field': 'Visits', 'name': '@Html.Raw(Language.SVDashboardTXT13)' },
            { 'field': 'Agreements', 'name': '@Html.Raw(Language.SVDashboardTXT14)' },
            { 'field': 'ToProcess', 'name': '@Html.Raw(Language.SVDashboardTXT15)' },
            { 'field': 'Closed', 'name': '@Html.Raw(Language.SVDashboardTXT17)'}
            ]"
            data-bind="source: sp_DSHB_1_1_chart" style="height: 100px;"></div>
            <!-- ******************************END sp_DSHB_1_1******************************* -->
        </div>
        <div class="cell">
            <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Describe', 'headerTemplate': '@Html.ActionLink(Language.sp_DSHB_1_2LIN1, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_2"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold"}).ToHtmlString<br><input style=\'width: 100%\' id=\'accountSelect\' />' },
            { 'field': 'ThisMonth', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT18)</span>', 'template': '#=CellInt(ThisMonth, \'center\')#', 'width': 40 },
            { 'field': 'ThisWeek', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT19)</span>', 'template': '#=CellInt(ThisWeek, \'center\')#', 'width': 40 },
            { 'field': 'ThisDay', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT20)</span>', 'template': '#=CellInt(ThisDay, \'center\')#', 'width': 40 }
            ]"
            data-bind="source: sp_DSHB_1_2"></div>
        </div>
    </div>
        <style>
            .kgrid {
                min-width: 440px;
            }
        </style>
    <div class="col">
        <div class="cell">
            <div data-role="grid" class="multicolumn vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Popis', 'headerTemplate': '<a href=\'@Url.Action("SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_3"})\' target=\'_blank\' style=\'font-size:18px;font-weight:bold\' class=\'k-link\'>@Html.Raw(Language.SVDashboardTXT21)<br>@Html.Raw(Language.SVDashboardTXT22)</a>' },
            { 'title': '@Html.Raw(Language.SVDashboardTXT16)', 'columns': [
               { 'field': 'Pocet', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTBL30)</span>', 'template': '#=CellInt(Pocet, \'center\')#', 'width': 40 },
               { 'field': 'Cely', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTBL31)</span>', 'template': '#=CellInt(Cely)#', 'width': 60 }
            ] },
            { 'title': '@Html.Raw(Language.SVDashboardTXT18)', 'columns': [
               { 'field': 'MPocet', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTBL30)</span>', 'template': '#=CellInt(MPocet, \'center\')#', 'width': 40 },
               { 'field': 'MCely', 'headerTemplate':'<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTBL31)</span>', 'template': '#=CellInt(MCely)#', 'width': 60 }
            ] }
            ]"
            data-bind="source: sp_DSHB_1_3"></div>
            <script id="sp_DSHB_1_3_Detail" type="text/html">
            <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Jmeno', 'template': '\\#=CellString(Jmeno, \\'center\\')\\#' },
            { 'field': 'Pocet', 'template': '\\#=CellInt(Pocet, \\'center\\')\\#', 'width': 40 },
            { 'field': 'Cely', 'template': '\\#=CellInt(Cely)\\#', 'width': 60 },
            { 'field': 'MPocet', 'template': '\\#=CellInt(MPocet, \\'center\\')\\#', 'width': 40 },
            { 'field': 'MCely', 'template': '\\#=CellInt(MCely)\\#', 'width': 60 }]"
            data-bind="source: sp_DSHB_1_3_Detail"></div>
            </script>
        </div>
        <div class="cell">
            <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Name', 'headerTemplate': '@Html.ActionLink(Language.sp_DSHB_1_4LIN1, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_4"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold"}).ToHtmlString' },
            { 'field': 'PocetUrg', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT23)</span>', 'template': '#=CellInt(PocetUrg, \'center\')#', 'width': 40 },
            { 'field': 'PocetRemind', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT24)</span>', 'template': '#=CellInt(PocetRemind, \'center\')#', 'width': 40 }
            ]"
            data-bind="source: sp_DSHB_1_4"></div>
            <script id="sp_DSHB_1_4_Detail" type="text/html">
            <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Kategorie', 'template': '\\#=CellString(Kategorie, \\'center\\')\\#' },
            { 'field': 'PocetUrg', 'template': '\\#=CellInt(PocetUrg, \\'center\\')\\#', 'width': 40 },
            { 'field': 'PocetMsg', 'template': '\\#=CellInt(PocetMsg, \\'center\\')\\#', 'width': 40 }]"
            data-bind="source: sp_DSHB_1_4_Detail"></div>
            </script>
        </div>
    </div>
    <div class="col">
        <div class="cell">
            <ul style="list-style-type: none;">
                <li style="padding-bottom:3px">@Html.ActionLink(Language.sp_DSHB_1_7LIN1, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_7"}, New With {.target = "_blank", .class = "k-link"})</li>
                <li style="padding-bottom:3px">@Html.ActionLink(Language.sp_DSHB_1_8LIN1, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_8"}, New With {.target = "_blank", .class = "k-link"})</li>
                <li style="padding-bottom:3px">@Html.ActionLink(Language.sp_DSHB_1_9LIN1, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_9"}, New With {.target = "_blank", .class = "k-link"})</li>
                <li style="padding-bottom:3px">@Html.ActionLink(Language.sp_DSHB_1_10LIN1, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_10"}, New With {.target = "_blank", .class = "k-link"})</li>
                <li style="padding-bottom:3px">@Html.ActionLink(Language.SVDashboardTXT25, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_11"}, New With {.target = "_blank", .class = "k-link"})</li>
                <li style="padding-bottom:3px">@Html.ActionLink(Language.SVDashboardTXT26, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_12"}, New With {.target = "_blank", .class = "k-link"})</li>
                <li style="padding-bottom:3px">@Html.ActionLink(Language.SVDashboardLIN7, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_13"}, New With {.target = "_blank", .class = "k-link"})</li>
                <li style="padding-bottom:3px">@Html.ActionLink(Language.SVDashboardLIN8, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_14"}, New With {.target = "_blank", .class= "k-link"})</li>
            </ul>
        </div>
        <div class="cell">
            <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Name', 'headerTemplate': '@Html.ActionLink(Language.sp_DSHB_1_5LIN1, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_5"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold"}).ToHtmlString' },
            { 'field': 'Dnu', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT27)</span>', 'template': '#=CellInt(Dnu, \'center\')#', 'width': 40 }
            ]"
            data-bind="source: sp_DSHB_1_5"></div>
        </div>
        <div class="cell">
            <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Name', 'headerTemplate': '@Html.ActionLink(Language.SVDashboardLIN10, "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_6"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold"}).ToHtmlString' },
            { 'field': 'Neprijate', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT28)</span>', 'template': '#=CellInt(Neprijate, \'center\')#', 'width': 40 },
            { 'field': 'Prodleni', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.SVDashboardTXT29)</span>', 'template': '#=CellInt(Prodleni, \'center\')#', 'width': 40 }
            ]"
            data-bind="source: sp_DSHB_1_6"></div>
        </div>
    </div>
</main>
</div>

@Html.Partial("~/Views/Objects/SVDocuMng.vbhtml")

<script>
    function sp_DSHB_LastFill(callback) {
        $.get("@Url.Action("sp_DSHB_LastFill", "Api/AdminService")", {}, function (result) {
            callback(result)
        })
    }

    $(function () {
        var viewModel = new kendo.observable({
            dshTitle: function () {
                var that = this;
                sp_DSHB_LastFill(function (result) {
                    var html = '<span class="k-link"><span class="k-icon k-i-reload"></span> @Html.Raw(Language.SVScriptTXT1): ' + result + '</span>'
                    that.set("dshTitle", html);
                });
            },
            dshRefresh: function (e) {
                var that = this;
                kendo.ui.progress($("body"), true);
                $.get("@Url.Action("sp_DSHB_Fill", "Api/AdminService")", {}, function (result) {
                    sp_DSHB_LastFill(function (result) {
                        kendo.ui.progress($("body"), false);
                        var html = '<span class="k-link"><i class="k-icon k-i-reload"></i> @Html.Raw(Language.SVScriptTXT1): ' + result + '</span>'
                        that.set("dshTitle", html);
                        that.sp_DSHB_1_1.read();
                        that.sp_DSHB_1_2.read();
                        that.sp_DSHB_1_3.read();
                        that.sp_DSHB_1_4.read();
                        that.sp_DSHB_1_5.read();
                        that.sp_DSHB_1_6.read();
                    });
                })
            },
            docManager: function (e) {
                SVDocuMng();
            },
            sp_DSHB_1_1: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_1", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_1_DataBound: function (e) {
                var grid = e.sender;
                var row = grid.tbody.find('tr:first');
                grid.select(row);
            },
            sp_DSHB_1_1_Detail: function (e) {
                var that = this;
                var model = new kendo.observable({
                    sp_DSHB_1_1_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_1_Detail", "Api/AdminService")"
                        }
                    }),
                    sp_DSHB_1_1_select: function (e) {
                        var g = $(e.sender.element).data("kendoGrid");
                        var di = g.dataItem(g.select());
                        if (di) {
                            var data = [{
                                "New": di.New,
                                "Vracene": di.Vracene,
                                "Visits": di.Visits,
                                "Agreements": di.Agreements,
                                "ToProcess": di.ToProcess,
                                "Closed": di.Closed
                            }]
                            that.sp_DSHB_1_1_chart.data(data)
                        }
                    }
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_1_select: function (e) {
                var g = $(e.sender.element).data("kendoGrid");
                var di = g.dataItem(g.select());
                if (di) {
                    var data = [{
                        "New": di.New,
                        "Vracene": di.Vracene,
                        "Visits": di.Visits,
                        "Agreements": di.Agreements,
                        "ToProcess": di.ToProcess,
                        "Closed": di.Closed
                    }]
                    this.sp_DSHB_1_1_chart.data(data)
                }
            },
            sp_DSHB_1_1_chart: new kendo.data.DataSource({
                schema: {
                    model: {
                        fields: {
                            New: { type: "number" },
                            Vracene: { type: "number" },
                            Visits: { type: "number" },
                            Agreements: { type: "number" },
                            ToProcess: { type: "number" },
                            Closed: { type: "number" }
                        }
                    }
                },
                data: []
            }),
            sp_DSHB_1_2_iDUser: 0,
            sp_DSHB_1_2: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_2", "Api/AdminService")",
                    parameterMap: function (options, type) {
                        return { iDUser: viewModel.sp_DSHB_1_2_iDUser };
                    }
                }
            }),
            sp_DSHB_1_3: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_3", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_3_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var model = new kendo.observable({
                    sp_DSHB_1_3_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_3_Detail", "Api/AdminService")",
                            parameterMap: function (options, type) {
                                return { Poradi: di.IDValue };
                            }
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_4: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_4", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_4_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var model = new kendo.observable({
                    sp_DSHB_1_4_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_4_Detail", "Api/AdminService")",
                            parameterMap: function (options, type) {
                                return { iDUser: di.IDUser };
                            }
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_5: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_5", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_6: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_6", "Api/AdminService")"
                }
            })
        })
        kendo.bind($("#body"), viewModel);
        
        $(".col").kendoSortable({
            filter: ".cell",
            ignore: "td",
            cursor: "move",
            connectWith: ".col",
            placeholder: placeholder,
            hint: hint,
            end: function (e) {
                setTimeout(function () {
                    $(window).resize();
                }, 500);
            }
        });

        function placeholder(element) {
            return element.clone().addClass("placeholder");
        };

        function hint(element) {
            return element.clone().addClass("hint")
                        .height(element.height() + 18)
                        .width(element.width());
        };

        $("#accountSelect").kendoDropDownList({
            optionLabel: 'Vyberte inspektora...',
            dataTextField: 'text',
            dataValueField: 'value',
            dataSource: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("GetInspectors", "Api/AdminService")",
                    type: "json"
                }
            }),
            change: function (e) {
                var IDUser = e.sender.value();
                if (!IDUser) {
                    viewModel.set("sp_DSHB_1_2_iDUser", 0);
                } else {
                    viewModel.set("sp_DSHB_1_2_iDUser", IDUser);
                }
                viewModel.sp_DSHB_1_2.read();
            }
        });
    })
</script>