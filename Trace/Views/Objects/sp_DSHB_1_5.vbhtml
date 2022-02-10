<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Nepřihlášení IP.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-columns="[
            { 'field': 'Name', 'headerTemplate': '@Html.ActionLink("5. Nepřihlášení IP", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_5"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'field': 'Dnu', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_5TXT1)</span>', 'template': '#=CellInt(Dnu, \'center\')#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_5" style="width:400px;"></div>