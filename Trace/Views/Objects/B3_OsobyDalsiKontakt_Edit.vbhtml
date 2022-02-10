<div id="B3_OsobyDalsiKontakt_Edit" 
    data-role="window"
    data-title="Edit"
    data-modal="true"
    data-width="500"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">

    <table style="width: 100%;">
        <tr>
            <td colspan="2">
                <span>@Html.Raw(Language.B3_OsobyDalsiKontakt_EditTXT1)</span>
                <select
                    data-control="edit"
                    data-value-primitive="true"
                    data-auto-bind="false"
                    data-value-field="value"
                    data-text-field="text"
                    data-role="dropdownlist"
                    data-bind="source: PersType, value: Source.rr_PersType" style="width:100%;">
                </select>
            </td>
        </tr>
        <tr>
            <td>
                <input required name="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH6)" style="width: 100%;" type="text" data-bind="value: Source.NCSurname" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH6)" />
            </td>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.NCName" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH7)" />
            </td>
        </tr>
        <tr>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.NCStreet" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH8)" />
            </td>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.NCHouseNum" class="k-textbox" maxlength="10" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH9)" />
            </td>
        </tr>
        <tr>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.NCCity" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH10)" />
            </td>
            <td>
                <input class="k-textbox" type="text" name="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH11)" pattern="[0-9]{5}" name="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH11)" maxlength="5" data-bind="value: Source.NCZipCode, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH11)" style="width: 100%;" />
            </td>
        </tr>
        <tr>
            <td>
                <input maxlength="300" style="width: 100%;" type="text" data-bind="value: Source.NCComment" class="k-textbox" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH12)" />
            </td>
            <td>
                <input type="checkbox" name="NCAddressVisited" id="NCAddressVisited" class="k-checkbox" data-type="boolean" data-bind="checked: Source.NCAddressVisited">
                <label class="k-checkbox-label" for="NCAddressVisited">@Html.Raw(Language.B3_OsobyDalsiKontakt_EditTXT2)</label>
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" class="k-input k-textbox" name="NC@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH13)" data-type="email" data-bind="    value: Source.NC@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH13)" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH13)">
            </td>
            <td>
                <input type="checkbox" name="NC@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH13)Valid" id="NC@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH13)Valid" class="k-checkbox" data-type="boolean" data-bind="    checked: Source.NC@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH13)Valid">
                <label class="k-checkbox-label" for="NC@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH13)Valid">@Html.Raw(Language.B3_OsobyDalsiKontakt_EditTXT3)</label>
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" class="k-input k-textbox" name="NCPhone" data-bind="    value: Source.NCPhone" placeholder="@Html.Raw(Language.B3_OsobyDalsiKontakt_EditPLH14)">
            </td>
            <td>
                <select
                        data-option-label="Platnost telefonu"
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: PhoneValidity, value: Source.NCPhoneValid"
                        style="width: 100%;">
                    </select>

                <!-- <input type="checkbox" name="NCPhoneValid" id="NCPhoneValid"  class="k-checkbox" data-type="boolean" data-bind="    checked: Source.NCPhoneValid">
                <label class="k-checkbox-label" for="NCPhoneValid">Platnost telefonu</label> -->
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <a role="button" class="k-button k-button-icontext k-primary" data-bind="events: { click: Save }" href="#"><span class="k-icon k-i-check"></span>@Html.Raw(Language.B3_OsobyDalsiKontakt_EditTXT4)</a>
        <a role="button" class="k-button k-button-icontext" data-bind="events: { click: Storno }" href="#"><span class="k-icon k-i-cancel"></span>@Html.Raw(Language.B3_OsobyDalsiKontakt_EditTXT5)</a>
    </div>
</div>

<script>
    function osobyDalsiKontakt_Edit(data, ddl, ds) {
        var win;
        var model = new kendo.observable({
            PersType: ddl,
            Source: data,
            numberValue: function (e) {
                return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
            },
            PhoneValidity: new kendo.data.DataSource({
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
                        return { Register: "rr_PhoneValidity" };
                    }
                }
            }),
            Save: function (e) {
                ds.sync();
                win.close();
            },
            Storno: function (e) {
                win.close();
            },
            Close: function (e) {
                ds.read();
            }
        });
        kendo.bind($("#B3_OsobyDalsiKontakt_Edit"), model);
        win = $("#B3_OsobyDalsiKontakt_Edit").data("kendoWindow");
        win.open().center();
    }
</script>
