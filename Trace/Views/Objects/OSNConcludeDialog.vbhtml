<div id="OSNCloseDoc" data-role="window"
    data-title="@Language.OSNConcludeDialogTitle"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <table style="width:100%">
        <tr><td>@Language.OSNConcludeDialogACC</td><td data-bind="text: data.ACC"></td></tr>
        <tr><td>@Language.OSNConcludeDialogDL</td><td data-bind="text: data.Name"></td></tr>
<!--         <tr>
            <td>Důvod</td>
            <td>
                <input data-role="dropdownlist"
                   data-text-field="Txt"
                   data-value-field="rr_ClosedFile"
                   data-bind="value: Value, source: Source" style="width: 100%;"/>
            </td>
        </tr> -->
        <tr>
            <td colspan="2">
                <h4 style="margin:0">@Language.OSNConcludeDialogComment</h4>
                <textarea class="k-textbox" autofocus style="width:100%;" rows="9" data-bind="value: data.Comment"></textarea>
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Save }">@Language.btnOk</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>
<style>
    #OSNCloseDoc textarea {
        resize: none;
    }
</style>
<script>
    function showOSNConclude(options, callback) {
        $.get('@Url.Action("vwrr_ClosedFile", "Api/Service")', {}, function (result) {
            var win;
            var OSNCloseDoc = new kendo.observable({
                data: options,
                Source: result.Data,
                Value: 0,
                Save: function (e) {
                    if (!$.trim(this.data.Comment)) {
                        message("   @SystemMessages.NoComment1 ", "info")
                        return;
                    }
                    win.close();
                    callback(this.Value, this.data.Comment)
                },
                Storno: function (e) {
                    win.close();
                }
            });
            kendo.bind($("#OSNCloseDoc"), OSNCloseDoc);
            win = $("#OSNCloseDoc").data("kendoWindow");
            win.open().center();
        });
    };
</script>