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
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A2_SeznamDluzSpisyOSN_URG)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyOSN_URG)', 'width': 30 },
{ 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyOSN_ACC)'), 'template': '<a href="\\#" data-bind="attr: { href: rowHref }">#=CellRaw(ACC)#</a>', width: 90 },
{ 'field': 'DateOSNPlane', 'template': '#=CellDate(DateOSNPlane)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyOSN_VisitDateDNPlan)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyOSN_VisitDateDNPlan)', 'width': 100 },
{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyOSN_CreditorAlias)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyOSN_CreditorAlias)', 'width': 200 },
{ 'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyOSN_ActualDebit)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyOSN_ActualDebit)', 'width': 90 },
{ 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
{ 'field': 'DateOSNMax', 'template': '#=CellDate(DateOSNMax)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyOSN_VisitDateDNMax)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyOSN_VisitDateDNMax)', 'width': 90 },
{ 'field': 'StateTxt', 'template': '#=CellString(StateTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyOSN_StateTxt)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyOSN_StateTxt)' },
            ]
        });
    };
</script>

<script id="SpisyDLSub" type="text/html">
    <div id="grid_#=uid#" data-bind="source: SpisyDLSub, events: { change: SpisyDLSub_change, dataBound: SpisyDLSub_dataBound }"></div>
</script>
