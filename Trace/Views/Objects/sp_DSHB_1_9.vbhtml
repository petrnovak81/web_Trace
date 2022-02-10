
<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Objem pohledávek.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-detail-template="sp_DSHB_1_9_Detail"
            data-columns="[
            { 'field': 'Describe', 'headerTemplate': '@Html.ActionLink("9. Objem pohledávek", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_9"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'field': 'SumActualDebit', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_9TXT1)<br>@Html.Raw(Language.sp_DSHB_1_9TXT2)</span>', 'template': '#=CellInt(SumActualDebit)#', 'width': 90 },
            { 'field': 'Uhrazeno', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_9TXT3)</span>', 'template': '#=CellInt(Uhrazeno)#', 'width': 90 },
            { 'field': 'OcekavanePlatby', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_9TXT4)<br>@Html.Raw(Language.sp_DSHB_1_9TXT5)</span>', 'template': '#=CellInt(OcekavanePlatby)#', 'width': 90 },
            { 'field': 'OcekavanaProvize', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_9TXT6)<br>@Html.Raw(Language.sp_DSHB_1_9TXT7)</span>', 'template': '#=CellInt(OcekavanaProvize)#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_9, events: { detailInit: sp_DSHB_1_9_Detail }" style="width: 600px"></div>

<script id="sp_DSHB_1_9_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
        data-resizable="false"
        data-scrollable="false"
        data-columns="[
            { 'field': 'Name', 'template': '\\#=CellString(Name)\\#' },
            { 'field': 'SumActualDebit', 'template': '\\#=CellInt(SumActualDebit)\\#', 'width': 90 },
            { 'field': 'Uhrazeno', 'template': '\\#=CellInt(Uhrazeno)\\#', 'width': 90 },
            { 'field': 'OcekavanePlatby', 'template': '\\#=CellInt(OcekavanePlatby)\\#', 'width': 90 },
            { 'field': 'OcekavanaProvize', 'template': '\\#=CellInt(OcekavanaProvize)\\#', 'width': 90 }
            ]"
        data-bind="source: sp_DSHB_1_9_Detail">
    </div>
</script>