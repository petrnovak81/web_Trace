<div id="SVZmenaDMAX" 
    data-role="window"
    data-title="@Html.Raw(Language.ZmenaDMAX_Title1)"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <h3>@Html.Raw(Language.ZmenaDMAX_Title2)</h3>
    <div data-role="grid" 
        data-resizable="true"
        data-bind="source: Source"
        data-columns="[
        {'template': '<input type=\'checkbox\' checked data-bind=\'events: { change: Select }\' id=\'ch-\#=IDSpisu\#\' class=\'k-checkbox checkrow\'><label class=\'k-checkbox-label\' for=\'ch-\#=IDSpisu\#\'></label>', 'width': 30 },
        {'field': 'DateOSNPlan', 'template': '#=CellDate(DateOSNPlan)#', 'title': '@Language.Get_ListOfOtherCaseVisitDatePlan', 'width': 100},
        {'field': 'DateOSNMax', 'template': '#=CellDate(DateOSNMax)#', 'title': '@Language.Get_ListOfOtherCaseDateOSNMax', 'width': 100},
        {'field': 'ACC', 'template': '#=CellString(ACC)#', 'title': '@Language.Get_ListOfOtherCaseACC', 'width': 100},
        {'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'title': '@Language.Get_ListOfOtherCaseActualDebit', 'width': 100},
        {'field': 'CurrencyTxt', 'template': '#=CellString(CurrencyTxt)#', 'title': '@Language.Get_ListOfOtherCaseActualCur', 'width': 30},
        {'field': 'StateTxt', 'template': '#=CellString(StateTxt)#', 'title': '@Language.Get_ListOfOtherCaseStateTxt'}
        ]" style="height:210px"></div>
    <h4>@Html.Raw(Language.SVZmenaDMAXTXT1)</h4>
    <input style="width: 100%;" data-role="datepicker" data-bind="value: DMAX, mindate: today" placeholder="@Html.Raw(Language.SVZmenaDMAXTXT1)" />
    <textarea class="k-textbox" maxlength="300" autofocus style="width:100%;max-width:100%;" rows="3" data-bind="value: Comment" placeholder="@Html.Raw(Language.SVZmenaDMAXPLH3)"></textarea>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Save }">@Language.btnDMAX</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function SVZmenaDMAX(items, callback) {
        var iDs = {};
        var win;
        $.each(items, function (a, b) {
            iDs[b.IDSpisu] = true;
        });
        var model = new kendo.observable({
            Source: items,
            today: new Date(),
            DMAX: new Date(),
            Comment: "",
            Select: function (e) {
                var checked = $(e.currentTarget).prop("checked")
                iDs[e.data.IDSpisu] = checked;
            },
            Save: function (e) {
                if (!$.trim(this.Comment)) {
                    message("   @SystemMessages.NoComment6 ", "info")
                    return;
                };

                var res = [];
                $.each(iDs, function (a, b) {
                    if (b) {
                        res.push(parseInt(a));
                    }
                })

                if (res.length === 0) {
                    message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                    return;
                }

                var that = this;
                progressModel.set("progressLogVisible", false);
                var promises = res.map(function (id, i) {
                    return $.Deferred(function (d) {
                        $.get("@Url.Action("sp_Do_Super2_3_5", "Api/AdminService")", {
                            iDSpisu: id,
                            dNMAX: kendo.toString(that.DMAX, "yyyy-MM-dd HH:mm:ss"),
                            comment: that.Comment
                        }, function (result) {
                            if (result.MsgType === "error") {
                                progressModel.set("progressLogVisible", true);
                                progressModel.progressLog.insert(0, { state: result.MsgType, text: result.Msg[0] });
                            }
                        }).always(function () {
                            d.notify(i);
                            d.resolve.apply(this, arguments);
                        })
                    }).promise();
                })

                callback(promises);
                win.close();
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#SVZmenaDMAX"), model);
        win = $("#SVZmenaDMAX").data("kendoWindow");
        win.open().center();
    };
</script>
