<div id="SVUzavreniSpisu231" 
    data-role="window"
    data-title="@Html.Raw(Language.SVUzavreniSpisu231_Title1)"
    data-modal="true"
    data-resizable="true"
    data-actions="['close']"
    style="display: none;width: 300px">
    <span>@Language.SVUzavreniSpisu231_Title2</span>
    <input maxlength="500" type="text" data-bind="value: Comment" style="width: 100%;" class="k-textbox" placeholder="@Language.PlaceholderComment" />
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="events: { click: Yes }">@Language.SVUzavreniSpisu231_OK</button>
        <button type="button" class="k-button" data-bind="events: { click: No }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function SVUzavreniSpisu(ids, callback) {
        var win;
        var model = new kendo.observable({
            Comment: "",
            Yes: function (e) {
                var comment = this.get("Comment");
                if (!$.trim(comment)) {
                    message("   @SystemMessages.NoComment1 ", "info")
                    return;
                }
                win.close();
                var promises = ids.map(function (id, i) {
                    return $.Deferred(function (d) {
                        $.get("@Url.Action("sp_Do_Super2_3_1", "Api/AdminService")", {
                            iDSpisu: id,
                            comment: comment
                        }, function (result) {
                            if (result.MsgType === 'error') {
                                var msg = "<span style='margin-left:6px;'>" + result.Msg.join("<br>") + "</span>"
                                message(msg, 'error');
                            }
                        }).always(function () {
                            d.notify(i);
                            d.resolve.apply(this, arguments);
                        })
                    }).promise();
                });
                callback(promises);
            },
            No: function (e) {
                win.close();
            }
        });
        kendo.bind($("#SVUzavreniSpisu231"), model);
        win = $("#SVUzavreniSpisu231").data("kendoWindow");
        win.open().center();
    };
</script>