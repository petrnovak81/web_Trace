<div id="progressBarDialog" data-role="window"
    data-title="false"
    data-width="600"
    data-modal="true"
    data-resizable="true"
    data-actions="['minimize', 'maximize', 'close']"
    data-bind="events: { close: winClose }"
    style="display: none;">
    <div data-role="progressbar"
                 data-min="0"
                 data-max="100"
                 data-animation="false"
                 data-type= "percent"
                 data-bind="value: progressValue, events: { change: progressChange, complete: progressComplete }" style="width: 99%;"></div>
    <span data-bind="text: progressText"></span>
    <div data-role="grid" data-bind="source: progressLog, visible: progressLogVisible"
        data-resizable="true"
        data-columns="[
        {'field': 'text', 'title': '@Language.ProgressText', 'template': '#=CellString(text)#'}
        ]" style="height:200px"></div>
    <div class="window-footer">
        <button style="float:right" class="k-button" data-bind="visible: stornoVisible, events: { click: btnStorno }" >@Language.btnStorno</button>
        <button style="float:right" class="k-button k-primary" data-bind="visible: btnVisible, enabled: btnEnable, events: { click: btnClick }" >@Language.btnOk</button>
    </div>
</div>
<script id="progressLogTemp" type="text/html">
    <li>#=text#</li>
</script>
<script>
    var winProgressBarDialog;
    var progress_storno = false;
    var progressModel = new kendo.observable({
        progressValue: 0,
        progressText: "-",
        progressLog: new kendo.data.DataSource({
            data: []
        }),
        progressLogVisible: false,
        stornoVisible: false,
        btnVisible: true,
        btnEnable: false,
        btnClick: function () {
            winProgressBarDialog.close();
        },
        progressChange: function (e) {
            var progress = $(e.sender.element).data("kendoProgressBar");
            progress.progressWrapper.css({
                "background-color": "#00b0ff",
                "border-color": "#00b0ff"
            });
        },
        progressComplete: function (e) {
            var progress = $(e.sender.element).data("kendoProgressBar");
            progress.progressWrapper.css({
                "background-color": "#92DB00",
                "border-color": "#92DB00"
            });
            if (this.progressLog.data().length > 0) {
                this.set("progressLogVisible", true);
            }
            this.set("progressText", "@SystemMessages.Success");
            this.set("btnEnable", true);
        },
        winClose: function (e) {
            this.set("progressText", "-");
            this.set("progressValue", 0);
            this.set("btnEnable", false);
            this.progressLog.data([]);
        },
        btnStorno: function () {
            this.set("progressValue", 100);
            progress_storno = true;
            winProgressBarDialog.close();
        }
    });
    kendo.bind($("#progressBarDialog"), progressModel);
    winProgressBarDialog = $("#progressBarDialog").data("kendoWindow");
</script>
