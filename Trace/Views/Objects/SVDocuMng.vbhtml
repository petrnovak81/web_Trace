<div id="SVDocuMng" 
    data-role="window"
    data-title="@Html.Raw(Language.SVDocuMng_Title1)"
    data-width="600"
    data-modal="true"
    data-resizable="false"
    data-actions="['close']"
    style="display: none;">
    <h3>@Html.Raw(Language.SVDocuMng_Title2)</h3>
    <input name="files"
        type="file"
        accept="application/pdf"
        data-multiple="true"
        data-validation="{ maxFileSize: 104857600, allowedExtensions: ['.pdf'] }"
        data-show-file-list="false"
        data-drop-zone=".dropZoneElement"
        data-localization="{ select: '@Html.Raw(Language.SVDocuMng_btnFile)' }"
        data-role="upload"
        data-bind="events: { success: success }"
        data-async="{ saveUrl: '@Url.Action("PdfManualUpload", "Administrator")', autoUpload: true }">
    <div class="dropZoneElement">
        <div data-role="grid" 
        data-resizable="true"
        data-bind="source: files"
        data-columns="[
        {'template': '<a href=\'\\#\' data-bind=\'events: { click: getManualPDF }\' class=\'file-icon pdf-file\'></a>', 'width': 60 },
        {'field': 'CreationTime', 'template': '#=CellDate(CreationTime)#', 'title': 'Datum vložení', 'width': 100},
        {'field': 'Name', 'template': '#=CellString(Name)#', 'title': 'Název'},
        {'template': '<a href=\'\\#\' class=\'k-link fa fa-trash-o\' data-bind=\'events: { click: removeFile }\'></a>', 'width': 50}
        ]" style="height:210px"></div>
    </div>
    <div class="window-footer">
        <button type="button" class="k-button" data-bind="events: { click: storno }">@Language.btnOk</button>
    </div>
</div>

<style>
    #SVDocuMng .fa-trash-o {
        font-size: 22px;
    }

    #SVDocuMng .k-grid-content table td:nth-child(4) {
        text-align: center;
    }

    #SVDocuMng .k-dropzone-hovered {
    background-color: transparent;
    }

    .file-icon {
        display: inline-block;
        width: 48px;
        height: 48px;
    }

    .pdf-file {
        background-image: url(../Content/pdf.png);
    }
</style>

<script>
    function SVDocuMng() {
        var win;
        var model = new kendo.observable({
            files: menuModel.get("files"),
            success: function (e) {
                this.files.read();
                if (e.response.state == true) {
                    message(e.response.message, "success")
                } else {
                    message(e.response.message, "error")
                }
            },
            removeFile: function (e) {
                var that = this;
                $.get("@Url.Action("PdfManualRemove", "Administrator")", { fileName: e.data.Name }, function (result) {
                    if (result.state == true) {
                        that.files.remove(e.data);
                    } else {
                        message(result.message, "error");
                    }
                })
            },
            getManualPDF: function (e) {
                menuModel.getManualPDF(e)
            },
            storno: function (e) {
                win.close();
            }
        });

        kendo.bind($("#SVDocuMng"), model);
        win = $("#SVDocuMng").data("kendoWindow");
        win.open().center();
    }
</script>