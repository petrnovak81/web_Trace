<div id="SVCashRevisionParovat"
     data-role="window"
     data-title="Párovat"
     data-modal="true"
     data-resizable="false"
     data-actions="['close']"
     style="display: none;width: 600px">
    <div data-role="grid"
         data-resizable="true"
         data-scrollable="true"
         data-selectable="true"
         data-bind="source: sp_Get_SV_NonPairedPayments"
         data-columns="[
         {'template': '<a href=\'\\#\' data-bind=\'events: { click: Parovat }\'>Párovat</a>', 'title': ' ', 'width': 60},
         {'field': 'ACC', 'template': '#=CellString(ACC)#', 'title': 'Číslo spisu', 'width': 100},
         {'field': 'PaymentDate', 'template': '#=CellDate(PaymentDate)#', 'title': 'Došlo na centrálu', 'width': 80},
         {'field': 'Amount', 'template': '#=CellMoney(Amount)#', 'title': 'Došlo na centrálu'}
        ]" style="height:200px"></div>
    <div class="window-footer">
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function SVCashRevisionParovat(iDSpisu, iDCashPayment, callback) {
        var win;
        var model = new kendo.observable({
            sp_Get_SV_NonPairedPayments: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDSpisu"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_SV_NonPairedPayments", "Api/AdminService")" + "?iDSpisu=" + iDSpisu,
                        dataType: "json",
                    }
                }
            }),
            Parovat: function (e) {
                $.get("@Url.Action("sp_Do_SV_ChangeCash", "Api/AdminService")", { iDCashPayment: iDCashPayment, iDSpisyPlatbyDosle: e.data.IDSpisyPlatbyDosle }, function (result) {
                    win.close();
                    callback(true);
                })
            },
            Storno: function (e) {
                win.close();
                callback(false);
            }
        });
        kendo.bind($("#SVCashRevisionParovat"), model);
        win = $("#SVCashRevisionParovat").data("kendoWindow");
        win.open().center();
    };
</script>