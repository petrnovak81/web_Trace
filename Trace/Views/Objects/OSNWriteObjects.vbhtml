

<!-- **** OBJECT 62 ************************************************************************************ -->
<script id="object_62" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_62">
        <div class="objtitle">62</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <b>@Html.Raw(Language.OSNWriteObjectsTXT1) <i style="color:red">*</i>:</b>
                </li>
                <li>
                    <input required name="Email" type="email" class="k-textbox" data-bind="value: textbox0" style="width: 100%" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH4)" />
                </li>
                <li>
                    <table>
                        <tr>
                            <td>
                                <button data-action="1" data-nameact="result" style="float: right;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT2)</button></td>
                        </tr>
                        <tr>
                            <td>
                                <button data-action="2" data-nameact="result" style="float: right;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT3)</button></td>
                        </tr>
                    </table>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 5 ************************************************************************************ -->
<script id="object_5" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_5">
        <div class="objtitle">5</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <button data-action="1" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT5)</button>
                </li>
                <li>
                    <button data-action="2" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT6)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 6 ************************************************************************************ -->
<script id="object_6" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_6">
        <div class="objtitle">6</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <button data-action="1" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT7)</button>
                </li>
                <li>
                    <button data-action="2" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT8)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 7 ************************************************************************************ -->
<script id="object_7" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_7">
        <div class="objtitle">7</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <h3 style="text-align:center">@Html.Raw(Language.OSNWriteObjectsTXT9)</h3>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT10)</button>
                </li>
                <li>
                    <button data-action="2" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT11)</button>
                </li>
                <li>
                    <button data-action="3" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT12)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 9 ************************************************************************************ -->
<script id="object_9" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_9">
        <div class="objtitle">9</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <h3 style="text-align:center">@Html.Raw(Language.OSNWriteObjectsTXT13)</h3>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT14)</button>
                </li>
                <li>
                    <button data-action="2" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT15)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 36a ************************************************************************************ -->
<script id="object_36A" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_36A">
        <div class="objtitle">36A</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <button style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: end }">@Html.Raw(Language.OSNWriteObjectsTXT16)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 61 ************************************************************************************ -->
<script id="object_61" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_61">
        <div class="objtitle">61</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <table>
                        <tr>
                            <td style="width: 160px">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT17) <i style="color:red">*</i>:</span>
                                <!-- PŘEDVYPLNIT DNEŠNÍ DATUM, nelze zadat dopředu, vložit kalendář -->
                                <input required name="Datum" style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, maxdate: today, events: { change: dateChange }" value="" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT17):" /></td>
                            <td style="width: 190px">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT18) <i style="color:red">*</i>:</span>
                                <select required name="Email"
                                    data-auto-bind="false"
                                    data-value-field="ID"
                                    data-template="tmpemail"
                                    data-value-template="tmpemail"
                                    data-role="dropdownlist"
                                    data-bind="source: sp_Get_FVAllEmailsOfCase, value: select0"
                                    style="width: 100%;">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT19)</span>
                                <input type="text" maxlength="800" data-bind="value: textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH25)" />
                            </td>
                        </tr>
                    </table>
                </li>
                <li>
                    <button data-action="1"  data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT20)</button>
                </li>
                <li>
                    <button data-action="2"  data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT21)</button>
                </li>
                <li>
                    <button style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: winNovyKontakt }">@Html.Raw(Language.OSNWriteObjectsTXT22)</button>
                </li>
                <li>
                    <button data-action="4" data-nameact="result" style="float: right;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT23)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 51 ************************************************************************************ -->
<script id="object_51" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_51">
        <div class="objtitle">51</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <table>
                        <tr>
                            <td style="width: 160px">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT26) <i style="color:red">*</i>:</span>
                                <!-- PŘEDVYPLNIT DNEŠNÍ DATUM, nelze zadat dopředu, vložit kalendář -->
                                <input required name="Datum" style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, maxdate: today, events: { change: dateChange }" value="" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT26):" /></td>
                            <td style="width: 190px">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT27) <i style="color:red">*</i>:</span>
                                <select required name="Telefon"
                                    data-auto-bind="false"
                                    data-value-field="ID"
                                    data-template="tmpphone"
                                    data-value-template="tmpphone"
                                    data-role="dropdownlist"
                                    data-bind="source: sp_Get_FVAllPhonesOfCase, value: select0"
                                    style="width: 100%;">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT28)</span>
                                <input type="text" maxlength="500" data-bind="value: textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH34)" />
                            </td>
                        </tr>
                    </table>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT29)</button>
                </li>
                <li>
                    <button data-action="2" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT30)</button>
                </li>
                <li>
                    <button style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: winNovyKontakt }">@Html.Raw(Language.OSNWriteObjectsTXT31)</button>
                </li>
                <li>
                    <button data-action="4" data-nameact="result" style="float: right;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT32)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 51a ************************************************************************************ -->
<script id="object_51a" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_51a">
        <div class="objtitle">51a</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <table>
                        <tr>
                            <td style="width: 160px">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT35) <i style="color:red">*</i>:</span>
                                <!-- PŘEDVYPLNIT DNEŠNÍ DATUM, nelze zadat dopředu, vložit kalendář -->
                                <input required name="Datum" style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, maxdate: today, events: { change: dateChange }" value="" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT35):" /></td>
                            <td style="width: 190px">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT36) <i style="color:red">*</i>:</span>
                                <select required name="Telefon"
                                    data-auto-bind="false"
                                    data-value-field="ID"
                                    data-template="tmpphone"
                                    data-value-template="tmpphone"
                                    data-role="dropdownlist"
                                    data-bind="source: sp_Get_FVAllPhonesOfCase, value: select0"
                                    style="width: 100%;">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span>@Html.Raw(Language.OSNWriteObjectsTXT37)</span>
                                <input type="text" maxlength="500" data-bind="value: textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH43)" />
                            </td>
                        </tr>
                    </table>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT38)</button>
                </li>
                <li>
                    <button data-action="2" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT39)</button>
                </li>
                <li>
                    <button style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: winNovyKontakt }">@Html.Raw(Language.OSNWriteObjectsTXT40)</button>
                </li>
                <li>
                    <button data-action="4" data-nameact="result" style="float: right;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT41)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3131b ************************************************************************************ -->
    <script id="object_3131b" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3131b">
        <div class="objtitle">3131b</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <b>@Html.Raw(Language.OSNWriteObjectsTXT44)</b>
                </li>
                <li>@Html.Raw(Language.OSNWriteObjectsTXT45)
                    <select 
                        data-auto-bind="false"
                        data-value-field="rr_PersTypeMini"
                        data-text-field="PersTypeTxt"
                        data-role="dropdownlist"
                        data-bind="source: vwrr_PersType, value: select0" 
                        style="width: 100%;">
                    </select>
                </li>
                <li>@Html.Raw(Language.OSNWriteObjectsTXT46)
                    <table>
                        <tr>
                            <td style="width: 200px">
                                <input type="text" class="k-textbox" data-bind="value: textbox0" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH50)" /></td>
                            <td style="width: 150px">
                                <input type="text" class="k-textbox" data-bind="value: textbox1" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH51)" /></td>
                        </tr>
                        <tr>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox2" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH52)" />
                            </td>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox3" style="width: 100%" maxlength="10" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH53)" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox4" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH54)" />
                            </td>
                            <td>
                                <input class="k-textbox" type="text"  pattern="[0-9]{5}" name="@Html.Raw(Language.OSNWriteObjectsPLH55)" maxlength="5" data-bind="value: textbox5, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH55)" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input class="k-textbox" type="text"  pattern="[0-9]{9}" name="@Html.Raw(Language.OSNWriteObjectsPLH56)" maxlength="9" data-bind="value: textbox6, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH56)" style="width: 100%;" />
                            <td>
                                <input type="email" class="k-textbox" data-bind="value: textbox7" style="width: 100%" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH57)" /></td>
                        </tr>
                    </table>
                </li>
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT47)</span>
                    <input type="text" maxlength="300" data-bind="value: textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH58)" />
                    <div class="myhr"></div>
                </li>
                <li>
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox272" /><label for="checkbox272" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT48)</label>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT49)</button>
                </li>
            </ul>
        </div>
    </div>
    </script>

