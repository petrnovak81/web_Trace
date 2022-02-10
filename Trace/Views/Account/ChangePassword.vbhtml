@ModelType TRACE.tblUser

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width" />
    <title>@(Language.ChangePasswordTitle)</title>
    <link href="@Url.Content("~/Content/kendo/2017.2.504/" & Html.KendoCss.common)" rel="stylesheet" />
    <link href="@Url.Content("~/Content/kendo/2017.2.504/" & Html.KendoCss.style)" rel="stylesheet" />
    <link href="@Url.Content("~/Content/app.css")" rel="stylesheet" type="text/css" />


    <link rel="icon" type="image/png" href="~/favicon-16x16.png" sizes="16x16">
    <link href="@Url.Content("~/Content/font-awesome.css")" rel="stylesheet" />

    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/jquery.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/kendo.all.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/aspnetmvc.min.js")"></script>

    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/cultures/kendo.culture." & Culture & ".min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/2017.2.504/messages/kendo.messages." & Culture & ".min.js")"></script>

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="@Url.Content("~/Content/bootstrap.min.css")">
    <!-- Latest compiled and minified JavaScript -->
    <script src="@Url.Content("~/Scripts/bootstrap.min.js")"></script>
    <style>
        html, body {
            height: 100%;
        }

        .buttonRow {
            margin-top: 30px;
        }

        .messages {
            margin-top: 3px;
        }

        .editorField {
            margin-top: 3px;
        }

        .buttonRow .k-button {
            margin-left: 2px;
        }

        .pop-table {
            font-size: 12px;
        }

            .pop-table tr td {
                padding-top: 3px;
            }

        .ico {
            width: 16px;
            height: 16px;
            text-align: center;
            background: #d6d6d6;
            /*color: white;*/
            -webkit-border-radius: 50%;
            -moz-border-radius: 50%;
            border-radius: 50%;
        }

        .success .ico {
            background: #80c63b;
        }

        .inf {
            color: #808080;
            padding-left: 6px;
        }

        .success .inf {
            color: #80c63b;
        }

        .metter-inf {
            font-size: 12px;
            color: #808080;
        }

        .p0 {
            width: 0;
        }

        .p25 {
            width: 25%;
            border: 2px solid #FF0000;
        }

        .p50 {
            width: 50%;
            border: 2px solid orange;
        }

        .p75 {
            width: 75%;
            border: 2px solid #2D98F3;
        }

        .p100 {
            width: 100%;
            border: 2px solid #80c63b;
        }

        .short {
            color: #FF0000;
        }

        .weak {
            color: orange;
        }

        .good {
            color: #2D98F3;
        }

        .strong {
            color: #80c63b;
        }
    </style>
