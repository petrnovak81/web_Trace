<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Průměrný počet dní dodávání zpráv.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button><i>Sumární průměr zobrazuje průměr za všechny spisy, ne za IP</i></div>" }]'
            data-detail-template="sp_DSHB_1_13_Detail"
            data-columns="[
            { 'field': 'Popis', 'headerTemplate': '<a href=\'@(Url.Action("SVDashboardDetail", "Administrator"))?p=sp_DSHB_1_13\' target=\'_blank\' class=\'k-link\' style=\'font-size: 18px;font-weight:bold;\'><span>@Html.Raw(Language.sp_DSHB_1_13TXT1)</span><br /><span>@Html.Raw(Language.sp_DSHB_1_13TXT2)</span></a>' },
            { 'field': 'PrvniPrumer', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_13TXT3)</span>', 'template': '#=CellInt(PrvniPrumer, \'center\')#', 'width': 90 },
            { 'field': 'DalsiPrumer', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_13TXT4)</span>', 'template': '#=CellInt(DalsiPrumer, \'center\')#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_13, events: { detailInit: sp_DSHB_1_13_Detail }" style="width: 600px"></div>

<script id="sp_DSHB_1_13_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Jmeno', 'template': '\\#=CellString(Jmeno)\\#' },
            { 'field': 'PrvniPrumer', 'template': '\\#=CellInt(PrvniPrumer, \\'center\\')\\#', 'width': 90 },
            { 'field': 'DalsiPrumer', 'template': '\\#=CellInt(DalsiPrumer, \\'center\\')\\#', 'width': 90 }]"
            data-bind="source: sp_DSHB_1_13_Detail"></div>
</script>