<!-- **** OBJECT 3131a ************************************************************************************ -->
    <script id="object_3131a" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_3131a">
            <div class="objtitle">3131a</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <b>@Html.Raw(Language.OSNWriteObjectsTXT59)</b>
                    </li>
                    <li>@Html.Raw(Language.OSNWriteObjectsTXT60)
                    <select 
                        data-auto-bind="false"
                        data-value-field="rr_PersTypeMini"
                        data-text-field="PersTypeTxt"
                        data-role="dropdownlist"
                        data-bind="source: vwrr_PersType, value: select0" 
                        style="width: 100%;">
                    </select>
                    </li>
                    <li>@Html.Raw(Language.OSNWriteObjectsTXT61)
                    <table>
                        <tr>
                            <td style="width: 200px">
                                <input type="text" class="k-textbox" data-bind="value: textbox0" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH65)" /></td>
                            <td style="width: 150px">
                                <input type="text" class="k-textbox" data-bind="value: textbox1" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH66)" /></td>
                        </tr>
                        <tr>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox2" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH67)" />
                            </td>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox3" style="width: 100%" maxlength="10" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH68)" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox4" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH69)" />
                            </td>
                            <td>
                                <input class="k-textbox" type="text"  pattern="[0-9]{5}" name="@Html.Raw(Language.OSNWriteObjectsPLH70)" maxlength="5" data-bind="value: textbox5, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH70)" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input class="k-textbox" type="text"  pattern="[0-9]{9}" name="@Html.Raw(Language.OSNWriteObjectsPLH71)" maxlength="9" data-bind="value: textbox6, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH71)" style="width: 100%;" />
                            <td>
                                <input type="email" class="k-textbox" data-bind="value: textbox7" style="width: 100%" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH72)" /></td>
                        </tr>
                    </table>
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT62)</span>
                        <input type="text" maxlength="300" data-bind="value: textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH73)" />
                        <div class="myhr"></div>
                    </li>
                    <li>
                        <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox271" /><label for="checkbox271" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT63)</label>
                    </li>
                    <li>
                        <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT64)</button>
                    </li>
                </ul>
            </div>
        </div>
    </script>

<!-- **** OBJECT 56 ************************************************************************************ -->
    <script id="object_56" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_56">
            <div class="objtitle">56</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox270" /><label for="checkbox270" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT74)</label>
                    </li>
                    <li>
                        <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT75)</button>

                    </li>
                </ul>
            </div>
        </div>
    </script>

<!-- **** OBJECT 55 ************************************************************************************ -->
<script id="object_55" type="text/html">                                                             
    <div class="arrow_box k-shadow show" data-object="object_55">
        <div class="objtitle">55</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox273" /><label for="checkbox273" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT76)</label>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT77)</button>

                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 54_1 ************************************************************************************ -->
    <script id="object_54_1" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_54_1">
            <div class="objtitle">54_1</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT78) <i style="color: red">*</i>:</span>
                        <!-- nelze zadat ZPĚT - vložit kalendář -->
                        <input required name="Datum" style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, mindate: today, events: { change: dateChange }" value="" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT78)" />
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT79) <i style="color: red">*</i>:</span>
                        <input required name="Předmět" style="width: 100%;" class="k-textbox" type="text" maxlength="60" data-bind="value: textbox0" value="" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH84)" />
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT80)</span>
                        <input type="text" maxlength="300" data-bind="value: textbox1" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH85)" />
                    </li>
                    <li>
                        <button data-action="1" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: sp_Rec_Object_54_1_Extra }"  data-valid="false">@Html.Raw(Language.OSNWriteObjectsTXT81)</button>
                    </li>
                    <li>
                        <button data-action="2" data-nameact="result" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="false">@Html.Raw(Language.OSNWriteObjectsTXT82)</button>
                    </li>
                </ul>
            </div>
        </div>
    </script>


<!-- **** OBJECT 3138 ************************************************************************************ -->
    <script id="object_3138" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_3138">
            <div class="objtitle">3138</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <b>@Html.Raw(Language.OSNWriteObjectsTXT86)</b>
                    </li>
                    <li>
                        <input name="files"
                                type="file"
                                accept="*"
                                data-multiple="true"
                                data-files='#=osnModel.initFiles("object_3138")#'
                                data-localization="{ select: '@Html.Raw(Language.Key_Soubor)' }"
                                data-role="upload"
                                data-bind="events: { error: uploadOnError, upload: uploadData, success: uploadOnSuccess }"
                                data-async="{ saveUrl: '@Url.Action("SaveFile", "Base")?obj=object_3138', removeUrl: '@Url.Action("RemoveFile", "Base")?obj=object_3138', autoUpload: true }">
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT87)</span>
                        <input type="text" maxlength="300" data-bind="value: textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH92)" />
                        <div class="myhr"></div>
                    </li>
                    <li>
                        <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio260" name="groupradios_3138" /><label for="radio260" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT88)</label>
                    </li>
                    <li>
                        <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio261" name="groupradios_3138" /><label for="radio261" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT89)</label>
                    </li>
                    <li>
                        <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio262" name="groupradios_3138" /><label for="radio262" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT90)  </label>
                    </li>
                    <li>
                        <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio263" name="groupradios_3138" /><label for="radio263" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT91)  </label>
                    </li>
                </ul>
            </div>
        </div>
    </script>

<!-- **** OBJECT 3137_4 ********************************************************************************** -->
<script id="object_3137_4" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3137_4">
        <div class="objtitle">3137_4</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio50" name="groupradios3137-4" /><label for="radio50" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT93)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio51" name="groupradios3137-4" /><label for="radio51" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT94)</label>
                </li>
                <li>
                    <div class="myhr"></div>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio52" name="groupradios3137-4" /><label for="radio52" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT95)</label>
                </li>
                <li>
                    <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio53" name="groupradios3137-4" /><label for="radio53" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT96)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3137_3 ************************************************************************************ -->
<script id="object_3137_3" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3137_3">
        <div class="objtitle">3137_3</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT97) <i style="color:red">*</i></span>
                    <input required  name="Požadavky" type="text" maxlength="300" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH99)" />
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT98)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3137_19 a 3137_2 ************************************************************************ -->
<script id="object_3137_2" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3137_2">
        <div class="objtitle">3137_2</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio47" name="groupradios3137_2" /><label for="radio47" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT100)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio48" name="groupradios3137_2" /><label for="radio48" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT101)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio49" name="groupradios3137_2" /><label for="radio49" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT102)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3137_17 ************************************************************************************ -->
