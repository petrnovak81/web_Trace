@Code
    ViewData("Title") = Language.SVLinkTXT6
    Layout = "~/Views/Shared/_AdminLayout.vbhtml"
End Code

<h3 style="padding-left: 16px;">@Html.Raw(Language.DefectTitle)</h3>
<div id="body" style="height: 100%; display: flex; flex-direction: column;">
    <div id="vwAD_BasicNonAccepted" style="height: 100%;" data-bind="source: vwAD_BasicNonAccepted, events: { dataBound: vwAD_BasicNonAccepted_dataBound }"></div>
</div>
<script>
    $(document).ready(function () {
        $("#vwAD_BasicNonAccepted").kendoGrid({
            scrollable: true,
            reorderable: true,
            editable: false,
            filterable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
            selectable: false,
            resizable: true,
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
                'info': false,
                'refresh': false
            },
            columns: [
                { 'field': 'ACC', 'template': '#=CellString(ACC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_ACC)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_ACC)', 'width': 130 },
                        { 'field': 'ActualDebit', 'template': '#=CellMoney(ActualDebit)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_ActualDebit)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_ActualDebit)', 'width': 100 },
                        { 'field': 'UserLastName', 'template': '#=CellString(UserLastName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.A1_SeznamSpisOSN_PersonSurname)'), 'title': '@Html.Raw(Language.A1_SeznamSpisOSN_PersonSurname)', 'width': 100 },
                        { 'field': 'VisitDateSentFromMother', 'template': '#=CellDate(VisitDateSentFromMother)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA_SpisyNovy_VisitDateSentFromMother)'), 'title': '@Html.Raw(Language.vwA_SpisyNovy_VisitDateSentFromMother)', 'width': 80 },
                        { 'field': 'FirstLapse', 'template': '#=CellDate(FirstLapse)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.FirstLapse)'), 'title': '@Html.Raw(Language.FirstLapse)', 'width': 80 },
                        { 'field': 'LastLapse', 'template': '#=CellDate(LastLapse)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.LastLapse)'), 'title': '@Html.Raw(Language.LastLapse)', 'width': 80 },
                        { 'field': 'LastLapseMsg', 'template': '#=CellString(LastLapseMsg)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.LastLapseMsg)'), 'title': '@Html.Raw(Language.LastLapseMsg)' }
                    ]
                });
            });

            $(function () {
                var viewModel = new kendo.observable({
                    vwAD_BasicNonAccepted: new kendo.data.DataSource({
                        schema: {
                            total: "Total",
                            data: "Data",
                            model: {
                                id: "IDSpisu",
                                fields: {
                                    'ACC': { type: 'number' },
                                    'ActualDebit': { type: 'number' },
                                    'UserLastName': { type: 'string' },
                                    'VisitDateSentFromMother': { type: 'date' },
                                    'FirstLapse': { type: 'date' },
                                    'LastLapse': { type: 'date' },
                                    'LastLapseMsg': { type: 'string' }
                                }
                            }
                        },
                        serverPaging: true,
                        serverSorting: false,
                        serverFiltering: true,
                        transport: {
                            read: {
                                url: "@Url.Action("vwAD_BasicNonAccepted", "Api/AdminService")",
                                dataType: "json",
                            },
                            parameterMap: function (options, type) {
                                var pm = kendo.data.transports.odata.parameterMap(options);
                                if (pm.$filter) {
                                    pm.$filter = pm.$filter.replace("eq ''", "eq null");
                                }
                                return pm;
                            }
                        }
                    }),
                    vwAD_BasicNonAccepted_dataBound: function () {

                    }
                })
                kendo.bind($("#body"), viewModel);
            })
</script>
