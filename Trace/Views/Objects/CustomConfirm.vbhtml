<div id="CustomConfirm" data-role="window"
    data-title=""
    data-width="400"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;" 
    data-bind="events: { close: Close }">
    <h3 data-bind="text: Text" style="text-align:center"></h3>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Yes }">@Language.btnYes</button>
        <button type="button" class="k-button" data-bind="events: { click: No }">@Language.btnNo</button>
    </div>
</div>
<script>
    function CustomConfirm(ti, te, callback) {
        var win;
        if (!ti) { ti = "" };
        var model = new kendo.observable({
            Text: te,
            Confirm: false,
            Yes: function (e) {
                this.set("Confirm", true);
                win.close();
            },
            No: function (e) {
                this.set("Confirm", false);
                win.close();
            },
            Close: function (e) {
                callback(this.Confirm);
            }
        });
        kendo.bind($("#CustomConfirm"), model);
        win = $("#CustomConfirm").data("kendoWindow");
        win.open().center();
        $("#CustomConfirm").prev().find(".k-window-title").text(ti);
    }
</script>