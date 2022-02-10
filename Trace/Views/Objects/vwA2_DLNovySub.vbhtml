<script>
    function initDLNovySub(uid) {
        $('#grid_' + uid).kendoGrid({
            scrollable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
            selectable: "single",
            columns: [
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.vwA_SpisyNovyDLSub_AlertExist)"></i>', 'title': '@Html.Raw(Language.vwA_SpisyNovyDLSub_AlertExist)', 'width': 30 },
{ 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovyDLSub_ACC)'), 'template': '<a href="\\#" data-bind="attr: { href: rowHref }">#=CellRaw(ACC)#</a>', width: 130 },
{ 'field': 'VisitDatePlan', 'template': '#=planeCalendar((rr_State > 9 && rr_State < 20), "VisitDatePlan")#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovyDLSub_VisitDatePlan)'), 'title': '@Html.Raw(Language.vwA_SpisyNovyDLSub_VisitDatePlan)', 'width': 100 },
{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovyDLSub_CreditorAlias)'), 'width': 130 },
{ 'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovyDLSub_ActualDebit)'), 'width': 130 },
{ 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
{ 'field': 'StateTxt', 'template': '#=CellString(StateTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovyDLSub_StateTxt)'), 'title': '@Html.Raw(Language.vwA_SpisyNovyDLSub_StateTxt)', 'width': 130 },
{ 'field': 'VisitDateSentFromMother', 'template': '#=CellDate(VisitDateSentFromMother)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovyDLSub_VisitDateSentFromMother)'), 'title': '@Html.Raw(Language.vwA_SpisyNovyDLSub_VisitDateSentFromMother)' }
            ]
        });
    };
</script>

<script id="SpisyDLSub" type="text/html">
    <div id="grid_#=uid#" data-bind="source: SpisyDLSub, events: { change: SpisyDLSub_change, dataBound: SpisyDLSub_dataBound }"></div>
</script>
