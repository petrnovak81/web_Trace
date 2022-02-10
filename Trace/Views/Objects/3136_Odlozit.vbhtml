﻿<div id="3136_Odlozit" 
    data-role="window"
    data-title="@Html.Raw(Language.Odlozit_TXT1)"
    data-modal="true"
    data-resizable="true"
    data-actions="['close']"
    style="display: none;width: 640px">
    <b style="color:red;" data-bind="text: Warning"></b>
    <h4 data-bind="visible: titvisible">@Html.Raw(Language.Odlozit_TXT2)</h4>
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
        <b style="margin-right:20px;">@Html.Raw(Language.a3136_OdlozitTXT1)</b>
        <button type="button" class="k-button k-primary" data-bind="events: { click: Yes }">@Language.btnYes</button>
        <button type="button" class="k-button" data-bind="events: { click: No }">@Language.btnNo</button> 
    </div>
</div>

<script>
    function OdlozitKeZpracovani(data, warning, callback) {
        var win;
        var model = new kendo.observable({
            Warning: warning,
            titvisible: (data ? true : false),
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