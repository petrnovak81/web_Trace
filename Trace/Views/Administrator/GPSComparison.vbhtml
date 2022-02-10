@Code
    ViewData("Title") = Language.SVLinkTXT4
    Layout = "~/Views/Shared/_AdminLayout.vbhtml"
End Code

<div id="splitter"
        data-role="splitter"
        data-bind="events: { expand: onExpand, collapse: onCollapse, resize: onResize }"
        data-panes="[
     { collapsible: true, scrollable: false },
     { collapsible: true, scrollable: false, size: '40%'}
     ]">
    <div id="left" style="display: flex; flex-direction: column;">
        <ul data-role="menu">
            <li data-bind="events: { click: expandTab }" style="float: right;">
                <i class="fa fa-window-maximize" aria-hidden="true"></i>
            </li>
            <li data-bind="events: { click: clearFilter }" style="float: right;">
                <span class="k-icon k-i-filter-clear"></span>
            </li>
        </ul>
        @Html.Partial("~/Views/Objects/vw_CampCompare_GPS_Date.vbhtml")
    </div>
    <div id="middle" style="display: flex; flex-direction: column;">
        <ul data-role="menu" style="text-align: right;">
            <li data-bind="events: { click: toggleSplit }"><span id="leftPaneControl" class="fa fa-arrow-left"></span></li>
        </ul>
        <div id="detailPanel" style="margin: 10px; width: 300px;">
            <div class="k-header" style="padding: 6px;">
                <span><b style="text-transform: uppercase">@Html.Raw(Language.GPSComparisonTXT1)</b></span>
            </div>
            <div class="k-content">
                <table style="width: 100%; margin: 3px;">
                    <tr><td><b class="lt">@Html.Raw(Language.GPSComparisonTXT2)</b></td><td data-bind="date: selected.VR1_DateOSN"></td></tr>
                    <tr><td><b class="lt">@Html.Raw(Language.GPSComparisonTXT3)</b></td><td data-bind="date: selected.DatumZapisu"></td></tr>
                    <tr><td><b class="lt">@Html.Raw(Language.GPSComparisonTXT4)</b></td><td data-bind="date: selected.DocuSentDate"></td></tr>
                    <tr><td><b class="lt">@Html.Raw(Language.GPSComparisonTXT5)</b></td><td data-bind="text: selected.Rozdil_DatumOSN_DatumZapisu"></td></tr>
                    <tr><td><b class="lt">@Html.Raw(Language.GPSComparisonTXT6)</b></td><td data-bind="text: selected.Rozdil_DatumOSN_Foto"></td></tr> 
                    <tr><td><b class="lt">@Html.Raw(Language.GPSComparisonTXT7)</b></td><td data-bind="thousand: selected.Vzdalenost_AddrOSN_Zapis"></td></tr>
                    <tr><td><b class="lt">@Html.Raw(Language.GPSComparisonTXT8)</b></td><td data-bind="thousand: selected.Vzdalenost_AddrOSN_Foto"></td></tr>
                </table>
            </div>
        </div>
        <div id="styleMap" style="margin: 10px;">
            <select data-role="dropdownlist" title="Vzhled mapy" data-bind="events: { select: styleMapSelect }">
                <option value="default">@Html.Raw(Language.GPSComparisonTXT9)</option>
                <option value="silver">@Html.Raw(Language.GPSComparisonTXT10)</option>
                <option value="retro">@Html.Raw(Language.GPSComparisonTXT11)</option>
                <option value="dark">@Html.Raw(Language.GPSComparisonTXT12)</option>
                <option value="night">@Html.Raw(Language.GPSComparisonTXT13)</option>
                <option value="aubergine">@Html.Raw(Language.GPSComparisonTXT14)</option>
            </select>
        </div>
        <div id="mapcanvas" style="flex: auto;"></div>
    </div>
</div>

