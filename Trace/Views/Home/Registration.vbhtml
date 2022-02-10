@Code
    ViewData("Title") = "Zápis"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div id="osnModel" class="flex-container">
    <div class="flex-body">
        <header>
            @Html.Partial("~/Views/Objects/B3_Detail.vbhtml")
        </header>
        <section
            data-role="splitter"
            class="site-content"
            data-panes="[
        {collapsible: false, scrollable: true, size: '350px', min: '350px'},
        {collapsible: false, min: '450px'}
        ]">
            <div id="osntree" style="overflow-x: hidden;">
                <div id="objects" data-bind="source: objects" data-template="tempform"></div>
                <script id="tempform" type="text/html">
                    <form class="objects-form" disabled data-bind="source: object.source, events: { keypress: formKeyPress }" data-object="#=object.name#" data-template="#=object.name#"></form>
                </script>
            </div>
            <div style="overflow-y: hidden">
                <ul id="spisy" data-role="menu" data-scrollable="true">
                    @Code
                        Using db As New Trace.TRACEEntities
                            Dim IDUser As Integer = ViewBag.IDUser
                            Dim IDSpisu As Integer = ViewData("IDSpisu")
                            Dim IDSpisyOsoby As Integer = ViewData("IDSpisyOsoby")
                            Dim spisy = db.sp_B3_SpisyDluznika(IDSpisyOsoby, IDUser).ToList
                            For Each i In spisy
                        @<li style="text-align: center" title="@(i.CreditorAlias) @(If(i.IDSpisu = IDSpisu, "@Html.Raw(Language.Key_ProbihaZapis)", ""))" class="@(If(i.IDSpisu = IDSpisu, "k-state-selected", ""))">
                            <a href="#" data-id="@i.IDSpisu" data-acc="@i.ACC" data-bind="events: { click: selectFile }">
                                <div class="acc"><b>@i.ACC</b></div>
                                <div class="statetxt">@i.StateTxt</div>
                                @If (i.rr_State > 9 And i.rr_State < 20) Then
                                    @<div class="stateline state-red"></div>
                                        ElseIf (i.rr_State > 29 And i.rr_State < 40) Then
                                    @<div class="stateline state-orange"></div>
                                        ElseIf (i.rr_State > 39 And i.rr_State < 50) Then
                                    @<div class="stateline state-green"></div>
                                        ElseIf (i.rr_State > 49 And i.rr_State < 60) Then
                                    @<div class="stateline state-blue"></div>
                                        ElseIf (i.rr_State > 59) Then
                                    @<div class="stateline state-silver"></div>
                                        Else
                                    @<div class="stateline"></div>
                                        End If
                            </a>
                        </li>
                            Next
                        End Using
                    End Code
                </ul>
                <div id="splitter-center-panels" class="k-scrollable" style="height: calc(100% - 45px);">
                    @Html.Partial("~/Views/Objects/B3_DetailSpisu.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Kontakty.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DoslePlatby.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DalsiOsoby.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Dokumentace.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Historie.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Seznam.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Terminy.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Specifikace.vbhtml")
                </div>
            </div>
        </section>
        <footer class="site-footer">
            <div style="text-align:center;height:0">
                <span class="k-link" data-bind="text: logout"></span>
            </div>
            <button class="k-button k-primary" style="float:left;" data-bind="events: { click: backObject }">@Html.Raw(Language.Key_VratitSeOKrokZpet)</button>
            @*<button class="k-button k-primary" data-bind="events: { click: AddressValid }">Validace kontaktů</button>*@
            <button class="k-button k-primary" data-bind="events: { click: Close }">@Html.Raw(Language.Key_UkoncitZapisBezUlozeni)</button>
        </footer>
    </div>
</div>

    @Html.Partial("~/Views/Objects/OSNWriteObjects.vbhtml")
    @Html.Partial("~/Views/Objects/OSNEntryWin.vbhtml")
    @Html.Partial("~/Views/Objects/TableNextFiles.vbhtml")
    @Html.Partial("~/Views/Objects/B3_OsobyDalsiKontakt_Edit.vbhtml")
    @Html.Partial("~/Views/Objects/ValidaceAdresDialog.vbhtml")
    @Html.Partial("~/Views/Objects/3136_Odlozit.vbhtml")
    @Html.Partial("~/Views/Objects/3136_Uzavrit.vbhtml")
    @Html.Partial("~/Views/Objects/NovyKontakt.vbhtml")
    @Html.Partial("~/Views/Objects/NewAddress.vbhtml")
    @Html.Partial("~/Views/Objects/NewEMPAddress.vbhtml")

<script id="tmpddaddress" type="text/html">
    #=(PersSurname ? PersSurname : '')# 
    #=(PersName ? PersName : '')
    # - #=(PersStreet ? PersStreet : '')# 
    #=(PersHouseNum ? PersHouseNum : '')# 
    #=(PersZipCode ? PersZipCode : '')#
    #=(PersCity ? PersCity : '')# 
</script>

<script id="tmpddosoby" type="text/html">
    #=(PersSurname ? PersSurname : '') + ' ' + (PersName ? PersName : '')#
</script>

<script id="tmpphone" type="text/html">
    #=PersPhone#
</script>

<script id="tmpemail" type="text/html">
    #=PersEmail#
</script>

<script id="tmpcampaign" type="text/html">
    #=kendo.toString(new Date(DeadLine), 'd')# #=CampName#
</script>

