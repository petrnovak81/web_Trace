<script>
    function initDLNovySub(uid) {
        $('#grid_' + uid).kendoGrid({
            scrollable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
            selectable: "single",
            //rowTemplate: kendo.template($("#subspisrowtemplate").html()),
            columns: [
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.A2_SeznamDluzSpisyDohody_URG)"></i>', 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyDohody_URG)', 'width': 30 },
{ 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyDohody_ACC)'), 'template': '<a href="\\#" data-bind="attr: { href: rowHref }">#=CellRaw(ACC)#</a>', width: 90 },
{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyDohody_CreditorAlias)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyDohody_CreditorAlias)', 'width': 200 },
{ 'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyDohody_ActualDebit)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyDohody_ActualDebit)', 'width': 90 },
{ 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
{ 'field': 'NextPaymentDate', 'template': '#=CellDate(NextPaymentDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyDohody_NextPaymentDate)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyDohody_NextPaymentDate)', 'width': 90 },
{ 'field': 'NextPaymentAmountAwait', 'template': '#=CellMoney(NextPaymentAmountAwait)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyDohody_NextPaymentAmountAwait)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyDohody_NextPaymentAmountAwait)', 'width': 90 },
{ 'field': 'LastPaymentDate', 'template': '#=CellDate(LastPaymentDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyDohody_LastPaymentDate)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyDohody_LastPaymentDate)', 'width': 90 },
{ 'field': 'LastPaymentAmountAwait', 'template': '#=CellMoney(LastPaymentAmountAwait)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyDohody_LastPaymentAmountAwait)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyDohody_LastPaymentAmountAwait)', 'width': 90 },
{ 'field': 'ValidityTypeTxt', 'template': '#=CellString(ValidityTypeTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A2_SeznamDluzSpisyDohody_ValidityTypeTxt)'), 'title': '@Html.Raw(Language.A2_SeznamDluzSpisyDohody_ValidityTypeTxt)' },
            ]
        });
    };
</script>

<script id="SpisyDLSub" type="text/html">
    <div id="grid_#=uid#" data-bind="source: SpisyDLSub, events: { change: SpisyDLSub_change, dataBound: SpisyDLSub_dataBound }"></div>
</script>

