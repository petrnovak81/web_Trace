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
            //rowTemplate: kendo.template($("#spisdlrowtemplate").html()),
            columns: [
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A2_SeznamDluzDetailOSN_URG)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_URG)', 'width': 30 },
                { 'field': 'GPSValid', 'template': '#=gpsMarker(GPSValid, AddrLocalGovernment)#', 'headerTemplate': '<i class="fa fa-map-marker" title="@Html.Raw(Language.A2_SeznamDluzDetailOSN_GPSValid)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_GPSValid)', 'width': 30 },
{ 'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonSurname)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonSurname)', 'width': 130 },
{ 'field': 'PersName', 'template': '#=CellString(PersName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonName)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonName)', 'width': 130 },
{ 'field': 'VisitDatePlan', 'template': '#=CellDate(VisitDatePlan)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_VisitDatePlan)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_VisitDatePlan)', 'width': 90 },
{ 'field': 'VisitDatePlanNoChange', 'template': '#=CellBool(VisitDatePlanNoChange)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_VisitDatePlanNoChange)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_VisitDatePlanNoChange)', 'width': 30 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersRegion)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersRegion)', 'width': 130 },
{ 'field': 'SumActualDebit', 'template': '#=CellMoney(SumActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_ActualDebit)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_ActualDebit)', 'width': 80 },
{ 'field': 'PersBirthDate', 'template': '#=CellDate(PersBirthDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonBirthDate)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonBirthDate)', 'width': 90 },
{ 'field': 'PersRC', 'template': '#=CellRC(PersRC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonRC)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonRC)', 'width': 90 },
{ 'field': 'PersPhone', 'template': '#=CellPhone(PersPhone)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_Phone)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_Phone)', 'width': 90 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersCity)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersCity)', 'width': 130 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersZipCode)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersZipCode)', 'width': 60 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersStreet)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersStreet)', 'width': 130 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersHouseNum)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersHouseNum)', 'width': 70 },
{ 'field': 'PersIC', 'template': '#=CellString(PersIC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonIC)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailOSN_PersonIC)', 'width': 90 },
            ]
        });
    });
    </script>

@Html.Partial("~/Views/Objects/vwA2_DLOSNSub.vbhtml")
