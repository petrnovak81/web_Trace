<div id="NextFiles" data-role="window"
    data-title="@Html.Raw(Language.Key_DalsiSpisyDluznika)"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <h3>@Html.Raw(Language.NextFilesDialogTXT1)</h3>
    <div data-role="grid" 
        data-resizable="true"
        data-bind="source: Source, events: { dataBound: DataBound }"
        data-columns="[
        {'template': '<input type=\'checkbox\' data-bind=\'events: { change: Select }\' id=\'ch-\#=uid\#\' class=\'k-checkbox checkrow\'><label class=\'k-checkbox-label\' for=\'ch-\#=uid\#\'></label>', 'width': 30 },
        {'field': 'VisitDatePlan', 'template': '#=CellString(VisitDatePlan)#', 'title': '@Language.Get_ListOfOtherCaseVisitDatePlan', 'width': 100},
        {'field': 'ACC', 'template': '#=CellString(ACC)#', 'title': '@Language.Get_ListOfOtherCaseACC', 'width': 100},
        {'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'title': '@Language.Get_ListOfOtherCaseActualDebit', 'width': 100},
        {'field': 'StateTxt', 'template': '#=CellString(StateTxt)#', 'title': '@Language.Get_ListOfOtherCaseStateTxt'}
        ]" style="height:210px"></div>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Save }">@Language.btnOk</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>
<script>
    function showNextFiles(id, data, callback) {
        var iDs = {};
        iDs[id] = true;
        var win;
        var model = new kendo.observable({
            Source: new kendo.data.DataSource({
                schema: {
                    model: {
                        id: "OtherIDSpisu",
                        fields: {
                            "VisitDatePlan": { type: "date" },
                            "ACC": { type: "string" },
                            "ActualDebit": { type: "double" },
                            "StateTxt": { type: "string" }
                        }
                    }
                },
                data: data
            }),
            Select: function (e) {
                var checked = $(e.currentTarget).prop("checked")
                iDs[e.data.OtherIDSpisu] = checked;
            },
            DataBound: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var allRows = e.sender.tbody.find("tr");
                allRows.each(function () {
                    var di = grid.dataItem($(this));
                    if (di.rr_State > 9 && di.rr_State < 20) {
                        $(this).addClass("red-row");
                    } else if (di.rr_State > 29 && di.rr_State < 40) {
                        $(this).addClass("orange-row");
                    } else if (di.rr_State > 39 && di.rr_State < 50) {
                        $(this).addClass("green-row");
                    } else if (di.rr_State > 49 && di.rr_State < 60) {
                        $(this).addClass("blue-row");
                    }
                });
            },
            Save: function (e) {
                win.close();
                callback(iDs);
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#NextFiles"), model);
        win = $("#NextFiles").data("kendoWindow");
        win.open().center();
    };
</script>