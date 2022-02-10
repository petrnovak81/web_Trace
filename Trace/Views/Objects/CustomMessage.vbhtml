<div id="CustomMessage" 
    data-role="window"
    data-title="Detail"
    data-modal="true"
    data-resizable="true"
    data-actions="['close']"
    style="display: none;width: 640px">
    <textarea id="CustomMessageArea" readonly class="k-textbox" data-bind="value: Message" style="resize: none;width:100%;max-width:100%;height:400px"></textarea>
    <div class="window-footer">
        <button type="button" class="k-button" data-bind="events: { click: Ok }">@Language.btnOk</button>
    </div>
</div>
<script>
    function CustomMessage(msg, callback) {
        var win;
        var model = new kendo.observable({
            Message: msg,
            Ok: function (e) {
                win.close();
                if (callback && typeof callback == "function") {
                    callback(true);
                }
            }
        });
        kendo.bind($("#CustomMessage"), model);
        win = $("#CustomMessage").data("kendoWindow");
        win.open().center();
    };
</script>
