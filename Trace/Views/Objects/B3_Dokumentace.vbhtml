<div id="B3_podzal_Dokumentace" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b class="">@Language.B3_DokumentaceTitle</b></td>
            <td></td>
            <td></td>
            <td></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body">
        <table>
            <tr>
                <!-- <td><i class="lt">@Language.B3_DokumentaceTitle1</i></td> -->
                <td><b class="lt">@Language.B3_DokumentaceTitle2</b></td>
            </tr>
            <tr>
                <td>
                    <div style="height: 100px; width: 100%;" id="B3_Dokumentace"
                        data-role="grid"
                        data-resizable="true"
                        data-scrollable="true"
                        data-no-records="false"
                        data-columns="[
                        @Code
                            If User.IsInRole("1") Then
                               @<text>{ 'template': '<a href=\'\\#\' style=\'color:\\#c5394e;\' class=\'k-icon k-i-close-circle\' data-bind=\'events: { click: deletePDFFile }\'></a>', 'title': ' ', 'width': 30 },</text>
                            End If
                        End Code
            { 'field': 'DocuPrintSelected', 'headerTemplate': headerTemplate('@Language.B3_Dokumentace_DocuPrintSelected'), 'template': '#=CellBool(DocuPrintSelected, true)#', 'width': 30 },
            { 'field': 'DocuSentDate', 'headerTemplate': headerTemplate('@Language.B3_Dokumentace_DocuSentDate'), 'template': '#=CellDate(DocuSentDate)#', 'width': 80 },
            { 'field': 'DocuPrintPDF', 'headerTemplate': headerTemplate('@Language.B3_Dokumentace_DocuPrintPDF'), 'template': '<a href=\'\\#\' title=\'#=DocuPrintPDF#\' data-bind=\'events: { click: DocuGetPDF }\'>#=DocuPrintPDF#</a>', 'width': 80  },
            { 'field': 'DocuSentComment', 'headerTemplate': headerTemplate('@Language.B3_Dokumentace_DocuSentComment'), 'template': '#=CellString(DocuSentComment)#' }
            ]"
                        data-bind="source: B3_Dokumentace">
                    </div>
                    <button class="k-button" data-bind="events: { click: docPrint }" style="width: 100%">@Language.B3_btnPrint1</button>
                    <button class="k-button" data-bind="events: { click: docPrintAll }" style="width: 100%">@Language.B3_btnPrint2</button>
                </td>
            </tr>
        </table>
    </div>
</div>
