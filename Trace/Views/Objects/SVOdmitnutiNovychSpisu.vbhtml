<div id="SVOdmitnutiNovychSpisu" 
    data-role="window"
    data-title="@Html.Raw(Language.SVOdmitnutiNovychSpisu_Title1)"
    data-modal="true"
    data-resizable="true"
    data-actions="['close']"
    style="display: none;width: 400px">
    <ul class="fieldlist">
        <li>
            <input type="radio" value="1" data-bind="checked: Open, events: { change: Potvrzeni }" class="k-radio" id="SVOdmitnutiNovychSpisu_radio1" name="SVOdmitnutiNovychSpisu" /><label for="SVOdmitnutiNovychSpisu_radio1" class="k-radio-label">@Html.Raw(Language.SVOdmitnutiNovychSpisuTXT1)</label>
        </li>
        <li>
            <input type="radio" value="2" data-bind="checked: Open, events: { change: Zamitnuti }" class="k-radio" id="SVOdmitnutiNovychSpisu_radio2" name="SVOdmitnutiNovychSpisu" /><label for="SVOdmitnutiNovychSpisu_radio2" class="k-radio-label">@Html.Raw(Language.SVOdmitnutiNovychSpisuTXT2)</label>
            <div style="margin-left:30px;margin-top:8px;" data-bind="visible: visible1">
                <span>@Language.SVOdmitnutiNovychSpisu_Title3</span>
                <input maxlength="300" type="text" data-bind="value: Comment" style="width: 100%;" class="k-textbox" placeholder="@Language.SVOdmitnutiNovychSpisu_CommentPlaceholder" />
            </div>
        </li>
    </ul>
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="text: btnText, visible: btnVisible, events: { click: Save }"></button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function SVOdmitnutiNovychSpisu(ids, callback) {
        var win;
        var model = new kendo.observable({
            Open: 0,
            btnVisible: false,
            btnText: null,
            Comment: "",
            visible1: false,
            Potvrzeni: function (e) {
                this.set("btnVisible", true);
                this.set("btnText", "@Html.Raw(Language.SVOdmitnutiNovychSpisu_btn1)");
                this.set("visible1", false);
            },
            Zamitnuti: function (e) {
                this.set("btnVisible", true);
                this.set("btnText", "@Html.Raw(Language.SVOdmitnutiNovychSpisu_btn2)");
                this.set("visible1", true);
            },
            Storno: function (e) {
                win.close();
            },
            Save: function (e) {
                var that = this;
                var buffer = [];
                var promises = null;
                switch (that.get("Open")) {
                    case "1":
                        promises = ids.map(function (id, i) {
                            return $.Deferred(function (d) {
                                $.get("@Url.Action("sp_Do_Super2_3_3_Radio1", "Api/AdminService")", {
                                    iDSpisu: id
                                }).always(function () {
                                    d.notify(i);
                                    d.resolve.apply(this, arguments);
                                })
                            }).promise();
                        });
                        break;
                    case "2":
                        promises = ids.map(function (id, i) {
                            return $.Deferred(function (d) {
                                $.get("@Url.Action("sp_Do_Super2_3_3_Radio2", "Api/AdminService")", {
                                    iDSpisu: id,
                                    comment: that.Comment
                                }).always(function () {
                                    d.notify(i);
                                    d.resolve.apply(this, arguments);
                                })
                            }).promise();
                        });
                        break;
                }
                callback(promises)
                win.close();
            }
        });
        kendo.bind($("#SVOdmitnutiNovychSpisu"), model);
        win = $("#SVOdmitnutiNovychSpisu").data("kendoWindow");
        win.open().center();
    }
</script>