<div id="B3_podzal_Kontakty" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b class="">@Html.Raw(Language.B3_KontaktyTXT1)</b></td>
            <td></td>
            <td></td>
            <td></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body row-flex-align">
        <div style="margin-right: 12px; width: 100%">
            <div style="height: 120px; width: 100%;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="true"
                data-no-records="false"
                data-columns="[
            { 'field': 'PersCity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonCity)'), 'template': '#=CellString(PersCity)#', 'width': 100 },
            { 'field': 'PersHouseNum', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonHouseNum)'), 'template': '#=CellString(PersHouseNum)#', 'width': 60 },
            { 'field': 'PersStreet', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonStreet)'), 'template': '#=CellString(PersStreet)#', 'width': 100 },
            { 'field': 'PersZipCode', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonZipCode)'), 'template': '#=CellZip(PersZipCode)#', 'width': 50 },
            { 'field': 'PersAddressVisited', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonVisited)'), 'template': '#=CellBool(PersAddressVisited)#', 'width': 30 },
            { 'field': 'PersMainAddress', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersMainAddress)'), 'template': '#=CellBool(PersMainAddress)#', 'width': 30 },
            { 'field': 'PersAddressForItinerary', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersAddressForItinerary)'), 'template': '#=traceradio(uid, IDSpisu, IDSpisyOsobyAdresy, 1, PersAddressForItinerary)#', width: 30 },
            { 'field': 'AddressValidityTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_rr_AddressValidity)'), 'template': '#=CellString(AddressValidityTxt)#', 'width': 70 },
            { 'field': 'AddressTypeTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonAddressType)'), 'template': '#=CellString(AddressTypeTxt)#', 'width': 70 }
            ]"
                data-bind="source: B3_OsobyAddress">
            </div>
        </div>

        <div style="margin-right: 12px;">
            <div style="width: 150px;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="false"
                data-no-records="false"
                data-columns="[
            { 'field': 'PersTypeTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyRole_PersTypeTxt)'), 'template': '#=CellString(PersTypeTxt)#' },
            ]"
                data-bind="source: B3_OsobyRole">
            </div>
        </div>

        <div style="margin-right: 12px;">
            <div style="width: 250px;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="false"
                data-no-records="false"
                data-columns="[
            { 'field': 'PersEmail', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonEmail)'), 'template': '#=CellEmail(PersEmail)#' },
            { 'field': 'PersEmailValid', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonEmailValid)'), 'template': '#=CellBool(PersEmailValid)#', 'width': 70 }
            ]"
                data-bind="source: B3_OsobyEmail">
            </div>
        </div>

        <div style="margin-right: 12px;">
            <div style="width: 200px;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="false"
                data-no-records="false"
                data-columns="[
             { 'field': 'PersPhone', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonPhone)'), 'template': '#=CellPhone(PersPhone)#'},
            { 'field': 'PhoneValidityTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonPhoneValid)'), 'template': '#=CellString(PhoneValidityTxt)#', 'width': 70 }
            ]"
                data-bind="source: B3_OsobyPhone">
            </div>
        </div>

        <div style="margin-right: 12px; width: 100%">
            <div style="height: 100px; width: 100%;"
                data-role="grid"
                data-resizable="true"
                data-scrollable="true"
                data-no-records="false"
                data-columns="[
            { 'field': 'EmployerName', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerName)'), 'template': '#=CellString(EmployerName)#', 'width': 100  },
            { 'field': 'EmployerIC', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerIC)'), 'template': '#=CellString(EmployerIC)#', 'width': 100  },
            { 'field': 'EmployerCity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerCity)'), 'template': '#=CellString(EmployerCity)#', 'width': 100 },
            { 'field': 'EmployerHouseNum', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerHouseNum)'), 'template': '#=CellString(EmployerHouseNum)#', 'width': 100 },
            { 'field': 'EmployerStreet', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerStreet)'), 'template': '#=CellString(EmployerStreet)#', 'width': 100 },
            { 'field': 'EmployerZipCode', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerZipCode)'), 'template': '#=CellZip(EmployerZipCode)#', 'width': 100 },
            @*{ 'field': 'EmployerType', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerType)'), 'template': '#=CellString(EmployerType)#', 'width': 100 },*@
            { 'field': 'AddressValidityTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerAddressValidity)'), 'template': '#=CellString(AddressValidityTxt)#', 'width': 100 },
            { 'field': 'EmployerContactSurname', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerContactSurname)'), 'template': '#=CellString(EmployerContactSurname)#', 'width': 100 },
            { 'field': 'EmployerContactName', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerContactName)'), 'template': '#=CellString(EmployerContactName)#', 'width': 100 },
            { 'field': 'EmployerContactEmail', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerContactEmail)'), 'template': '#=CellEmail(EmployerContactEmail)#', 'width': 100 },
            { 'field': 'EmployerContactPhone', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Kontakt_EmployerContactPhone)'), 'template': '#=CellPhone(EmployerContactPhone)#', 'width': 100 }
            ]"
                data-bind="source: B3_OsobyZam">
            </div>
        </div>

        <div style="margin-right: 12px; width: 100%">
            <table style="width: 100%; height: 36px;">
                <tr>
                    <td style="vertical-align: bottom"><b class="lt">
                        @Html.Raw(Language.B3_KontaktyTXT4)</b>
                        <br>@Html.Raw(Language.B3_KontaktyTXT5)
                    </td>
                </tr>
            </table>
            
            <div style="height: 150px;" id="B3_OsobyDalsiKontakt"
                data-role="grid"
                data-editable="popup"
                data-resizable="true"
                data-scrollable="true"
                data-columns="[
            { 'field': 'rr_PersType', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_rr_PersType)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_rr_PersType)', 'values': this.vwrr_PersType, 'template': '#:getText(rr_PersType, this.vwrr_PersType)#', 'width': 100 },
            { 'field': 'NCSurname', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCSurname)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCSurname)', 'template': '#=CellString(NCSurname)#', 'width': 100 },
            { 'field': 'NCName', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCName)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCName)', 'template': '#=CellString(NCName)#', 'width': 100 },
            { 'field': 'NCCity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCCity)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCCity)', 'template': '#=CellString(NCCity)#', 'width': 100 },
            { 'field': 'NCStreet', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCStreet)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCStreet)', 'template': '#=CellString(NCStreet)#', 'width': 100 },
            { 'field': 'NCHouseNum', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCHouseNum)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCHouseNum)', 'template': '#=CellString(NCHouseNum)#', 'width': 100 },
            { 'field': 'NCZipCode', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCZipCode)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCZipCode)', 'template': '#=CellZip(NCZipCode)#', 'width': 100 },
            { 'field': 'NCAddressVisited', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCAddressVisited)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCAddressVisited)', 'template': '#=CellBool(NCAddressVisited)#', 'width': 30 },
            { 'field': 'NCEmail', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCEmail)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCEmail)', 'template': '#=CellEmail(NCEmail)#', 'width': 100 },
            { 'field': 'NCEmailValid', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCEmailValid)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCEmailValid)', 'template': '#=CellBool(NCEmailValid)#', 'width': 30 },
            { 'field': 'NCPhone', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCPhone)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCPhone)', 'template': '#=CellPhone(NCPhone)#', 'width': 100 },
            { 'field': 'NCPhoneValid', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCPhoneValid)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCPhoneValid)', 'template': '#=CellString(NCPhoneValid)#', 'width': 30 },
            { 'field': 'NCComment', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_OsobyDalsiKontakt_NCComment)'), 'title': '@Html.Raw(Language.B3_OsobyDalsiKontakt_NCComment)', 'template': '#=CellString(NCComment)#', 'width': 60 },
            { 'template': '<a role=\'button\' class=\'k-button\' href=\'\\#\' data-bind=\'events: { click: B3_OsobyDalsiKontakt_Edit }\'><span class=\'k-icon k-i-edit\'></span></a><a role=\'button\' class=\'k-button k-button-icontext k-grid-delete\' href=\'\\#\'><span class=\'k-icon k-i-close\'></span></a>', 'width': 150 }
            ]"
                data-bind="source: B3_OsobyDalsiKontakt, events: { dataBound: B3_OsobyDalsiKontakt_dataBound }">
            </div>
        </div>
    </div>
</div>
