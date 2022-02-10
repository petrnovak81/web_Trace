Imports System.IO
Imports System.Xml

<Authorize(Roles:="1")>
Public Class AdministratorController
    Inherits BaseController

    '
    ' GET: /Administrator

    Function Dashboard() As ActionResult
        Return View()
    End Function

    Function FileAdministration() As ActionResult
        Return View()
    End Function

    Function AdministrationOfConstants() As ActionResult
        Return View()
    End Function

    Function GPSComparison() As ActionResult
        Return View()
    End Function

    Function SVCashRegister() As ActionResult
        Return View()
    End Function

    Function SVDefect() As ActionResult
        Return View()
    End Function

    Public Function PdfManualUpload(files As IEnumerable(Of HttpPostedFileBase)) As ActionResult
        Dim physicalPath = Nothing
        Dim dir As String = Nothing
        Dim f = files.First
        Dim fi As New FileInfo(f.FileName)
        Try
            dir = Server.MapPath("~/App_Data/UploadedFiles/Manuals")
            physicalPath = Path.Combine(dir, Path.GetFileName(f.FileName))

            If Not Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If

            If System.IO.File.Exists(physicalPath) Then
                Return Json(New With {.message = "Soubor s tímto názvem již existuje", .state = False}, JsonRequestBehavior.AllowGet)
            End If

            f.SaveAs(physicalPath)
            Return Json(New With {.message = "Upload " & f.FileName & " dokončeno", .state = True}, JsonRequestBehavior.AllowGet)
        Catch ex As Exception
            Return Json(New With {.message = ex.Message, .state = False}, JsonRequestBehavior.AllowGet)
        End Try
    End Function

    Public Function PdfManualRemove(fileName As String) As ActionResult
        Dim physicalPath = Nothing
        Dim dir As String = Nothing
        Try
            dir = Server.MapPath("~/App_Data/UploadedFiles/Manuals")
            Dim di As New DirectoryInfo(dir)
            di.Attributes = FileAttributes.Normal

            physicalPath = Path.Combine(dir, fileName)

            System.IO.File.SetAttributes(physicalPath, FileAttributes.Normal)

            If System.IO.File.Exists(physicalPath) Then
                System.IO.File.Delete(physicalPath)
            End If

            Return Json(New With {.message = "Remove " & fileName & " dokončeno", .state = True}, JsonRequestBehavior.AllowGet)
        Catch ex As Exception
            Return Json(New With {.message = ex.Message, .state = False}, JsonRequestBehavior.AllowGet)
        End Try
    End Function

    Public Function SVDashboardDetail(p As String) As ActionResult
        ViewData("Partial") = p
        Return View()
    End Function

    Public Function PDFNahled(id As Integer, typ As String, tmp As String)
        Dim bytes As Byte(),
                html As String = "",
                fc As FileConverter,
                pdfStream As MemoryStream = New MemoryStream(),
                xml = ""

        fc = New FileConverter
        tmp = "~/App_Data/Templates/" & tmp
        Try
            Select Case typ
                Case "TemplateDLSpis"
                    xml = dbContext.sp_Get_XMLPrintKartaDL(id).FirstOrDefault
                Case "TemplateFVLetter"
                    xml = dbContext.sp_Get_XMLPrintLetter(id, 1).FirstOrDefault
                Case "TemplateUZSK"
                    xml = dbContext.sp_Get_XMLPrintUZSK(id, 1).FirstOrDefault
            End Select
            Dim p As String = Server.MapPath(tmp)
            If xml IsNot Nothing Then
                If System.IO.File.Exists(p) Then
                    Dim xp As New XslProcessing
                    Dim output As String = xp.XslTransfer(xml.ToString(), p)
                    bytes = fc.HTMLtoPDF(output, "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 0F))
                    pdfStream.Write(bytes, 0, bytes.Length)
                    pdfStream.Position = 0
                    Return New FileStreamResult(pdfStream, "application/pdf")
                Else
                    Return Content("<h3 style='text-align:center;'>Šablona " & tmp & " nenalezena</h3>")
                End If
            Else
                Return Content("<h3 style='text-align:center;'>Pro IDSpisu: " & id & " nebylo vytvořeno xml.</h3>")
            End If
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Return Content("<h3 style='text-align:center;'>" & ex.Message & "</h3>")
        End Try

    End Function

    Public Function AllCasesFromTRACE() As FileResult
        Dim content = dbContext.sp_Get_SV_AllCasesFromTRACE.FirstOrDefault.ToString
        Dim xml = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbNewLine
        xml += content

        Return File(Encoding.UTF8.GetBytes(xml), "application/xml", "AllCasesFromTRACE.xml")
    End Function

    Public Function AllFeeFromTRACE() As FileResult
        Dim content = dbContext.sp_Get_SV_AllFeeFromTRACE.FirstOrDefault.ToString
        Dim xml = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbNewLine
        xml += content

        Return File(Encoding.UTF8.GetBytes(xml), "application/xml", "AllFeeFromTRACE.xml")
    End Function
End Class