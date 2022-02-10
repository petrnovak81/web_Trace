<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Přehled návštěv - detail.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-detail-template="sp_DSHB_1_8_Detail"
            data-columns="[
            { 'field': 'Describe', 'headerTemplate': '@Html.ActionLink("8. Přehled návštěv - detail", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_8"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'field': 'ThisMonth', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_8TXT1)</span>', 'template': '#=CellInt(ThisMonth, \'center\')#', 'width': 90 },
            { 'field': 'ThisWeek', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_8TXT2)</span>', 'template': '#=CellInt(ThisWeek, \'center\')#', 'width': 90 },
            { 'field': 'ThisDay', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_8TXT3)</span>', 'template': '#=CellInt(ThisDay, \'center\')#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_8, events: { detailInit: sp_DSHB_1_8_Detail }" style="width: 600px;"></div>

<script id="sp_DSHB_1_8_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
        data-resizable="false"
        data-scrollable="false"
        data-columns="[
            { 'field': 'Name', 'template': '\\#=CellString(Name, \\'center\\')\\#' },
            { 'field': 'ThisMonth', 'template': '\\#=CellInt(ThisMonth, \\'center\\')\\#', 'width': 90 },
            { 'field': 'ThisWeek', 'template': '\\#=CellInt(ThisWeek, \\'center\\')\\#', 'width': 90 },
            { 'field': 'ThisDay', 'template': '\\#=CellInt(ThisDay, \\'center\\')\\#', 'width': 90 }
            ]"
        data-bind="source: sp_DSHB_1_8_Detail">
    </div>
</script>