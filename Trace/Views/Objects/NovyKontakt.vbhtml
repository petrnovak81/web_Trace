<div id="NovyKontakt" 
    data-role="window"
    data-title="@Html.Raw(Language.NovyKontaktTXT4)"
    data-modal="true"
    data-resizable="true"
    data-actions="['close']"
    style="display: none;width: 640px">
    <h4>@Html.Raw(Language.NovyKontaktTXT1)</h4>
    <div data-role="grid" 
        data-resizable="true"
        data-scrollable="true"
        data-bind="source: Source"
        data-columns="[
        {'field': 'IDSpisyOsoby', 'title': ' ', 'template': '<input type=\'radio\' name=\'IDSpisyOsoby\' value=\'#=IDSpisyOsoby#\' data-bind=\'checked: Radio\' id=\'r-#=uid#\' class=\'k-radio\'><label class=\'k-radio-label\' for=\'r-#=uid#\'></label>', 'width': 30 },
        {'field': 'PersSurname', 'template': '#=CellString(PersSurname)#', 'title': '@Html.Raw(Language.NovyKontaktTXT5)', 'width': 100},
        {'field': 'PersSurname2', 'template': '#=CellString(PersSurname2)#', 'title': '@Html.Raw(Language.NovyKontaktTXT6)', 'width': 100},
        {'field': 'PersName', 'template': '#=CellString(PersName)#', 'title': '@Html.Raw(Language.NovyKontaktTXT7)', 'width': 100},
        {'field': 'PersTypeTxt', 'template': '#=CellString(PersTypeTxt)#', 'title': '@Html.Raw(Language.NovyKontaktTXT8)', 'width': 100},
        {'field': 'PersBirthDate', 'template': '#=CellDate(PersBirthDate)#', 'title': '@Html.Raw(Language.NovyKontaktTXT9)', 'width': 100}
        ]" style="height:200px"></div>
    <table style="width: 100%">
        <tr>
            <td>
                <span>@Html.Raw(Language.NovyKontaktTXT2)</span>
                <input data-bind="value: Phone, events: { keypress: numberValue }" pattern="[0-9]{9}" name="Telefon" maxlength="9" type="text" class="k-textbox" style="width:100%"/>
            </td>
            <td>
                <span>@Html.Raw(Language.NovyKontaktTXT3)</span>
                <input data-bind="value: Email" name="Email" type="email" class="k-textbox" style="width:100%"/>
            </td>
        </tr>
    </table>
    <div class="window-footer">
        <button type="button" class="k-button k-primary" data-bind="events: { click: Save }">@Language.btnSave</button>
        <button type="button" class="k-button" data-bind="events: { click: Storno }">@Language.btnStorno</button> 
    </div>
</div>

<script>
    function newContact(iDSpisu, callback) {
        var win;
        var model = new kendo.observable({
            Source: new kendo.data.DataSource({
                schema: {
                    data: "Data",
                    model: {
                        id: "IDSpisyOsoby"
                    }
                },
                transport: {
                    read: {
                        url: "@Url.Action("sp_Get2_Osoby", "Api/Service")?iDspisu=" + iDSpisu,
                        dataType: "json"
                    }
                }
            }),
            numberValue: function (e) {
                return (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
            },
            Radio: 0,
            Email: "",
            Phone: "",
            Save: function (e) {
                var IDSpisyOsoby = parseInt(this.Radio)
                if (IDSpisyOsoby === 0) {
                    message("   Vyberte osobu, k níž bude vložen kontakt ", "info")
                    return;
                }

                if (!$.trim(this.Email) && !$.trim(this.Phone)) {
                    message("   Zadejte email nebo telefon ", "info")
                    return;
                }

                var validator = $("#NovyKontakt").kendoValidator().data("kendoValidator");
                if (validator.validate()) {
                    var select = this.Source.get(IDSpisyOsoby);
                    callback(select.toJSON(), this.Phone, this.Email);
                    win.close();
                }
            },
            Storno: function (e) {
                win.close();
            }
        })
        kendo.bind($("#NovyKontakt"), model);
        win = $("#NovyKontakt").data("kendoWindow");
        win.open().center();
    }
</script>
