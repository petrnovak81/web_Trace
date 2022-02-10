Imports System.Threading
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.IO
Imports Newtonsoft.Json
Imports System.Net.Mime

Public Class BaseController
    Inherits System.Web.Mvc.Controller

    Public dbContext As New TRACEEntities
    Public log As New AppLog
    Public EmailModule As NetMail
    Public IDUser As Integer

    'Public Function IsDifferent(object1 As Object, object2 As Object) As Boolean
    '    Dim a = String.Join("", object1).ToLower
    '    Dim b = String.Join("", object2).ToLower
    '    Return a <> b
    'End Function

    Protected Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)

        'For Each u In users
        '    u.UserPWD = GetMd5Hash(u.IDUser & "1")

        '    dbContext.tblUsers.Attach(u)
        '    dbContext.Entry(u).State = EntityState.Modified
        'Next
        'dbContext.SaveChanges()
        'Dim h = GetMd5Hash("Agilo.2017")

        'Using db As New TRACEEntities
        '    Dim item = db.vwA1_OSN.FirstOrDefault
        '    Dim ser As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(vwA1_OSN))
        '    Dim settings As System.Xml.XmlWriterSettings = New System.Xml.XmlWriterSettings()
        '    settings.Indent = True
        '    Using sw = New StringWriter()
        '        Using writer As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(sw, settings)
        '            writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8""")
        '            ser.Serialize(writer, item)
        '            Dim xml = sw.ToString()
        '        End Using
        '    End Using
        'End Using

        Try
            'filterContext.Result = New RedirectToRouteResult(
            '            New RouteValueDictionary(
            '                New With
            '                {
            '                    .Controller = "Account",
            '                    .Action = "Login",
            '                    .ReturnUrl = Request.Url.OriginalString.ToString
            '                }))


            EmailModule = New NetMail(My.Settings.emailSMTP,
                                My.Settings.emailPORT,
                                False,
                                My.Settings.emailUserEmail,
                                My.Settings.emailUserPass,
                                True,
                                True)

            'If Url.IsLocalUrl(returnUrl) AndAlso Not String.IsNullOrEmpty(returnUrl) Then
            '    ViewBag.ReturnURL = returnUrl
            'End If

            Dim u = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = User.Identity.Name)
            If u IsNot Nothing Then
                IDUser = u.IDUser
                ViewBag.IDUser = u.IDUser
                ViewBag.FullUserName = u.UserFirstName & " " & u.UserLastName
                ViewBag.UserInitials = u.UserFirstName.Substring(0, 1) & u.UserLastName.Substring(0, 1)
            End If

            Dim buildxml = Server.MapPath("~/App_Data/build.xml")
            If System.IO.File.Exists(buildxml) Then
                Dim doc = XDocument.Load(buildxml)
                Dim value = doc...<application_info>.Elements.FirstOrDefault(Function(e) e.Name = "last_build").Value
                ViewBag.LastBuild = value
            End If

            'Dim ip = Server.HtmlEncode(Request.UserHostAddress)
            'Dim docc As XDocument = XDocument.Load("http://www.freegeoip.net/xml/" & ip)
            'Dim x = 0
        Catch ex As Exception

        End Try

        MyBase.OnActionExecuting(filterContext)
    End Sub

    Public Function downloadAndroid() As FileResult
        Dim filepath As String = Server.MapPath("~/Android/trace.apk")
        'Dim droidfile As FileInfo = New FileInfo(filepath)
        'If droidfile.Exists Then
        '    Response.ClearContent()
        '    Response.AddHeader("Content-Disposition", "attachment; filename=trace.apk")
        '    Response.AddHeader("Content-Length", droidfile.Length.ToString())
        '    Response.ContentType = "application/vnd.android.package-archive"
        '    Response.TransmitFile(droidfile.FullName)
        '    Response.Flush()
        '    Response.[End]()
        'End If
        Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(filepath)
        Dim fileName As String = "trace.apk"
        Return File(fileBytes, "application/vnd.android.package-archive", fileName)
    End Function

    Function Translate(culture As String) As ActionResult
        If culture IsNot Nothing Then
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)
        End If

        Dim cookie As New HttpCookie("EOSL")
        cookie.Value = culture
        Response.Cookies.Add(cookie)

        Dim returnUrl As String = Request.UrlReferrer.ToString()
        Return Redirect(returnUrl)
    End Function

    Function ChangeTemplate(common As String, style As String) As ActionResult
        Dim cookie As New HttpCookie("kendoTemplate")
        cookie.Value = "{'common': '" & common & "', 'style': '" & style & "'}"
        Response.Cookies.Add(cookie)

        Dim returnUrl As String = Request.UrlReferrer.ToString()
        Return Redirect(returnUrl)
    End Function

    'Function CheckForInternetConnection() As Integer
    '    Try
    '        Using client = New Net.WebClient()
    '            Using stream = client.OpenRead("https://maps.googleapis.com/maps/api/js")
    '                Return 1
    '            End Using
    '        End Using
    '        Return 0
    '    Catch
    '        Return 0
    '    End Try
    'End Function

    Shared Function GetMd5Hash(ByVal input As String) As String
        Dim md5Hash = MD5.Create()
        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function 'GetMd5Hash

    ' Verify a hash against a string.
    Public Function VerifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        Dim md5Hash = MD5.Create()
        ' Hash the input.
        Dim hashOfInput As String = GetMd5Hash(input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function 'VerifyMd5Hash

    Public Function Encode(encodeMe As String) As String
        Dim encoded As Byte() = System.Text.Encoding.UTF8.GetBytes(encodeMe)
        Return Convert.ToBase64String(encoded)
    End Function

    Public Shared Function Decode(decodeMe As String) As String
        Dim encoded As Byte()
        Try
            encoded = Convert.FromBase64String(decodeMe)
            Return System.Text.Encoding.UTF8.GetString(encoded)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'dokument existuje?
    Public Function B3_Dokumentace_PDFExist(IDSpisyDocument As Integer) As Integer
        Dim model = dbContext.tblSpisyDocuments.FirstOrDefault(Function(e) e.IDSpisyDocument = IDSpisyDocument)
        If model IsNot Nothing Then
            If System.IO.File.Exists(model.DocuLink) Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function

    'kdyz existuje vrat klientovi
    Public Function B3_Dokumentace_GetPDF(IDSpisyDocument As Integer) As ActionResult
        Dim model = dbContext.tblSpisyDocuments.FirstOrDefault(Function(e) e.IDSpisyDocument = IDSpisyDocument)
        If model IsNot Nothing Then
            If System.IO.File.Exists(model.DocuLink) Then
                Dim filedata As Byte() = System.IO.File.ReadAllBytes(model.DocuLink)
                Dim contentType As String = MimeMapping.GetMimeMapping(model.DocuLink)
                Return File(filedata, contentType)
            Else
                Return Content("<p style='text-align:center;'>Soubor " & model.DocuLink & " nenalezen.</p>")
            End If
        Else
            Return Content("<p style='text-align:center;'>Soubor IDSpisyDocument=" & IDSpisyDocument & " nenalezen</p>")
        End If
    End Function

    'manualy***********************
    Public Function GetManualFiles() As ActionResult
        Dim dir = Server.MapPath("~/App_Data/UploadedFiles/Manuals")
        Dim files As New List(Of Object)
        If Directory.Exists(dir) Then
            Dim di As New DirectoryInfo(dir)
            Dim counter As Integer = 1
            For Each fi As FileInfo In di.GetFiles("*.pdf")
                files.Add(New With {.ID = ++counter, .CreationTime = fi.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"), .Name = fi.Name, .Size = fi.Length, .Html = "<i class='k-icon fa fa-file-pdf-o'></i> " & fi.Name.Replace(fi.Extension, "")})
            Next
        End If
        Return Json(files, JsonRequestBehavior.AllowGet)
    End Function

    Public Function PDF(fileName As String) As ActionResult
        Dim f As String = Path.Combine(Server.MapPath("~/App_Data/UploadedFiles/Manuals"), fileName)
        Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName + ";")
        Dim filedata As Byte() = System.IO.File.ReadAllBytes(f)
        Return File(filedata, System.Net.Mime.MediaTypeNames.Application.Pdf)
    End Function
    '*******************************

    Public Function HasImageExtension(ByVal source As String) As Boolean
        Return (source.EndsWith(".png") OrElse source.EndsWith(".jpg") OrElse source.EndsWith(".bmp") OrElse source.EndsWith(".gif"))
    End Function

    'uložit soubor
    Public Function SaveFile(IDSpisu As Integer, files As IEnumerable(Of HttpPostedFileBase), obj As String) As ActionResult
        ' The Name of the Upload component is "files"
        Try
            Using db As New TRACEEntities
                Dim f As HttpPostedFileBase = files(0)
                Dim destination As String = Nothing
                If HasImageExtension(f.FileName) Then
                    Dim img_rr = db.tblRegisterRestrictions.FirstOrDefault(Function(e) e.Register = "rr_IMG_PATH")
                    If img_rr IsNot Nothing Then
                        If Not Directory.Exists(img_rr.Val) Then
                            Directory.CreateDirectory(img_rr.Val)
                        End If
                        destination = Path.Combine(img_rr.Val, f.FileName)
                    Else
                        Return Json(New With {.fullPath = "", .object = obj}, "text/plain")
                    End If
                Else
                    Dim doc_rr = db.tblRegisterRestrictions.FirstOrDefault(Function(e) e.Register = "rr_DOC_PATH")
                    If doc_rr IsNot Nothing Then
                        If Not Directory.Exists(doc_rr.Val) Then
                            Directory.CreateDirectory(doc_rr.Val)
                        End If
                        destination = Path.Combine(doc_rr.Val, f.FileName)
                    Else
                        Return Json(New With {.fullPath = "", .object = obj}, "text/plain")
                    End If
                End If

                If System.IO.File.Exists(destination) Then
                    System.IO.File.Delete(destination)
                End If

                f.SaveAs(destination)
                Return Json(New With {.fullPath = destination, .object = obj}, "text/plain")
            End Using
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("ERROR SaveFile = IDUser, " & IDUser, 40)
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return Json(New With {.fullPath = "", .object = obj}, "text/plain")
        End Try

    End Function

    Public Function RemoveFile(fileNames As String(), obj As String) As ActionResult
        ' The parameter of the Remove action must be called "fileNames"
        Dim folder = Encode(User.Identity.Name) & "/" & obj
        Dim physicalPath = Nothing
        Dim fileName = Nothing
        Dim dir As String = Nothing
        If fileNames IsNot Nothing Then
            For Each fullName In fileNames
                fileName = Path.GetFileName(fullName)
                dir = Server.MapPath("~/App_Data/UploadedFiles/" & folder)
                physicalPath = Path.Combine(dir, fileName)

                ' TODO: Verify user permissions

                ' The files are not actually removed in this demo
                ' System.IO.File.Delete(physicalPath);
                If System.IO.File.Exists(physicalPath) Then
                    System.IO.File.Delete(physicalPath)
                End If
            Next
        End If

        ' Return an empty string to signify success
        Return Json(New With {.fullPath = physicalPath, .object = obj}, "text/plain")
    End Function

    '<HttpPost> _
    'Public Sub TraceVBHTMLReplaceLanguage(<Http.FromBody> items As List(Of lngJson))
    '    Dim query = items.GroupBy(Function(e) e.value).Select(Function(e) e.ToList()).ToList()

    '    Dim vbhtml As String = Nothing
    '    Using sr As New IO.StreamReader(Server.MapPath("~/Views/Objects/OSNWriteObjects.vbhtml"))
    '        vbhtml = sr.ReadToEnd
    '        For Each i In query
    '            Dim v = i.First
    '            vbhtml = vbhtml.Replace(v.value, "@(Html.Raw(Language." & v.key & "))")
    '        Next
    '    End Using

    '    Using sw As New IO.StreamWriter(Server.MapPath("~/Views/Objects/__OSNWriteObjects.vbhtml"))
    '        sw.Write(vbhtml)
    '    End Using
    'End Sub

    Public Function CashInvoice(ID As Integer, IDMonthBilling As Integer) As ActionResult
        Try
            Dim xml = dbContext.sp_Get_Cash_Invoice(ID, IDMonthBilling).FirstOrDefault
            Dim xp As New XslProcessing
            Dim tables As New StringBuilder()
            Dim output As String = xp.XslTransfer(xml, Server.MapPath("~/App_Data/XSLTs/faktura.xslt"))
            Dim doc = New HtmlAgilityPack.HtmlDocument()
            doc.LoadHtml(output)

            Dim header = doc.DocumentNode.SelectSingleNode("//header")
            If header IsNot Nothing Then
                tables.Append(header.OuterHtml)
            End If

            Dim table = doc.DocumentNode.SelectNodes("//table")
            For Each tbl In table
                tables.Append(tbl.OuterHtml)
            Next

            Dim pp As New FileConverter
            Dim bytes = pp.HTMLtoPDF(tables.ToString(), "A4", False, New Drawing.Rectangle(25.0F, 25.0F, 25.0F, 25.0F))
            Response.AddHeader("Content-Disposition", "inline; filename=Faktura.pdf")
            Return File(bytes, "application/pdf")
        Catch ex As Exception
            Return Content("<p>" & ex.Message & ": " & Server.MapPath("~/App_Data/XSLTs/faktura.xslt") & "</p>")
        End Try
    End Function
End Class

'Partial Public Class lngJson
'    Public Property key As String
'    Public Property value As String
'End Class