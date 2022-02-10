
<div id="spl1-center-detail" class="k-block k-shadow">
    <table class="client-panel-detail">
        <tr>
            <td><span class="lt">@Language.B3_DetailTXT1</span> <span class="lgt" data-bind="text: B3_Detail.PersSurname"></span> <span class="lgt" data-bind="text: B3_Detail.PersName"></span></td>
            <td><span class="lt">@Language.A1_SeznamSpisDohody_ACC</span> <span class="lgt" data-bind="text: B3_Detail.ACC"></span></td>
            <td><span class="lt">@Language.B3_DetailTXT2 </span><span class="lgt" data-bind="money: B3_Detail.ActualDebit"></span> <span class="lgt" data-bind="text: B3_Detail.CurrencyTxt"></span></td>
            <td rowspan="3" style="text-align:center" valign="top">
                <span class="lt">@Language.B3_SeznamTXT2</span>
                <div style="font-size:48px" data-bind="text: B3_Detail.cnt, css: { lt: B3_Detail.cls }">0</div>
            </td>
        </tr>
        <tr>
            <td><span class="lt">@Language.B3_DetailTXT3</span> <span data-bind="rc: B3_Detail.PersRC"> </span><span data-bind="text: B3_Detail.PersIC"></span></td>
            <td><span class="lt">@Language.B3_DetailTXT4</span> <span data-bind="text: B3_Detail.PersStreet"></span> <span data-bind="text: B3_Detail.PersHouseNum"></span> <span data-bind="text: B3_Detail.PersCity"></span> <span data-bind="zip: B3_Detail.PersZipCode"></span></td>
            <td><span class="lt">@Language.B3_DetailSpisuHL_CreditorName</span> <span data-bind="text: B3_Detail.CreditorAlias"></span></td>
            <td></td>
        </tr>
        <tr>
            <td><span class="lt">@Language.B3_DetailTXT5</span> <span data-bind="date: B3_Detail.PersBirthDate"></span></td>
            <td><span class="lt">@Language.B3_DetailTXT6</span> <span data-bind="phone: B3_Detail.PersPhone"></span></td>
            <td>
                @Code
                    Select Case Html.CurAction
                        Case "News"
                            @<span class="lt">@Language.B3_Kontakt_EmployerContactEmail</span>
                            @<span data-bind="text: B3_Detail.PersEmail"></span>
                        Case "PersonalVisit"
                                                @<span class="lt">@Language.B3_DetailTXT7</span>
                                                @<span data-bind="date: B3_Detail.Datum"></span>@<br>
                                                @<span class="lt">@Language.B3_Kontakt_EmployerContactEmail</span>
                                                @<span data-bind="text: B3_Detail.PersEmail"></span>
                        Case "Agreements"
                                                                    @<span class="lt">@Language.B3_DetailTXT8</span>
                                                                    @<span data-bind="date: B3_Detail.Datum"></span>@<br>
                                                                    @<span class="lt">@Language.B3_Kontakt_EmployerContactEmail</span>
                                                                    @<span data-bind="text: B3_Detail.PersEmail"></span>
                        Case "ToProcess"
                                                                                        @<span class="lt">@Language.B3_DetailTXT9</span>
                                                                                        @<span data-bind="date: B3_Detail.Datum"></span>@<br>
                                                                                        @<span class="lt">@Language.B3_Kontakt_EmployerContactEmail</span>
                                                                                        @<span data-bind="text: B3_Detail.PersEmail"></span>
                    End Select
                End Code
            </td>
            <td></td>
        </tr>
    </table>
</div>