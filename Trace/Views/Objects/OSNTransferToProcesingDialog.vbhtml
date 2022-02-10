<div id="OSNTransferToProcesing" data-role="window"
    data-title="@Language.OSNTransferToProcesingDialogTitle"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <table style="width:100%">
        <tr><td style="width:200px">@Language.OSNTransferToProcesingDialogFile</td><td data-bind="text: Data.SpisC"></td></tr>
        <tr><td>@Language.OSNTransferToProcesingDialogDebtor</td><td data-bind="text: Data.Dluznik"></td></tr>
        <tr><td colspan="2"><hr /></td></tr>
        <tr>
            <td>
                <h4 style="margin:0">@Html.Raw(Language.OSNTransferToProcesingDialogTXT1)</h4><br />
                <ul class="fieldlist" data-bind="source: Source" data-template="transtoprocitemtemp">
                    
                </ul>
            </td>
            <td style="vertical-align: top;">
                <h4 style="margin:0">@Html.Raw(Language.OSNTransferToProcesingDialogTXT2)</h4>
                <input data-role="datepicker" data-bind="value: Date, mindate: Min" style="width:100%" />
                <h4 style="margin:0">@Html.Raw(Language.OSNTransferToProcesingDialogTXT3)</h4>
                <textarea class="k-textbox" style="width:100%;" rows="9" data-bind="value: Comment"></textarea>
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="enabled: OKbtnEna, events: { click: Save }">@Language.btnOk</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
    <script type="text/html" id="transtoprocitemtemp">
        <li>
            <input type="radio" name="radioTraToPro" id="radioTraToPro#=IDOrder#" value="#=IDOrder#" data-bind="checked: Value, events: { change: Change }" class="k-radio">
            <label class="k-radio-label" for="radioTraToPro#=IDOrder#">#=Val#</label>
        </li>
    </script>
</div>
<style>
    .fieldlist {
        margin: 0 0 -1em;
        padding: 0;
    }

        .fieldlist li {
            list-style: none;
            padding-bottom: 1em;
        }

    #OSNTransferToProcesing textarea {
        resize: none;
    }
</style>
<script>
    function showOSNTransferToProcesing(options, callback) {
        $.get('@Url.Action("tblRegisterRestrictions", "Api/Service")', { Register: "rr_CaseNextActivity" }, function (result) {
            var win;
            var OSNTransferToProcesing = new kendo.observable({
                Data: options,
                Source: result.Data,
                Date: new Date(),
                Min: new Date(),
                Value: "",
                Comment: "",
                OKbtnEna: false,
                Save: function (e) {
                    win.close();
                    callback(this.Date, this.Value, this.Comment);
                },
                Storno: function (e) {
                    win.close();
                },
                Change: function (e) {
                    this.set("OKbtnEna", true);
                }
            });
            kendo.bind($("#OSNTransferToProcesing"), OSNTransferToProcesing);
            win = $("#OSNTransferToProcesing").data("kendoWindow");
            win.center().open();
            $("#OSNTransferToProcesing [data-role='datepicker']").attr("readonly", true);
        });
    };
</script>

