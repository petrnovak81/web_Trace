@Code
    ViewData("Title") = Language.layoutmasTXT10
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<style>
    /*#panelMenu .k-widget {
        background-color: rgba(255, 255, 255, 0.8);
    }*/

    #panelMenu .k-grid .k-grid-content {
        flex: auto;
    }

    #middle .k-dropdown, span.k-colorpicker {
        background-color: white;
    }

    showOSNDatePlan
    #middle .k-button {
        /*background-color: white;*/
    }

    [data-role="splitter"] {
    height:100%;
    }
</style>

<div id="splitter" class="flex-container"
     data-role="splitter"
     data-bind="events: { expand: onExpand, collapse: onCollapse }"
     data-panes="[
     { collapsible: true, scrollable: false, size: '450px' },
     { collapsible: true, scrollable: false, size: '350px' },
     { collapsible: true, scrollable: false }
    ]">
    <div id="left" style="display: flex; flex-direction: column;">
        <ul data-role="menu">
            <li>
                <span data-bind="text: curFilter">@Html.Raw(Language.TracingTXT1)</span>
                <ul>
                    <li data-filter="1" data-bind="events: { click: selectFilter }"><span>@Html.Raw(Language.TracingTXT2)</span><p style="margin:0;padding:0;font-size:8px;">@Html.Raw(Language.TracingTXT3)<br />@Html.Raw(Language.TracingTXT4)</p></li>
                    <li data-filter="3" data-bind="events: { click: selectFilter }"><span>@Html.Raw(Language.TracingTXT5)</span><p style="margin:0;padding:0;font-size:8px;">@Html.Raw(Language.Key_FiltrProVsechnySpisyZeZalozky) @Html.Raw(Language.TracingTXT5)</p></li>
                    <li data-filter="2" data-bind="events: { click: selectFilter }"><span>@Html.Raw(Language.TracingTXT7)</span><p style="margin:0;padding:0;font-size:8px;">@Html.Raw(Language.Key_FiltrProVsechnySpisyZeZalozky) @Html.Raw(Language.TracingTXT5)<br />@Html.Raw(Language.TracingTXT9)</p></li>
                    <li data-filter="6" data-bind="events: { click: selectFilter }"><span>@Html.Raw(Language.TracingTXT10)</span><p style="margin:0;padding:0;font-size:8px;">@Html.Raw(Language.TracingTXT11)<br />@Html.Raw(Language.TracingTXT12)</p></li>
                    <li data-filter="5" data-bind="events: { click: selectFilter }"><span>@Html.Raw(Language.TracingTXT13)</span><p style="margin:0;padding:0;font-size:8px;">@Html.Raw(Language.TracingTXT14)<br />@Html.Raw(Language.TracingTXT15)</p></li>
                </ul>
            </li>
            <li>
                <a href="#" class="k-link" data-bind="visible: btnAddEdit, events: { click: AddressAdd }"><span class="k-icon k-i-plus-circle"></span> @Html.Raw(Language.TracingTXT16)</a>
            </li>
            <li data-filter="4" data-bind="events: { click: selectFilter }"><span>@Html.Raw(Language.TracingTXT17)</span></li>
            <li data-bind="events: { click: expandTab }" style="float: right;">
                <i class="fa fa-window-maximize" aria-hidden="true"></i>
            </li>
            <li data-bind="events: { click: clearFilter }" style="float: right;">
                <span class="k-icon k-i-filter-clear"></span>
            </li>
        </ul>

        @Html.Partial("~/Views/Objects/vw_CampAddrALL.vbhtml")

    </div>
    <div id="center">
        <div data-role="splitter"
             data-orientation="vertical"
             data-panes="[
     { collapsible: true, scrollable: false },
     { collapsible: true, scrollable: false }
    ]">
            <div>
                <ul data-role="menu">
                    <li>
                        <span>@Html.Raw(Language.TracingTXT19)</span>
                    </li>
                </ul>
                @Html.Partial("~/Views/Objects/vw_Campaign.vbhtml")
            </div>
            <div>
                <ul data-role="menu">
                    <li>
                        <span>@Html.Raw(Language.TracingTXT20)</span>
                    </li>
                </ul>
                @Html.Partial("~/Views/Objects/vw_CampMember.vbhtml")
            </div>
        </div>
    </div>
    <div id="middle" style="display: flex; flex-direction: column; position: relative;">
        <ul data-role="menu" style="text-align: right;">
            <li data-bind="events: { click: toggleSplit }"><span id="leftPaneControl" class="fa fa-arrow-left"></span></li>
        </ul>
        <div id="panelMenu" style="position: absolute;padding: 10px;bottom: 0; width: 300px; z-index: 1; flex: 1; display: flex; flex-direction: column;">
            <div id="directionsPlanWin" style="flex: auto; display: flex; flex-direction: column;">
                <div class="k-header" style="padding: 6px;">
                    <span><b style="text-transform: uppercase">@Html.Raw(Language.TracingTXT18)</b></span>
                </div>
                <div id="directionsPlan" style="height: 100% ;overflow-y: auto;background-color:#fff"></div>
            </div>

            <div id="campPanel" style="flex: auto; display: flex; flex-direction: column;">
                <div class="k-content">
                    <table style="width: 100%; margin: 3px;">
                        <tr>
                            <td colspan="3" style="text-align: center; font-size: 14px; border-bottom: dashed 1px;"><b data-bind="text: vybranaKampan"></b></td>
                        </tr>
                        <tr>
                            <td style="width: 100px;"><b class="lt">@Html.Raw(Language.TracingTXT21)</b></td>
                            <td>:</td>
                            <td data-bind="text: start"></td>
                        </tr>
                        <tr>
                            <td><b class="lt">@Html.Raw(Language.TracingTXT22)</b></td>
                            <td>:</td>
                            <td data-bind="text: stop"></td>
                        </tr>
                        <tr>
                            <td><b class="lt">@Html.Raw(Language.TracingTXT23)</b></td>
                            <td>:</td>
                            <td data-bind="text: totalDistance"></td>
                        </tr>
                        <tr>
                            <td><b class="lt">@Html.Raw(Language.TracingTXT24)</b></td>
                            <td>:</td>
                            <td data-bind="text: totalDuration"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="styleMap" style="margin: 10px;">
            <button class="k-button k-primary" data-bind="events: { click: userTrace }" style="width: 100px" title="@Html.Raw(Language.TraceScriptTXT2)"><i class="fa fa-user" aria-hidden="true"></i> <i class="fa fa-car" aria-hidden="true"></i></button>
            <button class="k-button k-primary" data-bind="events: { click: optimalTrace }" style="width: 100px" title="@Html.Raw(Language.TraceScriptTXT3)"><i class="fa fa-google" aria-hidden="true"></i> <i class="fa fa-car" aria-hidden="true"></i></button>
            <button class="k-button k-primary" data-bind="events: { click: tracePlan }" style="width: 100px" title="@Html.Raw(Language.TracingTXT18)"><i class="fa fa-list-ol" aria-hidden="true"></i></button>
            <select data-role="dropdownlist" data-bind="events: { select: styleMapSelect }">
                <option value="default">@Html.Raw(Language.TracingTXT25)</option>
                <option value="silver">@Html.Raw(Language.TracingTXT26)</option>
                <option value="retro">@Html.Raw(Language.TracingTXT27)</option>
                <option value="dark">@Html.Raw(Language.TracingTXT28)</option>
                <option value="night">@Html.Raw(Language.TracingTXT29)</option>
                <option value="aubergine">@Html.Raw(Language.TracingTXT30)</option>
            </select>
        </div>
        <div id="mapcanvas" style="flex: auto;"></div>
    </div>
