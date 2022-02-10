SpisyDL: new kendo.data.DataSource({
    schema: {
        total: "Total",
        data: "Data",
        model: {
            id: "IDSpisyOsoby",
            fields: {
                'AlertExist': { type: 'number' },
                'PersSurname': { type: 'string' },
                'PersName': { type: 'string' },
                'PersRC': { type: 'string' },
                'PersIC': { type: 'string' },
                'PersBirthDate': { type: 'date' },
                'PersRegion': { type: 'string' },
                'PersCity': { type: 'string' },
                'PersStreet': { type: 'string' },
                'PersHouseNum': { type: 'string' },
                'PersZipCode': { type: 'string' },
                'GPSValid': { type: 'boolean' }
            }
        }
    },
    serverPaging: true,
    serverSorting: true,
    serverFiltering: false,
    noRecords: true,
    transport: {
        read: {
            url: SpisyDL,
            dataType: "json",
        },
        parameterMap: function (options, type) {
            var pm = kendo.data.transports.odata.parameterMap(options);
            if(pm.$filter){
                pm.$filter = pm.$filter.replace("eq ''", "eq null");
            }
            return pm;
        }
    },
    pageSize: 1000,
    requestEnd: function (e) {
        if (e.response) {
            if (e.response.MsgType === 'error') {
                var msg = "<span style='margin-left:6px;'>" + e.response.Msg.join("<br>") + "</span>"
                console.log("SpisyDL requestEnd Error")
                message(msg, e.response.MsgType);
            }
        }
    }
}),
    SpisyDL_dataBound: function (e) {
        var grid = $(e.sender.element).data("kendoGrid");
        var allRows = e.sender.tbody.find("tr");
        allRows.each(function () {
            var di = grid.dataItem($(this));
            $(this).attr("data-id", di.IDSpisyOsoby);
        })
        var row = e.sender.tbody.find("tr:first");
        if (dlID) {
            row = e.sender.tbody.find("[data-id='" + dlID + "']");
        }
        if (this.SpisyDL_visible) {
            grid.select(row);
        }
    },
SpisyDL_change: function (e) {
    var g = $(e.sender.element).data("kendoGrid");
    var di = g.dataItem(g.select());
    if (di) {
        dlID = di.IDSpisyOsoby;
        this.B3_Filter(0, di.IDSpisyOsoby, 0);
    }
    $.each($(".k-detail-cell > .k-grid"), function(){
        var grid = $(this).data("kendoGrid");
        if($(this)[0].id && $(e.sender.element)[0].id){
            if($(e.sender.element)[0].id !== $(this)[0].id){
                grid.clearSelection();
            };
        };
    });
    btnEnebleChange(0, 0, 0, this);
},