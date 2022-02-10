<div id="SVValidateFeeAdd"
     data-role="window"
     data-title="@Html.Raw(Language.Key_VlozitZaznam)"
     data-modal="true"
     data-resizable="false"
     data-actions="['close']"
     style="display: none;width: 400px">

    <table style="width:100%;">
        <tr>
            <td colspan="2">
                <input type="radio" name="types" id="type1" class="k-radio" value="1" data-bind="checked: types">
                <label class="k-radio-label" for="type1">Dle spisu</label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="radio" name="types" id="type2" class="k-radio" value="2" data-bind="checked: types">
                <label class="k-radio-label" for="type2">Ke smazanému spisu</label>
            </td>
            <td></td>
        </tr>
        <tr data-bind="visible: visiblefor1">
            <td colspan="2">
                <input data-role="combobox"
                       data-placeholder="@Html.Raw(Language.Key_VyberteSpis)"
                       data-filter="contains"
                       data-suggest="true"
                       data-value-primitive="true"
                       data-auto-bind="false"
                       data-text-field="TXT"
                       data-value-field="IDSpisu"
                       data-bind="value: iDSpisu,
                                  source: sp_Get_SV_CashListACC"
                       style="width: 100%" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <input data-role="combobox"
                       data-placeholder="@Html.Raw(Language.Key_VyberteInspektora)"
                       data-filter="contains"
                       data-suggest="true"
                       data-value-primitive="true"
                       data-auto-bind="false"
                       data-text-field="UserLastName"
                       data-value-field="IDUser"
                       data-bind="value: iDUser,
                              source: vw_Users,
                              events: { change: userOnChange }"
                       style="width: 100%" />
            </td>
            <td></td>
        </tr>
        <tr data-bind="visible: visiblefor2">
            <td colspan="2">
                <input type="text" class="k-textbox" style="width: 100%;" placeholder="ACC" data-bind="value: aCC" />
            </td>
            <td></td>
        </tr>
        <tr data-bind="visible: visiblefor2">
            <td colspan="2">
                <input data-role="datepicker" style="width: 100%;" placeholder="Datum platby" data-bind="value: paymentDate" />
            </td>
            <td></td>
        </tr>
        <tr data-bind="visible: visiblefor2">
            <td colspan="2">
                <input type="text" class="k-textbox" style="width: 100%;" placeholder="Jméno dlužníka" data-bind="value: persName" />
            </td>
            <td></td>
        </tr>
        <tr data-bind="visible: visiblefor2">
            <td colspan="2">
                <input type="text" class="k-textbox" style="width: 100%;" placeholder="Příjmení dlužníka" data-bind="value: persSurname" />
            </td>
            <td></td>
        </tr>
        <tr data-bind="visible: visiblefor2">
            <td colspan="2">
                <input data-role="combobox"
                       data-placeholder="Věřitel"
                       data-filter="contains"
                       data-suggest="true"
                       data-value-primitive="true"
                       data-text-field="CreditorAlias"
                       data-value-field="CreditorAlias"
                       data-bind="value: creditorAlias,
                              source: sp_Get_CreditorsCombo"
                       style="width: 100%" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <input data-role="combobox"
                       data-placeholder="@Html.Raw(Language.Key_VyberteTypOdmeny)"
                       data-filter="contains"
                       data-suggest="true"
                       data-value-primitive="true"
                       data-auto-bind="false"
                       data-text-field="Val"
                       data-value-field="IDOrder"
                       data-bind="value: rr_TypeFee,
                              source: tblRegisterRestrictions }"
                       style="width: 100%" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <input type="text" class="k-textbox" style="width: 100%;" onclick="$(this).select();" data-bind="value: fee, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.SVValidateFeeAddPLH2)" />
            </td>
            <td>
                <input type="checkbox" class="k-checkbox" id="SVValidateFeeAdd_checkbox" data-bind="checked: sVApproved"><label class="k-checkbox-label" for="SVValidateFeeAdd_checkbox">@Html.Raw(Language.SVValidateFeeAddTXT1)</label>
            </td>
        </tr>
    </table>

    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="events: { click: Save }">@Language.btnSave</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>

