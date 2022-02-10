<div id="OSNDatePlan" data-role="window"
    data-title="@Language.OSNDatePlanWinTitle"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <table style="width:100%">
        <tr>
            <td>
                <input data-role="datepicker"
                    data-bind="value: Date, dmax: DMAX, mindate: Min, events: { change: dateChange }"
                    style="width: 100%" />
            </td>
            <td>
                <input type="checkbox" name="nochange" id="nochange" class="k-checkbox" data-type="boolean" data-bind="checked: NoChange">
                <label class="k-checkbox-label" for="nochange">@Html.Raw(Language.OSNDatePlanDialogTXT1)</label>
            </td>
            <td>
                <input type="text" name="nazev" class="k-textbox" style="width: 100%" data-bind="value: NazevKampane" placeholder="@Html.Raw(Language.OSNDatePlanDialogPLH2)">
            </td>
        </tr>
    </table>
    <h3 style="text-align:center">@Language.OSNDatePlanWinTitleSub</h3>
    <div data-role="grid" 
        data-bind="source: Source, events: { change: Change }"
        data-selectable="true"
        data-columns="[
        {'field': 'DeadLine', 'template': '#=CellDate(DeadLine)#', 'title': '@Language.OSNDatePlanWinCampaignDate', 'width': 120 },
        {'field': 'CampName', 'template': '#=CellString(CampName)#', 'title': '@Language.OSNDatePlanWinCampaignName'}
        ]" style="height:210px"></div>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Save }">@Language.btnOk</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>
<!-- dmaxSelect(data.date, data.value) -->
<script>
    function showOSNDatePlan(d, dmx, nochange, callback) {
        var win;
        if (nochange === null) nochange = false;
        if (!d) { d = new Date(); }
        var OSNDatePlan = new kendo.observable({
            Min: new Date(),
            Date: d,
            DMAX: dmx,
            NazevKampane: null,
            Source: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDCampaign"
                    }
                },
                transport: {
                    read: "@Url.Action("vw_Campaign", "Api/Service")",
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if (pm.$filter) {
                            pm.$filter = pm.$filter.replace("eq ''", "eq null");
                        }
                        return pm;
                    }
                },
                pageSize: 1000,
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true
            }),
            dateChange: function (e) {
                if (this.get("DMAX")) {
                    var max = this.get("DMAX");
                    var val = e.sender.value();
                    var diff = new Date(max - val);
                    var days = diff / 1000 / 60 / 60 / 24;
                    if (parseInt(days) < 0) {
                        message(" Zvolené datum přesahuje DMAX")
                    }
                }
            },
            Change: function (e) {
                var row = e.sender.select();
                var di = e.sender.dataItem(row);
                this.set("Date", new Date(di.DeadLine));
                this.set("NazevKampane", di.CampName);
            },
            NoChange: nochange,
            Save: function (e) {
                if (!this.Date) {
                    message("   @SystemMessages.NoDate ", "info")
                    return
                }
                win.close();
                callback(this.Date, this.NoChange, this.NazevKampane)
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#OSNDatePlan"), OSNDatePlan);
        win = $("#OSNDatePlan").data("kendoWindow");
        win.open().center();
        $("#OSNDatePlan [data-role='datepicker']").attr("readonly", true);
    };
</script>