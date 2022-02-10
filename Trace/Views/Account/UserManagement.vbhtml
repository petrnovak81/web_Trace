<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>@Language.UserManagement</title>
    <link href="@Url.Content("~/Content/kendo/2017.2.504/" & Html.KendoCss.common)" rel="stylesheet" />
    <link href="@Url.Content("~/Content/kendo/2017.2.504/" & Html.KendoCss.style)" rel="stylesheet" />

    <link href="@Url.Content("~/Content/app.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/font-awesome.css")" rel="stylesheet" />

    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/jquery.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/kendo.all.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/aspnetmvc.min.js")"></script>

    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/cultures/kendo.culture." & Culture & ".min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/messages/kendo.messages." & Culture & ".min.js")"></script>
</head>
<body>
    <div id="bind-container" style="height:100%">
        <div data-role="grid"
             data-editable="true"
             data-sortable="multiple"
             data-filterable="true"
             data-toolbar="['save', 'cancel']"
             data-columns="[
            { 'field': 'UserLogin', 'title': 'Login', 'width': 200 },
            { 'field': 'IDRole', 'title': 'Role', 'width': 200, 'editor': this.viewModel.roleEdit, 'template': '#: this.viewModel.getRole(IDRole, this.viewModel.tblRoles, \'RoleName\', \'IDRole\') #' },
            { 'field': 'UserFirstName', 'title': 'Jméno', 'width': 200 },
            { 'field': 'UserLastName', 'title': 'Příjmení', 'width': 200 },
            { 'field': 'UserMobilePhone', 'title': 'Telefon', 'width': 100 },
            { 'field': 'UserAccountEnabled', 'title': 'Povoleno', 'template': '#=checbox(UserAccountEnabled)#', 'width': 30 },
            { 'field': 'PDFPWD', 'title': 'Heslo PDF', 'width': 100 },
            { 'template': '<button class=\'k-button\' name=\'reset\' title=\'@SystemMessages.ResetPasswordTitle\' data-bind=\'visible: resetVisible,events: { click: resetPass }\'>Reset password</button>' }
                              ]"
             data-bind="source: tblUsers, events: { save: onSave, edit: onEdit }"
             style="height: 100%"></div>
    </div>
     @Html.Partial("~/Views/Objects/Notification.vbhtml")
    <script>

        function checbox(v) {
            return "<input type='checkbox' name='UserAccountEnabled' title='@SystemMessages.AccountAllowed' value='" + v + "' " + (v ? 'checked' : '') + " id='ch-#=uid#' class='k-checkbox'><label class='k-checkbox-label' title='@SystemMessages.AccountAllowed' for='ch-#=uid#'></label>"
        }

        function btnDelete() {
            return "<a class='k-grid-delete' name='delete' title='@SystemMessages.DeleteRecordTitle' style='color: red' href='#'><span class='k-icon k-i-close'></span></a>"
        }

        var viewModel = null;
        $.get("@Url.Action("tblRoles_Read", "Account")", null, function (result) {
            viewModel = kendo.observable({
                onSave: function (e) {

                },
                tblUsers: new kendo.data.DataSource({
                    schema: {
                        data: "Data",
                        total: "Total",
                        model: {
                            id: "IDUser",
                            fields: {
                                'UserLogin': { type: 'string', editable: false },
                                'IDRole': { type: 'number', editable: false },
                                'UserFirstName': { type: 'string', editable: false },
                                'UserLastName': { type: 'string', editable: false },
                                'UserMobilePhone': { type: 'string', editable: false },
                                'UserAccountEnabled': { type: 'boolean', editable: true },
                                'PDFPWD': { type: 'string', editable: true }
                            }
                        }
                    },
                    batch: true,
                    transport: {
                        read: {
                            url: "@Url.Action("tblUser_Read", "Account")",
                            dataType: "json"
                        },
                        @*destroy: {
                            url: "@Url.Action("tblUser_Destroy", "Account")",
                            dataType: "json"
                        },*@
                        update: {
                            url: "@Url.Action("tblUser_Update", "Account")",
                            dataType: "json"
                        },
                        @*create: {
                            url: "@Url.Action("tblUser_Create", "Account")",
                            dataType: "json"
                        },*@
                        parameterMap: function (options, operation) {
                            if (operation !== "read" && options.models) {
                                var result = {};
                                for (var i = 0; i < options.models.length; i++) {
                                    var site = options.models[i];
                                    for (var member in site) {
                                        result["users[" + i + "]." + member] = site[member];
                                    }
                                }
                                return result;
                            }
                        },
                        requestEnd: function (e) {
                            if (e.response) {
                                if (e.response.MsgType === 'error') {
                                    var msg = "<span style='margin-left:6px;'>" + e.response.Msg.join("<br>") + "</span>"
                                    message(msg, e.response.MsgType);
                                }
                            }
                        }
                    }
                }),
                tblRoles: [],
                getRole: function (value) {
                    var t = "No Value Found";
                    r = $.grep(this.tblRoles, function (val, integer) {
                        return val["value"] == value;
                    });
                    if (r.length > 0) {
                        t = r[0]["text"];
                    }
                    return t
                },
                roleEdit: function (container, options) {
                    var roles = viewModel.tblRoles;
                    $('<input data-text-field="text" data-value-field="value" data-bind="value:' + options.field + '"/>')
                    .appendTo(container)
                    .kendoDropDownList({
                        dataTextField: "text",
                        dataValueField: "value",
                        dataSource: {
                            data: roles
                        }
                    });
                },
                resetVisible: true,
                deleteVisible: true,
                onEdit: function (e) {
                    if (!e.model.isNew()) {
                        var indexCell = e.container.context.cellIndex;
                        if (indexCell == 0) {
                            e.sender.closeCell();
                        }
                    }
                },
                resetPass: function (e) {
                    $.get('@Url.Action("changePasswordEmail", "Account")', { UserLogin: e.data.UserLogin, Txt: '@Html.Raw(SystemMessages.resetPassEmailBody)' }, function (result) {
                        message(result.Msg[0], result.MsgType)
                    })
                }
            });
            kendo.bind($("#bind-container"), viewModel);
            viewModel.set("tblRoles", result);
        })
    </script>
</body>
</html>
