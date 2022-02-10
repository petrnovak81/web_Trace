<div id="B3_podzal_DalsiOsoby" class="panel k-block k-shadow">
    <table class="panel-header" data-bind="events: { click: togglePanel }">
        <tr>
            <td><b class="">@Html.Raw(Language.B3_DalsiOsobyTXT1)</b></td>
            <td></td>
            <td></td>
            <td></td>
            <td><span class="toggle k-icon k-i-sort-asc-sm"></span></td>
        </tr>
    </table>
    <div class="panel-body">
        <div style="width: 100%;"
            data-role="grid"
            data-resizable="true"
            data-detail-template="B3_Osoby_detail"
            data-columns="[
            { 'field': 'PersTypeTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersTypeTxt)'), 'template': '#=CellString(PersTypeTxt)#' },
            { 'field': 'PersSurname', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonSurname)'), 'template': '#=CellString(PersSurname)#' },
            { 'field': 'PersName', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonName)'), 'template': '#=CellString(PersName)#' },
            { 'field': 'PersSurname2', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonSurname2)'), 'template': '#=CellString(PersSurname2)#' },
            { 'field': 'PersRC', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonRC)'), 'template': '#=CellRC(PersRC)#' },
            { 'field': 'PersIC', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonIC)'), 'template': '#=CellString(PersIC)#' },
            { 'field': 'PersBirthDate', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonBirthDate)'), 'template': '#=CellDate(PersBirthDate)#' },
            ]"
            data-bind="source: B3_Osoby, events: { detailInit: B3_Osoby_detail_init }">
        </div>
        <script id="B3_Osoby_detail" type="text/html">
            <table>
                <tr>
                    <td style="width: 50%; overflow-x: auto">
                        <div style="width: 500px"
                            data-role="grid"
                            data-resizable="true"
                            data-columns="[
            { 'field': 'PersCity', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonCity)'), 'template': '\\#=CellString(PersCity)\\#', 'width': 100 },
            { 'field': 'PersHouseNum', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonHouseNum)'), 'template': '\\#=CellString(PersHouseNum)\\#', 'width': 50 },
            { 'field': 'PersStreet', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonStreet)'), 'template': '\\#=CellString(PersStreet)\\#', 'width': 100 },
            { 'field': 'PersZipCode', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonZipCode)'), 'template': '\\#=CellZip(PersZipCode)\\#', 'width': 50 },
            { 'field': 'PersAddressVisited', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonVisited)'), 'template': '\\#=CellBool(PersAddressVisited)\\#', 'width': 30 },
            { 'field': 'PersMainAddress', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersMainAddress)'), 'template': '\\#=CellBool(PersMainAddress)\\#', 'width': 30 },
            { 'field': 'PersAddressForItinerary', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersAddressForItinerary)'), 'template': '\\#=traceradio(uid, IDSpisu, IDSpisyOsobyAdresy, 1, PersAddressForItinerary)\\#', width: 30 },
            { 'field': 'AddressValidityTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_rr_AddressValidity)'), 'template': '\\#=CellString(AddressValidityTxt)\\#', 'width': 50 },
            { 'field': 'AddressTypeTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonAddressType)'), 'template': '\\#=CellString(AddressTypeTxt)\\#', 'width': 50 }
            ]"
                            data-bind="source: B3_OsobyAddress">
                        </div>
                    </td>
                    <td style="overflow-x: auto">
                        <div style="width: 200px;"
                            data-role="grid"
                            data-resizable="true"
                            data-columns="[
            { 'field': 'PersEmail', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonEmail)'), 'template': '\\#=CellEmail(PersEmail)\\#' },
            { 'field': 'PersEmailValid', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonEmailValid)'), 'template': '\\#=CellBool(PersEmailValid)\\#', 'width': 30 }
            ]"
                            data-bind="source: B3_OsobyEmail">
                        </div>
                    </td>
                    <td style="overflow-x: auto">
                        <div style="width: 200px;"
                            data-role="grid"
                            data-resizable="true"
                            data-columns="[
            { 'field': 'PersPhone', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonPhone)'), 'template': '\\#=CellPhone(PersPhone)\\#'},
            { 'field': 'PhoneValidityTxt', 'headerTemplate': headerTemplate('@Html.Raw(Language.B3_Osoby_PersonPhoneValid)'), 'template': '\\#=CellString(PhoneValidityTxt)\\#', 'width': 100 }
            ]"
                            data-bind="source: B3_OsobyPhone">
                        </div>
                    </td>
                </tr>
            </table>
        </script>
    </div>
</div>