<script id="object_3137_17" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3137_17">
        <div class="objtitle">3137_17</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT103) <i style="color:red">*</i></span>
                    <input required  name="Datum" style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, mindate: today, events: { change: dateChange }" value="" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT103)" />
                </li>
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT104)</span>
                    <input maxlength="300" type="text" data-bind="value: textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT104)" />
                </li>
                <li>
                    <button style="width:100%;" class="k-button k-primary" type="button" data-bind="events: { click: vytvoritPripominku }">@Html.Raw(Language.OSNWriteObjectsTXT105)</button>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT106)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

    <!-- **** OBJECT 3137_16 ************************************************************************************ -->
    <script id="object_3137_16" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_3137_16">
            <div class="objtitle">3137_16</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <table>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT109) <i style="color:red">*</i>:</span>
                                    <input required name="Částka" data-role="numerictextbox" maxlength="6" data-format="n0" data-max="999999" data-decimals="0" data-min="1" data-bind="value: textbox0" style="width: 100%;" />
                                </td>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT110) <i style="color:red">*</i>:</span>
                                    <input required name="Číslo" class="k-textbox" type="text" maxlength="8" data-bind="value: textbox1, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT110)" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="object_3137_161" /><label for="object_3137_161" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT111)</label>

                                </td>
                                <td>
                                    <input type="checkbox" data-bind="checked: checkbox1" class="k-checkbox" id="object_3137_162" /><label for="object_3137_162" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT112)</label>
                                </td>
                            </tr>
                        </table>
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT113)</span>
                        <input maxlength="300" type="text" data-bind="value: textbox2" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH116)" />
                    </li>
                    <li>
                        <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT114)</button>
                    </li>
                </ul>
            </div>
        </div>
    </script>

    <!-- **** OBJECT 3137_15 ************************************************************************************ -->
    <script id="object_3137_15" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_3137_15">
            <div class="objtitle">3137_15</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <table>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT117) <span data-bind="text: max"></span>) <i style="color:red">*</i>:</span>
                                    <input required name="Počet" class="k-textbox" data-msgmax="Počet splátek přesahuje maximální povolenou hodnotu." data-bind="value: textbox0, events: { change: maxminValueValidity, keypress: numberValue }" style="width: 100%;" />
                                </td>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT118) <i style="color:red">*</i>:</span>
                                    <input required name="Datum" data-role="datepicker" data-bind="value: datepicker0, mindate: today, events: { change: dateChange }" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT118)" />
                                </td>
                            </tr>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT119)</span>
                                    <input data-role="numerictextbox" maxlength="6" data-format="n0" data-decimals="0" data-max="999999" data-min="1" data-bind="value: textbox1" style="width: 100%;" />
                                </td>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT120) <i style="color:red">*</i>:</span>
                                    <input required name="Den" data-role="numerictextbox" data-format="n0" data-decimals="0" data-max="31" data-min="0" data-bind="value: textbox2" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT121)</span>
                                    <select data-value-primitive="true"
                                        data-auto-bind="true"
                                        data-value-field="Val"
                                        data-text-field="Val"
                                        data-role="dropdownlist"
                                        data-bind="source: rr_Currency, value: select0, events: { dataBound: rr_CurrencyDataBound }"
                                        style="width: 100%;">
                                    </select>
                                </td>
                                <td>
                                    <input id="313715o3" type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" /><label for="313715o3" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT122)</label>
                                </td>
                            </tr>
                        </table>
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT123)</span>
                        <input maxlength="300" type="text" data-bind="value: textbox3" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH126)" />
                    </li>
                    <li>
                        <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT124)</button>
                    </li>
                </ul>
            </div>
        </div>
    </script>

    <!-- **** OBJECT 3137_14 ************************************************************************************ -->
    <script id="object_3137_14" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_3137_14">
            <div class="objtitle">3137_14</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <table>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT127) <span data-bind="text: min"></span>) <i style="color:red">*</i>:</span>
                                    <input required name="Výše splátek" class="k-textbox" data-msgmax="Výše splátky přesahuje dlužnou částku" data-msgmin="Výše splátky nesplňuje povolenou minimální hodnotu" data-bind="value: textbox0, events: { change: maxminValueValidity, keypress: numberValue }" style="width: 100%;" />
                                </td>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT128) <i style="color:red">*</i>:</span>
                                    <input required name="Datum" data-role="datepicker" data-bind="value: datepicker0, mindate: today, events: { change: dateChange }" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT128)" />
                                </td>
                            </tr>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT129)</span>
                                    <input data-role="numerictextbox" maxlength="6" data-format="n0" data-decimals="0" data-max="999999" data-min="1" data-bind="value: textbox1" style="width: 100%;" />
                                </td>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT130) <i style="color:red">*</i>:</span>
                                    <input required name="Den" data-role="numerictextbox" data-format="n0" data-decimals="0" data-max="31" data-min="0" data-bind="value: textbox2" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="313714o4" type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" /><label for="313714o4" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT131)</label>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT132)</span>
                        <input maxlength="300" type="text" data-bind="value: textbox3" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH135)" />
                    </li>
                    <li>
                        <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT133)</button>
                    </li>
                </ul>
            </div>
        </div>
    </script>

    <!-- **** OBJECT 3137_13 ************************************************************************************ -->
    <script id="object_3137_13" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_3137_13">
            <div class="objtitle">3137_13</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <table>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT136) <i style="color:red">*</i>:</span> 
                                    <input required name="@Html.Raw(Language.OSNWriteObjectsTXT136)" data-role="numerictextbox" maxlength="6" data-format="n0" data-decimals="0" data-max="999999" data-min="1" data-bind="value: textbox0" style="width: 100%;" />
                                </td>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT137) <span data-bind="text: max"></span>) <i style="color:red">*</i>:</span>
                                    <input required name="Počet splátek" class="k-textbox" data-msg="Počet splátek přesahuje maximální povolenou hodnotu." data-bind="value: textbox1, attr: { data_max: max }, events: { change: maxminValueValidity, keypress: numberValue }" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT138) <i style="color:red">*</i>:</span>
                                    <input required name="Datum" data-role="datepicker" data-bind="value: datepicker0, mindate: today, events: { change: dateChange }" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT138)" />
                                </td>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT139)</span>
                                    <input data-role="numerictextbox" maxlength="6" data-format="n0" data-decimals="0" data-max="999999" data-min="1" data-bind="value: textbox2" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td><span>@Html.Raw(Language.OSNWriteObjectsTXT140)</span>
                                    <input data-role="numerictextbox" data-format="n0" data-decimals="0" data-max="31" data-min="0" data-bind="value: textbox3" style="width: 100%;" />
                                </td>
                                <td>
                                    <input id="object313713o4" type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" /><label for="object313713o4" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT141)</label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"><span>@Html.Raw(Language.OSNWriteObjectsTXT142)</span>
                                    <select data-value-primitive="true"
                                        data-auto-bind="true"
                                        data-value-field="Val"
                                        data-text-field="Val"
                                        data-role="dropdownlist"
                                        data-bind="source: rr_Currency, value: select0, events: { dataBound: rr_CurrencyDataBound }"
                                        style="width: 100%;">
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT143)</span>
                        <input maxlength="300" type="text" data-bind="value: textbox4" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH146)" />
                    </li>
                    <li>
                        <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT144)</button>
                    </li>
                </ul>
            </div>
        </div>
    </script>

<!-- **** OBJECT 3137_12 ************************************************************************************ -->
<script id="object_3137_12" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3137_12">
        <div class="objtitle">3137_12</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <table>
                        <tr>
                            <td colspan="2"><span>@Html.Raw(Language.OSNWriteObjectsTXT147)</span>
                                <input maxlength="300" type="text" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH150)" /></td>
                        </tr>
                        <tr>
                            <td>
                                <input id="object313712ch" type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" /><label for="object313712ch" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT148)</label>
                            </td>
                            <td>
                                <i style="color:red">*</i>
                                <input required name="Datum" data-role="datepicker" data-bind="value: datepicker0, mindate: today, events: { change: dateChange }" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH151)" />
                            </td>
                        </tr>
                    </table>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right; margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT149)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3137_1 ************************************************************************************ -->
