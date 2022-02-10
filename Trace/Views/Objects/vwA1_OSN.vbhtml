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
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A1_SeznamSpisOSN_URG)"></i>', 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_URG)', 'width': 30 },
{ 'field': 'GPSValid', 'template': '#=gpsMarker(GPSValid, AddrLocalGovernment)#', 'headerTemplate': '<i class="fa fa-map-marker" title="@Html.Raw(Language.A1_SeznamSpisOSN_GPSValid)"></i>', 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_GPSValid)', 'width': 30 },
{ 'field': 'ACC', 'template': '#=CellString(ACC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_ACC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_ACC)', 'width': 130 },
{ 'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonSurname)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersonSurname)', 'width': 130 },
{ 'field': 'PersName', 'template': '#=CellString(PersName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonName)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersonName)', 'width': 130 },
{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_CreditorAlias)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_CreditorAlias)', 'width': 200 },
{ 'field': 'DateOSNMax', 'template': '#=CellDate(DateOSNMax)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DateOSNMax)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DateOSNMax)', 'width': 90 },
{ 'field': 'DateOSNPlan', 'template': '<a data-bind="events: { click: btnDateOSNPlan }" href="\\#"><i class="fa fa-calendar-plus-o"></i> <span data-bind="date: DateOSNPlan"></span></a>', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DateOSNPlan)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DateOSNPlan)', 'width': 100 },
{ 'field': 'VisitDatePlanNoChange', 'template': '<input type="checkbox" data-bind="events: { change: noChangeDate }" #= VisitDatePlanNoChange ? \'checked="checked"\' : "" # id="noChangeDate-#=uid#">', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_VisitDatePlanNoChange)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_VisitDatePlanNoChange)', width: 30 },
{ 'field': 'DateReturnToCreditor', 'template': '#=CellDate(DateReturnToCreditor)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DateReturnToCreditor)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DateReturnToCreditor)', 'width': 130 },
{ 'field': 'PersIC', 'template': '#=CellString(PersIC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonIC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersonIC)', 'width': 100 },
{ 'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_ActualDebit)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_ActualDebit)', 'width': 80 },
{ 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
{ 'field': 'MaxCommission', 'template': '#=CellMoney(MaxCommission)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_MaxCommission)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_MaxCommission)', 'width': 80 },
{ 'field': 'PersRegion', 'template': '#=CellString(PersRegion)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersRegion)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersRegion)', 'width': 130 },
{ 'field': 'PersCity', 'template': '#=CellString(PersCity)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersCity)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersCity)', 'width': 130 },
{ 'field': 'PersPhone', 'template': '#=CellPhone(PersPhone)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisDohody_PersPhone)'), 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_PersPhone)', 'width': 80 },
{ 'field': 'PersRC', 'template': '#=CellRC(PersRC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonRC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersonRC)', 'width': 100 },
{ 'field': 'PersBirthDate', 'template': '#=CellDate(PersBirthDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonBirthDate)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersonBirthDate)', 'width': 100 },
{ 'field': 'LastPaymentDate', 'template': '#=CellDate(LastPaymentDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_LastPaymentDate)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_LastPaymentDate)', 'width': 100 },
{ 'field': 'DebtLastOSN', 'template': '#=CellDate(DebtLastOSN)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastOSN)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastOSN)', 'width': 100 },
{ 'field': 'DebtLastContact', 'template': '#=CellDate(DebtLastContact)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastContact)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DebtLastContact)', 'width': 100 },
{ 'field': 'DateLapse', 'template': '#=CellDate(DateLapse)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_DateLapse)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_DateLapse)', 'width': 100 },
{ 'field': 'VisitDateReceiveFromMother', 'template': '#=CellDate(VisitDateReceiveFromMother)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_VisitDateRecieveFromMother)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_VisitDateRecieveFromMother)', 'width': 90 },
{ 'field': 'PersZipCode', 'template': '#=CellZip(PersZipCode)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersZipCode)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersZipCode)', 'width': 80 },
{ 'field': 'PersStreet', 'template': '#=CellString(PersStreet)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersStreet)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersStreet)', 'width': 130 },
{ 'field': 'StateTxt', 'template': '#=CellString(StateTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_StateTxt)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_StateTxt)', 'width': 130 },
{ 'field': 'PersHouseNum', 'template': '#=CellString(PersHouseNum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersHouseNum)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersHouseNum)', 'width': 130 }
            ]
        });
    });
</script>
