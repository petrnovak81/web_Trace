<div id="B3_podzal_DetailSpisu" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b>@Html.Raw(Language.B3_DetailSpisu_TXT1)</b></td>
            <td><span class="lt">@Html.Raw(Language.B3_DetailSpisuHL_CreditorName)</span> <span data-bind="text: B3_DetailSpisu.CreditorName"></span></td>
            <td><span class="lt">@Html.Raw(Language.B3_DetailSpisuHL_ACC)</span> <span data-bind="text: B3_DetailSpisu.ACC"></span></td>
            <td><span class="lt">@Html.Raw(Language.B3_DetailSpisuHL_ActualDebit)</span> <span data-bind="money: B3_DetailSpisu.ActualDebit"></span> <span data-bind="text: B3_DetailSpisu.CurrencyTxt"></span></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body row-flex-align">
        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt"><b>@Html.Raw(Language.B3_DetailSpisu_ActualDebitSUM)</b></th>
                <th class="r"><span data-bind="money: B3_DetailSpisu.ActualDebit"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></th>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_Principal)</td>
                <td class="r"><span data-bind="money: B3_DetailSpisu.Principal"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_Interest)</td>
                <td class="r"><span data-bind="money: B3_DetailSpisu.Interest"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_Costs)</td>
                <td class="r"><span data-bind="money: B3_DetailSpisu.Costs"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_YetPaid)</td>
                <td class="r"><span data-bind="money: B3_DetailSpisu.YetPaid"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></td>
            </tr>
        </table>
        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt" colspan="2"><b>@Html.Raw(Language.B3_DetailSpisu_TXT2)</b></th>
                <th></th>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_AccountNumber)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.AccountNumber"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_BankCode)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.BankCode"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_VariableSymbol)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.VariableSymbol"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_SpecificSymbol)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.SpecificSymbol"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_Message)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.MsgForRecipient"></span></td>
            </tr>
        </table>
        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt" colspan="2"><b>@Html.Raw(Language.B3_DetailSpisu_TXT3)</b></th>
            </tr>
            <tr>
                <td><span data-bind="text: B3_DetailSpisu.CreditorAddrFull"></span></td>
            </tr>
        </table>
        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt" colspan="2"><b>@Html.Raw(Language.B3_DetailSpisu_TXT4)</b></th>
                <th></th>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_DateReceiveFromMother)</td>
                <td class="r"><span data-bind="date: B3_DetailSpisu.VisitDateReceiveFromMother"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_DateTransToMother)</td>
                <td class="r"><span data-bind="date: B3_DetailSpisu.VisitDateSentToMother"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_DateReturnToCreditor)</td>
                <td class="r"><span data-bind="date: B3_DetailSpisu.DateReturnToCreditor"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_DateLapse)</td>
                <td class="r"><span data-bind="date: B3_DetailSpisu.DateLapse"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_DateSignSKUZ)</td>
                <td class="r"><span data-bind="date: B3_DetailSpisu.DateSignSKUZ"></span></td>
            </tr>
        </table>

        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt" colspan="2"><b>@Html.Raw(Language.B3_DetailSpisu_TXT5)</b></th>
                <th></th>
            </tr>
                        <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_MaxCommission)</td>
                <td class="r"><span data-bind="money: B3_DetailSpisu.MaxCommission"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_FirstVisitFee)</td>
                <td class="r"><span data-bind="money: B3_DetailSpisu.FirstVisitFee"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_SumPaymentFromVisits)</td>
                <td class="r"><span data-bind="money: B3_DetailSpisu.SumPaymentFromVisits"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_KindOfEnforcement)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.KindOfEnforcement"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_MaxCountPayments)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.MaxCountPayments"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_PardonCampaign)</td>
                <td class="r">
                    <input type="checkbox" disabled id="B3_DetailSpisu_PardonCampaign" data-bind="checked: B3_DetailSpisu.PardonCampaign" class="k-checkbox"><label class="k-checkbox-label" for="B3_DetailSpisu_PardonCampaign"></label>
                </td>
            </tr>
<!--             <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_DOHL)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.DOHL"></span></td>
            </tr> -->
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_ActualActions)</td>
                <td class="r"><span data-bind="text: B3_DetailSpisu.ActualActions"></span></td>
            </tr>
        </table>

        <table class="B3tbl tbl2col">
            <tr>
                <th class="lt" colspan="2"><b>@Html.Raw(Language.B3_Bonita_TXT1)</b></th>
                <th></th>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_Bonita_BonitaKatastr)</td>
                <td class="r"><span data-bind="text: B3_Bonita.BonitaKatastr"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_Bonita_BonitaPocetExe)</td>
                <td class="r"><span data-bind="text: B3_Bonita.BonitaPocetExe"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_Bonita_BonitaDatLustrace)</td>
                <td class="r"><span data-bind="date: B3_Bonita.BonitaDatLustrace"></span></td>
            </tr>
        </table>

        <table class="B3tbl">
            <tr>
                <td class="lt" style="min-width:100px">@Html.Raw(Language.B3_DetailSpisu_LastPaymentDate)</td>
                <td><span data-bind="date: B3_DetailSpisu.LastPaymentDate"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_LastPaymentAmountReal)</td>
                <td><span data-bind="money: B3_DetailSpisu.LastPaymentAmountReal"></span> <span data-bind="    text: B3_DetailSpisu.CurrencyTxt"></span></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_DetailSpisu_LastCallDate)</td>
                <td><span data-bind="date: B3_DetailSpisu.LastCallDate"></span></td>
            </tr>
        </table>

        <table class="B3tbl" style="width: 100%">
            <tr>
                <td>
                    <b class="lt">@Html.Raw(Language.B3_DetailSpisu_LastCallText)</b><br />
                    <span data-bind="text: B3_DetailSpisu.LastCallText"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <b class="lt">@Html.Raw(Language.B3_DetailSpisu_TaskForIP)</b><br />
                    <span data-bind="text: B3_DetailSpisu.TaskForIP"></span>
                </td>
            </tr>
        </table>
    </div>
</div>
