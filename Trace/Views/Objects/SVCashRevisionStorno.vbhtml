<div id="SVCashRevisionStorno"
     data-role="window"
     data-title="@Html.Raw(Language.Key_VytvoreniZaznamuOStornovanemDokladu)"
     data-modal="true"
     data-resizable="false"
     data-actions="['close']"
     style="display: none;width: 400px">
    <input data-role="combobox"
           data-placeholder="@Html.Raw(Language.Key_VyberteInspektora)"
           data-filter="contains"
           data-suggest="true"
           data-value-primitive="true"
           data-auto-bind="false"
           data-text-field="UserLastName"
           data-value-field="IDUser"
           data-bind="value: iDUser,
                              source: vw_Users,
                              events: { change: userOnChange }"
           style="width: 100%" />
    <div data-role="grid"
         data-resizable="true"
         data-scrollable="true"
         data-selectable="false"
         data-auto-bind="false"
         data-bind="source: sp_Get_Cash_MissingCashDocNumber"
         data-columns="[
         {'template': '#=CellSelect(Diry)#', 'title': ' ', 'width': 30},
         {'field': 'missnum', 'template': '#=CellString(Diry)#', 'title': '@Html.Raw(Language.Key_CisloDokladu)'}
        ]" style="height:200px"></div>
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="events: { click: Ok }">@Language.btnOk</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function SVCashRevisionStorno() {
        var win;
        var model = new kendo.observable({
            iDUser: null,
            vw_Users: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDUser"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("vw_Users", "Api/AdminService")",
                        dataType: "json",
                    }
                }
            }),
            userOnChange: function (e) {
                this.set("iDUser", e.sender.value())
                this.sp_Get_Cash_MissingCashDocNumber.read();
            },
            sp_Get_Cash_MissingCashDocNumber: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDDiry"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_Cash_MissingCashDocNumber", "Api/AdminService")",
                        dataType: "json",
                    },
                    parameterMap: function (data, type) {
                        if (type == "read") {
                            var ID = model.get("iDUser");
                            if (!ID) { ID = 0 };
                            return { ID: ID };
                        }
                    }
                }
            }),
            Ok: function (e) {
                var ID = model.get("iDUser");
                var chs = $("#SVCashRevisionStorno .k-grid .select-row-checkbox:checked");
                chs.each(function () {
                    var cashDocNumber = $(this).data("param");
                    $.get("@Url.Action("sp_Do_Cash_GenerateCanceledDocNumber", "Api/AdminService")", { ID: ID, cashDocNumber: cashDocNumber }, function (result) {
                        
                    })
                    win.close();
                });
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#SVCashRevisionStorno"), model);
        win = $("#SVCashRevisionStorno").data("kendoWindow");
        win.open().center();
    };
</script>