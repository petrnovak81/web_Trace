var CellNull = "<div class='null'></div>";

function uniq() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
      s4() + '-' + s4() + s4() + s4();
}

function isEmail(e) {
    var pattern = new RegExp("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
    return pattern.test(e);
};

function isUrl(e) {
    var pattern = /^(http|https|ftp):\/\/[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/i
    return pattern.test(e);
}

function parseJsonDate(value) {
    if (value) {
        return new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
    } else {
        return value
    }
};

function planeCalendar(stateok, field) {
    if (stateok) {
        return '<a data-bind="events: { click: btnDateOSNPlan }" href="#"><i class="fa fa-calendar-plus-o"></i> <span data-bind="date: ' + field + '"></span></a>';
    } else {
        return '<span data-bind="date: ' + field + '"></span>'
    }
};

function CellDetectType(value) {
    var type = jQuery.type(value)
    if (isEmail(value)) {
        return CellEmail(value);
    }
    if (isUrl(value)) {
        return CellLink(value);
    }
    switch (type) {
        case "boolean":
            return CellBool(value);
        case "number":
            return CellInt(value);
        case "date":
            return CellDate(value);
        case "null":
            return CellNull;
        default:
            return CellString(value);
    }
};

function fileSize(size) {
    var i = Math.floor(Math.log(size) / Math.log(1024));
    return (size / Math.pow(1024, i)).toFixed(2) * 1 + ' ' + ['B', 'kB', 'MB', 'GB', 'TB'][i];
};

function traceradio(uid, ids, id, tbl, val) {
    return "<input type='radio' " + (val ? "checked" : "") + " data-spis='" + ids + "' data-id='" + id + "' data-tbl='" + tbl + "' name='traceplaneradio' data-bind='events: { change: traceplaneradio }' id='r-" + uid + "' class='k-radio'><label class='k-radio-label' for='r-" + uid + "'></label>";
}

function getText(matchValue, valuesArray, text, value) {
    if (text === undefined) {
        text = 'text';
    }

    if (value === undefined) {
        value = 'value';
    }

    var retText = "No Value Found";

    var finalArr = $.grep(valuesArray, function (val, integer) {
        return val[value] == matchValue;
    });

    if (finalArr.length > 0) {
        retText = finalArr[0].text;
    }

    return retText;
};

function rotateHeaderTemplate(text, title) {
    return '<svg width="100%" height="100%" version="1.1" xmlns="http://www.w3.org/2000/svg"><text transform="rotate(90)">' + text + '</text></svg>'
}

function headerTemplate(text, title) {
    if (!title) {
        title = text;
    };
    return "<div title='" + text + "'>" + text + "</div>"
}

    function CellRaw(value) {
        if (value) {
            return value;
        } else {
            return "";
        }
    };

    function CellString(value) {
        if (value) {
            return "<div class='cellString' title='" + value + "'>" + value + "</div>";
        } else {
            return CellNull;
        };
    };

    function CellInt(value, align) {
        if (!align) { align = "right"; }
        if (value) {
            var v = kendo.toString(parseInt(value), "n0");
            return "<div class='cellInteger' style='text-align: " + align + "' title='" + v + "'>" + v + "</div>";
        } else {
            return CellNull;
        };
    };

    function CellPercentage(value) {
        if (value) {
            var v = kendo.toString(parseInt(value), "n1") + " %";
            return "<div style='text-align: right' title='" + v + "'>" + v + "</div>";
        } else {
            return CellNull;
        };
    };

    function CellDouble(value, uid) {
        if (value) {
            var v = kendo.toString(parseFloat(value), "n2");
            return "<div class='cellDouble' style='text-align: right' title='" + v + "'>" + v + "</div>";
        } else {
            return CellNull;
        };
    };

    //function HeaderSelect() {
    //    var id = uniq();
    //    return '<input type="checkbox" data-param="' + param + '" id="select-' + id + '" class="k-checkbox select-row-checkbox"><label class="k-checkbox-label" for="select-' + id + '"></label>';
    //}

    function CellSelect(param) {
        var id = uniq();
        return '<input type="checkbox" data-param="' + param + '" id="select-' + id + '" class="k-checkbox select-row-checkbox"><label class="k-checkbox-label" for="select-' + id + '"></label>';
    };

    function CellBool(value, enabled) {
        var id = uniq();
        return '<div style="text-align: center"><input type="checkbox" ' + (enabled ? '' : 'disabled') + ' id="' + id + '" value="' + value + '" class="k-checkbox"' + (value ? 'checked="checked"' : '') + '><label class="k-checkbox-label" for="' + id + '"></label></div>';
    };

    function CellDateTime(value) {
        if (value) {
            var obj = new Date(value);
            var d = kendo.toString(obj, "d").replace(/ /g, "");
            var t = kendo.toString(obj, "t").replace(/ /g, "");
            var v = d + " " + t;
            return "<div title='" + v + "' style='text-align: right'>" + v + "</div>";
        } else {
            return CellNull;
        };
    };

    function CellDate(value) {
        if (value) {
            var obj = new Date(value);
            var v = kendo.toString(obj, "d").replace(/ /g, "");
            return "<div title='" + v + "' style='text-align: right'>" + v + "</div>";
        } else {
            return CellNull;
        };
    };

    function CellTime(value) {
        if (value) {
            var obj = new Date(value);
            var v = kendo.toString(obj, "t").replace(/ /g, "");
            return "<div title='" + v + "' style='text-align: right'>" + v + "</div>";
        } else {
            return CellNull;
        };
    };

    function CellZip(value, mask) {
        try {
            if (value) {
                value = value.replace(/ /g, "");
                if (!mask) {
                    mask = "000 00";
                };
                var v = $("<input />").kendoMaskedTextBox({
                    mask: mask,
                    value: parseInt(value)
                });
                v = v[0].value.replace(/[()\s-_]/g, " ");
                return "<div title='" + v + "'>" + v + "</div>";
            } else {
                return CellNull;
            };
        } catch (ex) {
            console.log(ex)
            return "<div title='" + value + "'>" + value + "</div>";
        }
    };

    function CellLink(value, target) {
        if (value) {
            if (target) {
                return '<a href="' + value + '" target="' + target + '" title="' + value + '">' + value + '</a>';
            } else {
                return '<a href="' + value + '" title="' + value + '">' + value + '</a>';
            }
        } else {
            return CellNull;
        };
    };

    function CellEmail(value, culture) {
        if (value) {
            return '<a href="mailto:' + value + '" title="' + value + '">' + value + '</a>';
        } else {
            return CellNull;
        };
    };

    function CellPhone(value, mask) {
        try {
            if (value) {
                if (!mask) {
                    mask = "000 000 000";
                };
                var v = $("<input />").kendoMaskedTextBox({
                    mask: mask,
                    value: parseInt(value)
                });
                v = v[0].value.replace(/[()\s-_]/g, " ");
                return "<div title='" + v + "'>" + v + "</div>";
            } else {
                return CellNull;
            };
        } catch (ex) {
            return "<div title='" + value + "'>" + value + "</div>";
        }
    };

    function CellRC(value, mask) {
        try {
            if (value) {
                if (!mask) {
                    mask = "000000/0000";
                };
                var v = $("<input />").kendoMaskedTextBox({
                    mask: mask,
                    value: parseInt(value)
                });
                v = v[0].value.replace(/[()\s-_]/g, " ");
                return "<div title='" + v + "'>" + v + "</div>";
            } else {
                return CellNull;
            };
        } catch (ex) {
            return "<div title='" + value + "'>" + value + "</div>";
        }
    };

    function CellMoney(value, currency, css) {
        if (value) {
            var v = kendo.toString(parseFloat(value), "n2");
            if (currency == undefined) {
                currency = "";
            }
            return "<div style='text-align: right;" + (css ? css : "") + "' title='" + v + " " + currency + "'>" + v + " " + currency + "</div>";
        } else {
            return CellNull;
        };
    };

    function CellThousand(value) {
        if (value) {
            var v = kendo.toString(value, "#,0");
            return "<div style='text-align: right' title='" + v + "'>" + v + "</div>";
        } else {
            return CellNull;
        };
    }

    //grid cmmands

    function CmdDelete() {
        return { name: "destroy", text: " ", template: "<a class='k-grid-delete' href='#'><span class='k-icon k-i-close'></span></a>" }
    };

    function CmdEdit() {
        return { name: "edit", text: " ", template: "<a class='k-grid-edit' href='#'><span class='k-icon k-i-edit'></span></a>" }
    };

    function CmdSave() {
        return { name: "update", text: " ", template: "<a class='k-grid-update' href='#'><span class='k-icon k-i-check'></span></a>" }
    };

    function CmdCancel() {
        return { name: "cancel", text: " ", template: "<a class='k-grid-cancel' href='#'><span class='k-icon k-i-cancel'></span></a>" }
    };

    //element convert bind string

    $(function () {
        kendo.data.binders.widget.max = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            },
            refresh: function () {
                var that = this,
                value = that.bindings["max"].get(); //get the value from the View-Model
                $(that.element).data("kendoNumericTextBox").max(value); //update the widget
            }
        });

        kendo.data.binders.money = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var currency = $(element).data("currency");
                if (!currency) {
                    currency = "";
                }
                this.currency = currency;
            },
            refresh: function () {
                var data = this.bindings["money"].get();
                if (data) {
                    $(this.element).text(kendo.toString(parseFloat(data), "n2") + " " + this.currency);
                } else {
                    $(this.element).text(kendo.toString(0, "n2") + " " + this.currency);
                }
            }
        });

        kendo.data.binders.zip = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var mask = $(element).data("mask");
                if (!mask) {
                    mask = "000 00";
                }
                this.mask = mask;
            },
            refresh: function () {
                var data = this.bindings["zip"].get();
                if (data) {
                    var obj = $("<input />").kendoMaskedTextBox({
                        mask: this.mask,
                        value: data
                    });
                    obj = obj[0].value.replace(/[()\s-_]/g, " ");
                    $(this.element).text(obj);
                } else {
                    $(this.element).text("");
                }
            }
        });

        kendo.data.binders.phone = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var mask = $(element).data("mask");
                if (!mask) {
                    mask = "000 000 000";
                }
                this.mask = mask;
            },
            refresh: function () {
                var data = this.bindings["phone"].get();
                if (data) {
                    var obj = $("<input />").kendoMaskedTextBox({
                        mask: this.mask,
                        value: data
                    });
                    obj = obj[0].value.replace(/[()\s-_]/g, " ");
                    $(this.element).text(obj);
                } else {
                    $(this.element).text("");
                }
            }
        });

        kendo.data.binders.rc = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var mask = $(element).data("mask");
                if (!mask) {
                    mask = "000000/0000";
                }
                this.mask = mask;
            },
            refresh: function () {
                var data = this.bindings["rc"].get();
                if (data) {
                    var obj = $("<input />").kendoMaskedTextBox({
                        mask: this.mask,
                        value: data
                    });
                    obj = obj[0].value.replace(/[()\s-_]/g, " ");
                    $(this.element).text(obj);
                } else {
                    $(this.element).text("");
                }
            }
        });

        kendo.data.binders.date = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var data = this.bindings["date"].get();
                if (data) {
                    var obj = new Date(data);
                    var d = kendo.toString(obj, "d").replace(/ /g, "");
                    $(this.element).text(d);
                } else {
                    $(this.element).text("");
                }
            }
        });

        kendo.data.binders.datetime = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var data = this.bindings["datetime"].get();
                if (data) {
                    var obj = new Date(data);
                    var d = kendo.toString(obj, "d").replace(/ /g, "");
                    var t = kendo.toString(obj, "t").replace(/ /g, "");
                    $(this.element).text(d + " " + t);
                } else {
                    $(this.element).text("");
                }
            }
        });

        kendo.data.binders.time = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var data = this.bindings["time"].get();
                if (data) {
                    var obj = new Date(data);
                    var t = kendo.toString(obj, "t").replace(/ /g, "");
                    $(this.element).text(t);
                } else {
                    $(this.element).text("");
                }
            }
        });

        kendo.data.binders.thousand = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var data = this.bindings["thousand"].get();
                if (data) {
                    var t = kendo.toString(data, "#,0");
                    $(this.element).text(t);
                } else {
                    $(this.element).text("");
                }
            }
        });

        //bind min/max datepicker

        kendo.data.binders.widget.maxdate = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            },
            refresh: function () {
                var that = this,
                    value = that.bindings["maxdate"].get(); //get the value from the View-Model
                $(that.element).data("kendoDatePicker").max(value); //update the widget
            }
        });

        kendo.data.binders.widget.maxdateinput = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            },
            refresh: function () {
                var that = this,
                    value = that.bindings["maxdateinput"].get(); //get the value from the View-Model
                $(that.element).data("kendoDateInput").max(value); //update the widget
            }
        });

        kendo.data.binders.widget.mindate = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            },
            refresh: function () {
                var that = this,
                    value = that.bindings["mindate"].get(); //get the value from the View-Model
                $(that.element).data("kendoDatePicker").min(value); //update the widget
            }
        });

        kendo.data.binders.widget.dmax = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var d = bindings["dmax"].get();
                if (d) {
                    d = new Date(bindings["dmax"].get())
                    var dmax = kendo.toString(d, "yyyyMMdd");
                    var tmp = '# var d1 = "' + dmax + '" #' +
                              '# var d2 = kendo.toString(data.date, "yyyyMMdd") #' +
                              '# if (d1 == d2) { #' +
                              '<div class="dmax" title="Datum max OSN #= kendo.toString(data.date, "d") #">DMAX</div>' +
                              '# } else { #' +
                              '#= kendo.toString(data.date, "dd") #' +
                              '# } #'
                    options.month.content = tmp;
                }
            },
            refresh: function () {
                //var dmax = kendo.toString(this.bindings["dmax"].get(), "yyyyMMdd");
                //var tmp = '# var d1 = "' + dmax + '" #' +
                //          '# var d2 = kendo.toString(data.date, "yyyyMMdd") #' +
                //          '# if (d1 == d2) { #' +
                //          '<div class="dmax" title="Datum max OSN">DMAX</div>' +
                //          '# } else { #' +
                //          '#= kendo.toString(data.date, "dd") #' +
                //          '# } #'
                //this.options.month.content = tmp;
            }
        });

        //bind state
        kendo.data.binders.selected = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                //var target = $(element);
                //this.cssClass = target.hasClass("k-state-selected");
            },
            refresh: function () {
                var selected = this.bindings["selected"].get();
                if (selected) {
                    $(this.element).removeClass("k-state-default");
                    $(this.element).addClass("k-state-selected");
                } else {
                    $(this.element).removeClass("k-state-selected");
                    $(this.element).addClass("k-state-default");
                }
            }
        });
    })

    function getCheckedNodes(nodes) {
        var node, childCheckedNodes;
        var checkedNodes = [];
        for (var i = 0; i < nodes.length; i++) {
            node = nodes[i];
            if (node.checked) {
                checkedNodes.push(node);
            }
            // to understand recursion, first
            // you must understand recursion
            if (node.hasChildren) {
                childCheckedNodes = getCheckedNodes(node.children.view());
                if (childCheckedNodes.length > 0) {
                    checkedNodes = checkedNodes.concat(childCheckedNodes);
                }
            }

        }
        return checkedNodes;
    }

    //<script src="~/Scripts/md5.js"></script>
    //var login = "novak@agilo.cz";
    //var pwd = "Pn810610";
    //var user = "SELECT * tblUsers WHERE UserLogin = '" + login + "'";
    //var str = user[0].IDUser + pwd;
    //var hash = CryptoJS.MD5(str);
    //if (hash.toString() === user[0].UserPWD) { }
    //console.log(hash.toString())
    //console.log("1ac3f9128d8670cc1a475fbf662af321")

    //var translate = {
    //    "cs-CZ": {
    //        key1: ""
    //    },
    //    "en-GB": {
    //        key1: ""
    //    }
    //}