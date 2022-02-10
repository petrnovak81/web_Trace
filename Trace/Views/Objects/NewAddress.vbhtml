<div id="NewAddress" 
    data-role="window"
    data-title="@Html.Raw(Language.Key_NovaAdresa)"
    data-width="500"
    data-modal="true"
    data-actions="['close']"
    style="display: none;">

    <div id="validWin1" data-bind="visible: win1">
        <h4>@Html.Raw(Language.NewAddressTXT1)</h4>
        <table style="width:100%;">
            <tr>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.street" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.NewAddressPLH8)" />
                </td>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.cp" class="k-textbox" maxlength="10" placeholder="@Html.Raw(Language.NewAddressPLH9)" />
                </td>
            </tr>
            <tr>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.city" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.NewAddressPLH10)" />
                </td>
                <td>
                    <input class="k-textbox" type="text" name="@Html.Raw(Language.NewAddressPLH11)" pattern="[0-9]{5}" maxlength="5" required data-bind="value: Source.zip, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.NewAddressPLH11)" style="width: 100%;" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" style="width: 100%;" data-bind="checked: Source.dalsiosn" class="k-checkbox" id="NewAddress0" /><label for="NewAddress0" data-bind="    visible: visibleNotWin3" class="k-checkbox-label">@Html.Raw(Language.NewAddressTXT5)</label>
                </td>
                <td>
                    <select
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: PlatnostAdresy, value: Source.platnost"
                        style="width: 100%;" required>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" style="width: 100%;" data-bind="checked: Source.zneplatnit" class="k-checkbox" id="NewAddress1" /><label for="NewAddress1" data-bind="    visible: visibleNotWin3" class="k-checkbox-label">@Html.Raw(Language.NewAddressTXT6)</label>
                </td>
                <td>
                    <select
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: TypAdresy, value: Source.typ"
                        style="width: 100%;" required>
                    </select>
                </td>
            </tr>
        </table>
    </div>

    <div id="validWin2" data-bind="visible: win2">
        <h4>@Html.Raw(Language.NewAddressTXT2)</h4>
        <span>@Html.Raw(Language.NewAddressTXT3) <i style="color:red">*</i></span>
        <select required
            name="@Html.Raw(Language.Key_JinaOsoba)"
            data-auto-bind="false"
            data-value-field="IDSpisyOsoby"
            data-template="tmpddosoby"
            data-value-template="tmpddosoby"
            data-role="dropdownlist"
            data-bind="source: Osoby, value: Source.osoba"
            style="width: 100%;">
        </select>
        <table style="width:100%;">
            <tr>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.street" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.NewAddressPLH8)" />
                </td>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.cp" class="k-textbox" maxlength="10" placeholder="@Html.Raw(Language.NewAddressPLH9)" />
                </td>
            </tr>
            <tr>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.city" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.NewAddressPLH10)" />
                </td>
                <td>
                    <input class="k-textbox" type="text" name="@Html.Raw(Language.NewAddressPLH11)" pattern="[0-9]{5}" name="@Html.Raw(Language.NewAddressPLH11)" maxlength="5" required data-bind="value: Source.zip, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.NewAddressPLH11)" style="width: 100%;" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" style="width: 100%;" data-bind="checked: Source.dalsiosn" class="k-checkbox" id="NewAddress0" /><label for="NewAddress0" data-bind="    visible: visibleNotWin3" class="k-checkbox-label">@Html.Raw(Language.NewAddressTXT5)</label>
                </td>
                <td>
                    <select
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: PlatnostAdresy, value: Source.platnost"
                        style="width: 100%;" required>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" style="width: 100%;" data-bind="checked: Source.zneplatnit" class="k-checkbox" id="NewAddress1" /><label for="NewAddress1" data-bind="    visible: visibleNotWin3" class="k-checkbox-label">@Html.Raw(Language.NewAddressTXT6)</label>
                </td>
                <td>
                    <select
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: TypAdresy, value: Source.typ"
                        style="width: 100%;" required>
                    </select>
                </td>
            </tr>
        </table>
    </div>

    <div id="validWin3" data-bind="visible: win3">
        <h4>@Html.Raw(Language.NewAddressTXT4)</h4>
        <table style="width:100%;">
            <tr>
                <td>
                    <input required name="@Html.Raw(Language.Key_Prijmeni)" style="width: 100%;" type="text" data-bind="value: Source.surname" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.NewAddressPLH16)" />
                </td>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.name" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.NewAddressPLH17)" />
                </td>
            </tr>
            <tr>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.street" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.NewAddressPLH8)" />
                </td>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.cp" class="k-textbox" maxlength="10" placeholder="@Html.Raw(Language.NewAddressPLH9)" />
                </td>
            </tr>
            <tr>
                <td>
                    <input style="width: 100%;" type="text" data-bind="value: Source.city" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.NewAddressPLH10)" />
                </td>
                <td>
                    <input class="k-textbox" type="text" name="@Html.Raw(Language.NewAddressPLH11)" pattern="[0-9]{5}" name="@Html.Raw(Language.NewAddressPLH11)" maxlength="5" required data-bind="value: Source.zip, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.NewAddressPLH11)" style="width: 100%;" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" style="width: 100%;" data-bind="checked: Source.dalsiosn" class="k-checkbox" id="NewAddress0" /><label for="NewAddress0" data-bind="    visible: visibleNotWin3" class="k-checkbox-label">@Html.Raw(Language.NewAddressTXT5)</label>
                </td>
                <td>
                    <select
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: PlatnostAdresy, value: Source.platnost"
                        style="width: 100%;" required>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" style="width: 100%;" data-bind="checked: Source.zneplatnit" class="k-checkbox" id="NewAddress1" /><label for="NewAddress1" data-bind="    visible: visibleNotWin3" class="k-checkbox-label">@Html.Raw(Language.NewAddressTXT6)</label>
                </td>
                <td>
                    <select
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: TypAdresy, value: Source.typ"
                        style="width: 100%;" required>
                    </select>
                </td>
            </tr>
        </table>
    </div>

    <div id="validNext">
        <table style="width: 100%;">
            <tr>
                <td colspan="2"><hr /></td>
            </tr>
            <tr>
                <td>
                    <input class="k-textbox" type="text" name="@Html.Raw(Language.NewAddressPLH23)" pattern="[0-9]{9}" name="@Html.Raw(Language.NewAddressPLH23)" maxlength="9" data-bind="value: Source.phone, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.NewAddressPLH23)" style="width: 100%;" />
                </td>
                <td>
                    <select
                        data-option-label="Platnost telefonu"
                        data-auto-bind="true"
                        data-value-field="IDOrder"
                        data-text-field="Val"
                        data-role="dropdownlist"
                        data-bind="source: PhoneValidity, value: Source.rr_PhoneValidity"
                        style="width: 100%;">
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="2"><hr /></td>
            </tr>
            <tr>
                <td>
                    <input style="width: 100%;" type="email" data-bind="value: Source.email" class="k-textbox" placeholder="@Html.Raw(Language.NewAddressPLH24)" />
                </td>
                <td>
                    <input type="checkbox" style="width: 100%;" data-bind="checked: Source.PersEmailValid" class="k-checkbox" id="platnostTel" /><label for="platnostTel" class="k-checkbox-label">@Html.Raw(Language.NewAddressTXT7)</label>
                </td>
            </tr>
        </table>
    </div>

    <div class="window-footer">
        <button type="button" class="k-primary k-button" data-bind="events: { click: Save }">@Language.btnSave</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script id="tmpddosoby" type="text/html">
    #=(PersSurname ? PersSurname : '') + ' ' + (PersName ? PersName : '')#
