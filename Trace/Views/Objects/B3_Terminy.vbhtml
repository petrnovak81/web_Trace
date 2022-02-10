<div id="B3_podzal_Terminy" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b class="">@Language.B3_TerminyOSNTXT1</b></td>
            <td></td>
            <td></td>
            <td></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body row-flex-align">
         <table class="B3tbl tbl2col">
            <tr>
                <td class="lt">@Html.Raw(Language.B3_TerminyOSNVisitDateSentFromMothe)</td>
                <td class="r"><b data-bind="date: B3_TerminyOSN.VisitDateSentFromMother"></b></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_TerminyOSNVisitDateRecieveFromMother)</td>
                <td class="r"><b data-bind="date: B3_TerminyOSN.VisitDateReceiveFromMother"></b></td>
            </tr>
        </table>

        <table class="B3tbl tbl2col">
            <tr>
                <td class="lt">@Html.Raw(Language.B3_TerminyOSNVisitDateD1MAX)</td>
                <td class="r"><b data-bind="date: B3_TerminyOSN.VisitDateD1Max"></b></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_TerminyOSNVisitDateD1PLAN)</td>
                <td class="r"><b data-bind="date: B3_TerminyOSN.D1PLAN"></b></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_TerminyOSNVisitDateD1OSN)</td>
                <td class="r"><b data-bind="date: B3_TerminyOSN.VisitDateD1OSN"></b></td>
            </tr>
        </table>

        <table class="B3tbl tbl2col">
            <tr>
                <td class="lt">@Html.Raw(Language.B3_TerminyOSNVisitDateDNMAX)</td>
                <td class="r"><b data-bind="date: B3_TerminyOSN.VisitDateDNMax"></b></td>
            </tr>
            <tr>
                <td class="lt">@Html.Raw(Language.B3_TerminyOSNVisitDateDNPLAN)</td>
                <td class="r"><b data-bind="date: B3_TerminyOSN.DNPLAN"></b></td>
            </tr>
            <!-- <tr>
                <td class="lt">@Html.Raw(Language.B3_TerminyOSNVisitDateDNOSN)</td>
                <td class="r"><b data-bind="date: B3_TerminyOSN.VisitDateDNOSN"></b></td>
            </tr> -->
        </table>

        <div style="width:200px;">
            <!-- <b class="lt" style="padding: 3px;">@Html.Raw(Language.B3_TerminyOSNVisitDateDNOSN)</b> -->
            <div data-role="grid"
             data-resizable="true"
             data-columns="[
            { 'field': 'VisitDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_TerminyOSNVisitDateDNOSN)'), 'template': '#=CellDate(VisitDate)#' }
            ]"
             data-bind="source: B3_ListAllFV">
        </div>
        </div>
    </div>
</div>