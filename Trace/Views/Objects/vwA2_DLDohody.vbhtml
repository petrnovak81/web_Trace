<div id="SpisyDL" style="height: 100%;"  data-bind="source: SpisyDL, events: { dataBound: SpisyDL_dataBound, change: SpisyDL_change, detailInit: SpisyDL_detailInit }"></div>
<script>
    $(document).ready(function () {
        $("#SpisyDL").kendoGrid({
            scrollable: true,
            reorderable: true,
            editable: false,
            filterable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
            selectable: "single",
            resizable: true,
            columnMenu: true,
            columnMenuInit: function (e) {
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-filter-item"))
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-separator").last())
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-desc"))
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-asc"))
            },
            detailTemplate: kendo.template($("#SpisyDLSub").html()),
            pageable: {
                'previousNext': false,
                'numeric': false,
                'pageSizes': false,
                'info': true,
                'refresh': false
            },
            columns: [
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A2_SeznamDluzDetailDohody_URG)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_URG)', 'width': 25 },
                { 'field': 'GPSValid', 'template': '#=gpsMarker(GPSValid, AddrLocalGovernment)#', 'headerTemplate': '<i class="fa fa-map-marker" title="@Html.Raw(Language.A2_SeznamDluzDetailDohody_GPSValid)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_GPSValid)', 'width': 25 },
{ 'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersSurname)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersSurname)', 'width': 130 },
{ 'field': 'PersName', 'template': '#=CellString(PersName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersName)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersName)', 'width': 130 },
{ 'field': 'PersRC', 'template': '#=CellRC(PersRC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersRC)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersRC)', 'width': 80 },
{ 'field': 'PersBirthDate', 'template': '#=CellDate(PersBirthDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersBirthDate)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersBirthDate)', 'width': 70 },
{ 'field': 'SumActualDebit', 'template': '#=CellMoney(SumActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_SumActualDebit)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_SumActualDebit)', 'width': 60 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersRegion)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersRegion)', 'width': 130 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersZipCode)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersZipCode)', 'width': 60 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersCity)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersCity)', 'width': 130 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersStreet)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersStreet)', 'width': 130 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersHouseNum)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersHouseNum)', 'width': 60 },
{ 'field': 'PersIC', 'template': '#=CellString(PersIC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersIC)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailDohody_PersIC)', 'width': 80 },
            ]
        });
    });
    </script>

@Html.Partial("~/Views/Objects/vwA2_DLDohodySub.vbhtml")