<script id="object_3137_1" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3137_1">
        <div class="objtitle">3137_1</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio40" name="groupradios3137-1" /><label for="radio40" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT152)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio41" name="groupradios3137-1" /><label for="radio41" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT153)</label>
                </li>  
                <li>
                    <div class="myhr"></div>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio42" name="groupradios3137-1" /><label for="radio42" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT154)</label>
                </li>
                <li>
                    <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio43" name="groupradios3137-1" /><label for="radio43" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT155)</label>
                </li> 
                <li>
                    <div class="myhr"></div>
                    <input data-action="5" data-nameact="result" type="radio" value="5" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio44" name="groupradios3137-1" /><label for="radio44" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT156)</label>
                </li>
                <li>
                    <input data-action="6" data-nameact="result" type="radio" value="6" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio265" name="groupradios3137-1" /><label for="radio265" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT157)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3137 ************************************************************************************ -->
<script id="object_3137" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3137">
        <div class="objtitle">3137</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <b>@Html.Raw(Language.OSNWriteObjectsTXT158)</b>
                </li>
                <li>
                    <input name="files"
                                type="file"
                                accept="*"
                                data-multiple="true"
                                data-files='#=osnModel.initFiles("object_3137")#'
                                data-localization="{ select: 'Soubor' }"
                                data-role="upload"
                                data-bind="events: { error: uploadOnError, upload: uploadData, success: uploadOnSuccess }"
                                data-async="{ saveUrl: '@Url.Action("SaveFile", "Base")?obj=object_3137', removeUrl: '@Url.Action("RemoveFile", "Base")?obj=object_3137', autoUpload: true }">
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox275" /><label for="checkbox275" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT159)</label>
                </li>
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT160)</span>
                    <input maxlength="300" type="text" data-bind="value: textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH164)" />
                </li>
                <li>
                    <div class="myhr"></div>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio37" name="groupradios" /><label for="radio37" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT161)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio38" name="groupradios" /><label for="radio38" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT162)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio39" name="groupradios" /><label for="radio39" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT163) </label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3136_3 ************************************************************************************ -->
<script id="object_3136_3" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3136_3">
        <div class="objtitle">3136_3</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio35" name="groupradios3136-3" /><label for="radio35" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT165)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio36" name="groupradios3136-3" /><label for="radio36" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT166)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3136_2 ************************************************************************************ -->
<script id="object_3136_2" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3136_2">
        <div class="objtitle">3136_2</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li><b>@Html.Raw(Language.OSNWriteObjectsTXT167)</b></li>
                <li>
                    <input maxlength="300" style="width: 100%;" data-bind="value: textbox0" type="text" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH176)" />
                </li>
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT168)</span>
                    <input required style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, mindate: today, maxdate: maxdate, events: { change: dateChange }" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT168)" />
                </li>
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio28" name="groupradios3136_2" /><label for="radio28" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT169)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio29" name="groupradios3136_2" /><label for="radio29" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT170)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio30" name="groupradios3136_2" /><label for="radio30" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT171)</label>
                </li>
                <li>
                    <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio31" name="groupradios3136_2" /><label for="radio31" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT172)</label>
                </li>
                <li>
                    <input data-action="5" data-nameact="result" type="radio" value="5" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio32" name="groupradios3136_2" /><label for="radio32" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT173)</label>
                </li>
                <li>
                    <input data-action="6" data-nameact="result" type="radio" value="6" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio33" name="groupradios3136_2" /><label for="radio33" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT174)</label>
                </li>
                <li>
                    <input data-action="7" data-nameact="result" type="radio" value="7" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio34" name="groupradios3136_2" /><label for="radio34" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT175)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

    <!-- **** OBJECT 3136_1 ************************************************************************************ -->
    <script id="object_3136_1" type="text/html">
        <div class="arrow_box k-shadow show" data-object="object_3136_1">
            <div class="objtitle">3136_1</div>
            <div class="k-body">
                <ul class="fieldlist">
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT178)</span>
                        <!-- Vloží tuto adresu do předchozích polí (ulice, čp, město, psč)! -->
                        <select
                            data-auto-bind="false"
                            data-value-field="IDSpisyOsobyAdresy"
                            data-template="tmpddaddress"
                            data-value-template="tmpddaddress"
                            data-role="dropdownlist"
                            data-bind="source: obj2_Address, value: select0"
                            style="width: 100%;">
                        </select>
                    </li>
                    <li>
                        <i style="color:red">*</i>
                        <input required name="Datum" style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, dmax: dmax, mindate: today, events: { change: dateChange }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH182)" />
                    </li>
                    <li>
                        <input type="checkbox" name="nochange" id="nochange" class="k-checkbox" data-type="boolean" data-bind="checked: checkbox0">
                        <label class="k-checkbox-label" for="nochange">@Html.Raw(Language.OSNWriteObjectsTXT179)</label>
                    </li>
                    <li>
                        <input type="text" name="nazev" class="k-textbox" style="width: 100%" data-bind="value: textbox0" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH183)">
                    </li>
                    <li>
                        <span>@Html.Raw(Language.OSNWriteObjectsTXT180)</span>
                        <select
                            data-auto-bind="false"
                            data-value-field="DeadLine"
                            data-template="tmpcampaign"
                            data-value-template="tmpcampaign"
                            data-role="dropdownlist"
                            data-bind="source: vw_Campaign, value: select1, events: { change: vw_Campaign_change }"
                            style="width: 100%;">
                        </select>
                    </li>
                    <li>
                        <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT181)</button>
                    </li>
                </ul>
            </div>
        </div>
    </script>

    <!-- **** OBJECT 3136 ************************************************************************************ -->
<script id="object_3136" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3136">
        <div class="objtitle">3136</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio22" name="groupradios3136" /><label for="radio22" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT184)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: obj3136_Odlozit }" class="k-radio" id="radio23" name="groupradios3136" /><label for="radio23" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT185)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: obj3136_Uzavrit }" class="k-radio" id="radio24" name="groupradios3136" /><label for="radio24" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT186)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3135 ************************************************************************************ -->
<script id="object_3135" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3135">
        <div class="objtitle">3135</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox29" /><label for="checkbox29" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT187)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3132_3 ************************************************************************************ -->
