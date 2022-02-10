<div id="SVResPodUzaSpisu232" 
    data-role="window"
    data-title="@Html.Raw(Language.SVResPodUzaSpisu232_Title1)"
    data-modal="true"
    data-resizable="true"
    data-actions="['close']"
    style="display: none;width: 400px">
    <span>@Language.SVResPodUzaSpisu232_Title2</span>
    <ul class="fieldlist">
        <li>
            <input type="radio" value="1" data-bind="checked: Open, events: { change: UzavreniSpisu }" class="k-radio" id="SVResPodUzaSpisu232_radio1" name="SVResPodUzaSpisu232" /><label for="SVResPodUzaSpisu232_radio1" class="k-radio-label">@Html.Raw(Language.SVResPodUzaSpisu232TXT1)</label>
            <div style="margin-left:30px;margin-top:8px;" data-bind="visible: UzavreniSpisu_visible">
                <span>@Language.SVUzavreniSpisu231_Title2</span>
                <input maxlength="300" type="text" data-bind="value: UzavreniSpisuSource.Comment" style="width: 100%;" class="k-textbox" placeholder="@Language.PlaceholderComment" />
            </div>
        </li>
        <li>
            <input type="radio" value="2" data-bind="checked: Open, events: { change: ZpetOSN }" class="k-radio" id="SVResPodUzaSpisu232_radio2" name="SVResPodUzaSpisu232" /><label for="SVResPodUzaSpisu232_radio2" class="k-radio-label">@Html.Raw(Language.SVResPodUzaSpisu232TXT2)</label>
            <div style="margin-left:30px;margin-top:8px;" data-bind="visible: ZpetOSN_visible">
                <span>@Language.SVResPodUzaSpisu232_ZpetOSN_Title1</span>
                <input maxlength="300" type="text" data-bind="value: ZpetOSNSource.Comment" style="width: 100%;" class="k-textbox" placeholder="@Language.PlaceholderComment" />
                <span>@Language.SVResPodUzaSpisu232_ZpetOSN_Title2</span>
                <input style="width: 100%;" data-role="datepicker" data-bind="value: ZpetOSNSource.DMAX, mindate: today" placeholder="@Language.PlaceholderDMAX" />
            </div>
        </li>
        <li>
            <input type="radio" value="3" data-bind="checked: Open, events: { change: KeZprac }" class="k-radio" id="SVResPodUzaSpisu232_radio3" name="SVResPodUzaSpisu232" /><label for="SVResPodUzaSpisu232_radio3" class="k-radio-label">@Html.Raw(Language.SVResPodUzaSpisu232TXT3)</label>
            <div style="margin-left: 30px;margin-top:8px;" data-bind="visible: KeZprac_visible">
                <span>@Language.SVResPodUzaSpisu232_KeZprac_Title1</span>
                <input maxlength="300" type="text" data-bind="value: KeZpracSpisuSource.Comment1" style="width: 100%;" class="k-textbox" placeholder="@Language.PlaceholderDuvodVraceni" />
                <span>@Language.SVResPodUzaSpisu232_KeZprac_Title2</span>
                <input style="width: 100%;" data-role="datepicker" data-bind="value: KeZpracSpisuSource.datumDeadLine, mindate: today" placeholder="" />
                <ul class="fieldlist" data-bind="source: KeZpracSpisuSource.Source" data-template="transtoprocitemtemp">
                </ul>
                <input maxlength="500" type="text" data-bind="value: KeZpracSpisuSource.Comment2" style="width: 100%;" class="k-textbox" placeholder="" />
            </div>
        </li>
    </ul>
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="text: btnText, visible: btnVisible, events: { click: Save }"></button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
    <script type="text/html" id="transtoprocitemtemp">
        <li>
            <input type="radio" name="radioTraToPro" id="radioTraToPro#=IDOrder#" value="#=IDOrder#" data-bind="checked: rr_CaseNextActivity" class="k-radio">
            <label class="k-radio-label" for="radioTraToPro#=IDOrder#">#=Val#</label>
        </li>
    </script>
</div>

