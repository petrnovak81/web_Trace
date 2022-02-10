<div id="sp_Get_SpisyOfIDSpisyOsoby" 
    data-role="window"
    data-title="@Html.Raw(Language.A1_SeznamSpisOSN)"
    data-width="640"
    data-height="430"
    data-modal="true"
    data-resizable="true"
    data-actions="['maximize', 'close']"
    style="display: none;">
    <div data-role="grid"
                data-resizable="true"
                data-auto-bind="true"
                data-columns="[
        { 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_ACC)'), 'template': '<a href=\'\' data-bind=\'attr: { href: ACCLink }\'>#=CellRaw(ACC)#</a>', 'width': 130 },
        { 'field': 'PersSurname', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonSurname)'), 'template': '#=CellString(PersSurname)#', 'width': 130 },
        { 'field': 'PersName', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonName)'), 'template': '#=CellString(PersName)#', 'width': 130 },
        { 'field': 'PersRC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonRC)'), 'template': '#=CellRC(PersRC)#', 'width': 100 },
        { 'field': 'PersIC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonIC)'), 'template': '#=CellString(PersIC)#', 'width': 100 },
        { 'field': 'PersBirthDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonBirthDate)'), 'template': '#=CellDate(PersBirthDate)#', 'width': 100 },
        { 'field': 'VariableSymbol', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_VariableSymbol)'), 'template': '#=CellString(VariableSymbol)#', 'width': 100 },
        { 'field': 'DateOSN', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DateOSNPlan)'), 'template': '#=CellDate(DateOSN)#', 'width': 100 },
        { 'field': 'StateTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_StateTxt)'), 'template': '#=CellString(StateTxt)#', 'width': 100 },
            ]"
                data-bind="source: Source" style="height:calc(100% - 130px)">
            </div>
    <div class="window-footer">
        <small style="float:left;text-align:left;">@Html.Raw(Language.searchPozn)</small>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function SpisyOfIDSpisyOsoby(IDSpisyOsoby) {
        var win;
        var model = new kendo.observable({
            Source: new kendo.data.DataSource({
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
                            'DateOSN': { type: 'date' }
                        }
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_SpisyOfIDSpisyOsoby", "Api/Service")",
                        dataType: "json",
                    },
                    parameterMap: function (options, type) {
                        return { iDSpisyOsoby: IDSpisyOsoby };
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
            ACCLink: function (e) {
                var id = e.IDSpisu;
                var href = null;
                @Code
                    If Html.CurController = "Home" Then
                        @<text>
                var state = e.rr_State;
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
                        </text>
                    ElseIf Html.CurController = "Administrator" Then
                        @<text>href = "@(Url.Action("FileAdministration", "Administrator"))?id=" + id;</text>
                    End If
                End Code
                return href;
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#sp_Get_SpisyOfIDSpisyOsoby"), model);
        win = $("#sp_Get_SpisyOfIDSpisyOsoby").data("kendoWindow");
        win.open().center();
    };
</script>
