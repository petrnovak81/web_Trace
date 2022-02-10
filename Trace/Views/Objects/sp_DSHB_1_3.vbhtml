<div data-role="grid" class="multicolumn grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Přehled dohod - celkový.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-detail-template="sp_DSHB_1_3_Detail"
            data-columns="[
            { 'field': 'Popis', 'headerTemplate': '@Html.ActionLink("3. Přehled dohod - celkový", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_3"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'title': 'Celkem', 'columns': [
               { 'field': 'Pocet', 'headerTemplate': '<span class=\'verticalText\'>KS</span>', 'template': '#=CellInt(Pocet, \'center\')#', 'width': 90 },
               { 'field': 'Cely', 'headerTemplate': '<span class=\'verticalText\'>KČ</span>', 'template': '#=CellInt(Cely)#', 'width': 90 }
            ] },
            { 'title': 'Tento měsíc', 'columns': [
               { 'field': 'MPocet', 'headerTemplate': '<span class=\'verticalText\'>KS</span>', 'template': '#=CellInt(MPocet, \'center\')#', 'width': 90 },
               { 'field': 'MCely', 'headerTemplate':'<span class=\'verticalText\'>KČ</span>', 'template': '#=CellInt(MCely)#', 'width': 90 }
            ] }
            ]"
            data-bind="source: sp_DSHB_1_3, events: { detailInit: sp_DSHB_1_3_Detail }" style="width:700px;"></div>
<script id="sp_DSHB_1_3_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Jmeno', 'template': '\\#=CellString(Jmeno, \\'center\\')\\#' },
            { 'field': 'Pocet', 'template': '\\#=CellInt(Pocet, \\'center\\')\\#', 'width': 90 },
            { 'field': 'Cely', 'template': '\\#=CellInt(Cely)\\#', 'width': 90 },
            { 'field': 'MPocet', 'template': '\\#=CellInt(MPocet, \\'center\\')\\#', 'width': 90 },
            { 'field': 'MCely', 'template': '\\#=CellInt(MCely)\\#', 'width': 90 }]"
            data-bind="source: sp_DSHB_1_3_Detail"></div>
</script>
