Imports System.Web.Http
Imports Microsoft.Data.OData.Query.SemanticAst
Imports System.Web.Http.OData.Query
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Infrastructure
Imports System.Data.Objects
Imports Newtonsoft.Json
Imports System.IO
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Net

Public Class ApiResult
    Public Property Total As Integer
    Public Property Data As Object
    Public Property Msg As String()
    Public Property MsgType As String
    Public Property ReturnValue As Object
End Class

'<Authorize> _
Public Class ServiceController
    Inherits ApiController

    Public EmailModule As NetMail
    Public dbContext As New TRACEEntities
    Public IDUser As Integer = 0
    Public log As New AppLog

    Function Get_ErrorLog() As Object
        Try
            Dim f = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/AppLog.xml")
            If File.Exists(f) Then
                Dim doc As XDocument = XDocument.Load(f)
                Return doc
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

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

    '********************************************************************
    'A1 section 
    '********************************************************************
    <HttpGet> _
    Public Function vwA1_Novy(options As ODataQueryOptions(Of vwA1_Novy)) As Object
        Try
            Dim queryable As IQueryable(Of vwA1_Novy) = dbContext.vwA1_Novy.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(Queryable), IEnumerable(Of vwA1_Novy)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwA1_NovyPodleIDSpisyOsoby(IDSpisyOsoby As Integer) As Object
        Try
            Dim model = dbContext.vwA1_Novy.Where(Function(e) e.IDUser = IDUser And e.IDSpisyOsoby = IDSpisyOsoby).ToList
            Return New ApiResult With {.Total = model.Count, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwA1_OSN(options As ODataQueryOptions(Of vwA1_OSN)) As Object
        Try
            Dim queryable As IQueryable(Of vwA1_OSN) = dbContext.vwA1_OSN.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA1_OSN)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwA1_OSNPodleIDSpisyOsoby(IDSpisyOsoby As Integer) As Object
        Try
            Dim model = dbContext.vwA1_OSN.Where(Function(e) e.IDUser = IDUser And e.IDSpisyOsoby = IDSpisyOsoby).ToList
            Return New ApiResult With {.Total = model.Count, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwA1_Dohody(options As ODataQueryOptions(Of vwA1_Dohody)) As Object
        Try
            Dim queryable As IQueryable(Of vwA1_Dohody) = dbContext.vwA1_Dohody.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA1_Dohody)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function vwA1_KeZprac(options As ODataQueryOptions(Of vwA1_KeZprac)) As Object
        Try
            Dim queryable As IQueryable(Of vwA1_KeZprac) = dbContext.vwA1_KeZprac.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA1_KeZprac)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function vwA1_Finished(options As ODataQueryOptions(Of vwA1_Finished)) As Object
        Try
            Dim queryable As IQueryable(Of vwA1_Finished) = dbContext.vwA1_Finished.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA1_Finished)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    '********************************************************************
    'A2 section 
    '********************************************************************
    <HttpGet> _
    Public Function vwA2_DLNovy(options As ODataQueryOptions(Of vwA2_DLNovy)) As Object
        Try
            Dim queryable As IQueryable(Of vwA2_DLNovy) = dbContext.vwA2_DLNovy.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA2_DLNovy)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function vwA2_DLNovySub(options As ODataQueryOptions(Of vwA2_DLNovySub), IDSpisyOsoby As Integer) As Object
        Try
            Dim queryable As IQueryable(Of vwA2_DLNovySub) = dbContext.vwA2_DLNovySub.Where(Function(e) e.IDSpisyOsoby = IDSpisyOsoby And e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA2_DLNovySub)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser, IDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwA2_DLNovySubPodleIDSpisyOsoby(IDSpisyOsoby As Integer) As Object
        Try
            Dim model = dbContext.vwA2_DLNovySub.Where(Function(e) e.IDUser = IDUser And e.IDSpisyOsoby = IDSpisyOsoby).ToList
            Return New ApiResult With {.Total = model.Count, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    '********************************************************************
    <HttpGet> _
    Public Function vwA2_DLOSN(options As ODataQueryOptions(Of vwA2_DLOSN)) As Object
        Try
            Dim x = dbContext.vwA2_DLOSN.Where(Function(e) e.IDUser = IDUser).ToList
            Dim queryable As IQueryable(Of vwA2_DLOSN) = dbContext.vwA2_DLOSN.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA2_DLOSN)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function vwA2_DLOSNSub(options As ODataQueryOptions(Of vwA2_DLOSNSub), IDSpisyOsoby As Integer) As Object
        Try
            Dim queryable As IQueryable(Of vwA2_DLOSNSub) = dbContext.vwA2_DLOSNSub.Where(Function(e) e.IDSpisyOsoby = IDSpisyOsoby And e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA2_DLOSNSub)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser, IDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwA2_DLOSNSubPodleIDSpisyOsoby(IDSpisyOsoby As Integer) As Object
        Try
            Dim model = dbContext.vwA2_DLOSNSub.Where(Function(e) e.IDUser = IDUser And e.IDSpisyOsoby = IDSpisyOsoby).ToList
            Return New ApiResult With {.Total = model.Count, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    '********************************************************************
    <HttpGet> _
    Public Function vwA2_DLDohody(options As ODataQueryOptions(Of vwA2_DLDohody)) As Object
        Try
            Dim queryable As IQueryable(Of vwA2_DLDohody) = dbContext.vwA2_DLDohody.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA2_DLDohody)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function vwA2_DLDohodySub(options As ODataQueryOptions(Of vwA2_DLDohodySub), IDSpisyOsoby As Integer) As Object
        Try
            Dim queryable As IQueryable(Of vwA2_DLDohodySub) = dbContext.vwA2_DLDohodySub.Where(Function(e) e.IDSpisyOsoby = IDSpisyOsoby And e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA2_DLDohodySub)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser, IDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    '********************************************************************
    <HttpGet> _
    Public Function vwA2_DLKeZprac(options As ODataQueryOptions(Of vwA2_DLKeZprac)) As Object
        Try
            Dim queryable As IQueryable(Of vwA2_DLKeZprac) = dbContext.vwA2_DLKeZprac.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA2_DLKeZprac)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function vwA2_DLKeZpracSub(options As ODataQueryOptions(Of vwA2_DLKeZpracSub), IDSpisyOsoby As Integer) As Object
        Try
            Dim queryable As IQueryable(Of vwA2_DLKeZpracSub) = dbContext.vwA2_DLKeZpracSub.Where(Function(e) e.IDSpisyOsoby = IDSpisyOsoby And e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vwA2_DLKeZpracSub)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser, IDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    '********************************************************************
    'B3 section 
    '********************************************************************
    <HttpGet>
    Public Function sp_Get_CreditorDetail(iDSpisyOsoby As Nullable(Of Integer), zalozka As String) As Object
        Try
            Dim result As IQueryable(Of sp_Get_CreditorDetail_Result) = dbContext.sp_Get_CreditorDetail(iDSpisyOsoby, zalozka).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby, zalozka}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet>
    Public Function sp_Get_CreditorDetail_G2(iDSpisu As Nullable(Of Integer), zalozka As String) As Object
        Try
            Dim result As IQueryable(Of sp_Get_CreditorDetail_G2_Result) = dbContext.sp_Get_CreditorDetail_G2(iDSpisu, zalozka).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, zalozka}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet>
    Public Function sp_B3_DetailSpisu(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_DetailSpisu_Result) = dbContext.sp_B3_DetailSpisu(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_HistorieDohod(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_HistorieDohod_Result) = dbContext.sp_B3_HistorieDohod(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_HistorieSpisu(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_HistorieSpisu_Result) = dbContext.sp_B3_HistorieSpisu(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_Osoby(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_Osoby_Result) = dbContext.sp_B3_Osoby(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_OsobyAddress(iDSpisu As Nullable(Of Integer), iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_OsobyAddress_Result) = dbContext.sp_B3_OsobyAddress(iDSpisyOsoby, iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_Dokumentace(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_Dokumentace_Result) = dbContext.sp_B3_Dokumentace(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function B3_Dokumentace_Delete(IDSpisyDocument As Nullable(Of Integer)) As Object
        Try

            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDSpisyDocument}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_OsobyAdresyDalsiOsobyDodelat(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_OsobyAdresyDalsiOsobyDodelat_Result) = dbContext.sp_B3_OsobyAdresyDalsiOsobyDodelat(iDSpisyOsoby).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function B3_OsobyDalsiKontakt(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_OsobyDalsiKontakt_Result) = dbContext.sp_B3_OsobyDalsiKontakt(iDSpisyOsoby).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpPost> _
    Public Function B3_OsobyDalsiKontakt_Destroy(model As sp_B3_OsobyDalsiKontakt_Result) As Object
        Try
            Using dbContext
                Dim m = dbContext.tblSpisyOsobyAdresies.FirstOrDefault(Function(e) e.IDSpisyOsobyAdresy = model.IDSpisyOsobyDalsiKontakt)
                If m IsNot Nothing Then
                    dbContext.tblSpisyOsobyAdresies.Remove(m)
                    dbContext.SaveChanges()
                End If
                Return New ApiResult With {.Total = 0, .Data = m, .Msg = {"OK"}, .MsgType = "success"}
            End Using
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {model}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpPost> _
    Public Function B3_OsobyDalsiKontakt_Update(model As sp_B3_OsobyDalsiKontakt_Result) As Object
        Try
            Using dbContext
                Dim m = dbContext.tblSpisyOsobyAdresies.FirstOrDefault(Function(e) e.IDSpisyOsobyAdresy = model.IDSpisyOsobyDalsiKontakt)
                If m IsNot Nothing Then
                    m.NCrr_PersType = model.rr_PersType
                    m.NCSurname = model.NCSurname
                    m.NCName = model.NCName
                    m.PersCity = model.NCCity
                    m.PersStreet = model.NCStreet
                    m.PersHouseNum = model.NCHouseNum
                    m.PersZipCode = model.NCZipCode
                    m.NCEmail = model.NCEmail
                    m.NCEmailValid = model.NCEmailValid
                    m.NCPhone = model.NCPhone
                    m.NCPhoneValid = model.NCPhoneValid
                    m.AddrFVisitComment = model.NCComment
                    m.NextContact = True

                    dbContext.tblSpisyOsobyAdresies.Attach(m)
                    dbContext.Entry(m).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If
                Return New ApiResult With {.Total = 0, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
            End Using
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {model}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpPost> _
    Public Function B3_OsobyDalsiKontakt_Create(model As sp_B3_OsobyDalsiKontakt_Result) As Object
        Try
            Using dbContext
                Dim m As New tblSpisyOsobyAdresy
                m.IDSpisyOsoby = model.IDSpisyOsoby
                m.NCrr_PersType = model.rr_PersType
                m.NCSurname = model.NCSurname
                m.NCName = model.NCName
                m.PersCity = model.NCCity
                m.PersStreet = model.NCStreet
                m.PersHouseNum = model.NCHouseNum
                m.PersZipCode = model.NCZipCode
                m.NCEmail = model.NCEmail
                m.NCEmailValid = model.NCEmailValid
                m.NCPhone = model.NCPhone
                m.NCPhoneValid = model.NCPhoneValid
                m.AddrFVisitComment = model.NCComment
                m.NextContact = True

                dbContext.tblSpisyOsobyAdresies.Add(m)
                dbContext.SaveChanges()
                Return New ApiResult With {.Total = 0, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
            End Using
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {model}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function




    <HttpGet> _
    Public Function sp_B3_OsobyEmail(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_OsobyEmail_Result) = dbContext.sp_B3_OsobyEmail(iDSpisyOsoby).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_OsobyPhone(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_OsobyPhone_Result) = dbContext.sp_B3_OsobyPhone(iDSpisyOsoby).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_OsobyZam(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_OsobyZam_Result) = dbContext.sp_B3_OsobyZam(iDSpisyOsoby).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_PlatbyDoslePo1OSN(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_PlatbyDoslePo1OSN_Result) = dbContext.sp_B3_PlatbyDoslePo1OSN(iDSpisu).AsQueryable()
            Dim data = result.OrderByDescending(Function(e) e.PaymentDate).ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_PlatbyDoslePred1OSN(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_PlatbyDoslePred1OSN_Result) = dbContext.sp_B3_PlatbyDoslePred1OSN(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_B3_DohodyOUhrade(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_DohodyOUhrade_Result) = dbContext.sp_B3_DohodyOUhrade(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Overridable Function sp_B3_SpisyDluznika(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_SpisyDluznika_Result) = dbContext.sp_B3_SpisyDluznika(iDSpisyOsoby, IDUser).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Function sp_Do_DoneOneReminder(iDSpisu As Nullable(Of Integer), iDReminder As Nullable(Of Integer)) As Object
        Try
            dbContext.sp_Do_DoneOneReminder(iDReminder)
            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Overridable Function sp_B3_SpecifikaceDluhuFinUdaje(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_SpecifikaceDluhuFinUdaje_Result) = dbContext.sp_B3_SpecifikaceDluhuFinUdaje(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Overridable Function sp_B3_SpecifikaceDluhuVeritel(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_SpecifikaceDluhuVeritel_Result) = dbContext.sp_B3_SpecifikaceDluhuVeritel(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Overridable Function sp_B3_TerminyOSN(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_TerminyOSN_Result) = dbContext.sp_B3_TerminyOSN(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Overridable Function sp_B3_OsobyRole(iDSpisy As Nullable(Of Integer), iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_OsobyRole_Result) = dbContext.sp_B3_OsobyRole(iDSpisy, iDSpisyOsoby).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisy, iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Overridable Function sp_B3_OtherInfo(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_OtherInfo_Result) = dbContext.sp_B3_OtherInfo(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Overridable Function sp_B3_Bonita(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_Bonita_Result) = dbContext.sp_B3_Bonita(iDSpisyOsoby).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    <HttpGet> _
    Public Overridable Function sp_B3_ListAllFV(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_B3_ListAllFV_Result) = dbContext.sp_B3_ListAllFV(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function
    '********************************************************************
    'Other section 
    '********************************************************************
    <HttpGet> _
    Public Function tblRegisterRestrictions(Register As String) As Object
        Dim result = dbContext.tblRegisterRestrictions.Where(Function(e) e.Register = Register).ToList
        Return New ApiResult With {.Total = 0, .Data = result, .Msg = {Register}, .MsgType = "success"}
    End Function

    <HttpGet> _
    Public Function vw_ListUrgAndRemind(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.vw_ListUrgAndRemind.Where(Function(e) e.IDCase = iDSpisu And e.IDUser = IDUser).OrderBy(Function(e) e.Radek).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vw_AllUrgRemindMsg(options As ODataQueryOptions(Of vw_AllUrgRemindMsg)) As Object
        Try
            Dim params As NameValueCollection = HttpUtility.ParseQueryString(options.Request.RequestUri.Query)
            Dim typeFilter As Integer = params("type"),
                dateFilter As Integer = params("date")

            Dim queryable As IQueryable(Of vw_AllUrgRemindMsg) = dbContext.vw_AllUrgRemindMsg.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            Select Case typeFilter
                Case 2
                    queryable = queryable.Where(Function(e) e.Type = "R").AsQueryable()
                Case 3
                    queryable = queryable.Where(Function(e) e.Type = "U").AsQueryable()
                Case 4
                    queryable = queryable.Where(Function(e) e.Type = "M").AsQueryable()
            End Select

            Select Case dateFilter
                Case 1 'dnes
                    queryable = queryable.Where(Function(e) e.DeadLine = Today).AsQueryable()
                Case 2 'zitra
                    Dim zitra = Today.AddDays(1)
                    queryable = queryable.Where(Function(e) e.DeadLine > Today And e.DeadLine <= zitra).AsQueryable()
                Case 3 'tento tyden
                    Dim dayOfWeek = CInt(DateTime.Today.DayOfWeek)
                    Dim startWeek = Today.AddDays(-1 * dayOfWeek).AddDays(1)
                    Dim endWeek = Today.AddDays(7 - dayOfWeek).AddSeconds(-1).AddDays(1)
                    queryable = queryable.Where(Function(e) e.DeadLine >= startWeek And e.DeadLine <= endWeek).AsQueryable()
                Case 4 'tento mesic
                    Dim startMonth = New Date(Today.Year, Today.Month, 1)
                    Dim endMonth = New Date(Today.Year, Today.Month, 1).AddMonths(1).AddSeconds(-1)
                    queryable = queryable.Where(Function(e) e.DeadLine >= startMonth And e.DeadLine <= endMonth).AsQueryable()
                Case 5 'prosle
                    queryable = queryable.Where(Function(e) e.DeadLine < Today).AsQueryable()
            End Select

            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vw_AllUrgRemindMsg)).ToList

            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function SourceUpominky(type As Integer) As Object
        Try
            Using dbContext
                Select Case type
                    Case 1
                        Return dbContext.vwAD_Basic.Select(Function(e) New With {.text = e.ACC, .IDSpisu = e.IDSpisu}).ToList
                    Case 2
                        Return dbContext.vwAD_Basic.Select(Function(e) New With {.text = If(e.PersSurname = Nothing, "", e.PersSurname) & _
                                                               " " & If(e.PersName = Nothing, "", e.PersName), .IDSpisyOsoby = e.IDSpisyOsoby}).Distinct().ToList
                End Select
            End Using
            Return Nothing
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {type}, .Status = 1})
            Return Nothing
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_AddReminder(reminderDeadline As Nullable(Of Date), reminderSubject As String, reminderTxt As String, reminderJobForUID As Nullable(Of Integer), iDSpisu As Nullable(Of Integer), iDSpisyOsoby As Nullable(Of Integer), awaitAnswer As Nullable(Of Boolean)) As Object
        Try
            dbContext.sp_Do_AddReminder(IDUser, reminderJobForUID, reminderDeadline, reminderSubject, reminderTxt, iDSpisu, iDSpisyOsoby, awaitAnswer, Nothing)
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser, reminderJobForUID, reminderDeadline, reminderSubject, reminderTxt, iDSpisu, iDSpisyOsoby, awaitAnswer}, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet> _
    Public Function vw_ListReminders(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.vw_ListReminders.Where(Function(e) e.IDCase = iDSpisu).OrderBy(Function(e) e.Radek).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwrr_ClosedFile() As Object
        Try
            Dim result = dbContext.vwrr_ClosedFile.ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = Nothing, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function tblExternalAddress(IDSpisyOsobyAdresy As Integer) As Object
        Try
            Using dbContext
                Dim model = dbContext.tblExternalAddresses.FirstOrDefault(Function(e) e.IDExternalAddress = IDSpisyOsobyAdresy)
                Dim data = Nothing
                If model IsNot Nothing Then
                    data = New With {.IDSpisyOsobyAdresy = model.IDExternalAddress,
                                     .PersStreet = model.ExtAddrStreet,
                                     .PersHouseNum = model.ExtAddrHouseNum,
                                     .PersCity = model.ExtAddrCity,
                                     .PersZipCode = model.ExtAddrZipCode,
                                     .GPSLat = model.GPSLat,
                                     .GPSLng = model.GPSLng,
                                     .GPSValid = model.GPSValid,
                                     .PersAddrFull = model.ExtAddrStreet & " " & _
                                          model.ExtAddrHouseNum & ", " & _
                                          model.ExtAddrCity & " " & _
                                          model.ExtAddrZipCode,
                                          .isExt = True}
                End If
                Return New ApiResult With {.Total = 1, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
            End Using
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpPost> _
    Public Function tblExternalAddress_Save(model As tblSpisyOsobyAdresy) As Object
        Try
            Using dbContext
                Dim m = dbContext.tblExternalAddresses.FirstOrDefault(Function(e) e.IDExternalAddress = model.IDSpisyOsobyAdresy)
                If m IsNot Nothing Then
                    m.ExtAddrStreet = model.PersStreet
                    m.ExtAddrHouseNum = model.PersHouseNum
                    m.ExtAddrCity = model.PersCity
                    m.ExtAddrZipCode = model.PersZipCode
                    m.GPSLat = model.GPSLat
                    m.GPSLng = model.GPSLng
                    m.GPSValid = model.GPSValid

                    dbContext.tblExternalAddresses.Attach(m)
                    dbContext.Entry(m).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If
                Return New ApiResult With {.Total = 0, .Data = m, .Msg = {"OK"}, .MsgType = "success"}
            End Using
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function tblSpisyOsobyAdresy(IDSpisyOsobyAdresy As Integer) As Object
        Try
            Using dbContext
                Dim model = dbContext.tblSpisyOsobyAdresies.FirstOrDefault(Function(e) e.IDSpisyOsobyAdresy = IDSpisyOsobyAdresy)
                If model IsNot Nothing Then
                    If String.IsNullOrEmpty(model.PersAddrFull) Then
                        model.PersAddrFull = model.PersStreet & " " & _
                                          model.PersHouseNum & ", " & _
                                          model.PersCity & " " & _
                                          model.PersZipCode
                    End If
                End If
                Return New ApiResult With {.Total = 1, .Data = model, .Msg = {"OK"}, .MsgType = "success"}
            End Using
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpPost> _
    Public Function tblSpisyOsobyAdresy_Save(model As tblSpisyOsobyAdresy) As Object
        Try
            Using dbContext
                Dim m = dbContext.tblSpisyOsobyAdresies.FirstOrDefault(Function(e) e.IDSpisyOsobyAdresy = model.IDSpisyOsobyAdresy)
                If m IsNot Nothing Then
                    If model.GPSValidDetail = 1 Then
                        'm.PersStreet = model.PersStreet
                        'm.PersHouseNum = model.PersHouseNum
                        'm.PersCity = model.PersCity
                        'm.PersZipCode = model.PersZipCode
                        m.GPSLat = model.GPSLat
                        m.GPSLng = model.GPSLng
                        'm.PersAddrFull = model.PersAddrFull
                        m.GPSValid = True
                    Else
                        m.GPSValid = False
                    End If

                    m.GPSValidDetail = model.GPSValidDetail

                    dbContext.tblSpisyOsobyAdresies.Attach(m)
                    dbContext.Entry(m).State = EntityState.Modified
                    dbContext.SaveChanges()
                End If
                Return New ApiResult With {.Total = 0, .Data = m, .Msg = {"OK"}, .MsgType = "success"}
            End Using
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function Run_11to30(id As Integer) As Object
        Try
            Dim Output As New ObjectParameter("LL_LastLapse", GetType(Int32))
            Dim procedure = dbContext.sp_Run_11to30(id, Output)
            If Output.Value > 0 Then
                Dim LL_LastLapse As Integer = Output.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    Return New With {.exception = msg.LastLapseMsg}
                End If
            End If
            Return New With {.exception = Nothing}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {New Object() {id}}, .Status = 1})
            Return New With {.exception = ex.Message}
        End Try
    End Function

    <HttpGet> _
    Public Function Run_xxtoDateFV(id As Integer, dat As Date, nochange As Boolean, name As String) As Object
        Try
            Dim DOSN As Date = New Date(dat.Year, dat.Month, dat.Day, 0, 0, 0)
            Dim LL As New ObjectParameter("LL_LastLapse", GetType(Int32))
            Dim cnt As New ObjectParameter("Cnt", GetType(Int32))
            Dim procedure = dbContext.sp_Run_xxtoDateFV(id, DOSN, nochange, name, cnt, LL)
            If LL.Value > 0 Then
                Dim LL_LastLapse As Integer = LL.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {msg.LastLapseMsg}, .MsgType = "error"}
                End If
            End If
            If Not IsDBNull(cnt.Value) Then
                Return New ApiResult With {.Total = cnt.Value, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
            End If
            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {New Object() {id}}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "warning"}
        End Try
    End Function

    <HttpGet> _
    Public Function Run_11to20(iDSpisu As Integer, recordCommentType As String, recordCommentTxt As String) As Object
        Try
            Dim Output As New ObjectParameter("LL_LastLapse", GetType(Int32))
            Dim sp_Run_11to20 = dbContext.sp_Run_11to20(iDSpisu, recordCommentType, recordCommentTxt, Output)
            If Output.Value > 0 Then
                Dim LL_LastLapse As Integer = Output.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {msg.LastLapseMsg}, .MsgType = "error"}
                End If
            End If
            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {iDSpisu, recordCommentType, recordCommentTxt}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "warning"}
        End Try
    End Function

    <HttpGet> _
    Public Function Run_30to5x(iDspisu As Nullable(Of Integer), rr_CaseNextActivity As Nullable(Of Short), reminderDeadline As Nullable(Of Date), caseNextActivityComment As String) As Object
        Try
            Dim Output As New ObjectParameter("LL_LastLapse", GetType(Int32))
            Dim sp_Run_30to5x = dbContext.sp_Run_30to5x(IDUser, iDspisu, rr_CaseNextActivity, reminderDeadline, caseNextActivityComment, Output)
            If Output.Value > 0 Then
                Dim LL_LastLapse As Integer = Output.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {msg.LastLapseMsg}, .MsgType = "error"}
                End If
            End If
            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {IDUser, iDspisu, rr_CaseNextActivity, reminderDeadline, caseNextActivityComment}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "warning"}
        End Try
    End Function

    <HttpGet> _
    Public Function Run_5xto30(iDspisu As Nullable(Of Integer), Dat As Date, nochange As Boolean) As Object
        Try
            Dim messages As New List(Of String)
            Dim result As ApiResult = Run_xxtoDateFV(iDspisu, Dat, nochange, Nothing)

            Dim Output = New ObjectParameter("LL_LastLapse", GetType(Int32))
            Dim sp_Run_30to5x = dbContext.sp_Run_5xto30(iDspisu, Output)

            If Output.Value > 0 Then
                Dim LL_LastLapse = Output.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    messages.Add(msg.LastLapseMsg)
                End If
            End If

            If result.MsgType = "error" Then
                messages.Add(result.Msg(0))
            Else
                Output = New ObjectParameter("LL_LastLapse", GetType(Int32))
                Dim sp_Run_30to31 = dbContext.sp_Run_30to31(iDspisu, Output)
                If Output.Value > 0 Then
                    Dim LL_LastLapse = Output.Value
                    Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                    If msg IsNot Nothing Then
                        messages.Add(msg.LastLapseMsg)
                    End If
                End If
            End If

            If messages.Count > 0 Then
                Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = messages.ToArray, .MsgType = "error"}
            End If

            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {New Object() {iDspisu}}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "warning"}
        End Try
    End Function

    <HttpGet> _
    Public Function Get_ListOfOtherCase(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_Get_ListOfOtherCase_Result) = dbContext.sp_Get_ListOfOtherCase(iDSpisu).AsQueryable()
            Dim data = result.ToList
            Return New ApiResult With {.Total = data.Count, .Data = data, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function Run_xxto61(iDSpisu As Nullable(Of Integer), rr_ClosedFile As Nullable(Of Short), comment As String) As Object
        Try
            Dim Output = New ObjectParameter("LL_LastLapse", GetType(Int32))
            Dim sp_Run_xxto61 = dbContext.sp_Run_xxto61(iDSpisu, IDUser, rr_ClosedFile, comment, Output)
            If Output.Value > 0 Then
                Dim LL_LastLapse = Output.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {msg.LastLapseMsg}, .MsgType = "error"}
                End If
            End If
            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {iDSpisu, rr_ClosedFile, comment}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "warning"}
        End Try
    End Function

    'Zrušim SK sp_Run_4xto30 (IDSpisu, Comment, LL_LastLapse Output)
    'Naplanuju datum OSN: sp_Run_xxtoDateFV
    <HttpGet> _
    Public Function MoveToOSNFromDohody(iDSpisu As Nullable(Of Integer), C As String, D As Date, nochange As Boolean, name As String) As Object
        Try
            Dim messages As New List(Of String)

            Dim result As ApiResult = Run_xxtoDateFV(iDSpisu, D, nochange, name)
            If result.MsgType = "error" Then
                messages.Add(result.Msg(0))
            End If

            Dim Output = New ObjectParameter("LL_LastLapse", GetType(Int32))
            dbContext.sp_Run_4xto30(iDSpisu, C, Output)
            If Output.Value > 0 Then
                Dim LL_LastLapse = Output.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = LL_LastLapse)
                If msg IsNot Nothing Then
                    messages.Add(msg.LastLapseMsg)
                End If
            End If

            If messages.Count > 0 Then
                Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = messages.ToArray, .MsgType = "error"}
            End If

            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {iDSpisu, C, D}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "warning"}
        End Try
    End Function

    <HttpGet> _
    Public Function FinishedPostEmail(iDSpisu As Integer, comment As String) As Object
        Try
            Dim LL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Int32))
            dbContext.sp_Run_6xto62(iDSpisu, comment, LL_LastLapse)
            Dim message As String = If(IsDBNull(LL_LastLapse.Value), Nothing, LL_LastLapse.Value)
            If message IsNot Nothing Then
                Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {message}, .MsgType = "error"}
            End If

            Dim spis = dbContext.vwA1_Finished.FirstOrDefault(Function(e) e.IDSpisu = iDSpisu)
            Dim html As String = "<!DOCTYPE html><html><head><meta charset='utf-8'><title>Žádost o vrácení spisu</title>"
            html += "<style>"
            html += "table { padding: 10px; border-collapse: collapse; }"
            html += "table th { color: #666666; background: #efeff2; padding: 3px; }"
            html += "table td { color: #444; padding: 3px; }"
            html += "table, th, td { border: 1px solid silver; }"
            html += "</style>"
            html += "</head><body><h3>Žádost o vrácení spisu</h3><p>" & comment & "</p><table>"
            html += "<tr><th>Číslo spisu</th><th>Příjmení</th><th>Jméno</th><th>Věřitel</th><th>Datum ukončení</th><th>Uzavřeno</th><th>Důvod</th><th>IČ</th><th>Dluh ke dni uzavření</th><th>Suma plateb</th><th>Celková provize</th><th>Datum přijetí</th><th>RČ</th><th>Datum narození</th><th>Stav</th></tr>"
            html += "<tr><td>" & spis.ACC & "</td><td>" & spis.PersSurname & "</td><td>" & spis.PersName & "</td><td>" & spis.CreditorAlias & "</td><td>" & spis.VisitDateSentToMother & "</td><td>" & spis.UserWhoClosedFile & "</td><td>" & spis.ReasonClosedFile & "</td><td>" & spis.PersIC & "</td><td>" & spis.ActualDebit & "</td><td>" & spis.SumPaymentsByFV & "</td><td>" & spis.AllCommissionPerFile & "</td><td>" & spis.VisitDateReceiveFromMother & "</td><td>" & spis.PersRC & "</td><td>" & spis.PersBirthDate & "</td><td>" & spis.StateTxt & "</td></tr>"
            html += "</table></body></html>"

            Dim eopt As New NetMail.Options
            eopt.Subject = "Žádost o vrácení spisu č: " & spis.ACC
            eopt.To.Add(My.Settings.SupervisorEmail)
            eopt.DisplayName = "TRACE"
            eopt.Body = html

            EmailModule.Send(eopt)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            Errors("FinishedPostEmail", "Nepodařilo se odeslat email. Exception: " & ex.Message)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_SetVisitDatePlanNoChange(iDSpisu As Nullable(Of Integer), visitDatePlanNoChange As Nullable(Of Boolean)) As Object
        Try
            dbContext.sp_Do_SetVisitDatePlanNoChange(iDSpisu, visitDatePlanNoChange)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = {iDSpisu, visitDatePlanNoChange}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_FieldVisitObject(iDSpisu As Integer, Optional model As String = Nothing, Optional command As Integer = 1, Optional process As Integer = 1, Optional g As String = Nothing) As Object
        Try
            'parametters
            Dim _State = New ObjectParameter("returnValue", GetType(Int32))
            Dim _IDSpisu = New ObjectParameter("IDSpisu", iDSpisu)
            Dim _IDSpisyOsoby = New ObjectParameter("IDSpisyOsoby", GetType(Int32))
            Dim _Process = New ObjectParameter("rr_IDFVProcess", process)
            Dim _ACC = New ObjectParameter("ACC", GetType(Int32))
            Dim _SumTxt = New ObjectParameter("SumTxt", GetType(String))

            'json to xml
            Dim gui = Guid.NewGuid().ToString("d")
            Dim previousMasterResult As String = Nothing
            If model IsNot Nothing Then
                previousMasterResult = JsonConvert.DeserializeXmlNode(model).OuterXml.Trim()
                Dim doc As XDocument = XDocument.Parse(previousMasterResult)

                Dim idz As XElement = doc...<object>.<idz>.FirstOrDefault
                If idz Is Nothing Then
                    doc...<object>.FirstOrDefault.AddFirst(New XElement("device", "browser"))
                    doc...<object>.FirstOrDefault.AddFirst(New XElement("idz", g))
                End If

                Dim source As XElement = doc...<object>.<source>.FirstOrDefault
                If source IsNot Nothing Then
                    Dim files = source.Element("files")
                    If files IsNot Nothing Then
                        For Each f In files.Elements
                            Dim x = f.Name
                            f.Name = "file"
                        Next
                    End If
                End If
                previousMasterResult = doc.ToString
            End If

            Dim result As IQueryable(Of sp_Get_FieldVisitObject_Result) = dbContext.sp_Get_FieldVisitObject(IDUser, _IDSpisu, _Process, previousMasterResult, command, _State, _ACC, _IDSpisyOsoby, _SumTxt).AsQueryable()
            Dim data As List(Of XDocument) = result.AsEnumerable.Select(Function(e) XDocument.Parse(If(e.ObjectXML IsNot Nothing, e.ObjectXML, "<object></object>"))).ToList

            If (data.Last IsNot Nothing) Then
                Dim source As XElement = data.Last...<source>.FirstOrDefault
                If source IsNot Nothing Then
                    Dim radio = source.Element("radio")
                    If radio IsNot Nothing Then
                        radio.SetValue(0)
                    End If
                End If

                Dim fcount As XElement = data.Last...<fcount>.FirstOrDefault
                If fcount IsNot Nothing Then
                    Dim val = CInt(fcount.Value)
                    If val > 0 Then
                        fcount.SetValue(val - 1)
                    End If
                End If

            End If

            Return New With {.Total = data.Count, .Data = data, .State = _State.Value, .IDSpisu = _IDSpisu.Value, .IDSpisyOsoby = _IDSpisyOsoby.Value, .ACC = _ACC.Value, .Process = _Process.Value, .SumTxt = _SumTxt.Value}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})

            Errors("sp_Get_FieldVisitObject", ex.Message)

            Return New With {.Total = 0, .Data = Nothing}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_DebitorDetailSmall(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim fullName = New ObjectParameter("fullName", GetType(String))
            Dim aCC = New ObjectParameter("aCC", GetType(String))
            Dim sp_Run_xxto61 = dbContext.sp_Get_DebitorDetailSmall(iDSpisu, fullName, aCC)
            Dim data = New With {.name = fullName.Value, .aCC = aCC.Value}
            Return New ApiResult With {.Total = 1, .Data = data, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get2_Addresses(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_Get2_Addresses_Result) = dbContext.sp_Get2_Addresses(iDSpisu).AsQueryable()
            Return New ApiResult With {.Total = 0, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get2_Osoby(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result As IQueryable(Of sp_Get2_Osoby_Result) = dbContext.sp_Get2_Osoby(iDSpisu).AsQueryable()
            Return New ApiResult With {.Total = 0, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_RFV_NonReported(iDspisu As Nullable(Of Integer), iDspisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Get_RFV_NonReported(iDspisu, iDspisyOsoby, IDUser).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDspisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_RFV_HeadIsFinished(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Do_RFV_HeadIsFinished(iDSpisu, IDUser)
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwrr_PersType() As Object
        Try
            Dim result = dbContext.vwrr_PersType().ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwrr_PersTypeMini() As Object
        Try
            Dim result = dbContext.vwrr_PersTypeMini().ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vwrr_AddressType() As Object
        Try
            Dim result = dbContext.vwrr_AddressType().Select(Function(e) New With {.text = e.AddressTypeTxt, .value = e.rr_AddressType})
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Rec_Object_3137_17_Extra(iDSpisu As Nullable(Of Integer), dateNextPayment As Nullable(Of Date), rEM_Comment As String, iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Rec_Object_3137_17_Extra(IDUser, iDSpisu, dateNextPayment, rEM_Comment, iDSpisyOsoby)
            Return New With {.Msg = "OK", .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {IDUser, iDSpisu, dateNextPayment, rEM_Comment, iDSpisyOsoby}, .Status = 1})
            Return New With {.Msg = ex.InnerException.Message, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_GlobalFind(find As String) As Object
        Try
            Dim result = dbContext.sp_Get_GlobalFind(find, IDUser).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {find, IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = New Object() {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_FVOsoby(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Get_FVOsoby(iDSpisu).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = New Object() {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_FVOsobyAddress(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Get_FVOsobyAddress(iDSpisyOsoby).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = New Object() {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_FVOsobyEmail(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Get_FVOsobyEmail(iDSpisyOsoby).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = New Object() {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_FVOsobyPhone(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Get_FVOsobyPhone(iDSpisyOsoby).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = Nothing, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = New Object() {ex.InnerException.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangeAddrForItinerary(tbl As Nullable(Of Byte),
                                                 iDAddress As Nullable(Of Integer),
                                                 iDSpisu As Nullable(Of Integer),
                                                 GPSLat As String,
                                                 GPSLng As String,
                                                 GPSValid As Boolean) As Object
        Try
            Dim OK = New ObjectParameter("OK", GetType(Int16))
            Dim Msg = New ObjectParameter("Msg", GetType(String))
            Dim result = dbContext.sp_Do_ChangeAddrForItinerary(tbl, iDAddress, iDSpisu, GPSLat, GPSLng, GPSValid, OK, Msg)

            Return New With {.Msg = Msg.Value, .OK = OK.Value}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {tbl, iDAddress}, .Status = 1})
            Return New With {.Msg = ex.Message, .OK = 0}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangeAddrMain(iDSpisyOsobyAdresy As Nullable(Of Integer)) As Object
        Try
            dbContext.sp_Do_ChangeAddrMain(iDSpisyOsobyAdresy)
            Return New With {.Msg = "", .OK = 1}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsobyAdresy}, .Status = 1})
            Return New With {.Msg = ex.Message, .OK = 0}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangeAddrType(iDSpisyOsobyAdresy As Nullable(Of Integer), rr_AddressType As Nullable(Of Short)) As Object
        Try
            dbContext.sp_Do_ChangeAddrType(iDSpisyOsobyAdresy, rr_AddressType)
            Return New With {.Msg = "", .OK = 1}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsobyAdresy, rr_AddressType}, .Status = 1})
            Return New With {.Msg = ex.Message, .OK = 0}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangeAddrValidity(iDSpisyOsobyAdresy As Nullable(Of Integer), rr_AddressValidity As Nullable(Of Short)) As Object
        Try
            dbContext.sp_Do_ChangeAddrValidity(iDSpisyOsobyAdresy, rr_AddressValidity)
            Return New With {.Msg = "", .OK = 1}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsobyAdresy, rr_AddressValidity}, .Status = 1})
            Return New With {.Msg = ex.Message, .OK = 0}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangeAddrVisited(iDSpisyOsobyAdresy As Nullable(Of Integer), persAddressVisited As Nullable(Of Boolean)) As Object
        Try
            dbContext.sp_Do_ChangeAddrVisited(iDSpisyOsobyAdresy, persAddressVisited)
            Return New With {.Msg = "", .OK = 1}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsobyAdresy, persAddressVisited}, .Status = 1})
            Return New With {.Msg = ex.Message, .OK = 0}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangeMailValidity(iDSpisyOsobyEmail As Nullable(Of Integer), persEmailValid As Nullable(Of Boolean)) As Object
        Try
            dbContext.sp_Do_ChangeMailValidity(iDSpisyOsobyEmail, persEmailValid)
            Return New With {.Msg = "", .OK = 1}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsobyEmail, persEmailValid}, .Status = 1})
            Return New With {.Msg = ex.Message, .OK = 0}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangePhoneValidity(iDSpisyOsobyPhone As Nullable(Of Integer), rr_PhoneValidity As Nullable(Of Short)) As Object
        Try
            dbContext.sp_Do_ChangePhoneValidity(iDSpisyOsobyPhone, rr_PhoneValidity)
            Return New With {.Msg = "", .OK = 1}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsobyPhone, rr_PhoneValidity}, .Status = 1})
            Return New With {.Msg = ex.Message, .OK = 0}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_AllAddressOfDebitor(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim CountOfFV = New ObjectParameter("CountOfFV", GetType(Integer))
            Dim FirstVisitExecuted = New ObjectParameter("FirstVisitExecuted", GetType(Integer))
            Dim result = dbContext.sp_Get_AllAddressOfDebitor(iDSpisu, CountOfFV, FirstVisitExecuted).ToList
            Return New With {.Total = result.Count, .Data = result, .CountOfFV = CountOfFV.Value, .FirstVisitExecuted = FirstVisitExecuted.Value}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New With {.Total = 0, .Data = Nothing, .CountOfFV = 0, .FirstVisitExecuted = 0}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_FVAllPhonesOfCase(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Get_FVAllPhonesOfCase(iDSpisu).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "success"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_FVAllEmailsOfCase(iDSpisu As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Get_FVAllEmailsOfCase(iDSpisu).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "success"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Rec_Object_54_1_Extra(iDSpisu As Nullable(Of Integer), dateNextPayment As Nullable(Of Date), rEM_Comment As String, reminderSubject As String, iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            dbContext.sp_Rec_Object_54_1_Extra(IDUser, iDSpisu, dateNextPayment, rEM_Comment, reminderSubject, iDSpisyOsoby)
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser, iDSpisu, dateNextPayment, rEM_Comment, reminderSubject, iDSpisyOsoby}, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Rec_Object_81_Extra(iDSpisu As Nullable(Of Integer), comment As String) As Object
        Try
            dbContext.sp_Rec_Object_81_Extra(IDUser, iDSpisu, comment)
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser, iDSpisu, comment}, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Rec_Start8() As Object
        Try
            dbContext.sp_Rec_Start8(IDUser)
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return False
        End Try
    End Function

    <HttpGet> _
    Public Function sp_DSHB_10_01() As Object
        Try
            Dim data = dbContext.sp_DSHB_10_01(IDUser).ToList
            Return data.OrderBy(Function(e) e.IDOrder)
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet> _
    Public Function sp_DSHB_10_02() As Object
        Try
            Dim data_plan = dbContext.sp_DSHB_10_02(IDUser).FirstOrDefault(Function(e) e.Poradi = 1)
            Dim data_ukon = dbContext.sp_DSHB_10_02(IDUser).FirstOrDefault(Function(e) e.Poradi = 2)

            Dim series = New List(Of Object) From {
                New With {
                .name = My.Resources.Language.DSHBtxt27,
                .data = New List(Of Object) From {
                         New With {.category = My.Resources.Language.DSHBtxt28, .value = data_plan.ThisWeek}, _
                         New With {.category = My.Resources.Language.DSHBtxt29, .value = data_plan.ThisDay}
                    }, _
                .color = "#fd625e", _
                .overlay = New With {.gradient = "none"}, _
                .field = "value", _
                .categoryField = "category"}, _
                New With {
                .name = My.Resources.Language.DSHBtxt30,
                .data = New List(Of Object) From {
                        New With {.category = My.Resources.Language.DSHBtxt31, .value = data_ukon.ThisWeek}, _
                         New With {.category = My.Resources.Language.DSHBtxt32, .value = data_ukon.ThisDay}
                    }, _
                .color = "#03a9f4", _
                .overlay = New With {.gradient = "none"}, _
                .field = "value", _
                .categoryField = "category"}}

            Return series
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet> _
    Public Function sp_DSHB_10_03() As Object
        Try
            Dim data = dbContext.sp_DSHB_10_03(IDUser).ToList
            Return data
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet> _
    Public Function sp_DSHB_10_04() As Object
        Try
            Dim data = dbContext.sp_DSHB_10_04(IDUser).ToList
            Return data
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet> _
    Public Function sp_DSHB_10_07() As Object
        Try
            Dim data = dbContext.sp_DSHB_10_07(IDUser).ToList
            Return data
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet> _
    Public Function sp_DSHB_10_08() As Object
        Try
            Dim data = dbContext.sp_DSHB_Get_AverageDaysForFV(IDUser).ToList
            Return data
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet> _
    Public Function sp_DSHB_10_09() As Object
        Try
            Dim pripominky = dbContext.sp_DSHB_10_09(IDUser).Where(Function(e) e.Poradi < 7).OrderBy(Function(e) e.Poradi).Select(Function(e) e.Pripominek).ToList
            Dim urgence = dbContext.sp_DSHB_10_09(IDUser).Where(Function(e) e.Poradi < 7).OrderBy(Function(e) e.Poradi).Select(Function(e) e.Urgenci).ToList
            Dim zpravy = dbContext.sp_DSHB_10_09(IDUser).Where(Function(e) e.Poradi < 7).OrderBy(Function(e) e.Poradi).Select(Function(e) e.Msgs).ToList

            Dim c_pripominky = dbContext.sp_DSHB_10_09(IDUser).Where(Function(e) e.Poradi = 7).Select(Function(e) e.Pripominek).FirstOrDefault
            Dim c_urgence = dbContext.sp_DSHB_10_09(IDUser).Where(Function(e) e.Poradi = 7).Select(Function(e) e.Urgenci).FirstOrDefault
            Dim c_zpravy = dbContext.sp_DSHB_10_09(IDUser).Where(Function(e) e.Poradi = 7).Select(Function(e) e.Msgs).FirstOrDefault

            Dim series = New List(Of Object) From {
                New With {
                .name = My.Resources.Language.DSHBtxt33 & " (" & c_pripominky & ")",
                .data = pripominky, _
                .color = "#f2c80f",
                .overlay = New With {.gradient = "none"}}, _
                New With {
                .name = My.Resources.Language.DSHBtxt34 & " (" & c_urgence & ")",
                .color = "#fd625e",
                .data = urgence, _
                .overlay = New With {.gradient = "none"}}, _
                New With {
                .name = My.Resources.Language.DSHBtxt35 & " (" & c_zpravy & ")",
                .color = "#90cc38",
                .data = zpravy, _
                .overlay = New With {.gradient = "none"}}}

            Return series
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Rec_Start52_Extra() As Object
        Try
            dbContext.sp_Rec_Start52_Extra(IDUser)
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return False
        End Try
    End Function

    <HttpGet> _
    Public Function sp_CampAddrALL(options As ODataQueryOptions(Of sp_CampAddrALL_Result)) As Object
        Try
            Dim params As NameValueCollection = HttpUtility.ParseQueryString(options.Request.RequestUri.Query)
            Dim Type As Integer = params("Type")
            Dim data = dbContext.sp_CampAddrALL(IDUser, Type, 20).ToList
            Dim queryable As IQueryable(Of sp_CampAddrALL_Result) = data.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of sp_CampAddrALL_Result)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vw_Campaign(options As ODataQueryOptions(Of vw_Campaign)) As Object
        Try
            Dim queryable As IQueryable(Of vw_Campaign) = dbContext.vw_Campaign.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vw_Campaign)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vw_CampaignALL(options As ODataQueryOptions(Of vw_CampaignALL)) As Object
        Try
            Dim queryable As IQueryable(Of vw_CampaignALL) = dbContext.vw_CampaignALL.Where(Function(e) e.IDUser = IDUser).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vw_CampaignALL)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function vw_Campaign_Update(IDCampaign As Integer, CampName As String) As Object
        Try
            Dim item = dbContext.tblCampaigns.FirstOrDefault(Function(e) e.IDCampaign = IDCampaign)
            If item IsNot Nothing Then
                item.CampName = CampName
                dbContext.SaveChanges()
            End If
            Return True
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDCampaign, CampName}, .Status = 1})
            Return False
        End Try
    End Function

    <HttpGet> _
    Public Function vw_CampMember(options As ODataQueryOptions(Of vw_CampMember)) As Object
        Try
            Dim params As NameValueCollection = HttpUtility.ParseQueryString(options.Request.RequestUri.Query)
            Dim IDCampaign As Integer = params("IDCampaign")

            Dim queryable As IQueryable(Of vw_CampMember) = dbContext.vw_CampMember.Where(Function(e) e.IDCampaign = IDCampaign).AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of vw_CampMember)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_IDSpisu_OfIDSpisyOsobyAdresy(iDSpisyOsobyAdresy As Nullable(Of Integer), deadLine As Date) As Object
        Try
            Dim iDSpisu = New ObjectParameter("iDSpisu", GetType(Integer))
            Dim procedure = dbContext.sp_Get_IDSpisu_OfIDSpisyOsobyAdresy(iDSpisyOsobyAdresy, iDSpisu)
            If Not IsDBNull(iDSpisu.Value) Then
                Dim result = Run_xxtoDateFV(iDSpisu.Value, deadLine, False, Nothing)
                Return result
            End If
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"Spis nenalezen"}, .MsgType = "error"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisyOsobyAdresy, deadLine}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangeCampOrder(iDCampMember As Nullable(Of Integer), newPosition As Nullable(Of Short)) As Object
        Try
            dbContext.sp_Do_ChangeCampOrder(iDCampMember, newPosition)
            Return 0
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDCampMember, newPosition}, .Status = 1})
            Return 0
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_ChangeCampOrderOnlyOne(iDCampMember As Nullable(Of Integer), newPosition As Nullable(Of Short)) As Object
        Try
            dbContext.sp_Do_ChangeCampOrderOnlyOne(iDCampMember, newPosition)
            Return 0
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDCampMember, newPosition}, .Status = 1})
            Return 0
        End Try
    End Function

    <HttpPost>
    Public Function tblCampRouteTrajectory_Save(model As List(Of tblCampRouteTrajectory)) As Object
        Try
            dbContext.Database.ExecuteSqlCommand("DELETE FROM tblCampRouteTrajectory WHERE IDUser = " & IDUser)
            For Each m In model
                Dim item As New tblCampRouteTrajectory
                item.IDUser = IDUser
                item.GPSLat = m.GPSLat
                item.GPSLng = m.GPSLng
                dbContext.tblCampRouteTrajectories.Add(item)
            Next
            dbContext.SaveChanges()

            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {model}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "warning"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_DeleteCampMember(iDCampMember As Nullable(Of Integer), dateForFieldVisit As Nullable(Of Date), nochange As Boolean) As Object
        Try
            Dim LL_LastLapse As New ObjectParameter("LL_LastLapse", GetType(Int32))
            Dim cnt As New ObjectParameter("Cnt", GetType(Int32))
            dbContext.sp_Do_DeleteCampMember(iDCampMember, dateForFieldVisit, nochange, cnt, LL_LastLapse)
            If LL_LastLapse.Value > 0 Then
                Dim ll As Integer = LL_LastLapse.Value
                Dim msg = dbContext.tblLastLapses.FirstOrDefault(Function(e) e.LL_LastLapse = ll)
                If msg IsNot Nothing Then
                    Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {msg.LastLapseMsg}, .MsgType = "error"}
                End If
            End If
            If Not IsDBNull(cnt.Value) Then
                Return New ApiResult With {.Total = cnt.Value, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
            End If
            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDCampMember, dateForFieldVisit}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_MinDMAX_OfIDSpisyOsobyAdresy(iDSpisyOsobyAdresy As Nullable(Of Integer)) As Object
        Try
            Dim MinDMAX As New ObjectParameter("MinDMAX", GetType(DateTime))
            Dim visitDatePlanNoChange As New ObjectParameter("VisitDatePlanNoChange", GetType(Boolean))
            dbContext.sp_Get_MinDMAX_OfIDSpisyOsobyAdresy(iDSpisyOsobyAdresy, MinDMAX, visitDatePlanNoChange)
            If Not IsDBNull(MinDMAX.Value) Then
                Return New With {.dmax = MinDMAX.Value, .nochange = visitDatePlanNoChange.Value}
            End If
            Return New With {.dmax = Nothing, .nochange = Nothing}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisyOsobyAdresy}, .Status = 1})
            Return New With {.dmax = Nothing, .nochange = Nothing}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_AddExternalAddress(extAddrName As String, extAddrStreet As String, extAddrHouseNum As String, extAddrZipCode As String, extAddrCity As String, gPSLat As String, gPSLng As String, extAddrComment As String, gPSValid As Boolean) As Object
        Try
            Dim iDExternalAddress As New ObjectParameter("IDExternalAddress", GetType(Integer))
            dbContext.sp_Do_AddExternalAddress(IDUser, extAddrName, extAddrStreet, extAddrHouseNum, extAddrZipCode, extAddrCity, gPSLat, gPSLng, gPSValid, extAddrComment, iDExternalAddress)
            If Not IsDBNull(iDExternalAddress.Value) Then
                Return iDExternalAddress.Value
            End If
            Return 1
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {extAddrName, extAddrStreet, extAddrHouseNum, extAddrZipCode, extAddrCity, gPSLat, gPSLng, extAddrComment}, .Status = 1})
            Return 0
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_DeleteExternalAddress(iDExternalAddress As Nullable(Of Integer)) As Integer
        Try
            dbContext.sp_Do_DeleteExternalAddress(iDExternalAddress)
            Return 1
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDExternalAddress}, .Status = 1})
            Return 0
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_EditExternalAddress(iDExternalAddress As Nullable(Of Integer),
                                              extAddrName As String,
                                              extAddrStreet As String,
                                              extAddrHouseNum As String,
                                              extAddrZipCode As String,
                                              extAddrCity As String,
                                              gPSLat As String,
                                              gPSLng As String,
                                              gPSValid As Boolean,
                                              extAddrComment As String) As Object
        Try
            dbContext.sp_Do_EditExternalAddress(iDExternalAddress, extAddrName, extAddrStreet, extAddrHouseNum, extAddrZipCode, extAddrCity, Nothing, gPSLat, gPSLng, gPSValid, extAddrComment)
            Return 1
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDExternalAddress, extAddrName, extAddrStreet, extAddrHouseNum, extAddrZipCode, extAddrCity, Nothing, gPSLat, gPSLng, gPSValid, extAddrComment}, .Status = 1})
            Return 0
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_AddCampNewExternalAddr(iDCampaign As Nullable(Of Integer), iDExternalAddress As Nullable(Of Integer)) As Object
        Try
            Dim IDCampMember As New ObjectParameter("IDCampMember", GetType(Integer))
            dbContext.sp_Do_AddCampNewExternalAddr(iDCampaign, iDExternalAddress, IDCampMember)
            If IDCampMember.Value > 0 Then
                Return New ApiResult With {.Total = 0, .Data = IDCampMember.Value, .Msg = {"OK"}, .MsgType = "success"}
            End If
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {"Nepodařilo se přidat bod do kampaně"}, .MsgType = "error"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDCampaign, iDExternalAddress}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_DeleteCampNewExternalAddr(iDCampaign As Nullable(Of Integer), iDCampMember As Nullable(Of Integer)) As Object
        Try
            Dim cnt As New ObjectParameter("Cnt", GetType(Int32))
            dbContext.sp_Do_DeleteCampNewExternalAddr(iDCampaign, iDCampMember, cnt)
            If Not IsDBNull(cnt.Value) Then
                Return New ApiResult With {.Total = cnt.Value, .Data = Nothing, .Msg = {"OK"}, .MsgType = "success"}
            End If
            Return New ApiResult
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDCampaign, iDCampMember}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_SpisyOfIDSpisyOsoby(iDSpisyOsoby As Nullable(Of Integer)) As Object
        Try
            Dim result = dbContext.sp_Get_SpisyOfIDSpisyOsoby(IDUser, iDSpisyOsoby).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.InnerException.Message, .Params = New Object() {iDSpisyOsoby}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_CashBook(options As ODataQueryOptions(Of sp_Get_CashBook_Result)) As Object
        Try
            Dim data = dbContext.sp_Get_CashBook(IDUser, 1000).ToList
            Dim queryable As IQueryable(Of sp_Get_CashBook_Result) = data.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of sp_Get_CashBook_Result)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_ChangeCashAmountSended(IDCashPayment As Integer, AmountSended As Double) As Object
        Try
            dbContext.sp_Do_ChangeCashAmountSended(IDCashPayment, AmountSended)
            Return New ApiResult With {.Total = 0, .Data = IDCashPayment, .Msg = Nothing, .MsgType = "ok"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDCashPayment, AmountSended}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_CashAmountSended(IDCashPayment As Integer, AmountSended As Double, Check As Boolean) As Object
        Try
            dbContext.sp_Do_CashAmountSended(IDCashPayment, AmountSended, Check)
            Return New ApiResult With {.Total = 0, .Data = IDCashPayment, .Msg = Nothing, .MsgType = "ok"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDCashPayment, AmountSended, Check}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Do_CashCheck(IDCashPayment As Integer, Sended As Boolean) As Object
        Try
            dbContext.sp_Do_CashCheck(IDCashPayment, Sended)
            Return New ApiResult With {.Total = 0, .Data = IDCashPayment, .Msg = Nothing, .MsgType = "ok"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDCashPayment, Sended}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Overridable Function sp_Get_ListUserFee(options As ODataQueryOptions(Of sp_Get_ListUserFee_Result)) As Object
        Try
            Dim data = dbContext.sp_Get_ListUserFee(IDUser).ToList
            Dim queryable As IQueryable(Of sp_Get_ListUserFee_Result) = data.AsQueryable()
            If options.Filter IsNot Nothing Then
                queryable = options.Filter.ApplyTo(queryable, New ODataQuerySettings())
            End If
            Dim result = TryCast(options.ApplyTo(queryable), IEnumerable(Of sp_Get_ListUserFee_Result)).ToList
            Return New ApiResult With {.Total = queryable.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Overridable Function sp_Get_CashSUM() As Object
        Try
            Dim result = dbContext.sp_Get_CashSUM(IDUser).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_ListBilling() As Object
        Try
            Dim result = dbContext.sp_Get_ListBilling(IDUser).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_ListUrgCashPayments() As Object
        Try
            Dim result = dbContext.sp_Get_ListUrgCashPayments(IDUser).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet> _
    Public Function sp_Get_NotYetBilling() As Object
        Try
            Dim result = dbContext.sp_Get_NotYetBilling(IDUser).ToList
            Return New ApiResult With {.Total = result.Count, .Data = result, .Msg = {"OK"}, .MsgType = "success"}
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return New ApiResult With {.Total = 0, .Data = Nothing, .Msg = {ex.Message}, .MsgType = "error"}
        End Try
    End Function

    <HttpGet>
    Public Function sp_Do_OnePaymentOrder() As Object
        Try
            Dim NewIDPaymentOrder As New ObjectParameter("NewIDPaymentOrder", GetType(Int32))
            Dim result = dbContext.sp_Do_OnePaymentOrder(IDUser, NewIDPaymentOrder)
            Return NewIDPaymentOrder.Value
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}, .Status = 1})
            Return 0
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_10_05() As Object
        Try
            Dim result = dbContext.sp_DSHB_10_05(IDUser).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_10_10() As Object
        Try
            Dim result = dbContext.sp_DSHB_Claims(IDUser).ToList
            Return result
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_ClaimsVolume() As Object
        Try
            Return dbContext.sp_DSHB_ClaimsVolume(IDUser).ToList
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Function sp_DSHB_PaymentsSum() As Object
        Try
            Return dbContext.sp_DSHB_PaymentsSum(IDUser).ToList
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
            Return Nothing
        End Try
    End Function

    <HttpGet>
    Public Sub sp_Do_ChangeEmployerValidity(iDSpisyOsobyZam As Integer, rr_AddressValidity As Short)
        Try
            dbContext.sp_Do_ChangeEmployerValidity(iDSpisyOsobyZam, rr_AddressValidity)
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisyOsobyZam, rr_AddressValidity}})
        End Try
    End Sub

    <HttpGet>
    Public Sub sp_Do_AddEmployer(iDSpisu As Integer, employerName As String, employerIC As String, employerCity As String, employerHouseNum As String, employerStreet As String, employerZipCode As String, employerType As String, rr_AddressValidity As Short, employerAddrFull As String, employerContactSurname As String, employerContactName As String, employerContactEmail As String, employerContactPhone As String)
        Try
            dbContext.sp_Do_AddEmployer(iDSpisu, employerName, employerIC, employerCity, employerHouseNum, employerStreet, employerZipCode, employerType, rr_AddressValidity, employerAddrFull, employerContactSurname, employerContactName, employerContactEmail, employerContactPhone)
        Catch ex As Exception
            log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {iDSpisu, employerName, employerIC, employerCity, employerHouseNum, employerStreet, employerZipCode, employerType, rr_AddressValidity, employerAddrFull, employerContactSurname, employerContactName, employerContactEmail, employerContactPhone}})
        End Try
    End Sub

    '<HttpGet>
    'Public Function sp_DSHB_Get_AverageDaysForFV() As Object
    '    Try
    '        Return dbContext.sp_DSHB_Get_AverageDaysForFV(IDUser).ToList
    '    Catch ex As Exception
    '        log.WriteLog(New AppLog.LogItem With {.Message = ex.Message, .Params = New Object() {IDUser}})
    '        Return Nothing
    '    End Try
    'End Function

    <HttpGet>
    Public Function Errors(ErrSource As String, ErrText As String) As Object
        Try
            Dim err As New tblError
            err.ErrSource = Left(ErrSource, 40)
            err.ErrText = Left(ErrText, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
        Catch ex As Entity.Validation.DbEntityValidationException

        End Try
        Return Nothing
    End Function

    <HttpGet>
    Public Function Urady() As Object
        Try
            Dim model = dbContext.tblUradyCiselniks.Where(Function(e) e.GPSLatUradu Is Nothing Or e.GPSLngUradu Is Nothing).ToList()
            Return model
        Catch ex As Entity.Validation.DbEntityValidationException
        End Try
        Return Nothing
    End Function


    <HttpGet>
    Public Function UUrad(id As Integer, lat As String, lng As String) As Object
        Try
            Dim model = dbContext.tblUradyCiselniks.FirstOrDefault(Function(e) e.IDUradu = id)
            If model IsNot Nothing Then
                model.GPSLatUradu = lat
                model.GPSLngUradu = lng
                dbContext.SaveChanges()
            End If
        Catch ex As Entity.Validation.DbEntityValidationException
        End Try
        Return Nothing
    End Function

End Class
