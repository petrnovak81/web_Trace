<div id="vw_CampMember" style="flex: auto;height: calc(100% - 44px);" data-bind="source: Group, events: { dataBound: groupDataBound, change: groupChange }"></div>
<script>
    $(document).ready(function () {
        $("#vw_CampMember").kendoGrid({
            scrollable: true,
            reorderable: true,
            autoBind: false,
            selectable: true,
            resizable: true,
            pageable: {
                'previousNext': true,
                'numeric': true,
                'pageSizes': false,
                'info': false,
                'refresh': false
            },
            columns: [
{ 'template': '<a href="\\#" style="color:\\#c5394e;" class="k-icon k-i-close-circle" data-bind="events: { click: deleteFromTrace }"></a>', 'headerTemplate': ' ', 'width': 23 },
{ 'field': 'MemberOrder', 'template': '<input type="number" onclick="$(this).select();" data-bind="value: MemberOrder, events: { change: groupOrderEdit }" style="width: 100%;border: 0" />', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL110)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL110)', 'width': 43 },
{ 'field': 'FullName', 'template': '#=CellString(FullName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL2)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL12)', 'width': 130 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL3)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL13)', 'width': 100 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL4)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL14)', 'width': 80 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL5)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL15)', 'width': 100 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL6)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL16)', 'width': 80 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL7)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL7)', 'width': 80 },
{ 'field': 'VisitDatePlan', 'template': '#=CellDate(VisitDatePlan)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL81)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL81)', 'width': 80 },
{ 'field': 'VisitDatePlanNoChange', 'template': '#=CellBool(VisitDatePlanNoChange)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL91)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL91)', 'width': 30 },
{ 'field': 'GPSLat', 'template': '#=CellString(GPSLat)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL20)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL20)', 'width': 80 },
{ 'field': 'GPSLng', 'template': '#=CellString(GPSLng)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL21)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL21)', 'width': 80 },
{ 'field': 'AddrFVisitComment', 'template': '#=CellDate(AddrFVisitComment)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampMemberTBL101)'), 'title': '@Html.Raw(Language.vw_CampMemberTBL101)', 'width': 150 },
            ]
        });
    });
</script>

<!-- { 'template': '<a href=\'\\#\' style=\'color:\\#c5394e;\' class=\'k-icon k-i-close-circle\' data-bind=\'events: { click: deleteFromTrace }\'></a>', 'headerTemplate': ' ', 'width': 23 },
                { 'template': '<a href=\'\\#\' style=\'color:\\#749f3e;\' class=\'k-icon k-i-check-circle\'></a>', 'headerTemplate': ' ', 'width': 23 }, -->