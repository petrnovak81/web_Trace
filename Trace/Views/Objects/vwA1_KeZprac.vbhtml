<div id="Spisy" style="height: 100%;" data-bind="source: Spisy, events: { dataBound: Spisy_dataBound, change: Spisy_change }"></div>
<script>
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
            columns: [
{ 'headerTemplate': '<input type="checkbox" title="@Html.Raw(Language.Spisy_SelectAll)" id="a1_header-chb">', 'template': '<input type="checkbox" data-bind="events: { change: selectRow }" id="ch-#=uid#" class="checkrow">', width: 30 },
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A1_SeznamSpisZprac_URG)"></i>', 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_URG)', 'width': 30 },
{ 'field': 'GPSValid', 'template': '#=gpsMarker(GPSValid, AddrLocalGovernment)#', 'headerTemplate': '<i class="fa fa-map-marker" title="@Html.Raw(Language.A1_SeznamSpisZprac_GPSValid)"></i>', 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_GPSValid)', 'width': 30 },
{ 'field': 'MinDatum', 'template': '#=CellDate(MinDatum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_IDURGTxt)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_IDURGTxt)', 'width': 90 },
{ 'field': 'StateTxt', 'template': '#=CellString(StateTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_StateTxt)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_StateTxt)', 'width': 100 },
{ 'field': 'ACC', 'template': '#=CellString(ACC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_ACC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_ACC)', 'width': 90 },
{ 'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersonSurname)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersonSurname)', 'width': 130 },
{ 'field': 'PersName', 'template': '#=CellString(PersName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersonName)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersonName)', 'width': 130 },
{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_CreditorAlias)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_CreditorAlias)', 'width': 200 },
{ 'field': 'PersIC', 'template': '#=CellString(PersIC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersonIC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersonIC)', 'width': 80 },
{ 'field': 'LastDebtContacted', 'template': '#=CellDate(LastDebtContacted)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_DebtLastContact)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_DebtLastContact)', 'width': 90 },
{ 'field': 'DateReturnToCreditor', 'template': '#=CellDate(DateReturnToCreditor)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_DateReturnToCreditor)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_DateReturnToCreditor)', 'width': 90 },
{ 'field': 'DebtLastOSN', 'template': '#=CellDate(DebtLastOSN)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastOSN)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastOSN)', 'width': 100 },
{ 'field': 'DateLapse', 'template': '#=CellDate(DateLapse)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_DateLapse)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_DateLapse)', 'width': 90 },
{ 'field': 'PersPhone', 'template': '#=CellPhone(PersPhone)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersPhone)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersPhone)', 'width': 90 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersRegion)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersRegion)', 'width': 130 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersCity)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersCity)', 'width': 130 },
{ 'field': 'PersRC', 'template': '#=CellRC(PersRC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersonRC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersonRC)', 'width': 90 },
{ 'field': 'PersBirthDate', 'template': '#=CellDate(PersBirthDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersonBirthDate)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersonBirthDate)', 'width': 90 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersZipCode)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersZipCode)', 'width': 60 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersStreet)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersStreet)', 'width': 130 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisZprac_PersHouseNum)'), 'title': '@Html.Raw(Language.A1_SeznamSpisZprac_PersHouseNum)', 'width': 90 }
    ]
        });
    });
</script>