<script>
    $(function () {
        var viewModel = kendo.observable({
            onExpand: function (e) {
                if (map) google.maps.event.trigger(map, 'resize')
            },
            onCollapse: function (e) {
                if (map) google.maps.event.trigger(map, 'resize')
            },
            onResize: function (e) {
                if (map) google.maps.event.trigger(map, 'resize')
            },
            toggleSplit: function (e) {
                var splitter = $("#splitter").data("kendoSplitter");
                var leftPane = $("#left");
                if (leftPane.width() > 0) {
                    splitter["collapse"](leftPane);
                    $("#leftPaneControl").toggleClass('fa-arrow-left fa-arrow-right');
                } else {
                    splitter["expand"](leftPane);
                    $("#leftPaneControl").toggleClass('fa-arrow-right fa-arrow-left');
                }
                google.maps.event.trigger(map, 'resize');
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
            clearFilter: function (e) {
                this.vw_CampCompare_GPS_Date.filter({});
                this.vw_CampCompare_GPS_Date.sort({});
            },
            styleMapSelect: function (e) {
                var s = e.dataItem.value;
                changeMapStyle(s);
            },
            vw_CampCompare_GPS_Date: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDVisitReport",
                    }
                },
                transport: {
                    read: "@Url.Action("vw_CampCompare_GPS_Date", "Api/AdminService")",
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
            vw_CampCompare_GPS_Date_dataBound: function (e) {

            },
            selected: null,
            vw_CampCompare_GPS_Date_change: function (e) {
                var r = e.sender.select();
                var i = e.sender.dataItem(r);

                this.set("selected", i);
                if (map) {
                    drawLineDistance(i, map);
                    google.maps.event.trigger(map, 'resize');
                }
            }
        })
        kendo.bind($("#splitter"), viewModel);

        getCurrentPosition(function (result) {
            var isOn = window.setInterval(function () {
                if (googleIsLoad) {
                    var position = getLatLngFromString(result.loc);
                    initmapcanvas('mapcanvas', position);
                    window.clearInterval(isOn);
                }
            }, 500);
        })
    })

        function getLatLngFromString(ll) {
            var rplstr = ll.replace(" ", "");
            var latlng = rplstr.split(",");
            return new google.maps.LatLng(parseFloat(latlng[0]), parseFloat(latlng[1]));
        }

        var map = null,
            markerArray = [],
            infoWindows = [],
            polylines = [],
            directionsService = null,
            directionsDisplay = null;

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
                    b.close();
                });
            });

            var style = document.getElementById("styleMap");
            map.controls[google.maps.ControlPosition.TOP_RIGHT].push(style);

            var detail = document.getElementById("detailPanel");
            map.controls[google.maps.ControlPosition.TOP_LEFT].push(detail);
        };

        function drawLineDistance(i, map) {
            var ADDRlatLng = null
            if (i.FVAddrGPSLat && i.FVAddrGPSLng) {
                ADDRlatLng = new google.maps.LatLng({ lat: parseFloat(i.FVAddrGPSLat), lng: parseFloat(i.FVAddrGPSLng) });
            }
            var FOTOlatLng = null
            if (i.DocGPSLat && i.DocGPSLng) {
                FOTOlatLng = new google.maps.LatLng({ lat: parseFloat(i.DocGPSLat), lng: parseFloat(i.DocGPSLng) });
            }
            var OSNlatLng = null
            if (i.VR1_GPSLat && i.VR1_GPSLng) {
                OSNlatLng = new google.maps.LatLng({ lat: parseFloat(i.VR1_GPSLat), lng: parseFloat(i.VR1_GPSLng) });
            }

            var bounds = new google.maps.LatLngBounds();
            for (var i = 0; i < polylines.length; i++) {
                polylines[i].setMap(null);
            }
            polylines = [];
            for (var i = 0; i < markerArray.length; i++) {
                markerArray[i].setMap(null);
            }
            markerArray = [];
            for (var i = 0; i < infoWindows.length; i++) {
                infoWindows[i].setMap(null);
            }
            infoWindows = [];

            if (ADDRlatLng) { bounds.extend(ADDRlatLng); }
            if (FOTOlatLng) { bounds.extend(FOTOlatLng); }
            if (OSNlatLng) { bounds.extend(OSNlatLng); }
            map.fitBounds(bounds);

            if (ADDRlatLng) {
                var ADDR = new google.maps.Marker({
                    position: ADDRlatLng,
                    map: map,
                    icon: {
                        path: "M-20,0a20,20 0 1,0 40,0a20,20 0 1,0 -40,0",
                        fillColor: '#007acc',
                        fillOpacity: 1,
                        strokeColor: "#ffffff",
                        strokeWeight: 1,
                        scale: .5
                    },
                    label: {
                        text: "A",
                        color: '#ffffff',
                    }
                });
                markerArray.push(ADDR);
                addressFromLatLng(ADDRlatLng, function (result) {
                    var infowindow = new google.maps.InfoWindow({
                        content: "<b>@Html.Raw(Language.Key_Osn): </b>" + result
                    });
                    ADDR.addListener('click', function () {
                        $.each(infoWindows, function (a, b) {
                            b.close();
                        });
                        infowindow.open(map, ADDR);
                    });
                    infoWindows.push(infowindow)
                    infowindow.open(map, ADDR);
                })
            }

            if (FOTOlatLng) {
                var lineToFOTO = new google.maps.Polyline({
                    path: [ADDRlatLng, FOTOlatLng],
                    strokeColor: "#007acc",
                    strokeOpacity: 1,
                    strokeWeight: 2,
                    icons: [{
                        icon: { path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW },
                        offset: '50%'
                    }],
                    map: map
                });
                polylines.push(lineToFOTO);
                var FOTO = new google.maps.Marker({
                    position: FOTOlatLng,
                    map: map,
                    icon: {
                        path: "M-20,0a20,20 0 1,0 40,0a20,20 0 1,0 -40,0",
                        fillColor: '#13a300',
                        fillOpacity: 1,
                        strokeColor: "#ffffff",
                        strokeWeight: 1,
                        scale: .5
                    },
                    label: {
                        text: " ",
                        color: '#ffffff',
                    }
                });
                markerArray.push(FOTO);
                addressFromLatLng(FOTOlatLng, function (result) {
                    var infowindow = new google.maps.InfoWindow({
                        content: "<b>@Html.Raw(Language.Key_Foto): </b>" + result
                    });
                    infoWindows.push(infowindow)
                    FOTO.addListener('click', function () {
                        $.each(infoWindows, function (a, b) {
                            b.close();
                        });
                        infowindow.open(map, FOTO);
                    });
                })
            }

            if (OSNlatLng) {
                var lineToOSN = new google.maps.Polyline({
                    path: [ADDRlatLng, OSNlatLng],
                    strokeColor: "#007acc",
                    strokeOpacity: 1,
                    strokeWeight: 2,
                    icons: [{
                        icon: { path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW },
                        offset: '50%'
                    }],
                    map: map
                });
                polylines.push(lineToOSN);
                var OSN = new google.maps.Marker({
                    position: OSNlatLng,
                    map: map,
                    icon: {
                        path: "M-20,0a20,20 0 1,0 40,0a20,20 0 1,0 -40,0",
                        fillColor: '#9e2a00',
                        fillOpacity: 1,
                        strokeColor: "#ffffff",
                        strokeWeight: 1,
                        scale: .5
                    },
                    label: {
                        text: " ",
                        color: '#ffffff',
                    }
                });
                markerArray.push(OSN);
                addressFromLatLng(OSNlatLng, function (result) {
                    var infowindow = new google.maps.InfoWindow({
                        content: "<b>@Html.Raw(Language.Key_Zapis): </b>" + result
                    });
                    infoWindows.push(infowindow)
                    OSN.addListener('click', function () {
                        $.each(infoWindows, function (a, b) {
                            b.close();
                        });
                        infowindow.open(map, OSN);
                    });
                })
            }
        }

        function calculateDistance(latLng1, latLng2) {
            var R = 6371e3;
            var φ1 = toRadians(latLng1.lat);
            var φ2 = toRadians(latLng2.lat);
            var Δφ = toRadians(latLng2.lat - latLng1.lat);
            var Δλ = toRadians(latLng2.lng - latLng1.lng);

            var a = Math.sin(Δφ / 2) * Math.sin(Δφ / 2) +
                    Math.cos(φ1) * Math.cos(φ2) *
                    Math.sin(Δλ / 2) * Math.sin(Δλ / 2);
            var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));

            return d = R * c;
        }

        function toRadians(deg) {
            return deg * (Math.PI / 180)
        }

        function changeMapStyle(e) { var t = null; switch (e) { case "night": t = [{ elementType: "geometry", stylers: [{ color: "#242f3e" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#746855" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#242f3e" }] }, { featureType: "administrative.locality", elementType: "labels.text.fill", stylers: [{ color: "#d59563" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#d59563" }] }, { featureType: "poi.park", elementType: "geometry", stylers: [{ color: "#263c3f" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#6b9a76" }] }, { featureType: "road", elementType: "geometry", stylers: [{ color: "#38414e" }] }, { featureType: "road", elementType: "geometry.stroke", stylers: [{ color: "#212a37" }] }, { featureType: "road", elementType: "labels.text.fill", stylers: [{ color: "#9ca5b3" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#746855" }] }, { featureType: "road.highway", elementType: "geometry.stroke", stylers: [{ color: "#1f2835" }] }, { featureType: "road.highway", elementType: "labels.text.fill", stylers: [{ color: "#f3d19c" }] }, { featureType: "transit", elementType: "geometry", stylers: [{ color: "#2f3948" }] }, { featureType: "transit.station", elementType: "labels.text.fill", stylers: [{ color: "#d59563" }] }, { featureType: "water", elementType: "geometry", stylers: [{ color: "#17263c" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#515c6d" }] }, { featureType: "water", elementType: "labels.text.stroke", stylers: [{ color: "#17263c" }] }]; break; case "aubergine": t = [{ elementType: "geometry", stylers: [{ color: "#1d2c4d" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#8ec3b9" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#1a3646" }] }, { featureType: "administrative.country", elementType: "geometry.stroke", stylers: [{ color: "#4b6878" }] }, { featureType: "administrative.land_parcel", elementType: "labels.text.fill", stylers: [{ color: "#64779e" }] }, { featureType: "administrative.province", elementType: "geometry.stroke", stylers: [{ color: "#4b6878" }] }, { featureType: "landscape.man_made", elementType: "geometry.stroke", stylers: [{ color: "#334e87" }] }, { featureType: "landscape.natural", elementType: "geometry", stylers: [{ color: "#023e58" }] }, { featureType: "poi", elementType: "geometry", stylers: [{ color: "#283d6a" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#6f9ba5" }] }, { featureType: "poi", elementType: "labels.text.stroke", stylers: [{ color: "#1d2c4d" }] }, { featureType: "poi.park", elementType: "geometry.fill", stylers: [{ color: "#023e58" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#3C7680" }] }, { featureType: "road", elementType: "geometry", stylers: [{ color: "#304a7d" }] }, { featureType: "road", elementType: "labels.text.fill", stylers: [{ color: "#98a5be" }] }, { featureType: "road", elementType: "labels.text.stroke", stylers: [{ color: "#1d2c4d" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#2c6675" }] }, { featureType: "road.highway", elementType: "geometry.stroke", stylers: [{ color: "#255763" }] }, { featureType: "road.highway", elementType: "labels.text.fill", stylers: [{ color: "#b0d5ce" }] }, { featureType: "road.highway", elementType: "labels.text.stroke", stylers: [{ color: "#023e58" }] }, { featureType: "transit", elementType: "labels.text.fill", stylers: [{ color: "#98a5be" }] }, { featureType: "transit", elementType: "labels.text.stroke", stylers: [{ color: "#1d2c4d" }] }, { featureType: "transit.line", elementType: "geometry.fill", stylers: [{ color: "#283d6a" }] }, { featureType: "transit.station", elementType: "geometry", stylers: [{ color: "#3a4762" }] }, { featureType: "water", elementType: "geometry", stylers: [{ color: "#0e1626" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#4e6d70" }] }]; break; case "silver": t = [{ elementType: "geometry", stylers: [{ color: "#f5f5f5" }] }, { elementType: "labels.icon", stylers: [{ visibility: "off" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#616161" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#f5f5f5" }] }, { featureType: "administrative.land_parcel", elementType: "labels.text.fill", stylers: [{ color: "#bdbdbd" }] }, { featureType: "poi", elementType: "geometry", stylers: [{ color: "#eeeeee" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { featureType: "poi.park", elementType: "geometry", stylers: [{ color: "#e5e5e5" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#9e9e9e" }] }, { featureType: "road", elementType: "geometry", stylers: [{ color: "#ffffff" }] }, { featureType: "road.arterial", elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#dadada" }] }, { featureType: "road.highway", elementType: "labels.text.fill", stylers: [{ color: "#616161" }] }, { featureType: "road.local", elementType: "labels.text.fill", stylers: [{ color: "#9e9e9e" }] }, { featureType: "transit.line", elementType: "geometry", stylers: [{ color: "#e5e5e5" }] }, { featureType: "transit.station", elementType: "geometry", stylers: [{ color: "#eeeeee" }] }, { featureType: "water", elementType: "geometry", stylers: [{ color: "#c9c9c9" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#9e9e9e" }] }]; break; case "dark": t = [{ elementType: "geometry", stylers: [{ color: "#212121" }] }, { elementType: "labels.icon", stylers: [{ visibility: "off" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#212121" }] }, { featureType: "administrative", elementType: "geometry", stylers: [{ color: "#757575" }] }, { featureType: "administrative.country", elementType: "labels.text.fill", stylers: [{ color: "#9e9e9e" }] }, { featureType: "administrative.land_parcel", stylers: [{ visibility: "off" }] }, { featureType: "administrative.locality", elementType: "labels.text.fill", stylers: [{ color: "#bdbdbd" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { featureType: "poi.park", elementType: "geometry", stylers: [{ color: "#181818" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#616161" }] }, { featureType: "poi.park", elementType: "labels.text.stroke", stylers: [{ color: "#1b1b1b" }] }, { featureType: "road", elementType: "geometry.fill", stylers: [{ color: "#2c2c2c" }] }, { featureType: "road", elementType: "labels.text.fill", stylers: [{ color: "#8a8a8a" }] }, { featureType: "road.arterial", elementType: "geometry", stylers: [{ color: "#373737" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#3c3c3c" }] }, { featureType: "road.highway.controlled_access", elementType: "geometry", stylers: [{ color: "#4e4e4e" }] }, { featureType: "road.local", elementType: "labels.text.fill", stylers: [{ color: "#616161" }] }, { featureType: "transit", elementType: "labels.text.fill", stylers: [{ color: "#757575" }] }, { featureType: "water", elementType: "geometry", stylers: [{ color: "#000000" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#3d3d3d" }] }]; break; case "retro": t = [{ elementType: "geometry", stylers: [{ color: "#ebe3cd" }] }, { elementType: "labels.text.fill", stylers: [{ color: "#523735" }] }, { elementType: "labels.text.stroke", stylers: [{ color: "#f5f1e6" }] }, { featureType: "administrative", elementType: "geometry.stroke", stylers: [{ color: "#c9b2a6" }] }, { featureType: "administrative.land_parcel", elementType: "geometry.stroke", stylers: [{ color: "#dcd2be" }] }, { featureType: "administrative.land_parcel", elementType: "labels.text.fill", stylers: [{ color: "#ae9e90" }] }, { featureType: "landscape.natural", elementType: "geometry", stylers: [{ color: "#dfd2ae" }] }, { featureType: "poi", elementType: "geometry", stylers: [{ color: "#dfd2ae" }] }, { featureType: "poi", elementType: "labels.text.fill", stylers: [{ color: "#93817c" }] }, { featureType: "poi.park", elementType: "geometry.fill", stylers: [{ color: "#a5b076" }] }, { featureType: "poi.park", elementType: "labels.text.fill", stylers: [{ color: "#447530" }] }, { featureType: "road", elementType: "geometry", stylers: [{ color: "#f5f1e6" }] }, { featureType: "road.arterial", elementType: "geometry", stylers: [{ color: "#fdfcf8" }] }, { featureType: "road.highway", elementType: "geometry", stylers: [{ color: "#f8c967" }] }, { featureType: "road.highway", elementType: "geometry.stroke", stylers: [{ color: "#e9bc62" }] }, { featureType: "road.highway.controlled_access", elementType: "geometry", stylers: [{ color: "#e98d58" }] }, { featureType: "road.highway.controlled_access", elementType: "geometry.stroke", stylers: [{ color: "#db8555" }] }, { featureType: "road.local", elementType: "labels.text.fill", stylers: [{ color: "#806b63" }] }, { featureType: "transit.line", elementType: "geometry", stylers: [{ color: "#dfd2ae" }] }, { featureType: "transit.line", elementType: "labels.text.fill", stylers: [{ color: "#8f7d77" }] }, { featureType: "transit.line", elementType: "labels.text.stroke", stylers: [{ color: "#ebe3cd" }] }, { featureType: "transit.station", elementType: "geometry", stylers: [{ color: "#dfd2ae" }] }, { featureType: "water", elementType: "geometry.fill", stylers: [{ color: "#b9d3c2" }] }, { featureType: "water", elementType: "labels.text.fill", stylers: [{ color: "#92998d" }] }] } map.setOptions({ styles: t }) }
</script>