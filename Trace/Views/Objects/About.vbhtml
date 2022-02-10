<div id="about" 
    data-role="window"
    data-title="About"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;width: 400px">
    <div style="clear: both;display:table;width:100%;">
        <h3 class="k-header" style="padding:3px">@Html.Raw(Language.AboutTXT1)</h3>
        <img style="float:left;margin-right:16px;margin-bottom:16px" src="@Url.Action("logoeos.svg", "Images")" alt="EOS" />
        <div style="display: inline-block">
            <label style="margin: 0; font-size: 20px;">@Html.Raw(Language.AboutTXT2)</label>
            <small>@Html.Raw(Language.AboutTXT3)</small>
        </div>
        <table>
            <tr><td>@Html.Raw(Language.AboutTXT4)</td><td>:</td><td><b>@Html.Settings("aboutEOSTel")</b></td><td>@Html.Raw(Language.AboutTXT5)</td><td>:</td><td><a class="k-link" href="@Html.Settings("aboutEOSUrl")" target="_blank">@Html.Settings("aboutEOSUrl")</a></td></tr>
            <tr><td>@Html.Raw(Language.AboutTXT6)</td><td>:</td><td colspan="2"><a class="k-link" href="mailto:@Html.Settings("aboutEOSMail")">@Html.Settings("aboutEOSMail")</a></td><td></td><td></td><td></td></tr>
        </table><br />
        <p style="text-align:justify"><b>@Html.Raw(Language.AboutTXT2)</b> @Html.Raw(Language.AboutTXT8)</p>
        <small class="lt"><i>last build @ViewBag.LastBuild</i></small>
    </div>

    <div style="clear: both;display:table;width:100%;">
        <h3 class="k-header" style="padding:3px">@Html.Raw(Language.AboutTXT9)</h3>
        <img style="float:left;margin-right:16px;margin-bottom:16px" src="@Url.Action("logoagilo.svg", "Images")" alt="EOS" />
        <table>
            <tr><td>@Html.Raw(Language.AboutTXT4)</td><td>:</td><td><b>@Html.Settings("aboutAGTel")</b></td></tr>
            <tr><td>@Html.Raw(Language.AboutTXT6)</td><td>:</td><td><a class="k-link" href="mailto:@Html.Settings("aboutAGMail")">@Html.Settings("aboutAGMail")</a></td></tr>
            <tr><td>@Html.Raw(Language.AboutTXT5)</td><td>:</td><td><a class="k-link" href="@Html.Settings("aboutAGUrl")" target="_blank">@Html.Settings("aboutAGUrl")</a></td></tr>
        </table>
    </div>
    <p style="text-align:justify"><small class="lt"><i>@Html.Raw(Language.AboutTXT13)</i></small></p>
    <div class="window-footer">
        <span style="float: left;">© @Now.ToString("yyyy") AGILO.CZ s.r.o. All rights reserved</span>
        <button type="button" class="k-button k-primary" data-bind="events: { click: Ok }">@Language.btnOk</button>
    </div>
</div>

<script>
    function About() {
        var win;
        var model = new kendo.observable({
            Ok: function (e) {
                win.close();
            }
        });
        kendo.bind($("#about"), model);
        win = $("#about").data("kendoWindow");
        win.open().center();
    };
</script>