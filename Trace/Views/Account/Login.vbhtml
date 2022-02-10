@ModelType Trace.tblUser
@Code
    ViewData("Title") = "Login"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<script src="~/Scripts/bgAnimation.js"></script>

<style>
    .validate-msg {
        padding: 6px;
        color: #ff5252;
        background: #ffc0c0;
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
    }
</style>

<canvas class="bgAnimation" width="800" height="600"></canvas>

<form id="login" action="@(Url.Action("Login", "Account") & "?ReturnUrl=" & ViewBag.ReturnUrl)" method="post"
    data-role="window"
    data-title="@Html.Raw(Language.LoginTXT1)"
    data-modal="false"
    data-resizable="false"
    data-actions="['close']"
    data-bind="events: { open: onOpen }"
    style="display: none;width: 400px;" class="k-widget">
    <table style="width:calc(100% - 60px);margin:30px;">
        <tr>
            <td style="width:100px;" rowspan="2">
                <span class="k-icon k-i-user" style="font-size: 90px;"></span>
            </td>
            <td>
                <input required style="width:100%;" name="UserLogin" type="email" class="k-textbox" autofocus="autofocus" placeholder="@Language.LoginTXT2" />
            </td>
        </tr>
        <tr>
            <td>
                <input required style="width:100%;" name="UserPWD" type="password" class="k-textbox" placeholder="@Language.LoginTXT3" />
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                @Html.Raw(HttpUtility.HtmlDecode(Html.ValidationMessage("LoginError").ToHtmlString()))
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <a  class="k-link" style="float: left;width:100px;" href="@Url.Action("downloadAndroid", "Base")">
                <img height="38" style="float: left;margin-top:-6px" src="~/Images/android-icon.png" />
                TRACE<br />
                for android
        </a>
        
        <button type="submit" class="k-button k-primary">@Language.LoginTXT4</button><br /><br />
        <a href="#" class="k-link" data-bind="events: { click: forgottenPassword }">@SystemMessages.ForgottenPassword</a>
    </div>
</form>

<form id="newpwd" action="@(Url.Action("Login", "Account") & "?ReturnUrl=" & ViewBag.ReturnUrl)" method="post"
    data-role="window"
    data-title="@Html.Raw(Language.LoginTXT5)"
    data-modal="false"
    data-resizable="false"
    data-actions="{}"
    data-bind="events: { open: onOpen }"
    style="display: none;width: 400px;" class="k-widget">
    <input type="hidden" name="ForgottenPassword" value="1" />
    <table style="width:calc(100% - 60px);margin:30px;">
        <tr>
            <td>
                <input required style="width:100%;" name="UserLogin" type="email" class="k-textbox" autofocus="autofocus" placeholder="@Language.LoginTXT6" />
            </td>
        </tr>
        <tr>
            <td>
                <i>@Language.LoginTXT7</i>
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <button type="submit" class="k-button k-primary">@Language.LoginTXT8</button>
    </div>
</form>

<script>
    $(function () {
        var login, newpwd;
        var c = $('input').css('color'),
            c1 = "rgba(255, 255, 255, 0.35)",
            c2 = "rgba(255, 255, 255, 0.15)";
        if (c.indexOf('a') == -1) {
            c1 = c.replace(')', ', 0.75)').replace('rgb', 'rgba');
            c2 = c.replace(')', ', 0.55)').replace('rgb', 'rgba');
        }
        var model = new kendo.observable({
            forgottenPassword: function (e) {
                newpwd = $("#newpwd").data("kendoWindow");
                newpwd.open().center();
            },
            onOpen: function (e) {
                var t = $(e.sender.element);
                setTimeout(function () {
                    var i = t.find("input");
                    i.first().focus();
                }, 500)
            }
        });

        kendo.bind($("body"), model);
        login = $("#login").data("kendoWindow");
        login.open().center();
        bgAnimation_load($(".bgAnimation"), c1, c2);
    })
</script>

