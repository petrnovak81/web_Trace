<div id="nextFile" data-role="window"
    data-title="@Html.Raw(Language.Key_Spisy)"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <h4 style="text-align:center" data-bind="text: Title"></h4>
    <div data-role="grid" 
        id="sp_Get_RFV_NonReported"
        data-bind="source: Source, events: { change: Change, dataBound: DataBound }"
        data-selectable="true"
        data-columns="[
        {'field': 'ACC', 'title': '@Html.Raw(Language.Key_CisloSpisu)', 'template': '#=CellString(ACC)#' },
        {'field': 'ActualDebit', 'title': '@Html.Raw(Language.Key_AktualniDluh)', 'template': '#=CellMoney(ActualDebit, rr_Currency)#'},
        {'field': 'StateTxt', 'title': '@Html.Raw(Language.Key_Stav)', 'template': '#=CellString(StateTxt)#'}
        ]" style="height:200px"></div>
    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="text: btnText, enabled: Enabled, events: { click: Save }">@Html.Raw(Language.TableNextFilesTXT1)</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function nextFileDialog(id1, id2, title, callback) {
        var win;
        var model = new kendo.observable({
            Title: title,
            selectedData: [],
            btnText: "@Html.Raw(Language.adressValidityBtnText1)",
            //ACC: null,
            //IDSpisu: null,
            Source: new kendo.data.DataSource({
                schema: {
                    data: "Data",
                    model: {
                        id: "IDspisyOsoby"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_RFV_NonReported", "Api/Service")?iDspisu=" + id1 + "&iDspisyOsoby=" + id2,
                        dataType: "json"
                    }
                }
            }),
            Enabled: false,
            DataBound: function (e) {
                var that = this;
                var d = this.get("Source").data();
                if (d.length == 1) {
                    var dt = d[0].toJSON();
                    var id = dt.IDSpisu;
                    this.set("selectedData", dt);
                    if (id == id1) {
                        if (dt.rr_State > 9 && dt.rr_State < 20) {
                            kendo.ui.progress($("#nextFile"), true);
                            $.get("@Url.Action("Run_11to30", "Api/Service")", { id: id }, function (result) {
                                kendo.ui.progress($("#nextFile"), false);
                                if (result.exception) {
                                    alert(result.exception)
                                } else {
                                    win.close();
                                    callback(that);
                                }
                            })
                        } else {
                            win.close();
                            callback(that);
                        }
                    }
                }
            },
            Change: function (e) {
                var di = e.sender.dataItem(e.sender.select());

                //rr_State
                this.set("selectedData", di);
                if (di.rr_State > 9 && di.rr_State < 20) {
                    this.set("btnText", "@Html.Raw(Language.adressValidityBtnText2)");
                } else {
                    this.set("btnText", "@Html.Raw(Language.adressValidityBtnText1)");
                }

                this.set("Enabled", true);
                //this.set("IDSpisu", di.IDSpisu);
                //this.set("ACC", di.ACC);
            },
            Save: function (e) {
                var that = this;
                if (that.selectedData.rr_State > 9 && that.selectedData.rr_State < 20) {
                    kendo.ui.progress($("#nextFile"), true);
                    $.get("@Url.Action("Run_11to30", "Api/Service")", { id: that.selectedData.IDSpisu }, function (result) {
                        kendo.ui.progress($("#nextFile"), false);
                        if (result.exception) {
                            alert(result.exception)
                        } else {
                            win.close();
                            callback(that);
                        }
                    })
                } else {
                    win.close();
                    callback(that);
                }
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#nextFile"), model);
        win = $("#nextFile").data("kendoWindow");
        win.open().center();
    }
</script>