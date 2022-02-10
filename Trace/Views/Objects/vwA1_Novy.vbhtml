
<div id="Spisy" style="height:100%" data-bind="source: Spisy, events: { dataBound: Spisy_dataBound, change: Spisy_change }"></div>
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
{ 'headerTemplate': '<input type="checkbox" title="@Html.Raw(Language.Spisy_SelectAll)" id="a1_header-chb">', 'template': '<input type="checkbox" data-bind="events: { change: selectRow }" id="ch-#=uid#" class="checkrow">', width: 30 },
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.vwA_SpisyNovy_AlertExist)"></i>', 'title': '@Html.Raw(Language.vwA_SpisyNovy_AlertExist)', 'width': 30 },
                { 'field': 'GPSValid', 'template': '#=gpsMarker(GPSValid, AddrLocalGovernment)#', 'headerTemplate': '<i class="fa fa-map-marker" title="@Html.Raw(Language.vwA_SpisyNovy_GPSValid)"></i>', 'title': '@Html.Raw(Language.vwA_SpisyNovy_GPSValid)', 'width': 30 },
{ 'field': 'VisitDatePlan', 'template': '<a data-bind="events: { click: btnDateOSNPlan }" href="\\#"><i class="fa fa-calendar-plus-o"></i> <span data-bind="date: VisitDatePlan"></span></a>', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_VisitDateD1Plan)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_VisitDateD1Plan)', 'width': 100 },
{ 'field': 'ACC', 'template': '#=CellString(ACC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_ACC)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_ACC)', 'width': 130 },
{ 'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersSurname)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersSurname)', 'width': 130 },
{ 'field': 'PersName', 'template': '#=CellString(PersName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersName)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersName)', 'width': 130 },
{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_CreditorAlias)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_CreditorAlias)', 'width': 200 },
{ 'field': 'VisitDateSentFromMother', 'template': '#=CellDate(VisitDateSentFromMother)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_VisitDateSentFromMother)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_VisitDateSentFromMother)', 'width': 90 },
{ 'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_ActualDebit)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_ActualDebit)', 'width': 80 },
{ 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
{ 'field': 'PersIC', 'template': '#=CellString(PersIC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersIC)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersIC)', 'width': 90 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_Region)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_Region)', 'width': 130 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersCity)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersCity)', 'width': 140 },
{ 'field': 'PersRC', 'template': '#=CellRC(PersRC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersRC)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersRC)', 'width': 90 },
{ 'field': 'PersBirthDate', 'template': '#=CellDate(PersBirthDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersBirthDate)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersBirthDate)', 'width': 90 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersZipCode)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersZipCode)', 'width': 70 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersStreet)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersStreet)', 'width': 100 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_PersHouseNum)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_PersHouseNum)', 'width': 70 },
{ 'field': 'StateTxt', 'template': '#=CellString(StateTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_StateTxt)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_StateTxt)', 'width': 70 }
            ]
        });
    });
</script>
