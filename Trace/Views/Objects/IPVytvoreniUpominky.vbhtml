<div id="IPVytvoreniUpominky" 
    data-role="window"
    data-title="@Html.Raw(Language.Key_VytvoreniUpominky)"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <table style="width: 100%">
        <tr style="height:30px;">
            <td colspan="3">
                <h4 data-bind="text: title"></h4>
            </td>
        </tr>
        <tr style="max-height:200px;overflow-y:auto">
            <td colspan="3" style="height:30px;">
                <select id="ddl1" data-role="multiselect"
                   data-placeholder="@Html.Raw(Language.Key_VyberteSpisy)"
                   data-value-primitive="true"
                   data-text-field="text"
                   data-value-field="IDSpisu"
                   data-bind="value: selected, source: source, visible: visible1"></select>
                <select id="ddl2" data-role="multiselect"
                   data-placeholder="@Html.Raw(Language.Key_VyberteDluzniky)"
                   data-value-primitive="true"
                   data-text-field="text"
                   data-value-field="IDSpisyOsoby"
                   data-bind="value: selected, source: source, visible: visible2"></select>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="padding-top: 10px;">
                <fieldset>
                    <legend><b>@Html.Raw(Language.IPVytvoreniUpominkyTXT1)</b></legend>
                    <table style="width:100%;">
                        <tr>
                            <td>@Html.Raw(Language.IPVytvoreniUpominkyTXT2)</td><td><input style="width: 100%;" data-role="datepicker" data-bind="value: upominka.datepicker, mindate: upominka.today" placeholder="@Html.Raw(Language.IPVytvoreniUpominkyTXT2)" /></td>
                        </tr>
                        <tr>
                            <td>@Html.Raw(Language.IPVytvoreniUpominkyTXT3)</td><td><input style="width: 100%;" class="k-textbox" data-bind="value: upominka.title" placeholder="@Html.Raw(Language.IPVytvoreniUpominkyTXT3)" /></td>
                        </tr>
                        <tr>
                            <td>@Html.Raw(Language.IPVytvoreniUpominkyTXT4)</td><td><input style="width: 100%;" class="k-textbox" data-bind="value: upominka.text" placeholder="@Html.Raw(Language.IPVytvoreniUpominkyTXT4)" /></td>
                        </tr>
                        <tr>
                            <td colspan="2"><button style="width:100%;" class="k-button k-primary" data-bind="click: upominka.save">@Html.Raw(Language.IPVytvoreniUpominkyTXT5)</button></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <button type="button" class="k-button" data-bind="events: { click: storno }">@Html.Raw(Language.IPVytvoreniUpominkyTXT6)</button>
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
    function IPVytvoreniUpominky(typeUpo, selected, callback) {
        var win;
        var model = new kendo.observable({
            title: function () {
                if (typeUpo === 1) {
                    return "@Html.Raw(Language.Key_NovaUpominkaNaSpis)"
                } else {
                    return "@Html.Raw(Language.Key_NovaUpominkaNaDluznika)"
                }
            },
            upominka: {
                datepicker: new Date(),
                today: new Date(),
                title: null,
                text: null,
                save: function (e) {
                    var ddl = $("#ddl1").data("kendoMultiSelect"),
                        that = this.get("upominka"),
                        di = null,
                        promises = null;

                    switch (typeUpo) {
                        case 1:
                            ddl = $("#ddl1").data("kendoMultiSelect");
                            di = ddl.dataItems();
                            promises = di.map(function (data, i) {
                                return $.Deferred(function (d) {
                                    $.get("@Url.Action("sp_Do_AddReminder", "Api/Service")", {
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
                        case 2:
                            ddl = $("#ddl2").data("kendoMultiSelect");
                            di = ddl.dataItems();
                            promises = di.map(function (data, i) {
                                return $.Deferred(function (d) {
                                    $.get("@Url.Action("sp_Do_AddReminder", "Api/Service")", {
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
                    };

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
            visible1: function () {
                return (typeUpo === 1)
            },
            visible2: function () {
                return (typeUpo === 2)
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
                    read: "@Url.Action("SourceUpominky", "Api/Service")",
                    parameterMap: function (options, type) {
                        return { type: typeUpo };
                    }
                }
            }),
            selected: selected,
            storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#IPVytvoreniUpominky"), model);
        win = $("#IPVytvoreniUpominky").data("kendoWindow");
        win.open().center();
    }
</script>