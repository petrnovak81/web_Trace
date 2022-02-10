<div id="NewEMPAddress" 
    data-role="window"
    data-title="Kontakt na zaměstnavatele dlužníka"
    data-width="500"
    data-modal="true"
    data-actions="['close']"
    style="display: none;">

    <table style="width: 100%;">
        <tr>
            <td>
                <input style="width: 100%;" required type="text" data-bind="value: Source.employerName" class="k-textbox" maxlength="60" name="Název zaměstnavatele" placeholder="Název zaměstnavatele" />
            </td>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.employerIC" class="k-textbox" maxlength="60" name="IČO" placeholder="IČO" />
            </td>
        </tr>
        <tr>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.employerContactName" class="k-textbox" maxlength="60" name="Jméno" placeholder="Jméno" />
            </td>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.employerContactSurname" class="k-textbox" maxlength="60" name="Příjmení" placeholder="Příjmení" />     
            </td>
        </tr>
        <tr>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.employerStreet" class="k-textbox" maxlength="60" name="IČO" placeholder="Ulice" />
            </td>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.employerHouseNum" class="k-textbox" maxlength="10" name="IČO" placeholder="ČP" />   
            </td>
        </tr>
        <tr>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.employerZipCode, events: { keypress: numberValue }" pattern="[0-9]{5}" class="k-textbox" maxlength="5" name="PSČ" placeholder="PSČ" />
            </td>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.employerCity" class="k-textbox" maxlength="60" name="Město" placeholder="Město" />  
            </td>
        </tr>
        <tr>
            <td>
                <input style="width: 100%;" type="email" data-bind="value: Source.employerContactEmail" class="k-textbox" maxlength="60" name="Email" placeholder="Email" />
            </td>
            <td>
                <input style="width: 100%;" type="text" data-bind="value: Source.employerContactPhone" class="k-textbox" maxlength="9" pattern="[0-9]{9}" name="Telefon" placeholder="Telefon" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <select
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: AddressValidity, value: Source.rr_AddressValidity"
                        style="width: 100%;">
                    </select>
            </td>
            <td>
            </td>
        </tr>
    </table>

    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Save }">@Language.btnSave</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>
    function NewEMPAddress(callback) {
        var win;
        var model = new kendo.observable({
            numberValue: function (e) {
                if (e.widh != 9) {
                    return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
                };
            },
            Source: {
                employerName: null, //*
                employerIC: null, //*
                employerCity: null, //*
                employerHouseNum: null, //*
                employerStreet: null, //*
                employerZipCode: null, //*
                rr_AddressValidity: 2, //*
                employerContactSurname: null, //*
                employerContactName: null, //*
                employerContactEmail: null, //*
                employerContactPhone: null //*
            },
            AddressValidity: new kendo.data.DataSource({
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
                                return { Register: "rr_AddressValidity" };
                            }
                        }
            }),
            Save: function (e) {
                var validator = $("#NewEMPAddress").kendoValidator().data("kendoValidator");
                if (validator.validate()) {
                    win.close();
                    callback(this.Source)
                }
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#NewEMPAddress"), model);
        win = $("#NewEMPAddress").data("kendoWindow");
        win.open().center();
    }
</script>