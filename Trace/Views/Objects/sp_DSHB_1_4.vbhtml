<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"@Html.Raw(Language.sp_DSHB_1_4TXT1)-@Html.Raw(Language.sp_DSHB_1_4TXT2) ve spisech.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-detail-template="sp_DSHB_1_4_Detail"
            data-columns="[
            { 'field': 'Name', 'headerTemplate': '@Html.ActionLink("4. @Html.Raw(Language.sp_DSHB_1_4TXT1)/@Html.Raw(Language.sp_DSHB_1_4TXT2) ve spisech", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_4"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'field': 'PocetUrg', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_4TXT1)</span>', 'template': '#=CellInt(PocetUrg, \'center\')#', 'width': 90 },
            { 'field': 'PocetRemind', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_4TXT2)</span>', 'template': '#=CellInt(PocetRemind, \'center\')#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_4, events: { detailInit: sp_DSHB_1_4_Detail }" style="width: 500px;"></div>
<script id="sp_DSHB_1_4_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Kategorie', 'template': '\\#=CellString(Kategorie, \\'center\\')\\#' },
            { 'field': 'PocetUrg', 'template': '\\#=CellInt(PocetUrg, \\'center\\')\\#', 'width': 90 },
            { 'field': 'PocetMsg', 'template': '\\#=CellInt(PocetMsg, \\'center\\')\\#', 'width': 90 }]"
            data-bind="source: sp_DSHB_1_4_Detail"></div>
</script>