</head>
<body>
    @Code
        If Model IsNot Nothing Then
        @<div style="display: table; height: 100%; width: 100%;">
            <div style="display: table-cell; vertical-align: middle">
                <div style="margin: auto; width: 400px" class="k-shadow" id="login">
                    <div class="k-header">
                        <div style="padding: 10px">@(Language.ChangePasswordHead) @Model.UserLogin</div>
                    </div>
                    @Using (Html.BeginForm("ChangePassword", "Account"))
                        @<div style="padding: 8px">
                            <input type="hidden" name="IDUser" value="@Model.IDUser" />
                            <div class="editorField">
                                <input name="Pass1" autofocus placeholder="@Language.ChangePasswordNew" class="k-textbox" type="password" style="width: 100%" maxlength="16" required />
                            </div>
                            <div class="editorField">
                                <input name="Pass2" placeholder="@Language.ChangePasswordRep" class="k-textbox" type="password" style="width: 100%" maxlength="16" required />
                            </div>
                            <div class="buttonRow">
                                <button class="k-button k-primary" style="float: right;" type="submit"><span class="k-icon k-i-tick"></span>@Language.ChangePasswordSubmit</button>
                            </div>
                            <div style="clear: both" />
                        </div>
                    End Using
                </div>
            </div>
        </div>
        Else
        @<div class="alert alert-danger">
            <h4 style="text-align: center;">@SystemMessages.ChangePasswordAlert</h4>
        </div>
        End If
    End Code

    <script id="pop" type="text/html">
        <div class="pop-content">
            <p class="pop-title">@SystemMessages.ChangePasswordT1</p>
            <table class="pop-table">
                <tr class="required">
                    <td>
                        <div class="ico">✓</div>
                    </td>
                    <td class="inf">@SystemMessages.ChangePasswordT2</td>
                </tr>
                <tr class="minlength">
                    <td>
                        <div class="ico">✓</div>
                    </td>
                    <td class="inf">@SystemMessages.ChangePasswordT3</td>
                </tr>
                <tr class="lowerupper">
                    <td>
                        <div class="ico">✓</div>
                    </td>
                    <td class="inf">@SystemMessages.ChangePasswordT4</td>
                </tr>
                <tr class="digit">
                    <td>
                        <div class="ico">✓</div>
                    </td>
                    <td class="inf">@SystemMessages.ChangePasswordT5</td>
                </tr>
                <tr class="equal">
                    <td>
                        <div class="ico">✓</div>
                    </td>
                    <td class="inf">@SystemMessages.ChangePasswordT6</td>
                </tr>
                <tr class="email">
                    <td>
                        <div class="ico">✓</div>
                    </td>
                    <td class="inf">@SystemMessages.ChangePasswordT7</td>
                </tr>
                <tr class="unique">
                    <td>
                        <div class="ico">✓</div>
                    </td>
                    <td class="inf">@SystemMessages.ChangePasswordT8</td>
                </tr>
            </table>

            <div class="strength">
                <hr />
                <p class="pop-title">@SystemMessages.ChangePasswordT9 <span id="result"></span></p>
                <div style="background: #d6d6d6; height: 4px">
                    <div id="metter"></div>
                </div>
                <p class="metter-inf">@SystemMessages.ChangePasswordT10</p>
            </div>
        </div>
    </script>
    <script>
        $(function () {
            //heslo
            $('input[name="Pass1"]').focus(function () {
                popover(this);
                $(this).popover('show');
            }).keyup(function () {
                popover(this);
                $(this).popover('show');
            }).change(function () {
                popover(this);
            }).focusout(function () {
                $(this).popover('hide');
            })

            //opakovat heslo
            $('input[name="Pass2"]').focus(function () {
                popover(this);
                $(this).popover('show');
            }).keyup(function () {
                popover(this);
                $(this).popover('show');
            }).change(function () {
                popover(this);
            }).focusout(function () {
                $(this).popover('hide');
            })

            var pop = null, rules = {
                Pass1: {
                    minlength: true,
                    lowerupper: true,
                    digit: true,
                    strength: true
                },
                Pass2: {
                    equal: { cofirm: 'Pass1', notEqual: true }
                }
            };

            function popover(element) {
                pop = $($('#pop').html());
                pop.find('table tr').removeClass('success').hide();
                pop.find('.strength').hide();

                $(element).popover({
                    trigger: 'manual',
                    placement: 'top',
                    html: true,
                    content: function () {
                        return pop;
                    }
                });

                var v = $(element).val();
                var name = $(element).attr('name');
                for (var key in rules[name]) {
                    switch (key) {
                        case 'required':
                            var bol = required(v);
                            rules[name][key] = bol;
                            pop.find('.required').show();
                            pop.find('.required').addClass(bol ? 'success' : '');
                            break;
                        case 'email':
                            var bol = email(v);
                            rules[name][key] = bol;
                            pop.find('.email').show();
                            pop.find('.email').addClass(bol ? 'success' : '');
                            break;
                        case 'unique':
                            pop.find('.unique').show();
                            unique(v, function (bol) {
                                rules[name][key] = bol;
                                pop.find('.unique').addClass(bol ? 'success' : '');
                            });
                            break;
                        case 'minlength':
                            var bol = minlength(v, 8);
                            rules[name][key] = bol;
                            pop.find('.minlength').show();
                            pop.find('.minlength').addClass(bol ? 'success' : '');
                            break;
                        case 'lowerupper':
                            var bol = lowerupper(v);
                            rules[name][key] = bol;
                            pop.find('.lowerupper').show();
                            pop.find('.lowerupper').addClass(bol ? 'success' : '');
                            break;
                        case 'digit':
                            var bol = digit(v);
                            rules[name][key] = bol;
                            pop.find('.digit').show();
                            pop.find('.digit').addClass(bol ? 'success' : '');
                            break;
                        case 'strength':
                            var val = checkStrength(v);
                            pop.find('.strength').show();
                            if (!val == false) {
                                rules[name][key] = true;
                                pop.find('#result').html(val);
                            } else {
                                rules[name][key] = false;
                                pop.find('#result').html('');
                            }
                            break;
                        case 'equal':
                            var pass1 = name;
                            var pass2 = rules[name][key].cofirm;
                            if (pass1 && pass2) {
                                var bol = equal('input[name="' + pass1 + '"]', 'input[name="' + pass2 + '"]');
                                rules[name][key].notEqual = bol;
                                pop.find('.equal').show();
                                pop.find('.equal').addClass(bol ? 'success' : '');
                            } else {
                                rules[name][key].notEqual = false;
                            }
                            break;
                    }
                }
            }

            $("form").submit(function (e) {
                e.preventDefault();
                var element, iWantToBreak = false;
                for (var key in rules) {
                    element = $('input[name="' + key + '"]');
                    $.each(rules[key], function (i, e) {
                        if (i == 'equal') {
                            if (!rules[key][i].notEqual) iWantToBreak = true;
                        } else {
                            if (!e) iWantToBreak = true;
                        }
                    })
                    if (iWantToBreak) {
                        element.focus()
                        return false;
                    }
                }
                if (iWantToBreak) return false;
                this.submit();
            });

            //overovani
            function equal(element1, element2) {
                var val1 = $(element1).val()
                var val2 = $(element2).val()
                return (val1 === val2 && !val1 == '' && !val2 == '');
            }

            function required(value) {
                return (value != '');
            }

            function lowerupper(value) {
                return (/[a-z]/.test(value) && /[A-Z]/.test(value));
            }

            function digit(value) {
                return /\d/.test(value);
            }

            function minlength(value, n) {
                return (value.length > n || value.length === n);
            }

            function email(value) {
                var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
                return pattern.test(value);
            }

            function unique(value, callback) {
                var bol = email(value);
                if (bol) {
                    $.get('@Url.Action("uniqueEmail", "Account")', { email: value }, function (res) {
                    callback(res);
                })
            } else {
                callback(false);
            }
        }

            function checkStrength(password) {
                var strength = 0
                if (password.length == 0) {
                    return '@(Html.Raw(SystemMessages.ChangePasswordT11))'
                }
                if (/(.)\1\1/.test(password)) {
                    pop.find('.metter-inf').css('color', '#FF0000').text('@(Html.Raw(SystemMessages.ChangePasswordT12))');
                    pop.find('#metter').addClass('p0')
                    return false
                } else {
                    pop.find('.metter-inf').css('color', '#808080').text('@(Html.Raw(SystemMessages.ChangePasswordT13))');
                }
                if (password.length < 6) {
                    pop.find('#result').removeClass()
                    pop.find('#result').addClass('short')
                    pop.find('#metter').removeClass()
                    pop.find('#metter').addClass('p25')
                    return 'Velmi krátké'
                }
                if (password.length > 7) strength += 1
                // If password contains both lower and uppercase characters, increase strength value.
                if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) strength += 1
                // If it has numbers and characters, increase strength value.
                if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) strength += 1
                // If it has one special character, increase strength value.
                if (password.match(/([!,%,&,@@,#,$,^,*,?,_,~])/)) strength += 1
                // If it has two special characters, increase strength value.
                if (password.match(/(.*[!,%,&,@@,#,$,^,*,?,_,~].*[!,%,&,@@,#,$,^,*,?,_,~])/)) strength += 1
                // Calculated strength value, we can return messages
                // If value is less than 2
                if (strength < 2) {
                    pop.find('#result').removeClass()
                    pop.find('#result').addClass('weak')
                    pop.find('#metter').removeClass()
                    pop.find('#metter').addClass('p50')
                    return '@(Html.Raw(SystemMessages.ChangePasswordT14))'
                } else if (strength == 2) {
                    pop.find('#result').removeClass()
                    pop.find('#result').addClass('good')
                    pop.find('#metter').removeClass()
                    pop.find('#metter').addClass('p75')
                    return '@(Html.Raw(SystemMessages.ChangePasswordT15))'
                } else {
                    pop.find('#result').removeClass()
                    pop.find('#result').addClass('strong')
                    pop.find('#metter').removeClass()
                    pop.find('#metter').addClass('p100')
                    return '@(Html.Raw(SystemMessages.ChangePasswordT16))'
                }
        }
        });
    </script>
</body>
</html>
