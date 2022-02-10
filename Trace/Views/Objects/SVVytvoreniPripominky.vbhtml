<div id="SVVytvoreniPripominky" 
    data-role="window"
    data-title="@Html.Raw(Language.SVVytvoreniPripominky_Title1)"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <table style="width: 100%">
        <tr style="height:30px;">
            <td><input type="radio" value="1" data-bind="checked: radio, events: { change: change }" class="k-radio" id="SVVytvoreniPripominky1" name="radios_SVVytvoreniPripominky" /><label style="float:left" for="SVVytvoreniPripominky1" class="k-radio-label">IP</label></td>
            <td><input type="radio" value="2" data-bind="checked: radio, events: { change: change }" class="k-radio" id="SVVytvoreniPripominky2" name="radios_SVVytvoreniPripominky" /><label style="margin-left: 190px;" for="SVVytvoreniPripominky2" class="k-radio-label">@Html.Raw(Language.SVVytvoreniPripominkyTXT1)</label></td>
            <td><input type="radio" value="3" data-bind="checked: radio, events: { change: change }" class="k-radio" id="SVVytvoreniPripominky3" name="radios_SVVytvoreniPripominky" /><label style="float:right" for="SVVytvoreniPripominky3" class="k-radio-label">@Html.Raw(Language.SVVytvoreniPripominkyTXT2)</label></td>
        </tr>
        <tr style="max-height:200px;overflow-y:auto">
            <td colspan="3" style="height:30px;">
                <select id="ddl1" data-role="multiselect"
                   data-placeholder="@Html.Raw(Language.Key_VyberteInspektory)"
                   data-value-primitive="true"
                   data-text-field="text"
                   data-value-field="IDUser"
                   data-bind="value: selected, source: source, visible: visible1, events: { dataBound: dataBound }"></select>
                <select id="ddl2" data-role="multiselect"
                   data-placeholder="@Html.Raw(Language.Key_VyberteSpisy)"
                   data-value-primitive="true"
                   data-text-field="text"
                   data-value-field="IDSpisu"
                   data-bind="value: selected, source: source, visible: visible2, events: { dataBound: dataBound }"></select>
                <select id="ddl3" data-role="multiselect"
                   data-placeholder="@Html.Raw(Language.Key_VyberteDluzniky)"
                   data-value-primitive="true"
                   data-text-field="text"
                   data-value-field="IDSpisyOsoby"
                   data-bind="value: selected, source: source, visible: visible3, events: { dataBound: dataBound }"></select>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="padding-top: 10px;">
                <fieldset>
                    <legend><b>@Html.Raw(Language.SVVytvoreniPripominkyTXT3)</b></legend>
                    <table style="width:100%;">
                        <tr>
                            <td>@Html.Raw(Language.SVVytvoreniPripominkyTXT4)</td><td><input style="width: 100%;" data-role="datepicker" data-bind="value: pripominka.datepicker, mindate: pripominka.today" placeholder="@Html.Raw(Language.SVVytvoreniPripominkyTXT4)" /></td>
                        </tr>
                        <tr>
                            <td>@Html.Raw(Language.SVVytvoreniPripominkyTXT5)</td><td><input style="width: 100%;" class="k-textbox" data-bind="value: pripominka.title" placeholder="@Html.Raw(Language.SVVytvoreniPripominkyTXT5)" /></td>
                        </tr>
                        <tr>
                            <td>@Html.Raw(Language.SVVytvoreniPripominkyTXT6)</td><td><input style="width: 100%;" class="k-textbox" data-bind="value: pripominka.text" placeholder="@Html.Raw(Language.SVVytvoreniPripominkyTXT6)" /></td>
                        </tr>
                        <tr>
                            <td colspan="2"><button style="width:100%;" class="k-button k-primary" data-bind="click: pripominka.save">@Html.Raw(Language.SVVytvoreniPripominkyTXT7)</button></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <button type="button" class="k-button" data-bind="events: { click: storno }">@Html.Raw(Language.SVVytvoreniPripominkyTXT8)</button>
    </div>
</div>

<style>
    .k-multiselect-wrap li span {
    margin-right: 0;
    margin-top: -1px;
}
    .k-multiselect.k-header {
    max-height: 200px;
    overflow-y: auto;
}
</style>

