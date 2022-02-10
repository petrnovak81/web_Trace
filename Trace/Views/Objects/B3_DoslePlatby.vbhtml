<div id="B3_podzal_DoslePlatby" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b class="">@Language.B3_DoslePlatbyTXT1</b></td>
            <td></td>
            <td></td>
            <td></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body row-flex-align">

        <div style="margin-right: 12px;">
            <table style="width: 100%; height: 5px;">
                <tr>
                    <td style="vertical-align: bottom"><b class="lt">@Language.B3_DoslePlatbyTXT6</b></td>
                </tr>
            </table>
            <div style="height: 150px; width: 210px;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="true"
                data-no-records="false"
                data-columns="[
            { 'field': 'PaymentDate', 'headerTemplate': headerTemplate('@Language.B3_Dohoda_PaymentDate'), 'template': '#=CellDate(PaymentDate)#', 'width': 80 },
            { 'field': 'Amount', 'headerTemplate': headerTemplate('@Language.B3_Dohoda_Amount'), 'template': '#=CellMoney(Amount)#', 'width': 60 },
                { 'field': 'CurrencyTxt','headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 }
            ]"
                data-bind="source: B3_PlatbyDoslePred1OSN">
            </div>
        </div>

        <div style="margin-right: 12px;">
            <table style="width: 100%; height: 5px;">
                <tr>
                    <td style="vertical-align: bottom"><b class="lt">@Language.B3_DoslePlatbyTXT2</b></td>
                </tr>
            </table>
            <div style="height: 150px; width: 330px;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="true"
                data-no-records="false"
                data-columns="[
            { 'field': 'PaymentDate', 'headerTemplate': headerTemplate('@Language.B3_PlatbyDosle_PaymentDate'), 'template': '#=CellDate(PaymentDate)#', 'width': 80 },
            { 'field': 'Amount', 'headerTemplate': headerTemplate('@Language.B3_PlatbyDosle_Amount'), 'template': '#=CellMoney(Amount)#', 'width': 60 },
            { 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
                { 'field': 'CommissionForIP', 'headerTemplate': headerTemplate('@Language.B3_PlatbyDosle_CommissionForIP'), 'template': '#=CellMoney(CommissionForIP)#', 'width': 60 },
            { 'field': 'OverPayment', 'headerTemplate': headerTemplate('@Language.B3_PlatbyDosle_OverPayment'), 'template': '#=CellMoney(OverPayment)#', 'width': 60 }
            ]"
                data-bind="source: B3_PlatbyDoslePo1OSN">
            </div>
        </div>

        <div style="margin-right: 12px;">
            <table style="width: 100%; height: 5px;">
                <tr>
                    <td style="vertical-align: bottom"><b class="lt">@Language.B3_DoslePlatbyTXT3</b></td>
                    <td>
                        <div class="lt">@Language.B3_Dohoda_rr_PAValidityType</div>
                        <b data-bind="text: B3_HistorieDohod[0].ValidityTypeTxt"></b>
                    </td>
                    <td>
                        <div class="lt">@Language.B3_Dohoda_rr_PAType</div>
                        <b data-bind="text: B3_HistorieDohod[0].PATypeTxt"></b>
                    </td>
                </tr>
            </table>
            <div style="height: 150px; width: 348px;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="true"
                data-no-records="false"
                data-columns="[
            { 'field': 'PaymentDate', 'headerTemplate': headerTemplate('@Language.B3_DohodyOUhrade_PaymentDate'), 'template': '#=CellDate(PaymentDate)#', 'width': 80 },
            { 'field': 'PaymentAmountAwait', 'headerTemplate': headerTemplate('@Language.B3_DohodyOUhrade_PaymentAmountAwait'), 'template': '#=CellMoney(PaymentAmountAwait)#', 'width': 60 },
            { 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
                { 'field': 'CommissionAwait', 'headerTemplate': headerTemplate('@Language.B3_DohodyOUhrade_CommissionAwait'), 'template': '#=CellMoney(CommissionAwait)#', 'width': 60 },
            { 'field': 'PaymentAmountReal', 'headerTemplate': headerTemplate('@Language.B3_DohodyOUhrade_PaymentAmountReal'), 'template': '#=CellMoney(PaymentAmountReal)#', 'width': 60 }
            ]"
                data-bind="source: B3_DohodyOUhrade">
            </div>
        </div>

        <div style="margin-right: 12px;">
            <table style="width: 100%; height: 36px;">
                <tr>
                    <td style="vertical-align: bottom"><b class="lt">@Language.B3_DoslePlatbyTXT7</b></td>
                    <td style="vertical-align: bottom"><b class="lt">@Language.B3_DoslePlatbyTXT8</b></td>
                    <td style="vertical-align: bottom"><b data-bind="text: B3_HistorieDohod.length"></b></td>
                </tr>
            </table>
            <div style="height: 150px; width: 450px;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="true"
                data-no-records="false"
                data-columns="[
            { 'field': 'DateSK', 'headerTemplate': headerTemplate('@Language.B3_Dohoda_DateSK'), 'template': '#=CellDate(DateSK)#', 'width': 70 },
            { 'field': 'Amount', 'headerTemplate': headerTemplate('@Language.B3_Dohoda_Amount'), 'template': '#=CellMoney(Amount)#', 'width': 60 },
            { 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
                { 'field': 'CountOfPaymentsSK', 'headerTemplate': headerTemplate('@Language.B3_Dohoda_CountOfPaymentsSK'), 'template': '#=CellInt(CountOfPaymentsSK)#', 'width': 60 },
            { 'field': 'ValidityTypeTxt', 'headerTemplate': headerTemplate('@Language.B3_Dohoda_StateSK'), 'template': '#=CellString(ValidityTypeTxt)#', 'width': 70 },
            { 'field': 'PATypeTxt', 'headerTemplate': headerTemplate('@Language.B3_Dohoda_PATypeTxt'), 'template': '#=CellString(PATypeTxt)#', 'width': 100 }
            ]"
                data-bind="source: B3_HistorieDohod">
            </div>
        </div>
    </div>
</div>
