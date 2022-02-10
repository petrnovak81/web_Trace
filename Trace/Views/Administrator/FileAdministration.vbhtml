@Code
    ViewData("Title") = "Administrace spisů"
    Layout = "~/Views/Shared/_AdminLayout.vbhtml"
End Code

<div id="administration">
    <ul id="filtermenu" data-role="menu" data-open-on-click="true" data-close-on-click="false">
        <li><b>@Html.Raw(Language.FileAdministrationTXT1) </b></li>
        <li>@Html.Raw(Language.FileAdministrationTXT2) <span data-bind="visible: filter1" class="k-icon k-i-filter"></span>
                <ul>
                    <li>
                        <div data-role="treeview"
                            id="stateTree"
                            data-value-field="id"
                            data-text-field="text"
                            data-check-field="checked"
                            data-checkboxes="{ checkChildren: true }"
                            data-bind="source: statesMenu">
                        </div>
                    </li>
                    <li data-bind="events: { click: Stav_filter }" class="k-primary" style="text-align: center"><i class="fa fa-filter"></i>@Html.Raw(Language.FileAdministrationTXT3)</li>
                </ul>
        </li>
        <li>@Html.Raw(Language.FileAdministrationTXT4) <span data-bind="visible: filter2" class="k-icon k-i-filter"></span>
                <ul>
                    <li data-filter="1" data-bind="events: { click: OSN_filter }">@Html.Raw(Language.FileAdministrationTXT5) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="2" data-bind="events: { click: OSN_filter }">@Html.Raw(Language.FileAdministrationTXT6) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="3" data-bind="events: { click: OSN_filter }">@Html.Raw(Language.FileAdministrationTXT7) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="4" data-bind="events: { click: OSN_filter }">@Html.Raw(Language.FileAdministrationTXT8) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                </ul>
        </li>
        <li>@Html.Raw(Language.FileAdministrationTXT9) <span data-bind="visible: filter3" class="k-icon k-i-filter"></span>
                <ul>
                    <li data-filter="1" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT10) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="2" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT11) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="3" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT12) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="4" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT13) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="5" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT14) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="6" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT15) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="7" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT16) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="8" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT9) na dodání materiálů z centrály <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="9" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT18) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="10" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT18) nenapraveno do 5 dnů <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="11" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT20) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="12" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT21) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="13" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT22) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="14" data-bind="events: { click: URG_filter }">@Html.Raw(Language.FileAdministrationTXT9) o nedodání hotovosti na účet věřitele <span class="k-icon k-i-filter" style="display:none;"></span></li>
                </ul>
        </li>
        <li>@Html.Raw(Language.FileAdministrationTXT24) <span data-bind="visible: filter4" class="k-icon k-i-filter"></span>
                <ul>
                    <li data-filter="1" data-bind="events: { click: UZV_filter }">@Html.Raw(Language.FileAdministrationTXT25) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="2" data-bind="events: { click: UZV_filter }">@Html.Raw(Language.FileAdministrationTXT26) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="3" data-bind="events: { click: UZV_filter }">@Html.Raw(Language.FileAdministrationTXT27) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="4" data-bind="events: { click: UZV_filter }">@Html.Raw(Language.FileAdministrationTXT28) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                    <li data-filter="5" data-bind="events: { click: UZV_filter }">@Html.Raw(Language.FileAdministrationTXT29) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                </ul>
        </li>
    </ul>

    <div id="splitter"
        data-role="splitter"
        data-bind="events: { expand: onExpand, collapse: onCollapse, resize: onResize }"
        data-panes="[
     { collapsible: true, min: '300px', scrollable: false, size: '40%' },
     { collapsible: true, min: '400px' },
     { collapsible: true, min: '200px', max: '200px', scrollable: false, resizable: false, size: '200px' }
     ]">
        <div id="splitter-left">
            <!-- left -->
            <ul data-role="menu" data-scrollable="true">
                <li data-bind="selected: Spisy_visible, events: { click: Spisy_select }">@Language.splitterTXT1</li>
                <li data-bind="selected: SpisyDL_visible, events: { click: SpisyDL_select }">@Language.splitterTXT2</li>
                <li style="float: right;" data-bind="events: { click: tableMaximize }">
                    <i class="fa fa-window-maximize" aria-hidden="true"></i>
                </li>
                <li style="float: right;" data-bind="events: { click: clearFilters }">
                    <span class="k-icon k-i-filter-clear"></span>
                    <!-- <i class="fa fa-filter"></i>
                    <i style="position: relative; font-size: 70%; color: red; left: -3px;" class="fa fa-remove"></i> -->
                </li>
            </ul>
            <div data-bind="visible: Spisy_visible" style="height: 100%;">
                @Html.Partial("~/Views/Objects/vwAD_Spisy.vbhtml")
            </div>
            <div data-bind="visible: SpisyDL_visible" style="height: calc(100% - 40px);">
                @Html.Partial("~/Views/Objects/vwAD_SpisyDL.vbhtml")
            </div>
        </div>
        <div id="splitter-middle" style="overflow: hidden;" class="flex-body">
            <!-- middle -->
            <ul data-role="menu">
                <li data-bind="events: { click: collaps_left }"><span id="collapse-left" class="fa fa-arrow-left"></span></li>
                <li data-bind="events: { click: collaps_right }" style="float: right;"><span id="collapse-right" class="fa fa-arrow-right"></span></li>
            </ul>
            @Html.Partial("~/Views/Objects/B3_Detail.vbhtml")
            <div  id="splitter-middle-panels" data-bind="visible: B3_Visible" style="overflow-y: auto">
                @Html.Partial("~/Views/Objects/B3_Urgency.vbhtml")
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
        <div class="actionbuttons" id="splitter-right">
            <!-- right -->
            <ul data-role="menu">
                <li>@Html.Raw(Language.FileAdministrationTXT30)</li>
            </ul>
            <div id="actionbuttons" style="height: 100%; width: 100%; overflow-x: hidden" class="k-scrollable">
                <button data-role="button" data-action="1" data-bind="enabled: btnEnabled.btn38.enabled, events: { click: action }">@Html.Raw(Language.FileAdministrationTXT31)</button>
                <button data-role="button" data-action="2" data-bind="enabled: btnEnabled.btn39.enabled, events: { click: action }">@Html.Raw(Language.FileAdministrationTXT32)</button>
                <button data-role="button" data-action="3" data-bind="enabled: btnEnabled.btn41.enabled, events: { click: action }">@Html.Raw(Language.FileAdministrationTXT33)</button>
                <button data-role="button" data-action="6" data-bind="enabled: btnEnabled.btn39.enabled, events: { click: action }">@Html.Raw(Language.FileAdministrationTXT34)</button>
                <button data-role="button" data-action="4" data-bind="enabled: btnEnabled.btn43.enabled, events: { click: action }">@Html.Raw(Language.FileAdministrationTXT35)</button>
                <button data-role="button" data-action="5" data-bind="enabled: btnEnabled.btn45.enabled, events: { click: action }">@Html.Raw(Language.FileAdministrationTXT36)</button>
                <button data-role="button" data-action="7" data-bind="events: { click: action }">@Html.Raw(Language.FileAdministrationTXT37)</button>
                <a data-role="button" href="@Url.Action("AllCasesFromTRACE", "Administrator")">Stáhnout všechny spisy</a>
                <button data-role="button" data-action="8" data-bind="enabled: btnEnabled.btn49.enabled, events: { click: action }">@Html.Raw(Language.presunDoDohod)</button>
            </div>
        </div>
    </div>
