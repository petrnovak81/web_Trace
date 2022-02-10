<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"Přehled návštěv.pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-columns="[
            { 'field': 'Describe', 'headerTemplate': '@Html.ActionLink("2. Přehled návštěv", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_2"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString<br><input style=\'width: 100%\' id=\'accountSelect\' />' },
            { 'field': 'ThisMonth', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_2TXT1)</span>', 'template': '#=CellInt(ThisMonth, \'center\')#', 'width': 90 },
            { 'field': 'ThisWeek', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_2TXT2)</span>', 'template': '#=CellInt(ThisWeek, \'center\')#', 'width': 90 },
            { 'field': 'ThisDay', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_2TXT3)</span>', 'template': '#=CellInt(ThisDay, \'center\')#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_2" style="width: 500px"></div>