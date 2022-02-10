<div id="Spisy" style="height: 100%;" data-bind="source: Spisy, events: { dataBound: Spisy_dataBound, detailInit: Spisy_detailInit, change: Spisy_change }"></div>
<script>
    $(document).ready(function () {
        $("#Spisy").kendoGrid({
            scrollable: true,
            reorderable: true,
            editable: false,
            filterable: true,
            sortable: {
                mode: "multiple",
                allowUnsort: true
            },
            detailTemplate: kendo.template($("#urgency").html()),
            selectable: 'single',
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
                'info': true,
                'refresh': false
            },
            columns: [
{ 'headerTemplate': '<input type="checkbox" title="@Html.Raw(Language.Spisy_SelectAll)" id="a1_header-chb">', 'template': '<input type="checkbox" data-bind="events: { change: selectRow }" id="ch-#=uid#" class="checkrow">', width: 30 },
{ 'field': 'AlertExist', 'template': '# if (AlertExist !== 0) { # <i class="fa fa-bell-o"></i> # } #', 'headerTemplate': '<i class="fa fa-bell" title="@Html.Raw(Language.vwA1_Finished_AlertExist)"></i>', 'title': '@Html.Raw(Language.vwA1_Finished_AlertExist)', 'width': 30 },
{ 'field': 'ACC', 'template': '#=ACC#', 'headerTemplate': headerTemplate('@Html.Raw(Language.vwA1_Finished_ACC)'), 'title': '@Html.Raw(Language.vwA1_Finished_ACC)', 'width': 90 },
{ 'field': 'PersSurname', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_PersSurname'), 'template': '#=CellString(PersSurname)#', 'title': '@Html.Raw(Language.vwA1_Finished_PersSurname)', 'width': 130 },
{ 'field': 'PersName', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_PersName'), 'template': '#=CellString(PersName)#', 'title': '@Html.Raw(Language.vwA1_Finished_PersName)', 'width': 130 },
{ 'field': 'CreditorAlias', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_CreditorAlias'), 'template': '#=CellString(CreditorAlias)#', 'title': '@Html.Raw(Language.vwA1_Finished_CreditorAlias)', 'width': 200 },
{ 'field': 'FV_TerminationDate', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_FV_TerminationDate'), 'template': '#=CellDate(FV_TerminationDate)#', 'title': '@Html.Raw(Language.vwA1_Finished_FV_TerminationDate)', 'width': 90 },
{ 'field': 'UserWhoClosedFile', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_UserWhoClosedFile'), 'template': '#=CellString(UserWhoClosedFile)#', 'title': '@Html.Raw(Language.vwA1_Finished_UserWhoClosedFile)', 'width': 90 },
{ 'field': 'ReasonClosedFile', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_ReasonClosedFile'), 'template': '#=CellString(ReasonClosedFile)#', 'title': '@Html.Raw(Language.vwA1_Finished_ReasonClosedFile)', 'width': 130 },
{ 'field': 'PersIC', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_PersIC'), 'template': '#=CellString(PersIC)#', 'title': '@Html.Raw(Language.vwA1_Finished_PersIC)', 'width': 90 },
{ 'field': 'ActualDebit', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_ActualDebit'), 'template': '#=CellMoney(ActualDebit)#', 'title': '@Html.Raw(Language.vwA1_Finished_ActualDebit)', 'width': 90 },
{ 'field': 'CurrencyTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.Currency)'), 'title': '@Html.Raw(Language.Currency)', 'width': 50 },
{ 'field': 'SumPaymentsByFV', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_SumPaymentsByFV'), 'template': '#=CellMoney(SumPaymentsByFV)#', 'title': '@Html.Raw(Language.vwA1_Finished_SumPaymentsByFV)', 'width': 90 },
{ 'field': 'AllCommissionPerFile', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_AllCommissionPerFile'), 'template': '#=CellMoney(AllCommissionPerFile)#', 'title': '@Html.Raw(Language.vwA1_Finished_AllCommissionPerFile)', 'width': 90 },
{ 'field': 'VisitDateReceiveFromMother', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_VisitDateReceiveFromMother'), 'template': '#=CellDate(VisitDateReceiveFromMother)#', 'title': '@Html.Raw(Language.vwA1_Finished_VisitDateReceiveFromMother)', 'width': 90 },
{ 'field': 'PersRC', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_PersRC'), 'template': '#=CellRC(PersRC)#', 'title': '@Html.Raw(Language.vwA1_Finished_PersRC)', 'width': 90 },
{ 'field': 'PersBirthDate', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_PersBirthDate'), 'template': '#=CellDate(PersBirthDate)#', 'title': '@Html.Raw(Language.vwA1_Finished_PersBirthDate)', 'width': 90 },
{ 'field': 'StateTxt', 'headerTemplate': headerTemplate('@Language.vwA1_Finished_StateTxt'), 'template': '#=CellString(StateTxt)#', 'title': '@Html.Raw(Language.vwA1_Finished_StateTxt)', 'width': 160 },
            ]
        });
    });
</script>

<script type="text/html" id="urgency">
    <table data-bind="source: B3_Urgency" data-template="urgencyrowtemplate" style="width: 100%; border-spacing: 1px;"></table>
</script>

<script type="text/html" id="urgencyrowtemplate">
    <tr>
        <td style="width:30px;padding:3px;text-align:center;">
            # if(Type === 'U') { #
    <i style="color: rgb(158, 43, 17);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } else if(Type === 'R') { #
    <i style="color: rgb(255, 210, 70);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } else if(Type === 'M') { #
    <i style="color: rgb(120, 210, 55);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } #
        </td>
        <td style="width: 70px; padding: 3px;"># if(CreatedDate) { #
            <div title="@Html.Raw(Language.CreatedDate)">#=kendo.toString(new Date(CreatedDate), 'd')#</div>
            # } #
        </td>
        <td style="padding: 3px;">#=CellString(Txt)#</td>
        <td style="width: 70px; padding: 3px;"># if(DeadLine) { #
            <div title="@Html.Raw(Language.DeadLineDate)">#=kendo.toString(new Date(DeadLine), 'd')#</div>
            # } #
        </td>
    </tr>
</script>