</div>

<style>
    .row-incamp {
        background-color: #007acc;
    }

        .row-incamp td {
            color: #fff;
        }

    .row-outcamp {
        background-color: grey;
    }

        .row-outcamp td {
            color: #fff;
        }

    #panelMenu {
        overflow: hidden;
        resize: horizontal;
    }
</style>

@Html.Partial("~/Views/Objects/OSNDatePlanDialog.vbhtml")
@Html.Partial("~/Views/Objects/TraceAddress_Edit.vbhtml")
@Html.Partial("~/Views/Objects/sp_Get_SpisyOfIDSpisyOsoby.vbhtml")
@Html.Partial("~/Views/Objects/PrintCampPDFsDialog.vbhtml")

<script>
    var viewModel = null;
    $(function () {
        viewModel = new kendo.observable({
            onExpand: function (e) {
                this.toggleSplit(e);
            },
            onCollapse: function (e) {
                this.toggleSplit(e);
            },
            toggleSplit: function (e) {
                var splitter = $("#splitter").data("kendoSplitter");
                var leftPane = $("#left");
                var campPane = $("#center");
                if (leftPane.width() > 0) {
                    splitter["collapse"](leftPane);
                    splitter["collapse"](campPane);
                    $("#leftPaneControl").toggleClass('fa-arrow-left fa-arrow-right');
                } else {
                    splitter["expand"](leftPane);
                    splitter["expand"](campPane);
                    $("#leftPaneControl").toggleClass('fa-arrow-right fa-arrow-left');
                }
                google.maps.event.trigger(map, 'resize');
            },
            resizeMapMenu: function (e) {
                var parW = $("#middle").width() - 20;
                var panel = $("#panelMenu");
                if (parW > panel.width()) {
                    panel.css("width", "calc(100% - 20px)");
                    $(e.target).toggleClass('k-i-full-screen k-i-full-screen-exit');
                } else {
                    panel.css("width", "300px");
                    $(e.target).toggleClass('k-i-full-screen-exit k-i-full-screen');
                }
            },
            AddressFilter: 3,
            btnAddEdit: function (e) {
                var f = this.get("AddressFilter");
                return (f === 5)
            },
            AddressAdd: function (e) {
                var that = this;
                traceAddress_Edit(null, function (source) {
                    var data = {
                        extAddrName: source.Surname,
                        extAddrStreet: source.PersStreet,
                        extAddrHouseNum: source.PersHouseNum,
                        extAddrZipCode: source.PersZipCode,
                        extAddrCity: source.PersCity,
                        gPSLat: source.GPSLat,
                        gPSLng: source.GPSLng,
                        gPSValid: source.GPSValid,
                        extAddrComment: ""
                    }
                    $.get("@Url.Action("sp_Do_AddExternalAddress", "Api/Service")", data, function (result) {
                        that.Address.read();
                    })
                });
            },
            AddressUpdate: function (e) {
                var that = this;
                traceAddress_Edit(e.data, function (source) {
                    var data = {
                        iDExternalAddress: source.IDSpisyOsobyAdresy,
                        extAddrName: source.Surname,
                        extAddrStreet: source.PersStreet,
                        extAddrHouseNum: source.PersHouseNum,
                        extAddrZipCode: source.PersZipCode,
                        extAddrCity: source.PersCity,
                        gPSLat: source.GPSLat,
                        gPSLng: source.GPSLng,
                        gPSValid: source.GPSValid,
                        extAddrComment: ""
                    }
                    $.get("@Url.Action("sp_Do_EditExternalAddress", "Api/Service")", data, function (result) {

                    })
                })
            },
            GetAccs: function (e) {
                var id = e.data.IDSpisyOsoby;
                SpisyOfIDSpisyOsoby(id);
            },
            AddressRemove: function (e) {
                var that = this;
                var id = e.data.IDSpisyOsobyAdresy;
                $.get("@Url.Action("sp_Do_DeleteExternalAddress", "Api/Service")", {iDExternalAddress: id}, function (result) {
                    that.Address.read();
                })
            },
            Address: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDSpisyOsobyAdresy",
                    }
                },
                transport: {
                    read: "@Url.Action("sp_CampAddrALL", "Api/Service")",
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if (pm.$filter) {
                            pm.$filter = pm.$filter.replace("eq ''", "eq null");
                        }
                        pm.Type = viewModel.AddressFilter;
                        return pm;
                    }
                },
                pageSize: 1000,
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true
            }),
            clearFilter: function (e) {
                this.set("AddressFilter", 3);
                this.Address.filter({});
                this.Address.sort({});
            },
            curFilter: function () {
                var f = this.get("AddressFilter");
                switch (f) {
                    case 3:
                        return "@Html.Raw(Language.TracingTXT5) ";
                        break;
                    case 5:
                        return "@Html.Raw(Language.TracingTXT13)";
                        break;
                    case 6:
                        return "@Html.Raw(Language.TracingTXT10)";
                        break;
                    case 2:
                        return "@Html.Raw(Language.TracingTXT7) ";
                        break;
                    case 1:
                        return "@Html.Raw(Language.TracingTXT2)";
                        break;
                }
            },
            Address_dataBound: function (e) {
                var that = this;
                $('#Address_CheckAll').prop("checked", false);
                $('#Address_CheckAll').change(function (event) {
                    that.Address_CheckAll(e.sender.table, event)
                });
                var allRows = e.sender.tbody.find("tr");
                allRows.each(function () {
                    var di = e.sender.dataItem($(this));
                    $(this).removeClass("k-alt")

                    if (di.IDCampaign) {
                        if (di.IDCampaign === that.IDCampaign) $(this).addClass("row-incamp");
                        if (di.IDCampaign !== that.IDCampaign) $(this).addClass("row-outcamp");
                    }

                    $(this).attr("data-id", di.IDSpisyOsobyAdresy);
                })

                var showCH = this.get("enableAdd");
                var chs = $("#checkboxes").data("index");
                if (showCH) {
                    e.sender.showColumn(chs);
                } else {
                    e.sender.hideColumn(chs);
                }

                var btnaccs = $("#getaccs").data("index");
                var deletecontrol = $("#deletecontrol").data("index");
                var editcontrol = $("#editcontrol").data("index");
                if (this.get("AddressFilter") === 5) {
                    e.sender.showColumn(deletecontrol);
                    e.sender.showColumn(editcontrol);
                    e.sender.hideColumn(btnaccs);
                } else {
                    e.sender.hideColumn(deletecontrol);
                    e.sender.hideColumn(editcontrol);
                    e.sender.showColumn(btnaccs);
                }

                e.sender.table.kendoDraggable({
                    filter: "tr",
                    cursorOffset: {
                        top: -24,
                        left: -24
                    },
                    hint: function () {
                        var count = e.sender.table.find('.checkrow:checked').length;
                        if (count > 0) {
                            var ids = $.map(e.sender.table.find('.checkrow:checked'), function (ch) {
                                var item = e.sender.dataItem($(ch).closest("tr"));
                                return item.IDSpisyOsobyAdresy
                            })
                            return $('<span data-ids="' + JSON.stringify(ids) + '" style="font-size: 48px; color: red;" class="k-icon k-i-cancel"></span>');
                        }
                    },
                    group: "dropTarget"
                });

                $("#middle").kendoDropTarget({
                    drop: function (e) {
                        //je vybrana kampan
                        if (that.IDCampaign > 0) {
                            try {
                                var len = that.Group.view().length
                                var iDSpisyOsobyAdresys = $(e.draggable.hint).data("ids");
                                var total = len + iDSpisyOsobyAdresys.length;
                                var pageSize = that.Group.pageSize();
                                if (total > pageSize) {
                                    message(" @Html.Raw(Language.TraceScriptTXT4) " + pageSize + " @Html.Raw(Language.TraceScriptTXT5)", "info")
                                    return false;
                                }
                                var camp = that.Groups.get(that.IDCampaign);
                                sp_Get_IDSpisu_OfIDSpisyOsobyAdresy(iDSpisyOsobyAdresys, camp.DeadLine, that.IDCampaign, that);
                            } catch (ex) {
                                console.log(ex)
                            }
                        }
                    },
                    dragenter: function (e) {
                        if (that.IDCampaign > 0) $(e.draggable.hint).removeClass("k-i-cancel").addClass("k-i-plus-outline").css("color", "green");
                    },
                    dragleave: function (e) {
                        if (that.IDCampaign > 0) $(e.draggable.hint).removeClass("k-i-plus-outline").addClass("k-i-cancel").css("color", "red");
                    },
                    group: "dropTarget",
                });

                if (this.get("AddressFilter") == 4) {
                    var view = this.Address.view();
                    outPoints = $.map(view, function (a) {
                        if (a.IDCampaign != that.IDCampaign && a.GPSValid) {
                            var address = [a.PersStreet + " " + a.PersHouseNum, a.PersCity + " " + a.PersZipCode].join(", ");
                            return {
                                location: new google.maps.LatLng(a.GPSLat, a.GPSLng),
                                name: (a.Surname ? a.Surname : "") + " " + (a.Name ? a.Name : ""),
                                address: address,
                                id: a.IDSpisyOsobyAdresy,
                                color: a.Color
                            };
                        };
                    });
                    if (outPoints.length > 0) {
                        customMarkers(e.sender, outPoints);
                    };
                };
            },
            Address_CheckAll: function (grid, e) {
                var checked = e.target.checked;
                if (checked) {
                    grid.find('.checkrow').prop('checked', true);
                } else {
                    grid.find('.checkrow').prop('checked', false);
                };
                grid.find('.checkrow').change();
            },
            Address_Check: function (e) {
                var that = this;
                var checked = $(e.currentTarget).prop("checked"),
                       grid = $(e.currentTarget).closest("table");
                var l = grid.find('.checkrow:checked').length; //vybranych radku
                var t = $.grep(this.Address.view(), function (a, b) {
                    return (a.GPSValid && that.IDCampaign !== a.IDCampaign)
                }).length;
                if (l !== t) {
                    $('#Address_CheckAll').prop("checked", false);
                } else {
                    $('#Address_CheckAll').prop("checked", true);
                }
            },
            Address_CheckVisible: function (e) {
                if (!e.GPSValid || (this.IDCampaign === e.IDCampaign)) {
                    $("#ch-" + e.uid).removeClass("checkrow");
                    return false;
                }
                return true;
            },
            setGps: function(e) {
                var model = this;
                var f = this.get("AddressFilter");
                var url = "@Url.Action("tblSpisyOsobyAdresy", "Api/Service")";
                if (f === 5) {
                    url = "@Url.Action("tblExternalAddress", "Api/Service")";
                }
                CallWinAddressParser(url, e.data.IDSpisyOsobyAdresy, function (GPSValid) {
                    model.Address.read();
                });
            },
            selectFilter: function (e) {
                var that = this;
                var f = $(e.currentTarget).data("filter");
                that.set("AddressFilter", f);
                if (f === 4) {
                    markerOutClear();
                    if (routesOutPoints) {
                        that.calcTrajectory(function (result) {
                            that.Address.read();
                        })
                    } else {
                        message(" @Html.Raw(Language.TraceScriptTXT6)");
                        that.set("AddressFilter", 3);
                        that.Address.read();
                    }
                } else {
                    that.Address.read();
                }
            },
            calcTrajectory: function (callback) {
                kendo.ui.progress($("#left"), true);
                $.ajax({
                    url: "@Url.Action("tblCampRouteTrajectory_Save", "Api/Service")",
                    type: "POST",
                    data: JSON.stringify(routesOutPoints),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        kendo.ui.progress($("#left"), false);
                        showRadiusTrajectory(routesOutPoints);
                        callback(true);
                    }
                });
            },
            expandTab: function (e) {
                var splitter = $("#splitter").data("kendoSplitter");
                var icon = $(e.currentTarget).find(".fa");
                var panel = $("#middle");
                if (panel.width() > 0) {
                    splitter["collapse"](panel);
                    icon.removeClass("fa-window-maximize").addClass("fa-window-restore");
                } else {
                    splitter["expand"](panel);
                    icon.removeClass("fa-window-restore").addClass("fa-window-maximize");
                };
            },
            Groups: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDCampaign"
                    }
                },
                sort: ({ field: "DeadLine", dir: "asc" }),
                transport: {
                    read: "@Url.Action("vw_Campaign", "Api/Service")",
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if (pm.$filter) {
                            pm.$filter = pm.$filter.replace("eq ''", "eq null");
                        }
                        return pm;
                    }
                },
                pageSize: 1000,
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true
            }),
            Groups_Update: function (e) {
                var that = this;
                $.get("@Url.Action("vw_Campaign_Update", "Api/Service")", { IDCampaign: e.data.IDCampaign, CampName: e.data.CampName }, function (result) {
                    that.set("vybranaKampan", (kendo.toString(new Date(e.data.DeadLine), "d") + " " + e.data.CampName))
                });
            },
            Groups_DataBound: function (e) {
                var view = this.Groups.view();
                var allRows = e.sender.tbody.find("tr");
                allRows.each(function () {
                    var di = e.sender.dataItem($(this));
                    $(this).attr("data-id", di.IDCampaign);
                });
                if (this.IDCampaign > 0) {
                    var row = e.sender.table.find("tr[data-id='" + this.IDCampaign + "']")
                    e.sender.select(row)
                }
            },
            enableAdd: false,
            Groups_Change: function (e) {
                var item = e.sender.dataItem(e.sender.select());
                var today = new Date();
                var ddl = new Date(item.DeadLine);
                var diff = new Date(ddl - today);
                var days = parseInt(diff / 1000 / 60 / 60 / 24);
                if (days < 0) {
                    message(" @Html.Raw(Language.TraceScriptTXT7)")
                    this.set("enableAdd", false);
                } else {
                    this.set("enableAdd", true);
                }

                if (this.IDCampaign !== item.IDCampaign) {
                    this.set("IDCampaign", item.IDCampaign);
                    this.set("vybranaKampan", (kendo.toString(new Date(item.DeadLine), "d") + " " + item.CampName));
                    this.set("AddressFilter", 3);
                    this.Address.read();
                    this.Group.read();
                    clearMap();
                }
            },
            campPrint: function (e) {
                printCampPDFsDialog(function (m) {
                    var params = "?IDCampaign=" + e.data.IDCampaign +
                                 "&IDU=" + e.data.IDUser +
                                 "&DeadLine=" + e.data.DeadLine +
                                 "&CampName=" + e.data.CampName +
                                 "&pr=" + m.ch1 +
                                 "&dn=" + m.ch2 +
                        "&uz=" + m.ch3;
                    var url = "@Url.Action("TraceDocuments", "Home")" + params;
                    window.open(url);
                })
            },
            IDCampaign: 0,
            vybranaKampan: "@Html.Raw(Language.TraceScriptTXT1)",
            start: function () {
                var view = this.get("Group").view();
                var item = view[0]
                if (item) {
                    return [item.PersStreet + " " + item.PersHouseNum, item.PersCity + " " + item.PersZipCode].join(", ");
                } else { return "" }
            },
            stop: function () {
                var view = this.get("Group").view();
                var item = view[view.length - 1];
                if (item) {
                    return [item.PersStreet + " " + item.PersHouseNum, item.PersCity + " " + item.PersZipCode].join(", ");
                } else { return "" }
            },
            Group: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDCampMember",
                    }
                },
                sort: ({ field: "MemberOrder", dir: "asc" }),
                transport: {
                    read: "@Url.Action("vw_CampMember", "Api/Service")",
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if (pm.$filter) {
                            pm.$filter = pm.$filter.replace("eq ''", "eq null");
                        }
                        pm.IDCampaign = viewModel.IDCampaign;
                        return pm;
                    }
                },
                pageSize: 23,
                serverPaging: true,
                serverSorting: true,
                serverFiltering: true,
            }),
            groupChange: function (e) {
                var id = $(e.sender.select()[0]).data("id");
                var m = $.grep(markerArray, function (a, b) {
                    return a.id === id;
                })
                if (m.length > 0) {
                    google.maps.event.trigger(m[0].marker, 'click');
                }
            },
            deleteFromTrace: function (e) {
                var that = this;
                sp_Do_DeleteCampMember(e.data, function (result) {
                    if (result === 0) that.Groups.read();
                    that.Group.read();
                    that.Address.read();
                });
            },
            groupDataBound: function (e) {
                var that = this;
                var view = this.Group.view();
                var allRows = e.sender.tbody.find("tr");
                allRows.each(function () {
                    var di = e.sender.dataItem($(this));
                    $(this).attr("data-id", di.IDCampMember);
                })

                //var total = this.Group.total()
                //var max = this.Group.pageSize();
                //if (total > 23) {
                //    message(" V kampani je " + total + " adres pro OSN. Zobrazeno bude prvních " + max + " adres.", "warning")
                //}

                if (view.length === 0) this.set("vybranaKampan", "Nevybráno");

                if (view.length > 0) {
                    //presouvani jednoho bodu
                    e.sender.table.kendoSortable({
                        axis: "y",
                        hint: '', //hintElement,
                        cursor: "move",
                        placeholder: function (element) {
                            return element.clone().css("opacity", 0.3);
                        },
                        container: "#vw_CampMember tbody",
                        filter: ">tbody >tr",
                        change: function (row) {
                            var item = that.Group.getByUid(row.item.data("uid"));
                            $.get("@Url.Action("sp_Do_ChangeCampOrderOnlyOne", "Api/Service")", {
                                iDCampMember: item.IDCampMember,
                                newPosition: row.newIndex
                            }, function (result) {
                                that.Group.read();
                            });
                        }
                    });
                };
            },
            groupOrderEdit: function (e) {
                var that = this;
                $.get("@Url.Action("sp_Do_ChangeCampOrderOnlyOne", "Api/Service")", {
                    iDCampMember: e.data.IDCampMember,
                    newPosition: e.data.MemberOrder
                }, function (result) {
                    that.Group.read();
                });
            },
            styleMapSelect: function (e) {
                //zmena barvy mapy
                var s = e.dataItem.value;
                changeMapStyle(s);
            },
            userTrace: function (e) {
                var that = this;
                var view = $.grep(this.Group.view(), function (n, i) {
                    if (n.GPSLat || n.GPSLng) {
                        return n;
                    }
                });

                var noValid = $.grep(view, function (n, i) {
                    return (!n.GPSValid);
                });

                if (noValid.length > 0) {
                    message(" Některá z adres kampaně není validována. Kliknete na červenou ikonku a zvalidujte adresu.", "error")
                    return false;
                }

                if (this.get("AddressFilter") == 4) {
                    this.set("AddressFilter", 3);
                    this.Address.read();
                }
                getTracePoints(view, function (result) {
                    calculateAndDisplayRoute($("#vw_CampMember").data("kendoGrid"), result, false, that);
                });
            },
            optimalTrace: function (e) {
                var that = this;
                var view = $.grep(this.Group.view(), function (n, i) {
                    if (n.GPSLat || n.GPSLng) {
                        return n;
                    }
                });

                var noValid = $.grep(view, function (n, i) {
                    return (!n.GPSValid);
                });

                if (noValid.length > 0) {
                    message(" Některá z adres kampaně není validována. Kliknete na červenou ikonku a zvalidujte adresu.", "error")
                    return false;
                }

                if (this.get("AddressFilter") == 4) {
                    this.set("AddressFilter", 3);
                    this.Address.read();
                }
                if (view.length > 0) {
                    try {
                        getTracePoints(view, function (result) {
                            kendo.ui.progress($("body"), true);
                            if (view.length > 0 && view.length < 3) {
                                calculateAndDisplayRoute($("#vw_CampMember").data("kendoGrid"), result, false, that);
                            } else if  (view.length > 2) {
                                calculateAndDisplayRoute($("#vw_CampMember").data("kendoGrid"), result, true, that, function (points, reorder) {
                                    var grid = $("#vw_CampMember").data("kendoGrid");
                                    var page = grid.dataSource.page();
                                    var page_i = 0
                                    if (page > 0) {
                                        page_i = (page - 1) * 23
                                    }

                                    var ids = [];

                                    $.each(reorder, function (newOrder, oldOrder) {
                                        var wayp = points.waypoints[oldOrder];
                                        var item = that.Group.get(wayp.id);
                                        newOrder++
                                        wayp.order = newOrder;

                                        ids.push({ iDCampMember: item.IDCampMember, newPosition: (newOrder + page_i) });
                                    });

                                    var counter = 0,
                                            total = ids.length;

                                    if (total > 0) {
                                        var l = function (arr) {
                                            jQuery.ajax({
                                                url: "@Url.Action("sp_Do_ChangeCampOrder", "Api/Service")",
                                                type: "GET",
                                                async: false,
                                                data: {
                                                    "iDCampMember": arr[counter].iDCampMember,
                                                    "newPosition": arr[counter].newPosition
                                                },
                                                success: function (result) {
                                                    counter++
                                                    if (counter === total) {
                                                        kendo.ui.progress($("body"), false);
                                                        that.Group.read();
                                                        calculateAndDisplayRoute($("#vw_CampMember").data("kendoGrid"), points, false, that);
                                                    } else {
                                                        l(arr);
                                                    }
                                                }
                                            });
                                        };
                                        l(ids);

                                        @*ids.map(function (item, i) {
                                            jQuery.ajax({
                                                url: "@Url.Action("sp_Do_ChangeCampOrder", "Api/Service")",
                                                type: "GET",
                                                async: false,
                                                data: {
                                                    "iDCampMember": item.iDCampMember,
                                                    "newPosition": item.newPosition
                                                },
                                                success: function (result) {
                                                    counter++
                                                    if (counter === total) {
                                                        kendo.ui.progress($("body"), false);
                                                        that.Group.read();
                                                        calculateAndDisplayRoute($("#vw_CampMember").data("kendoGrid"), points, false, that);
                                                    }
                                                }
                                            });
                                        });*@
                                    };
                                });
                            }
                            kendo.ui.progress($("body"), false);
                        });
                    } catch (ex) {
                        kendo.ui.progress($("body"), false);
                    }
                }
            },
            tracePlan: function (e) {
                $("#directionsPlanWin").toggle();
                $("#campPanel").toggle();
            },
            infWinAct: function (e) {
                var that = this;
                var btn = $(e).data("act");
                var id = $(e).data("id");

                if (btn === 1) {
                    var item = this.Address.get(id);
                    var len = this.Group.view().length
                    var iDSpisyOsobyAdresys = [item.IDSpisyOsobyAdresy];
                    var total = len + 1;
                    var pageSize = this.Group.pageSize();
                    if (total > pageSize) {
                        message(" Počet bodů v trasaci by překračoval max. limit. Maximální počet je " + pageSize + " bodů", "info")
                        return false;
                    }
                    var camp = this.Groups.get(this.IDCampaign);
                    sp_Get_IDSpisu_OfIDSpisyOsobyAdresy(iDSpisyOsobyAdresys, camp.DeadLine, that.IDCampaign, this, function (result) {
                        $.each(infoWindowsOut, function (a, b) {
                            if (b.id === id) {
                                b.window.setMap(null);
                            };
                        });
                        $.each(markerOut, function (a, b) {
                            if (b.id === id) {
                                b.marker.setMap(null);
                            };
                        });
                    });
                }

                if (btn === 2) {
                    var di = this.Group.get(id);
                    sp_Do_DeleteCampMember(di, function (result) {
                        that.Group.read();
                        that.Address.read();
                    });
                }
            },
            totalDistance: null,
            totalDuration: null
        })
        $("#directionsPlanWin").hide();
        kendo.bind($("#splitter"), viewModel);

        getCurrentPosition(function (result) {
            var isOn = window.setInterval(function () {
                if (googleIsLoad) {
                    position = getLatLngFromString(result.loc);
                    initmapcanvas('mapcanvas', position);
                    window.clearInterval(isOn);
                }
            }, 500);
        })
    })

    function sp_Do_DeleteCampMember(item, callback) {
        if (item.rr_CampAddrType === 3) { //mazani vlastniho kontaktu z kampane
            winProgressBarDialog.open().center();
            progressModel.set("progressValue", 0);
            $.get("@Url.Action("sp_Do_DeleteCampNewExternalAddr", "Api/Service")", {
                iDCampaign: item.IDCampaign,
                iDCampMember: item.IDCampMember
            }, function (result) {
                progressModel.set("progressValue", 100);
                if (result.MsgType === "error") {
                    progressModel.set("progressLogVisible", true);
                    $.each(result.Msg, function (i, e) {
                        progressModel.progressLog.insert(0, { state: result.MsgType, text: e });
                    })
                }
                callback(result.Total);
            });
        } else {
            CustomAlert("Odstranění adresy z kampaně", "Opravdu si přejete odstranit tento bod z kampaně?", function (boolean) {
                try {
                    if (boolean) {
                        $.get("@Url.Action("sp_Get_MinDMAX_OfIDSpisyOsobyAdresy", "Api/Service")", { iDSpisyOsobyAdresy: item.IDSpisyOsobyAdresy }, function (result) {
                            var dmax, nochange;
                            if (result.dmax) {
                                dmax = new Date(result.dmax);
                            } else {
                                dmax = null;
                            };
                            if (result.nochange) {
                                nochange = result.nochange;
                            } else {
                                nochange = null;
                            };
                            showOSNDatePlan(new Date(item.VisitDatePlan), dmax, nochange, function (newdate, nochange, name) { //dodej null dmax
                                winProgressBarDialog.open().center();
                                progressModel.set("progressValue", 0);
                                $.get("@Url.Action("sp_Do_DeleteCampMember", "Api/Service")", {
                                    iDCampMember: item.IDCampMember,
                                    dateForFieldVisit: kendo.toString(newdate, "yyyy-MM-dd 00:00:00"),
                                    nochange: nochange,
                                    name: name
                                }, function (result) {
                                    progressModel.set("progressValue", 100);
                                    if (result.MsgType === "error") {
                                        progressModel.set("progressLogVisible", true);
                                        $.each(result.Msg, function (i, e) {
                                            progressModel.progressLog.insert(0, { state: result.MsgType, text: e });
                                        })
                                    }
                                    callback(result.Total);
                                });
                            });
                        });
                    };
                } catch (ex) {

                }
            });
        };
    }

    function sp_Get_IDSpisu_OfIDSpisyOsobyAdresy(iDSpisyOsobyAdresys, deadLine, IDCampaign, model, callback) {
        var counter = 0,
            total = iDSpisyOsobyAdresys.length;
        if (total > 0) {
            winProgressBarDialog.open().center();
            iDSpisyOsobyAdresys.map(function (id, i) {
                var item = model.Address.get(id);
                var url = "@Url.Action("sp_Get_IDSpisu_OfIDSpisyOsobyAdresy", "Api/Service")";
                var params = {
                    iDSpisyOsobyAdresy: id,
                    deadLine: kendo.toString(deadLine, "yyyy-MM-dd")
                }

                if (item.rr_AddressType === 3) {
                    url = "@Url.Action("sp_Do_AddCampNewExternalAddr", "Api/Service")";
                    params = {
                        iDCampaign: IDCampaign,
                        iDExternalAddress: id
                    }
                }

                $.get(url, params).always(function (result) {
                    var value = parseFloat(parseInt(counter, 10) * 100) / parseInt(total, 10);
                    progressModel.set("progressValue", value);
                    if (result.MsgType === "error") {
                        progressModel.set("progressLogVisible", true);
                        $.each(result.Msg, function (i, e) {
                            progressModel.progressLog.insert(0, { state: result.MsgType, text: e });
                        })
                    }
                    counter++
                    if (counter === total) {
                        progressModel.set("progressValue", 100);
                        model.Address.read();
                        model.Group.read();
                        if (callback && result.MsgType !== "error") {
                            callback(true)
                        }
                    }
                })
            });
        }
    }

    function getTracePoints(view, callback) {
        traceOpt = {
            origin: null,
            destination: null,
            waypoints: []
        };
        $.each(view, function (i, item) {
            var address = [item.PersStreet + " " + item.PersHouseNum, item.PersCity + " " + item.PersZipCode].join(", ");
            if (i === 0) {
                traceOpt.origin = {
                    location: new google.maps.LatLng(item.GPSLat, item.GPSLng),
                    name: item.FullName,
                    address: address,
                    order: item.MemberOrder,
                    id: item.IDCampMember
                };
            }
            if (view.length > 1) {
                if (i > 0 && i < (view.length - 1)) {
                    traceOpt.waypoints.push({
                        location: new google.maps.LatLng(item.GPSLat, item.GPSLng),
                        name: item.FullName,
                        address: address,
                        order: item.MemberOrder,
                        id: item.IDCampMember
                    });
                }
                if (i === (view.length - 1)) {
                    traceOpt.destination = {
                        location: new google.maps.LatLng(item.GPSLat, item.GPSLng),
                        name: item.FullName,
                        address: address,
                        order: item.MemberOrder,
                        id: item.IDCampMember
                    };
                }
            }
        })
        callback(traceOpt)
    }

    function hintElement(element) { // Customize the hint
        var grid = $("#vw_CampMember").data("kendoGrid"),
            table = grid.table.clone(), // Clone Grid's table
            wrapperWidth = grid.wrapper.width(), //get Grid's width
            wrapper = $("<div class='k-grid k-widget'></div>").width(wrapperWidth),
            hint;

        table.find("thead").remove(); // Remove Grid's header from the hint
        table.find("tbody").empty(); // Remove the existing rows from the hint
        table.wrap(wrapper); // Wrap the table
        table.append(element.clone().removeAttr("uid")); // Append the dragged element

        hint = table.parent(); // Get the wrapper

        return hint; // Return the hint element
    }

    //******************************************************************************
    var map,
        markerArray = [],
        markerOut = [],
        infoWindows = [],
        infoWindowsOut = [],
        radiusTrajectory = [],
        outPoints = [],
        position = null,
        directionsService = null,
        directionsDisplay = null,
        traceOpt = null,
        routesOutPoints = null;

    function getLatLngFromString(ll) {
        if (ll) {
            var rplstr = ll.replace(" ", "");
            var latlng = rplstr.split(",");
            return new google.maps.LatLng(parseFloat(latlng[0]), parseFloat(latlng[1]));
        } else {
            return new google.maps.LatLng(0, 0);
        }
    }

    function initmapcanvas(idmap, center) {
        map = new google.maps.Map(document.getElementById(idmap), {
            zoom: 12,
            center: center,
            mapTypeControl: false,
            styles: null,
            //gestureHandling: 'cooperative' //'greedy'
        });

        map.addListener('click', function (e) {
            $.each(infoWindows, function (a, b) {
                b.window.close();
            });
            $.each(infoWindowsOut, function (a, b) {
                b.window.close();
            });
        });

        var panel = document.getElementById("panelMenu");
        map.controls[google.maps.ControlPosition.TOP_LEFT].push(panel);

        var style = document.getElementById("styleMap");
        map.controls[google.maps.ControlPosition.TOP_RIGHT].push(style);

        var dist = document.getElementById("totalDistance");
        map.controls[google.maps.ControlPosition.TOP_RIGHT].push(dist);
    };

    function getTime(seconds) {

        //a day contains 60 * 60 * 24 = 86400 seconds
        //an hour contains 60 * 60 = 3600 seconds
        //a minut contains 60 seconds
        //the amount of seconds we have left
        var leftover = seconds;

        //how many full days fits in the amount of leftover seconds
        var days = Math.floor(leftover / 86400);

        //how many seconds are left
        leftover = leftover - (days * 86400);

        //how many full hours fits in the amount of leftover seconds
        var hours = Math.floor(leftover / 3600);

        //how many seconds are left
        leftover = leftover - (hours * 3600);

        //how many minutes fits in the amount of leftover seconds
        var minutes = Math.floor(leftover / 60);

        //how many seconds are left
        //leftover = leftover - (minutes * 60);
        days = (days > 0 ? days + " d " : "");
        hours = (hours > 0 ? hours + " h " : "");
        minutes = (minutes > 0 ? minutes + " m" : "");

        return (days + hours + minutes);
    }

    function calculateAndDisplayRoute(grid, points, optimizeWaypoints, model, callback) {
        clearMap();
        if (points.destination) {
            directionsService.route({
                origin: points.origin.location,
                destination: points.destination.location,
                waypoints: $.map(points.waypoints, function (a, b) {
                    return {
                        location: a.location,
                        stopover: true
                    }
                }),
                optimizeWaypoints: optimizeWaypoints,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    var totalDistance = 0;
                    var totalDuration = 0;
                    var legs = response.routes[0].legs

                    $.each(legs, function (a, b) {
                        totalDistance += legs[a].distance.value;
                        totalDuration += legs[a].duration.value
                    })

                    model.set("totalDistance", kendo.toString((totalDistance / 1000.), "n") + " km");
                    model.set("totalDuration", getTime(totalDuration));

                    $.each(points.waypoints, function (a, b) {
                        b.distance = legs[a].distance;
                        b.duration = legs[a].duration
                    })
                    points.destination.distance = legs[legs.length - 1].distance
                    points.destination.duration = legs[legs.length - 1].duration

                    if (callback) {
                        callback(points, response.routes[0].waypoint_order);
                    } else {
                        directionsDisplay.setDirections(response);

                        routesOutPoints = routeSplit(points.origin.location, points.destination.location, response.routes[0], 20000);

                        setMarkers(grid, points);
                    }
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        } else {
            var loc = points.origin.location;
            if (loc) {
                setMarkers(grid, points, function (res) {
                    routesOutPoints = [{ GPSLat: loc.lat(), GPSLng: loc.lng() }];
                    map.panTo(loc);
                });
            }
        }
    };

    function setMarkers(grid, points, callback) {
        if (points.origin) {
            var infoWindow_origin = new google.maps.InfoWindow({
                content: infoWindowContent(points.origin)
            });
            var origin = new google.maps.Marker({
                position: points.origin.location,
                map: map,
                icon: {
                    path: "m19.19107,-15.364l-36.3675,0c-3.44452,0 -6.24704,2.86638 -6.24704,6.38991l0,13.72708c0,3.5233 2.80251,6.38991 6.24704,6.38991l12.3546,0l5.04266,5.15798c0.21734,0.22208 0.50186,0.33313 0.78661,0.33313s0.56927,-0.11104 0.78661,-0.33313l5.04266,-5.15798l12.3546,0c3.44452,0 6.24704,-2.86661 6.24704,-6.38991l0,-13.72708c0,-3.52353 -2.80251,-6.38991 -6.24726,-6.38991l-0.00002,0z",
                    fillColor: '#007acc',
                    fillOpacity: .8,
                    strokeColor: "#ffffff",
                    strokeWeight: 1,
                    scale: 1,
                    anchor: new google.maps.Point(0, 15)
                },
                label: {
                    text: "start",
                    color: '#ffffff',
                }
            });
            origin.addListener('click', function (e) {
                $.each(infoWindows, function (a, b) {
                    b.window.close();
                });
                $.each(infoWindowsOut, function (a, b) {
                    b.window.close();
                });
                infoWindow_origin.open(map, origin);

                var tr = grid.table.find("tr[data-id='" + points.origin.id + "']")
                if (!tr.hasClass("k-state-selected")) grid.select(tr);
            });
            infoWindows.push({ id: points.origin.id, window: infoWindow_origin });
            markerArray.push({ id: points.origin.id, marker: origin });
        }

        if (points.waypoints.length > 0) {
            $.each(points.waypoints, function (a, b) {
                var infoWindow_wayp = new google.maps.InfoWindow({
                    content: infoWindowContent(b)
                });
                var wayp = new google.maps.Marker({
                    position: b.location,
                    map: map,
                    icon: {
                        path: "M-20,0a20,20 0 1,0 40,0a20,20 0 1,0 -40,0",
                        fillColor: '#007acc',
                        fillOpacity: .8,
                        strokeColor: "#ffffff",
                        strokeWeight: 1,
                        scale: .5
                    },
                    label: {
                        text: ("" + b.order + ""),
                        color: '#ffffff',
                    }
                });
                wayp.addListener('click', function () {
                    $.each(infoWindows, function (a, b) {
                        b.window.close();
                    });
                    $.each(infoWindowsOut, function (a, b) {
                        b.window.close();
                    });
                    infoWindow_wayp.open(map, wayp);

                    var tr = grid.table.find("tr[data-id='" + b.id + "']")
                    if (!tr.hasClass("k-state-selected")) grid.select(tr);
                });
                infoWindows.push({ id: b.id, window: infoWindow_wayp });
                markerArray.push({ id: b.id, marker: wayp });
            })
        }

        if (points.destination) {
            var infoWindow_destination = new google.maps.InfoWindow({
                content: infoWindowContent(points.destination)
            });
            var destination = new google.maps.Marker({
                position: points.destination.location,
                map: map,
                icon: {
                    path: "m19.19107,-15.364l-36.3675,0c-3.44452,0 -6.24704,2.86638 -6.24704,6.38991l0,13.72708c0,3.5233 2.80251,6.38991 6.24704,6.38991l12.3546,0l5.04266,5.15798c0.21734,0.22208 0.50186,0.33313 0.78661,0.33313s0.56927,-0.11104 0.78661,-0.33313l5.04266,-5.15798l12.3546,0c3.44452,0 6.24704,-2.86661 6.24704,-6.38991l0,-13.72708c0,-3.52353 -2.80251,-6.38991 -6.24726,-6.38991l-0.00002,0z",
                    fillColor: '#007acc',
                    fillOpacity: .8,
                    strokeColor: "#ffffff",
                    strokeWeight: 1,
                    scale: 1,
                    anchor: new google.maps.Point(0, 15)
                },
                label: {
                    text: "cíl",
                    color: '#ffffff',
                }
            });
            destination.addListener('click', function () {
                $.each(infoWindows, function (a, b) {
                    b.window.close();
                });
                $.each(infoWindowsOut, function (a, b) {
                    b.window.close();
                });
                infoWindow_destination.open(map, destination);

                var tr = grid.table.find("tr[data-id='" + points.destination.id + "']")
                if (!tr.hasClass("k-state-selected")) grid.select(tr);
            });
            infoWindows.push({ id: points.destination.id, window: infoWindow_destination });
            markerArray.push({ id: points.destination.id, marker: destination });
        }

        if (callback) { callback(true) };
    }

    function customMarkers(grid, points) {
        $.each(points, function (a, b) {
            var infoWindow = new google.maps.InfoWindow({
                content: infoWindowContent(b, true)
            });
            var point = new google.maps.Marker({
                position: b.location,
                map: map,
                icon: {
                    path: "M-20,0a20,20 0 1,0 40,0a20,20 0 1,0 -40,0",
                    fillColor: b.color,
                    fillOpacity: .8,
                    strokeColor: "#ffffff",
                    strokeWeight: 1,
                    scale: .5
                },
                label: {
                    text: " "
                }
            });
            point.addListener('click', function () {
                $.each(infoWindows, function (a, b) {
                    b.window.close();
                });
                $.each(infoWindowsOut, function (a, b) {
                    b.window.close();
                });
                infoWindow.open(map, point);

                var tr = grid.table.find("tr[data-id='" + b.id + "']")
                if (!tr.hasClass("k-state-selected")) grid.select(tr);
            });
            infoWindowsOut.push({ id: b.id, window: infoWindow });
            markerOut.push({ id: b.id, marker: point });
        })
    }

    function showRadiusTrajectory(points) {
        $.each(points, function (a, b) {
            var radius = new google.maps.Circle({
                strokeWeight: 0,
                fillColor: "#007acc",
                fillOpacity: 0.15,
                map: map,
                center: new google.maps.LatLng(b.GPSLat, b.GPSLng),
                radius: 20000 // in meters
            });
            radiusTrajectory.push(radius)
        })
    }

    function infoWindowContent(point, isNew) {
        var content = '<ul class="fieldlist">'
        content += '<p style="text-align: center;"><b>' + point.name + '</b></p>';
        content += '<p style="text-align: center;">' + point.address + '</p>';
        content += '<p style="text-align: center;">' + (point.distance ? "Od předchozího bodu: " + point.distance.text + ", " + point.duration.text : "") + '</p>';
        if (isNew) {
            content += '<li><a href="#" style="width:100%" class="k-button" data-act="1" data-id="' + point.id + '" onclick="viewModel.infWinAct(this)"><span style="color:#749f3e;float: left" class="k-icon k-i-plus-circle"></span> @Html.Raw(Language.Key_PridatBodDoKampane)</a></li>'
        } else {
            content += '<li><a href="#" style="width:100%" class="k-button" data-act="2" data-id="' + point.id + '" onclick="viewModel.infWinAct(this)"><span style="color:#c5394e;float: left" class="k-icon k-i-close-circle"></span> @Html.Raw(Language.Key_OdstraňBodZKampane)</a></li>'
        }
        content += '</div>'
        return content
    }

    function markerOutClear() {
        for (var i = 0; i < markerOut.length; i++) {
            markerOut[i].marker.setMap(null);
        }
        markerOut = [];
        for (var i = 0; i < radiusTrajectory.length; i++) {
            radiusTrajectory[i].setMap(null);
        }
        radiusTrajectory = [];
        for (var i = 0; i < infoWindowsOut.length; i++) {
            infoWindowsOut[i].window.setMap(null);
        }
        infoWindowsOut = [];
    }

    function clearMap() {
        markerOutClear();
        if (directionsDisplay) {
            directionsDisplay.setMap(null);
        }
        directionsService = new google.maps.DirectionsService;
        directionsDisplay = new google.maps.DirectionsRenderer({
            suppressMarkers: true,
            polylineOptions: {
                strokeColor: "#007acc",
                strokeOpacity: .8
            }
        });
        directionsDisplay.setMap(map);
        $("#directionsPlan").empty();
        directionsDisplay.setPanel(document.getElementById('directionsPlan'));
        for (var i = 0; i < markerArray.length; i++) {
            markerArray[i].marker.setMap(null);
        }
        markerArray = [];
        for (var i = 0; i < infoWindows.length; i++) {
            infoWindows[i].window.setMap(null);
        }
        infoWindows = [];
        routesOutPoints = null;
    }

    //hledat body podel trasy v radiusu
    function routeSplit(origin, destination, route, dist) {
        var positions = [],
            geo = google.maps.geometry.spherical,
            path = route.overview_path,
            point = path[0],
            distance = 0,
            leg,
            overflow,
            pos;

        positions.push({ GPSLat: origin.lat(), GPSLng: origin.lng() });
        for (var p = 1; p < path.length; ++p) {
            leg = Math.round(geo.computeDistanceBetween(point, path[p]));
            d1 = distance + 0
            distance += leg;
            overflow = dist - (d1 % dist);

            if (distance >= dist && leg >= overflow) {
                if (overflow && leg >= overflow) {
                    pos = geo.computeOffset(point, overflow, geo.computeHeading(point, path[p]));
                    positions.push({ GPSLat: pos.lat(), GPSLng: pos.lng() });
                    distance -= dist;
                }

                while (distance >= dist) {
                    pos = geo.computeOffset(point, dist + overflow, geo.computeHeading(point, path[p]));
                    positions.push({ GPSLat: pos.lat(), GPSLng: pos.lng() });
                    distance -= dist;
                }
            }
            point = path[p]
        }
        positions.push({ GPSLat: destination.lat(), GPSLng: destination.lng() });
        return positions;
    }

    function changeMapStyle(e) { var t = null; switch (e) { case "night": t = [{ elementType: "geometry", stylers: [{ color: "#242f3e" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#746855" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#242f3e" }] }, { featureType: "administrative.locality", elementType: "labels.text.fill", stylers: [{ color: "#d59563" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#d59563" }] }, { featureType: "poi.park", elementType: "geometry", stylers: [{ color: "#263c3f" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#6b9a76" }] }, { featureType: "road", elementType: "geometry", stylers: [{ color: "#38414e" }] }, { featureType: "road", elementType: "geometry.stroke", stylers: [{ color: "#212a37" }] }, { featureType: "road", elementType: "labels.text.fill", stylers: [{ color: "#9ca5b3" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#746855" }] }, { featureType: "road.highway", elementType: "geometry.stroke", stylers: [{ color: "#1f2835" }] }, { featureType: "road.highway", elementType: "labels.text.fill", stylers: [{ color: "#f3d19c" }] }, { featureType: "transit", elementType: "geometry", stylers: [{ color: "#2f3948" }] }, { featureType: "transit.station", elementType: "labels.text.fill", stylers: [{ color: "#d59563" }] }, { featureType: "water", elementType: "geometry", stylers: [{ color: "#17263c" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#515c6d" }] }, { featureType: "water", elementType: "labels.text.stroke", stylers: [{ color: "#17263c" }] }]; break; case "aubergine": t = [{ elementType: "geometry", stylers: [{ color: "#1d2c4d" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#8ec3b9" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#1a3646" }] }, { featureType: "administrative.country", elementType: "geometry.stroke", stylers: [{ color: "#4b6878" }] }, { featureType: "administrative.land_parcel", elementType: "labels.text.fill", stylers: [{ color: "#64779e" }] }, { featureType: "administrative.province", elementType: "geometry.stroke", stylers: [{ color: "#4b6878" }] }, { featureType: "landscape.man_made", elementType: "geometry.stroke", stylers: [{ color: "#334e87" }] }, { featureType: "landscape.natural", elementType: "geometry", stylers: [{ color: "#023e58" }] }, { featureType: "poi", elementType: "geometry", stylers: [{ color: "#283d6a" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#6f9ba5" }] }, { featureType: "poi", elementType: "labels.text.stroke", stylers: [{ color: "#1d2c4d" }] }, { featureType: "poi.park", elementType: "geometry.fill", stylers: [{ color: "#023e58" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#3C7680" }] }, { featureType: "road", elementType: "geometry", stylers: [{ color: "#304a7d" }] }, { featureType: "road", elementType: "labels.text.fill", stylers: [{ color: "#98a5be" }] }, { featureType: "road", elementType: "labels.text.stroke", stylers: [{ color: "#1d2c4d" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#2c6675" }] }, { featureType: "road.highway", elementType: "geometry.stroke", stylers: [{ color: "#255763" }] }, { featureType: "road.highway", elementType: "labels.text.fill", stylers: [{ color: "#b0d5ce" }] }, { featureType: "road.highway", elementType: "labels.text.stroke", stylers: [{ color: "#023e58" }] }, { featureType: "transit", elementType: "labels.text.fill", stylers: [{ color: "#98a5be" }] }, { featureType: "transit", elementType: "labels.text.stroke", stylers: [{ color: "#1d2c4d" }] }, { featureType: "transit.line", elementType: "geometry.fill", stylers: [{ color: "#283d6a" }] }, { featureType: "transit.station", elementType: "geometry", stylers: [{ color: "#3a4762" }] }, { featureType: "water", elementType: "geometry", stylers: [{ color: "#0e1626" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#4e6d70" }] }]; break; case "silver": t = [{ elementType: "geometry", stylers: [{ color: "#f5f5f5" }] }, { elementType: "labels.icon", stylers: [{ visibility: "off" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#616161" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#f5f5f5" }] }, { featureType: "administrative.land_parcel", elementType: "labels.text.fill", stylers: [{ color: "#bdbdbd" }] }, { featureType: "poi", elementType: "geometry", stylers: [{ color: "#eeeeee" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { featureType: "poi.park", elementType: "geometry", stylers: [{ color: "#e5e5e5" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#9e9e9e" }] }, { featureType: "road", elementType: "geometry", stylers: [{ color: "#ffffff" }] }, { featureType: "road.arterial", elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#dadada" }] }, { featureType: "road.highway", elementType: "labels.text.fill", stylers: [{ color: "#616161" }] }, { featureType: "road.local", elementType: "labels.text.fill", stylers: [{ color: "#9e9e9e" }] }, { featureType: "transit.line", elementType: "geometry", stylers: [{ color: "#e5e5e5" }] }, { featureType: "transit.station", elementType: "geometry", stylers: [{ color: "#eeeeee" }] }, { featureType: "water", elementType: "geometry", stylers: [{ color: "#c9c9c9" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#9e9e9e" }] }]; break; case "dark": t = [{ elementType: "geometry", stylers: [{ color: "#212121" }] }, { elementType: "labels.icon", stylers: [{ visibility: "off" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#212121" }] }, { featureType: "administrative", elementType: "geometry", stylers: [{ color: "#757575" }] }, { featureType: "administrative.country", elementType: "labels.text.fill", stylers: [{ color: "#9e9e9e" }] }, { featureType: "administrative.land_parcel", stylers: [{ visibility: "off" }] }, { featureType: "administrative.locality", elementType: "labels.text.fill", stylers: [{ color: "#bdbdbd" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { featureType: "poi.park", elementType: "geometry", stylers: [{ color: "#181818" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#616161" }] }, { featureType: "poi.park", elementType: "labels.text.stroke", stylers: [{ color: "#1b1b1b" }] }, { featureType: "road", elementType: "geometry.fill", stylers: [{ color: "#2c2c2c" }] }, { featureType: "road", elementType: "labels.text.fill", stylers: [{ color: "#8a8a8a" }] }, { featureType: "road.arterial", elementType: "geometry", stylers: [{ color: "#373737" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#3c3c3c" }] }, { featureType: "road.highway.controlled_access", elementType: "geometry", stylers: [{ color: "#4e4e4e" }] }, { featureType: "road.local", elementType: "labels.text.fill", stylers: [{ color: "#616161" }] }, { featureType: "transit", elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { featureType: "water", elementType: "geometry", stylers: [{ color: "#000000" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#3d3d3d" }] }]; break; case "retro": t = [{ elementType: "geometry", stylers: [{ color: "#ebe3cd" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#523735" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#f5f1e6" }] }, { featureType: "administrative", elementType: "geometry.stroke", stylers: [{ color: "#c9b2a6" }] }, { featureType: "administrative.land_parcel", elementType: "geometry.stroke", stylers: [{ color: "#dcd2be" }] }, { featureType: "administrative.land_parcel", elementType: "labels.text.fill", stylers: [{ color: "#ae9e90" }] }, { featureType: "landscape.natural", elementType: "geometry", stylers: [{ color: "#dfd2ae" }] }, { featureType: "poi", elementType: "geometry", stylers: [{ color: "#dfd2ae" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#93817c" }] }, { featureType: "poi.park", elementType: "geometry.fill", stylers: [{ color: "#a5b076" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#447530" }] }, { featureType: "road", elementType: "geometry", stylers: [{ color: "#f5f1e6" }] }, { featureType: "road.arterial", elementType: "geometry", stylers: [{ color: "#fdfcf8" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#f8c967" }] }, { featureType: "road.highway", elementType: "geometry.stroke", stylers: [{ color: "#e9bc62" }] }, { featureType: "road.highway.controlled_access", elementType: "geometry", stylers: [{ color: "#e98d58" }] }, { featureType: "road.highway.controlled_access", elementType: "geometry.stroke", stylers: [{ color: "#db8555" }] }, { featureType: "road.local", elementType: "labels.text.fill", stylers: [{ color: "#806b63" }] }, { featureType: "transit.line", elementType: "geometry", stylers: [{ color: "#dfd2ae" }] }, { featureType: "transit.line", elementType: "labels.text.fill", stylers: [{ color: "#8f7d77" }] }, { featureType: "transit.line", elementType: "labels.text.stroke", stylers: [{ color: "#ebe3cd" }] }, { featureType: "transit.station", elementType: "geometry", stylers: [{ color: "#dfd2ae" }] }, { featureType: "water", elementType: "geometry.fill", stylers: [{ color: "#b9d3c2" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#92998d" }] }] } map.setOptions({ styles: t }) }
</script>