Spisy: new kendo.data.DataSource({
    schema: {
        total: "Total",
        data: "Data",
        model: {
            id: "IDSpisu",
            fields: {
                'AlertExist': { type: 'number' },
                'ACC': { type: 'number' },
                'PersSurname': { type: 'string' },
                'PersName': { type: 'string' },
                'PersRC': { type: 'string' },
                'PersIC': { type: 'string' },
                'PersBirthDate': { type: 'date' },
                'CreditorAlias': { type: 'string' },
                'ActualDebit': { type: 'number' },
                'PersRegion': { type: 'string' },
                'PersCity': { type: 'string' },
                'PersStreet': { type: 'string' },
                'PersHouseNum': { type: 'string' },
                'PersZipCode': { type: 'string' },
                'StateTxt': { type: 'string' },
                'NextPaymentDate': { type: 'date' },
                'NextPaymentAmountAwait': { type: 'number' },
                'LastPaymentDate': { type: 'date' },
                'LastPaymentAmountReal': { type: 'number' },
                'DateReturnToCreditor': { type: 'date' },
                'DateLapse': { type: 'date' },
                'GPSValid': { type: 'boolean' },
                'PersPhone': { type: 'string' },
                'ValidityTypeTxt': { type: 'string' },
                'DebtLastOSN': { type: 'date' }, //Poslední návštěva
                'DebtLastContact': { type: 'date' }, //Poslední kontakt s dlužníkem
            }
        }
    },
    serverPaging: true,
    serverSorting: true,
    serverFiltering: false,
    noRecords: true,
    transport: {
        read: {
            url: Spisy,
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
                message(msg, e.response.MsgType);
            }
        }
    }
}),
Spisy_dataBound: function (e) {
    var grid = $(e.sender.element).data("kendoGrid");
    var allRows = e.sender.tbody.find("tr");
    allRows.each(function(){
        var di = grid.dataItem($(this));
        if (di.rr_State > 39 && di.rr_State < 50) {
            $(this).addClass("green-row");
        }
        $(this).attr("data-id", di.IDSpisu);
    })
    var row = e.sender.tbody.find("tr:first");
    if(urlID) {
        row = e.sender.tbody.find("[data-id='" + urlID + "']");
    }
    if (this.Spisy_visible && row.length > 0) {
        grid.select(row);
        grid.content.scrollTop($(row).position().top);
    }
    $('#a1_header-chb').prop("checked", false);
    $('#a1_header-chb').change(function (ev) {
        var checked = ev.target.checked;
        if (checked) {
            $('#Spisy .checkrow').prop('checked', true);
        } else {
            $('#Spisy .checkrow').prop('checked', false);
        };
        $('#Spisy .checkrow').change();
    });
    if(e.sender.dataSource.total() === 0) {
        this.set("B3_Visible", false);
    };
    btnEnebleChange(0, 0, 0, this);
},
Spisy_change: function (e) {
    var g = $(e.sender.element).data("kendoGrid");
    var di = g.dataItem(g.select());
    if (di) {
        urlID = di.IDSpisu;
        localStorage.setItem('lastid_dohody', di.IDSpisu);
        this.B3_Filter(di.IDSpisu, di.IDSpisyOsoby, 0);
    }
},
selectRow: function(e) {
    var checked = $(e.currentTarget).prop("checked"),
        row = $(e.currentTarget).closest("tr");
    var l = $('#Spisy .checkrow:checked').length; //vybranych radku
    var t = this.Spisy.data().length; //celkem zobrazenych zaznamu
    if (l !== t) {
        $('#a1_header-chb').prop("checked", false);
    } else {
        $('#a1_header-chb').prop("checked", true);
    }
    btnEnebleChange(+(l === 0), +(l === 1), +(l > 1), this);
},