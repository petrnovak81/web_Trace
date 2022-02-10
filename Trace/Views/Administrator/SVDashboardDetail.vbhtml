@Code
    ViewData("Title") = "Dashboard detail"
    Layout = "~/Views/Shared/_AdminLayout.vbhtml"
End Code

<style>
    .k-grid td.k-detail-cell {
    padding: 0;
}

    .k-grid td.k-detail-cell .k-grid-header {
        display: none;
    }

    #dashboarddetail > * {
        position:absolute; /*it can be fixed too*/
        left:0; right:0;
        margin:auto;
    }
</style>

<div id="dashboarddetail" class="k-content">
     @Html.Partial("~/Views/Objects/" & ViewData("Partial") & ".vbhtml")
</div>

<script>
    $(function () {
        var viewModel = new kendo.observable({
            sp_DSHB_1_1: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_1", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_1_Detail: function (e) {
                var that = this;
                var model = new kendo.observable({
                    sp_DSHB_1_1_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_1_Detail", "Api/AdminService")"
                        }
                    }),
                    sp_DSHB_1_1_select: function (e) {
                        var g = $(e.sender.element).data("kendoGrid");
                        var di = g.dataItem(g.select());
                        if (di) {
                            var data = [{
                                "New": di.New,
                                "Vracene": di.Vracene,
                                "Visits": di.Visits,
                                "Agreements": di.Agreements,
                                "ToProcess": di.ToProcess,
                                "Closed": di.Closed
                            }]
                            that.sp_DSHB_1_1_chart.data(data)
                        }
                    }
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_1_select: function (e) {
                var g = $(e.sender.element).data("kendoGrid");
                var di = g.dataItem(g.select());
                if (di) {
                    var data = [{
                        "New": di.New,
                        "Vracene": di.Vracene,
                        "Visits": di.Visits,
                        "Agreements": di.Agreements,
                        "ToProcess": di.ToProcess,
                        "Closed": di.Closed
                    }]
                    this.sp_DSHB_1_1_chart.data(data)
                }
            },
            sp_DSHB_1_1_chart: new kendo.data.DataSource({
                schema: {
                    model: {
                        fields: {
                            New: { type: "number" },
                            Vracene: { type: "number" },
                            Visits: { type: "number" },
                            Agreements: { type: "number" },
                            ToProcess: { type: "number" },
                            Closed: { type: "number" }
                        }
                    }
                },
                data: []
            }),
            sp_DSHB_1_2_iDUser: 0,
            sp_DSHB_1_2: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_2", "Api/AdminService")",
                    parameterMap: function (options, type) {
                        return { iDUser: viewModel.sp_DSHB_1_2_iDUser };
                    }
                }
            }),
            sp_DSHB_1_3: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_3", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_3_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var model = new kendo.observable({
                    sp_DSHB_1_3_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_3_Detail", "Api/AdminService")",
                            parameterMap: function (options, type) {
                                return { Poradi: di.IDValue };
                            }
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_4: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_4", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_4_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var model = new kendo.observable({
                    sp_DSHB_1_4_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_4_Detail", "Api/AdminService")",
                            parameterMap: function (options, type) {
                                return { iDUser: di.IDUser };
                            }
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_5: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_5", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_6: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_6", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_7: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_7", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_7_Detail: function (e) {
                var model = new kendo.observable({
                    sp_DSHB_1_7_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_7_Detail", "Api/AdminService")",
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_8: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_8", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_8_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var model = new kendo.observable({
                    sp_DSHB_1_8_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_8_Detail", "Api/AdminService")",
                            parameterMap: function (options, type) {
                                return { iDOrder: di.IDOrder };
                            }
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_9: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_9", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_9_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var url = "";
                if (di.IDOrder === 1) {
                    url = "@Url.Action("sp_DSHB_1_9_Detail_1", "Api/AdminService")";
                } else {
                    url = "@Url.Action("sp_DSHB_1_9_Detail_2", "Api/AdminService")";
                };
                var model = new kendo.observable({
                    sp_DSHB_1_9_Detail: new kendo.data.DataSource({
                        transport: {
                            read: url
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_10: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_10", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_10_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var model = new kendo.observable({
                    sp_DSHB_1_10_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_10_Detail", "Api/AdminService")",
                            parameterMap: function (options, type) {
                                return { IDUser: di.IDUser };
                            }
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_11: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_11", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_11_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var model = new kendo.observable({
                    sp_DSHB_1_11_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_11_Detail", "Api/AdminService")",
                            parameterMap: function (options, type) {
                                return { month: di.BillingMonth, year: di.BillingYear };
                            }
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_12: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_12", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_12_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var model = new kendo.observable({
                    sp_DSHB_1_12_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_12_Detail", "Api/AdminService")",
                            parameterMap: function (options, type) {
                                return { id: di.IDUser };
                            }
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_13: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_13", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_13_Detail: function (e) {
                var model = new kendo.observable({
                    sp_DSHB_1_13_Detail: new kendo.data.DataSource({
                        transport: {
                            read: "@Url.Action("sp_DSHB_1_13_Detail", "Api/AdminService")"
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            },
            sp_DSHB_1_14: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("sp_DSHB_1_14", "Api/AdminService")"
                }
            }),
            sp_DSHB_1_14_Detail: function (e) {
                var di = e.sender.dataItem(e.masterRow);
                var url = "";
                switch (di.IDValue) {
                    case 1:
                        url = "@Url.Action("sp_DSHB_1_14_Detail1", "Api/AdminService")";
                        break;
                    case 2:
                        url = "@Url.Action("sp_DSHB_1_14_Detail2", "Api/AdminService")";
                        break;
                    case 3:
                        url = "@Url.Action("sp_DSHB_1_14_Detail3", "Api/AdminService")";
                        break;
                    case 4:
                        url = "@Url.Action("sp_DSHB_1_14_Detail4", "Api/AdminService")";
                        break;
                }
                console.log(url)
                var model = new kendo.observable({
                    sp_DSHB_1_14_Detail: new kendo.data.DataSource({
                        transport: {
                            read: url
                        }
                    })
                })
                kendo.bind(e.detailCell, model);
            }
        })
        kendo.bind($("#dashboarddetail"), viewModel);

        $("#accountSelect").kendoDropDownList({
            optionLabel: 'Vyberte inspektora...',
            dataTextField: 'text',
            dataValueField: 'value',
            dataSource: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Action("GetInspectors", "Api/AdminService")",
                    type: "json"
                }
            }),
            change: function (e) {
                var IDUser = e.sender.value();
                if (!IDUser) {
                    viewModel.set("sp_DSHB_1_2_iDUser", 0);
                } else {
                    viewModel.set("sp_DSHB_1_2_iDUser", IDUser);
                }
                viewModel.sp_DSHB_1_2.read();
            }
        });
    })
</script>