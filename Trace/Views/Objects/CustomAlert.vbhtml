<div id="CustomAlert" data-role="window"
    data-title=""
    data-width="400"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <p data-bind="text: Text"></p>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Ok }">@Language.btnOk</button>
    </div>
</div>
<script>
    function CustomAlert(title, text, callback) {
        var win;
        if (!title) { title = "" };
        var model = new kendo.observable({
            Text: text,
            Ok: function (e) {
                win.close();
                if (callback) {
                    callback(e);
                }
            }
        });
        kendo.bind($("#CustomAlert"), model);
        win = $("#CustomAlert").data("kendoWindow");
        win.open().center();
        $("#CustomAlert").prev().find(".k-window-title").text(title);
    }
</script>