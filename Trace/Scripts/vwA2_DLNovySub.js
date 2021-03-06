SpisyDL_detailInit: function (e) {
    var parentModel = this;
    var dataItem = $(e.sender.element).data("kendoGrid").dataItem(e.masterRow);
    var detailModel = kendo.observable({
        SpisyDLSub: new kendo.data.DataSource({
            schema: {
                total: "Total",
                data: "Data",
                model: {
                    id: "IDSpisu",
                    fields: {
                        'AlertExist': { type: 'number' },
                        'ACC': { type: 'number' },
                        'CreditorAlias': { type: 'string' },
                        'ActualDebit': { type: 'number' },
                        'StateTxt': { type: 'string' },
                        'VisitDateSentFromMother': { type: 'date' },
                        'VisitDatePlan': { type: 'date' },
                        'DMAX': { type: 'date' }
                    }
                }
            },
            serverPaging: true,
            serverSorting: true,
            serverFiltering: false,
            noRecords: true,
            transport: {
                read: {
                    url: SpisyDLSub,
                    dataType: "json",
                },
                parameterMap: function (options, type) {
                    var pm = kendo.data.transports.odata.parameterMap(options);
                    return { options: pm, IDSpisyOsoby: dataItem.IDSpisyOsoby };
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
        SpisyDLSub_change: function (e) {
            var g = $(e.sender.element).data("kendoGrid");
            var di = g.dataItem(g.select());
            if (di) {
                $(e.sender.element).closest("#SpisyDL").find("tr").not(".k-detail-row tr").removeClass("k-state-selected");
                parentModel.B3_Filter(di.IDSpisu, di.IDSpisyOsoby, 0);

                $.each($(".k-detail-cell > .k-grid"), function(){
                    var grid = $(this).data("kendoGrid");
                    if($(this)[0].id && $(e.sender.element)[0].id){
                        if($(e.sender.element)[0].id !== $(this)[0].id){
                            grid.clearSelection();
                        };
                    };
                });
            };
            if(di) {
                if(di.rr_State > 9 && di.rr_State < 20) {
                    btnEnebleChange(0, 1, 0, parentModel);
                } else {
                    btnEnebleChange(0, 0, 0, parentModel);
                }
            }
        },
        SpisyDLSub_dataBound:function(e) {
            var grid = $(e.sender.element).data("kendoGrid");
            var allRows = e.sender.tbody.find("tr");
            allRows.each(function(){
                var di = grid.dataItem($(this));
                if (di.rr_State > 9 && di.rr_State < 20) {
                    $(this).addClass("red-row");
                }
                $(this).attr("data-id", di.IDSpisu);
            });
            if(urlID) {
                var row = e.sender.tbody.find("[data-id='" + urlID + "']");
                grid.select(row);
            } else {
                grid.select(allRows[0]);
            }
        },
        rowHref: function(e) {
            var id = e.IDSpisu;
            var state = e.rr_State;
            if (state > 9 && state < 20) {
                return "News?id=" + id;
            } else if(state > 29 && state < 40) {
                return "PersonalVisit?id=" + id;
            } else if(state > 39 && state < 50) {
                return "Agreements?id=" + id;
            } else if(state > 49 && state < 60) {
                return "ToProcess?id=" + id;
            } else {
                return ""
            };
        },
        btnDateOSNPlan: function (e) {
            var model = this;
            var grid = $(e.currentTarget).closest(".k-grid").data("kendoGrid");
            var row = $(e.currentTarget).closest("tr");
            var view = this.SpisyDLSub.view();
            grid.select(row);
            showOSNDatePlan(e.data.VisitDatePlan, e.data.DMAX, false, function (date, nochange) {
                DatePlanProcess([e.data], date, nochange, function(result) {
                    urlID = e.data.IDSpisu; 
                    $.get(apiUrl + "vwA2_DLNovySubPodleIDSpisyOsoby", {IDSpisyOsoby: e.data.IDSpisyOsoby}, function(result){
                        $.each(result.Data, function(a, b) {
                            var item = model.SpisyDLSub.get(b.IDSpisu);
                            item.set("AlertExist", b.AlertExist);
                            item.set("VisitDatePlan", b.VisitDatePlan);
                        });
                    });
                });
            });
        }
    });
    initDLNovySub(dataItem.uid);
    kendo.bind(e.detailCell, detailModel);
},