<script id="object_3132_3" type="text/html">
    <div class="objtitle">3132_3</div>
    <form>
        <ul class="fieldlist">
            <li><b>@Html.Raw(Language.OSNWriteObjectsTXT188)</b></li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox0" class="k-checkbox" id="checkbox19" /><label for="checkbox19" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT189)</label>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox1" class="k-checkbox" id="checkbox20" /><label for="checkbox20" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT190)</label>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox2" class="k-checkbox" id="checkbox21" /><label for="checkbox21" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT191)</label>
            </li>
            <li>
                <input type="radio" value="1" data-bind="checked: source.radio" class="k-radio" id="radio19" name="groupradios3132-3" /><label for="radio19" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT192)</label>
            </li>
            <li>
                <input type="text" maxlength="300" data-bind="value: source.textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH206)" />
            </li>
            <li>
                <input type="radio" value="2" data-bind="checked: source.radio" class="k-radio" id="radio20" name="groupradios3132-3" /><label for="radio20" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT193)</label>
            </li>
            <li>
                <input type="radio" value="3" data-bind="checked: source.radio" class="k-radio" id="radio21" name="groupradios3132-3" /><label for="radio21" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT194)</label>
            </li>
            <li>
                <b>@Html.Raw(Language.OSNWriteObjectsTXT195)</b>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox3" class="k-checkbox" id="checkbox22" /><label for="checkbox22" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT196)</label>
                <a href="\\#" type="button" data-bind="events: { click: address_3132_3 }"> @Html.Raw(Language.OSNWriteObjectsTXT197)</a>
                <table id="object_3132_4" style="display: none;">
                    <tr>
                        <td style="width: 50px;"></td>
                        <td>
                            <input type="text" id="empname_3132_4" data-bind="value: source.EmployerName" class="k-textbox" style="width: 100%;" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH207)" />
                        </td>
                        <td>
                            <input type="number" max="99999999" min="10000000" data-bind="value: source.EmployerIC" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH208)" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="text" data-bind="value: source.EmployerStreet" class="k-textbox" style="width: 100%;" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH209)" />
                        </td>
                        <td>
                            <input type="text" data-bind="value: source.EmployerHouseNum" class="k-textbox" style="width: 100%;" maxlength="10" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH210)" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="text" data-bind="value: source.EmployerCity" class="k-textbox" style="width: 100%;" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH211)" />
                        </td>
                        <td>
                            <input class="k-textbox" type="text"  pattern="[0-9]{5}" name="@Html.Raw(Language.OSNWriteObjectsPLH212)" maxlength="5" data-bind="value: source.EmployerZipCode, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH212)" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="text" data-bind="value: source.EmployerContactSurname" class="k-textbox" style="width: 100%;" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH213)" />
                        </td>
                        <td>
                            <input type="text" data-bind="value: source.EmployerContactName" class="k-textbox" style="width: 100%;" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH214)" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <input type="email" data-bind="value: source.EmployerContactEmail" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH215)" />
                        </td>
                        <td>
                            <input class="k-textbox" type="text"  pattern="[0-9]{9}" name="@Html.Raw(Language.OSNWriteObjectsPLH216)" maxlength="9" data-bind="value: source.EmployerContactPhone, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH216)" style="width: 100%;" />
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox4" class="k-checkbox" id="checkbox23" /><label for="checkbox23" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT198)</label>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox5" class="k-checkbox" id="checkbox24" /><label for="checkbox24" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT199)</label>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox6" class="k-checkbox" id="checkbox25" /><label for="checkbox25" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT200)</label>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox7" class="k-checkbox" id="checkbox26" /><label for="checkbox26" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT201)</label>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox8" class="k-checkbox" id="checkbox27" /><label for="checkbox27" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT202)</label>
            </li>
            <li>
                <input type="checkbox" data-bind="checked: source.checkbox9" class="k-checkbox" id="checkbox28" /><label for="checkbox28" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT203)</label>
            </li>
            <li>
                <input maxlength="300" type="text" data-bind="value: source.textbox1" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH217)" />
            </li>
            <li>
                <span>@Html.Raw(Language.OSNWriteObjectsTXT204)</span>
                <input maxlength="300" type="text" data-bind="value: source.textbox2" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH218)" />
            </li>
        </ul>
    </form>
    <div class="window-footer">
        <button data-action="1" data-nameact="result" type="button" class="k-primary k-button" data-bind="events: { click: modalSave }">@Html.Raw(Language.OSNWriteObjectsTXT205)</button>
    </div>
</script>

    <!-- **** OBJECT 3132_2 ************************************************************************************ -->
    <script id="object_3132_2" type="text/html">
        <div class="objtitle">3132_2</div>
        <form>
            <b>@Html.Raw(Language.OSNWriteObjectsTXT219)</b>
            <table>
                <tr>
                    <td>
                        <input type="radio" value="1" data-bind="checked: source.radio" class="k-radio" id="radio15" name="groupradios3132-2" /><label for="radio15" class="k-radio-label">@Html.Raw(Language.OSNWriteObjectsTXT220)</label>
                    </td>
                    <tr>
                        <td>
                            <input type="radio" value="2" data-bind="checked: source.radio" class="k-radio" id="radio16" name="groupradios3132-2" /><label for="radio16" class="k-radio-label">@Html.Raw(Language.OSNWriteObjectsTXT221)</label>
                            <input type="checkbox" data-bind="checked: source.checkbox0" class="k-checkbox" id="checkbox10" /><label for="checkbox10" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT222)</label>
                            <input type="checkbox" data-bind="checked: source.checkbox1" class="k-checkbox" id="checkbox11" /><label for="checkbox11" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT223)</label>
                            <input type="checkbox" data-bind="checked: source.checkbox2" class="k-checkbox" id="checkbox12" /><label for="checkbox12" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT224)</label>
                        </td>
                    </tr>
                <tr>
                    <td>
                        <input type="radio" value="3" data-bind="checked: source.radio" class="k-radio" id="radio17" name="groupradios3132-2" /><label for="radio17" class="k-radio-label">@Html.Raw(Language.OSNWriteObjectsTXT225) </label>
                        <input type="checkbox" data-bind="checked: source.checkbox3" class="k-checkbox" id="checkbox13" /><label for="checkbox13" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT222)</label>
                        <input type="checkbox" data-bind="checked: source.checkbox4" class="k-checkbox" id="checkbox14" /><label for="checkbox14" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT223)</label>
                        <input type="checkbox" data-bind="checked: source.checkbox5" class="k-checkbox" id="checkbox15" /><label for="checkbox15" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT224)</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="radio" value="4" data-bind="checked: source.radio" class="k-radio" id="radio18" name="groupradios3132-2" /><label for="radio18" class="k-radio-label">@Html.Raw(Language.OSNWriteObjectsTXT229)</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" data-bind="checked: source.checkbox6" class="k-checkbox" id="checkbox16" /><label for="checkbox16" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT230)</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" data-bind="checked: source.checkbox7" class="k-checkbox" id="checkbox17" /><label for="checkbox17" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT231)</label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="text" maxlength="300" data-bind="value: source.textbox0" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH234)" />

                        <input type="checkbox" data-bind="checked: source.checkbox8" class="k-checkbox" id="checkbox18" /><label for="checkbox18" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT232)</label>
                    </td>
                </tr>
            </table>
        </form>
        <div class="window-footer">
            <button data-action="1" data-nameact="result" type="button" class="k-primary k-button" data-bind="events: { click: modalSave }">@Html.Raw(Language.OSNWriteObjectsTXT233)</button>
        </div>
    </script>

<!-- **** OBJECT 3132 ************************************************************************************ -->
<script id="object_3132" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3132">
        <div class="objtitle">3132</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <button style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: object_8a }">@Html.Raw(Language.OSNWriteObjectsTXT235)</button>
                </li>
                <li>
                    <button class="k-button k-primary" style="width: 100%;" type="button" data-bind="events: { click: AddressValid }">@Html.Raw(Language.OSNWriteObjectsTXT236)</button>
                </li>
                <li>
                    <button data-modalname="object_3132_3" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: modalwin }">@Html.Raw(Language.OSNWriteObjectsTXT237)</button>
                </li>
                <li>
                    <button data-modalname="object_3132_2" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: modalwin }">@Html.Raw(Language.OSNWriteObjectsTXT238)</button>
                </li>
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: zpracovaniSpisu }" class="k-radio" id="radio220" name="groupradios3132" /><label for="radio220" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT239)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio221" name="groupradios3132" /><label for="radio221" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT240)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: zpracovaniSpisu }" class="k-radio" id="radio222" name="groupradios3132" /><label for="radio222" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT241)</label>
                </li>
                <li>
                    <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio223" name="groupradios3132" /><label for="radio223" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT242)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3131 ************************************************************************************ -->
