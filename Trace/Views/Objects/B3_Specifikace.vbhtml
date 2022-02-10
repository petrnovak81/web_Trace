<div id="B3_podzal_Specifikace" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b class="">@Language.B3_SpecifikaceTXT11</b></td>
            <td></td>
            <td></td>
            <td></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body row-flex-align">
        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt"><b>@Language.B3_SpecifikaceTXT1</b></th>
                <th></th>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="B3_OtherInfo"
                        data-role="grid"
                        data-resizable="true"
                        data-scrollable="true"
                        data-columns="[
            { 'field': 'Popis', 'template': '#=CellString(Popis)#' },
            { 'field': 'Hodnota', 'template': '#=CellString(Hodnota)#' },
            ]"
                        data-bind="source: B3_OtherInfo">
                    </div>
                    <style>
                        #B3_OtherInfo thead {
                            display: none;
                        }
                    </style>
                </td>
            </tr>
        </table>
        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt"><b>@Language.B3_SpecifikaceCreditorAlias</b></th>
            </tr>
            <tr>
                <td><b data-bind="text: B3_SpecifikaceDluhuVeritel.CreditorAlias">@Html.Raw(Language.B3_SpecifikaceTXT1)</b></td>
            </tr>
        </table>
        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt"><b>@Language.B3_SpecifikaceActualDebit</b></th>
                <th><b data-bind="money: B3_SpecifikaceDluhuVeritel.ActualDebit"></b> <b data-bind="    text: B3_SpecifikaceDluhuVeritel.CurrencyTxt"></b></th>
            </tr>
            <tr>
                <td class="lt">@Language.B3_SpecifikacePrincipal</td>
                <td class="r"><span data-bind="money: B3_SpecifikaceDluhuVeritel.Principal"></span> <span data-bind="    text: B3_SpecifikaceDluhuVeritel.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Language.B3_SpecifikaceInterest</td>
                <td class="r"><span data-bind="    money: B3_SpecifikaceDluhuVeritel.Interest"></span> <span data-bind="    text: B3_SpecifikaceDluhuVeritel.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Language.B3_SpecifikaceCosts</td>
                <td class="r"><span data-bind="    money: B3_SpecifikaceDluhuVeritel.Costs"></span> <span data-bind="    text: B3_SpecifikaceDluhuVeritel.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Language.B3_SpecifikaceYetPaid</td>
                <td class="r"><span data-bind="    money: B3_SpecifikaceDluhuVeritel.YetPaid"></span> <span data-bind="    text: B3_SpecifikaceDluhuVeritel.CurrencyTxt"></span></td>
            </tr>
        </table>
        
        <div style="height:150px;width: 100%;"
            data-role="grid"
            data-resizable="true"
            data-scrollable="true"
            data-no-records="false"
            data-columns="[
            { 'field': 'InfoKind', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpecDluhPD_InfoKind)'), 'title': '@Html.Raw(Language.B3_SpecDluhPD_InfoKind)', 'template': '#=CellString(InfoKind)#', 'width': 100 },
            { 'field': 'InfoInvoice', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpecDluhPD_InfoInvoice)'), 'title': '@Html.Raw(Language.B3_SpecDluhPD_InfoInvoice)', 'template': '#=CellString(InfoInvoice)#', 'width': 100 },
            { 'field': 'InfoAmount', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpecDluhPD_InfoAmount)'), 'title': '@Html.Raw(Language.B3_SpecDluhPD_InfoAmount)', 'template': '#=CellMoney(InfoAmount)#', 'width': 100 },
            { 'field': 'Mena', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
            { 'field': 'InfoAmountBalance', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpecDluhPD_InfoAmountBalance)'), 'title': '@Html.Raw(Language.B3_SpecDluhPD_InfoAmountBalance)', 'template': '#=CellMoney(InfoAmountBalance)#', 'width': 100 },
            { 'field': 'InfoAmountBalanceUpdated', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpecDluhPD_InfoAmountBalanceUpdated)'), 'title': '@Html.Raw(Language.B3_SpecDluhPD_InfoAmountBalanceUpdated)', 'template': '#=CellMoney(InfoAmountBalanceUpdated)#', 'width': 100 },
            { 'field': 'InfoDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpecDluhPD_InfoDate)'), 'title': '@Html.Raw(Language.B3_SpecDluhPD_InfoDate)', 'template': '#=CellDate(InfoDate)#', 'width': 100 },
            { 'field': 'InfoDueDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_SpecDluhPD_InfoDueDate)'), 'title': '@Html.Raw(Language.B3_SpecDluhPD_InfoDueDate)', 'template': '#=CellDate(InfoDueDate)#', 'width': 100 }
            ]"
            data-bind="source: B3_SpecifikaceDluhuFinUdaje">
        </div>
    </div>
</div>
