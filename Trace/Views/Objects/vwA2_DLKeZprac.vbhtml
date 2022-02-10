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
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A2_SeznamDluzDetailZprac_URG)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_URG)', 'width': 30 },
{ 'field': 'GPSValid', 'template': '# if (GPSValid) { # <a data-bind="events: { click: setGps }" href="\\#" class="fa fa-map-marker" style="color: green"></a> # } else { # <a data-bind="events: { click: setGps }" href="\\#" class="fa fa-map-marker" style="color: red"></a> # } #', 'headerTemplate': '<i class="fa fa-map-marker" title="@Html.Raw(Language.A2_SeznamDluzDetailZprac_GPSValid)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_GPSValid)', 'width': 30 },
{ 'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonSurname)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonSurname)', 'width': 130 },
{ 'field': 'PersName', 'template': '#=CellString(PersName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonName)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonName)', 'width': 130 },
{ 'field': 'PersRC', 'template': '#=CellRC(PersRC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonRC)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonRC)', 'width': 90 },
{ 'field': 'PersBirthDate', 'template': '#=CellDate(PersBirthDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonBirthDate)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonBirthDate)', 'width': 80 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersRegion)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersRegion)', 'width': 130 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersCity)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersCity)', 'width': 140 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersZipCode)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersZipCode)', 'width': 60 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersStreet)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersStreet)', 'width': 130 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersHouseNum)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersHouseNum)', 'width': 70 },
{ 'field': 'PersIC', 'template': '#=CellString(PersIC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonIC)'), 'title': '@Html.Raw(Language.A2_SeznamDluzDetailZprac_PersonIC)' },
            ]
        });
    });
    </script>

@Html.Partial("~/Views/Objects/vwA2_DLKeZpracSub.vbhtml")
