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
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A2_SeznamDluzSpisyZprac_URG)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyZprac_URG)', 'width': 30 },
{ 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyZprac_ACC)'), 'template': '<a href="\\#" data-bind="attr: { href: rowHref }">#=CellRaw(ACC)#</a>', width: 80 },
{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyZprac_CreditorAlias)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyZprac_CreditorAlias)', 'width': 200 },
{ 'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyZprac_ActualDebit)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyZprac_ActualDebit)', 'width': 80 },
{ 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
{ 'field': 'StateTxt', 'template': '#=CellString(StateTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyZprac_StateTxt)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyZprac_StateTxt)', 'width': 120 },
{ 'field': 'MinDatum', 'template': '#=CellDate(MinDatum)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyZprac_MinDatum)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyZprac_MinDatum)', 'width': 80 },
{ 'template': '' },
            ]
        });
    };
</script>

<script id="SpisyDLSub" type="text/html">
    <div id="grid_#=uid#" data-bind="source: SpisyDLSub, events: { change: SpisyDLSub_change, dataBound: SpisyDLSub_dataBound }"></div>
</script>
