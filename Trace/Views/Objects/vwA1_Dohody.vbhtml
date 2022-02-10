<div id="Spisy" style="height: 100%;" data-bind="source: Spisy, events: { dataBound: Spisy_dataBound, change: Spisy_change }"></div>
<script>
    function _NextPaymentDate(d, r) {
        var bg = "";
        switch (r) {
            case 1:
                break;
            case 2:
                d = null;
                break;
            case 3:
                bg = "background:#ffc4c4;";
                break;
            case 4:
                bg = "background:rgb(188,220,244);";
                break;
        }
        if (d) {
            var obj = new Date(d);
            var v = kendo.toString(obj, "d").replace(/ /g, "");
            return "<div title='" + v + "' style='text-align:right;height:100%;" + bg + "'>" + v + "</div>";
        } else {
            return "";
        };
    }

    function _NextPaymentAmountAwait(value, currency, css, r) {
        var bg = "";
        switch (r) {
            case 1:
                break;
            case 2:
                value = null;
                break;
            case 3:
                bg = "background:#ffc4c4;";
                break;
            case 4:
                bg = "background:rgb(188,220,244);";
                break;
        }
        if (value) {
            var v = kendo.toString(parseFloat(value), "n2");
            if (currency == undefined) {
                currency = "";
            }
            return "<div style='text-align: right;height:100%;" + (css ? css : "") + bg + "' title='" + v + " " + currency + "'>" + v + " " + currency + "</div>";
        } else {
            return "";
        };
    }
    //Èekající
    //Uhrazeno
    //Porušený
    //Zrušeno
    function _ValidityTypeTxt(value, r) {
        var bg = "";
        switch (r) {
            case 1:
                break;
            case 2:
                break;
            case 3:
                bg = "background:#ffc4c4;";
                break;
            case 4:
                bg = "background:rgb(188,220,244);";
                break;
        }
        if (value) {
            return "<div class='cellString' title='" + value + "' style='height:100%;" + bg + "'>" + value + "</div>";
        } else {
            return "";
        };
    }

    $(document).ready(function () {
        $("#Spisy").kendoGrid({
            scrollable: true,
            reorderable: true,
            editable: false,
            filterable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
            selectable: 'single',
            resizable: true,
            columnMenu: true,
            columnMenuInit: function (e) {
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-filter-item"))
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-separator").last())
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-desc"))
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-asc"))
            },
            pageable: {
                'previousNext': false,
                'numeric': false,
                'pageSizes': false,
                'info': true,
                'refresh': false
            },
            columns:  [
{ 'headerTemplate': '<input type="checkbox" title="@Html.Raw(Language.Spisy_SelectAll)" id="a1_header-chb">', 'template': '<input type="checkbox" data-bind="events: { change: selectRow }" id="ch-#=uid#" class="checkrow">', width: 30 },
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A1_SeznamSpisDohody_URG)"></i>', 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_URG)', 'width': 30 },
{ 'field': 'GPSValid', 'template': '#=gpsMarker(GPSValid, AddrLocalGovernment)#', 'headerTemplate': '<i class="fa fa-map-marker" title="@Html.Raw(Language.A1_SeznamSpisDohody_GPS)"></i>', 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_GPS)', 'width': 30 },
{ 'field': 'ACC', 'template': '#=CellString(ACC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_ACC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_ACC)', 'width': 100 },
{ 'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersonSurname)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersonSurname)', 'width': 130 },
{ 'field': 'PersName', 'template': '#=CellString(PersName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersonName)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersonName)', 'width': 130 },
{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_CreditorAlias)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_CreditorAlias)', 'width': 200 },
{ 'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_ActualDebit)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_ActualDebit)', 'width': 70 },
{ 'field': 'PersIC', 'template': '#=CellString(PersIC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersonIC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersonIC)', 'width': 90 },
{ 'field': 'NextPaymentDate', 'template': '#=_NextPaymentDate(NextPaymentDate, rr_PAValidityType)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_NextPaymentDate)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_NextPaymentDate)', 'width': 90 },
{ 'field': 'NextPaymentAmountAwait', 'template': '#=_NextPaymentAmountAwait(NextPaymentAmountAwait, null, null, rr_PAValidityType)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_NextPaymentAmountAwait)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_NextPaymentAmountAwait)', 'width': 90 },
{ 'field': 'LastPaymentDate', 'template': '#=CellDate(LastPaymentDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_LastPaymentDate)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_LastPaymentDate)', 'width': 90 },
{ 'field': 'LastPaymentAmountReal', 'template': '#=CellMoney(LastPaymentAmountReal)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_LastPaymentAmountReal)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_LastPaymentAmountReal)', 'width': 90 },
{ 'field': 'DateReturnToCreditor', 'template': '#=CellDate(DateReturnToCreditor)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_DateReturnToCreditor)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_DateReturnToCreditor)', 'width': 90 },
{ 'field': 'DateLapse', 'template': '#=CellDate(DateLapse)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_DateLapse)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_DateLapse)', 'width': 90 },
{ 'field': 'DebtLastOSN', 'template': '#=CellDate(DebtLastOSN)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastOSN)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastOSN)', 'width': 100 },
{ 'field': 'DebtLastContact', 'template': '#=CellDate(DebtLastContact)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastContact)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastContact)', 'width': 100 },
{ 'field': 'PersPhone', 'template': '#=CellPhone(PersPhone)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_DebtPhone)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_DebtPhone)', 'width': 100 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_okres)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_okres)', 'width': 130 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersCity)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersCity)', 'width': 130 },
{ 'field': 'PersRC', 'template': '#=CellRC(PersRC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersonRC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersonRC)', 'width': 90 },
{ 'field': 'PersBirthDate', 'template': '#=CellDate(PersBirthDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersonBirthDate)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersonBirthDate)', 'width': 90 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersZipCode)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersZipCode)', 'width': 60 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersStreet)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersStreet)', 'width': 150 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersHouseNum)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersHouseNum)', 'width': 80 },
{ 'field': 'ValidityTypeTxt', 'template': '#=_ValidityTypeTxt(ValidityTypeTxt, rr_PAValidityType)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_ValidityTypeTxt)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_ValidityTypeTxt)', 'width': 200 },
    ]
        });
    });
</script>
