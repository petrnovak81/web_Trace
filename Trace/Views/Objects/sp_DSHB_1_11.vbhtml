<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Přehled provizí a paušálů přes měsíce.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-detail-template="sp_DSHB_1_11_Detail"
            data-columns="[
            { 'field': 'MonthPeriod', 'headerTemplate': '@Html.ActionLink("11. Přehled provizí a paušálů přes měsíce", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_11"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'field': 'Provize', 'headerTemplate': '<span class=\'verticalText\'>Provize Kč</span>', 'template': '#=CellMoney(Provize)#', 'width': 90 },
            { 'field': 'PausalOSN', 'headerTemplate': '<span class=\'verticalText\'>Paušál za<br>OSN Kč</span>', 'template': '#=CellMoney(PausalOSN)#', 'width': 90 },
            { 'field': 'PausalUZ', 'headerTemplate': '<span class=\'verticalText\'>Paušál za<br>UZ Kč</span>', 'template': '#=CellMoney(PausalUZ)#', 'width': 90 },
            { 'field': 'ProvizeSum', 'headerTemplate': '<span class=\'verticalText\'>Celkem Kč</span>', 'template': '#=CellMoney(ProvizeSum)#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_11, events: { detailInit: sp_DSHB_1_11_Detail }" style="width: 800px"></div>

<script id="sp_DSHB_1_11_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
        data-resizable="false"
        data-scrollable="false"
        data-columns="[
            { 'field': 'UserName', 'template': '\\#=CellString(UserName)\\#' },
            { 'field': 'Provize', 'template': '\\#=CellMoney(Provize)\\#', 'width': 90 },
            { 'field': 'PausalOSN', 'template': '\\#=CellMoney(PausalOSN)\\#', 'width': 90 },
            { 'field': 'PausalUZ', 'template': '\\#=CellMoney(PausalUZ)\\#', 'width': 90 },
            { 'field': 'ProvizeSum', 'template': '\\#=CellMoney(ProvizeSum)\\#', 'width': 90 }
            ]"
        data-bind="source: sp_DSHB_1_11_Detail">
    </div>
</script>



