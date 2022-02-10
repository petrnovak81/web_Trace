@Code
    ViewData("Title") = Language.SVLinkTXT5
    Layout = "~/Views/Shared/_AdminLayout.vbhtml"
End Code

<style>
    #body, #bottom-splitter {
        height: 100%;
        display: flex;
        flex-direction: column;   
    }

        #top > div {
            height: calc(100% - 32px);
            flex: auto;
        }

        #bottom-left > div {
            height: calc(100% - 32px);
            flex: auto;
        }

        #bottom-right > div {
            height: calc(100% - 42px);
            flex: auto;
        }
</style>

<div id="body" data-role="splitter"
     data-orientation="vertical"
     data-panes="[
     { collapsible: false, scrollable: false, size: '50%' },
     { collapsible: false, scrollable: false } ]">
    <div id="top">
        <ul data-role="menu" class="k-widget k-reset k-header k-menu k-menu-horizontal" tabindex="0" role="menubar">
            <li class="k-state-selected" data-bind="events: { click: sp_Get_SV_CashRevision_refresh }"><span class="k-link"><b>@Html.Raw(Language.SVCashRegisterTXT1)</b></span></li>
            <li data-bind="events: { click: CheekyDocuments }">@Html.Raw(Language.SVCashRegisterTXT2)</li>
        </ul>
        <div id="sp_Get_SV_CashRevision" data-bind="source: sp_Get_SV_CashRevision, events: { dataBound: sp_Get_SV_CashRevision_dataBound }"></div>
        <script>
            $(document).ready(function () {
                $("#sp_Get_SV_CashRevision").kendoGrid({
                    scrollable: true,
                    reorderable: true,
                    editable: false,
                    filterable: true,
                    sortable: {
                        mode: "multiple",
                        allowUnsort: true
                    },
                    autoBind: true,
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
{ 'field': 'UserLastName', 'template': '#=CellString(UserLastName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL71)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL71)', 'width': 100 },
{ 'field': 'ACC', 'template': '#=accLink(IDSpisu, ACC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL81)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL81)', 'width': 100 },
//{ 'field': 'DebitorName ', 'template': '#=CellString(DebitorName )#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL472)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL472)', 'width': 80 },
{ 'field': 'PersSurname ', 'template': '#=CellString(PersSurname )#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL191)'), 'title': '@Html.Raw(Language.CashRegisterTBL191)', 'width': 100 },
{ 'field': 'PersName ', 'template': '#=CellString(PersName )#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL181)'), 'title': '@Html.Raw(Language.CashRegisterTBL181)', 'width': 100 },
{ 'field': 'CashPaymentState', 'template': '#=CellString(CashPaymentState)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL28)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL28)', 'width': 100 },
{ 'field': 'DatePaymentPickup', 'template': '#=CellDate(DatePaymentPickup)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL29)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL29)', 'width': 100 },

{ 'field': 'AmountPickup', 'template': '#=CellMoney(AmountPickup, undefined, (AmountSended && (AmountPickup != AmountSended) ? \'background-color: \\#9E2B11;color: white\' : \'\'))#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL30)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL30)', 'width': 100 },
{
    'field': 'AmountSended', 'template': '# if (AmountSended && (AmountPickup != AmountSended)) { #' +
        '<input type="text" title="@Html.Raw(Language.SVCashRegisterTBL100)" style="border: 1px silver solid;background-color:\\#9E2B11;color:white" onclick="$(this).select();" data-bind="value: AmountSended, events: { change: AmountSendedChange, keypress: numberValue }" class="editTextbox" />' +
        '# } else { #' +
        '<input type="text" title="@Html.Raw(Language.SVCashRegisterTBL100)" style="border: 1px silver solid;" onclick="$(this).select();" data-bind="value: AmountSended, events: { change: AmountSendedChange, keypress: numberValue }" class="editTextbox" />' +
        '# } #', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL32)', '@Html.Raw(Language.SVCashRegisterTBL100)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL32)', 'width': 100
},
//{ 'field': 'AmountOnCentrale', 'template': '<input type="text" style="border: 1px silver solid;" onclick="$(this).select();" data-bind="value: AmountOnCentrale, events: { change: AmountOnCentraleChange, keypress: numberValue }" class="editTextbox" />', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL502)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL502)', 'width': 100 },

