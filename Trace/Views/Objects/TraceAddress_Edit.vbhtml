<div id="TraceAddress_Edit" 
    data-role="window"
    data-title="Edit"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <table style="width:600px">
        <tr>
            <td colspan="2">
                <span class="lt">@Html.Raw(Language.TraceAddress_EditTXT1)</span>
                <input type="text" class="k-textbox" style="width:100%" required data-bind="value: Source.Surname" name="@Html.Raw(Language.TraceAddress_EditPLH7)" placeholder="@Html.Raw(Language.TraceAddress_EditPLH7)" />
            </td>
        </tr>
        <tr>
            <td>
                <span class="lt">@Html.Raw(Language.TraceAddress_EditTXT2)</span>
                <input type="text" class="k-textbox" style="width:100%" required data-bind="value: Source.PersStreet" name="@Html.Raw(Language.TraceAddress_EditTXT2)" placeholder="@Html.Raw(Language.TraceAddress_EditTXT2)" />
            </td>
            <td style="width:100px;">
                <span class="lt">@Html.Raw(Language.TraceAddress_EditPLH9)</span>
                <input type="text" class="k-textbox" style="width:100%" required data-bind="value: Source.PersHouseNum" name="@Html.Raw(Language.TraceAddress_EditPLH9)" placeholder="@Html.Raw(Language.TraceAddress_EditPLH9)" />
            </td>
        </tr>
        <tr>
            <td>
                <span class="lt">@Html.Raw(Language.TraceAddress_EditTXT3)</span>
                <input type="text" class="k-textbox" style="width:100%" required data-bind="value: Source.PersCity" name="@Html.Raw(Language.TraceAddress_EditTXT3)" placeholder="@Html.Raw(Language.TraceAddress_EditTXT3)" />
            </td>
            <td>
                <span class="lt">@Html.Raw(Language.TraceAddress_EditTXT4)</span>
                <input type="text" pattern="[0-9]{5}" maxlength="5" class="k-textbox" style="width:100%" required data-bind="value: Source.PersZipCode, events: { keypress: numberValue }" name="@Html.Raw(Language.TraceAddress_EditTXT4)" placeholder="@Html.Raw(Language.TraceAddress_EditTXT4)" />
            </td>
        </tr>
<!--         <tr>
            <td colspan="2">
                <div id="validMap" style="height:300px"></div>
            </td>
        </tr> -->
    </table>
    <div class="window-footer">
        <a role="button" class="k-button k-button-icontext k-primary" data-bind="events: { click: Save }" href="#"><span class="k-icon k-i-check"></span>@Html.Raw(Language.TraceAddress_EditTXT5)</a>
        <a role="button" class="k-button k-button-icontext" data-bind="events: { click: Storno }" href="#"><span class="k-icon k-i-cancel"></span>@Html.Raw(Language.TraceAddress_EditTXT6)</a>
    </div>
</div>

<script>
    function traceAddress_Edit(data, callback) {
        var win;
        if (!data) {
            data = {
                Surname: "Bez názvu",
                PersStreet: null,
                PersHouseNum: null,
                PersCity: null,
                PersZipCode: null,
                GPSLat: null,
                GPSLng: null,
                GPSValid: null
            }
        }
        var model = new kendo.observable({
            Source: data,
            numberValue: function (e) {
                return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
            },
            Save: function (e) {
                //validace
                var that = this;
                var validator = $("#TraceAddress_Edit").kendoValidator().data("kendoValidator");
                if (validator.validate()) {
                    var addr = ((that.Source.PersStreet ? that.Source.PersStreet : "") + " " + (that.Source.PersHouseNum ? that.Source.PersHouseNum : "") + ", " + (that.Source.PersCity ? that.Source.PersCity : "") + " " + (that.Source.PersZipCode ? that.Source.PersZipCode : ""));
                    globalValidAddress(addr, function (adr, bol, msg) {
                        if (!bol) {
                            message(msg, "error");
                            that.Source.set("GPSLat", 0);
                            that.Source.set("GPSLng", 0);
                            that.Source.set("GPSValid", false);
                            callback(that.Source);
                            win.close();
                        } else {
                            if (msg !== "OK") message(msg, "info");
                            that.Source.set("GPSLat", adr.lat);
                            that.Source.set("GPSLng", adr.lng);
                            that.Source.set("GPSValid", true);
                            callback(that.Source);
                            win.close();
                        }
                    });
                };
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#TraceAddress_Edit"), model);
        win = $("#TraceAddress_Edit").data("kendoWindow");
        win.open().center();
    }
</script>
