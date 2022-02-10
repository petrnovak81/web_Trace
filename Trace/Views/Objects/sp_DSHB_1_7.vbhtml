<div data-role="grid" class="multicolumn grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Osobní návštěvy.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-detail-template="sp_DSHB_1_7_Detail"
            data-columns="[
            { 'field': 'Popis', 'headerTemplate': '@Html.ActionLink("7. Osobní návštěvy", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_7"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'title': 'Tento týden', 'columns': [
                                                 { 'field': 'PlanTyden', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_7TXT1)</span>', 'template': '#=CellInt(PlanTyden, \'center\')#', 'width': 90 },
                                                 { 'field': 'RealTyden', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_7TXT2)</span>', 'template': '#=CellInt(RealTyden, \'center\')#', 'width': 90 }
                                                 ] 
            },
            { 'title': 'Včera', 'columns': [
                                                 { 'field': 'PlanVcera', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_7TXT1)</span>', 'template': '#=CellInt(PlanVcera, \'center\')#', 'width': 90 },
                                                 { 'field': 'RealVcera', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_7TXT2)</span>', 'template': '#=CellInt(RealVcera, \'center\')#', 'width': 90 }
                                                 ] 
            },
            { 'field': 'PlanDnes', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_7TXT5)</span>', 'template': '#=CellInt(PlanDnes, \'center\')#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_7, events: { detailInit: sp_DSHB_1_7_Detail }" style="width: 700px"></div>

<script id="sp_DSHB_1_7_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-columns="[
            { 'field': 'Jmeno', 'template': '\\#=CellString(Jmeno)\\#' },
            { 'field': 'PlanTyden', 'template': '\\#=CellInt(PlanTyden, \\'center\\')\\#', 'width': 90 },
            { 'field': 'RealTyden', 'template': '\\#=CellInt(RealTyden, \\'center\\')\\#', 'width': 90 },
            { 'field': 'PlanVcera', 'template': '\\#=CellInt(PlanVcera, \\'center\\')\\#', 'width': 90 },
            { 'field': 'RealVcera', 'template': '\\#=CellInt(RealVcera, \\'center\\')\\#', 'width': 90 },
            { 'field': 'PlanDnes', 'template': '\\#=CellInt(PlanDnes, \\'center\\')\\#', 'width': 90 }]"
            data-bind="source: sp_DSHB_1_7_Detail"></div>
</script>