{ 'field': 'PODateSent', 'template': '#=CellDate(PODateSent)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL411)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL411)', 'width': 100 },
{ 'field': 'Amount', 'template': '#=CellMoney(Amount)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL431)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL431)', 'width': 100 },
{ 'field': 'PaymentDate', 'template': '#=CellDate(PaymentDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL441)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL441)', 'width': 100 },
{ 'field': 'CashDocNumber', 'template': '#=CellInt(CashDocNumber)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL451)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL451)' }
                    ]
                });
            });
        </script>
    </div>

    <div id="bottom">
        <div data-role="splitter"
             id="bottom-splitter"
             data-orientation="hotizontal"
             data-panes="[
     { collapsible: true, scrollable: false },
     { collapsible: true, scrollable: false, size: '350px' } ]">
            <div id="bottom-left">
                <ul data-role="menu" class="k-widget k-reset k-header k-menu k-menu-horizontal" tabindex="0" role="menubar">
                    <li><span class="k-link"><b>@Html.Raw(Language.SVCashRegisterTXT3)</b></span></li>
                    <li data-bind="selected: ValidateFee1, events: { click: ValidateFeeSelectFilter }" data-filter="1"><span class="k-link"><b>@Html.Raw(Language.SVCashRegisterTXT4)</b></span></li>
                    <li data-bind="selected: ValidateFee2, events: { click: ValidateFeeSelectFilter }" data-filter="2"><span class="k-link"><b>@Html.Raw(Language.SVCashRegisterTXT5)</b></span></li>
                    <li data-bind="events: { click: sp_Get_Cash_ValidateFee_Insert }"><span class="k-icon k-i-plus"></span> @Html.Raw(Language.SVCashRegisterTXT6)</li>
                    <li style="float: right;" data-bind="events: { click: bottomLeftCollapse }"><span class="k-link"><span id="bottom-right-col" class="fa fa-arrow-right"></span></span></li>
                    <li style="float: right;"><a data-role="button" href="@Url.Action("AllFeeFromTRACE", "Administrator")">Stáhnout odměny pro Excel</a></li>
                </ul>

                <div id="sp_Get_Cash_ValidateFee" data-bind="source: sp_Get_Cash_ValidateFee, events: { dataBound: sp_Get_Cash_ValidateFee_dataBound }"></div>
                <script>
                    $(document).ready(function () {
                        $("#sp_Get_Cash_ValidateFee").kendoGrid({
                            scrollable: true,
                            reorderable: true,
                            editable: false,
                            filterable: true,
                            sortable: {
                                mode: "multiple",
                                allowUnsort: true
                            },
                            autoBind: true,
                            selectable: true,
                            resizable: true,
                            columnMenu: true,
                            columnMenuInit: function (e) {
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
                                'refresh': false
                            },
                            columns: [
{ 'field': 'ACC', 'template': '#=accLink(IDSpisu, ACC)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL37)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL37)', 'width': 80 },
{ 'field': 'PaymentDate', 'template': '#=CellDate(PaymentDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL47)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL47)', 'width': 80 },
{ 'field': 'PersSurname', 'template': '#=ParsName(PersName, PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL71)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL71)', 'width': 100 },

{ 'field': 'DebtSurname ', 'template': '#=CellString(DebtSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL191)'), 'title': '@Html.Raw(Language.CashRegisterTBL191)', 'width': 100 },
{ 'field': 'DebtName ', 'template': '#=CellString(DebtName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL181)'), 'title': '@Html.Raw(Language.CashRegisterTBL181)', 'width': 100 },

{ 'field': 'CreditorAlias', 'template': '#=CellString(CreditorAlias)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL50)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL50)', 'width': 100 },
{ 'field': 'DateOnCentrale', 'template': '#=CellDate(DateOnCentrale)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL51)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL51)', 'width': 80 },
{ 'field': 'TypeFeeTxt', 'template': '#=CellString(TypeFeeTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL52)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL52)', 'width': 200 },
{ 'field': 'DateCreated', 'template': '#=CellDate(DateCreated)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL53)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL53)', 'width': 100 },
{ 'field': 'Base', 'template': '#=CellMoney(Base)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL54)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL54)', 'width': 100 },
{ 'field': 'PercentFee', 'template': '#=CellInt(PercentFee)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL55)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL55)', 'width': 50 },
{ 'field': 'Fee', 'template': '#=CellMoney(Fee)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL56)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL56)', 'width': 100 },
{ 'field': 'SVApproved', 'template': '#=CellBool(SVApproved)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL57)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL57)', 'width': 30 },
{ 'field': 'MonthPeriod', 'template': '#=CellString(MonthPeriod)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL58)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL58)', 'width': 100 },
{ 'template': '<a href="\\#" # if(OnlyRead) { # style="display: none;" # } # data-bind="events: { click: Edit }">@Html.Raw(Language.SVCashRegisterTBL301)</a>', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL301)'), 'title': '@Html.Raw(Language.SVCashRegisterTBL301)', 'width': 100 }]
                        });
                    });
                </script>
            </div>
            <div id="bottom-right">
                <ul data-role="menu" class="k-widget k-reset k-header k-menu k-menu-horizontal" tabindex="0" role="menubar">
                    <li data-bind="events: { click: bottomRightCollapse }"><span class="k-link"><span id="bottom-left-col" class="fa fa-arrow-left"></span></span></li>
                </ul>
                <div id="sp_Get_SV_ListBilling" data-bind="source: sp_Get_SV_ListBilling"></div>
                <script>
                    $(document).ready(function () {
                        $("#sp_Get_SV_ListBilling").kendoGrid({
                            scrollable: true,
                            reorderable: true,
                            editable: false,
                            filterable: true,
                            sortable: {
                                mode: "multiple",
                                allowUnsort: true
                            },
                            autoBind: true,
                            selectable: true,
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
                    { 'field': 'UserName', 'template': '#=CellString(UserName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL71)'), 'width': 80 },
                    { 'field': 'DateOnCentrale', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL22)'), 'template': '<a href=\'\\#\' data-bind=\'events: { click: DateOnCentraleEdit }\'><i class=\'fa fa-calendar-plus-o\'></i> #if(DateOnCentrale) {# #=kendo.toString(DateOnCentrale, \'d\')# #}#</a>', 'width': 85 },
                    { 'field': 'DateBilling', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL23)'), 'template': '#=CellDate(DateBilling)#', 'width': 80 },
                    { 'field': 'MonthPeriod', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL24)'), 'template': '<a href=\'\\#\' data-bind=\'events: { click: CashInvoice }\'>#=MonthPeriod#</a>', 'width': 80 },
                    { 'field': 'SumAmount', 'headerTemplate': headerTemplate('@Html.Raw(Language.SVCashRegisterTBL25)'), 'template': '#=CellMoney(SumAmount)#', 'width': 80 }]
                        });
                    });
                </script>

            </div>
        </div>
    </div>
