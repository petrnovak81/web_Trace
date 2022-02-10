@Code
    ViewData("Title") = "Constants"
    Layout = "~/Views/Shared/_AdminLayout.vbhtml"
End Code

<div id="const" class="flex-container">
    <div class="flex-body">
        <div data-role="splitter" class="site-content"
             data-orientation="vertical"
             data-panes="[
     { collapsible: true, scrollable: true },
     { collapsible: true, scrollable: true, min: '500px', size: '500px' }
     ]">
            <div>
                <div data-role="grid"
                     data-resizable="true"
                     data-scrollable="false"
                     data-columns="[
            { 'field': 'ConstantDescription', 'title': '@Html.Raw(Language.AdministrationOfConstantsTBL10)', 'template': '#=CellString(ConstantDescription)#' },
            { 'field': 'ConstantValue', 'title': '@Html.Raw(Language.AdministrationOfConstantsTBL11)', 'template': '#=CellCustomEdit(ConstantName)#', 'width': 100 },
            { 'field': 'ConstantUnit', 'title': '@Html.Raw(Language.AdministrationOfConstantsTBL12)', 'template': '#=CellString(ConstantUnit)#', 'width': 100 }
            ]"
                     data-bind="source: tblConstant_source1">
                </div>
                <footer class="site-footer">
                    <button class="k-button k-primary" style="width: 150px;" data-bind="events: { click: Save }">@Html.Raw(Language.AdministrationOfConstantsTXT9)</button>
                </footer>
            </div>
            <div>
                <h3>Věřitelé - nastavení šablon pro PDF dokumenty</h3>
                <div data-role="grid"
                     data-scrollable="false"
                     data-resizable="true"
                     data-columns="[
            { 'field': 'IDCreditor', 'title': 'ID', 'width': 50 },
            { 'field': 'CreditorAlias', 'title': '@Html.Raw(Language.A1_SeznamSpisDohody_CreditorAlias)' },
            { 'field': 'TemplateDLSpis', 'template': '#=CellCombo(IDCreditor, \'TemplateDLSpis\', TemplateDLSpis)#', 'width': 140, 'title': 'DLSpis' },
            { 'field': 'TemplateFVLetter', 'template': '#=CellCombo(IDCreditor, \'TemplateFVLetter\', TemplateFVLetter)#', 'width': 140, 'title': 'FVLetter' },
            { 'field': 'TemplateUZSK', 'template': '#=CellCombo(IDCreditor, \'TemplateUZSK\', TemplateUZSK)#', 'width': 140, 'title': 'UZSK' }]"
                     data-bind="source: vw_CreditorTemplates">
                </div>
            </div>
        </div>
    </div>

    <div data-role="window"
         data-title="PDF náhled"
         data-modal="true"
         data-width="300"
         data-actions="{}"
         data-resizable="false"
         id="winnahled" style="display:none;">
        <form action="@Url.Action("PDFNahled", "Home")">
            <ul class="fieldlist">
                <li>
                    <label for="simple-input">ACC</label>
                    <input id="simple-input" type="text" name="acc" class="k-textbox" style="width: 100%;" required placeholder="Zadejte ACC" data-bind="value: acc" />
                </li>
            </ul>
        </form>
        <div class="window-footer">
            <button type="button" class="k-button k-primary" data-bind="events: { click: nahled }">@Language.btnOk</button>
            <button type="button" class="k-button" data-bind="events: { click: storno }">@Language.btnStorno</button>
        </div>
    </div>
</div>

<!-- <style>
    text {
    fill: inherit;
    }
</style> -->

