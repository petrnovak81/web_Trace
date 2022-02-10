@Code
    ViewData("Title") = Language.layoutmasTXT2
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<style>
    #body {
        height: 100%;
        display: flex;
        flex-direction: column;
    }

    .main {
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

    .k-grid-header th.k-header {
    text-align: center;
}

    .col::-webkit-scrollbar-track {
        background-color: #F5F5F5;
        display: none;
    }

    .col::-webkit-scrollbar {
        width: 5px;
        background-color: #F5F5F5;
        display: none;
    }

    .col::-webkit-scrollbar-thumb {
        background-color: rgba(143,143,143,0.5);
        display: none;
    }
</style>

<div id="body" data-role="splitter"
    data-orientation="vertical"
    data-panes="[
     { collapsible: false, scrollable: false },
     { collapsible: false, scrollable: false, size: 0 }
    ]">
    <div class="main">
        <div data-id="0" class="col connect">
            <div id="sort_sp_DSHB_10_01" class="cell">
                @*Přehled spisů ve správě*@
                <h2 style="text-align:center;opacity:0.8;margin-bottom:0;">@Html.Raw(Language.DashboardTXT13)</h2>
                <div style="text-align:center;opacity:0.7;margin-bottom:6px;"><i data-bind="text: celkemSpisu"></i></div>
                <div id="sp_DSHB_10_01_CHART" style="height:200px"></div>
            </div>
            <div id="sort_sp_DSHB_10_04" class="cell">
                @*Přehled návštěv*@
                <h2 style="text-align:center;opacity:0.8;">@Html.Raw(Language.DashboardTXT21)</h2>
                <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Val', 'headerTemplate': ' ' },
            { 'field': 'Suma', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.DashboardTBL1)</span>', 'template': '#=CellInt(Suma, \'center\')#', 'width': 40 },
            { 'field': 'ThisDay', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.DashboardTBL2)</span>', 'template': '#=CellInt(ThisDay, \'center\')#', 'width': 40 },
            { 'field': 'ThisWeek', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.DashboardTBL31)</span>', 'template': '#=CellInt(ThisWeek, \'center\')#', 'width': 40 },
            { 'field': 'ThisMonth', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.DashboardTBL4)</span>', 'template': '#=CellInt(ThisMonth, \'center\')#', 'width': 40 }
            ]"
            data-bind="source: sp_DSHB_10_04" style="overflow-x:auto;"></div>
            </div>
            <div id="sort_sp_DSHB_10_07" class="cell">
                @*Přehled dohod*@
                <h2 style="text-align:center;opacity:0.8;">@Html.Raw(Language.DashboardTXT31)</h2>
                <div data-role="grid"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Val', 'headerTemplate': ' ', 'template': '#=CellString(Val)#' },
            { 'title': '@Html.Raw(Language.DashboardTBL20)', 'columns': [
               { 'field': 'MPocet', 'headerTemplate': '@Html.Raw(Language.DashboardTBL5)', 'template': '#=CellInt(MPocet, \'center\')#', 'width': 40 },
               { 'field': 'MCely', 'headerTemplate': '@Html.Raw(Language.DashboardTBL6)', 'template': '#=CellMoney(MCely)#', 'width': 60 }
            ] },
            { 'title': '@Html.Raw(Language.DashboardTBL21)', 'columns': [
               { 'field': 'Pocet', 'headerTemplate': '@Html.Raw(Language.DashboardTBL5)', 'template': '#=CellInt(Pocet, \'center\')#', 'width': 40 },
               { 'field': 'Cely', 'headerTemplate': '@Html.Raw(Language.DashboardTBL6)', 'template': '#=CellMoney(Cely)#', 'width': 60 }
            ] }
            ]"
            data-bind="source: sp_DSHB_10_07" style="overflow-x:auto;"></div>
            </div>
        </div>
        <div data-id="1" class="col connect">
            <div id="sort_sp_DSHB_10_02" class="cell">
                @*Návštěvy*@
                <h2 style="text-align:center;opacity:0.8;">@Html.Raw(Language.DashboardTXT41)</h2>
                <div id="sp_DSHB_10_02_CHART" style="height:200px"></div>
            </div>
            <div id="sort_sp_DSHB_10_05" class="cell">
                <h2 style="text-align:center;opacity:0.8;">@Html.Raw(Language.DashboardTXT51)</h2>
                
                <div data-role="grid"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
                    { 'field': 'Popisek', 'headerTemplate': ' ', 'template': '#=CellString(Popisek)#' },
                    { 'field': 'ObjemPohledavek', 'headerTemplate': '@Html.Raw(Language.DSHBtxt1)', 'template': '#=CellMoney(ObjemPohledavek)#', 'width': 100 },
                    { 'field': 'OcekavanePlatby', 'headerTemplate': '@Html.Raw(Language.DSHBtxt2)', 'template': '#=CellMoney(OcekavanePlatby)#', 'width': 100 },
                    { 'field': 'OcekavanaProvize', 'headerTemplate': '@Html.Raw(Language.DSHBtxt3)', 'template': '#=CellMoney(OcekavanaProvize)#', 'width': 100 },
                    { 'field': 'Uhrazeno', 'headerTemplate': '@Html.Raw(Language.DSHBtxt4)', 'template': '#=CellMoney(Uhrazeno)#', 'width': 100 },
                    { 'field': 'ProvizeZUhrazenych', 'headerTemplate': '@Html.Raw(Language.DSHBtxt5)', 'template': '#=CellMoney(ProvizeZUhrazenych)#', 'width': 100 }
            ]"
            data-bind="source: sp_DSHB_10_05" style="overflow-x:auto;"></div>
            </div>
            <div id="sort_sp_DSHB_10_08" class="cell">
                <h2 style="text-align:center;opacity:0.8;margin-bottom:0">@Html.Raw(Language.DashboardTXT61)</h2>
                <div style="text-align:center;opacity:0.7;margin-bottom:6px;"><i>@Html.Raw(Language.DashboardTXT7)</i></div>
                <table data-role="grid" data-scrollable="false">
                    <colgroup>
                        <col />
                        <col style="width:100px" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th data-filed="Item"></th>
                            <th data-field="AvgDuring">@Html.Raw(Language.DashboardTBL9)</th>
                        </tr>
                    </thead>
                    <tbody data-bind="source: sp_DSHB_10_08" data-template="sp_DSHB_10_08_tmp">

                    </tbody>
                </table>
                <script id="sp_DSHB_10_08_tmp" type="text/html">
                    <tr>
                        <td>#=Item#</td>
                        <td style="text-align:center;"><b>#=(AvgDuring ? AvgDuring : 0)#</b></td>
                    </tr>
                </script>
            </div>
        </div>
        <div data-id="2" class="col connect">
            <div id="sort_sp_DSHB_10_09" class="cell">
                @*Souhrn připomínek, urgencí a zpráv*@
                <h2 style="text-align:center;opacity:0.8;">@Html.Raw(Language.DashboardTXT101)</h2>
                <div id="sp_DSHB_10_09_CHART" style="height:200px"></div>
            </div>
            <div id="sort_sp_DSHB_10_03" class="cell">
                <h2 style="text-align:center;opacity:0.8;">@Html.Raw(Language.DashboardTXT8)</h2>
                <div id="sp_DSHB_10_03" data-bind="source: sp_DSHB_10_03" style="overflow-x:auto;"></div>
                <script>
                    $(function () {
                        $("#sp_DSHB_10_03").kendoGrid({
                            sortable: true,
                            filterable: true,
                            columnMenu: true,
                            columns: [
                                { 'template': '# if (Type === "R") { # <a href="\\#" data-bind="events: { click: DeleteRecord }"><span class="k-icon k-i-close"></span></a> # } #', 'headerTemplate': ' ', 'title': '@Html.Raw(Language.DashboardTBL22)', 'width': 30 },
                    { 'field': 'DeadLine', 'headerTemplate': headerTemplate('@Html.Raw(Language.DashboardTBL10)'), 'template': '#=CellDate(DeadLine)#', 'width': 60 },
                    { 'field': 'Type', 'headerTemplate': headerTemplate('@Html.Raw(Language.DashboardTBL11)'), 'template': '#=CellString(Type)#', 'width': 30 },
                    { 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.DashboardTBL12)'), 'template': '<a href=\'\' data-bind=\'attr: { href: ACCLink }\'>#=CellRaw(ACC)#</a>', 'width': 70 },
                    { 'field': 'Title', 'headerTemplate': headerTemplate('@Html.Raw(Language.DashboardTBL13)'), 'template': '#=CellString(Title)#', 'width': 200 },
                    { 'field': 'Body', 'headerTemplate': headerTemplate('@Html.Raw(Language.DashboardTBL14)'), 'template': '#=CellString(Body)#' },
                    { 'field': 'CreatedDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.DashboardTBL15)'), 'template': '#=CellDateTime(CreatedDate)#', 'width': 100 },
                    { 'field': 'Zadavatel', 'headerTemplate': headerTemplate('@Html.Raw(Language.DashboardTBL16)'), 'template': '#=CellString(Zadavatel)#', 'width': 100 }
                            ]
                        });
                    });
                </script>
            </div>
        </div>
    </div>
    <div class="main">
        <div data-id="3" class="col connect">
            <div id="sort_sp_DSHB_10_10" class="cell">
                <h2 style="text-align: center; opacity: 0.8;">@Html.Raw(Language.DashboardTXT11)</h2>
                <table data-role="grid" data-scrollable="false">
                    <colgroup>
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                    </colgroup>
                    <thead>
                        <tr>
                            <th data-field="Obdobi" style="background:#ff0">@Html.Raw(Language.DSHBtxt19)<br />@Html.Raw(Language.DSHBtxt21)</th>
                            <th data-field="PocetSpisu" style="background:#fcd5b4">@Html.Raw(Language.DSHBtxt22)<br />@Html.Raw(Language.DSHBtxt23)</th>
                            <th data-field="SumDluh" style="background:#fcd5b4;">@Html.Raw(Language.DSHBtxt22)<br />@Html.Raw(Language.DSHBtxt24)</th>
                            <th data-field="SumMesic1" style="background:#daeef3">1. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="SumMesic2" style="background:#daeef3">2. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="SumMesic3" style="background:#daeef3">3. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="SumMesic4" style="background:#daeef3">4. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="SumMesic5" style="background:#daeef3">5. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="SumMesic6" style="background:#daeef3">6. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="Efekt1" style="background:#daeef3">@Html.Raw(Language.DSHBtxt25)<br />1. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="Efekt2" style="background:#daeef3">@Html.Raw(Language.DSHBtxt25)<br />2. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="Efekt3" style="background:#daeef3">@Html.Raw(Language.DSHBtxt25)<br />3. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="Efekt4" style="background:#daeef3">@Html.Raw(Language.DSHBtxt25)<br />4. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="Efekt5" style="background:#daeef3">@Html.Raw(Language.DSHBtxt25)<br />5. @Html.Raw(Language.DSHBtxt20)</th>
                            <th data-field="Efekt6" style="background:#daeef3">@Html.Raw(Language.DSHBtxt25)<br />6. @Html.Raw(Language.DSHBtxt20)</th>
                        </tr>
                    </thead>
                    <tbody data-bind="source: sp_DSHB_10_10" data-template="sp_DSHB_10_10_tmp">

                    </tbody>
                </table>

                <script id="sp_DSHB_10_10_tmp" type="text/html">
                    <tr>
                        <td>#=CellString(Obdobi)#</td>
                        <td>#=CellInt(PocetSpisu)#</td>
                        <td>#=CellMoney(SumDluh)#</td>
                        <td>#=CellMoney(SumMesic1)#</td>
                        <td>#=CellMoney(SumMesic2)#</td>
                        <td>#=CellMoney(SumMesic3)#</td>
                        <td>#=CellMoney(SumMesic4)#</td>
                        <td>#=CellMoney(SumMesic5)#</td>
                        <td>#=CellMoney(SumMesic6)#</td>
                        <td style="text-align:center">#=kendo.toString(Efekt1, "p1")#</td>
                        <td style="text-align:center">#=kendo.toString(Efekt2, "p1")#</td>
                        <td style="text-align:center">#=kendo.toString(Efekt3, "p1")#</td>
                        <td style="text-align:center">#=kendo.toString(Efekt4, "p1")#</td>
                        <td style="text-align:center">#=kendo.toString(Efekt5, "p1")#</td>
                        <td style="text-align:center">#=kendo.toString(Efekt6, "p1")#</td>
                    </tr>
                </script>
            </div>
        </div>
    </div>
