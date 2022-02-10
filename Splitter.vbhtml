<!-- splitter layout -->
<div id="splitter" class="flex-container"
    data-role="splitter"
    data-bind="events: { expand: onExpand, collapse: onCollapse, resize: onResize }"
    data-panes="[
    @Code
        If Html.CurAction <> "Finished" Then
    @<text>
     { collapsible: true, min: '300px', scrollable: false, size: '40%' },
     { collapsible: true, min: '400px' },
     { collapsible: true, min: '200px', max: '200px', resizable: false, size: '200px' }
    </text>
        Else
    @<text>
     { collapsible: true, min: '300px', scrollable: false },
     { collapsible: true, min: '200px', max: '200px', resizable: false, size: '200px' }
    </text>      
        End If
    End Code
     ]">
    <div id="splitter-left-pane" class="flex-body" style="overflow: hidden;">
        <!-- left top menu nav -->
        <ul data-role="menu"
            data-bind="events: { select: onSelect }">
            @Code
                If Html.CurAction <> "Finished" Then
                @<li data-bind="selected: Spisy_visible" data-action="1"><b>@Language.splitterTXT1</b></li>
                @<li data-bind="selected: SpisyDL_visible" data-action="2"><b>@Language.splitterTXT2</b></li>
                End If
            End Code
            @Code
                If Html.CurAction = "Finished" Then
                @<li data-action="4" style="float: right;"><span id="fullscreenspis" class="fa fa-arrow-right"></span></li>
                End If
            End Code
            @Code
                If Html.CurAction <> "Finished" Then
                @<li data-action="7" style="float: right;">
                    <i class="fa fa-window-maximize" aria-hidden="true"></i>
                </li>
                End If
            End Code
            <li data-action="6" style="float: right;">
                <span class="k-icon k-i-filter-clear"></span>
                <!-- <i class="fa fa-filter"></i>
                <i style="position: relative; font-size: 70%; color: red; left: -3px;" class="fa fa-remove"></i> -->
            </li>
            @Code
                If Html.CurAction = "News" Then
                @<li data-action="8" style="float: right;" title="Hromadná validace všech GPS adres">
                    <span class="k-icon k-i-marker-pin"></span>
                </li>
                End If
            End Code
        </ul>
        <!-- end menu -->
        <!-- grid -->
        @Code
            Select Case Html.CurAction
                Case "News"
            @<text>
            <div data-bind="visible: Spisy_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA1_Novy.vbhtml")
            </div>
            <div data-bind="visible: SpisyDL_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA2_DLNovy.vbhtml")
            </div>
            </text>
                Case "PersonalVisit"
            @<text>
            <div data-bind="visible: Spisy_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA1_OSN.vbhtml")
            </div>
            <div data-bind="visible: SpisyDL_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA2_DLOSN.vbhtml")
            </div>
            </text>
                Case "Agreements"
            @<text>
            <div data-bind="visible: Spisy_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA1_Dohody.vbhtml")
            </div>
            <div data-bind="visible: SpisyDL_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA2_DLDohody.vbhtml")
            </div>
            </text>
                Case "ToProcess"
            @<text>
            <div data-bind="visible: Spisy_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA1_KeZprac.vbhtml")
            </div>
            <div data-bind="visible: SpisyDL_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA2_DLKeZprac.vbhtml")
            </div>
            </text>
                Case "Finished"
            @<text>
            <div data-bind="visible: Spisy_visible" style="height: 100%; width: 100%">
                @Html.Partial("~/Views/Objects/vwA1_Finished.vbhtml")
            </div>
            <div data-bind="visible: SpisyDL_visible" style="height: 100%; width: 100%"></div>
            </text>
            End Select
        End Code
        <!-- end grid -->
    </div>
    @Code
                If Html.CurAction <> "Finished" Then
        @<div id="splitter-center-pane" class="flex-body" style="overflow: hidden;">
            <!-- center top menu nav -->
            <ul data-role="menu"
                data-bind="events: { select: onSelect }">
                <li data-action="3"><span class="fa fa-arrow-left"></span></li>
                <li data-action="4" style="float: right;"><span class="fa fa-arrow-right"></span></li>
            </ul>
            <!-- end menu -->
            @Html.Partial("~/Views/Objects/B3_Detail.vbhtml")
            <div id="splitter-center-panels" data-bind="visible: B3_Visible" class="k-scrollable">
                @Html.Partial("~/Views/Objects/B3_Urgency.vbhtml")
                @Code
                Select Case Html.CurAction
                    Case "News"
                    @Html.Partial("~/Views/Objects/B3_Seznam.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DetailSpisu.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DoslePlatby.vbhtml")
                    Case "PersonalVisit"
                    @Html.Partial("~/Views/Objects/B3_DetailSpisu.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Kontakty.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DoslePlatby.vbhtml")                 
                    @Html.Partial("~/Views/Objects/B3_DalsiOsoby.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Dokumentace.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Historie.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Seznam.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Terminy.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Specifikace.vbhtml")
                    Case "Agreements"
                    @Html.Partial("~/Views/Objects/B3_DoslePlatby.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DetailSpisu.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Kontakty.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DalsiOsoby.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Dokumentace.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Historie.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Seznam.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Terminy.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Specifikace.vbhtml")
                    Case "ToProcess"
                    @Html.Partial("~/Views/Objects/B3_DetailSpisu.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Kontakty.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DoslePlatby.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_DalsiOsoby.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Dokumentace.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Historie.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Seznam.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Terminy.vbhtml")
                    @Html.Partial("~/Views/Objects/B3_Specifikace.vbhtml")
                    Case "Finished"

                End Select
                End Code
            </div>
        </div>
                End If
    End Code
    <div id="splitter-right-pane" class="flex-body" style="overflow: hidden;">
        <!-- right top menu nav -->
        <ul data-role="menu"
            data-bind="events: { select: onSelect }">
            <li data-action="5"><a class="k-link"> </a></li>
        </ul>
        <!-- end menu -->
        <!-- action buttons list -->
        <div  class="actionbuttons" id="actionbuttons" style="height: 100%; width: 100%; overflow-x: hidden" class="k-scrollable">
            @Code
                Select Case Html.CurAction
                    Case "News"
                @<button data-role="button" data-action="3" data-bind="enabled: btnEnabled.btn3.enabled, events: { click: action }">@Language.actbtnTXT5</button>
                @<button data-role="button" data-action="1" data-bind="events: { click: action }">@Language.actbtnTXT1</button>
                @<button data-role="button" data-action="2" data-bind="enabled: btnEnabled.btn2.enabled, events: { click: action }">@Language.actbtnTXT2</button>
                @<button data-role="button" data-action="4" data-bind="enabled: btnEnabled.btn4.enabled, events: { click: action }">@Language.actbtnTXT4</button>
                    Case "PersonalVisit"
                
                @<button data-role="button" data-action="5" data-bind="enabled: btnEnabled.btn5.enabled, events: { click: action }">@Language.actbtnTXT5</button>
                        'kontakt s dluznikem
                @<button data-role="button" data-action="6" data-bind="enabled: btnEnabled.btn6.enabled, events: { click: action }"><i data-bind="    visible: pencilVisible" class="fa fa-pencil" style="float:left;"></i>@Language.actbtnTXT6</button>
                        'zapis OSN
                @<button data-role="button" data-action="7" data-bind="enabled: btnEnabled.btn7.enabled, events: { click: action }"><i data-bind="visible: pencilVisible" class="fa fa-pencil" style="float:left;"></i>@Language.actbtnTXT7</button>
                
                @<button data-role="button" data-action="8" data-bind="enabled: btnEnabled.btn8.enabled, events: { click: action }">@Language.actbtnTXT8 </button>
                
                @<button data-role="button" data-action="9" data-bind="enabled: btnEnabled.btn9.enabled, events: { click: action }">@Language.actbtnTXT9</button>
                
                @<button data-role="button" data-action="10" data-bind="enabled: btnEnabled.btn10.enabled, events: { click: action }">@Language.actbtnTXT10</button>
                
                @<button data-role="button" data-action="11" data-bind="events: { click: action }">@Language.actbtnTXT11</button>
                
                @<button data-role="button" data-action="12" data-bind="events: { click: action }">@Language.actbtnTXT12</button>
                
                @<button data-role="button" data-action="13" data-bind="events: { click: action }">@Language.actbtnTXT13</button>@* 
                
                @<button data-role="button" data-action="14" disabled data-bind="events: { click: action }">@Language.actbtnTXT14</button>
                
                @<button data-role="button" data-action="15" data-bind="enabled: btnEnabled.btn15.enabled, events: { click: action }">@Language.actbtnTXT15</button>*@
                    Case "Agreements"
                
                @<button data-role="button" data-action="16" data-bind="enabled: btnEnabled.btn16.enabled, events: { click: action }">@Language.actbtnTXT16</button>
                
                @<button data-role="button" data-action="17" data-bind="enabled: btnEnabled.btn17.enabled, events: { click: action }">@Language.actbtnTXT17</button>
                
                @<button data-role="button" data-action="18" data-bind="enabled: btnEnabled.btn18.enabled, events: { click: action }">@Language.actbtnTXT18</button>
                
                @<button data-role="button" data-action="19" data-bind="enabled: btnEnabled.btn19.enabled, events: { click: action }">@Language.actbtnTXT19</button>
                
                @<button data-role="button" data-action="20" data-bind="enabled: btnEnabled.btn20.enabled, events: { click: action }">@Language.actbtnTXT20</button>
                
                @<button data-role="button" data-action="21" data-bind="enabled: btnEnabled.btn21.enabled, events: { click: action }">@Language.actbtnTXT21</button>
                
                @<button data-role="button" data-action="22" data-bind="events: { click: action }">@Language.actbtnTXT22</button>
                
                @<button data-role="button" data-action="23" data-bind="events: { click: action }">@Language.actbtnTXT23</button>
                
                @<button data-role="button" data-action="24" data-bind="events: { click: action }">@Language.actbtnTXT24</button>@*
                
                @<button data-role="button" data-action="25" disabled data-bind="events: { click: action }">@Language.actbtnTXT25</button>
                
                @<button data-role="button" data-action="26" disabled data-bind="events: { click: action }">@Language.actbtnTXT26</button>*@
                    Case "ToProcess"
                
                @<button data-role="button" data-action="27" data-bind="enabled: btnEnabled.btn27.enabled, events: { click: action }">@Language.actbtnTXT27</button>
                
                @<button data-role="button" data-action="28" data-bind="enabled: btnEnabled.btn28.enabled, events: { click: action }">@Language.actbtnTXT28</button>
                
                @<button data-role="button" data-action="29" data-bind="enabled: btnEnabled.btn29.enabled,  events: { click: action }">@Language.actbtnTXT29</button>
                
                @<button data-role="button" data-action="30" data-bind="enabled: btnEnabled.btn30.enabled, events: { click: action }">@Language.actbtnTXT30</button>
                
                @<button data-role="button" data-action="31" data-bind="enabled: btnEnabled.btn31.enabled, events: { click: action }">@Language.actbtnTXT31</button>
                
                @<button data-role="button" data-action="32" data-bind="events: { click: action }">@Language.actbtnTXT32</button>
                
                @<button data-role="button" data-action="33" data-bind="events: { click: action }">@Language.actbtnTXT33</button>
                
                @<button data-role="button" data-action="34" data-bind="events: { click: action }">@Language.actbtnTXT34</button>@*
                
                @<button data-role="button" data-action="35" disabled data-bind="events: { click: action }">@Language.actbtnTXT35</button>
                
                @<button data-role="button" data-action="36" data-bind="enabled: btnEnabled.btn36.enabled, events: { click: action }">@Language.actbtnTXT36</button>*@
                    Case "Finished"
                
                @<button data-role="button" data-action="37" data-bind="enabled: btnEnabled.btn37.enabled, events: { click: action }">@Language.actbtnTXT37</button>
                End Select
            End Code
        </div>
        <!-- end buttons -->
    </div>
