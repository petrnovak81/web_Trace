Imports System.Security.Cryptography
Imports Trace.My.Resources
Imports Newtonsoft.Json
Imports System.Data.Objects

Public Class AccountController
    Inherits BaseController

    '
    ' GET: /Account

    <HttpGet>
    Function Login(ReturnUrl As String) As ActionResult
        'Dim password = GetMd5Hash(54022 & "Novodvorska321")
        'Dim password = GetMd5Hash(3 & "1")
        'Dim x = 0
        'If My.Settings.SkipLogin = 1 Then
        '    Using dbContext
        '        Dim password = GetMd5Hash("Agilo.2017")
        '        Dim dbUser = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = "developer@agilo.cz" And e.UserPWD = password)
        '        If dbUser IsNot Nothing Then
        '            CreateAuthTicket(dbUser.UserLogin, New tblUser With {
        '                                 .IDRole = dbUser.IDRole,
        '                                 .IDUser = dbUser.IDUser,
        '                                 .UserAccountEnabled = dbUser.UserAccountEnabled,
        '                                 .UserFirstName = dbUser.UserFirstName,
        '                                 .UserInternalID = dbUser.UserInternalID,
        '                                 .UserLastName = dbUser.UserLastName,
        '                                 .UserLogin = dbUser.UserLogin,
        '                                 .UserMobilePhone = dbUser.UserMobilePhone,
        '                                 .UserPWD = dbUser.UserPWD
        '                             })
        '        End If
        '    End Using

        '    Return RedirectToAction("Dashboard", "Home")
        'End If
        ViewBag.ReturnUrl = Nothing
        If Not ReturnUrl = "/" Then
            ViewBag.ReturnUrl = ReturnUrl
        End If
        If User.Identity.IsAuthenticated Then
            Dim getID = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = User.Identity.Name)
            If getID IsNot Nothing Then
                If String.IsNullOrWhiteSpace(ViewBag.ReturnUrl) Then
                    If getID.IDRole = 1 Then
                        Return RedirectToAction("Dashboard", "Administrator")
                    Else
                        Return RedirectToAction("Dashboard", "Home")
                    End If
                Else
                    If getID.IDRole = 1 Then
                        If ReturnUrl.Contains("Administrator") Then
                            Return Redirect(ViewBag.ReturnUrl)
                        Else
                            Return RedirectToAction("Dashboard", "Administrator")
                        End If
                    Else
                        If ReturnUrl.Contains("Home") Then
                            Return Redirect(ViewBag.ReturnUrl)
                        Else
                            Return RedirectToAction("Dashboard", "Home")
                        End If
                    End If
                End If
            End If
        End If
        Return View()
    End Function

    Sub CreateAuthTicket(TicketName As String, user As tblUser)
        Dim userData = JsonConvert.SerializeObject(user)
        Dim authTicket = New FormsAuthenticationTicket(1,
                                                               TicketName,
                                                               DateTime.Now,
                                                               DateTime.Now.AddYears(100),
                                                               True,
                                                               userData,
                                                               "/")
        Dim cookie As New HttpCookie(FormsAuthentication.FormsCookieName,
                                     FormsAuthentication.Encrypt(authTicket))
        Response.Cookies.Add(cookie)
    End Sub

    <HttpPost>
    Function Login(user As tblUser, Optional ForgottenPassword As Integer = 0, Optional ReturnUrl As String = Nothing) As ActionResult
        Try
            If ForgottenPassword > 0 And user.UserLogin IsNot Nothing Then
                Dim entity = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = user.UserLogin)
                If entity IsNot Nothing Then
                    changePasswordEmail(user.UserLogin, SystemMessages.forgPassEmailBody)
                Else
                    ModelState.AddModelError("LoginError", SystemMessages.PostUsesNotFound)
                End If
                Return View(user)
            End If
            If ModelState.IsValid Then
                Using dbContext
                    Dim getID = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = user.UserLogin)
                    If getID IsNot Nothing Then
                        Dim password = GetMd5Hash(getID.IDUser & user.UserPWD)
                        Dim dbUser As tblUser = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = user.UserLogin And e.UserPWD = password)
                        If dbUser IsNot Nothing Then
                            Dim uai = sp_Get_UserAccountInfo(dbUser.IDUser)
                            If uai.UserAccountEnabled And uai.BadLoginsBlock = False Then
                                CreateAuthTicket(dbUser.UserLogin, New tblUser With {
                                             .IDRole = dbUser.IDRole,
                                             .IDUser = dbUser.IDUser,
                                             .UserAccountEnabled = dbUser.UserAccountEnabled,
                                             .UserFirstName = dbUser.UserFirstName,
                                             .UserInternalID = dbUser.UserInternalID,
                                             .UserLastName = dbUser.UserLastName,
                                             .UserLogin = dbUser.UserLogin,
                                             .UserMobilePhone = dbUser.UserMobilePhone,
                                             .UserPWD = dbUser.UserPWD
                                         })
                                dbContext.sp_Do_AddUserLogin(dbUser.IDUser)
                                sp_Do_SuccessUserLogin(1)

                                If Not String.IsNullOrWhiteSpace(ReturnUrl) Then
                                    If getID.IDRole = 1 Then
                                        If ReturnUrl.Contains("Administrator") Then
                                            Return Redirect(ReturnUrl)
                                        Else
                                            Return RedirectToAction("Dashboard", "Administrator")
                                        End If
                                    Else
                                        If ReturnUrl.Contains("Home") Then
                                            Return Redirect(ReturnUrl)
                                        Else
                                            Return RedirectToAction("Dashboard", "Home")
                                        End If
                                    End If
                                Else
                                    If getID.IDRole = 1 Then
                                        Return RedirectToAction("Dashboard", "Administrator")
                                    Else
                                        Return RedirectToAction("Dashboard", "Home")
                                    End If
                                End If
                            Else
                                If uai.UserAccountEnabled = False Then
                                    ModelState.AddModelError("LoginError", SystemMessages.AccessIsNotAllowed)
                                ElseIf uai.BadLoginsBlock = True Then
                                    ModelState.AddModelError("LoginError", "<div class='validate-msg'><span class='k-icon k-i-warning'></span> Překročili jste povolený počet vadných přihlášení. Kontaktujte supervizora aby vám účet odemkl.</div>")
                                ElseIf uai.PasswordValidityEndBlock = True Then
                                    changePasswordEmail(getID.UserLogin, SystemMessages.forgPassEmailBody)
                                    ModelState.AddModelError("LoginError", "<div class='validate-msg'><span class='k-icon k-i-warning'></span> Platnost vašeho hesla vypršela. Na váš email (" & getID.UserLogin & ") jsme zaslali žádost ke změně hesla.</div>")
                                End If
                            End If
                        Else
                            sp_Do_SuccessUserLogin(0)
                            ModelState.AddModelError("LoginError", SystemMessages.LoginWrong)
                        End If
                    Else
                        sp_Do_SuccessUserLogin(0)
                        ModelState.AddModelError("LoginError", SystemMessages.UseNotFound)
                    End If
                End Using
            End If
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {
                        .Message = ex.Message,
                        .Params = {user},
                        .Status = 1
                    })
            ModelState.AddModelError("LoginError", ex.Message)
        End Try
        Return View(user)
    End Function

    Public Function sp_Do_NewUserPassword(IDUser As Integer, UserPWD As String) As Boolean
        Try
            Dim NotAllowedLastUsedPasswords As New ObjectParameter("NotAllowedLastUsedPasswords", GetType(Int32))
            Dim NewPWDIsOK As New ObjectParameter("NewPWDIsOK", GetType(Int32))
            Dim result = dbContext.sp_Do_NewUserPassword(IDUser, UserPWD, NewPWDIsOK)
            Return NewPWDIsOK.Value
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function sp_Do_SuccessUserLogin(SuccessLogin As Integer) As Boolean
        Try
            dbContext.sp_Do_SuccessUserLogin(IDUser, My.Settings.CountOfAllowedBadLogins, SuccessLogin)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Structure UserAccountInfo
        Dim UserAccountEnabled As Boolean
        Dim BadLoginsBlock As Boolean
        Dim PasswordValidityEndBlock As Boolean
    End Structure

    Public Function sp_Get_UserAccountInfo(id As Integer) As UserAccountInfo
        Try
            Dim uai As New UserAccountInfo
            Dim PasswordValidityDays = My.Settings.PasswordValidityDays
            Dim UserAccountEnabled As New ObjectParameter("UserAccountEnabled", GetType(Boolean))
            Dim BadLoginsBlock As New ObjectParameter("BadLoginsBlock", GetType(Boolean))
            Dim PasswordValidityEndBlock As New ObjectParameter("PasswordValidityEndBlock", GetType(Boolean))
            Dim result = dbContext.sp_Get_UserAccountInfo(id, PasswordValidityDays, UserAccountEnabled, BadLoginsBlock, PasswordValidityEndBlock)

            Dim _UserAccountEnabled = UserAccountEnabled.Value
            Dim _BadLoginsBlock = BadLoginsBlock.Value
            Dim _PasswordValidityEndBlock = PasswordValidityEndBlock.Value

            uai.UserAccountEnabled = _UserAccountEnabled
            uai.BadLoginsBlock = _BadLoginsBlock
            uai.PasswordValidityEndBlock = _PasswordValidityEndBlock

            Return uai
        Catch ex As Exception
            Return New UserAccountInfo
        End Try
    End Function

    Function LogOut(ReturnUrl As String)
        FormsAuthentication.SignOut()
        Return RedirectToAction("Login", New With {.ReturnUrl = returnUrl})
    End Function

    <Authorize> _
    Public Function UserManagement() As ActionResult
        Return View()
    End Function

    Public Function tblUser_Read() As ActionResult
        Try
            Dim u = dbContext.tblUsers.AsEnumerable().Select(Function(r) New tblUser With {
                                                              .IDRole = r.IDRole,
                                                              .IDUser = r.IDUser,
                                                              .UserFirstName = r.UserFirstName,
                                                              .UserLastName = r.UserLastName,
                                                              .UserLogin = r.UserLogin,
                                                              .UserMobilePhone = r.UserMobilePhone,
                                                              .UserAccountEnabled = r.UserAccountEnabled,
                                                              .PDFPWD = r.PDFPWD}).ToList
            Return Json(New ApiResult With {.Total = u.Count, .Data = u, .Msg = {"OK"}, .MsgType = "success"}, JsonRequestBehavior.AllowGet)
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Json(New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}, JsonRequestBehavior.AllowGet)
        End Try
    End Function

    Public Function tblUser_Update(users As IEnumerable(Of tblUser)) As ActionResult
        Try
            Dim results = New List(Of tblUser)

            If users IsNot Nothing AndAlso ModelState.IsValid Then
                For Each u In users
                    Dim entity = dbContext.tblUsers.FirstOrDefault(Function(e) e.IDUser = u.IDUser)
                    If entity IsNot Nothing Then
                        entity.UserAccountEnabled = u.UserAccountEnabled
                        entity.PDFPWD = u.PDFPWD

                        'sp_Do_NewUserPassword(u.PDFPWD)

                        dbContext.tblUsers.Attach(entity)
                        dbContext.Entry(entity).State = EntityState.Modified
                        dbContext.SaveChanges()
                    End If
                    results.Add(u)
                Next
            End If

            Return Json(New ApiResult With {.Total = results.Count, .Data = results, .Msg = {"OK"}, .MsgType = "success"}, JsonRequestBehavior.AllowGet)
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = users, .Status = 1})
            Return Json(New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}, JsonRequestBehavior.AllowGet)
        End Try
    End Function

    'Public Function tblUser_Create(users As IEnumerable(Of tblUser)) As ActionResult
    '    Try
    '        Dim results = New List(Of tblUser)

    '        If users IsNot Nothing AndAlso ModelState.IsValid Then
    '            For Each u In users
    '                u.UserPWD = GetMd5Hash(Now.ToString("yyyyMMddHHmmssff"))

    '                dbContext.tblUsers.Add(u)
    '                results.Add(u)
    '            Next

    '            dbContext.SaveChanges()

    '            For Each u In users
    '                changePasswordEmail(u.UserLogin, SystemMessages.newPassEmailBody)
    '            Next
    '        End If

    '        Return Json(New ApiResult With {.Total = results.Count, .Data = results, .Msg = {SystemMessages.NewUsersPostEmail}, .MsgType = "info"}, JsonRequestBehavior.AllowGet)
    '    Catch ex As Exception
    '        log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = users, .Status = 1})
    '        Return Json(New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}, JsonRequestBehavior.AllowGet)
    '    End Try
    'End Function

    'Public Function tblUser_Destroy(users As IEnumerable(Of tblUser)) As ActionResult
    '    Try
    '        If users.Any() Then
    '            For Each u In users
    '                Dim user = dbContext.tblUsers.FirstOrDefault(Function(e) e.IDUser = u.IDUser)
    '                If user IsNot Nothing Then
    '                    dbContext.tblUsers.Remove(user)
    '                End If
    '            Next
    '        End If
    '        dbContext.SaveChanges()
    '        Return Json(New ApiResult With {.Total = users.Count, .Data = users, .Msg = {"OK"}, .MsgType = "success"}, JsonRequestBehavior.AllowGet)
    '    Catch ex As Exception
    '        log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = users, .Status = 1})
    '        Return Json(New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}, JsonRequestBehavior.AllowGet)
    '    End Try
    'End Function

    Public Function tblRoles_Read() As ActionResult
        Dim d = dbContext.tblRoles.AsEnumerable().Select(Function(r) New With {
                                                              .value = r.IDRole,
                                                              .text = r.RoleName}).ToList
        Return Json(d, JsonRequestBehavior.AllowGet)
    End Function

    Public Function changePasswordEmail(UserLogin As String, Txt As String) As ActionResult
        Try
            Dim entity = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = UserLogin)
            If entity IsNot Nothing Then
                Dim request = String.Format("{0}://{1}{2}", HttpContext.Request.Url.Scheme, HttpContext.Request.Url.Authority, Url.Content("~"))
                'Dim request = String.Format("{0}://{1}", HttpContext.Request.Url.Scheme, HttpContext.Request.Url.Authority)
                Dim passUrl As String = request & "/Account/ChangePassword"
                Dim eSubject As String = My.Resources.SystemMessages.PassEmailSubject
                Dim href As String = passUrl & "?i=" & Encode(entity.IDUser) & "&d=" & Encode(Date.Now().ToString("yyyy-MM-dd HH:mm:ss"))
                Dim item As New NetMail.Options
                Dim html As String = Nothing
                Using sr As New IO.StreamReader(Server.MapPath("~/App_Data") & "/changepass.html")
                    item.To.Add(entity.UserLogin)
                    item.Subject = eSubject
                    item.DisplayName = "TRACE"

                    html = sr.ReadToEnd
                    html = html.Replace("${header}", "<a href='" & request & "' target='_blank'>TRACE</a>")
                    html = html.Replace("${body}", Txt)
                    html = html.Replace("${href}", href)
                    html = html.Replace("${button}", My.Resources.SystemMessages.PassEmailButton)

                    item.Body = html
                    EmailModule.Send(item)
                End Using
                Return Json(New ApiResult With {.Total = Nothing, .Data = Nothing, .Msg = {SystemMessages.PostEmailUser}, .MsgType = "info"}, JsonRequestBehavior.AllowGet)
            Else
                Return Json(New ApiResult With {.Total = Nothing, .Data = Nothing, .Msg = {SystemMessages.UseNotFound}, .MsgType = "warning"}, JsonRequestBehavior.AllowGet)
            End If
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {UserLogin}, .Status = 1})
            Return Json(New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}, JsonRequestBehavior.AllowGet)
        End Try
    End Function

    Public Function ChangePassword(i As String, d As String) As ActionResult
        Dim user As tblUser = Nothing
        Try
            Dim IDUser As Integer = CInt(Decode(i))
            Dim Datum As Date = CDate(Decode(d))
            Dim diff As Long = DateDiff(DateInterval.Day, Datum, Date.Today)
            If diff < 4 Then
                user = dbContext.tblUsers.FirstOrDefault(Function(e) e.IDUser = IDUser)
            End If
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {i, d}, .Status = 1})
        End Try
        Return View(user)
    End Function

    <HttpPost>
    Public Function ChangePassword(IDUser As Integer, Pass1 As String, Pass2 As String) As ActionResult
        Dim NewPWDIsOK = sp_Do_NewUserPassword(IDUser, GetMd5Hash(IDUser & Pass2))
        If NewPWDIsOK Then
            FormsAuthentication.SignOut()
            Return RedirectToAction("Login")
        Else
            Return View(New tblUser)
        End If
    End Function
End Class