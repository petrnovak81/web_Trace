@Code
    ViewData("Title") = Language.layoutmasTXT9
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<style>
    #ReminderSplitter {
            display: -webkit-box;
            display: -moz-box;
            display: -ms-flexbox;
            display: -webkit-flex;
            display: flex;
            flex-direction: column;
            flex: auto;
        }

        #splitter {
            flex: auto;
        }
</style>

<div id="ReminderSplitter">
    <ul id="filtermenu" data-role="menu" style="border-top: 1px solid">
        <li data-typefilter="1" data-bind="events: { click: clearFilter }" class="k-state-selected">@Html.Raw(Language.ReminderTXT1)</li>
        <li data-typefilter="2">@Html.Raw(Language.ReminderTXT2)
            <ul>
                <li data-datefilter="1" data-datetext="@Html.Raw(Language.ReminderTXT3)" data-bind="events: { click: dateFilter_click }">@Html.Raw(Language.ReminderTXT3) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                <li data-datefilter="2" data-datetext="@Html.Raw(Language.ReminderTXT4)" data-bind="events: { click: dateFilter_click }">@Html.Raw(Language.ReminderTXT4) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                <li data-datefilter="3" data-datetext="@Html.Raw(Language.ReminderTXT5)" data-bind="events: { click: dateFilter_click }">@Html.Raw(Language.ReminderTXT5) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                <li data-datefilter="4" data-datetext="@Html.Raw(Language.ReminderTXT6)" data-bind="events: { click: dateFilter_click }">@Html.Raw(Language.ReminderTXT6) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                <li data-datefilter="5" data-datetext="@Html.Raw(Language.ReminderTXT7)" data-bind="events: { click: dateFilter_click }">@Html.Raw(Language.ReminderTXT7) <span class="k-icon k-i-filter" style="display:none;"></span></li>
                <li data-datefilter="6" data-datetext="@Html.Raw(Language.ReminderTXT7)" data-bind="events: { click: dateFilter_click }">@Html.Raw(Language.ReminderTXT8) <span class="k-icon k-i-filter" style="display:none;"></span></li>
            </ul>
        </li>
        <li data-typefilter="3" data-bind="events: { click: typefilter_click }">@Html.Raw(Language.ReminderTXT9)</li>
        <li data-typefilter="4" data-bind="events: { click: typefilter_click }">@Html.Raw(Language.ReminderTXT10)</li>
        <li data-bind="events: { click: clearFilter }"><span class="k-icon k-i-filter-clear"></span></li>
    </ul>

    <div id="splitter"
        data-role="splitter"
        data-bind="events: { expand: onExpand, collapse: onCollapse, resize: onResize }"
        data-panes="[
     { collapsible: false, min: '300px', scrollable: false },
     { collapsible: false, min: '200px', scrollable: true, resizable: false, size: '200px' }
     ]">
        <div>
            @Html.Partial("~/Views/Objects/vw_AllUrgRemindMsg.vbhtml")
        </div>
        <div class="actionbuttons">
            <button class="k-button" style="width:100%" data-bind="events: { click: newUpoSpis }">@Html.Raw(Language.ReminderTXT11)</button>
            <button class="k-button" style="width:100%" data-bind="events: { click: newUpoDl }">@Html.Raw(Language.ReminderTXT12)</button>
        </div>
    </div>
</div>

@Html.Partial("~/Views/Objects/IPVytvoreniUpominky.vbhtml")
@Html.Partial("~/Views/Objects/ProgressBarDialog.vbhtml")

