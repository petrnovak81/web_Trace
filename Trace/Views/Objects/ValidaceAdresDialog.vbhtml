<div id="ValidaceAdresDialog" 
    data-role="window"
    data-title="@Html.Raw(Language.Key_ValidaceAdres)"
    data-width="1024"
    data-modal="true"
    data-resizable="true"
    data-bind="events: { close: Close }"
    data-actions="['maximize', 'close']"
    style="display: none;">
    <div style="height:400px"
            data-role="grid"
            data-resizable="true"
            data-detail-template="valAdrTmp"
            data-columns="[
            { 'field': 'PersTypeTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersTypeTxt)'), 'template': '#=CellString(PersTypeTxt)#' },
            { 'field': 'PersSurname', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonSurname)'), 'template': '#=CellString(PersSurname)#' },
            { 'field': 'PersName', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonName)'), 'template': '#=CellString(PersName)#' },
            { 'field': 'PersSurname2', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonSurname2)'), 'template': '#=CellString(PersSurname2)#' },
            { 'field': 'PersRC', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonRC)'), 'template': '#=CellRC(PersRC)#' },
            { 'field': 'PersIC', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonIC)'), 'template': '#=CellString(PersIC)#' },
            { 'field': 'PersBirthDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonBirthDate)'), 'template': '#=CellDate(PersBirthDate)#' },
            ]"
            data-bind="source: Osoby, events: { detailInit: Detail_init }">
        </div>
        <script id="valAdrTmp" type="text/html">
            <table>
                <tr>
                    <td style="width: 70%; overflow-x: auto; vertical-align: top;">
                        <div style="width: 100%"
                            data-role="grid"
                            data-sortable="false"
                            data-resizable="true"
                            data-columns="[
            { 'field': 'PersCity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonCity)'), 'template': '\\#=CellString(PersCity)\\#', 'width': 100 },
            { 'field': 'PersHouseNum', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonHouseNum)'), 'template': '\\#=CellString(PersHouseNum)\\#', 'width': 50 },
            { 'field': 'PersStreet', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonStreet)'), 'template': '\\#=CellString(PersStreet)\\#', 'width': 100 },
            { 'field': 'PersZipCode', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonZipCode)'), 'template': '\\#=CellZip(PersZipCode)\\#', 'width': 50 },
            { 'field': 'PersAddressVisited', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonVisited)'), 'template': '\\#=_PersAddressVisited()\\#', 'width': 30 },
            { 'field': 'PersMainAddress', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersMainAddress)'), 'template': '\\#=_PersMainAddress(PersMainAddress, IDSpisyOsobyAdresy)\\#', width: 30 },
            { 'field': 'PersAddressForItinerary', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersAddressForItinerary)'), 'template': '\\#=_PersAddressForItinerary(PersAddressForItinerary, IDSpisyOsobyAdresy)\\#', width: 30 },
            { 'field': 'rr_AddressValidity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_rr_AddressValidity)'), 'template': '\\#=_AddressValidityTxt(IDSpisyOsobyAdresy)\\#', 'width': 100 },
            { 'field': 'rr_AddressType', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonAddressType)'), 'template': '\\#=_AddressTypeTxt(IDSpisyOsobyAdresy)\\#', 'width': 100 }
            ]"
                            data-bind="source: Address">
                        </div>
                    </td>
                    <td style="overflow-x: auto; vertical-align: top;">
                        <div style="width: 100%;"
                            data-role="grid"
                            data-resizable="true"
                            data-columns="[
            { 'field': 'PersEmail', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonEmail)'), 'template': '\\#=CellEmail(PersEmail)\\#' },
            { 'field': 'PersEmailValid', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonEmailValid)'), 'template': '\\#=_PersEmailValid(IDSpisyOsobyEmail)\\#', 'width': 30 }
            ]"
                            data-bind="source: Email">
                        </div>
                        <div style="width: 100%;"
                            data-role="grid"
                            data-resizable="true"
                            data-columns="[
            { 'field': 'PersPhone', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonPhone)'), 'template': '\\#=CellPhone(PersPhone)\\#'},
            { 'field': 'rr_PhoneValidity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonPhoneValid)'), 'template': '\\#=_PhoneValidity(IDSpisyOsobyPhone)\\#', 'width': 100 }
            ]"
                            data-bind="source: Phone">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        # if(rr_PersType === 1) { #
                        <div style="width: 100%;"
                data-role="grid"
                data-resizable="true"
                data-columns="[
            { 'field': 'EmployerName', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerName)'), 'template': '\\#=CellString(EmployerName)\\#', 'width': 100  },
            { 'field': 'EmployerIC', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerIC)'), 'template': '\\#=CellString(EmployerIC)\\#', 'width': 100  },
            { 'field': 'EmployerCity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerCity)'), 'template': '\\#=CellString(EmployerCity)\\#', 'width': 100 },
            { 'field': 'EmployerHouseNum', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerHouseNum)'), 'template': '\\#=CellString(EmployerHouseNum)\\#', 'width': 100 },
            { 'field': 'EmployerStreet', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerStreet)'), 'template': '\\#=CellString(EmployerStreet)\\#', 'width': 100 },
            { 'field': 'EmployerZipCode', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerZipCode)'), 'template': '\\#=CellZip(EmployerZipCode)\\#', 'width': 100 },
            @*{ 'field': 'EmployerType', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerType)'), 'template': '\\#=CellString(EmployerType)\\#', 'width': 100 },*@
            { 'field': 'rr_AddressValidity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerAddressValidity)'), 'template': '\\#=_EMPAddressValidityTxt(IDSpisyOsobyZam)\\#', 'width': 100 },
            { 'field': 'EmployerContactSurname', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerContactSurname)'), 'template': '\\#=CellString(EmployerContactSurname)\\#', 'width': 100 },
            { 'field': 'EmployerContactName', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerContactName)'), 'template': '\\#=CellString(EmployerContactName)\\#', 'width': 100 },
            { 'field': 'EmployerContactEmail', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerContactEmail)'), 'template': '\\#=CellEmail(EmployerContactEmail)\\#', 'width': 100 },
            { 'field': 'EmployerContactPhone', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerContactPhone)'), 'template': '\\#=CellPhone(EmployerContactPhone)\\#', 'width': 100 }
            ]"
                data-bind="source: OsobyZam">
                        </div>
                        # } #
                    </td>
                </tr>
            </table>
        </script>
    <div data-bind="visible: btnNewAddressVisibility">
        <h4>@Html.Raw(Language.ValidaceAdresDialogTXT1)</h4>
        <input type="text" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.ValidaceAdresDialogPLH5)" data-bind="value: Comment" />
    </div>
    <div class="window-footer">
        <button type="button" data-type="1" class="k-button" data-bind="events: { click: newAddEmployer }">@Html.Raw(Language.Key_KontaktNaZamestnavateleDl)</button>
        <button type="button" data-type="1" class="k-button" data-bind="visible: btnNewAddressVisibility, events: { click: newAddressWin }">@Html.Raw(Language.ValidaceAdresDialogTXT2)</button>
        <button type="button" data-type="2" class="k-button" data-bind="visible: btnNewAddressVisibility, events: { click: newAddressWin }">@Html.Raw(Language.ValidaceAdresDialogTXT3)</button>
        <button type="button" data-type="3" class="k-button" data-bind="visible: btnNewAddressVisibility, events: { click: newAddressWin }">@Html.Raw(Language.ValidaceAdresDialogTXT4)</button>
        <button type="button" class="k-primary k-button" data-bind="events: { click: Ok }">@Language.btnOk</button>
    </div>
