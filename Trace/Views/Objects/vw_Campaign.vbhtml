<div id="vw_Campaign" style="flex: auto;height: calc(100% - 44px);" data-bind="source: Groups, events: { change: Groups_Change, dataBound: Groups_DataBound }"></div>
<script>
    $(document).ready(function () {
        $("#vw_Campaign").kendoGrid({
            scrollable: true,
            reorderable: true,
            selectable: true,
            resizable: true,
            sortable: true,
            filterable: true,
            columnMenu: true,
            columnMenuInit: function (e) {
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-filter-item"))
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-separator").last())
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-desc"))
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-asc"))
            },
            pageable: {
                'previousNext': false,
                'numeric': false,
                'pageSizes': false,
                'info': true,
                'refresh': false
            },
            columns: [
{ 'field': 'PercentDone', 'template': '#=CellString(PercentDone)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampaignTBL1)'), 'title': '@Html.Raw(Language.vw_CampaignTBL7)', 'width': 50 },
{ 'template': '<a href="\\#" title="@Html.Raw(Language.Key_HromadnyTisk)" style="color:\\#425ff4;" class="k-icon k-i-print" data-bind="events: { click: campPrint }"></a>', 'headerTemplate': ' ', 'width': 23 },
{ 'field': 'DeadLine', 'template': '#=CellDate(DeadLine)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampaignTBL2)'), 'title': '@Html.Raw(Language.vw_CampaignTBL8)', 'width': 80 },
{ 'field': 'CampName', 'template': '<input type="text" onclick="$(this).select();" data-bind="value: CampName, events: { change: Groups_Update }" style="width: 100%;border: 0" />', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampaignTBL3)'), 'title': '@Html.Raw(Language.vw_CampaignTBL9)', 'width': 100 },
{ 'field': 'CampDescription', 'template': '#=CellString(CampDescription)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampaignTBL4)'), 'title': '@Html.Raw(Language.vw_CampaignTBL10)', 'width': 100 },
{ 'field': 'CampDateCreated', 'template': '#=CellDate(CampDateCreated)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampaignTBL5)'), 'title': '@Html.Raw(Language.vw_CampaignTBL11)', 'width': 100 },
{ 'field': 'CampState', 'template': '#=CellString(CampState)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_CampaignTBL6)'), 'title': '@Html.Raw(Language.vw_CampaignTBL12)', 'width': 100 }
            ]
        });
    });
</script>