</div>

<!-- @Html.Partial("~/Views/Objects/SVCashRevisionParovat.vbhtml") -->
@Html.Partial("~/Views/Objects/SVOdmenaSchvalit.vbhtml")
@Html.Partial("~/Views/Objects/SVValidateFeeAdd.vbhtml")
@Html.Partial("~/Views/Objects/SVCashRevisionStorno.vbhtml")
@Html.Partial("~/Views/Objects/ModalCalendar.vbhtml")

<script>
    function accLink(IDSpisu, ACC) {
        if (ACC) {
            return '<a href="@Url.Action("FileAdministration", "Administrator")?id=' + ACC + '">' + ACC + '</a>'
        } else {
            return "";
        }
    };

    function ParsName(PersName, PersSurname) {
        var name = "";
        if (PersName && PersSurname) {
            name = PersSurname + " " + PersName;
        } else {
            if (PersName) {
                name = PersName;
            }
            if (PersSurname) {
                name = PersSurname;
            }
        }
        return "<div class='cellString' title='" + name + "'>" + name + "</div>";
    }

    var viewModel = null;
    $(function () {
        viewModel = new kendo.observable({
            bottomLeftCollapse: function (e) {
                var s = $("#bottom-splitter").data("kendoSplitter"), p = $("#bottom-right"), b = $("#bottom-right-col");
                if (p.width() > 0) {
                    s["collapse"](p);
                    b.toggleClass('fa-arrow-right fa-arrow-left');
                } else {
                    s["expand"](p);
                    b.toggleClass('fa-arrow-left fa-arrow-right');
                }
            },
            bottomRightCollapse: function (e) {
                var s = $("#bottom-splitter").data("kendoSplitter"), p = $("#bottom-left"), b = $("#bottom-left-col");
                if (p.width() > 0) {
                    s["collapse"](p);
                    b.toggleClass('fa-arrow-left fa-arrow-right');
                } else {
                    s["expand"](p);
                    b.toggleClass('fa-arrow-right fa-arrow-left');
                }
            },
            sp_Get_SV_CashRevision: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDCashPayment",
                        fields: {
                            'UserLastName': { type: 'string' },
                            'ACC': { type: 'number' },
                            'DatePaymentPickup': { type: 'date' },
                            'AmountPickup': { type: 'number' },
                            'PODateSent': { type: 'date' },
                            'AmountSended': { type: 'number' },
                            'AmountOnCentrale': { type: 'number' },
                            'Amount': { type: 'number' },
                            'PaymentDate': { type: 'date' },
                            'CashDocNumber': { type: 'number' },
                            'CashPaymentState': { type: 'string' }
                        }
                    }
                },
                //serverPaging: true,
                //serverSorting: false,
                //serverFiltering: true,
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_SV_CashRevision", "Api/AdminService")",
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
            sp_Get_SV_CashRevision_dataBound: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var rows = e.sender.tbody.find("tr");
                rows.each(function () {
                    var di = grid.dataItem($(this));
                    if (di) {
                        $(this).attr("data-id", di.IDCashPayment);
                    }
                });
            },
            AmountSendedChange: function (e) {
                var that = this;
                $.get("@Url.Action("sp_Do_ChangeCashAmountSended", "Api/Service")", { IDCashPayment: e.data.IDCashPayment, AmountSended: e.data.AmountSended }, function (result) {
                    //that.sp_Get_SV_CashRevision.read();
                })
            },
            AmountOnCentraleChange: function (e) {
                var val = 0
                if (e.data.AmountOnCentrale) {
                    val = e.data.AmountOnCentrale
                }
                $.get("@Url.Action("sp_Do_SV_ChangeAmountOnCentrale", "Api/AdminService")", { iDCashPayment: e.data.IDCashPayment, amount: e.data.AmountOnCentrale }, function (result) {
                    //that.sp_Get_SV_CashRevision.read();
                })
            },
            numberValue: function (e) {
                var temp = e.currentTarget.value;
                var count = (temp.match(/,/g) || []).length;
                return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57) || e.which === 110) ? (e.which === 44 && count === 0 ? true : false) : true;
            },
            sp_Get_SV_CashRevision_refresh: function (e) {
                this.sp_Get_SV_CashRevision.read();
            },
            CheekyDocuments: function (e) {
                SVCashRevisionStorno();
            },
            //Parovat: function (e) {
            //    var that = this;
            //    SVCashRevisionParovat(e.data.IDSpisu, e.data.IDCashPayment, function (result) {
            //        that.sp_Get_SV_CashRevision.read();
            //    });
            //},
            Edit: function (e) {
                var that = this;
                SVOdmenaSchvalit(e.data.IDFee, e.data.Fee, e.data.SVApproved, function (result) {
                    that.sp_Get_Cash_ValidateFee.read();
                });
            },
            sp_Get_Cash_ValidateFee_Insert: function (e) {
                var that = this;
                SVValidateFeeAdd(function (result) {
                    if (result) {
                        that.sp_Get_Cash_ValidateFee.read();
                    }
                })
            },
            sp_Get_Cash_ValidateFee: new kendo.data.DataSource({
                pageSize: 100,
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDFee",
                        fields: {
                            'UserLastName': { type: 'string' },
                            'PaymentDate': { type: 'date' },
                            'ACC': { type: 'number' },
                            'DebtSurname': { type: 'string' },
                            'DebtName': { type: 'string' },
                            'TypeFeeTxt': { type: 'string' },
                            'DateCreated': { type: 'date' },
                            'Base': { type: 'number' },
                            'PercentFee': { type: 'number' },
                            'Fee': { type: 'number' },
                            'SVApproved': { type: 'boolean' },
                            'MonthPeriod': { type: 'string' },
                            'OnlyRead': { type: 'boolean' }
                        }
                    }
                },
                //serverPaging: true,
                //serverSorting: false,
                //serverFiltering: true,
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_Cash_ValidateFee", "Api/AdminService")",
                        dataType: "json",
                    },
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if (pm.$filter) {
                            pm.$filter = pm.$filter.replace("eq ''", "eq null");
                        }
                        pm.type = viewModel.ValidateFeeType;
                        return pm;
                    }
                }
            }),
            sp_Get_Cash_ValidateFee_dataBound: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var rows = e.sender.tbody.find("tr");
                rows.each(function () {
                    var di = grid.dataItem($(this));
                    $(this).attr("data-id", di.IDFree);
                });
            },
            ValidateFeeType: 1,
            ValidateFee1: true,
            ValidateFee2: false,
            ValidateFeeSelectFilter: function (e) {
                var f = $(e.currentTarget).data("filter");
                switch (f) {
                    case 1:
                        this.set("ValidateFee1", true);
                        this.set("ValidateFee2", false);
                        break;
                    case 2:
                        this.set("ValidateFee1", false);
                        this.set("ValidateFee2", true);
                        break;
                }
                this.set("ValidateFeeType", f);
                this.sp_Get_Cash_ValidateFee.read();
            },
            sp_Get_SV_ListBilling: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDMonthBilling",
                        fields: {
                            'UserName': { type: 'string' },
                            'DateOnCentrale': { type: 'date' },
                            'DateBilling': { type: 'date' },
                            'MonthPeriod': { type: 'string' },
                            'SumAmount': { type: 'number' }
                        }
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_SV_ListBilling", "Api/AdminService")",
                        dataType: "json",
                    }
                }
            }),
            CashInvoice: function (e) {
                var win = window.open("@Url.Action("CashInvoice", "Base")" + "?ID=" + e.data.IDUser + "&IDMonthBilling=" + e.data.IDMonthBilling, '_blank');
                win.focus();
            },
            DateOnCentraleEdit: function (e) {
                ModalCalendar(function (date) {
                    $.get("@Url.Action("sp_Do_SV_Cash_UpdateDateOnCentrale", "Api/AdminService")", { iDMonthBilling: e.data.IDMonthBilling, datum: kendo.toString(date, "yyyy-MM-dd HH:mm:ss") }, function (result) {
                        e.data.set("DateOnCentrale", date);
                    })
                })
            }
        });
        kendo.bind($("#body"), viewModel);
    });
</script>