<script>
    var vwrr_PersType = [
    @Code
        For Each i In New Trace.TRACEEntities().vwrr_PersType
            @<text>{ text: "@Html.Raw(i.PersTypeTxt)", value: parseInt("@Html.Raw(i.rr_PersType)") },</text>
        Next
    End Code
    ];
    var aCC = parseInt('@ViewData("ACC")');
    var iDSpisu = parseInt('@ViewData("IDSpisu")');
    var iDSpisyOsoby = parseInt('@ViewData("IDSpisyOsoby")');
    var Process = parseInt('@ViewData("Process")');
    var win = null;
    var lat = null;
    var lng = null;
    var guid = uniq();
    var device = 'browser';
    var osnModel = kendo.observable({
        startProcess: function (e) {
            var that = this;
            if (googleIsLoad) {
                getCurrentPosition(function (result) {
                    if (result) {
                        var loc = result.loc.replace(" ", "");
                        var latlng = loc.split(",");
                        e.data["Date"] = kendo.toString(new Date(), "d");
                        e.data["GPSLat"] = parseFloat(latlng[0]);
                        e.data["GPSLng"] = parseFloat(latlng[1]);
                        that.buttonaction(e);
                    } else {
                        e.data["Date"] = kendo.toString(new Date(), "d");
                        e.data["GPSLat"] = 0;
                        e.data["GPSLng"] = 0;
                        that.buttonaction(e);
                    }
                })
            } else {
                e.data["Date"] = kendo.toString(new Date(), "d");
                e.data["GPSLat"] = 0;
                e.data["GPSLng"] = 0;
                that.buttonaction(e);
            }
        },
        objects: new kendo.data.DataSource({
            schema: {
                model: {
                    id: "object.name"
                }
            },
            data: []
        }),
        vwrr_PersType: new kendo.data.DataSource({
            schema: {
                data: "Data",
                model: {
                    id: "rr_PersTypeMini"
                }
            },
            transport: {
                read: {
                    url: "@Url.Action("vwrr_PersTypeMini", "Api/Service")",
                    dataType: "json"
                }
            }
        }),
        rr_Currency: new kendo.data.DataSource({
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
                    return { Register: "rr_Currency" };
                }
            }
        }),
        rr_CurrencyDataBound: function (e) {
            if (!e.sender.value()) {
                e.sender.value("CZK");
                $(e.sender.element).data("kendoDropDownList").trigger("change");
            }
        },
        sp_Get_FVAllEmailsOfCase: new kendo.data.DataSource({
            schema: {
                total: "Total",
                data: "Data",
                model: {
                    id: "ID"
                }
            },
            transport: {
                read: {
                    url: "@Url.Action("sp_Get_FVAllEmailsOfCase", "Api/Service")",
                    dataType: "json",
                },
                parameterMap: function (options, type) {
                    return { iDSpisu: iDSpisu };
                }
            }
        }),
        sp_Get_FVAllPhonesOfCase: new kendo.data.DataSource({
            schema: {
                total: "Total",
                data: "Data",
                model: {
                    id: "ID"
                }
            },
            transport: {
                read: {
                    url: "@Url.Action("sp_Get_FVAllPhonesOfCase", "Api/Service")",
                    dataType: "json",
                },
                parameterMap: function (options, type) {
                    return { iDSpisu: iDSpisu };
                }
            }
        }),
        winNovyKontakt: function (e) {
            var that = this;
            newContact(iDSpisu, function (select, tel, email) {
                var source = {
                    object: {
                        name: "object_52",
                        source: {
                            select0: select,
                            textbox0: tel,
                            textbox1: email,
                            result: 1
                        },
                        ord: 0,
                        sub: 0
                    }
                }

                sp_Get_FieldVisitObject(source, 1, false, function () {
                    $.get("@Url.Action("sp_Rec_Start52_Extra", "Api/Service")", {}, function (result) {
                        that.sp_Get_FVAllPhonesOfCase.read();
                        that.sp_Get_FVAllEmailsOfCase.read();
                    });
                });
            })
        },
        sp_Rec_Object_54_1_Extra: function (e) {
            var that = this;
            var target = $(e.target);
            var form = target.closest("form");
            var object = form.data("object");
            var dataItem = that.objects.get(object);
            var source = dataItem.object.source;
            var validator = form.kendoValidator().data("kendoValidator");
            if (validator.validate()) {
                var params = {
                    iDSpisu: iDSpisu,
                    dateNextPayment: kendo.toString(source.datepicker0, "yyyy-MM-dd 00:00:00"),
                    rEM_Comment: source.textbox1,
                    reminderSubject: source.textbox0,
                    iDSpisyOsoby: iDSpisyOsoby
                }
                $.get("@Url.Action("sp_Rec_Object_54_1_Extra", "Api/Service")", params, function (result) {
                    that.buttonaction(e);
                })
            }
        },
        obj2_Address: new kendo.data.DataSource({
            schema: {
                data: "Data",
                model: {
                    id: "IDSpisyOsobyAdresy"
                }
            },
            transport: {
                read: {
                    url: "@Url.Action("sp_Get2_Addresses", "Api/Service")?iDspisu=" + iDSpisu,
                    dataType: "json"
                }
            }
        }),
        obj2_Address_change: function (e) {
            var val = $(e.sender.element).data("kendoDropDownList").value();
            var obj = $(e.sender.element).closest("form").data("object");
            var oi = this.objects.get(obj);
            var di = this.obj2_Address.get(val);
            oi.object.source.set("stav", 2);
            oi.object.source.set("textbox0", di.PersStreet + " " + di.PersHouseNum + ", " + di.PersZipCode + " " + di.PersCity);
            //oi.object.source.set("textbox1", di.PersHouseNum);
            //oi.object.source.set("textbox2", di.PersCity);
            //oi.object.source.set("textbox3", di.PersZipCode);
        },
        vw_Campaign: new kendo.data.DataSource({
            schema: {
                data: "Data",
                model: {
                    id: "IDCampaign"
                }
            },
            transport: {
                read: {
                    url: "@Url.Action("vw_Campaign", "Api/Service")?iDspisu=" + iDSpisu,
                    dataType: "json"
                }
            }
        }),
        vw_Campaign_change: function (e) {
            var d = new Date(e.sender.value());
            var f = $(e.sender.element).closest("form");
            var object = f.data("object");
            var s = this.objects.get(object);
            s.object.source.set("datepicker0", kendo.toString(d, "yyyy-MM-dd"));

            var select = s.object.source.select1;
            s.object.source.set("textbox0", select.CampName);
        },
        obj3136_Odlozit: function (e) {
            var that = this;
            $.get("@Url.Action("sp_Get_AllAddressOfDebitor", "Api/Service")", { iDSpisu: iDSpisu }, function (result) {
                //POZOR: Nebyla provedena 2. osobní návštěva!
                var warning = "";
                var dod = "";
                if (Process === 1) { //OSN
                    result.CountOfFV++;
                }
                if (Process === 2) { //telefon
                    dod = "Telefonní kontakt s dlužníkem nenahrazuje povinnost provést návštěvu.";
                }
                if (Process === 3) { //email
                    dod = "Mailový kontakt s dlužníkem nenahrazuje povinnost provést návštěvu.";
                }
                if (result.CountOfFV === 0) { //neni true
                    warning = "POZOR: Nebyla provedena 1. osobní návštěva! " + dod;
                } else {
                    warning = "POZOR: Nebyla provedena 2. osobní návštěva! " + dod;
                }
                if (result.Total > 0 || result.CountOfFV === 0) {
                    OdlozitKeZpracovani(result.Data, warning, function (yesNo) {
                        if (yesNo) {
                            $(e.currentTarget).data("action", 4); //3136.2
                            that.buttonaction(e);
                        } else {
                            $(e.currentTarget).data("action", 5); //3136.1
                            that.buttonaction(e);
                        }
                    });
                } else {
                    that.buttonaction(e);
                }
            });
        },
        obj3136_Uzavrit: function (e) {
            var that = this;
            $.get("@Url.Action("sp_Get_AllAddressOfDebitor", "Api/Service")", { iDSpisu: iDSpisu }, function (result) {
                //POZOR: Nebyla provedena 2. osobní návštěva!
                var warning = "";
                var dod = "";
                if (Process === 1) { //OSN
                    result.CountOfFV++;
                }
                if (Process === 2) { //telefon
                    dod = "Telefonní kontakt s dlužníkem nenahrazuje povinnost provést návštěvu.";
                }
                if (Process === 3) { //email
                    dod = "Mailový kontakt s dlužníkem nenahrazuje povinnost provést návštěvu.";
                }
                if (result.CountOfFV === 0) { //neni true
                    warning = "POZOR: Nebyla provedena 1. osobní návštěva! " + dod;
                } else {
                    warning = "POZOR: Nebyla provedena 2. osobní návštěva! " + dod;
                }
                if (result.Total > 0 || result.CountOfFV === 0) {
                    UzavritSpis(result.Data, warning, function (yesNo) {
                        if (yesNo) {
                            $(e.currentTarget).data("action", 6); //3136.3
                            that.buttonaction(e);
                        } else {
                            //$(e.currentTarget).data("action", 5); //3136.1
                            //that.buttonaction(e);
                            var last = $("#objects form:last-child"); //3136
                            last.find('input[type="radio"]').each(function () {
                                $(this).prop('checked', false);
                            });
                        }
                    });
                } else {
                    that.buttonaction(e);
                }
            });
        },
        maxminValueValidity: function (e) {
            var val = parseInt($(e.target).val());
            if (val === 0) {
                $(e.target).val("").focus();
                return false
            }
            if (e.data.max) {
                var max = parseInt(e.data.max);
                if (val > max) {
                    var msg = $(e.target).data("msgmax");
                    CustomAlert("Upozornění", msg, function () {
                        $(e.target).val("").focus();
                    });
                }
            }
            if (e.data.min) {
                var min = parseInt(e.data.min);
                if (val < min) {
                    var msg = $(e.target).data("msgmin");
                    CustomAlert("Upozornění", msg, function () {
                        $(e.target).val("").focus();
                    });
                }
            }
        },
        numberValue: function (e) {
            return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
        },
        formKeyPress: function (e) {
            if (e.keyCode == 13) {
                return false;
            };
        },
        initFiles: function (e) {
            var dataItem = this.objects.get(e);
            var files = dataItem.object.source.files;
            if (files === undefined) {
                dataItem.object.source.set("files", {});
            };
            if (files) {
                var result = [];
                var items = dataItem.object.source.files.toJSON();
                if ($.isArray(items.file)) {
                    $.each(items.file, function (a, b) {
                        if (b) {
                            result.push({ name: b.name, extension: b.extension, size: b.size });
                        }
                    })
                } else {
                    result.push({ name: items.file.name, extension: items.file.extension, size: items.file.size });
                };
                return JSON.stringify(result);
            } else {
                return "";
            };
        },
        uploadOnError: function (e) {
            console.log(e)
        },
        fileSelect: function (e) {
            if (e.files.length > 6) {
                e.preventDefault();
                CustomAlert("Upozornění", "Maximalní počet souborů je 6", function () { });
            }
        },
        uploadData: function (e) {
            e.data = { IDSpisu: iDSpisu };
        },
        uploadOnSuccess: function (e) {
            var file = e.files[0];
            var fullPath = e.response.fullPath;
            var object = e.response.object;
            var dataItem = this.objects.get(object);
            var files = dataItem.object.source.get("files");
            var uid = file.uid.replace(/\-/g, '');

            file["fullPath"] = fullPath;
            file["Date"] = kendo.toString(new Date(), "d");
            file["GPSLat"] = lat;
            file["GPSLng"] = lng;

            if (e.operation === "upload") {
                dataItem.object.source.files.set("file" + uid, file);
            }

            if (e.operation === "remove") {
                var items = dataItem.object.source.files.toJSON();
                if ($.isArray(items.file)) {
                    var removed = items.file.filter(function (i) {
                        return i.name !== file.name;
                    });
                    dataItem.object.source.files.set("file", removed);
                } else {
                    $.each(items, function (a, b) {
                        if (b.name === file.name) {
                            delete items[a];
                            return true;
                        };
                    })
                    dataItem.object.source.set("files", items);
                }
            }
        },
        today: new Date(),
        dateChange: function (e) {
            if (e.data.maxdate) {
                try {
                    var max = new Date(e.data.maxdate);
                    var val = new Date(e.sender.value());
                    var diff = new Date(max - val);
                    var days = diff / 1000 / 60 / 60 / 24;
                    if (days < 0) {
                        message("Vyplněné datum přesahuje maximální povolenou hodnotu (" + kendo.toString(max, "d") + ").", "error")
                    }
                } catch (ex) { }
            }
            var object = $(e.sender.element).closest("form").data("object");
            var dataItem = this.objects.get(object);
            var obj = dataItem.object.source;
            $.each(obj, function (key, element) {
                if (key.indexOf("datepicker") != -1) {
                    obj[key] = kendo.toString(obj[key], "yyyy-MM-dd HH:mm:ss");
                }
            });
        },
        zrusitsk: function (e) {
            message("SK byl zrušen", "info");
        },
        backObject: function (e) {
            var total = $("#objects form").length;
            var obj0 = this.objects.get("object_0");

            if (obj0) {
                if (total === 2) return false;
            } else {
                if (total === 1) return false;
            }

            var last = $("#objects form:last-child");
            var form = last.prev();

            var item = this.objects.get(last.data("object"));
            this.objects.remove(item);

            form.find('*').removeAttr('disabled', 'disabled');
            var ddls = form.find('[data-role="dropdownlist"]');
            $.each(ddls, function () {
                var ddl = $(this).data("kendoDropDownList");
                ddl.enable(true);
            });
            var dtps = form.find('[data-role="datepicker"]');
            $.each(dtps, function () {
                var dtp = $(this).data("kendoDatePicker");
                dtp.enable(true);
            });
            var nums = form.find('[data-role="numerictextbox"]');
            $.each(nums, function () {
                var num = $(this).data("kendoNumericTextbox");
                num.enable(true);
            });
            var upls = form.find('[data-role="upload"]');
            $.each(upls, function () {
                var upl = $(this).data("kendoUpload");
                upl.enable(true);
            });

            form.find('input[type="radio"]').each(function () {
                $(this).prop('checked', false);
            });

            //console.log(this.objects.data())
        },
        buttonaction: function (e) {
            var that = this;
            var target = null
            if (e.target) {
                target = $(e.target);
            } else {
                target = $(e.sender.element);
            }
            var form = target.closest("form");
            if (target) {
                var action = target.data("action");
                var nameact = target.data("nameact");
                var object = form.data("object");
                var dataItem = that.objects.get(object);
                var valid = target.data("valid");
                try {
                    if (valid === true || valid === undefined) {
                        var validator = form.kendoValidator().data("kendoValidator");
                        if (validator.validate()) {
                            var all = form.nextAll();
                            all.each(function (i, element) {
                                var o = $(element).data("object");
                                var di = osnModel.objects.get(o);
                                osnModel.objects.remove(di);
                            });

                            dataItem.object.source[nameact] = action;
                            sp_Get_FieldVisitObject(dataItem, 1, true, function () {
                                form.find('*').attr('disabled', 'disabled');
                                var ddls = form.find('[data-role="dropdownlist"]');
                                $.each(ddls, function () {
                                    var ddl = $(this).data("kendoDropDownList");
                                    ddl.enable(false);
                                });
                                var dtps = form.find('[data-role="datepicker"]');
                                $.each(dtps, function () {
                                    var dtp = $(this).data("kendoDatePicker");
                                    dtp.enable(false);
                                });
                                var nums = form.find('[data-role="numerictextbox"]');
                                $.each(nums, function () {
                                    var num = $(this).data("kendoNumericTextbox");
                                    num.enable(false);
                                });
                                var upls = form.find('[data-role="upload"]');
                                $.each(upls, function () {
                                    var upl = $(this).data("kendoUpload");
                                    upl.enable(false);
                                });
                            });
                        } else {
                            message("Vyplňte povinná pole a správný formát polí.", "error")
                        }
                    } else {
                        var all = form.nextAll();
                        all.each(function (i, element) {
                            var o = $(element).data("object");
                            var di = osnModel.objects.get(o);
                            osnModel.objects.remove(di);
                        });
                        
                        dataItem.object.source[nameact] = action;
                        sp_Get_FieldVisitObject(dataItem, 1, true, function () {
                            form.find('*').attr('disabled', 'disabled');
                            var ddls = form.find('[data-role="dropdownlist"]');
                            $.each(ddls, function () {
                                var ddl = $(this).data("kendoDropDownList");
                                ddl.enable(false);
                            });
                            var dtps = form.find('[data-role="datepicker"]');
                            $.each(dtps, function () {
                                var dtp = $(this).data("kendoDatePicker");
                                dtp.enable(false);
                            });
                            var nums = form.find('[data-role="numerictextbox"]');
                            $.each(nums, function () {
                                var num = $(this).data("kendoNumericTextbox");
                                num.enable(false);
                            });
                            var upls = form.find('[data-role="upload"]');
                            $.each(upls, function () {
                                var upl = $(this).data("kendoUpload");
                                upl.enable(false);
                            });
                        });
                    }
                } catch (ex) { };
            }
        },
        object_8a: function (e) {
            var that = this;
            NewAddress(1, 0, function (result) {
                var objname = "object_8a";
                var addr = ((result.street ? result.street : "") + (result.cp ? " " + result.cp : "") + (result.city ? ", " + result.city : "") + (result.zip ? " " + result.zip : ""));
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
                                    "ord": "999", //999 protoze se mazaly vsechny dosud ulozene objekty 
                                    "sub": "0"
                                }
                        });
                        newAddressWin_save(model);
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
                                "ord": "999",
                                "sub": "0"
                            }
                    });

                    newAddressWin_save(model);
                }
                function newAddressWin_save(model) {
                    $.ajax({
                        url: '@Url.Action("sp_Get_FieldVisitObject", "Api/Service")',
                        type: "GET",
                        dataType: 'json',
                        data: { "iDSpisu": iDSpisu, "model": model, "command": 1, "process": 5, "g": guid },
                        async: false,
                        cache: false,
                        traditional: true,
                        contentType: 'application/json',
                        success: function (result) {
                            $.get('@Url.Action("sp_Rec_Start8", "Api/Service")', {}, function (result) {
                                that.B3_Filter(iDSpisu, iDSpisyOsoby);
                            })
                        }
                    });
                };
            })
        },
        modalwin: function (e) {
            var that = this;
            var forobj = $(e.target).closest("form").data("object");
            var modalname = $(e.target).data("modalname");
            var di = osnModel.objects.get(forobj);
            var model = new kendo.observable({
                source: {},
                numberValue: that.numberValue,
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
                obj2_Osoby: new kendo.data.DataSource({
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
                toggle: function (e) {
                    var target = null
                    if (e.target) {
                        target = $(e.target);
                    } else {
                        target = $(e.sender.element);
                    }
                    var options = target.data("toggle");
                    $.each(options.hide, function (i, id) {
                        var element = $("#" + id);
                        element.hide();
                    })
                    $.each(options.show, function (i, id) {
                        var element = $("#" + id);
                        element.slideDown("slow");
                    })
                },
                ord: parseInt(di.object.ord),
                obj_2_1_save: function (e) {
                    var that = this;
                    var form = $("#OSNEntryWin form");
                    var validator = form.kendoValidator().data("kendoValidator")
                    if (validator.validate()) {
                        var source = this.get("source");
                        var addr = (source.textbox2 + " " + source.textbox3 + ", " + source.textbox5 + " " + source.textbox4);
                        if (googleIsLoad) {
                            globalValidAddress(addr, function (adr, bol, msg) {
                                if (!bol) {
                                    message(msg, "error");
                                }
                                source.set("GPSLat", (adr ? adr.lat : 0));
                                source.set("GPSLng", (adr ? adr.lng : 0));
                                source.set("GPSValid", bol);

                                di.object.source.set("textbox0", addr);
                                that.modalSave(e);
                            })
                        } else {
                            source.set("GPSLat", 0);
                            source.set("GPSLng", 0);
                            source.set("GPSValid", false);
                            di.object.source.set("textbox0", addr);
                            that.modalSave(e);
                        }
                    } else {
                        message("Vyplňte povinná pole a správný formát polí.", "error");
                    }
                },
                obj_2_2_save: function (e) {
                    var that = this;
                    var source = this.get("source");
                    var addr = (source.textbox0 + " " + source.textbox1 + ", " + source.textbox2 + " " + source.textbox3);
                    if (googleIsLoad) {
                        globalValidAddress(addr, function (adr, bol, msg) {
                            if (!bol) {
                                message(msg, "error");
                            }
                            source.set("GPSLat", (adr ? adr.lat : 0));
                            source.set("GPSLng", (adr ? adr.lng : 0));
                            source.set("GPSValid", bol);

                            that.modalSave(e);
                        })
                    } else {
                        source.set("GPSLat", 0);
                        source.set("GPSLng", 0);
                        source.set("GPSValid", false);
                        that.modalSave(e);
                    }
                },
                address_3132_3: function (e) {
                    $("#object_3132_4").toggle("slow");
                },
                modalSave: function (e) {
                    var form = $("#OSNEntryWin form");
                    var action = $(e.target).data("action");
                    var nameact = $(e.target).data("nameact");

                    if (modalname === "object_3132_3") {
                        var ch = form.find("#checkbox22").is(':checked');
                        var empn = form.find("#empname_3132_4").val();

                        if (ch && !empn) {
                            message("Vyplňte název zaměstnavatele.", "error");
                            return false;
                        }
                    }

                    var source = { "object": { "name": modalname, "source": this.get("source"), "ord": this.get("ord"), "sub": 1 } };
                    var validator = form.kendoValidator().data("kendoValidator");
                    if (validator.validate()) {
                        source.object.source[nameact] = action;
                        sp_Get_FieldVisitObject(source, 1, false);
                        if (di.object.source.stav) {
                            di.object.source.set("stav", 3);
                        }
                        win.close();
                    } else {
                        message("Vyplňte povinná pole a správný formát polí.", "error");
                    }
                },
                modalStorno: function (e) {
                    win.close()
                }
            });
            $("#OSNEntryWin").html($("#" + modalname).html())
            kendo.bind($("#OSNEntryWin"), model);
            model.bind("change", function (e) {
                var validator = $("form").kendoValidator().data("kendoValidator")
                if (e.action === "itemchange") {
                    validator.validate()
                }
            })
            win = $("#OSNEntryWin").data("kendoWindow");
            win.open().center();
        },
        togglePanel: function (e) {
            var panel = $(e.currentTarget).closest(".panel");
            var toggle = $(e.currentTarget).find(".toggle");
            var panelBody = panel.find(">.panel-body");
            if (panelBody.css("display") === "none") {
                toggle.removeClass("k-i-sort-desc-sm").addClass("k-i-sort-asc-sm");
            } else {
                toggle.removeClass("k-i-sort-asc-sm").addClass("k-i-sort-desc-sm");
            }
            panelBody.slideToggle("slow", function () {
                $(window).resize();
            });
        },
        AddressValid: function (e) {
            var that = this;
            ValidaceAdresDialog(iDSpisu, false, function (result) {
                that.B3_Filter(iDSpisu, iDSpisyOsoby)
            });
        },
        Close: function (e) {
            CustomConfirm("Upozornění", "Máte rozpracován spis. Přesto zavřít?", function (result) {
                if (result) {
                    window.close();
                }
            });
        },
        zpracovaniSpisu: function (e) {
            var action = $(e.target).data("action");
            var forobj = $(e.target).closest("form").data("object");
            var dataItem = this.objects.get(forobj);

            nextFileDialog(iDSpisu, iDSpisyOsoby, "@Html.Raw(Language.Key_NasledujiciCastBudeResitJednotliveSpisyDl_UdajeZap)", function (result) {
                iDSpisu = result.selectedData.IDSpisu;
                aCC = result.selectedData.ACC;

                $("a[data-acc='" + aCC + "']").trigger("click");

                var all = $("#osntree form:last").prevAll();
                var item = {
                    "object": {
                        "name": "object_0",
                        "source": {
                            "acc": "Spis č.: " + aCC
                        },
                        "ord": "1",
                        "sub": "0"
                    }
                };

                osnModel.objects.data([]);
                osnModel.objects.add(item);

                dataItem.object.source["result"] = action;
                sp_Get_FieldVisitObject(dataItem, 6, true);
            });
        },
        nextFile: function (e) {
            $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', { "iDSpisu": iDSpisu, "model": null, "command": 5, "process": Process, "g": guid }, function (result) {
                var msg = result.SumTxt;
                CustomMessage(msg, function (bol) {
                    nextFileDialog(iDSpisu, iDSpisyOsoby, "", function (result) {
                        iDSpisu = result.selectedData.IDSpisu;
                        aCC = result.selectedData.ACC;

                        $("a[data-acc='" + aCC + "']").trigger("click");

                        var all = $("#osntree form:last").prevAll();
                        var item = {
                            "object": {
                                "name": "object_0",
                                "source": {
                                    "acc": "Spis č.: " + aCC
                                },
                                "ord": "1",
                                "sub": "0"
                            }
                        };
                        osnModel.objects.data([]);
                        osnModel.objects.add(item);

                        sp_Get_FieldVisitObject(null, 6, true);
                    });
                });
            });
        },
        endFile: function (e) {
            var that = this;
            $.get("@Url.Action("sp_Get_RFV_NonReported", "Api/Service")", { "iDspisu": iDSpisu, "iDspisyOsoby": iDSpisyOsoby }, function (result) {
                //vic nez 1 znamena ze je tam vic jinchych spisu nez ten ktery budu uzavirat
                if (result.Total > 1) {
                    CustomConfirm("@Html.Raw(Language.Key_NezpracovaneSpisy)", "@Html.Raw(Language.Key_UDluznikaJsouDalsiNezpracovaneSpisy_PrestoUzavritD)", function (result) {
                        if (result) {
                            end();
                        } else {
                            that.nextFile(e);
                        }
                    })
                } else {
                    end();
                }
            })
            function end() {
                $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', { "iDSpisu": iDSpisu, "model": null, "command": 4, "process": Process, "g": guid }, function (result) {
                    var msg = result.SumTxt;
                    CustomMessage(msg, function (bol) {
                        window.close();
                    });
                });
            };
        },
        end: function () {
            var o = this.objects.get("object_36A");
            var m = null;
            if (o) {
                o.object.source["result"] = 0;
                m = o.object.toJSON();
            }
            $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', { "iDSpisu": iDSpisu, "model": m, "command": 4, "process": Process, "g": guid }, function (result) {
                window.close();
            });
        },
        selectFile: function (e) {
            var ul = $(e.currentTarget).closest("ul");
            var id = $(e.currentTarget).data("id");
            ul.find("li").removeClass("k-state-selected");
            $(e.currentTarget).closest("li").addClass("k-state-selected");
            this.B3_Filter(id, iDSpisyOsoby, 0);
        },
        vytvoritPripominku: function (e) {
            var form = $(e.currentTarget).closest("form");
            var validator = form.kendoValidator().data("kendoValidator");
            if (validator.validate()) {
                $.get("@Url.Action("sp_Rec_Object_3137_17_Extra", "Api/Service")", {
                iDSpisu: iDSpisu,
                dateNextPayment: (e.data.datepicker0 ? kendo.toString(e.data.datepicker0, "yyyy-MM-dd 00:00:00") : null),
                rEM_Comment: (e.data.textbox0 ? e.data.textbox0 : null),
                iDSpisyOsoby: iDSpisyOsoby
            }, function (result) {
                message("@Html.Raw(Language.Key_PripominkaUlozena)");
            });
        } else {
                message("@Html.Raw(Language.Key_VyplntePovinnaPoleASpravnyFormatPoli_)", "error")
        }
        },
        Comment: function (e) {
            if (e.data.RecordCommentTxt) {
                CustomMessage(e.data.RecordCommentTxt);
            }
        },
        traceplaneradio: function (e) {
            var radio = $(e.currentTarget);
            var tbl = radio.data("tbl");
            var iDAddress = radio.data("id");
            var iDSpisu = radio.data("spis");
            var addr = (e.data.PersStreet ? e.data.PersStreet : "");
            addr += (e.data.PersHouseNum ? " " + e.data.PersHouseNum : "");
            addr += (e.data.PersCity ? ", " + e.data.PersCity : "");
            addr += (e.data.PersZipCode ? " " + e.data.PersZipCode : "");

            globalValidAddress(addr, function (adr, bol, msg) {
                var GPSLat = 0;
                var GPSLng = 0;
                var GPSValid = false;
                if (!bol) {
                    message(msg, "error");
                } else {
                    GPSLat = (adr ? adr.lat : 0);
                    GPSLng = (adr ? adr.lng : 0);
                    GPSValid = true;
                }

                $.get("@Url.Action("sp_Do_ChangeAddrForItinerary", "Api/Service")", {
                    tbl: tbl,
                    iDAddress: iDAddress,
                    iDSpisu: iDSpisu,
                    GPSLat: GPSLat,
                    GPSLng: GPSLng,
                    GPSValid: GPSValid
                }, function (result) {
                    if (!result.OK) {
                        radio.prop("checked", false);
                        message(result.Msg, "error");
                    }
                });
            });
        },
        B3_Filter: function (iDSpisu, iDSpisyOsoby, iDSpisyOsobyZam) {
            var model = this;
            try {
                var allProcess = [];
                kendo.ui.progress($("#splitter-center-panels"), true);

                $.get('@Url.Action("sp_Get_CreditorDetail_G2", "Api/Service")', { iDSpisu: iDSpisu, zalozka: 'PersonalVisit' }, function (result) {
                    if (result.Data) {
                        var d = result.Data[0];
                        var rm = '@Html.Raw(Language.DifferentCurrencies)';
                        var c = "";
                        if (d.Currency === "XXX") {
                            c = rm;
                        } else {
                            c = kendo.toString(d.SumDebit, "n2") + " " + d.Currency;
                        }
                        d.SumDebit = c;
                        model.set("B3_Detail", d);
                    }
                });

                allProcess.push($.get('@Url.Action("sp_B3_DetailSpisu", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_DetailSpisu", result.Data[0]); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_HistorieDohod", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_HistorieDohod", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_OsobyAddress", "Api/Service")', { iDSpisu: iDSpisu, iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyAddress", result.Data); }
                }))
                allProcess.push($.get('@Url.Action("sp_B3_OsobyEmail", "Api/Service")', { iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyEmail", result.Data); }
                }))
                allProcess.push($.get('@Url.Action("sp_B3_OsobyPhone", "Api/Service")', { iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyPhone", result.Data); }
                }))
                allProcess.push($.get('@Url.Action("sp_B3_HistorieSpisu", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_HistorieSpisu", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_Osoby", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_Osoby", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_OsobyAdresyDalsiOsobyDodelat", "Api/Service")', { iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyAdresyDalsiOsobyDodelat", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_OsobyRole", "Api/Service")', { iDSpisy: iDSpisu, iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyRole", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_OsobyZam", "Api/Service")', { iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyZam", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_PlatbyDoslePo1OSN", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_PlatbyDoslePo1OSN", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_PlatbyDoslePred1OSN", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_PlatbyDoslePred1OSN", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("vw_ListUrgAndRemind", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_Urgency", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_DohodyOUhrade", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_DohodyOUhrade", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_SpisyDluznika", "Api/Service")', { iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                    if (result.Data.length > 0) {
                        model.set("B3_SpisyDluznika", result.Data);
                        model.B3_Detail.set("cnt", result.Data.length);
                        if (result.Data.length < 2) {
                            model.B3_Detail.set("cls", true);
                        } else {
                            model.B3_Detail.set("cls", false);
                        }
                    } else {
                        model.set("B3_SpisyDluznika", []);
                        model.B3_Detail.set("cnt", 1);
                        model.B3_Detail.set("cls", true);
                    }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_Dokumentace", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_Dokumentace", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_TerminyOSN", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_TerminyOSN", result.Data[0]); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_SpecifikaceDluhuFinUdaje", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_SpecifikaceDluhuFinUdaje", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_SpecifikaceDluhuVeritel", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_SpecifikaceDluhuVeritel", result.Data[0]); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_OtherInfo", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    if (result.Data) { model.set("B3_OtherInfo", result.Data); }
                }));
                allProcess.push($.get('@Url.Action("sp_B3_Bonita", "Api/Service")', { iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                    model.set("B3_Bonita", result.Data[0]);
                }));
                allProcess.push($.get('@Url.Action("sp_B3_ListAllFV", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                    model.set("B3_ListAllFV", result.Data);
                }));

                var ds = new kendo.data.DataSource({
                    schema: {
                        data: "Data",
                        total: "Total",
                        model: {
                            id: "IDSpisyOsobyDalsiKontakt",
                            fields: {
                                "rr_PersType": { type: "number" },
                                "NCName": { type: "string" },
                                "NCSurname": { type: "string" },
                                "NCCity": { type: "string" },
                                "NCHouseNum": { type: "string" },
                                "NCStreet": { type: "string" },
                                "NCZipCode": { type: "string" },
                                "NCAddressVisited": { type: "boolean" },
                                "NCAddressForItinerary": { type: "boolean", editable: false },
                                "NCEmail": { type: "string", validation: { email: true } },
                                "NCEmailValid": { type: "boolean" },
                                "NCPhone": { type: "string" },
                                "NCPhoneValid": { type: "boolean" },
                                "NCComment": { type: "string" }
                            }
                        }
                    },
                    transport: {
                        read: {
                            url: '@Url.Action("B3_OsobyDalsiKontakt", "Api/Service")',
                            type: "GET",
                            dataType: "json"
                        },
                        destroy: {
                            url: "@Url.Action("B3_OsobyDalsiKontakt_Destroy", "Api/Service")",
                            type: "POST",
                            dataType: "json"
                        },
                        update: {
                            url: "@Url.Action("B3_OsobyDalsiKontakt_Update", "Api/Service")",
                            type: "POST",
                            dataType: "json"
                        },
                        create: {
                            url: "@Url.Action("B3_OsobyDalsiKontakt_Create", "Api/Service")",
                            type: "POST",
                            dataType: "json"
                        },
                        parameterMap: function (options, type) {
                            var pm = kendo.data.transports.odata.parameterMap(options);
                            pm.IDSpisyOsoby = iDSpisyOsoby
                            return pm;
                        },
                        requestEnd: function (e) {
                            if (e.response) {
                                if (e.response.MsgType === 'error') {
                                    var msg = "<span style='margin-left:6px;'>" + e.response.Msg.join("<br>") + "</span>"
                                    message(msg, e.response.MsgType);
                                }
                            }
                        }
                    }
                });
                model.set("B3_OsobyDalsiKontakt", ds);

                $.when.apply($, allProcess).fail(function () {
                    kendo.ui.progress($("#splitter-center-panels"), false);
                }).done(function () {
                    kendo.ui.progress($("#splitter-center-panels"), false);
                });
            } catch (ex) {
                kendo.ui.progress($("#splitter-center-panels"), false);
            }
        },
        pocetSpisu: 0,
        B3_Osoby_detail_init: function (e) {
            var grid = e.sender;
            var di = grid.dataItem(e.masterRow);
            var model = kendo.observable({
                B3_OsobyAddress: [],
                B3_OsobyEmail: [],
                B3_OsobyPhone: [],
                traceplaneradio: osnModel.traceplaneradio
            })
            kendo.bind($(e.detailCell), model);
            $.get('@Url.Action("sp_B3_OsobyAddress", "Api/Service")', { iDSpisu: di.IDSpisu, iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                if (result.Data) { model.set("B3_OsobyAddress", result.Data); }
            })
            $.get('@Url.Action("sp_B3_OsobyEmail", "Api/Service")', { iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                if (result.Data) { model.set("B3_OsobyEmail", result.Data); }
            })
            $.get('@Url.Action("sp_B3_OsobyPhone", "Api/Service")', { iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                if (result.Data) { model.set("B3_OsobyPhone", result.Data); }
            })
        },
        DocuGetPDF: function (e) {
            kendo.ui.progress($("#splitter-center-pane"), true);
            $.get("@Url.Action("B3_Dokumentace_PDFExist", "Base")", { IDSpisyDocument: e.data.IDSpisyDocument }, function (result) {
                if (result > 0) {
                    window.open('@Url.Action("B3_Dokumentace_GetPDF", "Base")' + '?IDSpisyDocument=' + e.data.IDSpisyDocument, '_blank');
                } else {
                    message("   @Html.Raw(SystemMessages.FileNotFound) ", "info");
                }
                kendo.ui.progress($("#splitter-center-pane"), false);
            })
        },
        docPrint: function (e) {
            var chs = $("#B3_Dokumentace input:checkbox");
            $.each(chs, function (i, el) {
                var is = $(el).prop("checked");
                if (is) {
                    var g = $("#B3_Dokumentace").data("kendoGrid");
                    var r = $(el).closest("tr")
                    var di = g.dataItem(r);
                    $.get("@Url.Action("B3_Dokumentace_PDFExist", "Base")", { IDSpisyDocument: di.IDSpisyDocument }, function (result) {
                        if (result > 0) {
                            var win = window.open('@Url.Action("B3_Dokumentace_GetPDF", "Base")' + '?IDSpisyDocument=' + di.IDSpisyDocument, '_blank');
                            win.print();
                        } else {
                            message("   @Html.Raw(SystemMessages.FileNotFound) ", "info");
                        }
                    });
                }
            })
        },
        docPrintAll: function (e) {
            var chs = $("#B3_Dokumentace input:checkbox");
            $.each(chs, function (i, el) {
                var g = $("#B3_Dokumentace").data("kendoGrid");
                var r = $(el).closest("tr")
                var di = g.dataItem(r);
                $.get("@Url.Action("B3_Dokumentace_PDFExist", "Base")", { IDSpisyDocument: di.IDSpisyDocument }, function (result) {
                    if (result > 0) {
                        var win = window.open('@Url.Action("B3_Dokumentace_GetPDF", "Base")' + '?IDSpisyDocument=' + di.IDSpisyDocument, '_blank');
                            win.print();
                        } else {
                            message("   @Html.Raw(SystemMessages.FileNotFound) ", "info");
                        }
                });
            });
        },
        ACCLink: function (e) {
            var id = e.IDSpisu;
            var state = e.rr_State;
            if (state > 9 && state < 20) {
                return "News?id=" + id;
            } else if (state > 29 && state < 40) {
                return "PersonalVisit?id=" + id;
            } else if (state > 39 && state < 50) {
                return "Agreements?id=" + id;
            } else if (state > 49 && state < 60) {
                return "ToProcess?id=" + id;
            } else {
                return ""
            };
        },
        B3_OsobyDalsiKontakt_Edit: function (e) {
            var data = e.data;
            osobyDalsiKontakt_Edit(data, vwrr_PersType, this.B3_OsobyDalsiKontakt);
        },
        B3_OsobyDalsiKontakt_dataBound: function (e) {
            var toolbar = $(e.sender.element).find(".k-grid-toolbar");
            var parent = this;
            var model = kendo.observable({
                B3_OsobyDalsiKontakt_Edit: function (ev) {
                    var data = parent.B3_OsobyDalsiKontakt.add({});
                    osobyDalsiKontakt_Edit(data, vwrr_PersType, parent.B3_OsobyDalsiKontakt);
                }
            })
            kendo.bind(toolbar, model);
        },
        B3_Bonita: [],
        B3_Detail: [],
        B3_DetailSpisu: [],
        B3_OsobyAddress: [],
        B3_OsobyEmail: [],
        B3_OsobyPhone: [],
        B3_HistorieDohod: [],
        B3_HistorieSpisu: [],
        B3_Osoby: [],
        B3_OsobyAdresyDalsiOsobyDodelat: [],
        B3_OsobyDalsiKontakt: [],
        B3_OsobyZam: [],
        B3_PlatbyDoslePo1OSN: [],
        B3_PlatbyDoslePred1OSN: [],
        B3_DohodyOUhrade: [],
        B3_SpisyDluznika: [],
        B3_Dokumentace: [],
        B3_TerminyOSN: [],
        B3_SpecifikaceDluhuFinUdaje: [],
        B3_SpecifikaceDluhuVeritel: [],
        B3_OsobyRole: [],
        B3_ListAllFV: [],
        B3_OtherInfo: []
    });

        $(function () {
            kendo.bind($("#osnModel"), osnModel);
            osnModel.bind("change", function (e) {
                //$("span.k-tooltip-validation").remove();
                var validator = $("form").kendoValidator().data("kendoValidator")
                if (e.action === "itemchange") {
                    validator.validate()
                }
            })
        @*        var items = [], index = 0;
        $("script[type='text/html']").each(function (a, b) {
            try {
                var o = $($(b).html());
                o.find("a, b, p, span, h1, h2, h3, h4, label, input, select, button").each(function (c, d) {
                    var text = $.trim($(d).html()).replace("&nbsp;", "");
                    var title = $.trim($(d).attr("title"));
                    var placeholder = $.trim($(d).attr("placeholder"));
                    var msg = $.trim($(d).data("msg"));
                    if (text != undefined && text != '') {
                        index += 1
                        var item = {
                            "key": ('@Html.CurAction' + 'TXT' + index),
                            "value": text
                        }
                        items.push(item);
                    }
                    if (title) {
                        index += 1
                        var item = {
                            "key": ('@Html.CurAction' + 'TXT' + index),
                            "value": title
                        }
                        items.push(item);
                    }
                    if (placeholder) {
                        index += 1
                        var item = {
                            "key": ('@Html.CurAction' + 'TXT' + index),
                            "value": placeholder
                        }
                        items.push(item);
                    }
                    if (msg) {
                        index += 1
                        var item = {
                            "key": ('@Html.CurAction' + 'TXT' + index),
                            "value": msg
                        }
                        items.push(item);
                    }
                });
            } catch (ex) { }
        });

        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            url: "@Url.Action("TraceVBHTMLReplaceLanguage", "Base")",
            data: JSON.stringify(items)
        });*@

        @*items = JSON.stringify({ 'items': items });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '@Url.Action("TraceVBHTMLReplaceLanguage", "Base")',
            data: items,
            success: function () {
                
            },
            failure: function (response) {
               
            }
        });*@


        //osnModel.objects.bind("change", function (e) {
        //    if (e.action === "itemchange") {
        //        console.log(e)
        //    }
        //})

        sp_Get_FieldVisitObject(null, 1, true, function () {
            var prev = $('#objects form:last-child').prevAll();
            $.each(prev, function () {
                $(this).find('*').attr('disabled', 'disabled');
                var ddls = $(this).find('[data-role="dropdownlist"]');
                $.each(ddls, function () {
                    var ddl = $(this).data("kendoDropDownList");
                    ddl.enable(false);
                });
                var dtps = $(this).find('[data-role="datepicker"]');
                $.each(dtps, function () {
                    var dtp = $(this).data("kendoDatePicker");
                    dtp.enable(false);
                });
                var nums = $(this).find('[data-role="numerictextbox"]');
                $.each(nums, function () {
                    var num = $(this).data("kendoNumericTextbox");
                    num.enable(false);
                });
                var upls = $(this).find('[data-role="upload"]');
                $.each(upls, function () {
                    var upl = $(this).data("kendoUpload");
                    upl.enable(false);
                });
            });
        });

        //nastaveni sorteni podzalozek
        $("#splitter-center-panels").kendoSortable({
            filter: ">.panel",
            ignore: ".panel-body *",
            cursor: "move",
            connectWith: "#splitter-center-panels",
            placeholder: placeholder,
            hint: hint,
            init: function (element, valueAccessor, allBindingsAccessor, context) {
                //console.log(context)
            }
        });

        osnModel.B3_Filter(iDSpisu, iDSpisyOsoby, 0);
    });

    function placeholder(element) {
        return element.clone().addClass("placeholder");
    }

    function hint(element) {
        return element.clone().addClass("hint")
                    .height(element.height() + 18)
                    .width(element.width());
    }

    function sp_Get_FieldVisitObject(model, cmd, next, callback) {
        try {
            if (model) {
                if (model.uid) {
                    model = JSON.stringify(model.toJSON());
                } else {
                    model = JSON.stringify(model);
                }
            }
            //console.log(model)
            kendo.ui.progress($("#osntree"), true);
            $.ajax({
                url: '@Url.Action("sp_Get_FieldVisitObject", "Api/Service")',
                type: "GET",
                dataType: 'json',
                data: { "iDSpisu": iDSpisu, "model": model, "command": cmd, "process": Process, "g": guid },
                async: false,
                cache: false,
                traditional: true,
                contentType: 'application/json',
                success: function (result) {
                    if (cmd === 1) {
                        if (result.SumTxt) {

                        }
                    }
                    if (osnModel.objects.total() === 0 && result.ACC) {
                        aCC = parseInt(result.ACC);

                        $("a[data-acc='" + aCC + "']").trigger("click");

                        var item = {
                            "object": {
                                "name": "object_0",
                                "source": {
                                    "acc": "Spis č.: " + aCC
                                },
                                "ord": "1",
                                "sub": "0"
                            }
                        };
                        osnModel.objects.add(item);
                    }

                    if (result.Data) {
                        var i = result.Data[0].idz;
                        if (i) {
                            guid = i;
                        }
                    }

                    //if (result.GUID) {
                    //    guid = result.GUID
                    //}

                    if (result.IDSpisu) {
                        iDSpisu = result.IDSpisu;
                    }

                    if (next) {
                        $.each(result.Data, function (i, e) {
                            if (!e.object.source) {
                                e.object.source = {};
                            }
                            osnModel.objects.add(e);
                        });
                        $('#osntree').scrollTop($('#osntree')[0].scrollHeight);
                        $("#objects [data-role='datepicker']").keydown(function (e) {
                            return false;
                        });
                    }

                    kendo.ui.progress($("#osntree"), false);
                    if (callback) {
                        callback()
                    }
                },
                error: function (error) {
                    kendo.ui.progress($("#osntree"), false);
                    console.log(error);
                }
            });
        } catch (ex) {
            kendo.ui.progress($("#osntree"), false);
            console.log(ex.message)
        };
        getCurrentPosition(function (result) {
            if (result) {
                var loc = result.loc.replace(" ", "");
                var latlng = loc.split(",");
                lat = parseFloat(latlng[0]);
                lng = parseFloat(latlng[1]);
            }
        })
    };
</script>
