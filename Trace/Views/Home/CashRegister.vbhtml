@Code
    ViewData("Title") = Language.layoutmasTXT8
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<style>
    #body, #top > div, #bottom > div {
        height: 100%;
        display: flex;
        flex-direction: column;
    }

    #top-left #sp_Get_CashBook {
            height: calc(100% - 18px);
            flex: auto;
        }

        #bottom-left #sp_Get_ListUserFee  {
            height: calc(100% - 18px);
            flex: auto;
        }

        #bottom-right #sp_Get_ListBilling {
            height: calc(100% - 75px);
            flex: auto;
        }
</style>

<div id="body" data-role="splitter"
    data-orientation="vertical"
    data-panes="[
     { collapsible: false, scrollable: false, size: '50%' },
     { collapsible: false, scrollable: false } ]">
    <div id="top">
        <div data-role="splitter"
            id="top-splitter"
            data-orientation="hotizontal"
            data-panes="[
     { collapsible: true, scrollable: false },
     { collapsible: true, scrollable: true, size: '350px' } ]">
            <div id="top-left">
                <ul data-role="menu" class="k-widget k-reset k-header k-menu k-menu-horizontal" tabindex="0" role="menubar">
                    <li class="k-state-selected"><span><b>@Html.Raw(Language.CashRegisterTXT1)</b></span><br /><small>@Html.Raw(Language.CashRegisterTXT2)</small></li>
                    <li style="float: right;" data-bind="events: { click: topLeftCollapse }"><span class="k-link"><span id="top-left-col" class="fa fa-arrow-right"></span></span></li>
                    <li style="float: right;" data-bind="events: { click: sp_Get_CashBook_clearFilter }"><span class="k-icon k-i-filter-clear"></span></li>
                    <li style="float: right;" data-bind="visible: bulkPrint_visible,  events: { click: bulkPrint }">@Html.Raw(Language.CashRegisterTXT3)</li>
                </ul>
                <div id="sp_Get_CashBook" data-bind="source: sp_Get_CashBook, events: { dataBound: sp_Get_CashBook_dataBound }"></div>
                <script>
                    $(document).ready(function () {
                        $("#sp_Get_CashBook").kendoGrid({
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
                                'info': true,
                                'refresh': false
                            },
                            columns: [
{ 'field': 'UrgExist', 'template': '# if (UrgExist) { # <i style="color: rgb(158, 43, 17)" class="fa fa-bell"></i> # } #', 'headerTemplate': ' ', 'title': '@Html.Raw(Language.CashRegisterTBL34)', 'width': 30 },
{ 'field': 'CashPaymentState', 'template': '#=CellString(CashPaymentState)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL1)'), 'title': '@Html.Raw(Language.CashRegisterTBL35)', 'width': 100 },
{ 'field': 'ACC', 'template': '<a href="\\#" data-bind="attr: { href: ACCLink }">#=CellRaw(ACC)#</a>', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL2)'), 'title': '@Html.Raw(Language.CashRegisterTBL36)', 'width': 80 },
{ 'field': 'CashDocNumber', 'template': '#=CellString(CashDocNumber)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL3)'), 'title': '@Html.Raw(Language.CashRegisterTBL37)', 'width': 100 },
{ 'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL4)'), 'title': '@Html.Raw(Language.CashRegisterTBL38)', 'width': 100 },
{ 'field': 'PersName', 'template': '#=CellString(PersName)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL5)'), 'title': '@Html.Raw(Language.CashRegisterTBL39)', 'width': 100 },
{ 'field': 'DatePaymentPickup', 'template': '#=CellDate(DatePaymentPickup)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL6)'), 'title': '@Html.Raw(Language.CashRegisterTBL40)', 'width': 80 },

{ 'field': 'AmountPickup', 'template': '#=CellMoney(AmountPickup, undefined, (AmountSended && (AmountPickup != AmountSended) ? \'background-color: \\#9E2B11;color: white\' : \'\'))#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL7)'), 'title': '@Html.Raw(Language.CashRegisterTBL41)', 'width': 60 },
{ 'field': 'AmountSended', 'template': '# if (rr_CashPaymState === 2) { # <input type="text" style="border: 1px silver solid;" onclick="$(this).select();" data-bind="value: AmountSended, events: { change: AmountSendedChange, keypress: numberValue }" class="editTextbox" /> # } else { # #=CellMoney(AmountSended, undefined, (AmountSended && (AmountPickup != AmountSended) ? \'background-color: \\#9E2B11;color: white\' : \'\'))# # } #', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL8)'), 'title': '@Html.Raw(Language.CashRegisterTBL42)', 'width': 60 },

