<div id="vw_AllUrgRemindMsg" style="height: 100%" data-bind="source: Source, events: { dataBound: DataBound }"></div>
<script>
    $(document).ready(function () {
        $("#vw_AllUrgRemindMsg").kendoGrid({
            scrollable: true,
            reorderable: true,
            editable: false,
            filterable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
            selectable: true,
            resizable: true,
            columnMenu: true,
            columnMenuInit: function(e) {
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-filter-item"))
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-separator").last())
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-desc"))
                e.container.find(".k-menu").prepend(e.container.find(".k-menu li.k-sort-asc"))
            },
            pageable: {
                'previousNext': true,
                'numeric': true,
                'pageSizes': false,
                'info': true,
                'refresh': true
            },
            columns: [
                    { 'template': ' ', headerTemplate: '<i class="fa fa-bell" title="Oznámení"></i>', 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL9)', 'width': 30 },
                    { 'template': '# if (Type === "R") { # <a href="\\#" data-bind="events: { click: DeleteRecord }"><span class="k-icon k-i-close"></span></a> # } #', 'width': 30 },
                    { 'field': 'DeadLine', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_AllUrgRemindMsgTBL1)'), 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL10)', 'template': '#=CellDate(DeadLine)#', 'width': 60 },
                    { 'field': 'Title', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_AllUrgRemindMsgTBL2)'), 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL11)', 'template': '#=CellString(Title)#', 'width': 200 },
                    { 'field': 'Body', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_AllUrgRemindMsgTBL3)'), 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL12)', 'template': '#=CellString(Body)#' },
                    { 'field': 'Jmeno', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_AllUrgRemindMsgTBL4)'), 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL13)', 'template': '#=CellString(Jmeno)#' },
                    { 'field': 'ACC', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_AllUrgRemindMsgTBL5)'), 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL14)', 'template': '<a href="" data-bind="attr: { href: ACCLink }">#=ACC#</a>', 'width': 70 },
                    { 'field': 'CreatedDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_AllUrgRemindMsgTBL6)'), 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL15)', 'template': '#=CellDateTime(CreatedDate)#', 'width': 100 },
                    { 'field': 'Zadavatel', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_AllUrgRemindMsgTBL7)'), 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL16)', 'template': '#=CellString(Zadavatel)#', 'width': 100 },
                    { 'field': 'Type', 'headerTemplate': headerTemplate('@Html.Raw(Language.vw_AllUrgRemindMsgTBL8)'), 'title': '@Html.Raw(Language.vw_AllUrgRemindMsgTBL17)', 'template': '#=CellString(Type)#', 'width': 30 }
            ]
        });
    });
</script>
