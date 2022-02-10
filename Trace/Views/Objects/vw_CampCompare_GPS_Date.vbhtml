<div id="vw_CampCompare_GPS_Date" style="flex: auto;height: 100%;" data-bind="source: vw_CampCompare_GPS_Date, events: { dataBound: vw_CampCompare_GPS_Date_dataBound, change: vw_CampCompare_GPS_Date_change }"></div>
<script>
    $(document).ready(function () {
        $("#vw_CampCompare_GPS_Date").kendoGrid({
            scrollable: true,
            reorderable: true,
            editable: false,
            filterable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
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
{ 'field': 'ACC', 'template': '#=CellString(ACC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_CisloSpisu)'), 'title': '@Html.Raw(Language.Key_CisloSpisu)', 'width': 100 },
{ 'field': 'UserLastName', 'template': '#=CellString(UserLastName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_Inspektor)'), 'title': '@Html.Raw(Language.Key_Inspektor)', 'width': 100 },
                { 'field': 'VR1_DateOSN', 'template': '#=CellDateTime(VR1_DateOSN)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_DatumOsn)'), 'title': '@Html.Raw(Language.Key_DatumOsn)', 'width': 100 },
                { 'field': 'DocuSentDate', 'template': '#=CellDateTime(DocuSentDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_DatumFoto)'), 'title': '@Html.Raw(Language.Key_DatumFoto)', 'width': 100 },
                { 'field': 'DatumZapisu', 'template': '#=CellDateTime(DatumZapisu)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_DatumZapisu)'), 'title': '@Html.Raw(Language.Key_DatumZapisu)', 'width': 100 },
{ 'field': 'Rozdil_DatumOSN_Foto', 'template': '#=CellString(Rozdil_DatumOSN_Foto)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_RozdilDnyOsnAFoto)'), 'title': '@Html.Raw(Language.Key_RozdilDnyOsnAFoto)', 'width': 100 },
{ 'field': 'Rozdil_DatumOSN_DatumZapisu', 'template': '#=CellString(Rozdil_DatumOSN_DatumZapisu)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_RozdilDnyOsnAZapis)'), 'title': '@Html.Raw(Language.Key_RozdilDnyOsnAZapis)', 'width': 100 },
{ 'field': 'Vzdalenost_AddrOSN_Zapis', 'template': '#=CellThousand(Vzdalenost_AddrOSN_Zapis)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_VzdalenosMetryOsnAZapis)'), 'title': '@Html.Raw(Language.Key_VzdalenosMetryOsnAZapis)', 'width': 100 },
{ 'field': 'Vzdalenost_AddrOSN_Foto', 'template': '#=CellThousand(Vzdalenost_AddrOSN_Foto)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.Key_VzdalenosMetryOsnAFoto)'), 'title': '@Html.Raw(Language.Key_VzdalenosMetryOsnAFoto)', 'width': 100 },
            ]
        });
    });
</script>
