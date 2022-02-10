<table class="grid" style="width: 700px;">
    <tr>
        <td style="vertical-align:top">
            <div data-role="grid" class="vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-selectable="true"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Počet spisů.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-detail-template="sp_DSHB_1_1_Detail"
            data-columns="[
            { 'field': 'ID', 'title': 'Text', 'headerTemplate': '@Html.ActionLink("1. Počet spisů", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_1"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString', 'template': '@Html.Raw(Language.sp_DSHB_1_1TXT5)' },
            { 'field': 'New', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_1TXT1)</span>', 'template': '#=CellInt(New, \'center\')#', 'width': 50 },
            { 'field': 'Visits', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_1TXT2)</span>', 'template': '#=CellInt(Visits, \'center\')#', 'width': 50 },
            { 'field': 'Agreements', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_1TXT3)</span>', 'template': '#=CellInt(Agreements, \'center\')#', 'width': 50 },
            { 'field': 'ToProcess', 'headerTemplate':'<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_1TXT4)</span>', 'template': '#=CellInt(ToProcess, \'center\')#', 'width': 50 },
            { 'field': 'Suma', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_1TXT5)</span>', 'template': '#=CellInt(Suma, \'center\')#', 'width': 50 },
            { 'field': 'Closed', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_1TXT6)</span>', 'template': '#=CellInt(Closed, \'center\')#', 'width': 50 }
            ]"
            data-bind="source: sp_DSHB_1_1, events: { detailInit: sp_DSHB_1_1_Detail, change: sp_DSHB_1_1_select }"></div>

<script id="sp_DSHB_1_1_Detail" type="text/html">
    <div data-role="grid" class="vertical-header"
        data-resizable="false"
        data-scrollable="false"
        data-selectable="true"
        data-columns="[
            { 'field': 'Name', 'template': '\\#=CellString(Name)\\#' },
            { 'field': 'New', 'template': '\\#=CellInt(New, \\'center\\')\\#', 'width': 50 },
            { 'field': 'Visits', 'template': '\\#=CellInt(Visits, \\'center\\')\\#', 'width': 50 },
            { 'field': 'Agreements', 'template': '\\#=CellInt(Agreements, \\'center\\')\\#', 'width': 50 },
            { 'field': 'ToProcess', 'template': '\\#=CellInt(ToProcess, \\'center\\')\\#', 'width': 50 },
            { 'field': 'Suma', 'template': '\\#=CellInt(Suma, \\'center\\')\\#', 'width': 50 },
            { 'field': 'Closed', 'template': '\\#=CellInt(Closed, \\'center\\')\\#', 'width': 50 }
            ]"
        data-bind="source: sp_DSHB_1_1_Detail, events: { change: sp_DSHB_1_1_select }">
    </div>
</script>
        </td>
        <td style="width:200px;vertical-align:top">
            <div data-role="chart"
                 data-series-colors="['#4770a4', '#a04441', '#869e50', '#71588f', '#d98847', '#95a7cb']",
            data-legend="{ position: 'bottom', visible: true }"
            data-series-defaults="{ type: 'column', labels: { visible: true }, tooltip: { template: '#:series.name# #:value#', visible: true } }"
                 data-series="[
            { 'field': 'New', 'name': '@Html.Raw(Language.sp_DSHB_1_1TXT1)' },
            { 'field': 'Visits', 'name': '@Html.Raw(Language.sp_DSHB_1_1TXT2)' },
            { 'field': 'Agreements', 'name': '@Html.Raw(Language.sp_DSHB_1_1TXT3)' },
            { 'field': 'ToProcess', 'name': '@Html.Raw(Language.sp_DSHB_1_1TXT4)' },
            { 'field': 'Closed', 'name': '@Html.Raw(Language.sp_DSHB_1_1TXT6)'}
                             ]"
                 data-bind="source: sp_DSHB_1_1_chart"></div>
        </td>
    </tr>
</table>
