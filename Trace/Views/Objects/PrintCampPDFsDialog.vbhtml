<div id="PrintCampPDFsDialog" 
    data-role="window"
    data-title="Tisk"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;width: 400px">
    <table>
        <tr>
            <td>
                <input type="checkbox" data-bind="checked: ch1" id="chdlsp" class="k-checkbox">
                <label class="k-checkbox-label" for="chdlsp">@Html.Raw(Language.PrintCampPDFsDialogTXT1)</label>
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" data-bind="checked: ch2" id="chdon" class="k-checkbox">
                <label class="k-checkbox-label" for="chdon">@Html.Raw(Language.PrintCampPDFsDialogTXT2)</label>
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" data-bind="checked: ch3" id="chuzsk" class="k-checkbox">
                <label class="k-checkbox-label" for="chuzsk">@Html.Raw(Language.PrintCampPDFsDialogTXT3)</label>
            </td>
        </tr>
    </table>
    
    
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="events: { click: Print }">@Language.btnPrint</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button> 
    </div>
</div>

<script>
    function printCampPDFsDialog(callback) {
        var win;
        var model = new kendo.observable({
            ch1: true,
            ch2: true,
            ch3: true,
            Print: function (e) {
                win.close();
                callback(model);
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#PrintCampPDFsDialog"), model);
        win = $("#PrintCampPDFsDialog").data("kendoWindow");
        win.open().center();
    };
</script>