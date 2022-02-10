<table data-bind="source: B3_Urgency, visible: B3_Visible" data-template="urgencyrowtemplate" style="width:100%;border-spacing: 1px;"></table>
<script type="text/html" id="urgencyrowtemplate">
    <tr>
        <td style="width:30px;padding:3px;text-align:center;">
            # if(Type === 'U') { #
    <i style="color: rgb(158, 43, 17);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } else if(Type === 'R') { #
    <i style="color: rgb(255, 210, 70);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } else if(Type === 'M') { #
    <i style="color: rgb(120, 210, 55);text-shadow: -1px 0 \\#fff, 0 1px \\#fff, 1px 0 \\#fff, 0 -1px \\#fff;" class="fa fa-bell" aria-hidden="true"></i>
    # } #
        </td>
        <td style="width:60px;padding:3px;">
            # if(CreatedDate) { #
            <div title="@Html.Raw(Language.CreatedDate)" data-bind="date: CreatedDate"></div>
            # } #
        </td>
        <td style="padding:3px;">#=CellString(Txt)#</td>
        <td style="width:60px;padding:3px;">
            # if(DeadLine) { #
            <div title="@Html.Raw(Language.DeadLineDate)" data-bind="date: DeadLine"></div>
            # } #
        </td>
        @Code
            If Html.CurAction <> "ToProcess" Then
            @<td style="width: 30px; padding: 3px; color: red; text-align: center;"># if(Type === 'R') { #
            <a data-bind="events: { click: UrgencyDelete }" href="\\#"><i class="fa fa-times"></i></a>
                # } #
            </td>
            End If
        End Code
    </tr>
</script>