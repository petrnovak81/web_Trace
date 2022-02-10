<div id="ModalCalendar"
     data-role="window"
     data-title="@Html.Raw(Language.Key_Kalendar)"
     data-modal="true"
     data-resizable="false"
     data-actions="['close']"
     style="display: none;">
    <div data-role="calendar"
         data-bind="value: SelectedDate"></div>
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="events: { click: Ok }">@Language.btnOk</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function ModalCalendar(callback) {
        var win;
        var model = new kendo.observable({
            SelectedDate: new Date(),
            Ok: function (e) {
                win.close();
                callback(this.SelectedDate);
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#ModalCalendar"), model);
        win = $("#ModalCalendar").data("kendoWindow");
        win.open().center();
    };
</script>