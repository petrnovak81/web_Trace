<div id="OSNEntryWin"
    data-role="window"
    data-title="@Html.Raw(Language.Key_ZadaniNovychInformaci)"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;overflow-y:auto;">

    <div class="window-footer">
        <button data-action="1" data-nameact="result" type="button" class="k-primary k-button" data-bind="events: { click: modalSave }">@Html.Raw(Language.OSNEntryWinTXT1)</button>
        <button type="button" class="k-button" data-bind="events: { click: modalStorno }">@Html.Raw(Language.OSNEntryWinTXT2)</button>
    </div>
</div>