</div>

<!-- Modalni okna -->
@Html.Partial("~/Views/Objects/SVUzavreniSpisu231.vbhtml")
@Html.Partial("~/Views/Objects/SVResPodUzaSpisu232.vbhtml")
@Html.Partial("~/Views/Objects/SVOdmitnutiNovychSpisu.vbhtml")
@Html.Partial("~/Views/Objects/SVZmenaD1MAX.vbhtml")
@Html.Partial("~/Views/Objects/SVZmenaDMAX.vbhtml")
@Html.Partial("~/Views/Objects/SVPotvrditAVratit.vbhtml")
@Html.Partial("~/Views/Objects/SVVytvoreniPripominky.vbhtml")
@Html.Partial("~/Views/Objects/B3_OsobyDalsiKontakt_Edit.vbhtml")
@Html.Partial("~/Views/Objects/ProgressBarDialog.vbhtml")
<!-- konec modalni okna -->

<script>
    var urlID = '@Request.QueryString("id")';

    function gpsMarker(GPSValid, AddrLocalGovernment) {
        if (GPSValid) {
            if (AddrLocalGovernment) {
                return '<a data-bind="events: { click: setGps }" href="#" class="fa fa-map-marker" style="color: #033aff"></a>';
            } else {
                return '<a data-bind="events: { click: setGps }" href="#" class="fa fa-map-marker" style="color: green"></a>';
            }
        } else {
            return '<a data-bind="events: { click: setGps }" href="#" class="fa fa-map-marker" style="color: red"></a>';
        }
    }

    $(function () {
        var defStates = [{
            id: 1, text: "@Html.Raw(Language.Key_Novy)", checked: false, expanded: true, items: [
                { id: 10, text: "@Html.Raw(Language.Key_10_Novy_PredanyZKlc)", checked: false, expanded: true },
                { id: 11, text: "@Html.Raw(Language.Key_11_Novy_NeprijatySpis)", checked: false },
                { id: 12, text: "@Html.Raw(Language.Key_12_Novy_NeprijatyDo2Dnu)", checked: false }
            ]
        }, {
            id: 20, text: "@Html.Raw(Language.Key_20_Odmitnuty_IpOdmitlSpis)", checked: false
        }, {
            id: 3, text: "@Html.Raw(Language.Key_Osn)", expanded: true, items: [
                { id: 30, text: "@Html.Raw(Language.Key_30_Osn_SpisNemaDOsn)", expanded: true },
                { id: 31, text: "@Html.Raw(Language.Key_31_NaplanovaneDatumOsn)", checked: false },
                { id: 32, text: "@Html.Raw(Language.Key_32_NeniDosnAPrekrocenDmax)", checked: false },
                { id: 33, text: "@Html.Raw(Language.Key_33_ChybiZpravaZOsn)", checked: false },
                { id: 34, text: "@Html.Raw(Language.Key_34_ProvedenZapisZOsn)", checked: false }
            ]
        }, {
            id: 3, text: "@Html.Raw(Language.Key_Dohoda)", checked: false, expanded: true, items: [
                { id: 40, text: "@Html.Raw(Language.Key_40_Dohoda_SkJeVyplnen)", checked: false },
                { id: 41, text: "@Html.Raw(Language.Key_41_Dohoda_PorusenSk)", checked: false }
            ]
        }, {
            id: 5, text: "@Html.Raw(Language.Key_KeZpracovani)", checked: false, expanded: true, items: [
                { id: 50, text: "@Html.Raw(Language.Key_50_KeZpracovani_50Nepouzito)", checked: false },
                { id: 51, text: "@Html.Raw(Language.Key_51_Telefonat)", checked: false },
                { id: 52, text: "@Html.Raw(Language.Key_52_MailSms)", checked: false },
                { id: 53, text: "@Html.Raw(Language.Key_53_DohledaniKontaktu)", checked: false },
                { id: 54, text: "@Html.Raw(Language.Key_54_OvereniDodaniDokumentu)", checked: false },
                { id: 55, text: "@Html.Raw(Language.Key_55_OvereniPlatby)", checked: false },
                { id: 56, text: "@Html.Raw(Language.Key_56_OvereniInformaci)", checked: false },
                { id: 57, text: "@Html.Raw(Language.Key_57_Jine)", checked: false },
                { id: 58, text: "@Html.Raw(Language.Key_58_Rozpor_DolozeniDokumentuEos)", checked: false }
            ]
        }, {
            id: 6, text: "@Html.Raw(Language.Key_Uzavreny)", checked: false, expanded: true, items: [
                { id: 60, text: "@Html.Raw(Language.Key_60_Uzavreny_VKlcKOsnZruseno)", checked: false },
                { id: 61, text: "@Html.Raw(Language.Key_61_UzavrenyPodminecne)", checked: false },
                { id: 62, text: "@Html.Raw(Language.Key_62_VZadostiOVraceniSpisu)", checked: false },
                { id: 63, text: "@Html.Raw(Language.Key_63_UzavreniSupervizorem)", checked: false }
            ]
        }];
        var spisyURL = '@Url.Action("vwAD_Basic", "Api/AdminService")';
        var viewModel = kendo.observable({
            Spisy_visible: true,
            SpisyDL_visible: false,
            Spisy_select: function (e) {
                this.set("Spisy_visible", true);
                this.set("SpisyDL_visible", false);
                this.SpisyDL.read();
            },
            SpisyDL_select: function (e) {
                this.set("Spisy_visible", false);
                this.set("SpisyDL_visible", true);
                this.SpisyDL.read();
            },
            tableMaximize: function (e) {
                var btn = $(e.target.firstChild);
                var splitter = $("#splitter").data("kendoSplitter");
                var panel1 = $("#splitter-right");
                var panel2 = $("#splitter-middle");
                if (panel1.width() > 0 && panel2.width() > 0) {
                    splitter["collapse"](panel1);
                    splitter["collapse"](panel2);
                    btn.removeClass("fa-window-maximize").addClass("fa-window-restore");
                } else {
                    splitter["expand"](panel2);
                    splitter["expand"](panel1);
                    btn.removeClass("fa-window-restore").addClass("fa-window-maximize");
                };
            },
            collaps_left: function (e) {
                var splitter = $("#splitter").data("kendoSplitter");
                var panel = $("#splitter-left");
                if (panel.width() > 0) {
                    splitter["collapse"](panel);
                    $("#collapse-left").removeClass("fa-arrow-left").addClass("fa-arrow-right");
                } else {
                    splitter["expand"](panel);
                    $("#collapse-left").removeClass("fa-arrow-right").addClass("fa-arrow-left");
                };
            },
            collaps_right: function (e) {
                var splitter = $("#splitter").data("kendoSplitter");
                var panel = $("#splitter-right");
                if (panel.width() > 0) {
                    splitter["collapse"](panel);
                    $("#collapse-right").removeClass("fa-arrow-right").addClass("fa-arrow-left");
                } else {
                    splitter["expand"](panel);
                    $("#collapse-right").removeClass("fa-arrow-left").addClass("fa-arrow-right");
                };
            },
            onResize: function (e) {
                $(window).resize();
            },
            onExpand: function (e) {
                var id = e.pane.id;
                if (id == "splitter-left") {
                    $("#collapse-left").removeClass("fa-arrow-right").addClass("fa-arrow-left");
                } else {
                    $("#collapse-right").removeClass("fa-arrow-left").addClass("fa-arrow-right");
                }
            },
            onCollapse: function (e) {
                var id = e.pane.id;
                if (id == "splitter-left") {
                    $("#collapse-left").removeClass("fa-arrow-left").addClass("fa-arrow-right");
                } else {
                    $("#collapse-right").removeClass("fa-arrow-right").addClass("fa-arrow-left");
                }
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
            statesMenu: defStates,
            filter1: false,
            filter2: false,
            filter3: false,
            filter4: false,
            Stav_filter: function (e) {
                $(e.currentTarget).closest("ul[data-role='menu']").find("li ul .k-icon").hide();
                this.set("filter1", true);
                this.set("filter2", false);
                this.set("filter3", false);
                this.set("filter4", false);
                this.Spisy.filter({});
                this.Spisy.sort({});
                this.SpisyDL.filter({});
                this.SpisyDL.sort({});
                var treeview = $("#stateTree").data("kendoTreeView");
                var nodes = treeview.dataSource.view();
                var items = getCheckedNodes(nodes);
                var filter = {
                    logic: "or",
                    filters: $.map(items, function (value) {
                        return {
                            operator: "eq",
                            field: "rr_State",
                            value: value.id
                        };
                    })
                };
                spisyURL = '@Url.Action("vwAD_Basic", "Api/AdminService")';
                this.Spisy.transport.options.read.url = spisyURL;
                this.Spisy.filter(filter);
            },
            OSN_filter: function (e) {
                $(e.currentTarget).closest("ul[data-role='menu']").find("li ul .k-icon").hide();
                $(e.currentTarget).find(".k-icon").show();
                var f = $(e.currentTarget).data("filter");
                this.set("filter1", false);
                this.set("filter2", true);
                this.set("filter3", false);
                this.set("filter4", false);
                this.Spisy.filter({});
                this.Spisy.sort({});
                this.SpisyDL.filter({});
                this.SpisyDL.sort({});
                switch (f) {
                    case 1:
                        spisyURL = '@Url.Action("vwAD_F21_WithoutFV", "Api/AdminService")';
                        break;
                    case 2:
                        spisyURL = '@Url.Action("vwAD_F22_WithFirstFV", "Api/AdminService")';
                        break;
                    case 3:
                        spisyURL = '@Url.Action("vwAD_F23_WithSecondFV", "Api/AdminService")';
                        break;
                    case 4:
                        spisyURL = '@Url.Action("vwAD_F24_WithMoreThanSecond", "Api/AdminService")';
                        break;
                };
                this.Spisy.transport.options.read.url = spisyURL;
                this.set("statesMenu", defStates);
                this.Spisy.read();
            },
            URG_filter: function (e) {
                $(e.currentTarget).closest("ul[data-role='menu']").find("li ul .k-icon").hide();
                $(e.currentTarget).find(".k-icon").show();
                var f = $(e.currentTarget).data("filter");
                this.set("filter1", false);
                this.set("filter2", false);
                this.set("filter3", true);
                this.set("filter4", false);
                this.Spisy.filter({});
                this.Spisy.sort({});
                this.SpisyDL.filter({});
                this.SpisyDL.sort({});
                switch (f) {
                    case 1:
                        spisyURL = '@Url.Action("vwAD_F31_WithUrgencyOnly", "Api/AdminService")';
                        break;
                    case 2:
                        spisyURL = '@Url.Action("vwAD_F32_NotYetAcceptedAfter2Days", "Api/AdminService")';
                        break;
                    case 3:
                        spisyURL = '@Url.Action("vwAD_F33_NotYetAccepted", "Api/AdminService")';
                        break;
                    case 4:
                        spisyURL = '@Url.Action("vwAD_F34_NewReturned", "Api/AdminService")';
                        break;
                    case 5:
                        spisyURL = '@Url.Action("vwAD_F35_WithoutPlanFV", "Api/AdminService")';
                        break;
                    case 6:
                        spisyURL = '@Url.Action("vwAD_F36_DateFVOver", "Api/AdminService")';
                        break;
                    case 7:
                        spisyURL = '@Url.Action("vwAD_F37_MaxFVDateOver", "Api/AdminService")';
                        break;
                    case 8:
                        spisyURL = '@Url.Action("vwAD_F38_Urgency58", "Api/AdminService")';
                        break;
                    case 9:
                        spisyURL = '@Url.Action("vwAD_F39_AgreementCanceled", "Api/AdminService")';
                        break;
                    case 10:
                        spisyURL = '@Url.Action("vwAD_F310_AgrCancOver5Days", "Api/AdminService")';
                        break;
                    case 11:
                        spisyURL = '@Url.Action("vwAD_F311_DateLapseUnder6M", "Api/AdminService")';
                        break;
                    case 12:
                        spisyURL = '@Url.Action("vwAD_F312_ReturToCredUnder2M", "Api/AdminService")';
                        break;
                    case 13:
                        spisyURL = '@Url.Action("vwAD_F313_DPlanOverDMax", "Api/AdminService")';
                        break;
                    case 14:
                        spisyURL = '@Url.Action("vwAD_F314_UrgCashToCreditor", "Api/AdminService")';
                        break;
                };
                this.Spisy.transport.options.read.url = spisyURL;
                this.set("statesMenu", defStates);
                this.Spisy.read();
            },
            UZV_filter: function (e) {
                $(e.currentTarget).closest("ul[data-role='menu']").find("li ul .k-icon").hide();
                $(e.currentTarget).find(".k-icon").show();
                var f = $(e.currentTarget).data("filter");
                this.set("filter1", false);
                this.set("filter2", false);
                this.set("filter3", false);
                this.set("filter4", true);
                this.Spisy.filter({});
                this.Spisy.sort({});
                this.SpisyDL.filter({});
                this.SpisyDL.sort({});
                switch (f) {
                    case 1:
                        spisyURL = '@Url.Action("vwAD_F41_ClosedAll", "Api/AdminService")';
                        break;
                    case 2:
                        spisyURL = '@Url.Action("vwAD_F42_ClosedBySuper", "Api/AdminService")';
                        break;
                    case 3:
                        spisyURL = '@Url.Action("vwAD_F43_ClosedFromProcess", "Api/AdminService")';
                        break;
                    case 4:
                        spisyURL = '@Url.Action("vwAD_F44_ConditionedClose", "Api/AdminService")';
                        break;
                    case 5:
                        spisyURL = '@Url.Action("vwAD_F45_InReturnRequest", "Api/AdminService")';
                        break;
                }
                this.Spisy.transport.options.read.url = spisyURL;
                this.set("statesMenu", defStates);
                this.Spisy.read();
            },
            clearFilters: function (e) {
                $("#filtermenu").find("li ul .k-icon").hide();
                this.Spisy.transport.options.read.url = '@Url.Action("vwAD_Basic", "Api/AdminService")';
                this.set("statesMenu", defStates);
                this.set("filter1", false);
                this.set("filter2", false);
                this.set("filter3", false);
                this.set("filter4", false);
                if (this.Spisy_visible) {
                    this.Spisy.filter({});
                    this.Spisy.sort({});
                } else {
                    this.SpisyDL.filter({});
                    this.SpisyDL.sort({});
                };
            },
            Spisy: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDSpisu",
                        fields: {
                            'AlertExist': { type: 'number' },
                            'ACC': { type: 'string' },
                            'PersSurname': { type: 'string' },
                            'PersName': { type: 'string' },
                            'PersRC': { type: 'string' },
                            'PersIC': { type: 'string' },
                            'PersBirthDate': { type: 'date' },
                            'CreditorAlias': { type: 'string' },
                            'DateOSNMax': { type: 'date' },
                            'DateOSNPlan': { type: 'date' },
                            'StateTxt': { type: 'string' },
                            'PersRegion': { type: 'string' },
                            'PersCity': { type: 'string' },
                            'PersStreet': { type: 'string' },
                            'PersHouseNum': { type: 'string' },
                            'PersZipCode': { type: 'string' },
                            'ActualDebit': { type: 'number' },
                            'VisitDateReceiveFromMother': { type: 'date' },
                            'MaxCommission': { type: 'number' },
                            'DebtLastContact': { type: 'date' },
                            'DebtLastOSN': { type: 'date' },
                            'DateReturnToCreditor': { type: 'date' },
                            'DateLapse': { type: 'date' },
                            'LastPaymentDate': { type: 'date' },
                            'VisitDateOSNNoChange': { type: 'boolean' },
                            'Inspector': { type: 'string' },
                            'GPSValid': { type: 'boolean' },
                            "CurrencyTxt": { type: "string" }
                        }
                    }
                },
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true,
                pageSize: 100,
                transport: {
                    read: {
                        url: spisyURL,
                        dataType: "json"
                    },
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if (pm.$filter) {
                            pm.$filter = pm.$filter.replace("eq ''", "eq null");
                        }
                        return pm;
                    }
                },
                requestEnd: function (e) {
                    if (e.response) {
                        if (e.response.MsgType === 'error') {
                            var msg = "<span style='margin-left:6px;'>" + e.response.Msg.join("<br>") + "</span>"
                            message(msg, e.response.MsgType);
                        }
                    }
                }
            }),
            Spisy_dataBound: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var row = e.sender.tbody.find("tr:first");
                var allRows = e.sender.tbody.find("tr");
                allRows.each(function () {
                    var di = grid.dataItem($(this));
                    $(this).attr("data-id", di.IDSpisu);
                });
                if (urlID) {
                    this.Spisy.filter({
                        field: "ACC",
                        operator: "eq",
                        value: urlID
                    });
                    urlID = null;
                };
                if (this.Spisy_visible && row.length > 0) {
                    grid.select(row);
                }
                $('#a1_header-chb').prop("checked", false);
                $('#a1_header-chb').change(function (ev) {
                    var checked = ev.target.checked;
                    if (checked) {
                        $('#Spisy .checkrow').prop('checked', true);
                    } else {
                        $('#Spisy .checkrow').prop('checked', false);
                    };
                    $('#Spisy .checkrow').change();
                });
                if (e.sender.dataSource.total() === 0) {
                    this.set("B3_Visible", false);
                };
                btnEnebleChange(0, 0, 0, this);
                $(window).resize();
            },
            Spisy_change: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var di = grid.dataItem(grid.select());
                if (di) {
                    this.B3_Filter(di.IDSpisu, di.IDSpisyOsoby, 0);
                }
            },
            selectRow: function (e) {
                var checked = $(e.currentTarget).prop("checked"),
                    row = $(e.currentTarget).closest("tr");
                var l = $('#Spisy .checkrow:checked').length; //vybranych radku
                var t = this.Spisy.data().length; //celkem zobrazenych zaznamu
                if (l !== t) {
                    $('#a1_header-chb').prop("checked", false);
                } else {
                    $('#a1_header-chb').prop("checked", true);
                }
                btnEnebleChange(+(l === 0), +(l === 1), +(l > 1), this);
            },
            btnDateOSNPlan: function (e) {
                var model = this;
                var grid = $(e.currentTarget).closest(".k-grid").data("kendoGrid");
                var row = $(e.currentTarget).closest("tr");
                var view = this.Spisy.view();
                grid.select(row);
                showOSNDatePlan(e.data.DateOSNPlan, e.data.DateOSNMax, function (date, nochange, name) {
                    DatePlanProcess([e.data], date, nochange, name, function (result) {
                        urlID = e.data.IDSpisu;
                        $.get("@Url.Action("SpisyIDSpisyOsoby", "Api/AdminService")", { IDSpisyOsoby: e.data.IDSpisyOsoby }, function (result) {
                            $.each(result.Data, function (a, b) {
                                var item = model.Spisy.get(b.IDSpisu);
                                if (item) {
                                    if (!item.get("VisitDatePlanNoChange")) {
                                        item.set("AlertExist", b.AlertExist);
                                        item.set("DateOSNPlan", date);
                                    }
                                }
                            });
                        });
                    });
                });
            },
            setGps: function (e) {
                var model = this;
                var grid = $(e.currentTarget).closest(".k-grid").data("kendoGrid");
                var row = $(e.currentTarget).closest("tr");
                grid.select(row);
                CallWinAddressParser("@Url.Action("tblSpisyOsobyAdresy", "Api/Service")", e.data.IDSpisyOsobyAdresy, function (GPSValid) {
                    urlID = e.data.IDSpisu;
                    model.Spisy.fetch();
                    model.SpisyDL.fetch();
                });
            },
            SpisyDL: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDSpisyOsoby",
                        fields: {
                            'AlertExist': { type: 'number' },
                            'IDSrcSpisyOsoby': { type: 'number' },
                            'PersSurname': { type: 'string' },
                            'PersName': { type: 'string' },
                            'PersRC': { type: 'string' },
                            'PersIC': { type: 'string' },
                            'PersBirthDate': { type: 'date' },
                            'SumActualDebit': { type: 'number' },
                            'PersPhone': { type: 'string' },
                            'PersRegion': { type: 'string' },
                            'PersCity': { type: 'string' },
                            'PersStreet': { type: 'string' },
                            'PersHouseNum': { type: 'string' },
                            'PersZipCode': { type: 'string' },
                            'VisitDatePlan': { type: 'date' },
                            'VisitDatePlanNoChange': { type: 'boolean' }
                        }
                    }
                },
                pageSize: 100,
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true,
                pageSize: 100,
                transport: {
                    read: {
                        url: '@Url.Action("vwAD_DLBasic", "Api/AdminService")',
                        dataType: "json",
                    },
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if (pm.$filter) {
                            pm.$filter = pm.$filter.replace("eq ''", "eq null or eq ''");
                        }
                        return pm;
                    }
                },
                requestEnd: function (e) {
                    if (e.response) {
                        if (e.response.MsgType === 'error') {
                            var msg = "<span style='margin-left:6px;'>" + e.response.Msg.join("<br>") + "</span>"
                            message(msg, e.response.MsgType);
                        }
                    }
                }
            }),
            SpisyDL_dataBound: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var row = e.sender.tbody.find("tr:first");
                if (this.SpisyDL_visible) {
                    grid.select(row);
                }
                $(window).resize();
            },
            SpisyDL_change: function (e) {
                var g = $(e.sender.element).data("kendoGrid");
                var di = g.dataItem(g.select());
                if (di) {
                    this.B3_Filter(0, di.IDSpisyOsoby, 0);
                }
                $.each($(".k-detail-cell > .k-grid"), function () {
                    var grid = $(this).data("kendoGrid");
                    if ($(this)[0].id && $(e.sender.element)[0].id) {
                        if ($(e.sender.element)[0].id !== $(this)[0].id) {
                            grid.clearSelection();
                        };
                    };
                });
                btnEnebleChange(0, 0, 0, this);
            },
            SpisyDL_detailInit: function (e) {
                var parentModel = this;
                var dataItem = $(e.sender.element).data("kendoGrid").dataItem(e.masterRow);
                var detailModel = kendo.observable({
                    SpisyDLSub: new kendo.data.DataSource({
                        schema: {
                            total: "Total",
                            data: "Data",
                            model: {
                                id: "IDSpisu",
                                fields: {
                                    'AlertExist': { type: 'number' },
                                    'ACC': { type: 'string' },
                                    'CreditorAlias': { type: 'string' },
                                    'ActualDebit': { type: 'number' },
                                    'StateTxt': { type: 'string' },
                                    'DateOSNMax': { type: 'date' },
                                    'DateOSNPlane': { type: 'date' }
                                }
                            }
                        },
                        serverPaging: true,
                        serverSorting: true,
                        serverFiltering: true,
                        noRecords: true,
                        transport: {
                            read: {
                                url: '@Url.Action("vwAD_DLBasicSub", "Api/AdminService")',
                                dataType: "json",
                            },
                            parameterMap: function (options, type) {
                                var pm = kendo.data.transports.odata.parameterMap(options);
                                return { options: pm, IDSpisyOsoby: dataItem.IDSpisyOsoby };
                            }
                        },
                        requestEnd: function (e) {
                            if (e.response) {
                                if (e.response.MsgType === 'error') {
                                    var msg = "<span style='margin-left:6px;'>" + e.response.Msg.join("<br>") + "</span>"
                                    message(msg, e.response.MsgType);
                                }
                            }
                        }
                    }),
                    SpisyDLSub_change: function (e) {
                        var g = $(e.sender.element).data("kendoGrid");
                        var di = g.dataItem(g.select());
                        if (di) {
                            $(e.sender.element).closest("#SpisyDL").find("tr").not(".k-detail-row tr").removeClass("k-state-selected");
                            parentModel.B3_Filter(di.IDSpisu, di.IDSpisyOsoby, 0);

                            $.each($(".k-detail-cell > .k-grid"), function () {
                                var grid = $(this).data("kendoGrid");
                                if ($(this)[0].id && $(e.sender.element)[0].id) {
                                    if ($(e.sender.element)[0].id !== $(this)[0].id) {
                                        grid.clearSelection();
                                    };
                                };
                            });
                        }
                        if (di) {
                            btnEnebleChange(0, 1, 0, parentModel);
                        }
                    },
                    SpisyDLSub_dataBound: function (e) {
                        var grid = $(e.sender.element).data("kendoGrid");
                        var allRows = e.sender.tbody.find("tr");
                        allRows.each(function () {
                            var di = grid.dataItem($(this));
                            $(this).attr("data-id", di.IDSpisu);
                        });
                        if (urlID) {
                            var row = e.sender.tbody.find("[data-id='" + urlID + "']");
                            grid.select(row);
                        } else {
                            grid.select(allRows[0]);
                        }
                    },
                    rowHref: function (e) {
                        var id = e.IDSpisu;
                        return "FileAdministration?id=" + id;
                    },
                    btnDateOSNPlan: function (e) {
                        var model = this;
                        var grid = $(e.currentTarget).closest(".k-grid").data("kendoGrid");
                        var row = $(e.currentTarget).closest("tr");
                        var view = this.SpisyDLSub.view();
                        grid.select(row);
                        showOSNDatePlan(e.data.VisitDatePlan, e.data.DateOSNMax, function (date, nochange, name) {
                            DatePlanProcess([e.data], date, nochange, name, function (result) {
                                urlID = e.data.IDSpisu;
                                $.get("@Url.Action("SpisyDLSubPodleIDSpisyOsoby", "Api/AdminService")", { IDSpisyOsoby: e.data.IDSpisyOsoby }, function (result) {
                                    $.each(result.Data, function (a, b) {
                                        var item = model.SpisyDLSub.get(b.IDSpisu);
                                        if (item) {
                                            console.log(item)
                                            if (!item.get("VisitDatePlanNoChange")) {
                                                item.set("AlertExist", b.AlertExist);
                                                item.set("DateOSNPlane", date);
                                            }
                                        }
                                    });
                                });
                            });
                        });
                    }
                });
                initDLNovySub(dataItem.uid);
                kendo.bind(e.detailCell, detailModel);
            },
            action: function (e) {
                var btn = $(e.sender.element);
                var act = btn.data("action");
                var grid,
                    chr,
                    items = [],
                    source = [];
                if (this.Spisy_visible) {
                    grid = $("#Spisy").data("kendoGrid");
                    source = grid.dataSource;
                    var select = grid.dataItem(grid.select());
                    if (select) {
                        urlID = select.IDSpisu;
                    };
                    chr = $("#Spisy .checkrow:checked");
                    chr.each(function () {
                        items.push(grid.dataItem($(this).closest("tr")));
                    });
                    setAct(source, this);
                } else {
                    var selected = $("#SpisyDL .k-detail-cell > .k-grid tr.k-state-selected")[0];
                    if (selected) {
                        grid = $(selected).closest(".k-grid").data("kendoGrid");
                        source = grid.dataSource;
                        urlID = grid.dataItem(grid.select()).IDSpisu;
                        items.push(grid.dataItem(selected));
                        setAct(source, this);
                    }
                };

                function setAct(source, model) {
                    var ids = $.map(items, function (n, i) {
                        return n.IDSpisu;
                    });
                    var total = ids.length;
                    switch (act) {
                        case 1: //Uzavření spisu
                            var nonstates = $.grep(items, function (n, i) {
                                return (n.rr_State === 20 || n.rr_State > 59);
                            });
                            if (nonstates.length > 0) {
                                message("@Language.SVNonStates1", "warning");
                                return false;
                            }
                            SVUzavreniSpisu(ids, function (promises) {
                                total = promises.length;
                                if (promises) {
                                    progress(promises, total, function (e) {
                                        urlID = null;
                                        model.Spisy.read();
                                        model.SpisyDL.read();
                                    });
                                }
                            });
                            break;
                        case 2: //@Html.Raw(Language.FileAdministrationTXT32)
                            var nonstates = $.grep(items, function (n, i) {
                                return (n.rr_State !== 61);
                            });
                            if (nonstates.length > 0) {
                                message("@Language.SVNonStates2", "warning");
                                return false;
                            }
                            $.get("@Url.Action("AGsp_GetCommentInspektoraWhenFileToClose", "Api/AdminService")", { iDSpisu: ids[0] }, function (text) {
                                SVResPodUzaSpisu(ids, text, function (promises) {
                                    total = promises.length;
                                    if (promises) {
                                        progress(promises, total, function (e) {
                                            urlID = null;
                                            model.Spisy.read();
                                            model.SpisyDL.read();
                                        });
                                    }
                                });
                            })
                            break;
                        case 3: //Zrušení odmítnutého spisu
                            var nonstates = $.grep(items, function (n, i) {
                                return (n.rr_State !== 20);
                            });
                            if (nonstates.length > 0) {
                                message("@Language.SVNonStates3", "warning");
                                return false;
                            }
                            SVOdmitnutiNovychSpisu(ids, function (promises) {
                                total = promises.length;
                                if (promises) {
                                    progress(promises, total, function (e) {
                                        urlID = null;
                                        model.Spisy.read();
                                        model.SpisyDL.read();
                                    });
                                }
                            })
                            break;
                        case 4: //@Html.Raw(Language.FileAdministrationTXT35)
                            var nonstates = $.grep(items, function (n, i) {
                                return (n.rr_State === 20 || n.rr_State > 39);
                            });
                            if (nonstates.length > 0) {
                                message("@Language.SVNonStates4", "warning");
                                return false;
                            }
                            SVZmenaD1MAX(items, function (promises) {
                                total = promises.length;
                                if (promises) {
                                    progress(promises, total, function (e) {
                                        urlID = null;
                                        model.Spisy.read();
                                        model.SpisyDL.read();
                                    });
                                }
                            })
                            break;
                        case 5: //@Html.Raw(Language.FileAdministrationTXT36)
                            var nonstates = $.grep(items, function (n, i) {
                                return (n.rr_State === 20 || n.rr_State > 39);
                            });
                            if (nonstates.length > 0) {
                                message("@Language.SVNonStates4", "warning");
                                return false;
                            }
                            SVZmenaDMAX(items, function (promises) {
                                total = promises.length;
                                if (promises) {
                                    progress(promises, total, function (e) {
                                        urlID = null;
                                        model.Spisy.read();
                                        model.SpisyDL.read();
                                    });
                                }
                            })
                            break;
                        case 6: //Potvrdit a vrátit ke zpracování
                            var nonstates = $.grep(items, function (n, i) {
                                return (n.rr_State !== 62);
                            });
                            if (nonstates.length > 0) {
                                message("Nelze pokračovat. Některé spisy nejsou ve stavu 62 (v žádosti o vrácení spisu)", "warning");
                                return false;
                            }
                            SVPotvrditAVratit(ids, function (promises) {
                                total = promises.length;
                                if (promises) {
                                    progress(promises, total, function (e) {
                                        urlID = null;
                                        model.Spisy.read();
                                        model.SpisyDL.read();
                                    });
                                }
                            });
                            break;
                        case 7:
                            SVVytvoreniPripominky(items, source, function (promises) {
                                total = promises.length;
                                if (promises) {
                                    progress(promises, total, function (e) {
                                        urlID = null;
                                        model.Spisy.read();
                                        model.SpisyDL.read();
                                    });
                                }
                            })
                            break;
                        case 8:
                            var promises = items.map(function (item, i) {
                                return $.Deferred(function (d) {
                                    $.get("@Url.Action("sp_Run_3xand5xto40", "Api/AdminService")", {
                                        iDSpisu: item.IDSpisu,
                                        aCC: item.ACC
                                    }, function (result) {
                                        if (result.MsgType === 'error') {
                                            var msg = "<span style='margin-left:6px;'>" + result.Msg.join("<br>") + "</span>"
                                            message(msg, 'error', 10000);
                                        }
                                    }).always(function () {
                                        d.notify(i);
                                        d.resolve.apply(this, arguments);
                                    })
                                }).promise();
                            });
                            total = promises.length;
                            if (promises) {
                                progress(promises, total, function (e) {
                                    urlID = null;
                                    model.Spisy.read();
                                    model.SpisyDL.read();
                                });
                            }
                            break;
                    }
                };
                
                function progress(promises, total, callback) {
                    var counter = 0;
                    var value = 0;
                    winProgressBarDialog.open().center();
                    $.when.apply(null, promises).progress(function () {
                        counter++
                        value = parseFloat(parseInt(counter, 10) * 100) / parseInt(total, 10);
                        progressModel.set("progressValue", value);
                    }).done(function () {
                        callback(true);
                    });
                }
            },
            btnEnabled: {
                @Code
                    Using db As New Trace.TRACEEntities
                        Dim p As String = Html.CurAction
                        For Each i In db.tblObjectAccessibilities.Where(Function(e) e.Destination = p).ToList
                            @<text>"@i.IDObject": { "enabled": false, "access": "@i.Access" },</text>
                        Next
                    End Using
                End Code
            },
            B3_Visible: true,
            B3_Filter: function (iDSpisu, iDSpisyOsoby, iDSpisyOsobyZam) {
                var model = this;
                try {
                    var allProcess = [];
                    kendo.ui.progress($("#splitter-middle"), true);

                    $.get('@Url.Action("sp_Get_CreditorDetail_G2", "Api/Service")', { iDSpisu: iDSpisu, zalozka: '@Html.CurAction' }, function (result) {
                        if (result.Data) {
                            var d = result.Data[0];
                            var rm = '@Language.DifferentCurrencies';
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

                    if (iDSpisu === 0) {
                        model.set("B3_Visible", false);
                        kendo.ui.progress($("#splitter-middle"), false);
                        return false;
                    } else {
                        model.set("B3_Visible", true);
                    }

                    allProcess.push($.get('@Url.Action("sp_B3_DetailSpisu", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                        if (result.Data) { model.set("B3_DetailSpisu", result.Data[0]); }
                    }));
                    allProcess.push($.get('@Url.Action("sp_B3_HistorieDohod", "Api/Service")', { iDSpisu: iDSpisu }, function (result) {
                        if (result.Data) { model.set("B3_HistorieDohod", result.Data); }
                    }));
                    allProcess.push($.get('@Url.Action("sp_B3_OsobyAddress", "Api/Service")', { iDSpisu: iDSpisu, iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                        if (result.Data) { model.set("B3_OsobyAddress", result.Data); }
                    }));
                    allProcess.push($.get('@Url.Action("sp_B3_OsobyEmail", "Api/Service")', { iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                        if (result.Data) { model.set("B3_OsobyEmail", result.Data); }
                    }));
                    allProcess.push($.get('@Url.Action("sp_B3_OsobyPhone", "Api/Service")', { iDSpisyOsoby: iDSpisyOsoby }, function (result) {
                        if (result.Data) { model.set("B3_OsobyPhone", result.Data); }
                    }));
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
                    allProcess.push($.get('@Url.Action("vw_ListUrgAndRemind", "Api/AdminService")', { iDSpisu: iDSpisu }, function (result) {
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
                        model.set("B3_OtherInfo", result.Data);
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
                        kendo.ui.progress($("#splitter-middle"), false);
                    }).done(function () {
                        kendo.ui.progress($("#splitter-middle"), false);
                    });
                } catch (ex) {
                    kendo.ui.progress($("#splitter-middle"), false);
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
                    traceplaneradio: viewModel.traceplaneradio
                })
                kendo.bind($(e.detailCell), model);
                $.get('@Url.Action("sp_B3_OsobyAddress", "Api/Service")', { iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyAddress", result.Data); }
                })
                $.get('@Url.Action("sp_B3_OsobyEmail", "Api/Service")', { iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyEmail", result.Data); }
                })
                $.get('@Url.Action("sp_B3_OsobyPhone", "Api/Service")', { iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyPhone", result.Data); }
                })
            },
            UrgencyDelete: function (e) {
                var model = this;
                $.get('@Url.Action("sp_Do_DoneOneReminder", "Api/Service")', { iDSpisu: e.data.IDCase, iDReminder: e.data.ID }, function (result) {
                    var nm = $(e.currentTarget).closest("table").find("tr").length - 1;
                    var id = e.data.IDCase;
                    if (nm === 0) {
                        var row = $("tr[data-id='" + id + "']");
                        row.find(".fa-bell-o").remove();
                    }
                    $(e.currentTarget).closest("tr").remove();
                });
            },
            deletePDFFile: function (e) {
                var row = $(e.currentTarget).closest("tr");
                $.get("@Url.Action("sp_Do_DeleteDocument", "Api/AdminService")", { iDSpisyDocument: e.data.IDSpisyDocument }, function (result) {
                    row.remove();
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
                var id = e.ACC;
                return "FileAdministration?id=" + id;
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
            B3_Urgency: [],
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
            B3_OtherInfo: [],
            B3_ListAllFV: [],
            vwrr_AddressType: []
        });

        kendo.bind($("#administration"), viewModel);

        //nastaveni sorteni podzalozek
        $("#splitter-middle-panels").kendoSortable({
            axis: "y",
            filter: ">.panel",
            ignore: ".panel-body *",
            cursor: "move",
            connectWith: "#splitter-middle-panels",
            placeholder: placeholder,
            hint: hint,
            init: function (element, valueAccessor, allBindingsAccessor, context) {
                //console.log(context)
            }
        });

        loadSettings();
    });

    function placeholder(element) {
        return element.clone().addClass("placeholder");
    };

    function hint(element) {
        return element.clone().addClass("hint")
                    .height(element.height() + 18)
                    .width(element.width());
    };

        var vwrr_PersType = [
    @Code
        For Each i In New Trace.TRACEEntities().vwrr_PersType
            @<text>{ text: "@Html.Raw(i.PersTypeTxt)", value: parseInt("@Html.Raw(i.rr_PersType)") },</text>
        Next
    End Code
        ];

        function btnEnebleChange(n, o, m, model) {
            var res = null;
            var arr = model.btnEnabled.toJSON();
            res = (n + 2 * o + 4 * m);
            //if (model.Spisy_visible) {
            //    res = (n + 2 * o + 4 * m);
            //} else {
            //    res = (8 * n + 16 * o + 32 * m);
            //}
            $.each(arr, function (i, e) {
                var access = model.btnEnabled[i].get("access");
                var b = (access & res) > 0;
                model.btnEnabled[i].set("enabled", b)
            });
        };

        function DatePlanProcess(items, dat, nochange, name, callback) {
            var allProcess = [];
            var total = items.length;
            var counter = 1;
            progressModel.set("progressLogVisible", false);
            $.each(items, function (i, item) {
                allProcess.push($.get('@Url.Action("Run_xxtoDateFV", "Api/Service/")', { id: item.IDSpisu, dat: kendo.toString(dat, "yyyy-MM-dd HH:mm:ss"), nochange: nochange, name: name }, function (result) {
                    var value = parseFloat(parseInt(counter, 10) * 100) / parseInt(total, 10);
                    progressModel.set("progressValue", value);

                    if (result.MsgType === "error") {
                        progressModel.set("progressLogVisible", true);
                        progressModel.progressLog.insert(0, { state: result.MsgType, text: result.Msg[0] });
                    }
                    counter++
                }));
            });
            winProgressBarDialog.open().center();
            $.when.apply($, allProcess).done(function () {
                callback(true)
            });
        };

        //*************************************************************************************************

        var settings = {
            splitter: {},
            grids: [],
            sortable: [{ "id": "B3_podzal_DetailSpisu", "index": 0, "toggle": false },
                        { "id": "B3_podzal_Kontakty", "index": 1, "toggle": false },
                        { "id": "B3_podzal_DoslePlatby", "index": 2, "toggle": true },
                        { "id": "B3_podzal_DalsiOsoby", "index": 3, "toggle": true },
                        { "id": "B3_podzal_Dokumentace", "index": 4, "toggle": true },
                        { "id": "B3_podzal_Historie", "index": 5, "toggle": true },
                        { "id": "B3_podzal_Seznam", "index": 6, "toggle": true },
                        { "id": "B3_podzal_Terminy", "index": 7, "toggle": true },
                        { "id": "B3_podzal_Specifikace", "index": 8, "toggle": true }, ],
            visible1: true,
            visible2: false,
        };

        var options = localStorage["@Html.CurAction"];
        if (options) {
            options = JSON.parse(options);
        } else {
            options = settings
        };

        function loadSettings() {
            if (options.grids) {
                $.each(options.grids, function (i, e) {
                    var obj = $("#" + e.id).data("kendoGrid");
                    if (obj) {
                        obj.setOptions(e.options);
                    };
                });
            };

            //rozlozeni velkeho splitru
            if (options.splitter) {
                var obj = $("#splitter").data("kendoSplitter");
                if (obj) {
                    $.each(options.splitter.panes, function (index, pane) {
                        var p = $("#splitter").children(".k-pane")[index];
                        if (pane.collapsible) {
                            if (pane.size > 0) {
                                obj["expand"](p);
                                obj.size(p, (pane.size + "px"));
                            } else {
                                obj["collapse"](p);
                                if ($(p)[0].id == "splitter-left-pane") {
                                    $("li[data-action=3] .fa").removeClass("fa-arrow-left").addClass("fa-arrow-right");
                                } else {
                                    $("li[data-action=4] .fa").removeClass("fa-arrow-right").addClass("fa-arrow-left");
                                }
                            };
                        };
                    });
                };
            };

            //sorteni a otvirani/zavirani podzalozek
            if (options.sortable) {
                $.each(options.sortable, function (index, pane) {
                    var obj = $("#" + pane.id);
                    if (obj) {
                        obj.attr("data-index", pane.index);
                        if (pane.toggle) {
                            obj.children(".panel-header").click();
                        };
                    };
                });
                $("#splitter-center-panels > div").sort(function (a, b) {
                    return a.dataset.index > b.dataset.index;
                }).appendTo('#splitter-center-panels');
            };
        };

        function saveSettings() {
            kendo.ui.progress($("body"), true);

            try {
                $.each($(".k-grid"), function (i, e) {
                    var obj = $(this).data("kendoGrid");
                    var id = $(this)[0].id;
                    if (id) {
                        settings.grids.push({ id: id, options: obj.getOptions() });
                    };
                });
            } catch (ex) { console.log(ex) }

            try {
                var obj = $("#splitter").data("kendoSplitter");
                if (obj) {
                    $.each($("#splitter").children(".k-pane"), function (i, e) {
                        obj.options.panes[i].size = $(this).width();
                    });
                    settings.splitter = { panes: obj.options.panes };
                }
            } catch (ex) { console.log(ex) }

            try {
                var obj = $("#splitter-center").data("kendoSortable");
                if (obj) {
                    var items = $(obj.options.connectWith + " " + obj.options.filter);
                    $.each(items, function (i, e) {
                        var id = $(this)[0].id;
                        if (id) {
                            var index = $(this).index();
                            $.grep(settings.sortable, function (pan) {
                                if (pan.id === id) {
                                    pan.index = index;
                                    pan.toggle = !$("#" + id).find(".panel-body").is(':visible');
                                }
                            });
                        };
                    });
                }
            } catch (ex) { console.log(ex) }

            try {
                localStorage["@Html.CurAction"] = kendo.stringify(settings);
                setTimeout(function () {
                    kendo.ui.progress($("body"), false);
                }, 1000);
            } catch (ex) { console.log(ex) }
        };
</script>