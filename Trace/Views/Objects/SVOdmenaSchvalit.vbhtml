<div id="SVOdmenaSchvalit"
     data-role="window"
     data-title="@Html.Raw(Language.Key_Upravit)"
     data-modal="true"
     data-resizable="false"
     data-actions="['close']"
     style="display: none;width: 400px">
    <input type="text" class="k-textbox" style="width: 100%;" onclick="$(this).select();" data-bind="value: Fee, events: { keypress: numberValue }"  placeholder="@Html.Raw(Language.SVOdmenaSchvalitPLH2)" />
    <input type="checkbox" class="k-checkbox" id="SVOdmenaSchvalit_checkbox" data-bind="checked: SVApproved"><label class="k-checkbox-label" for="SVOdmenaSchvalit_checkbox">@Html.Raw(Language.SVOdmenaSchvalitTXT1)</label>
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="events: { click: Save }">@Language.btnSave</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function SVOdmenaSchvalit(iDFee, fee, sVApproved, callback) {
        var win;
        var model = new kendo.observable({
            Fee: fee,
            SVApproved: sVApproved,
            numberValue: function (e) {
                var temp = e.currentTarget.value;
                var count = (temp.match(/,/g) || []).length;
                return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57) || e.which === 110) ? (e.which === 44 && count === 0 ? true : false) : true;
            },
            Save: function (e) {
                $.get("@Url.Action("sp_Do_Cash_ValidateFee", "Api/AdminService")", { iDFee: iDFee, fee: this.Fee, sVApproved: this.SVApproved }, function (result) {
                    win.close();
                    callback(true)
                })
            },
            Storno: function (e) {
                win.close();
                callback(false)
            }
        });
        kendo.bind($("#SVOdmenaSchvalit"), model);
        win = $("#SVOdmenaSchvalit").data("kendoWindow");
        win.open().center();
    };
</script>