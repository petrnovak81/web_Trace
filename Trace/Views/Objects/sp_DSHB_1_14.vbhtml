<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Operativa.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-detail-template="sp_DSHB_1_14_Detail"
            data-columns="[
            { 'field': 'Popis', 'headerTemplate': '@Html.ActionLink("14. Operativa", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_14"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'field': 'Pocet', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_14TXT1)</span>', 'template': '#=CellInt(Pocet, \'center\')#', 'width': 90 },
            ]"
            data-bind="source: sp_DSHB_1_14, events: { detailInit: sp_DSHB_1_14_Detail }" style="width: 400px"></div>

<script id="sp_DSHB_1_14_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Name', 'template': '\\#=CellString(Name, \\'center\\')\\#' },
            { 'field': 'Pocet', 'template': '\\#=CellInt(Pocet, \\'center\\')\\#', 'width': 90 }]"
            data-bind="source: sp_DSHB_1_14_Detail"></div>
</script>