</div>

<script>
    function _PersMainAddress(val, id) {
        var uid = uniq() + id;
        return "<input type='radio' " + (val ? "checked" : "") + " data-id='" + id + "' data-name='PersMainAddress' name='PersMainAddress' data-bind='events: { change: sp_Do_ChangeAddrMain }' id='r-" + uid + "' class='k-radio'><label class='k-radio-label' for='r-" + uid + "'></label>";
    }

    function _PersAddressForItinerary(val, id) {
        var uid = uniq() + id;
        return "<input disabled type='radio' " + (val ? "checked" : "") + " data-id='" + id + "' data-name='PersAddressForItinerary' name='PersAddressForItinerary' id='r-" + uid + "' class='k-radio'><label class='k-radio-label' for='r-" + uid + "'></label>";
    }

    function _PersAddressVisited() {
        var uid = uniq() + 3;
        return "<input type='checkbox' disabled data-bind='checked: PersAddressVisited' id='ch-" + uid + "' class='k-checkbox'><label class='k-checkbox-label' for='ch-" + uid + "'></label>";
    }
    
    function _AddressValidityTxt(id) {
        return $('<div><select style="width:100%;" data-id="' + id + '" data-name="rr_AddressValidity" data-role="dropdownlist" data-text-field="Val" data-value-field="IDOrder" data-bind="value: rr_AddressValidity, source: AddressValidity, events: { change: sp_Do_ChangeAddrValidity }"></select></div>').html();
    }

    function _AddressTypeTxt(id) {
        return $('<div><select style="width:100%;" data-id="' + id + '" data-name="rr_AddressType" data-role="dropdownlist" data-text-field="Val" data-value-field="IDOrder" data-bind="value: rr_AddressType, source: AddressType, events: { change: sp_Do_ChangeAddrType }"></select></div>').html();
    }

    function _PersEmailValid(id) {
        var uid = uniq() + id;
        return "<input type='checkbox' data-id='" + id + "' data-name='PersEmailValid' data-bind='checked: PersEmailValid, events: { change: sp_Do_ChangeMailValidity }' id='ch-" + uid + "' class='k-checkbox'><label class='k-checkbox-label' for='ch-" + uid + "'></label>";
    }

    function _PhoneValidity(id) {
        return $('<div><select style="width:100%;" data-id="' + id + '" data-name="rr_PhoneValidity" data-role="dropdownlist" data-text-field="Val" data-value-field="IDOrder" data-bind="value: rr_PhoneValidity, source: PhoneValidity, events: { change: sp_Do_ChangePhoneValidity }"></select></div>').html();
    }

    function _EMPAddressValidityTxt(id) {
        return $('<div><select style="width:100%;" data-id="' + id + '" data-name="rr_AddressValidity" data-role="dropdownlist" data-text-field="Val" data-value-field="IDOrder" data-bind="value: rr_AddressValidity, source: AddressValidity, events: { change: sp_Do_ChangeEmployerValidity }"></select></div>').html();
    }

    function ValidaceAdresDialog(iDSpisu, newAddress, callback) {
        var win;
        var model = new kendo.observable({
            Osoby: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDSpisyOsoby"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_FVOsoby", "Api/Service")",
                        dataType: "json",
                    },
                    parameterMap: function (options, type) {
                        return { iDSpisu: iDSpisu };
                    }
                }
            }),
            Detail_init: function (e) {
                var grid = e.sender;
                var di = grid.dataItem(e.masterRow);
                var model = kendo.observable({
                    Address: new kendo.data.DataSource({
                        schema: {
                            total: "Total",
                            data: "Data",
                            model: {
                                id: "IDSpisyOsobyAdresy"
                            }
                        },
                        transport: {
                            read: {
                                url: "@Url.Action("sp_Get_FVOsobyAddress", "Api/Service")",
                                dataType: "json",
                            },
                            parameterMap: function (options, type) {
                                return { IDSpisyOsoby: di.IDSpisyOsoby };
                            },
                            //sort: [
                            //    { field: "IDSpisyOsobyAdresy", dir: "asc" },
                            //    { field: "PersMainAddress", dir: "asc" }
                            //]
                        }
                    }),
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
                    AddressType: new kendo.data.DataSource({
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
                    Email: new kendo.data.DataSource({
                        schema: {
                            total: "Total",
                            data: "Data",
                            model: {
                                id: "IDSpisyOsobyEmail"
                            }
                        },
                        transport: {
                            read: {
                                url: "@Url.Action("sp_Get_FVOsobyEmail", "Api/Service")",
                                dataType: "json",
                            },
                            parameterMap: function (options, type) {
                                return { IDSpisyOsoby: di.IDSpisyOsoby };
                            }
                        }
                    }),
                    Phone: new kendo.data.DataSource({
                        schema: {
                            total: "Total",
                            data: "Data",
                            model: {
                                id: "IDSpisyOsobyPhone"
                            }
                        },
                        transport: {
                            read: {
                                url: "@Url.Action("sp_Get_FVOsobyPhone", "Api/Service")",
                                dataType: "json",
                            },
                            parameterMap: function (options, type) {
                                return { IDSpisyOsoby: di.IDSpisyOsoby };
                            }
                        }
                    }),
                    OsobyZam: new kendo.data.DataSource({
                        schema: {
                            total: "Total",
                            data: "Data",
                            model: {
                                id: "IDSpisyOsobyZam"
                            }
                        },
                        transport: {
                            read: {
                                url: "@Url.Action("sp_B3_OsobyZam", "Api/Service")",
                                dataType: "json",
                            },
                            parameterMap: function (options, type) {
                                return { iDSpisyOsoby: di.IDSpisyOsoby };
                            }
                        }
                    }),
                    sp_Do_ChangeAddrForItinerary: function (e) {
                        var id = e.data.IDSpisyOsobyAdresy;
                        $.get("@Url.Action("sp_Do_ChangeAddrForItinerary", "Api/Service")", { tbl: 1, iDAddress: id }, function (result) {
                            //model.Address.read();
                        })
                    },
                    sp_Do_ChangeAddrMain: function (e) {
                        var id = e.data.IDSpisyOsobyAdresy;
                        $.get("@Url.Action("sp_Do_ChangeAddrMain", "Api/Service")", { iDSpisyOsobyAdresy: id }, function (result) {
                            //model.Address.read();
                        })
                    },
                    sp_Do_ChangeAddrType: function (e) {
                        var val = e.data.rr_AddressType;
                        var id = e.data.IDSpisyOsobyAdresy;
                        $.get("@Url.Action("sp_Do_ChangeAddrType", "Api/Service")", { iDSpisyOsobyAdresy: id, rr_AddressType: val }, function (result) {
                            //model.Address.read();
                        })
                    },
                    sp_Do_ChangeAddrValidity: function (e) {
                        var val = e.data.rr_AddressValidity;
                        var id = e.data.IDSpisyOsobyAdresy;
                        $.get("@Url.Action("sp_Do_ChangeAddrValidity", "Api/Service")", { iDSpisyOsobyAdresy: id, rr_AddressValidity: val }, function (result) {
                            //model.Address.read();
                        })
                    },
                    sp_Do_ChangeMailValidity: function (e) {
                        var val = e.data.PersEmailValid;
                        var id = e.data.IDSpisyOsobyEmail;
                        $.get("@Url.Action("sp_Do_ChangeMailValidity", "Api/Service")", { iDSpisyOsobyEmail: id, persEmailValid: val }, function (result) {
                            //model.Email.read();
                        })
                    },
                    sp_Do_ChangePhoneValidity: function (e) {
                        var val = e.data.rr_PhoneValidity;
                        var id = e.data.IDSpisyOsobyPhone;
                        $.get("@Url.Action("sp_Do_ChangePhoneValidity", "Api/Service")", { iDSpisyOsobyPhone: id, rr_PhoneValidity: val }, function (result) {
                            //model.Phone.read();
                        })
                    },
                    sp_Do_ChangeEmployerValidity: function (e) {
                        var val = e.data.rr_AddressValidity;
                        var id = e.data.IDSpisyOsobyZam;
                        $.get("@Url.Action("sp_Do_ChangeEmployerValidity", "Api/Service")", { iDSpisyOsobyZam: id, rr_AddressValidity: val }, function (result) {
                            //model.OsobyZam.read();
                        })
                    }
                })
                kendo.bind($(e.detailCell), model);
            },
            Comment: null,
            btnNewAddressVisibility: newAddress,
            newAddEmployer: function(e) {
                var that = this;
                NewEMPAddress(function (result) {
                    $.get("@Url.Action("sp_Do_AddEmployer", "Api/Service")", {
                        iDSpisu: iDSpisu,
                        employerName: result.employerName, //*
                        employerIC: result.employerIC, //*
                        employerCity: result.employerCity, //*
                        employerHouseNum: result.employerHouseNum, //*
                        employerStreet: result.employerStreet, //*
                        employerZipCode: result.employerZipCode, //*
                        employerType: 2,
                        rr_AddressValidity: result.rr_AddressValidity, //*
                        employerAddrFull: null,
                        employerContactSurname: result.employerContactSurname, //*
                        employerContactName: result.employerContactName, //*
                        employerContactEmail: result.employerContactEmail, //*
                        employerContactPhone: result.employerContactPhone //*
                    }, function (e) {
                        that.Osoby.read();
                    })
                })
            },
            newAddressWin: function (e) { 
                var that = this;
                var type = $(e.target).data("type");
                NewAddress(type, iDSpisu, function (result) {
                    var objname = "";
                    var addr = ((result.street ? result.street : "") + (result.cp ?  " " + result.cp : "") + (result.city ? ", " + result.city : "") + (result.zip ? " " + result.zip : ""));
                    switch (type) {
                        case 1:
                            objname = "object_8a";
                            break;
                        case 2:
                            objname = "object_8b";
                            break;
                        case 3:
                            objname = "object_8c";
                            break;
                    }
                    if (addr && googleIsLoad) {
                        globalValidAddress(addr, function (adr, bol, msg) {
                            if (!bol) {
                                message(msg, "error");
                            }
                            result["GPSLat"] = (adr ? adr.lat : 0);
                            result["GPSLng"] = (adr ? adr.lng : 0);
                            result["GPSValid"] = bol;

                            console.log(result)

                            var model = JSON.stringify({
                                "object":
                                    {
                                        "name": objname,
                                        "source": result,
                                        "ord": "1",
                                        "sub": "0"
                                    }
                            });

                            newAddressWin_save(iDSpisu, model);
                        });
                    } else {
                        result["GPSLat"] = 0;
                        result["GPSLng"] = 0;
                        result["GPSValid"] = false;

                        console.log(result)

                        var model = JSON.stringify({
                            "object":
                                {
                                    "name": objname,
                                    "source": result,
                                    "ord": "1",
                                    "sub": "0"
                                }
                        });

                        newAddressWin_save(iDSpisu, model);
                    }
                    function newAddressWin_save(iDSpisu, model) {
                        $.ajax({
                            url: '@Url.Action("sp_Get_FieldVisitObject", "Api/Service")',
                            type: "GET",
                            dataType: 'json',
                            data: { "iDSpisu": iDSpisu, "model": model, "command": 1, "process": 5 },
                            async: false,
                            cache: false,
                            traditional: true,
                            contentType: 'application/json',
                            success: function (result) {
                                $.get('@Url.Action("sp_Rec_Start8", "Api/Service")', {}, function (result) {
                                    that.Osoby.read()
                                })
                            }
                        });
                    }
                })
            },
            Ok: function (e) {
                if (this.btnNewAddressVisibility) {
                    var c = this.get("Comment");
                    if (c) {
                        //ulozit komentar
                        $.get("@Url.Action("sp_Rec_Object_81_Extra", "Api/Service")", { iDSpisu: iDSpisu, comment: c }, function (result) {

                        })
                    }
                }
                win.close();
                callback(true);
            },
            Close: function (e) {
                callback(true);
            }
        });
        kendo.bind($("#ValidaceAdresDialog"), model);
        win = $("#ValidaceAdresDialog").data("kendoWindow");
        win.open().center();
    };
</script>