<script>
    function CellCombo(id, name, tmp) {
        return '<input data-id="' + id + '" data-name="' + name + '" id="' + name + id + '" data-auto-bind="false" data-option-label="..." data-role="dropdownlist" data-primitive-value="true" data-text-field="text" data-value-field="text" data-bind="source: tmpFiles, value: ' + name + ', events: { change: tmpFilesChange }" /><button title="PDF náhled" data-role="button" data-name="' + name + '" data-tmp="' + tmp + '" data-bind="events: { click: pdfnahled }"><i class="fa fa-search" aria-hidden="true"></i></button>'
    }

    function CellCustomEdit(cname) {
        return '<input data-cname="' + cname + '" data-role="numerictextbox" data-min="0" data-format="n0" data-decimals="0" data-bind="value: ConstantValue" />'
    }

    $(function () {
        var winnahled = null;
        var model = new kendo.observable({
            tmp: null,
            typ: null,
            acc: null,
            pdfnahled: function (e) {
                var n = $(e.sender.element).data("name");
                var t = $(e.sender.element).data("tmp");
                this.set("typ", n);
                this.set("tmp", t);
                winnahled.open().center();
            },
            nahled: function (e) {
                var that = this;
                var acc = that.get("acc");
                var typ = that.get("typ");
                var tmp = that.get("tmp");

                $.get("@Url.Action("sp_Get_IDSpisuByACC", "Api/AdminService")", { aCC: acc }, function (r) {
                    if (r.error) {
                        alert(r.error)
                    } else {
                        var params = "?id=" + r.id +
                            "&typ=" + typ +
                            "&tmp=" + tmp;
                        var url = "@Url.Action("PDFNahled", "Administrator")" + params;
                        console.log(url)
                        window.open(url, "_blank");
                    }
                })
            },
            storno: function (e) {
                winnahled.close();
            },
            vw_CreditorTemplates: new kendo.data.DataSource({
                schema: {
                    data: "Data",
                    model: {
                        id: "IDCreditor"
                    }
                },
                transport: {
                    read: "@Url.Action("vw_CreditorTemplates", "Api/AdminService")"
                }
            }),
            tmpFiles: new kendo.data.DataSource({
                schema: {
                    data: "Data",
                    model: {
                        id: "value"
                    }
                },
                transport: {
                    read: "@Url.Action("tmpFiles", "Api/AdminService")"
                }
            }),
            tmpFilesChange: function (e) {
                var d = $(e.sender.element).data();
                var v = e.sender.value();
                //sp_SV_CreditorTemplateEdit(iDCreditor As Integer, rr_TemplateType As String, templateFileName As String)
                $.get("@Url.Action("sp_SV_CreditorTemplateEdit", "Api/AdminService")", { iDCreditor: d.id, rr_TemplateType: d.name, templateFileName: v }, function (result) {
                    console.log(result)
                })
            },
            tblConstant_source1: new kendo.data.DataSource({
                schema: {
                    model: {
                        id: "ConstantName"
                    }
                },
                transport: {
                    read: "@Url.Action("tblConstant_source1", "Api/AdminService")"
                }
            }),
            B2B: 0,
            B2C: 0,
            B2CProvident: 0,
            RedemOver24Month: 0,
            RedemUnder24Month: 0,
            Save: function (e) {
                var that = this;
                CustomConfirm("@Html.Raw(SystemMessages.Warning)", "Opravdu si přejete změnit hodnoty?", function (result) {
                    if (result) {
                        $.post("@Url.Action("tblConstant_Update", "Api/AdminService")", {
                            B2B: that.B2B,
                            B2C: that.B2C,
                            B2CProvident: that.B2CProvident,
                            DaysForShowClosed: parseInt(that.tblConstant_source1.get("DaysForShowClosed").ConstantValue),
                            DMaxAfterBrAgreement: parseInt(that.tblConstant_source1.get("DMaxAfterBrAgreement").ConstantValue),
                            FirstFVCommission: parseInt(that.tblConstant_source1.get("FirstFVCommission").ConstantValue),
                            MaxDaysForFirstFV: parseInt(that.tblConstant_source1.get("MaxDaysForFirstFV").ConstantValue),
                            MaxDaysForNextFV: parseInt(that.tblConstant_source1.get("MaxDaysForNextFV").ConstantValue),
                            MaxDaysForReceiveCase: parseInt(that.tblConstant_source1.get("MaxDaysForReceiveCase").ConstantValue),
                            RedemOver24Month: that.RedemOver24Month,
                            RedemUnder24Month: that.RedemUnder24Month,
                            WaitAfterBrAgreement: parseInt(that.tblConstant_source1.get("WaitAfterBrAgreement").ConstantValue),
                            PACommission: parseInt(that.tblConstant_source1.get("PACommission").ConstantValue)
                        }, function (result) {

                        })
                    }
                });
            }
        });

       kendo.bind($("#const"), model);

        winnahled = $("#winnahled").data("kendoWindow");

       coogleRead();

       function coogleRead() {
           $.get("@Url.Action("tblConstant_source2", "Api/AdminService")", {}, function (result) {
                $.each(result, function (a, b) {
                    if (b.ConstantName === "B2B") {
                        model.set("B2B", parseInt(b.ConstantValue));
                    }
                    if (b.ConstantName === "B2C") {
                        model.set("B2C", parseInt(b.ConstantValue));
                    }
                    if (b.ConstantName === "B2CProvident") {
                        model.set("B2CProvident", parseInt(b.ConstantValue));
                    }
                    if (b.ConstantName === "RedemOver24Month") {
                        model.set("RedemOver24Month", parseInt(b.ConstantValue));
                    }
                    if (b.ConstantName === "RedemUnder24Month") {
                        model.set("RedemUnder24Month", parseInt(b.ConstantValue));
                    }
                })
            })
        };
   });
</script>
