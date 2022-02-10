<div id="ListUrgAndRemind" data-role="window"
    data-title=""
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none; max-height:600px;">
    <h3>@Html.Raw(Language.ListUrgAndRemindTXT1)</h3>
    <table data-bind="source: Source" data-template="ListUrgAndRemindtemp" style="width:100%;border-spacing: 1px;"></table>
    <script type="text/html" id="ListUrgAndRemindtemp">
    <tr>
        <td style="width:30px;padding:3px;text-align:center;">
            # if(Type === 'U') { #
    <i style="color: rgb(158, 43, 17);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } else if(Type === 'R') { #
    <i style="color: rgb(255, 210, 70);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } else if(Type === 'M') { #
    <i style="color: rgb(120, 210, 55);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } #
        </td>
        <td style="width:60px;padding:3px;">
            # if(CreatedDate) { #
            #=CellDate(CreatedDate)#
            # } #
        </td>
        <td style="padding:3px;">#=CellString(Txt)#</td>
    </tr>
</script>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Yes }">@Html.Raw(Language.ListUrgAndRemindTXT2)</button>
        <button type="button" class="k-button" data-bind="events: { click: No }">@Html.Raw(Language.ListUrgAndRemindTXT3)</button>
    </div>
</div>
<script>
    function showListUrgAndRemind(data, callback) {
        var win;
        var model = new kendo.observable({
            Source: data,
            Yes: function (e) {
                win.close();
                callback(true);
            },
            No: function (e) {
                win.close();
                callback(false);
            }
        });
        kendo.bind($("#ListUrgAndRemind"), model);
        win = $("#ListUrgAndRemind").data("kendoWindow");
        win.open().center();
    }
</script>