{ 'field': 'Sended', 'template': '# if (rr_CashPaymState < 2) { # <input type="checkbox" # if (rr_CashPaymState === 1) { # checked # } # data-bind="events: { change: SendedChange }" id="Sended-#=uid#" class="k-checkbox"><label class="k-checkbox-label" for="Sended-#=uid#"></label> # } #', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL9)'), 'title': '@Html.Raw(Language.CashRegisterTBL43)', 'width': 100 },
{ 'field': 'Prepare', 'template': '# if (rr_CashPaymState > 1 && rr_CashPaymState < 4) { # <input type="checkbox" # if (rr_CashPaymState === 3) { # checked # } # data-bind="events: { change: PrepareChange }" id="Prepared-#=uid#" class="k-checkbox"><label class="k-checkbox-label" for="Prepared-#=uid#"></label> # } #', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL10)'), 'title': '@Html.Raw(Language.CashRegisterTBL43)', 'width': 30 },

{ 'field': 'PODateSent', 'template': '#=CellDate(PODateSent)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL11)'), 'title': '@Html.Raw(Language.CashRegisterTBL45)', 'width': 80 },
{ 'field': 'DatePaymentOnCentrale', 'template': '#=CellDate(DatePaymentOnCentrale)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL12)'), 'title': '@Html.Raw(Language.CashRegisterTBL12)', 'width': 80 },
{ 'field': 'Amount', 'template': '#=CellMoney(Amount)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL66)'), 'title': '@Html.Raw(Language.CashRegisterTBL66)', 'width': 80 },
{ 'field': 'IDPaymentOrder', 'template': '# if (IDPaymentOrder) { # <a href="\\#" data-bind="events: { click: bulkShow }" >#=IDPaymentOrder#</a> # } #', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL13)'), 'title': '@Html.Raw(Language.CashRegisterTBL47)', 'width': 100 }
            ]
        });
    });
                </script>
            </div>
            <div id="top-right">
                <ul data-role="menu" class="k-widget k-reset k-header k-menu k-menu-horizontal" tabindex="0" role="menubar">
                    <li data-bind="events: { click: topRightCollapse }"><span class="k-link"><span id="top-right-col" class="fa fa-arrow-left"></span></span></li>
                </ul>
                <div data-role="grid" 
                    data-resizable="true"
                    data-scrollable="true"
                    data-bind="source: sp_Get_CashSUM, events: { dataBound: sp_Get_CashSUM_DataBound }"
                    data-columns="[
                    { 'field': 'SumToSent', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL14)'), 'template': '# if(Ord === 90) { # #=CellInt(SumToSent)# # } else { # #=CellMoney(SumToSent)# # } #', 'width': 80 },
                    { 'field': 'Title', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL15)'), 'template': '#=CellString(Title)#' },
                    ]"></div>
            </div>
        </div>
    </div>
    <div id="bottom">
        <div data-role="splitter"
            id="bottom-splitter"
            data-orientation="hotizontal"
            data-panes="[
     { collapsible: true, scrollable: false },
     { collapsible: true, scrollable: true, size: '350px' } ]">
            <div id="bottom-left">
                <ul data-role="menu" class="k-widget k-reset k-header k-menu k-menu-horizontal" tabindex="0" role="menubar">
                    <li class="k-state-selected"><span><b>@Html.Raw(Language.CashRegisterTXT4)</b></span><br /><small>@Html.Raw(Language.CashRegisterTXT5)</small></li>
                    <li style="float: right;" data-bind="events: { click: bottomLeftCollapse }"><span class="k-link"><span id="bottom-right-col" class="fa fa-arrow-right"></span></span></li>
                    <li style="float: right;" data-bind="events: { click: sp_Get_ListUserFee_clearFilter }"><span class="k-icon k-i-filter-clear"></span></li>
                </ul>
                <div id="sp_Get_ListUserFee" data-bind="source: sp_Get_ListUserFee, events: { dataBound: sp_Get_ListUserFee_dataBound }"></div>
                <script>
                    $(document).ready(function () {
                        $("#sp_Get_ListUserFee").kendoGrid({
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
                                'info': true,
                                'refresh': false
                            },
                            columns: [
{ 'field': 'ACC', 'template': '<a href="\\#" data-bind="attr: { href: ACCLink }">#=CellRaw(ACC)#</a>', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL210)'), 'title': '@Html.Raw(Language.CashRegisterTBL210)', 'width': 80 },
{ 'field': 'PaymentDate', 'template': '#=CellDate(PaymentDate)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL171)'), 'title': '@Html.Raw(Language.CashRegisterTBL171)', 'width': 80 },
{ 'field': 'PersSurname ', 'template': '#=CellString(PersSurname )#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL191)'), 'title': '@Html.Raw(Language.CashRegisterTBL191)', 'width': 100 },
{ 'field': 'PersName ', 'template': '#=CellString(PersName )#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL181)'), 'title': '@Html.Raw(Language.CashRegisterTBL181)', 'width': 100 },
{ 'field': 'CreditorAlias ', 'template': '#=CellString(CreditorAlias )#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL201)'), 'title': '@Html.Raw(Language.CashRegisterTBL201)', 'width': 100 },
{ 'field': 'DateOnCentrale', 'template': '#=CellDate(DateOnCentrale)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL211)'), 'title': '@Html.Raw(Language.CashRegisterTBL211)', 'width': 80 },
{ 'field': 'TypeFeeTxt', 'template': '#=CellString(TypeFeeTxt)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL221)'), 'title': '@Html.Raw(Language.CashRegisterTBL221)', 'width': 200 },
{ 'field': 'DateCreated', 'template': '#=CellDate(DateCreated)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL231)'), 'title': '@Html.Raw(Language.CashRegisterTBL231)', 'width': 100 },
{ 'field': 'Base', 'template': '#=CellMoney(Base)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL241)'), 'title': '@Html.Raw(Language.CashRegisterTBL241)', 'width': 100 },
{ 'field': 'PercentFee', 'template': '#=CellPercentage(PercentFee)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL571)'), 'title': '@Html.Raw(Language.CashRegisterTBL571)', 'width': 50 },
{ 'field': 'Fee', 'template': '#=CellMoney(Fee)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL261)'), 'title': '@Html.Raw(Language.CashRegisterTBL261)', 'width': 100 },
{ 'field': 'SVApproved', 'template': '#=CellBool(SVApproved)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL271)'), 'title': '@Html.Raw(Language.CashRegisterTBL271)', 'width': 30 },
{ 'field': 'MonthPeriod', 'template': '#=CellString(MonthPeriod)#', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL281)'), 'title': '@Html.Raw(Language.CashRegisterTBL281)', 'width': 100 }]
        });
                    });

                </script>
            </div>
            <div id="bottom-right">
                <ul data-role="menu" class="k-widget k-reset k-header k-menu k-menu-horizontal" tabindex="0" role="menubar">
                    <li data-bind="events: { click: bottomRightCollapse }"><span class="k-link"><span id="bottom-left-col" class="fa fa-arrow-left"></span></span></li>
                </ul>
                <div data-role="grid" 
                    data-resizable="true"
                    data-scrollable="false"
                    data-bind="source: sp_Get_NotYetBilling"
                    data-columns="[
                    { 'field': 'NotYetBilling', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL29)'), 'template': '#=CellMoney(NotYetBilling)#', 'width': 80 }]"></div>
                
                <div data-role="grid" id="sp_Get_ListBilling"
                    data-resizable="true"
                    data-scrollable="true"
                    data-bind="source: sp_Get_ListBilling"
                    data-columns="[
                    { 'field': 'DateBilling', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL301)'), 'template': '#=CellDate(DateBilling)#' },
                    { 'field': 'DateOnCentrale', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL311)'), 'template': '#=CellDate(DateOnCentrale)#' },
                    { 'field': 'MonthPeriod', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL321)'), 'template': '<a href=\'\\#\' data-bind=\'events: { click: CashInvoice }\'>#=MonthPeriod#</a>' },
                    { 'field': 'SumAmount', 'headerTemplate': headerTemplate('@Html.Raw(Language.CashRegisterTBL331)'), 'template': '#=CellMoney(SumAmount)#' }
                    ]"></div>
            </div>
        </div>
    </div>