<script id="object_3131" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3131">
        <div class="objtitle">3131</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <b>@Html.Raw(Language.OSNWriteObjectsTXT243)</b>
                </li>
                <li>@Html.Raw(Language.OSNWriteObjectsTXT244)
                    <select 
                        data-auto-bind="false"
                        data-value-field="rr_PersTypeMini"
                        data-text-field="PersTypeTxt"
                        data-role="dropdownlist"
                        data-bind="source: vwrr_PersType, value: select0" 
                        style="width: 100%;">
                    </select>
                </li>
                <li>
                    @Html.Raw(Language.OSNWriteObjectsTXT245)
                    <table>
                        <tr>
                            <td style="width: 200px">
                                <input type="text" class="k-textbox" data-bind="value: textbox0" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH248)" /></td>
                            <td style="width: 150px">
                                <input type="text" class="k-textbox" data-bind="value: textbox1" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH249)" /></td>
                        </tr>
                        <tr>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox2" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH250)" />
                            </td>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox3" style="width: 100%" maxlength="10" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH251)" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="text" class="k-textbox" data-bind="value: textbox4" style="width: 100%" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH252)" />
                            </td>
                            <td>
                                <input class="k-textbox" type="text"  pattern="[0-9]{5}" name="@Html.Raw(Language.OSNWriteObjectsPLH253)" maxlength="5" data-bind="value: textbox5, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH253)" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input class="k-textbox" type="text"  pattern="[0-9]{9}" name="@Html.Raw(Language.OSNWriteObjectsPLH254)" maxlength="9" data-bind="value: textbox6, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH254)" style="width: 100%;" />
                            <td>
                                <input type="email" class="k-textbox" data-bind="value: textbox7" style="width: 100%" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH255)" /></td>
                        </tr>
                    </table>
                </li>
                <li>
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox1" /><label for="checkbox1" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT246)</label>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT247)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 511a ************************************************************************************ -->
<script id="object_511a" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_511a">
        <div class="objtitle">511a</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio8" name="groupradios511a" /><label for="radio8" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT256)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio9" name="groupradios511a" /><label for="radio9" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT257)</label>
                </li>
                <li>
                    <div class="myhr"></div>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio10" name="groupradios511a" /><label for="radio10" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT258)</label>
                </li>
                <li>
                    <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio11" name="groupradios511a" /><label for="radio11" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT259)</label>
                </li>
                <li>
                    <input data-action="5" data-nameact="result" type="radio" value="5" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio12" name="groupradios511a" /><label for="radio12" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT260)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 511 ************************************************************************************ -->
<script id="object_511" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_511">
        <div class="objtitle">511</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio73" name="groupradios511" /><label for="radio73" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT261)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio74" name="groupradios511" /><label for="radio74" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT262)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio75" name="groupradios511" /><label for="radio75" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT263)</label>
                </li>
                <li>
                    <div class="myhr"></div>
                    <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio76" name="groupradios511" /><label for="radio76" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT264)</label>
                </li>
                <li>
                    <input data-action="5" data-nameact="result" type="radio" value="5" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio77" name="groupradios511" /><label for="radio77" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT265)</label>
                </li>
                <li>
                    <input data-action="6" data-nameact="result" type="radio" value="6" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio78" name="groupradios511" /><label for="radio78" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT266)</label>
                </li>
                <li>
                    <input data-action="7" data-nameact="result" type="radio" value="7" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio79" name="groupradios511" /><label for="radio79" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT267)</label>
                </li>
                <li>
                    <div class="myhr"></div>
                    <input data-action="8" data-nameact="result" type="radio" value="8" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio80" name="groupradios511" /><label for="radio80" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT268)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 341 ************************************************************************************ -->
<script id="object_341" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_341">
        <div class="objtitle">341</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>@Html.Raw(Language.OSNWriteObjectsTXT269)</li>
                <li>
                    <input maxlength="500" type="text" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH272)" />
                </li>
                <li>
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox8" /><label for="checkbox8" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT270)</label>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT271)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 314 ************************************************************************************ -->
<script id="object_314" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_314">
        <div class="objtitle">314</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>@Html.Raw(Language.OSNWriteObjectsTXT273)</li>
                <li>
                    <input maxlength="500" type="text" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH275)" />
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT274)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 314a ************************************************************************************ -->
<script id="object_314a" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_314a">
        <div class="objtitle">314_A</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>@Html.Raw(Language.OSNWriteObjectsTXT276)</li>
                <li>
                    <input type="text" maxlength="300" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH278)" />
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT277)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 314b ************************************************************************************ -->
<script id="object_314b" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_314b">
        <div class="objtitle">314b</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>@Html.Raw(Language.OSNWriteObjectsTXT279)</li>
                <li>
                    <input type="text" maxlength="300" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH281)" />
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT280)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 313 ************************************************************************************ -->
<script id="object_313" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_313">
        <div class="objtitle">313</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox7" /><label for="checkbox7" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT282)</label></li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 312_1 ************************************************************************************ -->
<script id="object_312_1" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_312_1">
        <div class="objtitle">312_1</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox6" /><label for="checkbox6" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT283)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 312 ************************************************************************************ -->
<script id="object_312" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_312">
        <div class="objtitle">312</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>@Html.Raw(Language.OSNWriteObjectsTXT284)</li>
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio200" name="groupradios312" /><label for="radio200" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT285)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio201" name="groupradios312" /><label for="radio201" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT286)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio202" name="groupradios312" /><label for="radio202" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT287)</label>
                </li>
                <li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 311 ************************************************************************************ -->
<script id="object_311" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_311">
        <div class="objtitle">311</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>@Html.Raw(Language.OSNWriteObjectsTXT288)</li>
                <li>
                    <input id="object_311input" maxlength="300" type="text" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH290)" />
                    <span data-for="object_311input" class="k-invalid-msg"></span>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT289)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 63 ************************************************************************************ -->
<script id="object_63" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_63">
        <div class="objtitle">63</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input type="checkbox" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox5" /><label for="checkbox5" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT291)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 54 ************************************************************************************ -->
<script id="object_54" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_54">
        <div class="objtitle">54</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio69" name="groupradios54" /><label for="radio69" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT292)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio70" name="groupradios54" /><label for="radio70" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT293)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio71" name="groupradios54" /><label for="radio71" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT294)</label>
                </li>
                <li>
                    <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { click: buttonaction }" class="k-radio" id="radio72" name="groupradios54" /><label for="radio72" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT295)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 41 ************************************************************************************ -->
<script id="object_41" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_41">
        <div class="objtitle">41</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li><b>@Html.Raw(Language.OSNWriteObjectsTXT296)</b>
                    <table>
                        <tr>
                            <td style="width: 150px">@Html.Raw(Language.OSNWriteObjectsTXT297)</td>
                            <td>
                                <input disabled style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, events: { change: dateChange }" value="" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT297)" />
                            </td>
                        </tr>
                        <tr>
                            <td>@Html.Raw(Language.OSNWriteObjectsTXT298) <i style="color:red">*</i></td>
                            <td>
                                <input required name="Číslo" class="k-textbox" type="text" maxlength="8" data-bind="value: textbox0, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsTXT298)" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td>@Html.Raw(Language.OSNWriteObjectsTXT299) <i style="color:red">*</i></td>
                            <td>
                                <input required name="Částka" data-role="numerictextbox" maxlength="6" data-format="n0" data-decimals="0" data-max="999999" data-min="1" data-bind="value: textbox1" style="width: 100%;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <input type="text" maxlength="300" data-bind="value: textbox2" class="k-textbox" style="width: 100%;" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH306)" />
                                <div class="myhr"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" value="1" data-bind="checked: checkbox0" class="k-checkbox" id="checkbox65" /><label for="checkbox65" class="k-checkbox-label"> @Html.Raw(Language.OSNWriteObjectsTXT300)</label>
                            </td>
                            <td>
                                <input style="width: 100%;" data-role="datepicker" data-bind="value: datepicker1, mindate: today, events: { change: dateChange }" value="" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH307)" />
                            </td>
                        </tr>
                    </table>
                </li>
                <li>
                    <button data-action="2" data-nameact="result" style="width: 100%" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT301)</button>
                </li>
                <li>
                    <button data-action="3" data-nameact="result" style="width: 100%" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }">@Html.Raw(Language.OSNWriteObjectsTXT302)</button>
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT303)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 36 ************************************************************************************ -->
<script id="object_36" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_36">
        <div class="objtitle">36</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <button data-count="0" style="width: 100%" class="k-button k-primary badge badge-top-right" type="button" data-bind="attr: { data-count: fcount }, events: { click: nextFile }">@Html.Raw(Language.OSNWriteObjectsTXT308)</button>
                </li>
                <li>
                    <button style="width: 100%" class="k-button k-primary" type="button" data-bind="events: { click: endFile }">@Html.Raw(Language.OSNWriteObjectsTXT309)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 35 ************************************************************************************ -->
