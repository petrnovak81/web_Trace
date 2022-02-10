<div id="SelectContactType"
    data-role="window"
    data-title="@Html.Raw(Language.Key_TypKontaktu)"
    data-width="300"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <ul class="fieldlist">
        <li>
            <button style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: telephone }">@Html.Raw(Language.SelectContactTypeTXT1)</button>
        </li>
        <li>
            <button style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: email }">@Html.Raw(Language.SelectContactTypeTXT2)</button>
        </li>
    </ul>
</div>

<script>
    function SelectContactType(IDSpisu, IDSpisyOsoby, ACC) {
        var win;
        var model = new kendo.observable({
            email: function (e) {
                window.open('@Url.Action("Registration", "Home")?iDSpisu=' + IDSpisu + '&iDSpisyOsoby=' + IDSpisyOsoby + '&ACC=' + ACC + '&Process=' + 3, '_blank');
                win.close();
            },
            telephone: function (e) {
                window.open('@Url.Action("Registration", "Home")?iDSpisu=' + IDSpisu + '&iDSpisyOsoby=' + IDSpisyOsoby + '&ACC=' + ACC + '&Process=' + 2, '_blank');
                win.close();
            }
        });
        kendo.bind($("#SelectContactType"), model);
        win = $("#SelectContactType").data("kendoWindow");
        win.open().center();
    }
</script>