<div id="DohodyMoveToOSN" data-role="window"
    data-title="@Language.DohodyMoveToOSNTitle"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <h3 style="text-align:center;color:red">@Language.DohodyMoveToOSNAlert</h3>
    <textarea placeholder="@Language.DohodyMoveToOSNComment" class="k-textbox" autofocus style="width:100%;" rows="9" data-bind="value: Comment"></textarea>
    <h4 style="text-align:center">@Language.OSNDatePlanWinTitle</h4>
    <table style="width: 100%">
        <tr>
            <td>
                <input data-role="datepicker"
                    data-bind="value: Date, dmax: DMAX, mindate: Min, events: { change: dateChange }"
                    style="width: 100%" />
            </td>
            <td>
                <input type="checkbox" name="nochange1" id="nochange1" class="k-checkbox" data-type="boolean" data-bind="checked: NoChange">
                <label class="k-checkbox-label" for="nochange1">@Html.Raw(Language.DohodyMoveToOSNDialogTXT1)</label>
            </td>
            <td>
                <input type="text" name="nazev" class="k-textbox" style="width: 100%" data-bind="value: NazevKampane" placeholder="@Html.Raw(Language.DohodyMoveToOSNDialogPLH2)">
            </td>
        </tr>
    </table>
    <h4 style="text-align:center">@Language.OSNDatePlanWinTitleSub</h4>
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
<style>
    #DohodyMoveToOSN textarea {
        resize: none;
    }
</style>
<script>
    function showDohodyMoveToOSN(d, dmx, callback) {
        var win;
        if (nochange === null) nochange = false;
        if (!d) { d = new Date(); }
        var model = new kendo.observable({
            Min: new Date(),
            Comment: "",
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
            NoChange: false,
            Save: function (e) {
                if (!$.trim(this.Comment)) {
                    message("   @SystemMessages.NoComment2 ", "info")
                    return;
                }
                if (!$.trim(this.Date)) {
                    message("   @SystemMessages.NoDate ", "info")
                    return;
                }
                win.close();
                callback(this.Date, this.Comment, this.NoChange, this.NazevKampane)
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#DohodyMoveToOSN"), model);
        win = $("#DohodyMoveToOSN").data("kendoWindow");
        win.open().center();
        $("#DohodyMoveToOSN [data-role='datepicker']").attr("readonly", true);
    };
</script>
