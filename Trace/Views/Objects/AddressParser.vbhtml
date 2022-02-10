
<div id="winAddressParser" data-role="window"
    data-title="@Language.GPSWinTitle"
    data-width="800"
    data-modal="true"
    data-actions="['close']"
    style="display: none;" data-bind="events: { open: Open, resize: Resize }">
    <label>@Language.GPSWinLabel</label>
    <input type="text" class="k-textbox" data-bind="value: Address.PersAddrFull" disabled style="width: 100%" />
    <table id="winAddressParser_body" style="width: 100%">
        <tr>
            <th>@Language.GPSWinStreet</th>
            <th>@Language.GPSWinHouseNum</th>
            <th>@Language.GPSWinCity</th>
            <th>@Language.GPSWinZipCode</th>
            <th></th>
        </tr>
        <tr>
            <td>
                <input style="width: 100%;" type="text" class="k-textbox" data-bind="value: Address.PersStreet" /></td>
            <td>
                <input style="width: 100%;" type="text" class="k-textbox" data-bind="value: Address.PersHouseNum" /></td>
            <td>
                <input style="width: 100%;" type="text" class="k-textbox" data-bind="value: Address.PersCity" /></td>
            <td>
                <input style="width: 100%;" type="text" class="k-textbox" data-bind="value: Address.PersZipCode" /></td>
            <td>
                <button style="width: 100%;" type="button" class="k-button" data-bind="events: { click: ShowInMap }"><i class="fa fa-search" aria-hidden="true"></i> @Language.btnShow</button></td>
        </tr>
    </table>
    <div style="min-height: 400px;height:calc(100% - 200px);" id="winAddressParser_map"></div>
    <div id="map_controls_gps">
        <input class="k-textbox" style="width: 120px; margin-top: 10px; margin-right: 10px;" placeholder="Lat" data-bind="value: Address.GPSLat" readonly />
        <input class="k-textbox" style="width: 120px; margin-top: 10px; margin-right: 10px;" placeholder="Lng" data-bind="value: Address.GPSLng" readonly />
    </div>
    <div class="window-footer">
        <a href="#" data-bind="events: { click: SeznamMapy }" target="_blank" style="float:left;">zobrazit na mapy.cz</a>
        <button type="button" class="k-primary k-button" data-bind="events: { click: Save }">@Language.btnSave</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button>
    </div>
