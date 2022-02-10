<div id="ReturnFile" data-role="window"
    data-title="@Language.ReturnFileTitle"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <h3 data-bind="text: Title"></h3>
    <table style="width:100%">
        <tr>
            <td style="width:200px">
                <ul class="fieldlist" data-bind="source: Source" data-template="oreturnfileitemtemp">

                </ul>
            </td>
            <td style="vertical-align: top;">
                <h4 style="margin:0">@Language.ReturnFileTitleComment</h4>
                <textarea class="k-textbox" style="width:100%;" rows="4" data-bind="value: Comment"></textarea>
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="enabled: OKbtnEna, events: { click: Save }">@Language.btnOk</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
    <script type="text/html" id="oreturnfileitemtemp">
        <li>
            <input type="radio" name="radioRetF" id="r#=IDOrder#" value="#=IDOrder#" data-bind="checked: Value, events: { change: Change }" class="k-radio">
            <label class="k-radio-label" for="r#=IDOrder#">#=Val2#</label>
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

    #OSNReturn textarea {
        resize: none;
    }
</style>
<script>
    function showFileReturn(callback) {
        var win;
        $.get("@Url.Action("tblRegisterRestrictions", "Api/Service")", {Register: "rr_Dialog10to20BrakeFV"}, function (result) {
            var t = result.Data[0].Val;
            var model = new kendo.observable({
                Title: t,
                Source: result.Data,
                Value: "",
                Comment: "",
                OKbtnEna: false,
                Save: function (e) {
                    var res = $.grep(result.Data, function (item, index) {
                        return item.IDOrder == model.Value;
                    })[0];
                    if (this.Value == 3) {
                        if (!$.trim(this.Comment)) {
                            message("   @SystemMessages.NoComment4 ", "info")
                            return;
                        }
                    }
                    win.close()
                    callback([this.Title, res.Val2].join(", "), this.Comment);
                },
                Storno: function (e) {
                    win.close()
                },
                Change: function(e) {
                    this.set("OKbtnEna", true);
                }
            });
            kendo.bind($("#ReturnFile"), model);
            win = $("#ReturnFile").data("kendoWindow");
            win.center().open();
        });
    };
</script>

