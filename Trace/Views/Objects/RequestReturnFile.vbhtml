<div id="ReqReturnFile" data-role="window"
    data-title="@Language.ReqReturnFileTitle"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <textarea class="k-textbox" placeholder="@Language.ReqReturnFilePlaceholder" style="width:100%;resize: none;" rows="4" data-bind="value: Comment"></textarea>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Save }">@Language.btnOk</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>
<script>
    function showReqFileReturn(callback) {
        var win;
        var model = new kendo.observable({
            Comment: "",
            Save: function (e) {
                if (!$.trim(this.Comment)) {
                    message("   @SystemMessages.NoComment3 ", "info")
                    return;
                }
                win.close()
                callback(this.Comment);
            },
            Storno: function (e) {
                win.close()
            }
        });
        kendo.bind($("#ReqReturnFile"), model);
        win = $("#ReqReturnFile").data("kendoWindow");
        win.center().open();
    };
</script>

