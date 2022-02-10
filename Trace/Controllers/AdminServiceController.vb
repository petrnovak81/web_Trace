Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.OData.Query
Imports System.Data.Objects
Imports Newtonsoft.Json
Imports System.IO

<Authorize(Roles:="1")>
Public Class AdminServiceController
    Inherits ApiController
    Public EmailModule As NetMail
    Public dbContext As New TRACEEntities
    Public IDUser As Integer = 0
    Public log As New AppLog

    Sub New()
        Try
            If User.Identity.IsAuthenticated Then
                Dim cookieName As String = FormsAuthentication.FormsCookieName
                Dim authCookie As HttpCookie = HttpContext.Current.Request.Cookies(cookieName)
                Dim data = FormsAuthentication.Decrypt(authCookie.Value)
                Dim u = JsonConvert.DeserializeObject(Of tblUser)(CStr(data.UserData))
                If u IsNot Nothing Then
                    IDUser = u.IDUser
                End If
            End If
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {}, .Status = 1})
        End Try

        Try
            EmailModule = New NetMail(My.Settings.emailSMTP,
                                My.Settings.emailPORT,
                                False,
                                My.Settings.emailUserEmail,
                                My.Settings.emailUserPass,
                                True,
                                True)
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {}, .Status = 1})
        End Try
    End Sub

    <HttpGet>
    Public Function vwAD_GetPage(IDSpisu As Integer, PageSize As Integer) As Integer
        Try
            Dim result = dbContext.vwAD_Basic.ToList
            Dim find = result.FirstOrDefault(Function(e) e.IDSpisu = IDSpisu)
            Dim take = result.IndexOf(find)
            Dim page = 0
            If (take > 100) Then
                page = CInt(take / PageSize)
            End If
            Return page
        Catch ex As Exception
            Return 1
        End Try
    End Function

    <HttpGet>
    Public Function GetInspectors() As Object
        Try

            Dim result = dbContext.tblUsers.Where(Function(e) e.IDRole = 2).Select(Function(e) New With {.value = e.IDUser, .text = (e.UserLastName & " " & e.UserFirstName)}).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function tblRegisterRestrictions(Register As String) As Object
        Try
            Dim result = dbContext.tblRegisterRestrictions.Where(Function(e) e.Register = Register).ToList
            Return New ApiResult With {.Total = 0, .Data = result, .Msg = {Register}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    'Filtry pres stavy****************************************************************************
    <HttpGet>
    Public Function vwAD_Basic(options As ODataQueryOptions(Of vwAD_Basic)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_Basic) = dbContext.vwAD_Basic.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_Basic)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    'Filtry OSN****************************************************************************
    <HttpGet>
    Public Function vwAD_F21_WithoutFV(options As ODataQueryOptions(Of vwAD_F21_WithoutFV)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F21_WithoutFV) = dbContext.vwAD_F21_WithoutFV.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F21_WithoutFV)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F22_WithFirstFV(options As ODataQueryOptions(Of vwAD_F22_WithFirstFV)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F22_WithFirstFV) = dbContext.vwAD_F22_WithFirstFV.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F22_WithFirstFV)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F23_WithSecondFV(options As ODataQueryOptions(Of vwAD_F23_WithSecondFV)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F23_WithSecondFV) = dbContext.vwAD_F23_WithSecondFV.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F23_WithSecondFV)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F24_WithMoreThanSecond(options As ODataQueryOptions(Of vwAD_F24_WithMoreThanSecond)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F24_WithMoreThanSecond) = dbContext.vwAD_F24_WithMoreThanSecond.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F24_WithMoreThanSecond)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    'Filtry pres urgence****************************************************************************
    <HttpGet>
    Public Function vwAD_F31_WithUrgencyOnly(options As ODataQueryOptions(Of vwAD_F31_WithUrgencyOnly)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F31_WithUrgencyOnly) = dbContext.vwAD_F31_WithUrgencyOnly.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F31_WithUrgencyOnly)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F32_NotYetAcceptedAfter2Days(options As ODataQueryOptions(Of vwAD_F32_NotYetAcceptedAfter2Days)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F32_NotYetAcceptedAfter2Days) = dbContext.vwAD_F32_NotYetAcceptedAfter2Days.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F32_NotYetAcceptedAfter2Days)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F33_NotYetAccepted(options As ODataQueryOptions(Of vwAD_F33_NotYetAccepted)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F33_NotYetAccepted) = dbContext.vwAD_F33_NotYetAccepted.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F33_NotYetAccepted)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F34_NewReturned(options As ODataQueryOptions(Of vwAD_F34_NewReturned)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F34_NewReturned) = dbContext.vwAD_F34_NewReturned.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F34_NewReturned)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F35_WithoutPlanFV(options As ODataQueryOptions(Of vwAD_F35_WithoutPlanFV__dodelat)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F35_WithoutPlanFV__dodelat) = dbContext.vwAD_F35_WithoutPlanFV__dodelat.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F35_WithoutPlanFV__dodelat)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F36_DateFVOver(options As ODataQueryOptions(Of vwAD_F36_DateFVOver)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F36_DateFVOver) = dbContext.vwAD_F36_DateFVOver.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F36_DateFVOver)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F37_MaxFVDateOver(options As ODataQueryOptions(Of vwAD_F37_MaxFVDateOver)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F37_MaxFVDateOver) = dbContext.vwAD_F37_MaxFVDateOver.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F37_MaxFVDateOver)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F38_Urgency58(options As ODataQueryOptions(Of vwAD_F38_Urgency58)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F38_Urgency58) = dbContext.vwAD_F38_Urgency58.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F38_Urgency58)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F39_AgreementCanceled(options As ODataQueryOptions(Of vwAD_F39_AgreementCanceled)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F39_AgreementCanceled) = dbContext.vwAD_F39_AgreementCanceled.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F39_AgreementCanceled)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F310_AgrCancOver5Days(options As ODataQueryOptions(Of vwAD_F310_AgrCancOver5Days)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F310_AgrCancOver5Days) = dbContext.vwAD_F310_AgrCancOver5Days.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F310_AgrCancOver5Days)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F311_DateLapseUnder6M(options As ODataQueryOptions(Of vwAD_F311_DateLapseUnder6M)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F311_DateLapseUnder6M) = dbContext.vwAD_F311_DateLapseUnder6M.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F311_DateLapseUnder6M)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F312_ReturToCredUnder2M(options As ODataQueryOptions(Of vwAD_F312_ReturToCredUnder2M)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F312_ReturToCredUnder2M) = dbContext.vwAD_F312_ReturToCredUnder2M.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F312_ReturToCredUnder2M)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F313_DPlanOverDMax(options As ODataQueryOptions(Of vwAD_F313_DPlanOverDMax)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F313_DPlanOverDMax) = dbContext.vwAD_F313_DPlanOverDMax.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F313_DPlanOverDMax)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F314_UrgCashToCreditor(options As ODataQueryOptions(Of vwAD_F314_UrgCashToCreditor)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F314_UrgCashToCreditor) = dbContext.vwAD_F314_UrgCashToCreditor.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F314_UrgCashToCreditor)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    'Filtry pres uzavrene****************************************************************************
    <HttpGet>
    Public Function vwAD_F41_ClosedAll(options As ODataQueryOptions(Of vwAD_F41_ClosedAll)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F41_ClosedAll) = dbContext.vwAD_F41_ClosedAll.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F41_ClosedAll)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F42_ClosedBySuper(options As ODataQueryOptions(Of vwAD_F42_ClosedBySuper)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F42_ClosedBySuper) = dbContext.vwAD_F42_ClosedBySuper.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F42_ClosedBySuper)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F43_ClosedFromProcess(options As ODataQueryOptions(Of vwAD_F43_ClosedFromProcess)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F43_ClosedFromProcess) = dbContext.vwAD_F43_ClosedFromProcess.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F43_ClosedFromProcess)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F44_ConditionedClose(options As ODataQueryOptions(Of vwAD_F44_ConditionedClose)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F44_ConditionedClose) = dbContext.vwAD_F44_ConditionedClose.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F44_ConditionedClose)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_F45_InReturnRequest(options As ODataQueryOptions(Of vwAD_F45_InReturnRequest)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_F45_InReturnRequest) = dbContext.vwAD_F45_InReturnRequest.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_F45_InReturnRequest)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    '****************************************************************************************************************

    <HttpGet>
    Public Function vwAD_DLBasic(options As ODataQueryOptions(Of vwAD_DLBasic)) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_DLBasic) = dbContext.vwAD_DLBasic.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_DLBasic)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_DLBasicSub(options As ODataQueryOptions(Of vwAD_DLBasicSub), IDSpisyOsoby As Integer) As Object
        Try
            Dim queryable As IQueryable(Of vwAD_DLBasicSub) = dbContext.vwAD_DLBasicSub.Where(Function(e) e.IDSpisyOsoby = IDSpisyOsoby).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_DLBasicSub)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function SpisyIDSpisyOsoby(IDSpisyOsoby As Integer) As Object
        Try
            Dim model = dbContext.vwAD_Basic.Where(Function(e) e.IDSpisyOsoby = IDSpisyOsoby).ToList
            Return New ApiResult With {.Total = model.Count, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function SpisyDLSubPodleIDSpisyOsoby(IDSpisyOsoby As Integer) As Object
        Try
            Dim model = dbContext.vwAD_DLBasicSub.Where(Function(e) e.IDSpisyOsoby = IDSpisyOsoby).ToList
            Return New ApiResult With {.Total = model.Count, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vw_ListUrgAndRemind(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.vw_ListUrgAndRemind.Where(Function(e) e.IDCase = iDSpisu).OrderBy(Function(e) e.Radek).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_2_Radio1(iDSpisu As Nullable(Of Integer), comment As String) As Object
        Try
            Dim lastLapseMsg = New ObjectParameter("LastLapseMsg", GetType(String))
            dbContext.sp_Do_Super2_3_2_Radio1(iDSpisu, comment, lastLapseMsg)
            If lastLapseMsg.Value IsNot Nothing Then
                Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
            Else
                Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {lastLapseMsg.Value}, .MsgType = "error"}
            End If
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, comment}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_2_Radio2(iDSpisu As Nullable(Of Integer), comment1 As String, dMax As Nullable(Of Date)) As Object
        Try
            dbContext.sp_Do_Super2_3_2_Radio2(iDSpisu, comment1, dMax)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, comment1, dMax}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_2_Radio3(iDSpisu As Nullable(Of Integer), comment1 As String, rr_CaseNextActivity As Nullable(Of Short), commentJine As String, datumDeadLine As Nullable(Of Date)) As Object
        Try
            dbContext.sp_Do_Super2_3_2_Radio3(iDSpisu, IDUser, comment1, rr_CaseNextActivity, commentJine, datumDeadLine)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, IDUser, comment1, rr_CaseNextActivity, commentJine, datumDeadLine}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_8_Radio1(iDSpisu As Nullable(Of Integer), comment As String) As Object
        Try
            Dim lastLapseMsg = New ObjectParameter("LastLapseMsg", GetType(String))
            dbContext.sp_Do_Super2_3_8_Radio1(iDSpisu, comment, lastLapseMsg)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, comment}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_8_Radio2(iDSpisu As Nullable(Of Integer), comment1 As String, dMax As Nullable(Of Date)) As Object
        Try
            dbContext.sp_Do_Super2_3_8_Radio2(iDSpisu, comment1, dMax)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, comment1, dMax}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_8_Radio3(iDSpisu As Nullable(Of Integer), comment1 As String, rr_CaseNextActivity As Nullable(Of Short), commentJine As String, datumDeadLine As Nullable(Of Date)) As Object
        Try
            dbContext.sp_Do_Super2_3_8_Radio3(iDSpisu, IDUser, comment1, rr_CaseNextActivity, commentJine, datumDeadLine)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, IDUser, comment1, rr_CaseNextActivity, commentJine, datumDeadLine}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_1(iDSpisu As Nullable(Of Integer), comment As String) As Object
        Try
            dbContext.sp_Do_Super2_3_1(iDSpisu, comment)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, comment}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_3_Radio1(iDSpisu As Nullable(Of Integer)) As Object
        Try
            dbContext.sp_Do_Super2_3_3_Radio1(iDSpisu)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_3_Radio2(iDSpisu As Nullable(Of Integer), comment As String) As Object
        Try
            dbContext.sp_Do_Super2_3_3_Radio2(iDSpisu, comment)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, comment}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_4(iDSpisu As Nullable(Of Integer), d1MAX As Nullable(Of Date), comment As String) As Object
        Try
            Dim Output As New ObjectParameter("LL_LastLapse", GetType(Int32))
            dbContext.sp_Do_Super2_3_4(iDSpisu, d1MAX, comment, Output)
            If Not IsDBNull(Output.Value) AndAlso Output.Value > 0 Then
                Dim LL_LastLapse As Integer = Output.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {msg.LastLapseMsg}, .MsgType = "error"}
                End If
            End If
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, d1MAX, comment}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Do_Super2_3_5(iDSpisu As Nullable(Of Integer), dNMAX As Nullable(Of Date), comment As String) As Object
        Try
            Dim Output As New ObjectParameter("LL_LastLapse", GetType(Int32))
            dbContext.sp_Do_Super2_3_5(iDSpisu, dNMAX, comment, Output)
            If Not IsDBNull(Output.Value) AndAlso Output.Value > 0 Then
                Dim LL_LastLapse As Integer = Output.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {msg.LastLapseMsg}, .MsgType = "error"}
                End If
            End If
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, dNMAX, comment}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_1() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_1.ToList
            Return result
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_1_Detail() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_1_Detail.ToList
            Return result
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_2(iDUser As Integer) As Object
        Try
            Dim result = dbContext.sp_DSHB_1_2(iDUser).ToList
            Return result
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDUser}, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_3() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_3.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_3_Detail(Poradi As Short) As Object
        Try
            Dim result = dbContext.sp_DSHB_1_3_Detail(Poradi).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_4() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_4.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_4_Detail(iDUser As Integer) As Object
        Try
            Dim result = dbContext.sp_DSHB_1_4_Detail(iDUser).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDUser}, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_5() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_5.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_6() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_6.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_7() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_7.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_7_Detail() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_7_Detail.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_8() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_8.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_8_Detail(iDOrder As Integer) As Object
        Try
            Dim result = dbContext.sp_DSHB_1_8_Detail(iDOrder).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDOrder}, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_9() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_9.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_9_Detail_1() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_9_Detail_1.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_9_Detail_2() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_9_Detail_2.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_10() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_10.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_10_Detail(IDUser As Integer) As Object
        Try
            Dim result = dbContext.sp_DSHB_1_10_Detail(IDUser).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_11() As Object
        Try
            Dim result = dbContext.sp_SV_DSHB_Get_SumFee.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_11_Detail(month As Short, year As Short) As Object
        Try
            Dim result = dbContext.sp_SV_DSHB_Get_SumFeeDetail(month, year).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_12() As Object
        Try
            Return dbContext.sp_SV_DSHB_Get_SumFeeOverIP.ToList
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object(), .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_12_Detail(id As Integer) As Object
        Try
            Return dbContext.sp_SV_DSHB_Get_SumFeeDetailOverIP(id).ToList
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {id}, .Status = 1})
            Return Nothing
        End Try
    End Function


    <HttpGet>
    Public Function sp_DSHB_1_13() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_13.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_13_Detail() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_13_Detail.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_14() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_14.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_14_Detail1() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_14Detail1.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_14_Detail2() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_14Detail2.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_14_Detail3() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_14Detail3.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_1_14_Detail4() As Object
        Try
            Dim result = dbContext.sp_DSHB_1_14Detail4.ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_Fill() As Object
        Try
            dbContext.sp_DSHB_Fill()
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_LastFill() As Object
        Try
            Dim result = dbContext.sp_DSHB_LastFill.ToList.First
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function tblConstant_source1() As Object
        Try
            Dim result = dbContext.tblConstants.Where(Function(e) e.Sada = 1 Or e.Sada = 2 And e.Sada IsNot Nothing).OrderBy(Function(e) e.Sada).ThenBy(Function(e) e.IDOrder).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function tblConstant_source2() As Object
        Try
            Dim result = dbContext.tblConstants.Where(Function(e) e.Sada <> 1 And e.Sada <> 2 And e.Sada IsNot Nothing).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpPost>
    Public Function tblConstant_Update(constants As Constants) As Object
        Try
            Using dbContext
                Dim item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "B2B")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.B2B
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "B2C")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.B2C
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "B2CProvident")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.B2CProvident
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "DaysForShowClosed")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.DaysForShowClosed
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "DMaxAfterBrAgreement")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.DMaxAfterBrAgreement
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "FirstFVCommission")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.FirstFVCommission
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "MaxDaysForFirstFV")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.MaxDaysForFirstFV
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "MaxDaysForNextFV")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.MaxDaysForNextFV
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "MaxDaysForReceiveCase")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.MaxDaysForReceiveCase
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "RedemOver24Month")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.RedemOver24Month
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "RedemUnder24Month")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.RedemUnder24Month
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "WaitAfterBrAgreement")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.WaitAfterBrAgreement
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If

                item = dbContext.tblConstants.FirstOrDefault(Function(e) e.ConstantName = "PACommission")
                If item IsNot Nothing Then
                    item.ConstantValue = constants.PACommission
                    dbContext.Entry(item).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If
            End Using

            Return New With {.msg = "OK"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {constants}, .Status = 1})
            Return New With {.msg = ex.Message}
        End Try
    End Function

    Function SourcePripominkyText(e As vwAD_Basic)
        Dim acc = If(e.ACC = Nothing, "", e.ACC)
        Dim jmeno = If(e.PersSurname = Nothing, "", e.PersSurname) & " " & If(e.PersName = Nothing, "", e.PersName)
        Dim veritel = If(e.CreditorAlias = Nothing, "", e.CreditorAlias)
        Return acc & ", " & jmeno & ", " & veritel
    End Function

    <HttpGet>
    Public Function SourcePripominky(type As Integer) As Object
        Try
            Using dbContext
                Select Case type
                    Case 1
                        Return dbContext.vwAD_Basic.Select(Function(e) New With {.text = e.Inspector, .IDUser = e.IDUser}).Distinct().ToList
                    Case 2
                        Return dbContext.vwAD_Basic.Select(Function(e) New With {.text = If(e.ACC = Nothing, "", e.ACC) &
                                                               If(e.PersSurname = Nothing, "", ", " & e.PersSurname) &
                                                               If(e.PersName = Nothing, "", " " & e.PersName) &
                                                               If(e.CreditorAlias = Nothing, "", ", " & e.CreditorAlias), .IDSpisu = e.IDSpisu}).ToList
                    Case 3
                        Return dbContext.vwAD_Basic.Select(Function(e) New With {.text = If(e.ACC = Nothing, "", e.ACC) &
                                                               If(e.PersSurname = Nothing, "", ", " & e.PersSurname) &
                                                               If(e.PersName = Nothing, "", " " & e.PersName) &
                                                               If(e.CreditorAlias = Nothing, "", ", " & e.CreditorAlias), .IDSpisyOsoby = e.IDSpisyOsoby}).Distinct().ToList
                End Select
            End Using
            Return Nothing
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {type}, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_AddReminder(reminderDeadline As Nullable(Of Date), reminderSubject As String, reminderTxt As String, reminderJobForUID As Nullable(Of Integer), iDSpisu As Nullable(Of Integer), iDSpisyOsoby As Nullable(Of Integer), awaitAnswer As Nullable(Of Boolean)) As Object
        Try
            dbContext.sp_Do_AddReminder(IDUser, reminderJobForUID, reminderDeadline, reminderSubject, reminderTxt, iDSpisu, iDSpisyOsoby, awaitAnswer, Nothing)
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser, reminderJobForUID, reminderDeadline, reminderSubject, reminderTxt, iDSpisu, iDSpisyOsoby, awaitAnswer}, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet>
    Public Function sp_Get_GlobalFind(find As String) As Object
        Try
            Dim result = dbContext.sp_Get_GlobalFind(find, 0).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {find, IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = New Object() {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vw_CampCompare_GPS_Date(options As ODataQueryOptions(Of vw_CampCompare_GPS_Date)) As Object
        Try
            Dim queryable As IQueryable(Of vw_CampCompare_GPS_Date) = dbContext.vw_CampCompare_GPS_Date.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vw_CampCompare_GPS_Date)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_DeleteDocument(iDSpisyDocument As Nullable(Of Integer)) As Object
        Try

            Dim filePath As New ObjectParameter("FilePath", GetType(String))
            dbContext.sp_Do_DeleteDocument(iDSpisyDocument, filePath)
            If Not IsDBNull(filePath.Value) Then
                Dim fpath = filePath.Value
                If System.IO.File.Exists(fpath) Then
                    System.IO.File.Delete(fpath)
                End If
            End If

            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyDocument}, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet>
    Public Function sp_Get_SV_CashRevision(options As ODataQueryOptions(Of sp_Get_SV_CashRevision_Result1)) As Object
        Try
            Dim data = dbContext.sp_Get_SV_CashRevision.ToList
            Dim queryable As IQueryable(Of sp_Get_SV_CashRevision_Result1) = data.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of sp_Get_SV_CashRevision_Result1)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Get_SV_NonPairedPayments(iDSpisu As Integer) As Object
        Try
            Dim result = dbContext.sp_Get_SV_NonPairedPayments(iDSpisu).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_SV_ChangeCash(iDCashPayment As Integer, iDSpisyPlatbyDosle As Integer) As Boolean
        Try
            dbContext.sp_Do_SV_ChangeCash(iDCashPayment, iDSpisyPlatbyDosle)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    <HttpGet>
    Public Function sp_Get_Cash_ValidateFee(options As ODataQueryOptions(Of sp_Get_Cash_ValidateFee_Result)) As Object
        Try
            Dim params As NameValueCollection = HttpUtility.ParseQueryString(options.Request.RequestUri.Query)
            Dim type As Integer = params("type")

            Dim data = dbContext.sp_Get_Cash_ValidateFee(type).ToList
            Dim queryable As IQueryable(Of sp_Get_Cash_ValidateFee_Result) = data.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of sp_Get_Cash_ValidateFee_Result)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_SV_AddFee(iDUser As Nullable(Of Integer),
                                    iDSpisu As Nullable(Of Integer),
                                    rr_TypeFee As Nullable(Of Short),
                                    fee As Nullable(Of Single),
                                    sVApproved As Nullable(Of Boolean),
                                    aCC As String,
                                    paymentDate As Nullable(Of Date),
                                    persSurname As String,
                                    persName As String,
                                    creditorAlias As String) As Boolean
        Try
            dbContext.sp_Do_SV_AddFee(iDUser, iDSpisu, rr_TypeFee, fee, sVApproved, aCC, paymentDate, persSurname, persName, creditorAlias)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Get_CreditorsCombo() As Object
        Try
            Dim data = dbContext.sp_Get_CreditorsCombo().ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_Cash_ValidateFee(iDFee As Integer, fee As Single, sVApproved As Boolean) As Boolean
        Try
            dbContext.sp_Do_Cash_ValidateFee(iDFee, fee, sVApproved)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    <HttpGet>
    Public Function vw_Users() As Object
        Try
            Dim result = dbContext.vw_Users.ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Get_SV_CashListACC(ID As Integer) As Object
        Try
            Dim result = dbContext.sp_Get_SV_CashListACC(ID).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {ID}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Get_Cash_MissingCashDocNumber(ID As Integer) As Object
        Try
            Dim result = dbContext.sp_Get_Cash_MissingCashDocNumber(ID).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {ID}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_Cash_GenerateCanceledDocNumber(ID As Integer, cashDocNumber As Integer) As Boolean
        Try
            dbContext.sp_Do_Cash_GenerateCanceledDocNumber(ID, cashDocNumber)
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {ID}, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_SV_Cash_UpdateDateOnCentrale(iDMonthBilling As Integer, datum As Date) As Boolean
        Try
            dbContext.sp_Do_SV_Cash_UpdateDateOnCentrale(iDMonthBilling, datum)
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDMonthBilling, datum}, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet>
    Public Function sp_Get_SV_ListBilling() As Object
        Try
            Dim result = dbContext.sp_Get_SV_ListBilling().ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Get_DMAX(iDSpisu As Integer) As Object
        Try
            Dim dMaxOsn As New ObjectParameter("DMaxOsn", GetType(DateTime))
            dbContext.sp_Get_DMAX(iDSpisu, dMaxOsn)
            If dMaxOsn.Value() IsNot Nothing Then
                Return New With {.DMax = dMaxOsn.Value()}
            End If
            Return New With {.DMax = Nothing}
        Catch ex As Exception
            Return New With {.DMax = Nothing}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_SV_ChangeAmountOnCentrale(iDCashPayment As Integer, amount As Double) As Object
        Try
            dbContext.sp_Do_SV_ChangeAmountOnCentrale(iDCashPayment, amount)
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function vwAD_BasicNonAccepted(options As ODataQueryOptions(Of vwAD_BasicNonAccepted)) As Object
        Try
            Dim data = dbContext.vwAD_BasicNonAccepted.ToList
            Dim queryable As IQueryable(Of vwAD_BasicNonAccepted) = data.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwAD_BasicNonAccepted)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function vw_CreditorTemplates(options As ODataQueryOptions(Of vw_CreditorTemplates)) As Object
        Try
            Dim data = dbContext.vw_CreditorTemplates.ToList
            Dim queryable As IQueryable(Of vw_CreditorTemplates) = data.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vw_CreditorTemplates)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function tmpFiles() As Object
        Try
            Dim d = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Templates")
            Dim di As New DirectoryInfo(d)
            Dim l As List(Of FileInfo) = di.GetFiles("*.xslt").ToList
            Dim result = l.Select(Function(e) New With {.text = e.Name, .value = l.IndexOf(e)}).ToList
            Return New ApiResult With {.Total = l.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_SV_CreditorTemplateEdit(iDCreditor As Integer, rr_TemplateType As String, templateFileName As String) As Object
        Try
            dbContext.sp_SV_CreditorTemplateEdit(iDCreditor, rr_TemplateType, templateFileName)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Get_IDSpisuByACC(aCC As String) As Object
        Try
            Dim iDSpisu = New ObjectParameter("IDSpisu", GetType(Integer))
            Dim lL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Integer))
            Dim lastLapseText = New ObjectParameter("LastLapseText", GetType(String))
            dbContext.sp_Get_IDSpisuByACC(aCC, iDSpisu, lL_LastLapse, lastLapseText)
            Return New With {.error = lastLapseText.Value, .id = iDSpisu.Value}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Return New With {.error = ex.Message, .id = 0}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function sp_Run_3xand5xto40(iDSpisu As Nullable(Of Integer), aCC As String) As Object
        Try
            Dim lL_LastLapse As New ObjectParameter("LL_LastLapse", GetType(Integer))
            dbContext.sp_Run_3xand5xto40(iDSpisu, aCC, lL_LastLapse)
            If lL_LastLapse.Value > 0 Then
                Dim ll = CInt(lL_LastLapse.Value)
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = ll)
                If msg IsNot Nothing Then
                    Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {aCC & " " & msg.LastLapseMsg}, .MsgType = "error"}
                End If
            End If
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Overridable Function AGsp_GetCommentInspektoraWhenFileToClose(iDSpisu As Nullable(Of Integer)) As String
        Try
            Dim commentInsp As New ObjectParameter("CommentInsp", GetType(Integer))
            dbContext.AGsp_GetCommentInspektoraWhenFileToClose(iDSpisu, commentInsp)
            Return commentInsp.Value
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Class