<script id="object_35" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_35">
        <div class="objtitle">35</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT310)</span>
                    <input type="text" maxlength="500" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH312)" />
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT311)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 33 ************************************************************************************  -->
<script id="object_33" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_33">
        <div class="objtitle">33</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT313)</span>
                    <input maxlength="500" type="text" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH315)" />
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT314)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 32 ************************************************************************************ -->
<script id="object_32" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_32">
        <div class="objtitle">32</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT316)</span>
                    <input maxlength="500" type="text" data-bind="value: textbox0" style="width: 100%;" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH318)" />
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT317)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 4 ************************************************************************************ -->
<script id="object_4" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_4">
        <div class="objtitle">4</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input type="radio" value="1" data-bind="checked: radio" class="k-radio" id="radio64" name="groupradios4" /><label for="radio64" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT319)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 3 ************************************************************************************ -->
<script id="object_3" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_3">
        <div class="objtitle">3</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <input data-action="1" data-nameact="result" type="radio" value="1" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio58" name="groupradios3" /><label for="radio58" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT320)</label>
                </li>
                <li>
                    <input data-action="2" data-nameact="result" type="radio" value="2" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio59" name="groupradios3" /><label for="radio59" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT321)</label>
                </li>
                <li>
                    <input data-action="3" data-nameact="result" type="radio" value="3" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio60" name="groupradios3" /><label for="radio60" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT322)</label>
                </li>
                <li>
                    <input data-action="4" data-nameact="result" type="radio" value="4" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio61" name="groupradios3" /><label for="radio61" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT323)</label>
                </li>
                <li>
                    <input data-action="5" data-nameact="result" type="radio" value="5" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio62" name="groupradios3" /><label for="radio62" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT324)</label>
                </li>
                <li>
                    <input data-action="6" data-nameact="result" type="radio" value="6" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio63" name="groupradios3" /><label for="radio63" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT325)</label>
                </li>
                <li>
                    <input data-action="7" data-nameact="result" type="radio" value="7" data-bind="checked: radio, events: { change: buttonaction }" class="k-radio" id="radio250" name="groupradios3" /><label for="radio250" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT326)</label>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 2_2 ************************************************************************************ -->
<script id="object_2_2" type="text/html">
    <form style="width: 400px">
        <div class="objtitle">2_2</div>
        <ul class="fieldlist">
            <li>
                <b>NOVÁ ADRESA, TELEFON či EMAIL</b>
                <div class="myhr"></div>
                <b>Zadejte novou adresu:</b>
                <table>
                    <tr>
                        <td style="width: 200px">
                            <input style="width: 100%;" type="text" data-bind="value: source.textbox0" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH364)" /></td>
                        <td>
                            <input style="width: 100%;" type="text" data-bind="value: source.textbox1" class="k-textbox" maxlength="10" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH365)" /></td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <input style="width: 100%;" type="text" data-bind="value: source.textbox2" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH366)" /></td>
                        <td style="width: 50px">
                            <input class="k-textbox" type="text"  pattern="[0-9]{5}" name="@Html.Raw(Language.OSNWriteObjectsPLH367)" maxlength="5" data-bind="value: source.textbox3, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH367)" style="width: 100%;" />
                    </tr>
                </table>
            </li>
            <li>
                <div class="myhr"></div>
                <table>
                    <tr>
                        <td colspan="2"><b>@Html.Raw(Language.OSNWriteObjectsTXT357)</b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <span>@Html.Raw(Language.OSNWriteObjectsTXT358)</span><br>
                            <input class="k-textbox" type="text"  pattern="[0-9]{9}" name="Telefon 1" maxlength="9" data-bind="value: source.textbox4, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH368)" style="width: 150px;" />
                        </td>
                        <td>
                            <span>@Html.Raw(Language.OSNWriteObjectsTXT359)</span><br>
                            <input class="k-textbox" type="text"  pattern="[0-9]{9}" name="Telefon 2" maxlength="9" data-bind="value: source.textbox5, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH369)" style="width: 150px;" />
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <div class="myhr"></div>
                <table>
                    <tr>
                        <td colspan="2"><b>@Html.Raw(Language.OSNWriteObjectsTXT360)</b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 180px">
                            <span>@Html.Raw(Language.OSNWriteObjectsTXT361)</span>
                            <input style="width: 180px;" type="email" data-bind="value: source.textbox6" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH370)" />
                        </td>
                        <td>
                            <span>@Html.Raw(Language.OSNWriteObjectsTXT362)</span>
                            <input style="width: 180px;" type="email" data-bind="value: source.textbox7" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH371)" />
                        </td>
                    </tr>
                </table>
            </li>
        </ul>
    </form>
    <div class="window-footer">
        <button data-action="1" data-nameact="result" type="button" class="k-primary k-button" data-bind="events: { click: obj_2_2_save }">@Html.Raw(Language.OSNWriteObjectsTXT363)</button>
    </div>
</script>

