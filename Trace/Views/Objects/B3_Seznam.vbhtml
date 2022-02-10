<div id="B3_podzal_Seznam" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b class="">@Language.B3_SeznamTXT1</b></td>
            <td></td>
            <td></td>
            <td><span class="lt">@Language.B3_SeznamTXT2 </span><span data-bind="text: B3_SpisyDluznika.length"></span></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body">
        <div style="height:150px;width:100%;"
            data-role="grid"
            data-resizable="true"
            data-scrollable="true"
            data-no-records="false"
            data-columns="[
            { 'field': 'ACC', 'template': '<a href=\'\' data-bind=\'attr: { href: ACCLink }\'>#=CellRaw(ACC)#</a>', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpisyDluznika_ACC)'), 'width': 80 },
            { 'field': 'CreditorAlias', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpisyDluznika_CreditorAlias)'), 'template': '#=CellString(CreditorAlias)#', 'width': 200 },
            { 'field': 'ActualDebit', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpisyDluznika_ActualDebit)'), 'template': '#=CellMoney(ActualDebit)#', 'width': 80 },
            { 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
            { 'field': 'StateTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpisyDluznika_StateTxt)'), 'template': '#=CellString(StateTxt)#' }
            ]"
            data-bind="source: B3_SpisyDluznika">
        </div>
    </div>
</div>
