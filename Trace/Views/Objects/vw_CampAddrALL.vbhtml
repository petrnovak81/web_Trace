<div id="vw_CampAddrALL" style="flex: auto;height: 100%;" data-bind="source: Address, events: { dataBound: Address_dataBound }"></div>
<script>
    $(document).ready(function () {
        $("#vw_CampAddrALL").kendoGrid({
            scrollable: true,
            reorderable: true,
            editable: false,
            filterable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
            autoBind: true,
            selectable: true,
            resizable: true,
            columnMenu: true,
            columnMenuInit: function(e) {
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
{ 'headerAttributes': { id: 'checkboxes' }, 'headerTemplate': '<input type="checkbox" id="Address_CheckAll" data-bind="events: { change: Address_CheckAll }" class="k-checkbox"><label class="k-checkbox-label" for="Address_CheckAll" data-uid="#=uid#"></label>', 'template': '<input type="checkbox" data-bind="events: { change: Address_Check }" id="ch-#=uid#" class="k-checkbox checkrow"><label class="k-checkbox-label" data-bind="visible: Address_CheckVisible" for="ch-#=uid#"></label>', width: 30 },
{ 'headerAttributes': { id: 'getaccs' }, 'template': '<a href="\\#" style="color:\\#425ff4;" class="k-icon k-i-search" data-bind="events: { click: GetAccs }"></a>', 'headerTemplate': ' ', 'width': 23 },
{ 'headerAttributes': { id: 'deletecontrol' }, 'template': '<a href="\\#" style="color:\\#c5394e;" class="k-icon k-i-close-circle" data-bind="events: { click: AddressRemove }"></a>', 'headerTemplate': ' ', 'width': 23 },
{ 'headerAttributes': { id: 'editcontrol' }, 'template': '<a href="\\#" style="color:\\#425ff4;" class="k-icon k-i-edit" data-bind="events: { click: AddressUpdate }"></a>', 'headerTemplate': ' ', 'width': 23 },
                { 'field': 'GPSValid', 'template': '#=gpsMarker(GPSValid, AddrLocalGovernment)#', 'headerTemplate': '<i class="fa fa-map-marker" title=""></i>', 'title': 'GPS Valid', 'width': 30 },
{ 'field': 'VisitDatePlanNoChange', 'template': '#=CellBool(VisitDatePlanNoChange)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL1)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL12)', 'width': 30 },
{ 'field': 'Surname', 'template': '#=CellString(Surname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL2)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL13)', 'width': 100 },
{ 'field': 'Name', 'template': '#=CellString(Name)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL3)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL14)', 'width': 100 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL4)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL15)', 'width': 100 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL5)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL16)', 'width': 50 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL6)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL17)', 'width': 100 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL7)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL18)', 'width': 70 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL8)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL19)', 'width': 100 },
{ 'field': 'PersAddressVisited', 'template': '#=CellBool(PersAddressVisited)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL9)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL20)', 'width': 30 },
{ 'field': 'VisitDatePlan', 'template': '#=CellDate(VisitDatePlan)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL10)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL21)', 'width': 100 },
{ 'field': 'AddrFVisitComment', 'template': '#=CellString(AddrFVisitComment)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampAddrALLTBL11)'), 'title': '@Html.Raw(Language.vw_CampAddrALLTBL22)', 'width': 100 },
            ]
        });
    });
</script>