<script>
    function SVResPodUzaSpisu(ids, text, callback) {
        var win;
        var model = new kendo.observable({
            Open: 0,
            btnVisible: false,
            btnText: null,
            today: new Date(),
            UzavreniSpisuSource: {
                Comment: text
            },
            ZpetOSNSource: {
                Comment: text,
                DMAX: new Date()
            },
            KeZpracSpisuSource: {
                Source: new kendo.data.DataSource({
                    schema: {
                        total: "Total",
                        data: "Data",
                        model: {
                            id: "IDOrder"
                        }
                    },
                    transport: {
                        read: {
                            url: "@Url.Action("tblRegisterRestrictions", "Api/Service")",
                            dataType: "json",
                        },
                        parameterMap: function (options, type) {
                            return { Register: "rr_CaseNextActivity" };
                        }
                    }
                }),
                Comment1: text,
                Comment2: text,
                datumDeadLine: new Date(),
                rr_CaseNextActivity: 0
            },
            UzavreniSpisu_visible: false,
            ZpetOSN_visible: false,
            KeZprac_visible: false,
            UzavreniSpisu: function (e) {
                this.set("btnVisible", true);
                this.set("btnText", "@Html.Raw(Language.SVResPodUzaSpisu232_btn1)");
                this.set("UzavreniSpisu_visible", true);
                this.set("ZpetOSN_visible", false);
                this.set("KeZprac_visible", false);
            },
            ZpetOSN: function (e) {
                this.set("btnVisible", true);
                this.set("btnText", "@Html.Raw(Language.SVResPodUzaSpisu232_btn2)");
                this.set("UzavreniSpisu_visible", false);
                this.set("ZpetOSN_visible", true);
                this.set("KeZprac_visible", false);
            },
            KeZprac: function (e) {
                this.set("btnVisible", true);
                this.set("btnText", "@Html.Raw(Language.SVResPodUzaSpisu232_btn3)");
                this.set("UzavreniSpisu_visible", false);
                this.set("ZpetOSN_visible", false);
                this.set("KeZprac_visible", true);
            },
            Storno: function (e) {
                win.close();
            },
            Save: function (e) {
                var that = this;
                var buffer = [];
                var promises = null
                switch (that.get("Open")) {
                    case "1":
                        var data = that.get("UzavreniSpisuSource");
                        //sp_Do_Super2_3_2_Radio1(comment As String) As Object
                        promises = ids.map(function (id, i) {
                            return $.Deferred(function (d) {
                                $.get("@Url.Action("sp_Do_Super2_3_2_Radio1", "Api/AdminService")", {
                                    iDSpisu: id,
                                    comment: data.Comment
                                }, function (result) {
                                    if (result.MsgType === 'error') {
                                        var msg = "<span style='margin-left:6px;'>" + result.Msg.join("<br>") + "</span>"
                                        message(msg, 'error');
                                    }
                                }).always(function () {
                                    d.notify(i);
                                    d.resolve.apply(this, arguments);
                                });
                            }).promise();
                        });
                        break;
                    case "2":
                        var data = that.get("ZpetOSNSource");
                        //sp_Do_Super2_3_2_Radio2(comment1 As String, dMax As Nullable(Of Date)) As Object
                        var counter = 0;
                        promises = ids.map(function (id, i) {
                            return $.Deferred(function (d) {
                                $.get("@Url.Action("sp_Do_Super2_3_2_Radio2", "Api/AdminService")", {
                                    iDSpisu: id,
                                    comment1: data.Comment,
                                    dMax: kendo.toString(data.DMAX, "yyyy-MM-dd HH:mm:ss")
                                }, function (result) {
                                    if (result.MsgType === 'error') {
                                        var msg = "<span style='margin-left:6px;'>" + result.Msg.join("<br>") + "</span>"
                                        message(msg, 'error');
                                    }
                                }).always(function () {
                                    d.notify(counter++);
                                    d.resolve.apply(this, arguments);
                                })
                            }).promise();
                        });
                        break;
                    case "3":
                        var data = that.get("KeZpracSpisuSource");
                        //sp_Do_Super2_3_2_Radio3(iDSpisu As Nullable(Of Integer), comment1 As String, rr_CaseNextActivity As Nullable(Of Short), commentJine As String, datumDeadLine As Nullable(Of Date)) As Object
                        promises = ids.map(function (id, i) {
                            return $.Deferred(function (d) {
                                $.get("@Url.Action("sp_Do_Super2_3_2_Radio3", "Api/AdminService")", {
                                    iDSpisu: id,
                                    comment1: data.Comment1,
                                    rr_CaseNextActivity: data.rr_CaseNextActivity,
                                    commentJine: data.Comment2,
                                    datumDeadLine: kendo.toString(data.datumDeadLine, "yyyy-MM-dd HH:mm:ss"),
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
                        break;
                }
                callback(promises)
                win.close();
            }
        });
        kendo.bind($("#SVResPodUzaSpisu232"), model);
        win = $("#SVResPodUzaSpisu232").data("kendoWindow");
        win.open().center();
    };
</script>