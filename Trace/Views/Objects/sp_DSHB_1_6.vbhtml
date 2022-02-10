<div data-role="grid" class="grid vertical-header"
            data-resizable="false"
            data-scrollable="false"
            data-toolbar='[{"template": "<div class=\"toolbar\"><button type=\"button\" class=\"k-button k-button-icontext\" data-filename=\"@Html.Raw(Language.sp_DSHB_1_6TXT1).pdf\" onclick=\"exportPDF(this)\"><span class=\"k-icon k-i-file-pdf\"></span> Export PDF</button></div>" }]'
            data-columns="[
            { 'field': 'Name', 'headerTemplate': '@Html.ActionLink("6. @Html.Raw(Language.sp_DSHB_1_6TXT1)", "SVDashboardDetail", "Administrator", New With {.p = "sp_DSHB_1_6"}, New With {.target = "_blank", .class = "k-link", .style = "font-size:18px;font-weight:bold;"}).ToHtmlString' },
            { 'field': 'Neprijate', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_6TXT1)</span>', 'template': '#=CellInt(Neprijate, \'center\')#', 'width': 90 },
            { 'field': 'Prodleni', 'headerTemplate': '<span class=\'verticalText\'>@Html.Raw(Language.sp_DSHB_1_6TXT2)</span>', 'template': '#=CellInt(Prodleni, \'center\')#', 'width': 90 }
            ]"
            data-bind="source: sp_DSHB_1_6" style="width: 400px;"></div>