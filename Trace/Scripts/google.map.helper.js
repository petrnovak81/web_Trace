function addressFromLatLng(latlng, callback) {
    var geocoder = new google.maps.Geocoder;
    geocoder.geocode({ 'location': latlng }, function (results, status) {
        if (status === 'OK') {
            if (results[0]) {
                callback(results[0].formatted_address);
            } else {
                callback("");
            }
        } else {
            callback("");
        }
    })
}

//preformatovani adresy na google
function parseAddress(address, callback) {
    var geocoder = new google.maps.Geocoder();
    try {
        geocoder.geocode({
            "address": address
        }, function (results, status) {
            callback(results)
        });
    } catch (ex) {
        console.log(ex)
    }
};

    function getJsonAddress(r) {
        if (r.length > 0) {
            var fa = r[0].formatted_address;
            var cp = r[0].address_components;
            var ge = r[0].geometry.location;

            //cislo za / cp
            var street_number = $.grep(cp, function (item) {
                if ($.inArray("street_number", item.types) > -1) {
                    return item;
                }
            })[0];
            street_number = (typeof street_number !== 'undefined' ? street_number.short_name : "");
            //cp
            var premise = $.grep(cp, function (item) {
                if ($.inArray("premise", item.types) > -1) {
                    return item;
                }
            })[0];
            premise = (typeof premise !== 'undefined' ? premise.short_name : "");
            //cast mesta
            var sublocality = $.grep(cp, function (item) {
                if ($.inArray("sublocality", item.types) > -1) {
                    return item;
                }
            })[0];
            sublocality = (typeof sublocality !== 'undefined' ? sublocality.short_name : "");
            //mesto
            var locality = $.grep(cp, function (item) {
                if ($.inArray("locality", item.types) > -1) {
                    return item;
                }
            })[0];
            locality = (typeof locality !== 'undefined' ? locality.short_name : "");
            //ulice
            var route = $.grep(cp, function (item) {
                if ($.inArray("route", item.types) > -1) {
                    return item;
                }
            })[0];
            route = (typeof route !== 'undefined' ? route.short_name : locality);
            //psc
            var postal_code = $.grep(cp, function (item) {
                if ($.inArray("postal_code", item.types) > -1) {
                    return item;
                }
            })[0];
            postal_code = (typeof postal_code !== 'undefined' ? postal_code.short_name : "");

            return {
                formatted_address: (typeof fa !== 'undefined' ? fa : null),
                street: route,
                number: (street_number != "" ? premise + "/" + street_number : premise),
                city: (sublocality ? sublocality + " " + locality : locality),
                zip: postal_code,
                lat: (typeof ge.lat() !== 'undefined' ? ge.lat() : null),
                lng: (typeof ge.lng() !== 'undefined' ? ge.lng() : null)
            };
        } else {
            return null;
        };
    }


    //ERROR	There was a problem contacting the Google servers.
    //INVALID_REQUEST	This GeocoderRequest was invalid.
    //OK	The response contains a valid GeocoderResponse.
    //OVER_QUERY_LIMIT	The webpage has gone over the requests limit in too short a period of time.
    //REQUEST_DENIED	The webpage is not allowed to use the geocoder.
    //UNKNOWN_ERROR	A geocoding request could not be processed due to a server error. The request may succeed if you try again.
    //ZERO_RESULTS	No result was found for this GeocoderRequest.
    function getStatusMsg(type) {
        switch (type) {
            case "ERROR":
                return "Při kontaktování serverů Google došlo k problému. Opakujte spuštění později." //There was a problem contacting the Google servers";
                break;
            case "INVALID_REQUEST":
                return "Tento GeocoderRequest byl neplatný" //This GeocoderRequest was invalid";
                break;
            case "OK":
                return "OK";
                break;
            case "OVER_QUERY_LIMIT":
                return "Webová stránka překročila limit žádostí v příliš krátké době. Opakujte spuštění později." //The webpage has gone over the requests limit in too short a period of time";
                break;
            case "REQUEST_DENIED":
                return "Webová stránka nesmí používat geocoder" //The webpage is not allowed to use the geocoder";
                break;
            case "UNKNOWN_ERROR":
                return "Žádost o geokódování nemohla být zpracována kvůli chybě serveru. Požadavek může uspět, pokud funkci spustíte opakovaně." //A geocoding request could not be processed due to a server error. The request may succeed if you try again";
                break;
            case "ZERO_RESULTS":
                return "Pro tento GeocoderRequest nebyl nalezen žádný výsledek. GPS souřadnice je třeba ručně nastavit." //No result was found for this GeocoderRequest";
                break;
            case "MORE_RESULTS":
                return "Více než jeden výsledek. GPS souřadnice je třeba ručně nastavit." //More than one result";
                break;
        }
    }

    function globalValidAddress(address, callback) {
        try {
            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({
                "address": address
            }, function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    if (results.length > 0) {
                        if (results.length === 1) {
                            var res = getJsonAddress(results)
                            //OK
                            callback(res, true, getStatusMsg("OK"), 1);
                        } else {
                            var res = getJsonAddress(results)
                            // > 1
                            callback(res, true, getStatusMsg("MORE_RESULTS"), 2);
                        }
                    } else {
                        // = 0
                        callback(null, false, getStatusMsg("ZERO_RESULTS"), 3);
                    }
                } else {
                    //ERROR
                    switch (status) {
                        case "MORE_RESULTS":
                            callback(res, true, getStatusMsg("MORE_RESULTS"), 2);
                            break;
                        case "ZERO_RESULTS":
                            callback(null, false, getStatusMsg("ZERO_RESULTS"), 3);
                            break;
                        default:
                            callback(null, false, getStatusMsg(status), 4);
                            break;
                    }
                }
            });
        } catch (ex) {
            callback(null, false, ex, 0);
        }
    }

    //tato funkce googlu vyzaduje potvrzeni urcovani polohy proto pouzivame https://ipinfo.io
    //function getCurrentPosition(callback) {
    //    // Try HTML5 geolocation.
    //    if (navigator.geolocation) {
    //        navigator.geolocation.getCurrentPosition(function (position) {
    //            callback(position);
    //        });
    //    } else {
    //        // Browser doesn't support Geolocation
    //        callback(null);
    //    }
    //}

function getCurrentPosition(callback) {
    $.getJSON('https://ipinfo.io?token=d4f1b4b80b7e9d', function (data) {
        callback(data);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        callback(false);
    });
};