<!-- **** OBJECT 2_1 ************************************************************************************ -->
<script id="object_2_1" type="text/html">
    <form style="width: 400px">
        <div class="objtitle">2_1</div>
        <ul class="fieldlist">
            <li><b>@Html.Raw(Language.OSNWriteObjectsTXT327)</b></li>
            <li>
                <div class="myhr"></div>
                <b>@Html.Raw(Language.OSNWriteObjectsTXT328)</b>
            </li>
            <li>
                <input type="radio" value="1" data-toggle='{ 
                    "show": ["toggle2_1_1", "toggle2_1_2", "toggle2_1_3", "toggle2_1_4", "toggle2_1_5", "toggle2_1_6"], 
                    "hide": ["toggle2_1_0"] 
                    }' data-bind="checked: source.radio, events: { click: toggle }" class="k-radio" id="radio1" name="groupradios2-1" /><label for="radio1" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT329)</label>
            </li>
            <li>
                <input type="radio" value="2" data-toggle='{ 
                    "show": ["toggle2_1_0"], 
                    "hide": ["toggle2_1_1_0", "toggle2_1_1_3"] 
                    }' data-bind="checked: source.radio, events: { click: toggle }" class="k-radio" id="radio13" name="groupradios2-1" /><label for="radio13" class="k-radio-label"> @Html.Raw(Language.OSNWriteObjectsTXT330)</label>
            </li>
            <li id="toggle2_1_0" style="display: none">
                <select data-toggle='{ 
                    "show": ["toggle2_1_1", "toggle2_1_2", "toggle2_1_3", "toggle2_1_4", "toggle2_1_5", "toggle2_1_6"], 
                    "hide": ["toggle2_1_1_0", "toggle2_1_1_3"] 
                    }'
                   
                    data-auto-bind="false"
                    data-value-field="IDSpisyOsoby"
                    data-template="tmpddosoby"
                    data-value-template="tmpddosoby"
                    data-role="dropdownlist"
                    data-bind="source: obj2_Osoby, value: source.select0, events: { change: toggle }"
                    style="width: 100%;">
                </select>
            </li>
            <li>
                <input type="radio" value="3" data-toggle='{ 
                    "show": ["toggle2_1_1", "toggle2_1_1_0", "toggle2_1_1_3", "toggle2_1_2", "toggle2_1_3", "toggle2_1_4", "toggle2_1_5", "toggle2_1_6"], 
                    "hide": ["toggle2_1_0"] 
                    }' data-bind="checked: source.radio, events: { click: toggle }" class="k-radio" id="radio3" name="groupradios2-1" /><label for="radio3" class="k-radio-label">@Html.Raw(Language.OSNWriteObjectsTXT331)</label>
            </li>
            <li id="toggle2_1_1" style="display: none">
                <div class="myhr"></div>
                <b>@Html.Raw(Language.OSNWriteObjectsTXT332)</b>
                <table>
                    <tr  id="toggle2_1_1_0" style="display: none">
                        <td>
                            <input style="width: 100%;" type="text" data-bind="value: source.textbox0" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH339)" />
                        </td>
                        <td>
                            <input style="width: 100%;" type="text" data-bind="value: source.textbox1" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH340)" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input style="width: 100%;" type="text" data-bind="value: source.textbox2" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH341)" />
                        </td>
                        <td>
                            <input style="width: 100%;" type="text" data-bind="value: source.textbox3" class="k-textbox" maxlength="10" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH342)" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input style="width: 100%;" type="text" data-bind="value: source.textbox4" class="k-textbox" maxlength="60" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH343)" />
                        </td>
                        <td>
                            <input class="k-textbox" type="text" name="@Html.Raw(Language.OSNWriteObjectsPLH344)"  pattern="[0-9]{5}" name="@Html.Raw(Language.OSNWriteObjectsPLH344)" maxlength="5" data-bind="value: source.textbox5, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH344)" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr id="toggle2_1_1_3" style="display: none">
                        <td>
                            <input id="object_21email" style="width: 100%;" type="email" data-bind="value: source.textbox6" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH345)" />
                        </td>
                        <td>
                            <input class="k-textbox" type="text" name="@Html.Raw(Language.OSNWriteObjectsPLH346)"  pattern="[0-9]{9}" name="@Html.Raw(Language.OSNWriteObjectsPLH346)" maxlength="9" data-bind="value: source.textbox7, events: { keypress: numberValue }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH346)" style="width: 100%;" />
                        </td>
                    </tr>
                </table>
               </li>
            <li id="toggle2_1_2" style="display: none">
                <div class="myhr"></div>
                <b>@Html.Raw(Language.OSNWriteObjectsTXT333)</b>
                <input maxlength="300" style="width: 100%;" type="text" data-bind="value: source.textbox8" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH347)" />
            </li>
            <li id="toggle2_1_3" style="display: none">
                <input type="checkbox" data-bind="checked: source.checkbox0" class="k-checkbox" id="checkbox2" /><label for="checkbox2" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT334)</label>
            </li>
            <li id="toggle2_1_4" style="display: none">
                <input type="checkbox" data-bind="checked: source.checkbox1" class="k-checkbox" id="checkbox3" /><label for="checkbox3" class="k-checkbox-label">@Html.Raw(Language.OSNWriteObjectsTXT335)</label>
            </li>
            <li id="toggle2_1_5" style="display: none">
                <span>@Html.Raw(Language.OSNWriteObjectsTXT336)</span>
                <select
                    data-option-label="Vyber platnost adresy"
                    data-auto-bind="false"
                    data-value-field="IDOrder"
                    data-text-field="Val"
                    data-role="dropdownlist"
                    data-bind="source: @Html.Raw(Language.OSNWriteObjectsTXT336)Adresy, value: source.select1"
                    style="width: 100%;">
                </select>
            </li>
            <li id="toggle2_1_6" style="display: none">
                <span>@Html.Raw(Language.OSNWriteObjectsTXT337)</span>
                <select
                    data-option-label="Vyber typ adresy"
                    data-auto-bind="false"
                    data-value-field="IDOrder"
                    data-text-field="Val"
                    data-role="dropdownlist"
                    data-bind="source: @Html.Raw(Language.OSNWriteObjectsTXT337)Adresy, value: source.select2"
                    style="width: 100%;">
                </select>
            </li>
        </ul>
    </form>
    <div class="window-footer">
        <button data-action="1" data-nameact="result" type="button" class="k-primary k-button" data-bind="events: { click: obj_2_1_save }">@Html.Raw(Language.OSNWriteObjectsTXT338)</button>
    </div>
</script>

<!-- **** OBJECT 2 ************************************************************************************ -->
<script id="object_2" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_2">
        <div class="objtitle">2</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <b>@Html.Raw(Language.OSNWriteObjectsTXT348)</b>
                </li>
                <li>
                    <input readonly="readonly" style="width: 100%;" type="text" data-bind="value: textbox0" class="k-textbox" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH352)" />
                </li>
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT349)</span>
                    <!-- Vloží tuto adresu do předchozích polí (ulice, čp, město, psč)! -->
                    <select 
                        data-auto-bind="false"
                        data-value-field="IDSpisyOsobyAdresy"
                        data-template="tmpddaddress"
                        data-value-template="tmpddaddress"
                        data-role="dropdownlist"
                        data-bind="source: obj2_Address, value: select0, events: { change: obj2_Address_change }" 
                        style="width: 100%;">
                    </select>
                </li>
                <li>
                    <table>
                        <tr>
                            <td>
                                <button data-modalname="object_2_1" style="width: 100%;" class="k-button k-primary" type="button" data-bind="events: { click: modalwin }">@Html.Raw(Language.OSNWriteObjectsTXT350)</button></td>
                            <td>
                                <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: buttonaction }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT351)</button></td>
                        </tr>
                    </table>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 1 ************************************************************************************ -->
<script id="object_1" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_1">
        <div class="objtitle">1</div>
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                    <!-- Tlačítko na vložení fotografie -->
                    <input name="files"
                                type="file"
                                accept="image/*"
                                data-multiple="true"
                                data-files='#=osnModel.initFiles("object_1")#'
                                data-localization="{ select: '@Html.Raw(Language.Key_Fotografie)' }"
                                data-role="upload"
                                data-bind="events: { error: uploadOnError, upload: uploadData, success: uploadOnSuccess, select: fileSelect }"
                                data-async="{ saveUrl: '@Url.Action("SaveFile", "Base")?obj=object_1', removeUrl: '@Url.Action("RemoveFile", "Base")?obj=object_1', autoUpload: true }">
                </li>
                <li>
                    <span>@Html.Raw(Language.OSNWriteObjectsTXT353)</span> <i style="color:red">*</i>
                    <input required name="Datum" style="width: 100%;" data-role="datepicker" data-bind="value: datepicker0, maxdate: today, events: { change: dateChange }" placeholder="@Html.Raw(Language.OSNWriteObjectsPLH355)" />
                </li>
                <li>
                    <button data-action="1" data-nameact="result" style="float: right;margin-left: 3px" class="k-button k-primary" type="button" data-bind="events: { click: startProcess }" data-valid="true">@Html.Raw(Language.OSNWriteObjectsTXT354)</button>
                </li>
            </ul>
        </div>
    </div>
</script>

<!-- **** OBJECT 0 ************************************************************************************ -->
<script id="object_0" type="text/html">
    <div class="arrow_box k-shadow show" data-object="object_0">
        <div class="k-body">
            <ul class="fieldlist">
                <li>
                   <h2 style="text-align: center" data-bind="text: acc"></h2>
                    <small style="color:red;text-align: center">@Html.Raw(Language.OSNWriteObjectsTXT356)</small>
                </li>
            </ul>
        </div>
    </div>
</script>

<style>
    form table {
        width: 100%;
    }

    form .k-radio-label {
        margin-left: 15px;
    }

    form .k-checkbox-label {
        margin-left: 15px;
    }

    form .myhr {
        border-bottom: 1px solid #c7c7c7;
        margin-top: 5px;
        margin-bottom: 5px;
    }

    form .objtitle {
        text-align: right;
        font-size: 8px;
        margin: 3px;
        /*display: none;*/
    }

    /*input:required {
        background-color: yellow;
    }*/
</style>