<script>

    function SVValidateFeeAdd(callback) {
        var win;
        var model = new kendo.observable({
            types: 1,
            visiblefor1: function (e) {
                var t = this.get("types");
                if (t == 1) {
                    return true;
                }
                return false;
            },
            visiblefor2: function (e) {
                var t = this.get("types");
                if (t == 2) {
                    return true;
                }
                return false;
            },
            iDUser: null,
            iDSpisu: null,
            rr_TypeFee: null,
            fee: null,
            sVApproved: false,
            aCC: null,
            paymentDate: null,
            persSurname: null,
            persName: null,
            creditorAlias: null,
            vw_Users: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDUser"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("vw_Users", "Api/AdminService")",
                        dataType: "json",
                    }
                }
            }),
            userOnChange: function (e) {
                this.sp_Get_SV_CashListACC.read();
            },
            sp_Get_SV_CashListACC: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDSpisu"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_SV_CashListACC", "Api/AdminService")",
                        dataType: "json",
                    },
                    parameterMap: function (data, type) {
                        if (type == "read") {
                            var ID = model.get("iDUser");
                            if (!ID) { ID = 0 };
                            return { ID: kendo.stringify(ID) };
                        }
                    }
                }
            }),
            accOnChange: function (e) {

            },
            tblRegisterRestrictions: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDOrder"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("tblRegisterRestrictions", "Api/AdminService")" + "?Register=rr_TypeFee",
                        dataType: "json",
                    }
                }
            }),
            typeOnChange: function (e) {

            },
            sp_Get_CreditorsCombo: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDCreditor"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_CreditorsCombo", "Api/AdminService")",
                        dataType: "json",
                    }
                }
            }),
            numberValue: function (e) {
                var temp = e.currentTarget.value;
                var count = (temp.match(/,/g) || []).length;
                return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57) || e.which === 110) ? (e.which === 44 && count === 0 ? true : false) : true;
            },
            Save: function (e) {
                var type = this.get("types");
                if (type == 1) {
                    if (!$.isNumeric(this.iDSpisu)) {
                        message("  Vyberte spis", "info")
                        return;
                    }
                } else {
                    this.iDSpisu = 0;

                    if (!$.trim(this.aCC)) {
                        message("  Zadejte ACC", "info")
                        return;
                    }

                    this.paymentDate = kendo.toString(new Date(this.paymentDate), "yyyy-MM-ddTHH:mm:ss")

                    //if (!$.trim(this.paymentDate)) {
                    //    message("  Zadejte Datum platby", "info")
                    //    return;
                    //}

                    //if (!$.trim(this.persSurname)) {
                    //    message("  Zadejte příjmení", "info")
                    //    return;
                    //}

                    //if (!$.trim(this.persName)) {
                    //    message("  Zadejte jméno", "info")
                    //    return;
                    //}

                    if (!$.trim(this.creditorAlias)) {
                        message("  Zadejte věřitele", "info")
                        return;
                    }
                }

                if (!$.isNumeric(this.iDUser)) {
                    message("  Vyberte inspektora", "info")
                    return;
                }

                if (!$.isNumeric(this.rr_TypeFee)) {
                    message("  Vyberte typ odměny", "info")
                    return;
                }

                if (!$.trim(this.fee)) {
                    message("  Zadejte částku", "info")
                    return;
                }

                $.get("@Url.Action("sp_Do_SV_AddFee", "Api/AdminService")", {
                    iDUser: this.iDUser,
                    iDSpisu: this.iDSpisu,
                    rr_TypeFee: this.rr_TypeFee,
                    fee: this.fee,
                    sVApproved: this.sVApproved,
                    aCC: this.aCC,
                    paymentDate: this.paymentDate,
                    persSurname: this.persSurname,
                    persName: this.persName,
                    creditorAlias: this.creditorAlias,
                }, function (result) {
                    win.close();
                    callback(true)
                })
            },
            Storno: function (e) {
                win.close();
                callback(false)
            }
        });
        kendo.bind($("#SVValidateFeeAdd"), model);
        win = $("#SVValidateFeeAdd").data("kendoWindow");
        win.open().center();
    };
</script>