</div>
<!-- splitter end -->

<script>
    var urlID = '@Request.QueryString("id")'
    var dlID = null;
        @Code  
            Select Case Html.CurAction
                Case "News"
                @<text>
    if (!urlID) {
        var lastid = localStorage.getItem('lastid_novy');
        if (lastid) {
            urlID = lastid;
        }
    }
    var Spisy = '@Url.Action("vwA1_Novy", "Api/Service")';
    var SpisyDL = '@Url.Action("vwA2_DLNovy", "Api/Service")';
    var SpisyDLSub = '@Url.Action("vwA2_DLNovySub", "Api/Service")';
                 </text>
                Case "PersonalVisit"
                @<text>
    if (!urlID) {
        var lastid = localStorage.getItem('lastid_osn');
        if (lastid) {
            urlID = lastid;
        }
    }
    var Spisy = '@Url.Action("vwA1_OSN", "Api/Service")';
    var SpisyDL = '@Url.Action("vwA2_DLOSN", "Api/Service")';
    var SpisyDLSub = '@Url.Action("vwA2_DLOSNSub", "Api/Service")';
                 </text>
                Case "Agreements"
                @<text>
    if (!urlID) {
        var lastid = localStorage.getItem('lastid_dohody');
        if (lastid) {
            urlID = lastid;
        }
    }
    var Spisy = '@Url.Action("vwA1_Dohody", "Api/Service")';
    var SpisyDL = '@Url.Action("vwA2_DLDohody", "Api/Service")';
    var SpisyDLSub = '@Url.Action("vwA2_DLDohodySub", "Api/Service")';
                 </text>
                Case "ToProcess"
                @<text>
    if (!urlID) {
        var lastid = localStorage.getItem('lastid_kezprac');
        if (lastid) {
            urlID = lastid;
        }
    }
    var Spisy = '@Url.Action("vwA1_KeZprac", "Api/Service")';
    var SpisyDL = '@Url.Action("vwA2_DLKeZprac", "Api/Service")';
    var SpisyDLSub = '@Url.Action("vwA2_DLKeZpracSub", "Api/Service")';
                 </text>
                Case "Finished"
                @<text>
    if (!urlID) {
        var lastid = localStorage.getItem('lastid_dokoncene');
        if (lastid) {
            urlID = lastid;
        }
    }
    var Spisy = '@Url.Action("vwA1_Finished", "Api/Service")';
    </text>
            End Select
    End Code

    var vwrr_PersType = [
    @Code
        For Each i In New Trace.TRACEEntities().vwrr_PersTypeMini
            @<text>{ text: "@Html.Raw(i.PersTypeTxt)", value: parseInt("@Html.Raw(i.rr_PersTypeMini)") },</text>
        Next
    End Code
        ];

    var apiUrl = '@Url.Action("/", "Api/Service")';
   //datovy model
    var viewModel = kendo.observable({
        onSelect: function (e) {
            menuCommand_Select(e, this);
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
                if (act !== 1 && act !== 13 && act !== 24 && act !== 34 && act !== 11 && act !== 12 && act !== 22 && act !== 23 && act !== 32 && act !== 33) {
                    if (!$(grid.select()).find(".checkrow").is(':checked')) {
                        CustomConfirm("@Html.Raw(SystemMessages.Warning)", "@Html.Raw(SystemMessages.NoCheckedItem)", function (result) {
                            if (result) {
                                setAct(source, this);
                            }
                            return false
                        });
                    } else {
                        setAct(source, this);
                    };
                } else {
                    setAct(source, this);
                }
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
                switch (act) {
                    case 1: //prijmout vse
                        items = viewModel.Spisy.data();
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        CustomConfirm("@Html.Raw(Language.actbtnTXT1)", "@Html.Raw(Language.TakeAllMsg)", function (result) {
                            if (result) {
                                Run_11to30(items, function () {
                                    source.fetch();
                                });
                            }
                        })
                        break;
                    case 2: //prijmout vybrane
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        Run_11to30(items, function () {
                            source.fetch();
                        });
                        break;
                    case 3: //naplanovat datum OSN
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        var url = "";
                        if (model.Spisy_visible) {
                            url = "@Url.Action("vwA1_NovyPodleIDSpisyOsoby", "Api/Service")";
                        } else {
                            url = "@Url.Action("vwA2_DLNovySubPodleIDSpisyOsoby", "Api/Service")";
                        }
                        showOSNDatePlan(new Date(), null, false, function (date, nochange, name) {
                            DatePlanProcess(items, date, nochange, name, function (result) {
                                $.each(items, function (i, e) {
                                    kendo.ui.progress($("body"), true);
                                    $.get(url, { IDSpisyOsoby: e.IDSpisyOsoby }, function (result) {
                                        $.each(result.Data, function (a, b) {
                                            var item = source.get(b.IDSpisu);
                                            if (item) {
                                                item.set("AlertExist", b.AlertExist);
                                                item.set("VisitDatePlan", date);
                                            }
                                        });
                                        kendo.ui.progress($("body"), false);
                                    });
                                });
                            });
                        });
                        break;
                    case 4: //vratit a dalsi
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        var id = items[0].IDSpisu;
                        showFileReturn(function (m, c) {
                            $.get("@Url.Action("Run_11to20", "Api/Service")", { iDSpisu: id, recordCommentType: m, recordCommentTxt: c }, function (result) {
                                if (result.MsgType === "error") {
                                    message(result.MsgType, "error");
                                }
                                source.fetch();
                            });
                        });
                        break;
                    case 5: //naplanovat datum OSN
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        var url = "";
                        if (model.Spisy_visible) {
                            url = "@Url.Action("vwA1_OSNPodleIDSpisyOsoby", "Api/Service")";
                        } else {
                            url = "@Url.Action("vwA2_DLOSNSubPodleIDSpisyOsoby", "Api/Service")";
                        }
                        showOSNDatePlan(new Date(), null, false, function (date, nochange, name) {
                            DatePlanProcess(items, date, nochange, name, function (result) {
                                $.each(items, function (i, e) {
                                    $.get(url, { IDSpisyOsoby: e.IDSpisyOsoby }, function (result) {
                                        $.each(result.Data, function (a, b) {
                                            var item = source.get(b.IDSpisu);
                                            if (item) {
                                                if (!item.get("VisitDatePlanNoChange")) {
                                                    item.set("AlertExist", b.AlertExist);
                                                    if (model.Spisy_visible) {
                                                        item.set("DateOSNPlan", date);
                                                    } else {
                                                        item.set("DateOSNPlane", date);
                                                    }
                                                }
                                            }
                                        });
                                        kendo.ui.progress($("body"), false);
                                    });
                                });
                            });
                        });
                        break;
                    case 6: //OSN kontakt s dluznikem
                        var data = {
                            iDSpisu: items[0].IDSpisu,
                            model: null,
                            command: 2,
                            process: 1
                        }
                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                            if (result.State === 4) {
                                CustomConfirm("@Html.Raw(Language.Key_Upozorneni)", "@Html.Raw(Language.Key_MateRozepsanZapis_PokracovatVTomtoZapisuD)", function (bol) {
                                    if (bol) {
                                        window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                    } else {
                                        data.command = 3
                                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                                            SelectContactType(result.IDSpisu, result.IDSpisyOsoby, result.ACC);
                                        });
                                    };
                                });
                            } else {
                                SelectContactType(result.IDSpisu, result.IDSpisyOsoby, result.ACC);
                            }
                        });
                        break;
                    case 7: //zapis z OSN
                        var data = {
                            iDSpisu: items[0].IDSpisu,
                            model: null,
                            command: 2,
                            process: 1
                        }
                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                            if (result.State === 4) {
                                CustomConfirm("@Html.Raw(Language.Key_Upozorneni)", "@Html.Raw(Language.Key_MateRozepsanZapisC_)" + result.ACC + "@Html.Raw(Language.Key__PokracovatVTomtoZapisuD)", function (bol) {
                                    if (bol) {
                                        window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                    } else {
                                        data.command = 3
                                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                                            window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                        });
                                    };
                                });
                            } else {
                                window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                            }
                        });
                        break;
                    case 8: //OSN presun ke zpracovani
                        var iDSpisu = items[0].IDSpisu;
                        ValidaceAdresDialog(iDSpisu, true, function (result) {
                            model.Spisy.read();
                            model.SpisyDL.read();
                        });
                        break;
                    case 9: //OSN presun ke zpracovani
                        var arr = $.grep(items, function (n, i) {
                            return (n.DateOSNPlan instanceof Date);
                        });
                        if (arr.length > 0) {
                            message("   @Html.Raw(Language.isDPlan) ", "warning", 10000);
                            return false;
                        }
                        var opt = {
                            SpisC: null,
                            Dluznik: null,
                            Duvod: null
                        }
                        if (items.length > 1) {
                            opt.SpisC = items[0].ACC + ", " + items[1].ACC + " ...";
                            opt.Dluznik = items[0].PersSurname + " " + items[0].PersName + ", " + items[1].PersSurname + " " + items[1].PersName + " ...";
                        } else if (items.length === 1) {
                            opt.SpisC = items[0].ACC;
                            opt.Dluznik = items[0].PersSurname + " " + items[0].PersName;
                        } else {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        };
                        showOSNTransferToProcesing(opt, function (Date, Value, Comment) {
                            Run_30to5x(items, {
                                iDspisu: 0,
                                rr_CaseNextActivity: Value,
                                reminderDeadline: kendo.toString(Date, "yyyy-MM-dd HH:mm:ss"),
                                caseNextActivityComment: Comment
                            }, function (result) {
                                source.fetch();
                            })
                        })
                        break;
                    case 10: //OSN uzavrit spis
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        var IDSpisu = items[0].IDSpisu;
                        $.get("@Url.Action("sp_Get_AllAddressOfDebitor", "Api/Service")", { iDSpisu: IDSpisu }, function (result) {
                            var warning = ""
                            warning += (result.Total > 1 ? "@Html.Raw(Language.PredUzavrenimSpisu_MSG1)" : "");
                            warning += (result.CountOfFV === 0 ? "@Html.Raw(Language.PredUzavrenimSpisu_MSG2)" : "");
                            if (result.Total > 1 || result.CountOfFV === 0) {
                                PredUzavrenimSpisu(result.Data, warning, function (yesNo) {
                                    if (yesNo) {
                                        Get_ListOfOtherCase();
                                    }
                                });
                            } else {
                                Get_ListOfOtherCase();
                            }
                        });

                        function Get_ListOfOtherCase() {
                            $.get('@Url.Action("Get_ListOfOtherCase", "Api/Service")', { iDSpisu: IDSpisu }, function (result) {
                                closingFilesDialog(IDSpisu, result.Data, function (ids, comment) {
                                    closingFiles(ids, comment, viewModel, function () {
                                        source.fetch();
                                    });
                                })
                            });
                        }
                        break;
                    case 11: //PŘIPOMÍNKA KE SPISU
                        //1 spis, 2 DL
                        novaPripominka(1, items, viewModel)
                        break;
                    case 12: //PŘIPOMÍNKA K DLUŽNÍKOVI
                        //1 spis, 2 DL
                        novaPripominka(2, items, viewModel)
                        break;
                    case 13: //PŘEHLED PŘIPOMÍNEK
                        //1 zalozka
                        UrgRemindMsg(3)
                        break;
                    case 15: //OSN tisk

                        break;
                    case 16: //Kontakt s DL
                        var data = {
                            iDSpisu: items[0].IDSpisu,
                            model: null,
                            command: 2,
                            process: 1
                        }
                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                            if (result.State === 4) {
                                CustomConfirm("@Html.Raw(Language.Key_Upozorneni)", "@Html.Raw(Language.Key_MateRozepsanZapis_PokracovatVTomtoZapisuD)", function (bol) {
                                    if (bol) {
                                        window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                    } else {
                                        data.command = 3
                                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                                            SelectContactType(result.IDSpisu, result.IDSpisyOsoby, result.ACC);
                                        });
                                    };
                                });
                            } else {
                                SelectContactType(result.IDSpisu, result.IDSpisyOsoby, result.ACC);
                            }
                        });
                        break;
                    case 17: //Zrusit SK
                        var data = {
                            iDSpisu: items[0].IDSpisu,
                            model: null,
                            command: 2,
                            process: 1
                        }
                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                            if (result.State === 4) {
                                CustomConfirm("@Html.Raw(Language.Key_Upozorneni)", "@Html.Raw(Language.Key_MateRozepsanZapis_PokracovatVTomtoZapisuD)", function (bol) {
                                    if (bol) {
                                        window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                    } else {
                                        data.command = 3
                                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                                            window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + 4, '_blank');
                                        });
                                    };
                                });
                            } else {
                                window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + 4, '_blank');
                            }
                        });
                        break;
                    case 18: //zapis OSN
                        var data = {
                            iDSpisu: items[0].IDSpisu,
                            model: null,
                            command: 2,
                            process: 1
                        }
                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                            if (result.State === 4) {
                                CustomConfirm("@Html.Raw(Language.Key_Upozorneni)", "@Html.Raw(Language.Key_MateRozepsanZapis_PokracovatVTomtoZapisuD)", function (bol) {
                                    if (bol) {
                                        window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                    } else {
                                        data.command = 3
                                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                                            window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                        });
                                    };
                                });
                            } else {
                                window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                            }
                        });
                        break;
                    case 19: //
                        var iDSpisu = items[0].IDSpisu;
                        ValidaceAdresDialog(iDSpisu, true, function (result) {
                            model.Spisy.read();
                            model.SpisyDL.read();
                        });
                        break;
                    case 20: //HOTOVOSTNÍ VÝBĚR
                        var data = {
                            iDSpisu: items[0].IDSpisu,
                            model: null,
                            command: 2,
                            process: 1
                        }
                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                            if (result.State === 4) {
                                CustomConfirm("@Html.Raw(Language.Key_Upozorneni)", "@Html.Raw(Language.Key_MateRozepsanZapis_PokracovatVTomtoZapisuD)", function (bol) {
                                    if (bol) {
                                        window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                    } else {
                                        data.command = 3
                                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                                            window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + 6, '_blank');
                                        });
                                    };
                                });
                            } else {
                                window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + 6, '_blank');
                            }
                        });
                        break;
                    case 21: //Dohody presun k OSN
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        showDohodyMoveToOSN(new Date(), null, function (Date, Comment, nochange, name) {
                            kendo.ui.progress($("body"), true);
                            $.get("@Url.Action("MoveToOSNFromDohody", "Api/Service")", { iDspisu: items[0].IDSpisu, C: Comment, D: kendo.toString(Date, "yyyy-MM-dd HH:mm:ss"), nochange: nochange, name: name }, function (result) {
                                kendo.ui.progress($("body"), false);
                                source.fetch();
                            });
                        });
                        break;
                    case 22: //PŘIPOMÍNKA KE SPISU
                        //1 spis, 2 DL
                        novaPripominka(1, items, viewModel)
                        break;
                    case 23: //PŘIPOMÍNKA K DLUŽNÍKOVI
                        //1 spis, 2 DL
                        novaPripominka(2, items, viewModel)
                        break;
                    case 24: //PŘEHLED PŘIPOMÍNEK
                        //1 zalozka
                        UrgRemindMsg(4)
                        break;
                    case 27: //KONTAKT S DLUŽNÍKEM
                        var data = {
                            iDSpisu: items[0].IDSpisu,
                            model: null,
                            command: 2,
                            process: 1
                        }
                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                            if (result.State === 4) {
                                CustomConfirm("@Html.Raw(Language.Key_Upozorneni)", "@Html.Raw(Language.Key_MateRozepsanZapis_PokracovatVTomtoZapisuD)", function (bol) {
                                    if (bol) {
                                        window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                    } else {
                                        data.command = 3
                                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                                            SelectContactType(result.IDSpisu, result.IDSpisyOsoby, result.ACC);
                                        });
                                    };
                                });
                            } else {
                                SelectContactType(result.IDSpisu, result.IDSpisyOsoby, result.ACC);
                            }
                        });
                        break;
                    case 28:
                        var data = {
                            iDSpisu: items[0].IDSpisu,
                            model: null,
                            command: 2,
                            process: 1
                        }
                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                            if (result.State === 4) {
                                CustomConfirm("@Html.Raw(Language.Key_Upozorneni)", "@Html.Raw(Language.Key_MateRozepsanZapis_PokracovatVTomtoZapisuD)", function (bol) {
                                    if (bol) {
                                        window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                    } else {
                                        data.command = 3
                                        $.get('@Url.Action("sp_Get_FieldVisitObject", "Api/Service")', data, function (result) {
                                            window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                                        });
                                    };
                                });
                            } else {
                                window.open('@Url.Action("Registration", "Home")?iDSpisu=' + result.IDSpisu + '&iDSpisyOsoby=' + result.IDSpisyOsoby + '&ACC=' + result.ACC + '&Process=' + result.Process, '_blank');
                            }
                        });
                        break;
                    case 29: //
                        var iDSpisu = items[0].IDSpisu;
                        ValidaceAdresDialog(iDSpisu, true, function (result) {
                            model.Spisy.read();
                            model.SpisyDL.read();
                        });
                        break;
                    case 30: //Ke zpracovani presun k OSN
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        showOSNDatePlan(new Date(), null, false, function (Date, nochange, name) {
                            MoveToOSN(items, Date, nochange, name, function (result) {
                                source.fetch();
                            });
                        });
                        break;
                    case 31: //Ke zpracovani uzavrit spis
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        var IDSpisu = items[0].IDSpisu;
                        $.get("@Url.Action("sp_Get_AllAddressOfDebitor", "Api/Service")", { iDSpisu: IDSpisu }, function (result) {
                            var warning = ""
                            warning += (result.Total > 1 ? "@Html.Raw(Language.PredUzavrenimSpisu_MSG1)" : "");
                            warning += (result.CountOfFV === 0 ? "@Html.Raw(Language.PredUzavrenimSpisu_MSG2)" : "");
                            if (result.Total > 1 || result.CountOfFV === 0) {
                                PredUzavrenimSpisu(result.Data, warning, function (yesNo) {
                                    if (yesNo) {
                                        Get_ListOfOtherCase();
                                    }
                                });
                            } else {
                                Get_ListOfOtherCase();
                            }
                        });

                        function Get_ListOfOtherCase() {
                            $.get('@Url.Action("Get_ListOfOtherCase", "Api/Service")', { iDSpisu: IDSpisu }, function (result) {
                                closingFilesDialog(IDSpisu, result.Data, function (ids, comment) {
                                    closingFiles(ids, comment, viewModel, function () {
                                        source.fetch();
                                    });
                                })
                            });
                        }
                        break;
                    case 32: //PŘIPOMÍNKA KE SPISU
                        //1 spis, 2 DL
                        novaPripominka(1, items, viewModel);
                        break;
                    case 33: //PŘIPOMÍNKA K DLUŽNÍKOVI
                        //1 spis, 2 DL
                        novaPripominka(2, items, viewModel);
                        break;
                    case 34: //PŘEHLED PŘIPOMÍNEK
                        //1 zalozka
                        UrgRemindMsg(5);
                        break;
                    case 37: //Ukoncene zados o vraceni spisu
                        if (items.length === 0) {
                            message("   @Html.Raw(SystemMessages.NoItems) ", "info");
                            return false;
                        }
                        showReqFileReturn(function (c) {
                            $.get('@Url.Action("FinishedPostEmail", "Api/Service")', { iDSpisu: items[0].IDSpisu, comment: c }, function (result) {
                                if (result.MsgType === "error") {
                                    message("   " + result.Msg[0] + " ", "error");
                                } else {
                                    message("   @Html.Raw(Language.FinishedMailSuccess) ", "success");
                                }
                                source.fetch();
                            });
                        })
                        break;
                };
            };
        },
        pencilVisible: false,
        onResize: function (e) {
            $(window).resize();
        },
        onExpand: function (e) {
            var id = e.pane.id;
            if (id == "splitter-left-pane") {
                $("li[data-action=3] .fa").removeClass("fa-arrow-right").addClass("fa-arrow-left");
            } else {
                $("li[data-action=4] .fa").removeClass("fa-arrow-left").addClass("fa-arrow-right");
            }
        },
        onCollapse: function (e) {
            var id = e.pane.id;
            if (id == "splitter-left-pane") {
                $("li[data-action=3] .fa").removeClass("fa-arrow-left").addClass("fa-arrow-right");
            } else {
                $("li[data-action=4] .fa").removeClass("fa-arrow-right").addClass("fa-arrow-left");
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
            urlID = iDSpisu;

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
                    viewModel.Spisy.read();
                    viewModel.SpisyDL.read();
                });
            });
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
        Spisy_visible: options.visible1,
        SpisyDL_visible: options.visible2,
        @Code
                Select Case Html.CurAction
                    Case "News"
                        @Html.FileRender("~/Scripts/vwA1_Novy.js")
                        @Html.FileRender("~/Scripts/vwA2_DLNovy.js")
                        @Html.FileRender("~/Scripts/vwA2_DLNovySub.js")
                    Case "PersonalVisit"
                        @Html.FileRender("~/Scripts/vwA1_OSN.js")
                        @Html.FileRender("~/Scripts/vwA2_DLOSN.js")
                        @Html.FileRender("~/Scripts/vwA2_DLOSNSub.js")
                    Case "Agreements"
                        @Html.FileRender("~/Scripts/vwA1_Dohody.js")
                        @Html.FileRender("~/Scripts/vwA2_DLDohody.js")
                        @Html.FileRender("~/Scripts/vwA2_DLDohodySub.js")
                    Case "ToProcess"
                        @Html.FileRender("~/Scripts/vwA1_KeZprac.js")
                        @Html.FileRender("~/Scripts/vwA2_DLKeZprac.js")
                        @Html.FileRender("~/Scripts/vwA2_DLKeZpracSub.js")
                    Case "Finished"
                        @Html.FileRender("~/Scripts/vwA1_Finished.js")
                End Select
            End Code
        B3_Visible: true,
        B3_Filter: function (iDSpisu, iDSpisyOsoby, iDSpisyOsobyZam) {
            var model = this;
            try {
                var allProcess = [];
                kendo.ui.progress($("#splitter-center-pane"), true);
                $.get('@Url.Action("sp_Get_CreditorDetail_G2", "Api/Service")', { iDSpisu: iDSpisu, zalozka: '@Html.CurAction' }, function (result) {
                    if (result.Data.length > 0) {
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
                    } else {
                        model.set("B3_Detail", []);
                    }
                });

                if (iDSpisu === 0) {
                    model.set("B3_Visible", false);
                    kendo.ui.progress($("#splitter-center-pane"), false);
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
                                "NCPhoneValid": { type: "number" },
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
                    kendo.ui.progress($("#splitter-center-pane"), false);
                }).done(function () {
                    kendo.ui.progress($("#splitter-center-pane"), false);
                });
            } catch (ex) {
                kendo.ui.progress($("#splitter-center-pane"), false);
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

            $.get('@Url.Action("sp_B3_OsobyAddress", "Api/Service")', { iDSpisu: di.IDSpisu, iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                if (result.Data) { model.set("B3_OsobyAddress", result.Data); }
                $.get('@Url.Action("sp_B3_OsobyEmail", "Api/Service")', { iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                    if (result.Data) { model.set("B3_OsobyEmail", result.Data); }
                    $.get('@Url.Action("sp_B3_OsobyPhone", "Api/Service")', { iDSpisyOsoby: di.IDSpisyOsoby }, function (result) {
                        if (result.Data) { model.set("B3_OsobyPhone", result.Data); }
                        kendo.bind($(e.detailCell), model);
                    })
                })
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
        DocuGetPDF: function (e) {
            kendo.ui.progress($("#splitter-center-pane"), true);
            $.get("@Url.Action("B3_Dokumentace_PDFExist", "Base")", { IDSpisyDocument: e.data.IDSpisyDocument }, function (result) {
                if (result > 0) {
                    window.open('@Url.Action("B3_Dokumentace_GetPDF", "Base")' + '?IDSpisyDocument=' + e.data.IDSpisyDocument, '_blank');
                } else {
                    message("@Html.Raw(SystemMessages.FileNotFound) ", "info");
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

    function novaPripominka(type, selected, model) {
        IPVytvoreniUpominky(type, selected, function (promises) {
            total = promises.length;
            if (promises) {
                progress(promises, total, function (e) {
                    model.Spisy.read();
                    model.SpisyDL.read();
                });
            }
        })
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
    }

    $(function () {
        kendo.bind($("#splitter"), viewModel);
        viewModel.bind("change", function (e) {
            if (e.field === "Spisy_visible" || e.field === "SpisyDL_visible") {
                settings.visible1 = viewModel["Spisy_visible"];
                settings.visible2 = viewModel["SpisyDL_visible"];
            }
        });

        //nastaveni sorteni podzalozek
        $("#splitter-center-panels").kendoSortable({
            axis: "y",
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
    })
            

    function SetVisitDatePlanNoChange(iDSpisu, visitDatePlanNoChange, callback) {
        $.get('@Url.Action("sp_Do_SetVisitDatePlanNoChange", "Api/Service")', { iDSpisu: iDSpisu, visitDatePlanNoChange: visitDatePlanNoChange }, function (result) {
            callback(result);
        });
    };

        //stav akcnich tlacitek
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

    function closingFiles(ids, comment, model, callback) {
        var allProcess = [];
        var total = ids.length;
        var counter = 1;
        $.each(ids, function (i, e) {
            allProcess.push($.get("@Url.Action("Run_xxto61", "Api/Service")", { iDSpisu: e, rr_ClosedFile: 0, comment: comment }, function (result) {
                var value = parseFloat(parseInt(counter, 10) * 100) / parseInt(total, 10);
                progressModel.set("progressValue", value);
                counter++
            }));
        })
        winProgressBarDialog.open().center();
        $.when.apply($, allProcess).done(function () {
            callback();
        });
    };

    function listUrgAndReminder(id, ids, dl, model) {
        if (ids.hasOwnProperty(id)) {
            if (ids[id]) {
                $.get('@Url.Action("vw_ListReminders", "Api/Service")', { iDSpisu: id }, function (result) {
                    var arr = {};
                    $.each(ids, function (i, e) {
                        if (parseInt(i) !== id) {
                            arr[i] = e;
                            return false;
                        }
                    });
                    var i = parseInt(Object.keys(arr)[0]);
                    if (isNaN(i)) {
                        i = 0;
                    }
                    if (result.Data.length > 0) {
                        showListUrgAndRemind(result.Data, function (bol) {
                            if (bol) {
                                showOSNConclude(dl, function (a, b) {
                                    $.get("@Url.Action("Run_xxto61", "Api/Service")", { iDSpisu: id, rr_ClosedFile: a, comment: b }, function (result) {
                                        listUrgAndReminder(i, arr, dl, model);
                                    });
                                });
                            } else {
                                listUrgAndReminder(i, arr, dl, model);
                            }
                        })
                    } else {
                        showOSNConclude(dl, function (a, b) {
                            $.get("@Url.Action("Run_xxto61", "Api/Service")", { iDSpisu: id, rr_ClosedFile: a, comment: b }, function (result) {
                                listUrgAndReminder(i, arr, dl, model);
                            });
                        });
                    }
                });
            };
        } else {
            model.Spisy.fetch();
            model.SpisyDL.fetch();
        }
    };

        //presun k OSN
    function MoveToOSN(items, dat, nochange, name, callback) {
            var allProcess = [];
            var total = items.length;
            var counter = 1;
            progressModel.set("progressLogVisible", false);
            $.each(items, function (i, item) {
                allProcess.push($.get('@Url.Action("Run_5xto30", "Api/Service/")', { iDspisu: item.IDSpisu, Dat: kendo.toString(dat, "yyyy-MM-dd HH:mm:ss"), nochange: nochange }, function (result) {
                    var value = parseFloat(parseInt(counter, 10) * 100) / parseInt(total, 10);
                    progressModel.set("progressValue", value);
                    if (result.MsgType === "error") {
                        $.each(result.Msg, function (i, e) {
                            progressModel.progressLog.insert(0, { state: result.MsgType, text: e });
                        })
                    }
                    counter++
                }));
            });
            winProgressBarDialog.open().center();
            $.when.apply($, allProcess).done(function () {
                callback(true)
            });
        }

        //naplanovat datum osn
    function DatePlanProcess(items, dat, nochange, name, callback) {
        var allProcess = [];
        var total = items.length;
        var counter = 0;
        progressModel.set("progressLogVisible", false);
        $.each(items, function (i, item) {
            jQuery.ajax({
                url: "@Url.Action("Run_xxtoDateFV", "Api/Service")",
                type: "GET",
                async: false,
                data: { "id": item.IDSpisu, "dat": kendo.toString(dat, "yyyy-MM-dd 00:00:00"), "nochange": nochange, "name": name },
                success: function (result) {
                    var value = parseFloat(parseInt(counter, 10) * 100) / parseInt(total, 10);
                    progressModel.set("progressValue", value);

                    if (result.MsgType === "error") {
                        progressModel.set("progressLogVisible", true);
                        progressModel.progressLog.insert(0, { state: result.MsgType, text: result.Msg[0] });
                    }
                    counter++
                    if (counter === total) {
                        progressModel.set("progressValue", 100);
                        callback(true);
                    }
                }
            });
        });
        winProgressBarDialog.open().center();
    };
        //OSN presun ke zpracovani
        function Run_30to5x(items, parameters, callback) {
            var allProcess = [];
            var total = items.length;
            var counter = 1;
            progressModel.set("progressLogVisible", false);
            $.each(items, function (i, item) {
                parameters.iDspisu = item.IDSpisu;
                allProcess.push($.get('@Url.Action("Run_30to5x", "Api/Service/")', parameters, function (result) {
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
        //povyseni stavu 11to30
    function Run_11to30(items, callback) {
        var allProcess = [];
        var total = items.length;
        var counter = 1;
        progressModel.set("progressLogVisible", false);
        $.each(items, function (i, item) {
            allProcess.push($.get('@Url.Action("Run_11to30", "Api/Service/")', { id: item.IDSpisu }, function (result) {
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

    function placeholder(element) {
        return element.clone().addClass("placeholder");
    };

    function hint(element) {
        return element.clone().addClass("hint")
                    .height(element.height() + 18)
                    .width(element.width());
    };

        //udalosti tlacitek ve vrchnim menu splitteru
    function menuCommand_Select(e, model) {
        var ul = $(e.item).closest("ul");
        var action = $(e.item).data("action");
        var splitter = $("#splitter").data("kendoSplitter");
        var panel = null,
            expcol = $(e.item).find(".fa");
        try {
            switch (action) {
                case 1:
                    ul.find("li").removeClass("k-state-selected");
                    $(e.item).addClass("k-state-selected");
                    model.set("Spisy_visible", true);
                    model.set("SpisyDL_visible", false);
                    model.Spisy.fetch();
                    $(window).resize();
                    break;
                case 2:
                    ul.find("li").removeClass("k-state-selected");
                    $(e.item).addClass("k-state-selected");
                    model.set("Spisy_visible", false);
                    model.set("SpisyDL_visible", true);
                    model.SpisyDL.fetch();
                    $(window).resize();
                    break;
                case 3:
                    panel = $("#splitter-left-pane");
                    if (panel.width() > 0) {
                        splitter["collapse"](panel);
                        expcol.removeClass("fa-arrow-left").addClass("fa-arrow-right");
                    } else {
                        splitter["expand"](panel);
                        expcol.removeClass("fa-arrow-right").addClass("fa-arrow-left");
                    };
                    break;
                case 4:
                    panel = $("#splitter-right-pane");
                    if (panel.width() > 0) {
                        splitter["collapse"](panel);
                        expcol.removeClass("fa-arrow-right").addClass("fa-arrow-left");
                    } else {
                        splitter["expand"](panel);
                        expcol.removeClass("fa-arrow-left").addClass("fa-arrow-right");
                    };
                    break;
                case 5:
                    break;
                case 6:
                    if (model.Spisy_visible) {
                        model.Spisy.filter({});
                        model.Spisy.sort({});
                    } else {
                        model.SpisyDL.filter({});
                        model.SpisyDL.sort({});
                    };
                    break;
                case 7:
                    panel1 = $("#splitter-right-pane");
                    panel2 = $("#splitter-center-pane");
                    if (panel1.width() > 0 && panel2.width() > 0) {
                        splitter["collapse"](panel1);
                        splitter["collapse"](panel2);
                        expcol.removeClass("fa-window-maximize").addClass("fa-window-restore");
                    } else {
                        splitter["expand"](panel2);
                        splitter["expand"](panel1);
                        expcol.removeClass("fa-window-restore").addClass("fa-window-maximize");
                    };
                    break;
                case 8:
                    var data = model.Spisy.view();
                    GPSValidAllAdress(data, function (result) {
                        progressModel.set("progressValue", 100);
                        model.Spisy.read();
                        model.SpisyDL.read();
                    });
                    break;
            };
        } catch (ex) {
            console.log(ex)
        }
    };

    function GPSValidAllAdress(data, callback) {
        var result = [];
        $.each(data, function (a, b) {
            if (b.GPSValidDetail === 0) {
                result.push(b);
            }
        });
        var total = result.length;
        var index = 0;
        var loop = function (arr) {
            try {
                var item = arr[index];
                var address = [(item.PersStreet ? item.PersStreet : "") + " " + (item.PersHouseNum ? item.PersHouseNum : ""), (item.PersCity ? item.PersCity : "") + " " + (item.PersZipCode ? item.PersZipCode : "")].join(", ")
                address = $.trim(address);
                //**********
                if (!progress_storno) {
                    globalValidAddress(address, function (adr, bol, msg, valid) {
                        var value = parseFloat(parseInt(index, 10) * 100) / parseInt(total, 10);
                        progressModel.set("progressValue", value);
                        index++

                        if (!bol) {
                            msg = item.ACC + " " + msg
                            progressModel.progressLog.insert(0, { state: 0, text: msg });
                        }

                        console.log(valid + " " + bol + " - " + address);

                        if (valid > 1) {
                            adr = {
                                street: "",
                                number: "",
                                city: "",
                                zip: "",
                                lat: "",
                                lng: "",
                                formatted_address: ""
                            }
                        };

                        $.post("@Url.Action("tblSpisyOsobyAdresy_Save", "Api/Service")", {
                        IDSpisyOsobyAdresy: item.IDSpisyOsobyAdresy,
                        PersStreet: adr.street,
                        PersHouseNum: adr.number,
                        PersCity: adr.city,
                        PersZipCode: adr.zip,
                        GPSLat: adr.lat,
                        GPSLng: adr.lng,
                        GPSValid: bol,
                        PersAddrFull: adr.formatted_address,
                        GPSValidDetail: valid
                    }, function (result) {
                    }).always(function () {
                        if (index < result.length) {
                            setTimeout(function () {
                                loop(arr);
                            }, 4000);
                        } else {
                            progressModel.set("progressValue", 100);
                            callback(status);
                        }
                    });
                });
            };
                //**********
            } catch (ex) { }
        }
        if (result.length > 0) {
            progressModel.set("progressLogVisible", true);
            progressModel.set("stornoVisible", true);
            progress_storno = false;
            winProgressBarDialog.open().center();
            loop(result);
        } else {
            message(" GPS souřadnice jsou překontrolované. Červeně označené GPS souřadnice je potřeba řešit ručně.", "warning", 5000)
        }
    };
</script>

@Html.Partial("~/Views/Objects/OSNDatePlanDialog.vbhtml")
@Html.Partial("~/Views/Objects/FileReturnDialog.vbhtml")
@Html.Partial("~/Views/Objects/OSNTransferToProcesingDialog.vbhtml")
@Html.Partial("~/Views/Objects/OSNConcludeDialog.vbhtml")
@Html.Partial("~/Views/Objects/NextFilesDialog.vbhtml")
@Html.Partial("~/Views/Objects/ListUrgAndRemind.vbhtml")
@Html.Partial("~/Views/Objects/DohodyMoveToOSNDialog.vbhtml")
@Html.Partial("~/Views/Objects/RequestReturnFile.vbhtml")
@Html.Partial("~/Views/Objects/ClosingFilesDialog.vbhtml")
@Html.Partial("~/Views/Objects/B3_OsobyDalsiKontakt_Edit.vbhtml")
@Html.Partial("~/Views/Objects/SelectContactType.vbhtml")
@Html.Partial("~/Views/Objects/PredUzavrenimSpisu.vbhtml")
@Html.Partial("~/Views/Objects/ValidaceAdresDialog.vbhtml")
@Html.Partial("~/Views/Objects/NewAddress.vbhtml")
@Html.Partial("~/Views/Objects/NewEMPAddress.vbhtml")
@Html.Partial("~/Views/Objects/IPVytvoreniUpominky.vbhtml")
@Html.Partial("~/Views/Objects/UrgRemindMsg.vbhtml")
