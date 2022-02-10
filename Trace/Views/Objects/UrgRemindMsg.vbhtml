<div id="UrgRemindMsg" 
    data-role="window"
    data-title="@Html.Raw(Language.UrgRemindMsg_title)"
    data-modal="true"
    data-width="800"
    data-height="600"
    data-resizable="true"
    data-actions="['close']"
    style="display: none;">
    <div data-role="grid" 
        data-resizable="true"
        data-scrollable="true"
        data-bind="source: Source"
        data-columns="[
                    { 'template': '# if (Type === \'R\') { # <a href=\'\\#\' data-bind=\'events: { click: DeleteRecord }\'><span class=\'k-icon k-i-close\'></span></a> # } #', 'width': 30 },
                    { 'field': 'DeadLine', 'headerTemplate': headerTemplate('Dead line'), 'title': 'Dead line', 'template': '#=CellDate(DeadLine)#', 'width': 60 },
                    { 'field': 'Title', 'headerTemplate': headerTemplate('@Html.Raw(Language.UrgRemindMsgTBL10)'), 'title': '@Html.Raw(Language.UrgRemindMsgTBL10)', 'template': '#=CellString(Title)#', 'width': 200 },
                    { 'field': 'Body', 'headerTemplate': headerTemplate('@Html.Raw(Language.UrgRemindMsgTBL11)'), 'title': '@Html.Raw(Language.UrgRemindMsgTBL11)', 'template': '#=CellString(Body)#', 'width': 300 },
                    { 'field': 'Jmeno', 'headerTemplate': headerTemplate('@Html.Raw(Language.UrgRemindMsgTBL12)'), 'title': '@Html.Raw(Language.UrgRemindMsgTBL12)', 'template': '#=CellString(Jmeno)#', 'width': 150 },
                    { 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.UrgRemindMsgTBL13)'), 'title': '@Html.Raw(Language.UrgRemindMsgTBL13)', 'template': '<a href=\'\' data-bind=\'attr: { href: ACCLink }\'>#=CellRaw(ACC)#</a>', 'width': 70 },
                    { 'field': 'CreatedDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.UrgRemindMsgTBL14)'), 'title': '@Html.Raw(Language.UrgRemindMsgTBL14)', 'template': '#=CellDateTime(CreatedDate)#', 'width': 100 },
                    { 'field': 'Zadavatel', 'headerTemplate': headerTemplate('@Html.Raw(Language.UrgRemindMsgTBL15)'), 'title': '@Html.Raw(Language.UrgRemindMsgTBL15)', 'template': '#=CellString(Zadavatel)#', 'width': 100 },
                    { 'field': 'Type', 'headerTemplate': headerTemplate('@Html.Raw(Language.UrgRemindMsgTBL16)'), 'title': '@Html.Raw(Language.UrgRemindMsgTBL16)', 'template': '#=CellString(Type)#', 'width': 30 }
        ]" style="height:calc(100% - 60px)"></div>
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="events: { click: Ok }">@Language.btnOk</button>
    </div>
</div>

<script>
    function UrgRemindMsg(zal) {
        var win;
        var model = new kendo.observable({
            Source: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "ID",
                        fields: {
                            "DeadLine": { type: "date" },
                            "Title": { type: "string" },
                            "Body": { type: "string" },
                            "Jmeno": { type: "string" },
                            "ACC": { type: "string" },
                            "CreatedDate": { type: "date" },
                            "Zadavatel": { type: "string" }
                        }
                    }
                },
                filter: { field: "Zalozka", operator: "eq", value: zal },
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true,
                pageSize: 100,
                sort: {
                    field: "DeadLine",
                    dir: "desc"
                },
                transport: {
                    read: {
                        url: "@Url.Action("vw_AllUrgRemindMsg", "Api/Service")",
                        dataType: "json"
                    },
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if (pm.$filter) {
                            pm.$filter = pm.$filter.replace("eq ''", "eq null");
                        }
                        pm.type = 2;
                        pm.date = 0;
                        return pm;
                    }
                }
            }),
            DeleteRecord: function (e) {
                var model = this;
                $.get('@Url.Action("sp_Do_DoneOneReminder", "Api/Service")', { iDSpisu: e.data.IDCase, iDReminder: e.data.ID }, function (result) {
                    model.Source.read();
                });
            },
            ACCLink: function (e) {
                var id = e.IDCase;
                var state = e.rr_State;
                if (state > 9 && state < 20) {
                    return "News?id=" + id;
                } else if (state > 29 && state < 40) {
                    return "PersonalVisit?id=" + id;
                } else if (state > 39 && state < 50) {
                    return "Agreements?id=" + id;
                } else if (state > 49 && state < 60) {
                    return "ToProcess?id=" + id;
                } else {
                    return ""
                };
            },
            Ok: function (e) {
                win.close();
            }
        });
        kendo.bind($("#UrgRemindMsg"), model);
        win = $("#UrgRemindMsg").data("kendoWindow");
        win.open().center();
    };
</script>