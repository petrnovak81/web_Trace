<div id="3136_Odlozit" 
    data-role="window"
    data-title="@Html.Raw(Language.Key_UzavritSpis)"
    data-modal="true"
    data-resizable="true"
    data-actions="['close']"
    style="display: none;width: 640px">
    <h4>@Html.Raw(Language.PredUzavrenimSpisuTXT1) <span data-bind="text: Warning"></span></h4>
    <div data-role="grid" 
        data-resizable="true"
        data-scrollable="true"
        data-bind="source: Source"
        data-columns="[
        {'field': 'AddressTypeTxt', 'template': '#=CellString(AddressTypeTxt)#', 'title': '@Html.Raw(Language.Odlozit_AddressTypeTxt)', 'width': 100},
        {'field': 'Jmeno', 'template': '#=CellString(Jmeno)#', 'title': '@Html.Raw(Language.Odlozit_Jmeno)', 'width': 100},
        {'field': 'Adresa', 'template': '#=CellString(Adresa)#', 'title': '@Html.Raw(Language.Odlozit_Adresa)', 'width': 200},
        {'field': 'AddressValidityTxt', 'template': '#=CellString(AddressValidityTxt)#', 'title': '@Html.Raw(Language.Odlozit_AddressValidityTxt)'}
        ]" style="height:200px"></div>
    <div class="window-footer">
        <b style="float: left;color:red;">@Html.Raw(Language.PredUzavrenimSpisuTXT2)</b>
        <button type="button" class="k-button k-primary" data-bind="events: { click: Yes }">@Language.btnYes</button>
        <button type="button" class="k-button" data-bind="events: { click: No }">@Language.btnNo</button> 
    </div>
</div>

<script>
    function PredUzavrenimSpisu(data, warning, callback) {
        var win;
        var model = new kendo.observable({
            Warning: warning,
            Source: data,
            Yes: function (e) {
                win.close();
                callback(true);
            },
            No: function (e) {
                win.close();
                callback(false);
            }
        });
        kendo.bind($("#3136_Odlozit"), model);
        win = $("#3136_Odlozit").data("kendoWindow");
        win.open().center();
    };
</script>