<script>
    function SVVytvoreniPripominky(selected, source, callback) {
        var win;
        var model = new kendo.observable({
            pripominka: {
                datepicker: new Date(),
                today: new Date(),
                title: null,
                text: null,
                save: function (e) {
                    var type = model.get("radio");
                    var ddl = $("#ddl1").data("kendoMultiSelect"),
                        that = this.get("pripominka"),
                        di = null,
                        params = null,
                        promises = null;
                    switch (type) {
                        case "1":
                            ddl = $("#ddl1").data("kendoMultiSelect");
                            di = ddl.dataItems();
                            promises = di.map(function (data, i) {
                                return $.Deferred(function (d) {
                                    $.get("@Url.Action("sp_Do_AddReminder", "Api/AdminService")", {
                                        reminderDeadline: kendo.toString(that.datepicker, "yyyy-MM-dd"),
                                        reminderSubject: that.title,
                                        reminderTxt: that.text,
                                        reminderJobForUID: data.IDUser,
                                        iDSpisu: 0,
                                        iDSpisyOsoby: 0,
                                        awaitAnswer: false
                                    }).always(function () {
                                        d.notify(i);
                                        d.resolve.apply(this, arguments);
                                    })
                                }).promise();
                            });
                            break;
                        case "2":
                            ddl = $("#ddl2").data("kendoMultiSelect");
                            di = ddl.dataItems();
                            promises = di.map(function (data, i) {
                                return $.Deferred(function (d) {
                                    $.get("@Url.Action("sp_Do_AddReminder", "Api/AdminService")", {
                                        reminderDeadline: kendo.toString(that.datepicker, "yyyy-MM-dd"),
                                        reminderSubject: that.title,
                                        reminderTxt: that.text,
                                        reminderJobForUID: 0,
                                        iDSpisu: data.IDSpisu,
                                        iDSpisyOsoby: 0,
                                        awaitAnswer: false
                                    }).always(function () {
                                        d.notify(i);
                                        d.resolve.apply(this, arguments);
                                    })
                                }).promise();
                            });
                            break;
                        case "3":
                            ddl = $("#ddl3").data("kendoMultiSelect");
                            di = ddl.dataItems();
                            promises = di.map(function (data, i) {
                                return $.Deferred(function (d) {
                                    $.get("@Url.Action("sp_Do_AddReminder", "Api/AdminService")", {
                                        reminderDeadline: kendo.toString(that.datepicker, "yyyy-MM-dd"),
                                        reminderSubject: that.title,
                                        reminderTxt: that.text,
                                        reminderJobForUID: 0,
                                        iDSpisu: 0,
                                        iDSpisyOsoby: data.IDSpisyOsoby,
                                        awaitAnswer: false
                                    }).always(function () {
                                        d.notify(i);
                                        d.resolve.apply(this, arguments);
                                    })
                                }).promise();
                            });
                            break;
                    }
                    if (!$.trim(that.title)) {
                        message("@Html.Raw(Language.Key_VyplnteNadpisUpominky)", "info")
                        return;
                    }
                    if (!$.trim(that.text)) {
                        message("@Html.Raw(Language.Key_VyplnteTextUpominky)", "info")
                        return;
                    }
                    if (promises.length === 0) {
                        message("@Html.Raw(Language.Key_VyberteKomuMaBytVytvorenaUpominka)", "info")
                        return;
                    }
                    callback(promises);
                }
            },
            radio: "1",
            visible1: function () {
                return (this.get("radio") === "1")
            },
            visible2: function () {
                return (this.get("radio") === "2")
            },
            visible3: function () {
                return (this.get("radio") === "3")
            },
            source: new kendo.data.DataSource({
                schema: {
                    model: {
                        fields: {
                            "text": { type: "string" },
                            "IDUser": { type: "number" },
                            "IDSpisu": { type: "number" },
                            "IDSpisyOsoby": { type: "number" }
                        }
                    }
                },
                transport: {
                    read: "@Url.Action("SourcePripominky", "Api/AdminService")",
                    parameterMap: function (options, type) {
                        return { type: model.radio };
                    }
                }
            }),
            selected: null,
            dataBound: function (e) {
                this.set("selected", selected);
            },
            change: function (e) {
                this.source.read();
            },
            storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#SVVytvoreniPripominky"), model);
        win = $("#SVVytvoreniPripominky").data("kendoWindow");
        win.open().center();
    }
</script>