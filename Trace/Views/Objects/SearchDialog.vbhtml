<div id="SearchDialog" 
    data-role="window"
    data-title="@Html.Raw(Language.searchDialogTitle)"
    data-width="640"
    data-height="480"
    data-modal="true"
    data-resizable="true"
    data-actions="['maximize', 'close']"
    data-bind="events: { open: winOpen }"
    style="display: none;">
    <ul data-role="menu">
        <li>
            <span title="@Html.Raw(Language.searchInfo)" class="k-textbox k-space-right" style="width:300px">
                <input autofocus id="searchInput" type="text" style="width:300px" data-value-update="keyup" data-bind="value: SearchTxt, events: { keypress: SearchAct }" placeholder="@Html.Raw(Language.searchPlaceholder)" />
                <a href="#" data-bind="click: SearchAct">
                    <span class="k-icon fa fa-search"></span>
                </a>
            </span>
        </li>
    </ul>
    <div data-role="grid"
                data-resizable="true"
                data-auto-bind="false"
                data-columns="[
        { 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_ACC)'), 'template': '#=acclinktmp(rr_State, IDSpisu, ACC)#', 'width': 130 },
        { 'field': 'PersSurname', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonSurname)'), 'template': '#=CellString(PersSurname)#', 'width': 130 },
        { 'field': 'PersName', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonName)'), 'template': '#=CellString(PersName)#', 'width': 130 },
        { 'field': 'PersRC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonRC)'), 'template': '#=CellRC(PersRC)#', 'width': 100 },
        { 'field': 'PersIC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonIC)'), 'template': '#=CellString(PersIC)#', 'width': 100 },
        { 'field': 'PersBirthDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonBirthDate)'), 'template': '#=CellDate(PersBirthDate)#', 'width': 100 },
        { 'field': 'VariableSymbol', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_VariableSymbol)'), 'template': '#=CellString(VariableSymbol)#', 'width': 100 },
        { 'field': 'DateOSN', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DateOSNPlan)'), 'template': '#=CellDate(DateOSN)#', 'width': 100 },
        { 'field': 'StateTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_StateTxt)'), 'template': '#=CellString(StateTxt)#', 'width': 100 },
            ]"
                data-bind="source: SearchResult" style="height:calc(100% - 130px)">
            </div>
    <div class="window-footer">
        <small style="float:left;text-align:left;">@Html.Raw(Language.searchPozn)</small>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script id="acctmplink" type="text/html">
    # if() { #
</script>

<script>
    var curcont = "@Html.CurController";
    function acclinktmp(rr_State, IDSpisu, ACC) {
        if (curcont == "Home") {
            if (rr_State > 9 && rr_State < 20) {
                return '<a href="@(Url.Action("News", "Home"))?id=' + IDSpisu + '">' + ACC + '</a>';
            } else if (rr_State > 29 && rr_State < 40) {
                return '<a href="@(Url.Action("PersonalVisit", "Home"))?id=' + IDSpisu + '">' + ACC + '</a>';
            } else if (rr_State > 39 && rr_State < 50) {
                return '<a href="@(Url.Action("Agreements", "Home"))?id=' + IDSpisu + '">' + ACC + '</a>';
            } else if (rr_State > 49 && rr_State < 60) {
                return '<a href="@(Url.Action("ToProcess", "Home"))?id=' + IDSpisu + '">' + ACC + '</a>';
            } else {
                return '<a href="@(Url.Action("Finished", "Home"))?id=' + IDSpisu + '">' + ACC + '</a>';
            };
        } else {
            return '<a href="@(Url.Action("FileAdministration", "Administrator"))?id=' + ACC + '">' + ACC + '</a>';
        }
    }

    function SearchDialog() {
        var win;
        @Code
            If Html.CurController = "Home" Then
                @<text>var url = "@Url.Action("sp_Get_GlobalFind", "Api/Service")";</text>
            Else
                @<text>var url = "@Url.Action("sp_Get_GlobalFind", "Api/AdminService")";</text>
            End If
        End Code
        var model = new kendo.observable({
            SearchResult: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDSpisu",
                        fields: {
                            'ACC': { type: 'string' },
                            'PersSurname': { type: 'string' },
                            'PersName': { type: 'string' },
                            'PersRC': { type: 'string' },
                            'PersIC': { type: 'string' },
                            'PersBirthDate': { type: 'date' },
                            'VariableSymbol': { type: 'string' },
                            'DateOSN': { type: 'date' },
                            "StateTxt": { type: "string" }
                        }
                    }
                },
                transport: {
                    read: {
                        url: url,
                        dataType: "json",
                    },
                    parameterMap: function (options, type) {
                        return { find: model.SearchTxt };
                    }
                },
                requestEnd: function (e) {
                    if (e.response) {
                        if (e.response.MsgType === 'error') {
                            var msg = "<span style='margin-left:6px;'>" + e.response.Msg.join("<br>") + "</span>"
                            message(msg, e.response.MsgType);
                        }
                    }
                }
            }),
            SearchTxt: null,
            SearchAct: function (e) {
                if (e.type === "keypress" && e.key === "Enter") {
                    this.set("SearchTxt", $("#searchInput").val());
                    this.SearchResult.read();
                }
                if (e.type === "click") {
                    this.set("SearchTxt", $("#searchInput").val());
                    this.SearchResult.read();
                }
            },
            ACCLink: function (e) {
                var id = e.data.IDSpisu;
                var href = null;
                @Code
                    If Html.CurController = "Home" Then
                        @<text>
                var state = e.data.rr_State;
                if (state > 9 && state < 20) {
                    href = "@(Url.Action("News", "Home"))?id=" + id;
                } else if (state > 29 && state < 40) {
                    href = "@(Url.Action("PersonalVisit", "Home"))?id=" + id;
                } else if (state > 39 && state < 50) {
                    href = "@(Url.Action("Agreements", "Home"))?id=" + id;
                } else if (state > 49 && state < 60) {
                    href = "@(Url.Action("ToProcess", "Home"))?id=" + id;
                } else {
                    href = "@(Url.Action("Finished", "Home"))?id=" + id;
                };
                window.location.href = href;
                        </text>
                    ElseIf Html.CurController = "Administrator" Then
                @<text>
                window.location.href = "@(Url.Action("FileAdministration", "Administrator"))?id=" + e.data.ACC;
                </text>
                    End If
                End Code
            },
            winOpen: function (e) {
                setTimeout(function () {
                    $("#searchInput").focus();
                }, 1000)
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#SearchDialog"), model);
        win = $("#SearchDialog").data("kendoWindow");
        win.open().center();
    };
</script>