<script>
    var viewModel = kendo.observable({
        Source: new kendo.data.DataSource({
            schema: {
                total: "Total",
                data: "Data",
                model: {
                    id: "IDRadku",
                    fields: {
                        "DeadLine": { type: "date" },
                        "Title": { type: "string" },
                        "Body": { type: "string" },
                        "Jmeno": { type: "string" },
                        "ACC": { type: "string" },
                        "CreatedDate": { type: "date" },
                        "Zadavatel": { type: "string" }
                    }
                }
            },
            serverPaging: true,
            serverSorting: true,
            serverFiltering: true,
            pageSize: 100,
            sort: {
                field: "DeadLine",
                dir: "desc"
            },
            transport: {
                read: {
                    url: "@Url.Action("vw_AllUrgRemindMsg", "Api/Service")",
                    dataType: "json"
                },
                parameterMap: function (options, type) {
                    var pm = kendo.data.transports.odata.parameterMap(options);
                    if(pm.$filter){
                        pm.$filter = pm.$filter.replace("eq ''", "eq null");
                    }
                    pm.type = viewModel.typeFilter;
                    pm.date = viewModel.dateFilter;
                    return pm;
                }
            }
        }),
        dateText: "@Html.Raw(Language.ReminderTXT8)",
        dateFilter: 0,
        typeFilter: 1,
        typefilter_click: function(e) {
            var target = $(e.currentTarget);
            $("#filtermenu li").removeClass("k-state-selected");
            target.addClass("k-state-selected");
            this.set("typeFilter", parseInt(target.data("typefilter")));
            this.set("dateFilter", 0);
            this.set("dateText", "@Html.Raw(Language.ReminderTXT8)");
            this.Source.sort({});
            this.Source.filter({});
            this.Source.read();
        },
        dateFilter_click: function (e) {
            $(e.currentTarget).closest("ul[data-role='menu']").find("li ul .k-icon").hide();
            $(e.currentTarget).find(".k-icon").show();

            $("#filtermenu li").removeClass("k-state-selected");
            $(e.currentTarget).closest("ul").closest("li").addClass("k-state-selected");

            var target = $(e.currentTarget);
            this.set("typeFilter", 2);
            this.set("dateFilter", parseInt(target.data("datefilter")));
            this.set("dateText", target.data("datetext"));
            this.Source.sort({});
            this.Source.filter({});
            this.Source.read();
        },
        clearFilter: function (e) {
            $(e.currentTarget).closest("ul[data-role='menu']").find("li ul .k-icon").hide();
            $("#filtermenu li").removeClass("k-state-selected");
            $("#filtermenu li:first-child").addClass("k-state-selected");
            this.set("typeFilter", 1);
            this.set("dateFilter", 0);
            this.set("dateText", "@Html.Raw(Language.ReminderTXT8)");
            this.Source.sort({});
            this.Source.filter({});
        },
        DataBound: function (e) {
            var grid = $(e.sender.element).data("kendoGrid");
            var allRows = e.sender.tbody.find("tr");
            allRows.each(function(){
                var di = grid.dataItem($(this));
                var td = $(this).find("td:first-child")
                if (di.Type === "U") {
                    td.append('<i style="color: rgb(158, 43, 17);text-shadow: -1px 0 #fff, 0 1px #fff, 1px 0 #fff, 0 -1px #fff;" class="fa fa-bell" aria-hidden="true"></i>');
                }
                if (di.Type === "R") {
                    td.append('<i style="color: rgb(255, 210, 70);text-shadow: -1px 0 #fff, 0 1px #fff, 1px 0 #fff, 0 -1px #fff;" class="fa fa-bell" aria-hidden="true"></i>');
                }
                if (di.Type === "M") {
                    td.append('<i style="color: rgb(120, 210, 55);text-shadow: -1px 0 #fff, 0 1px #fff, 1px 0 #fff, 0 -1px #fff;" class="fa fa-bell" aria-hidden="true"></i>');
                }
            })
            setTimeout(function () {
                kendo.resize($('#splitter'));
            }, 500);
        },
        DeleteRecord: function(e) {
            var model = this;
            $.get('@Url.Action("sp_Do_DoneOneReminder", "Api/Service")', { iDSpisu: e.data.IDCase, iDReminder: e.data.ID }, function (result) {
                model.Source.read();
            });
        },
        newUpoSpis: function(e) {
            var model = this;
            IPVytvoreniUpominky(1, null, function (promises) {
                total = promises.length;
                if (promises) {
                    progress(promises, total, function (e) {
                        model.Source.read();
                    });
                }
            })
        },
        newUpoDl: function(e) {
            var model = this;
            IPVytvoreniUpominky(2, null, function (promises) {
                total = promises.length;
                if (promises) {
                    progress(promises, total, function (e) {
                        model.Source.read();
                    });
                }
            })
        },
        ACCLink: function (e) {
            var id = e.IDCase;
            var state = e.rr_State;
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
                return ""
            };
        }
    })

    function progress(promises, total, callback) {
        var counter = 0;
        var value = 0;
        winProgressBarDialog.open().center();
        $.when.apply(null, promises).progress(function () {
            counter++
            value = parseFloat(parseInt(counter, 10) * 100) / parseInt(total, 10);
            progressModel.set("progressValue", value);
        }).done(function () {
            callback(true);
        });
    }

    $(function(){
        kendo.bind($("#ReminderSplitter"), viewModel);
    })
   
</script>