</div>

<script>
    var viewModel = null;
    $(function () {
        viewModel = new kendo.observable({
            celkemSpisu: "@Html.Raw(Language.DSHBtxt26)",
           @* sp_DSHB_10_01: new kendo.data.DataSource({
                sort: ({ field: "IDOrder", dir: "asc" }),
                transport: {
                    read: "@Url.Action("sp_DSHB_10_01", "Api/Service")"
                }
            }),
            sp_DSHB_10_02Tyden: new kendo.data.DataSource({
                data: []
            }),
            sp_DSHB_10_02Dnes: new kendo.data.DataSource({
                data: []
            }),*@
            sp_DSHB_10_03: new kendo.data.DataSource({
                schema: {
                    model: {
                        id: "Radek",
                        fields: {
                            'DeadLine': { type: 'date' },
                            'Type': { type: 'string' },
                            'ACC': { type: 'string' },
                            'Title': { type: 'string' },
                            'Body': { type: 'string' },
                            'CreatedDate': { type: 'date' },
                            'Zadavatel': { type: 'string' }
                        }
                    }
                },
                transport: {
                    read: "@Url.Action("sp_DSHB_10_03", "Api/Service")"
                }
            }),
            sp_DSHB_10_04: new kendo.data.DataSource({
                sort: ({ field: "IDOrder", dir: "asc" }),
                transport: {
                    read: "@Url.Action("sp_DSHB_10_04", "Api/Service")"
                }
            }),
            sp_DSHB_10_05: [],
            sp_DSHB_10_07: new kendo.data.DataSource({
                sort: ({ field: "Poradi", dir: "asc" }),
                transport: {
                    read: "@Url.Action("sp_DSHB_10_07", "Api/Service")"
                }
            }),
            sp_DSHB_10_08: [],
            sp_DSHB_10_09: new kendo.data.DataSource({
                sort: ({ field: "Poradi", dir: "asc" }),
                transport: {
                    read: "@Url.Action("sp_DSHB_10_09", "Api/Service")"
                }
            }),
            sp_DSHB_10_10: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_10_10", "Api/Service")"
                }
            }),
            DeleteRecord: function (e) {
                var that = this;
                $.get('@Url.Action("sp_Do_DoneOneReminder", "Api/Service")', { iDSpisu: e.data.IDCase, iDReminder: e.data.ID }, function (result) {
                    that.sp_DSHB_10_03.read();
                });
            },
            ACCLink: function (e) {
                var id = e.IDCase;
                var state = e.rr_State;
                if (state > 9 && state < 20) {
                    return "Home/News?id=" + id;
                } else if (state > 29 && state < 40) {
                    return "Home/PersonalVisit?id=" + id;
                } else if (state > 39 && state < 50) {
                    return "Home/Agreements?id=" + id;
                } else if (state > 49 && state < 60) {
                    return "Home/ToProcess?id=" + id;
                } else {
                    return ""
                };
            }
        })
        kendo.bind($("#body"), viewModel)

        //inicializace grafu
        var colors = ["#fd625e",
                      "#f2c80f",
                      "#90cc38",
                      "#03a9f4",
                      "#5f6b6d",
                      "#374649"]

        $.get("@Url.Action("sp_DSHB_10_08", "Api/Service")", {}, function (result) {
                        result[0].Item = "od předání do vykonání první OSN"
                        result[1].Item = "od první návštěvy do vykonání druhé OSN"
                        viewModel.set("sp_DSHB_10_08", result)
        })

        $.get("@Url.Action("sp_DSHB_10_05", "Api/Service")", {}, function (result) {
            viewModel.set("sp_DSHB_10_05", result);
        })

        $.get("@Url.Action("sp_DSHB_10_01", "Api/Service")", {}, function (result) {
            viewModel.set("celkemSpisu", "(@Html.Raw(Language.DSHBtxt17) " + result[4]["Suma"] + " @Html.Raw(Language.DSHBtxt18))")
            $("#sp_DSHB_10_01_CHART").kendoChart({
                seriesColors: colors,
                seriesDefaults: {
                    labels: { visible: false },
                },
                legend: {
                    position: "bottom",
                    visible: true
                },
                series: [{
                    type: "donut",
                    overlay: { gradient: "none" },
                    data: [
                        {
                            category: "@Html.Raw(Language.DSHBtxt6)",
                            value: result[0]["Suma"]
                        },
                        {
                            category: "@Html.Raw(Language.DSHBtxt7)",
                            value: result[1]["Suma"]
                        },
                        {
                            category: "@Html.Raw(Language.DSHBtxt8)",
                            value: result[2]["Suma"]
                        },
                        {
                            category: "@Html.Raw(Language.DSHBtxt9)",
                            value: result[3]["Suma"]
                        },
                        {
                            category: "@Html.Raw(Language.DSHBtxt10)",
                            value: result[5]["Suma"]
                        }]
                }
                ],
                tooltip: {
                    visible: true,
                    template: "#=category# #=value#"
                }
            });
        });

        $.get("@Url.Action("sp_DSHB_10_02", "Api/Service")", {}, function (result) {
            $("#sp_DSHB_10_02_CHART").kendoChart({
                seriesDefaults: {
                    type: "bar",
                    labels: { visible: true }
                },
                legend: {
                    position: "bottom",
                    visible: true
                },
                series: result,
                tooltip: {
                    visible: true,
                    template: "#=series.name# #=value#"
                }
            });
        });

        $.get("@Url.Action("sp_DSHB_10_09", "Api/Service")", {}, function (result) {
            $("#sp_DSHB_10_09_CHART").kendoChart({
                seriesColors: colors,
                legend: {
                    position: "bottom",
                    visible: true
                },
                seriesDefaults: {
                    type: "bar",
                    stack: true,
                    labels: { visible: false }
                },
                series: result,
                categoryAxis: {
                    categories: ["@Html.Raw(Language.DSHBtxt11)", "@Html.Raw(Language.DSHBtxt12)", "@Html.Raw(Language.DSHBtxt13)", "@Html.Raw(Language.DSHBtxt14)", "@Html.Raw(Language.DSHBtxt15)", "@Html.Raw(Language.DSHBtxt16)"],
                    majorGridLines: {
                        visible: false
                    }
                },
                tooltip: {
                    visible: true,
                    template: "#= series.name #: #= value #"
                }
            });
        });

        //pretahovani tabulek
        $("#body").kendoSortable({
            filter: ".cell",
            ignore: "td",
            cursor: "move",
            connectWith: ".connect",
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
    })
</script>