</div>
<script>
    var winAddressParser = new kendo.observable({
        Address: {
            IDSpisyOsobyAdresy: 0,
            PersStreet: "",
            PersHouseNum: "",
            PersCity: "",
            PersZipCode: "",
            GPSLat: 0,
            GPSLng: 0,
            GPSValid: false,
            PersAddrFull: "",
            IsExt: false
        },
        ShowInMap: function () {
            var adr = [
                this.Address.get("PersStreet") + " " + this.Address.get("PersHouseNum"),
                this.Address.get("PersCity") + " " + this.Address.get("PersZipCode")
            ].join(", ");
            var model = this;
            parseAddress(adr, function (r) {
                var loc = r[0].geometry.location;
                winAddressParser_map_marker.setPosition(loc);
                winAddressParser_map.panTo(loc);

                model.Address.set("GPSLat", loc.lat());
                model.Address.set("GPSLng", loc.lng());
            })
        },
        Resize: function (e) {
            google.maps.event.trigger(winAddressParser_map, 'resize');
        },
        Open: function () {      
            winAddressParserInitMap();
            setTimeout(function () {
                google.maps.event.trigger(winAddressParser_map, 'resize');
            }, 500);
        },
        Storno: function () {
            winAddressParser_win.close();
        },
        SeznamMapy: function (e) {
            var adr = winAddressParser.Address.get("PersAddrFull");
            $(e.currentTarget).attr("href", "https://mapy.cz/zakladni?q=" + adr)
        },
        Save: function () {
            var model = this;
            this.Address.set("GPSValid", true);
                this.Address.set("GPSValidDetail", 1);
                var url = '@Url.Action("tblSpisyOsobyAdresy_Save", "Api/Service")';
                var isext = this.Address.get("IsExt");
                if (isext) {
                    url = '@Url.Action("tblExternalAddress_Save", "Api/Service")';
            }
            this.Address.set("GPSValid", true);
            this.Address.set("GPSValidDetail", 1);
            $.post(url, this.get("Address").toJSON(), function (result) {
                model.set("Success", result.GPSValid);
                winAddressParser_win.close();
            });
            @*if (parseInt(this.Address.GPSLat) > 0 && parseInt(this.Address.GPSLng) > 0) {
                this.Address.set("GPSValid", true);
                this.Address.set("GPSValidDetail", 1);
                var url = '@Url.Action("tblSpisyOsobyAdresy_Save", "Api/Service")';
                var isext = this.Address.get("IsExt");
                if (isext) {
                    url = '@Url.Action("tblExternalAddress_Save", "Api/Service")';
                }
                $.post(url, this.get("Address").toJSON(), function (result) {
                    model.set("Success", result.GPSValid);
                    winAddressParser_win.close();
                });
            } else {
                message("Nelze uložit, GPS souřadnice jsou nulové.")
            };*@
        },
        Success: false
    });
    kendo.bind($("#winAddressParser"), winAddressParser);

    var winAddressParser_win,
            winAddressParser_map,
            winAddressParser_map_marker;
    //inicializace mapy
    function winAddressParserInitMap() {
        if (!winAddressParser_map) {
            winAddressParser_map = new google.maps.Map(document.getElementById('winAddressParser_map'), {
                center: { lat: 49.7856504, lng: 13.2323656 },
                zoom: 8,
                streetViewControl: true
            });

            winAddressParser_map_marker = new google.maps.Marker({
                position: { lat: 49.7856504, lng: 13.2323656 },
                draggable: true,
                map: winAddressParser_map
            });

            google.maps.event.addListener(winAddressParser_map_marker, 'dragend', function () {
                var p = winAddressParser_map_marker.getPosition();
                var lat = p.lat();
                var lng = p.lng();
                winAddressParser.Address.set("GPSLat", lat);
                winAddressParser.Address.set("GPSLng", lng);
            })

            var centerControlDiv = document.getElementById('map_controls_gps')
            centerControlDiv.index = 1;
            winAddressParser_map.controls[google.maps.ControlPosition.TOP_RIGHT].push(centerControlDiv);
        }
        winAddressParser_map.streetView.setVisible(false);
    };

    function CallWinAddressParser(url, id, callback) {
        winAddressParser.set("Address", {
            IDSpisyOsobyAdresy: 0,
            PersStreet: "",
            PersHouseNum: "",
            PersCity: "",
            PersZipCode: "",
            GPSLat: 0,
            GPSLng: 0,
            GPSValid: false,
            PersAddrFull: "",
            IsExt: false
        });
        //if (winAddressParser_map_marker) winAddressParser_map_marker.setMap(null);


        winAddressParser_win = $("#winAddressParser").data("kendoWindow");
        //kendo.ui.progress($("#winAddressParser"), true);
        $.get(url, { IDSpisyOsobyAdresy: id }, function (result) {
            var cont = (url.indexOf("tblExternalAddress") >= 0 ? true : false);
            winAddressParser.Address.set("IsExt", cont);

            if (result.Data) {
                try {
                    winAddressParser.Address.set("IDSpisyOsobyAdresy", id);
                    winAddressParser.Address.set("PersStreet", result.Data.PersStreet);
                    winAddressParser.Address.set("PersHouseNum", result.Data.PersHouseNum);
                    winAddressParser.Address.set("PersCity", result.Data.PersCity);
                    winAddressParser.Address.set("PersZipCode", result.Data.PersZipCode);
                    winAddressParser.Address.set("GPSLat", result.Data.GPSLat);
                    winAddressParser.Address.set("GPSLng", result.Data.GPSLng);
                    winAddressParser.Address.set("PersAddrFull", result.Data.PersAddrFull);

                    if (result.Data.GPSLat && result.Data.GPSLng) {
                        winAddressParser_map_marker.setPosition({ lat: parseFloat(result.Data.GPSLat), lng: parseFloat(result.Data.GPSLng) });
                    } else {
                        parseAddress(result.Data.PersAddrFull, function (r) {
                            var loc = r[0].geometry.location;
                            winAddressParser.Address.set("GPSLat", loc.lat());
                            winAddressParser.Address.set("GPSLng", loc.lng());
                            winAddressParser_map_marker.setPosition(loc);
                            winAddressParser_map.panTo(loc);
                        })
                    }
                    
                    winAddressParser_map.panTo({ lat: parseFloat(result.Data.GPSLat), lng: parseFloat(result.Data.GPSLng) });

                    kendo.ui.progress($("#winAddressParser"), false);
                } catch (ex) {
                    kendo.ui.progress($("#winAddressParser"), false);
                }
                //if (result.Data.GPSValid) {
                //    try {
                //        winAddressParser.Address.set("IDSpisyOsobyAdresy", id);
                //        winAddressParser.Address.set("PersStreet", result.Data.PersStreet);
                //        winAddressParser.Address.set("PersHouseNum", result.Data.PersHouseNum);
                //        winAddressParser.Address.set("PersCity", result.Data.PersCity);
                //        winAddressParser.Address.set("PersZipCode", result.Data.PersZipCode);
                //        winAddressParser.Address.set("GPSLat", result.Data.GPSLat);
                //        winAddressParser.Address.set("GPSLng", result.Data.GPSLng);
                //        winAddressParser.Address.set("PersAddrFull", result.Data.PersAddrFull);
                //        winAddressParser_map_marker.setPosition({ lat: parseFloat(result.Data.GPSLat), lng: parseFloat(result.Data.GPSLng) });
                //        winAddressParser_map.panTo({ lat: parseFloat(result.Data.GPSLat), lng: parseFloat(result.Data.GPSLng) });

                //        kendo.ui.progress($("#winAddressParser"), false);
                //    } catch (ex) {
                //        kendo.ui.progress($("#winAddressParser"), false);
                //    }
                //} else {
                //    parseAddress(result.Data.PersAddrFull, function (r) {
                //        try {
                //            var adr = getJsonAddress(r);

                //            winAddressParser.Address.set("IDSpisyOsobyAdresy", id);
                //            //winAddressParser.Address.set("PersAddrFull", result.Data.PersAddrFull);

                //            if (r) {
                //                winAddressParser.Address.set("PersStreet", adr.street);
                //                winAddressParser.Address.set("PersHouseNum", adr.number);
                //                winAddressParser.Address.set("PersCity", adr.city);
                //                winAddressParser.Address.set("PersZipCode", adr.zip);
                //                winAddressParser.Address.set("GPSLat", adr.lat);
                //                winAddressParser.Address.set("GPSLng", adr.lng);
                //                winAddressParser.Address.set("PersAddrFull", adr.formatted_address);
                //                winAddressParser_map_marker.setPosition(r[0].geometry.location);
                //                winAddressParser_map.panTo(r[0].geometry.location);
                //            }
                //            kendo.ui.progress($("#winAddressParser"), false);
                //        } catch (ex) {
                //            kendo.ui.progress($("#winAddressParser"), false);
                //        }
                //    })
                //}
                winAddressParser.set("Success", false);
                winAddressParser.bind("change", function (e) {
                    if (e.field === "Success") {
                        callback(e.sender.Address.GPSValid);
                    }
                });
            }
        });
        winAddressParser_win.center().open();
    };
</script>
