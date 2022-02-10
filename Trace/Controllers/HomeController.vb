Imports System.IO
Imports System.Xml.Xsl
Imports System.Xml
Imports System.Data.Objects
Imports DocumentFormat.OpenXml.Packaging

<Authorize(Roles:="2, 3")>
Public Class HomeController
    Inherits BaseController

    '
    ' GET: /Home
    Function Dashboard(Optional q As Integer = 0) As ActionResult
        On Error Resume Next
        If q = 1 Then
            dbContext.sp_UtilsForTest_01_HoditSpisyDoStavu10()
            dbContext.sp_UtilsForTest_02_SimulovatJobPriPrijetiSpisu()
            Return RedirectToAction("News", "Home")
        ElseIf q = 2 Then
            dbContext.sp_UtilsForTest_40_SimulovatPovyseniDoDohodySK()
            Return RedirectToAction("Agreements", "Home")
        End If

        'Using sr As New System.IO.StreamReader(Server.MapPath("~/App_Data/testemail.txt"))
        '    ViewBag.TestEmail = sr.ReadToEnd.ToLower
        'End Using

        'Dim str = "1 Růžový vrh"
        'For i As Integer = str.Length To 1 Step -1
        '    Dim bytes() As Byte = Encoding.ASCII.GetBytes(str)
        '    If bytes.Length > 9 Then
        '        str = Left(str, i)
        '    Else
        '        Exit For
        '    End If
        'Next

        'Dim bytes() As Byte = Encoding.ASCII.GetBytes("1 Růžový vrh")
        'If bytes.Length > 10 Then
        '    Array.Resize(bytes, 10)

        '    Dim x = bytes.Length

        '    Dim y = Encoding.Unicode.GetString(bytes)
        'End If


        Return View()
    End Function

    <HttpPost>
    Function Dashboard(email As String) As ActionResult
        Using sw As New System.IO.StreamWriter(Server.MapPath("~/App_Data/testemail.txt"), False)
            sw.Write(email.ToLower)
        End Using

        Using sr As New System.IO.StreamReader(Server.MapPath("~/App_Data/testemail.txt"))
            ViewBag.TestEmail = sr.ReadToEnd.ToLower
        End Using
        Return RedirectToAction("Finished", "Home")
    End Function

    Function News(Optional id As String = Nothing) As ActionResult
        Return View()
    End Function

    Function PersonalVisit(Optional id As String = Nothing) As ActionResult
        Return View()
    End Function

    Function Agreements(Optional id As String = Nothing) As ActionResult
        Return View()
    End Function

    Function ToProcess(Optional id As String = Nothing) As ActionResult
        Return View()
    End Function

    Function Finished(Optional id As String = Nothing) As ActionResult
        Return View()
    End Function

    Function CashRegister() As ActionResult
        Return View()
    End Function

    Function Reminder() As ActionResult
        Return View()
    End Function

    Function Tracing() As ActionResult
        Return View()
    End Function

    Function Convert_EOS_RTFVariables(var As String) As String
        Select Case var
            Case "[[$$TMP.SUBSCRIBER_FIRST_NAME]]"
                Return "Petr"
            Case "[[$$TMP.SUBSCRIBER_LAST_NAME]]"
                Return "Novák"
            Case Else
                Return ""
        End Select
    End Function

    Public Function sp_Get_XMLPrintKartaDLPocetAdres(iDSpisu As Integer) As String
        Try
            Dim pocetAdres As New ObjectParameter("PocetAdres", GetType(Int32))
            Dim lastLapse As New ObjectParameter("LastLapse", GetType(Int32))
            Using db As New TRACEEntities
                db.sp_Get_XMLPrintKartaDLPocetAdres(iDSpisu, pocetAdres, lastLapse)
                If lastLapse.Value > 0 Then
                    Dim lapse = db.tblRegisterRestrictions.FirstOrDefault(Function(e) e.Register = "LL_LastLapse" And e.IDOrder = lastLapse.Value)
                    Dim spis = db.tblSpisies.FirstOrDefault(Function(e) e.IDSpisu = iDSpisu)
                    If spis IsNot Nothing Then
                        Return "IDSpisu: " & iDSpisu & ", ACC: " & spis.ACC & ", Error: " & lapse.Val
                    Else
                        Return "Error: " & lapse.Val
                    End If
                Else
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Return ex.Message
        End Try
    End Function

    Function PDFNahled(id As Integer, typ As String, tmp As String) As FileStreamResult
        Dim bytes As Byte(),
                html As String = "",
                fc As FileConverter,
                xml = ""
        fc = New FileConverter
        tmp = "~/App_Data/Templates/" & tmp
        Try
            Select Case typ
                Case "TemplateDLSpis"
                    xml = dbContext.sp_Get_XMLPrintKartaDL(id).FirstOrDefault
                Case "TemplateFVLetter"
                    xml = dbContext.sp_Get_XMLPrintLetter(id, 0).FirstOrDefault
                Case "TemplateUZSK"
                    xml = dbContext.sp_Get_XMLPrintUZSK(id, 0).FirstOrDefault
            End Select
            Dim p As String = Server.MapPath(tmp)
            If System.IO.File.Exists(p) Then
                Dim xp As New XslProcessing
                Dim output As String = xp.XslTransfer(xml.ToString(), p)
                bytes = fc.HTMLtoPDF(output, "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 0F))
            Else
                bytes = fc.HTMLtoPDF("<h3 style='text-align:center;'>Šablona nenalezena</h3>", "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 0F))
            End If
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            bytes = fc.HTMLtoPDF("<h3 style='text-align:center;'>" & ex.Message & "</h3>", "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 0F))
        End Try
        Using pdfStream As MemoryStream = New MemoryStream()
            pdfStream.Write(bytes, 0, bytes.Length)
            pdfStream.Position = 0
            Return New FileStreamResult(pdfStream, "application/pdf")
        End Using
    End Function

    Function TraceDocuments(IDCampaign As Integer, IDU As Integer, DeadLine As Date, CampName As String, pr As Boolean, dn As Boolean, uz As Boolean) As ActionResult
        Dim name As String = "CAMP_" & DeadLine.ToString("yyyy-MM-dd") & "_" & CampName & "_" & IDU & "_" & Now.ToString("HHmmss") & ".pdf"
        Dim ids As Integer = 0
        Dim tmp As String = ""
        Try
            Dim bytes As New List(Of Byte())
            Dim html As String = ""
            Dim err As New List(Of String)
            'ziskat idspisu
            Dim spisy = dbContext.sp_SV_PDFDocumentForPrint(IDCampaign).ToList
            Dim fc As New FileConverter
            If spisy.Count > 0 Then
                For Each i In spisy
                    ids = i.IDSpisu
                    'ziskat xml

                    'prehled DL/Spis
                    If i.TemplateDLSpis <> "XXXNetisknout.xslt" Then
                        If pr Then
                            Dim msg = sp_Get_XMLPrintKartaDLPocetAdres(ids)
                            If msg IsNot Nothing Then
                                err.Add("<li>" & msg & "</li>")
                            Else
                                If i.TemplateDLSpis IsNot Nothing Then
                                    Dim xml = dbContext.sp_Get_XMLPrintKartaDL(i.IDSpisu).FirstOrDefault
                                    If xml IsNot Nothing Then
                                        tmp = "~/App_Data/Templates/" & i.TemplateDLSpis
                                        Dim p As String = Server.MapPath("~/App_Data/Templates/" & i.TemplateDLSpis)
                                        If System.IO.File.Exists(p) Then
                                            Dim xp As New XslProcessing
                                            Dim output As String = xp.XslTransfer(xml.ToString(), p)
                                            Dim b = fc.HTMLtoPDF(output, "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 0F))
                                            bytes.Add(b)
                                        Else
                                            'nenasel jsem xslt soubor
                                            err.Add("<li>Šablona " & i.TemplateDLSpis & " nenalezena</li>")
                                        End If
                                    Else
                                        'nevratio se mi xml
                                        err.Add("<li>sp_Get_XMLPrintKartaDL ACC: " & i.ACC & ", Stav spisu: " & i.StateTxt & ", IDSpisu: " & ids & " nevrátila žádné xml pro šablonu " & i.TemplateDLSpis & ": Nejčastější příčina: Spis není ve stavu K OSN</li>")
                                    End If
                                Else
                                    'supervizor nezvolil sablonu
                                    err.Add("<li>Šablona pro IDCreditor=" & i.IDCreditor & " nebyla zvolena. Upozorněte supervisora, aby šablonu u věřitele doplnil.</li>")
                                End If
                            End If
                        End If
                    End If

                    'dopis o navsteve
                    If i.TemplateFVLetter <> "XXXNetisknout.xslt" Then
                        If dn Then
                            If i.TemplateFVLetter IsNot Nothing Then
                                Dim xml = dbContext.sp_Get_XMLPrintLetter(i.IDSpisu, 0).FirstOrDefault
                                If xml IsNot Nothing Then
                                    tmp = "~/App_Data/Templates/" & i.TemplateFVLetter
                                    Dim p As String = Server.MapPath("~/App_Data/Templates/" & i.TemplateFVLetter)
                                    If System.IO.File.Exists(p) Then
                                        Dim xp As New XslProcessing
                                        Dim output As String = xp.XslTransfer(xml.ToString(), p)
                                        Dim b = fc.HTMLtoPDF(output, "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 0F))
                                        bytes.Add(b)
                                    Else
                                        'nenasel jsem xslt soubor
                                        err.Add("<li>Šablona " & i.TemplateFVLetter & " nenalezena</li>")
                                    End If
                                Else
                                    'nevratio se mi xml
                                    err.Add("<li>sp_Get_XMLPrintLetter ACC: " & i.ACC & ", Stav spisu: " & i.StateTxt & ", IDSpisu: " & ids & " nevrátila žádné xml pro šablonu " & i.TemplateFVLetter & ": Nejčastější příčina: Spis není ve stavu K OSN</li>")
                                End If
                            Else
                                'supervizor nezvolil sablonu
                                err.Add("<li>Šablona pro IDCreditor=" & i.IDCreditor & " nebyla zvolena. Upozorněte supervisora, aby šablonu u věřitele doplnil.</li>")
                            End If
                        End If
                    End If

                    'UZ/SK
                    If i.TemplateUZSK <> "XXXNetisknout.xslt" Then
                        If uz Then
                            If i.TemplateUZSK IsNot Nothing Then
                                Dim xml = dbContext.sp_Get_XMLPrintUZSK(i.IDSpisu, 0).FirstOrDefault
                                If xml IsNot Nothing Then
                                    tmp = "~/App_Data/Templates/" & i.TemplateUZSK
                                    Dim p As String = Server.MapPath("~/App_Data/Templates/" & i.TemplateUZSK)
                                    If System.IO.File.Exists(p) Then
                                        Dim xp As New XslProcessing
                                        Dim output As String = xp.XslTransfer(xml.ToString(), p)
                                        Dim b = fc.HTMLtoPDF(output, "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 0F))
                                        bytes.Add(b)
                                    Else
                                        'nenasel jsem xslt soubor
                                        err.Add("<li>Šablona " & i.TemplateUZSK & " nenalezena</li>")
                                    End If
                                Else
                                    'nevratio se mi xml
                                    err.Add("<li>sp_Get_XMLPrintUZSK ACC: " & i.ACC & ", Stav spisu: " & i.StateTxt & ", IDSpisu: " & ids & " nevrátila žádné xml pro šablonu " & i.TemplateUZSK & ": Nejčastější příčina: Spis není ve stavu K OSN</li>")
                                End If
                            Else
                                'supervizor nezvolil sablonu
                                err.Add("<li>Šablona pro IDCreditor=" & i.IDCreditor & " nebyla zvolena. Upozorněte supervisora, aby šablonu u věřitele doplnil.</li>")
                            End If
                        End If
                    End If
                Next
            Else
                err.Add("<li>Kampaň " & CampName & " nemá žádné spisy</li>")
            End If

            If err.Count > 0 Then
                html += "<h3>Zpráva z generování hromadného tisku:</h3><hr><ul>"
                html += String.Join("", err)
                html += "</ul>"
            End If

            If bytes.Count > 0 Then
                'Kdyz je pdf
                Dim contents As Byte() = fc.concatAndAddContent(bytes)
                Dim dir As String = Server.MapPath("~/App_Data")
                Dim p As String = Path.Combine(dir, name)
                If Not System.IO.Directory.Exists(dir) Then
                    System.IO.Directory.CreateDirectory(dir)
                End If
                System.IO.File.WriteAllBytes(p, contents)
                html += "<h3>Dokumenty pro tisk byly vytvořeny:</h3><hr>"
                html += "<a href='" & Url.Action("GetPDFPrint", "Home") & "?name=" & name & "' target='_blank'>Stáhnout dokumenty k tisku: " & name & "</a>"
            End If

            Return Content(html)
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim msg = "error: " & ex.Message & " IDSpisu: '" & ids & "', template: '" & tmp & "', PDF: '" & name & "'"

            Dim err As New tblError
            err.ErrSource = Left(msg, 40)
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()

            log.WriteLog(New AppLog.LogItem With {.Message = msg, .Params = New Object() {IDCampaign, IDU, DeadLine, CampName, pr, dn, uz}, .Status = 1})
            Return Content("<h3>Zpráva z generování hromadného tisku:</h3><hr><ul><li>" & msg & "</li></ul>")
        End Try
    End Function

    Public Function GetPDFPrint(name As String) As ActionResult

        Dim dir As String = Server.MapPath("~/App_Data")
        Dim p As String = Path.Combine(dir, name)
        If System.IO.File.Exists(p) Then
            Dim filedata As Byte() = System.IO.File.ReadAllBytes(p)
            Dim contentType As String = MimeMapping.GetMimeMapping(p)
            Return File(filedata, contentType)
        Else
            Return Content("<p style='text-align:center;'>Soubor " & name & " nenalezen.</p>")
        End If

    End Function

    Function Registration(iDSpisu As Integer, iDSpisyOsoby As Integer, ACC As String, Process As Integer, GUID As String) As ActionResult
        ViewData("ACC") = ACC
        ViewData("IDSpisu") = iDSpisu
        ViewData("IDSpisyOsoby") = iDSpisyOsoby
        ViewData("Process") = Process
        ViewData("GUID") = GUID
        Return View()
    End Function

    Function BulkCommand(NewIDPaymentOrder As Integer) As ActionResult
        Try
            Dim xml = dbContext.sp_Get_OnePaymentOrder(NewIDPaymentOrder).FirstOrDefault
            Dim xp As New XslProcessing
            Dim tables As New StringBuilder()
            Dim output As String = xp.XslTransfer(xml, Server.MapPath("~/App_Data/XSLTs/hrprikaz.xslt"))
            Dim doc = New HtmlAgilityPack.HtmlDocument()
            doc.LoadHtml(output)

            Dim table As HtmlAgilityPack.HtmlNode = doc.DocumentNode.SelectSingleNode("//table")
            If table IsNot Nothing Then
                tables.Append(table.OuterHtml)
            End If

            Dim pp As New FileConverter
            Dim bytes = pp.HTMLtoPDF(tables.ToString(), "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 25.0F))
            Response.AddHeader("Content-Disposition", "inline; filename=Hromadný příkaz.pdf")
            Return File(bytes, "application/pdf")
        Catch ex As Exception
            Return Content("<p>" & ex.Message & ": " & Server.MapPath("~/App_Data/XSLTs/hrprikaz.xslt") & "</p>")
        End Try
    End Function

    Public Shared Function GetExcelColumnName(ByVal columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt(((dividend - modulo) / 26))
        End While

        Return columnName
    End Function

    Public Function AllCasesFromTRACE(act As Boolean) As FileResult
        Dim str = dbContext.sp_Get_SV_AllCasesFromTRACEByUser(IDUser, act).FirstOrDefault.ToString
        Dim xml = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbNewLine
        xml += str

        Dim ms As New IO.MemoryStream
        Dim doc As XDocument = XDocument.Parse(xml)
        Dim name = If(act, "UkonceneSpisy_" & Now.ToString("yyMMdd_HHmm"), "AktivniSpisy_" & Now.ToString("yyMMdd_HHmm"))
        Dim spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Create(ms, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook)

        '' Add a WorkbookPart to the document.
        Dim workbookpart As WorkbookPart = spreadsheetDocument.AddWorkbookPart
        workbookpart.Workbook = New DocumentFormat.OpenXml.Spreadsheet.Workbook

        '' Add a WorksheetPart to the WorkbookPart.
        Dim worksheetPart As WorksheetPart = workbookpart.AddNewPart(Of WorksheetPart)()
        Dim sheetData As New DocumentFormat.OpenXml.Spreadsheet.SheetData
        worksheetPart.Worksheet = New DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData)

        '' Add Sheets to the Workbook.
        Dim sheets As DocumentFormat.OpenXml.Spreadsheet.Sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(Of DocumentFormat.OpenXml.Spreadsheet.Sheets)(New DocumentFormat.OpenXml.Spreadsheet.Sheets())

        '' Append a new worksheet and associate it with the workbook.
        Dim sheet As DocumentFormat.OpenXml.Spreadsheet.Sheet = New DocumentFormat.OpenXml.Spreadsheet.Sheet
        sheet.Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart)
        sheet.SheetId = 1
        sheet.Name = If(act, "Ukončené spisy", "Aktivní spisy")

        ''hlavicka
        Dim headerRow As DocumentFormat.OpenXml.Spreadsheet.Row = New DocumentFormat.OpenXml.Spreadsheet.Row() With {.RowIndex = 1}
        Dim xheaderRow = doc.Root.Elements.First.Elements
        Dim refCell As DocumentFormat.OpenXml.Spreadsheet.Cell = Nothing
        For Each _cell As DocumentFormat.OpenXml.Spreadsheet.Cell In headerRow.Elements(Of DocumentFormat.OpenXml.Spreadsheet.Cell)
            If (String.Compare(_cell.CellReference.Value, "A1", True) > 0) Then
                refCell = _cell
                Exit For
            End If
        Next

        For i As Integer = 0 To (xheaderRow.Count - 1)
            Dim cell = New DocumentFormat.OpenXml.Spreadsheet.Cell With {.CellReference = GetExcelColumnName(i + 1) & headerRow.RowIndex.ToString}
            headerRow.InsertBefore(cell, refCell)
            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String
            cell.CellValue = New DocumentFormat.OpenXml.Spreadsheet.CellValue(xheaderRow(i).Name.ToString)
        Next
        sheetData.Append(headerRow)

        Dim rowIndex = 2
        For Each _element In doc.Root.Elements
            Dim row As DocumentFormat.OpenXml.Spreadsheet.Row = New DocumentFormat.OpenXml.Spreadsheet.Row() With {.RowIndex = rowIndex}
            Dim _elements = _element.Elements
            rowIndex += 1
            For x As Integer = 0 To (_elements.Count - 1)
                Dim val = _elements(x).Value.ToString
                Dim cell = New DocumentFormat.OpenXml.Spreadsheet.Cell With {.CellReference = GetExcelColumnName(x + 1) & row.RowIndex.ToString}
                row.InsertBefore(cell, refCell)
                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String
                cell.CellValue = New DocumentFormat.OpenXml.Spreadsheet.CellValue(val)
            Next
            sheetData.Append(row)
        Next

        sheets.Append(sheet)
        workbookpart.Workbook.Save()
        spreadsheetDocument.Close()

        Return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name & ".xlsx")
    End Function
End Class