</div>

<script>
    var viewModel = null;
    $(function () {
        viewModel = new kendo.observable({
            topLeftCollapse: function (e) {
                var s = $("#top-splitter").data("kendoSplitter"), p = $("#top-right"), b = $("#top-left-col");
                if (p.width() > 0) {
                    s["collapse"](p);
                    b.toggleClass('fa-arrow-right fa-arrow-left');
                } else {
                    s["expand"](p);
                    b.toggleClass('fa-arrow-left fa-arrow-right');
                }
            },
            topRightCollapse: function (e) {
                var s = $("#top-splitter").data("kendoSplitter"), p = $("#top-left"), b = $("#top-right-col");
                if (p.width() > 0) {
                    s["collapse"](p);
                    b.toggleClass('fa-arrow-left fa-arrow-right');
                } else {
                    s["expand"](p);
                    b.toggleClass('fa-arrow-right fa-arrow-left');
                }
            },
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
            ACCLink: function (e) {
                var id = e.IDSpisu;
                var state = e.rr_State;
                if (e.ACC) {
                    if (state > 9 && state < 20) {
                        return "News?id=" + id;
                    } else if (state > 29 && state < 40) {
                        return "PersonalVisit?id=" + id;
                    } else if (state > 39 && state < 50) {
                        return "Agreements?id=" + id;
                    } else if (state > 49 && state < 60) {
                        return "ToProcess?id=" + id;
                    } else if (state > 59) {
                        return "Finished?id=" + id;
                    } else {
                        return "";
                    };
                } else {
                    return "";
                }
            },
            numberValue: function (e) {
                var temp = e.currentTarget.value;
                var count = (temp.match(/,/g) || []).length;
                return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57) || e.which === 110) ? (e.which === 44 && count === 0 ? true : false) : true;
            },
            sp_Get_CashBook_Selected: null,
            sp_Get_CashBook: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDCashPayment",
                        fields: {
                            'UrgExist': { type: 'boolean' },
                            'CashPaymentState': { type: 'string' },
                            'CashDocNumber': { type: 'string' },
                            'ACC': { type: 'number' },
                            'PersSurname': { type: 'string' },
                            'PersName': { type: 'string' },
                            'DatePaymentPickup': { type: 'date' },
                            'AmountPickup': { type: 'number' },
                            'AmountSended': { type: 'number' },
                            'Sended': { type: 'boolean' },
                            'Prepare': { type: 'boolean' },
                            'PODateSent': { type: 'date' },
                            'DatePaymentOnCentrale': { type: 'date' },
                            'Amount': { type: 'number' },
                            'IDPaymentOrder': { type: 'number' },
                            'Color': { type: 'string' },
                        }
                    }
                },
                //serverPaging: true,
                //serverSorting: true,
                //serverFiltering: true,
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_CashBook", "Api/Service")",
                        dataType: "json",
                    },
                    parameterMap: function (options, type) {
                        var pm = kendo.data.transports.odata.parameterMap(options);
                        if(pm.$filter){
                            pm.$filter = pm.$filter.replace("eq ''", "eq null");
                        }
                        return pm;
                    }
                }
            }),
            sp_Get_CashBook_clearFilter: function (e) {
                this.sp_Get_CashBook.filter({})
            },
            sp_Get_CashBook_dataBound: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var rows = e.sender.tbody.find("tr");
                rows.each(function () {
                    var di = grid.dataItem($(this));
                    if (di) {
                        $(this).css("background", di.Color);
                        $(this).attr("data-id", di.IDCashPayment);
                    }
                });

                var row = e.sender.tbody.find("tr:first");
                if (this.sp_Get_CashBook_Selected) {
                    row = e.sender.tbody.find("[data-id='" + this.sp_Get_CashBook_Selected + "']");
                }
                if (row.length > 0) {
                    grid.content.scrollTop(row.position().top)
                }

                var data = this.get("sp_Get_CashBook").view();
                var arr = $.grep(data, function (a) {
                    return a.rr_CashPaymState === 1;
                });
                this.set("bulkPrint_visible", (arr.length > 0));
            },
            AmountSendedChange: function (e) {
                var that = this;
                $.get("@Url.Action("sp_Do_ChangeCashAmountSended", "Api/Service")", { IDCashPayment: e.data.IDCashPayment, AmountSended: e.data.AmountSended }, function (result) {
                    that.set("sp_Get_CashBook_Selected", e.data.IDCashPayment);
                    that.sp_Get_CashBook.read();
                    that.sp_Get_CashSUM.read();
                })
            },
            SendedChange: function (e) {
                var Sended = $(e.currentTarget).is(':checked');
                var that = this;

                if (Sended) {
                    e.data.set("AmountSended", e.data.AmountPickup);
                };

                $.get("@Url.Action("sp_Do_CashCheck", "Api/Service")", { IDCashPayment: e.data.IDCashPayment, Sended: Sended }, function (result) {
                    that.set("sp_Get_CashBook_Selected", e.data.IDCashPayment);
                    that.sp_Get_CashBook.read();
                    that.sp_Get_CashSUM.read();
                })
            },
            PrepareChange: function (e) {
                var Prepare = $(e.currentTarget).is(':checked');
                var that = this;
                $.get("@Url.Action("sp_Do_CashAmountSended", "Api/Service")", { IDCashPayment: e.data.IDCashPayment, AmountSended: e.data.AmountSended, Check: Prepare }, function (result) {
                    that.set("sp_Get_CashBook_Selected", e.data.IDCashPayment);
                    that.sp_Get_CashBook.read();
                    that.sp_Get_CashSUM.read();
                })
            },
            bulkPrint_visible: false,
            bulkPrint: function (e) {
                var that = this;
                $.get("@Url.Action("sp_Do_OnePaymentOrder", "Api/Service")", null, function (result) {
                    that.sp_Get_CashBook.read();
                    that.sp_Get_CashSUM.read();
                    if (result > 0) {
                        var win = window.open("@Url.Action("BulkCommand", "Home")" + "?NewIDPaymentOrder=" + result, '_blank');
                        win.focus();
                    }
                })
            },
            bulkShow: function (e) {
                var win = window.open("@Url.Action("BulkCommand", "Home")" + "?NewIDPaymentOrder=" + e.data.IDPaymentOrder, '_blank');
                win.focus();
            },
            CashInvoice: function (e) {
                var win = window.open("@Url.Action("CashInvoice", "Base")" + "?ID=" + e.data.IDUser + "&IDMonthBilling=" + e.data.IDMonthBilling, '_blank');
                win.focus();
            },
            sp_Get_ListUserFee: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDFree",
                        fields: {
                            'IDFree': { type: 'number' },
                            'ACC': { type: 'number' },
                            'TypeFreeTxt': { type: 'string' },
                            'PaymentDate': { type: 'date' },
                            'PersName': { type: 'string' },
                            'PersSurname': { type: 'string' },
                            'CreditorAlias': { type: 'string' },
                            'DateOnCentrale': { type: 'date' },
                            'DateCreated': { type: 'date' },
                            'Base': { type: 'number' },
                            'PercentFree': { type: 'number' },
                            'Free': { type: 'number' },
                            'SVApproved': { type: 'boolean' },
                            'IDMonthBilling': { type: 'number' },
                            'MonthPeriod': { type: 'string' }
                        }
                    }
                },
                //serverPaging: true,
                //serverSorting: true,
                //serverFiltering: true,
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_ListUserFee", "Api/Service")",
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
            sp_Get_ListUserFee_clearFilter: function (e) {
                this.sp_Get_ListUserFee.filter({});
            },
            sp_Get_ListUserFee_dataBound: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var rows = e.sender.tbody.find("tr");
                rows.each(function () {
                    var di = grid.dataItem($(this));
                    $(this).attr("data-id", di.IDFree);
                });
            },
            sp_Get_CashSUM: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "Ord",
                        fields: {
                            'SumToSent': { type: 'number' },
                            'Title': { type: 'string' }
                        }
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_CashSUM", "Api/Service")",
                        dataType: "json",
                    }
                }
            }),
            sp_Get_CashSUM_DataBound: function (e) {
                var grid = $(e.sender.element).data("kendoGrid");
                var rows = e.sender.tbody.find("tr");
                rows.each(function (i) {
                    var cell = $(this).find("td:first");
                    if (i === 0) {
                        cell.css("background", "rgb(249, 209, 215)");
                    } else if (i === 1) {
                        cell.css("background", "rgb(247, 245, 215)");
                    } else if (i === 2) {
                        cell.css("background", "rgb(189, 237, 175)");
                    } else {
                        cell.css("background", "rgb(255, 255, 255)");
                    }
                });
            },
            sp_Get_ListUrgCashPayments: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDUrgency",
                        fields: {
                            'IDSpisu': { type: 'number' },
                            'ACC': { type: 'string' },
                            'Txt': { type: 'string' }
                        }
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_ListUrgCashPayments", "Api/Service")",
                        dataType: "json",
                    }
                }
            }),
            sp_Get_ListBilling: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "IDMonthBilling",
                        fields: {
                            'DateBilling': { type: 'date' },
                            'DateOnCentrale': { type: 'date' },
                            'MonthPeriod': { type: 'string' },
                            'SumAmount': { type: 'number' }
                        }
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_ListBilling", "Api/Service")",
                        dataType: "json",
                    }
                }
            }),
            sp_Get_NotYetBilling: new kendo.data.DataSource({
                schema: {
                    total: "Total",
                    data: "Data",
                    model: {
                        id: "NotYetBilling",
                        fields: {
                            'NotYetBilling': { type: 'number' }
                        }
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get_NotYetBilling", "Api/Service")",
                        dataType: "json",
                    }
                }
            })
        });
        kendo.bind($("#body"), viewModel);
    });
</script>

