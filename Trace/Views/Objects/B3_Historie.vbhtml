<div id="B3_podzal_Historie" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b class="">@Html.Raw(Language.B3_HistorieTXT1)</b></td>
            <td></td>
            <td></td>
            <td></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body">
        <div id="B3_Historie" class="breakcell" data-bind="source: B3_HistorieSpisu" style="width:100%;"></div>
        <script>
            $(function () {
                $("#B3_Historie").kendoGrid({
                    scrollable: false,
                    filterable: true,
                    sortable: {
                        mode: "multiple",
                        allowUnsort: true
                    },
                    selectable: 'single',
                    resizable: true,
                    columnMenu: true,
                    columnMenuInit: function (e) {
                        e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-filter-item"))
                        e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-separator").last())
                        e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-desc"))
                        e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-asc"))
                    },
                    columns: [
{ 'field': 'RecordDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_HistorieRecordDate)'), 'title': '@Html.Raw(Language.B3_HistorieRecordDate)', 'template': '#=CellDate(RecordDate)#', 'width': 80 },
{ 'field': 'RecordCommentType', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_HistorieRecordCommentType)'), 'title': '@Html.Raw(Language.B3_HistorieRecordCommentType)', 'template': '<a href=\'\\#\' title=\'#=RecordCommentType#\' data-bind=\'events: { click: Comment }\'>#=RecordCommentType#</a>', 'width': 200 },
{ 'field': 'RecordCommentTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_HistorieRecordCommentTxt)'), 'title': '@Html.Raw(Language.B3_HistorieRecordCommentTxt)', 'template': '#=CellString(RecordCommentTxt)#' },
                    ]
                });
            });
        </script>
    </div>
</div>