</script>

<script>
    function NewAddress(type, iDSpisu, callback) {
        var win;
        $("#validWin1").removeAttr("data-role");
        $("#validWin2").removeAttr("data-role");
        $("#validWin3").removeAttr("data-role");
        $("#validNext").removeAttr("data-role");
        var model = new kendo.observable({
            win1: function () {
                return (type === 1);
            },
            win2: function () {
                return (type === 2);
            },
            win3: function () {
                return (type === 3);
            },
            visibleNotWin3: function () {
                return (type !== 3);
            },
            numberValue: function (e) {
                if (e.widh != 9) {
                    return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
                };
            },
            Source: {
                city: null,
                comment: null,
                osoba: null,
                surname: null,
                name: null,
                cp: null,
                dalsiosn: null,
                email: null,
                phone: null,
                platnost: null,
                zip: null,
                street: null,
                typ: null,
                zneplatnit: null,
                rr_PhoneValidity: 3,
                PersEmailValid: false
            },
            Osoby: new kendo.data.DataSource({
                schema: {
                    data: "Data",
                    model: {
                        id: "IDSpisyOsoby"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_B3_Osoby", "Api/Service")?iDspisu=" + iDSpisu,
                        dataType: "json"
                    }
                }
            }),
            PlatnostAdresy: new kendo.data.DataSource({
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
            TypAdresy: new kendo.data.DataSource({
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
                        return { Register: "rr_AddressType" };
                    }
                }
            }),
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
                if (this.Source.city) {
                    if (!this.Source.typ) {
                        message("Typ adresy musí být vyplněn.")
                        return false;
                    }
                }
                var form1 = null;
                if (type === 1) {
                    form1 = $("#validWin1");
                }
                if (type === 2) {
                    form1 = $("#validWin2");
                }
                if (type === 3) {
                    form1 = $("#validWin3");
                }
                var form2 = $("#validNext");


                //validuju adresy
                if (this.Source.street || this.Source.cp || this.Source.city || this.Source.zip) {

                }



                var validator1 = form1.kendoValidator().data("kendoValidator");
                if (this.Source.street || this.Source.cp || this.Source.city || this.Source.zip) {
                    if (validator1.validate()) {
                        var validator2 = form2.kendoValidator().data("kendoValidator");
                        if (validator2.validate()) {
                            callback(this.Source)
                            win.close();
                        };
                    }
                } else {
                    var validator2 = form2.kendoValidator().data("kendoValidator");
                    if (validator2.validate()) {
                        callback(this.Source)
                        win.close();
                    };
                }
            },
            Storno: function (e) {
                win.close();
            }
        });
        kendo.bind($("#NewAddress"), model);
        win = $("#NewAddress").data("kendoWindow");
        win.open().center();
    }
</script>