Imports System.Data.Objects
Imports System.Net
Imports System.Web.Http
Imports Newtonsoft.Json
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Net.Mail
Imports System.Web.Http.Cors

'<EnableCors("*", "*", "*")>
Public Class MobileServiceController
    Inherits ApiController
    Public dbContext As New TRACEEntities

    <HttpGet>
    Public Function serverReady() As Boolean
        Return True
    End Function

    <HttpGet>
    Public Function sp_Do_AddError(text As String) As Boolean
        Dim iduser = getLoggedUserId()
        dbContext.sp_Do_AddError("Tablet synchronizace", iduser & "" & text)
        Return Nothing
    End Function

    Public Sub tblAAALog(text As String)
        Dim msg As New tblAAALog

        msg.Identifikace = "TABLET"
        msg.Data = text
        msg.cas = Now

        dbContext.tblAAALogs.Add(msg)
        dbContext.SaveChanges()
    End Sub

    <HttpGet>
    <AuthorizationBasic>
    Public Function AnDBSync() As Integer
        Try
            Dim q = HttpContext.Current.Request.QueryString
            Dim version = ""
            If Not String.IsNullOrEmpty(q("version")) Then
                version = q("version")
            End If
            Dim idz As Guid = System.Guid.NewGuid()
            If Not String.IsNullOrEmpty(q("idz")) Then
                idz = Guid.Parse(q("idz"))
            End If
            Dim idwrite = 0
            If Not String.IsNullOrEmpty(q("idwrite")) Then
                idwrite = q("idwrite")
            End If
            Dim state = 0
            If Not String.IsNullOrEmpty(q("state")) Then
                state = q("state")
            End If
            Dim reminders = Nothing
            If Not String.IsNullOrEmpty(q("reminders")) Then
                reminders = q("reminders")
            End If
            Dim procedures = Nothing
            If Not String.IsNullOrEmpty(q("procedures")) Then
                procedures = q("procedures")
            End If
            Dim objects = Nothing
            If Not String.IsNullOrEmpty(q("objects")) Then
                objects = q("objects")
            End If

            Dim IDUser As Integer = getLoggedUserId()

            Using dbContext
                If reminders IsNot Nothing Then
                    Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
                    Dim deserialize As Object = serializer.Deserialize(Of Object)(reminders)
                    For Each i In deserialize
                        Dim cmd = i("Command")
                        Dim lL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Integer))
                        dbContext.AGsp_ITabletJsonLog(IDUser, idwrite, idz, version, state, 2, cmd, "", lL_LastLapse)
                    Next
                End If

                If procedures IsNot Nothing Then
                    Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
                    Dim deserialize As Object = serializer.Deserialize(Of Object)(procedures)
                    For Each i In deserialize
                        Dim cmd = i("Command")
                        Dim lL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Integer))
                        dbContext.AGsp_ITabletJsonLog(IDUser, idwrite, idz, version, state, 2, cmd, "", lL_LastLapse)
                    Next
                End If

                If objects IsNot Nothing Then
                    Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
                    Dim deserialize As Object = serializer.Deserialize(Of Object)(objects)
                    For Each i In deserialize
                        Dim str As String = New JavaScriptSerializer().Serialize(i("Object")).ToString
                        Dim obj As Object = serializer.Deserialize(Of Object)(str)
                        Dim xml As String = JsonConvert.DeserializeXmlNode(obj).OuterXml.Trim()
                        Dim doc As XDocument = XDocument.Parse(xml)
                        doc...<object>.FirstOrDefault.AddFirst(New XElement("device", "tablet"))
                        doc...<object>.FirstOrDefault.AddFirst(New XElement("idz", idz))

                        Dim files = doc...<object>.<source>.<files>.<file>
                        If files.Count > 0 Then
                            For Each file As XElement In files
                                Dim name = file.<name>.Value.ToString
                                file.<fullPath>.Value = System.IO.Path.Combine(GetIMGDestination(), name)
                            Next
                        End If

                        xml = doc.ToString
                        Dim lL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Integer))
                        dbContext.AGsp_ITabletJsonLog(IDUser, idwrite, idz, version, state, 1, str, xml, lL_LastLapse)
                    Next
                End If
            End Using

            Return 3
        Catch ex As Exception
            Return 4
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function Android_getData(start As Boolean, varianta As Integer, skip As Integer, take As Integer, name As String, version As String) As Object
        Dim iduser = getLoggedUserId()
        Try
            If start Then
                Dim sumRowCnt = New ObjectParameter("SumRowCnt", GetType(Integer))
                Dim lL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Integer))
                Dim lastLapseText = New ObjectParameter("LastLapseText", GetType(String))

                dbContext.sp_ANDR_B5_Start(iduser, varianta, sumRowCnt, lL_LastLapse, lastLapseText)

                dbContext.sp_Do_EditAndroidVersion(iduser, version)

                Return New With {.sum = sumRowCnt.Value, .msg = lastLapseText.Value}
            Else
                Select Case name
                    Case "tblRegisterRestrictions"
                        Return dbContext.sp_ANDR_T5_tblRegisterRestrictions(skip, take).ToList
                    'Return dbContext.tblRegisterRestrictions.ToList
                    Case "vwrr_PersTypeMini"
                        Return dbContext.sp_ANDR_T5_vwrr_PersTypeMini(skip, take).ToList
                    'Return dbContext.vwrr_PersTypeMini.ToList
                    Case "sp_ANDR_Campaign"
                        Return dbContext.sp_ANDR_T5_Campaign(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Campaign(iduser, 0).ToList
                    Case "sp_ANDR_CampMember"
                        Return dbContext.sp_ANDR_T5_CampMember(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_CampMember(iduser, 0).ToList
                    Case "sp_ANDR_Get_Spisy"
                        Return dbContext.sp_ANDR_T5_Get_Spisy(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_Spisy(iduser, 0).ToList
                    Case "sp_ANDR_Get_AllAddressOfDebitor"
                        Return dbContext.sp_ANDR_T5_Get_AllAddressOfDebitor(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_AllAddressOfDebitor(iduser, 0).ToList
                    Case "sp_ANDR_Get2_Addresses"
                        Return dbContext.sp_ANDR_T5_Get2_Addresses(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get2_Addresses(iduser, 0).ToList
                    Case "sp_ANDR_Object_3137_14"
                        Return dbContext.sp_ANDR_T5_Object_3137_14(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Object_3137_14(iduser, 0).ToList
                    Case "sp_DSHB_10_01"
                        Return dbContext.sp_ANDR_T5_DSHB_10_01(iduser, skip, take).ToList
                    'Return dbContext.sp_DSHB_10_01(iduser).OrderBy(Function(e) e.IDOrder).ToList
                    Case "sp_DSHB_10_02"
                        Return dbContext.sp_ANDR_T5_DSHB_10_02(iduser, skip, take).ToList
                    'Return dbContext.sp_DSHB_10_02(iduser).ToList
                    Case "sp_ANDR_B3_Bonita"
                        'Return dbContext.sp_ANDR_B3_Bonita(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Bonita(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DetailSpisu"
                        'Return dbContext.sp_ANDR_B3_DetailSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DetailSpisu(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DetailSpisuG2"
                        'Return dbContext.sp_ANDR_B3_DetailSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DetailSpisuG2(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DohodyOUhrade"
                        'Return dbContext.sp_ANDR_B3_DohodyOUhrade(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DohodyOUhrade(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_Dokumentace"
                        'Return dbContext.sp_ANDR_B3_Dokumentace(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Dokumentace(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_HistorieDohod"
                        'Return dbContext.sp_ANDR_B3_HistorieDohod(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_HistorieDohod(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_HistorieSpisu"
                        'Return dbContext.sp_ANDR_B3_HistorieSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_HistorieSpisu(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_ListAllFV"
                        'Return dbContext.sp_ANDR_B3_ListAllFV(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_ListAllFV(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_Osoby"
                        'Return dbContext.sp_ANDR_B3_Osoby(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Osoby(iduser, skip, take).ToList
                    Case "sp_ANDR_Get_FVOsoby"
                        Return dbContext.sp_ANDR_T5_Get_FVOsoby(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_FVOsoby(iduser, 0).ToList
                    Case "sp_ANDR_B3_OsobyAddress"
                        'Return dbContext.sp_ANDR_B3_OsobyAddress(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyAddress(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyDalsiKontakt"
                        'Return dbContext.sp_ANDR_B3_OsobyDalsiKontakt(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyDalsiKontakt(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyEmail"
                        'Return dbContext.sp_ANDR_B3_OsobyEmail(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyEmail(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyPhone"
                        'Return dbContext.sp_ANDR_B3_OsobyPhone(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyPhone(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyRole"
                        'Return dbContext.sp_ANDR_B3_OsobyRole(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyRole(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyZam"
                        'Return dbContext.sp_ANDR_B3_OsobyZam(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyZam(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OtherInfo"
                        'Return dbContext.sp_ANDR_B3_OtherInfo(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OtherInfo(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_PlatbyDoslePo1OSN"
                        'Return dbContext.sp_ANDR_B3_PlatbyDoslePo1OSN(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_PlatbyDoslePo1OSN(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_PlatbyDoslePred1OSN"
                        'Return dbContext.sp_ANDR_B3_PlatbyDoslePred1OSN(iduser, 0)
                        Return dbContext.sp_ANDR_T5_PlatbyDoslePred1OSN(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpecifikaceDluhuFinUdaje"
                        'Return dbContext.sp_ANDR_B3_SpecifikaceDluhuFinUdaje(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpecifikaceDluhuFinUdaje(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpecifikaceDluhuVeritel"
                        'Return dbContext.sp_ANDR_B3_SpecifikaceDluhuVeritel(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpecifikaceDluhuVeritel(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpisyDluznika"
                        'Return dbContext.sp_ANDR_B3_SpisyDluznika(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpisyDluznika(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_TerminyOSN"
                        'Return dbContext.sp_ANDR_B3_TerminyOSN(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_TerminyOSN(iduser, skip, take).ToList
                    Case "sp_ANDR_Get_CreditorDetail"
                        Return dbContext.sp_ANDR_T5_Get_CreditorDetail(iduser, skip, take).ToList
                        'Return dbContext.sp_ANDR_Get_CreditorDetail(iduser, 0).ToList
                    Case Else
                        Return Nothing
                End Select
            End If
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("API Android_getData = IDUser, " & iduser, 40)
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return New With {.sum = 0, .msg = ex.Message}
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function Android_getData_G2(start As Boolean, varianta As Integer, skip As Integer, take As Integer, name As String, version As String) As Object
        Dim iduser = getLoggedUserId()
        Try
            If start Then
                Dim sumRowCnt = New ObjectParameter("SumRowCnt", GetType(Integer))
                Dim lL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Integer))
                Dim lastLapseText = New ObjectParameter("LastLapseText", GetType(String))

                dbContext.sp_ANDR_B5_Start(iduser, varianta, sumRowCnt, lL_LastLapse, lastLapseText)

                dbContext.sp_Do_EditAndroidVersion(iduser, version)

                Return New With {.sum = sumRowCnt.Value, .msg = lastLapseText.Value}
            Else
                Select Case name
                    Case "tblRegisterRestrictions"
                        Return dbContext.sp_ANDR_T5_tblRegisterRestrictions(skip, take).ToList
                    'Return dbContext.tblRegisterRestrictions.ToList
                    Case "vwrr_PersTypeMini"
                        Return dbContext.sp_ANDR_T5_vwrr_PersTypeMini(skip, take).ToList
                    'Return dbContext.vwrr_PersTypeMini.ToList
                    Case "sp_ANDR_Campaign"
                        Return dbContext.sp_ANDR_T5_Campaign(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Campaign(iduser, 0).ToList
                    Case "sp_ANDR_CampMember"
                        Return dbContext.sp_ANDR_T5_CampMember(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_CampMember(iduser, 0).ToList
                    Case "sp_ANDR_Get_Spisy"
                        Return dbContext.sp_ANDR_T5_Get_Spisy(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_Spisy(iduser, 0).ToList
                    Case "sp_ANDR_Get_AllAddressOfDebitor"
                        Return dbContext.sp_ANDR_T5_Get_AllAddressOfDebitor(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_AllAddressOfDebitor(iduser, 0).ToList
                    Case "sp_ANDR_Get2_Addresses"
                        Return dbContext.sp_ANDR_T5_Get2_Addresses(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get2_Addresses(iduser, 0).ToList
                    Case "sp_ANDR_Object_3137_14"
                        Return dbContext.sp_ANDR_T5_Object_3137_14(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Object_3137_14(iduser, 0).ToList
                    Case "sp_DSHB_10_01"
                        Return dbContext.sp_ANDR_T5_DSHB_10_01(iduser, skip, take).ToList
                    'Return dbContext.sp_DSHB_10_01(iduser).OrderBy(Function(e) e.IDOrder).ToList
                    Case "sp_DSHB_10_02"
                        Return dbContext.sp_ANDR_T5_DSHB_10_02(iduser, skip, take).ToList
                    'Return dbContext.sp_DSHB_10_02(iduser).ToList
                    Case "sp_ANDR_B3_Bonita"
                        'Return dbContext.sp_ANDR_B3_Bonita(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Bonita(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DetailSpisu"
                        'Return dbContext.sp_ANDR_B3_DetailSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DetailSpisu(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DetailSpisuG2"
                        'Return dbContext.sp_ANDR_B3_DetailSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DetailSpisuG2(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DohodyOUhrade"
                        'Return dbContext.sp_ANDR_B3_DohodyOUhrade(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DohodyOUhrade(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_Dokumentace"
                        'Return dbContext.sp_ANDR_B3_Dokumentace(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Dokumentace(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_HistorieDohod"
                        'Return dbContext.sp_ANDR_B3_HistorieDohod(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_HistorieDohod(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_HistorieSpisu"
                        'Return dbContext.sp_ANDR_B3_HistorieSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_HistorieSpisu(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_ListAllFV"
                        'Return dbContext.sp_ANDR_B3_ListAllFV(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_ListAllFV(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_Osoby"
                        'Return dbContext.sp_ANDR_B3_Osoby(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Osoby(iduser, skip, take).ToList
                    Case "sp_ANDR_Get_FVOsoby"
                        Return dbContext.sp_ANDR_T5_Get_FVOsoby(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_FVOsoby(iduser, 0).ToList
                    Case "sp_ANDR_B3_OsobyAddress"
                        'Return dbContext.sp_ANDR_B3_OsobyAddress(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyAddress(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyDalsiKontakt"
                        'Return dbContext.sp_ANDR_B3_OsobyDalsiKontakt(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyDalsiKontakt(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyEmail"
                        'Return dbContext.sp_ANDR_B3_OsobyEmail(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyEmail(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyPhone"
                        'Return dbContext.sp_ANDR_B3_OsobyPhone(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyPhone(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyRole"
                        'Return dbContext.sp_ANDR_B3_OsobyRole(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyRole(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyZam"
                        'Return dbContext.sp_ANDR_B3_OsobyZam(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyZam(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OtherInfo"
                        'Return dbContext.sp_ANDR_B3_OtherInfo(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OtherInfo(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_PlatbyDoslePo1OSN"
                        'Return dbContext.sp_ANDR_B3_PlatbyDoslePo1OSN(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_PlatbyDoslePo1OSN(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_PlatbyDoslePred1OSN"
                        'Return dbContext.sp_ANDR_B3_PlatbyDoslePred1OSN(iduser, 0)
                        Return dbContext.sp_ANDR_T5_PlatbyDoslePred1OSN(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpecifikaceDluhuFinUdaje"
                        'Return dbContext.sp_ANDR_B3_SpecifikaceDluhuFinUdaje(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpecifikaceDluhuFinUdaje(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpecifikaceDluhuVeritel"
                        'Return dbContext.sp_ANDR_B3_SpecifikaceDluhuVeritel(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpecifikaceDluhuVeritel(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpisyDluznika"
                        'Return dbContext.sp_ANDR_B3_SpisyDluznika(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpisyDluznika_G2(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_TerminyOSN"
                        'Return dbContext.sp_ANDR_B3_TerminyOSN(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_TerminyOSN(iduser, skip, take).ToList
                    Case "sp_ANDR_Get_CreditorDetail"
                        Return dbContext.sp_ANDR_T5_Get_CreditorDetail(iduser, skip, take).ToList
                        'Return dbContext.sp_ANDR_Get_CreditorDetail(iduser, 0).ToList
                    Case Else
                        Return Nothing
                End Select
            End If
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("API Android_getData_G2 = IDUser, " & iduser, 40)
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return New With {.sum = 0, .msg = ex.Message}
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function Android_getData_G3(start As Boolean, varianta As Integer, skip As Integer, take As Integer, name As String, version As String) As Object
        Dim iduser = getLoggedUserId()
        Try
            If start Then
                Dim sumRowCnt = New ObjectParameter("SumRowCnt", GetType(Integer))
                Dim lL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Integer))
                Dim lastLapseText = New ObjectParameter("LastLapseText", GetType(String))

                dbContext.sp_ANDR_B5_Start(iduser, varianta, sumRowCnt, lL_LastLapse, lastLapseText)

                dbContext.sp_Do_EditAndroidVersion(iduser, version)

                Return New With {.sum = sumRowCnt.Value, .msg = lastLapseText.Value}
            Else
                Select Case name
                    Case "tblRegisterRestrictions"
                        Return dbContext.sp_ANDR_T5_tblRegisterRestrictions(skip, take).ToList
                    'Return dbContext.tblRegisterRestrictions.ToList
                    Case "vwrr_PersTypeMini"
                        Return dbContext.sp_ANDR_T5_vwrr_PersTypeMini(skip, take).ToList
                    'Return dbContext.vwrr_PersTypeMini.ToList
                    Case "sp_ANDR_Campaign"
                        Return dbContext.sp_ANDR_T5_Campaign(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Campaign(iduser, 0).ToList
                    Case "sp_ANDR_CampMember"
                        Return dbContext.sp_ANDR_T5_CampMemberG2(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_CampMember(iduser, 0).ToList
                    Case "sp_ANDR_Get_Spisy"
                        Return dbContext.sp_ANDR_T5_Get_Spisy(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_Spisy(iduser, 0).ToList
                    Case "sp_ANDR_Get_AllAddressOfDebitor"
                        Return dbContext.sp_ANDR_T5_Get_AllAddressOfDebitor(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_AllAddressOfDebitor(iduser, 0).ToList
                    Case "sp_ANDR_Get2_Addresses"
                        Return dbContext.sp_ANDR_T5_Get2_Addresses(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get2_Addresses(iduser, 0).ToList
                    Case "sp_ANDR_Object_3137_14"
                        Return dbContext.sp_ANDR_T5_Object_3137_14(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Object_3137_14(iduser, 0).ToList
                    Case "sp_DSHB_10_01"
                        Return dbContext.sp_ANDR_T5_DSHB_10_01(iduser, skip, take).ToList
                    'Return dbContext.sp_DSHB_10_01(iduser).OrderBy(Function(e) e.IDOrder).ToList
                    Case "sp_DSHB_10_02"
                        Return dbContext.sp_ANDR_T5_DSHB_10_02(iduser, skip, take).ToList
                    'Return dbContext.sp_DSHB_10_02(iduser).ToList
                    Case "sp_ANDR_B3_Bonita"
                        'Return dbContext.sp_ANDR_B3_Bonita(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Bonita(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DetailSpisu"
                        'Return dbContext.sp_ANDR_B3_DetailSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DetailSpisuG3(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DetailSpisuG2"
                        'Return dbContext.sp_ANDR_B3_DetailSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DetailSpisuG2(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_DohodyOUhrade"
                        'Return dbContext.sp_ANDR_B3_DohodyOUhrade(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_DohodyOUhrade(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_Dokumentace"
                        'Return dbContext.sp_ANDR_B3_Dokumentace(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Dokumentace(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_HistorieDohod"
                        'Return dbContext.sp_ANDR_B3_HistorieDohod(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_HistorieDohod(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_HistorieSpisu"
                        'Return dbContext.sp_ANDR_B3_HistorieSpisu(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_HistorieSpisu(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_ListAllFV"
                        'Return dbContext.sp_ANDR_B3_ListAllFV(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_ListAllFV(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_Osoby"
                        'Return dbContext.sp_ANDR_B3_Osoby(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_Osoby(iduser, skip, take).ToList
                    Case "sp_ANDR_Get_FVOsoby"
                        Return dbContext.sp_ANDR_T5_Get_FVOsoby(iduser, skip, take).ToList
                    'Return dbContext.sp_ANDR_Get_FVOsoby(iduser, 0).ToList
                    Case "sp_ANDR_B3_OsobyAddress"
                        'Return dbContext.sp_ANDR_B3_OsobyAddress(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyAddress(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyDalsiKontakt"
                        'Return dbContext.sp_ANDR_B3_OsobyDalsiKontakt(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyDalsiKontakt(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyEmail"
                        'Return dbContext.sp_ANDR_B3_OsobyEmail(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyEmail(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyPhone"
                        'Return dbContext.sp_ANDR_B3_OsobyPhone(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyPhone(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyRole"
                        'Return dbContext.sp_ANDR_B3_OsobyRole(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyRole(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OsobyZam"
                        'Return dbContext.sp_ANDR_B3_OsobyZam(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OsobyZam(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_OtherInfo"
                        'Return dbContext.sp_ANDR_B3_OtherInfo(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_OtherInfo(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_PlatbyDoslePo1OSN"
                        'Return dbContext.sp_ANDR_B3_PlatbyDoslePo1OSN(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_PlatbyDoslePo1OSN(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_PlatbyDoslePred1OSN"
                        'Return dbContext.sp_ANDR_B3_PlatbyDoslePred1OSN(iduser, 0)
                        Return dbContext.sp_ANDR_T5_PlatbyDoslePred1OSN(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpecifikaceDluhuFinUdaje"
                        'Return dbContext.sp_ANDR_B3_SpecifikaceDluhuFinUdaje(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpecifikaceDluhuFinUdaje(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpecifikaceDluhuVeritel"
                        'Return dbContext.sp_ANDR_B3_SpecifikaceDluhuVeritel(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpecifikaceDluhuVeritel(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_SpisyDluznika"
                        'Return dbContext.sp_ANDR_B3_SpisyDluznika(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_SpisyDluznika_G2(iduser, skip, take).ToList
                    Case "sp_ANDR_B3_TerminyOSN"
                        'Return dbContext.sp_ANDR_B3_TerminyOSN(iduser, 0).ToList
                        Return dbContext.sp_ANDR_T5_TerminyOSN(iduser, skip, take).ToList
                    Case "sp_ANDR_Get_CreditorDetail"
                        Return dbContext.sp_ANDR_T5_Get_CreditorDetail(iduser, skip, take).ToList
                        'Return dbContext.sp_ANDR_Get_CreditorDetail(iduser, 0).ToList
                    Case Else
                        Return Nothing
                End Select
            End If
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("API Android_getData_G3 = IDUser, " & iduser, 40)
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return New With {.sum = 0, .msg = ex.Message}
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function sp_ANDR_C5_AddFVReport(rr_StateFVReport As Short, createDate As Date, iDSpisu As Integer, aCC As String, iDSpisyOsoby As Integer, subscriberID As Long, iDSpisyOsobyAdresy As Integer, debtLastFirstName As String)
        Dim IDUser As Integer = getLoggedUserId()
        Dim UIDFVReport = Guid.NewGuid()
        Try
            tblAAALog("sp_ANDR_C5_AddFVReport")

            dbContext.sp_ANDR_C5_AddFVReport(UIDFVReport, IDUser, rr_StateFVReport, createDate, iDSpisu, aCC, iDSpisyOsoby, subscriberID, iDSpisyOsoby, debtLastFirstName)

            Return New With {.uIDFVReport = UIDFVReport, .iDUser = IDUser, .msg = Nothing}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Return New With {.uIDFVReport = 0, .iDUser = IDUser, .msg = ex.Message}
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function sp_ANDR_C5_AddFVReportPol(uIDFVReport As System.Guid, json As String) As Object
        Try
            Dim j As JavaScriptSerializer = New JavaScriptSerializer()
            Dim a As Object = j.Deserialize(Of Object)(json)
            Dim countOfXMLCharacter As Integer = 0
            Dim countOfXMLRows As Integer = 0
            Dim ordering As Integer = 1
            For Each i In a
                Dim obj = New JavaScriptSerializer().Serialize(i("Object"))
                Dim xml As String = JsonConvert.DeserializeXmlNode(obj).OuterXml.Trim()
                Dim doc As XDocument = XDocument.Parse(xml)
                doc...<object>.FirstOrDefault.AddFirst(New XElement("device", "tablet"))
                doc...<object>.FirstOrDefault.AddFirst(New XElement("idz", uIDFVReport.ToString("d")))

                'Dim ele = doc...<object>.<source>.<files>
                'If ele.Count > 0 Then
                '    Dim files = <files/>
                '    For Each f As XElement In ele
                '        files.Add(f.<file>.FirstOrDefault)
                '    Next
                '    ele.Remove()
                '    doc...<object>.<source>.FirstOrDefault.Add(files)
                'End If

                Dim files = doc...<object>.<source>.<files>.<file>
                If files.Count > 0 Then
                    For Each file As XElement In files
                        Dim fname = file.<name>.Value.ToString
                        file.<fullPath>.Value = System.IO.Path.Combine(GetIMGDestination(), fname)
                    Next
                End If

                Dim name = i("Name")
                Dim lL_LastLapse = New ObjectParameter("LL_LastLapse", GetType(Integer))

                Dim xmlStr As String = ""
                Dim lines As String() = doc.ToString.Split(vbCr)
                For Each line As String In lines
                    xmlStr += line.Trim
                Next
                xmlStr = xmlStr.Replace(" />", "/>")

                dbContext.sp_ANDR_C5_AddFVReportPol(uIDFVReport, ordering, name, xmlStr, 1, 0, 1, 1, lL_LastLapse)

                ordering = ordering + 1
                countOfXMLCharacter += xmlStr.Length
                countOfXMLRows += 1
            Next
            'uIDFVReport As Nullable(Of System.Guid), countOfXMLRows As Nullable(Of Integer), rr_StateFVReport As ObjectParameter, detail As ObjectParameter

            Dim rr_StateFVReport = New ObjectParameter("rr_StateFVReport", GetType(Integer))
            Dim detail = New ObjectParameter("Detail", GetType(String))
            dbContext.sp_ANDR_C5_FVReportXMLControl(uIDFVReport, countOfXMLCharacter, rr_StateFVReport, detail)

            Return New With {.sum = countOfXMLRows, .msg = detail.Value, .error = Nothing}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Return New With {.sum = 0, .msh = Nothing, .error = ex.Message}
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function sp_ANDR_C5_AddFVReportStart(uIDFVReport As System.Guid, count As Integer) As Object
        Try
            Dim rr_StateFVReport = New ObjectParameter("rr_StateFVReport", GetType(Integer))
            Dim detail = New ObjectParameter("Detail", GetType(String))
            dbContext.sp_ANDR_C5_AddFVReportStart(uIDFVReport, count, rr_StateFVReport, detail)
            Return New With {.sum = count, .msg = detail.Value, .error = False}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Return New With {.sum = 0, .msg = ex.Message, .error = True}
        End Try
    End Function

    <HttpGet>
    Public Sub Android_Errors(ErrSource As String, ErrText As String)
        Try
            Dim err As New tblError
            err.ErrSource = Left(ErrSource, 40)
            err.ErrText = Left(ErrText, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
        Catch ex As Entity.Validation.DbEntityValidationException
            Dim IDUser As Integer = getLoggedUserId()
            For Each eve In ex.EntityValidationErrors
                Dim tbl = eve.Entry.Entity.GetType().Name
                Dim state = eve.Entry.State
                For Each ve In eve.ValidationErrors
                    Dim txt = ("Field: " & ve.PropertyName & ", Error: " & ve.ErrorMessage)
                    Dim err As New tblError
                    err.ErrSource = Left("API Android_Errors = IDUser, " & IDUser, 40)
                    err.ErrText = Left(txt, 400)
                    err.ErrDate = Now
                    dbContext.tblErrors.Add(err)
                    dbContext.SaveChanges()
                Next
            Next
        End Try
    End Sub

    <HttpGet>
    <AuthorizationBasic>
    Public Function getUser() As Object
        Try
            Dim result = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = User.Identity.Name)

            Return New With {.user = New With {
            .IDUser = result.IDUser,
            .IDRole = result.IDRole,
            .UserFirstName = result.UserFirstName,
            .UserLastName = result.UserLastName,
            .UserLogin = result.UserLogin}
            }

        Catch ex As Exception
            Return New With {.user = Nothing}
        End Try
    End Function

    Function getLoggedUserId() As Integer
        Dim result = dbContext.tblUsers.FirstOrDefault(Function(e) e.UserLogin = User.Identity.Name)
        If result IsNot Nothing Then
            dbContext.sp_Do_AndroidLastCall(result.IDUser)
            Return result.IDUser
        Else
            Return 0
        End If
    End Function

    <HttpGet>
    Public Function Android_TStamp() As Object
        Try
            Dim TSt As New ObjectParameter("TStamp", GetType(Integer))
            dbContext.sp_ANDR_Get_LastTimeStamp(TSt)
            Return TSt.Value
        Catch ex As Exception
            Return 0
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function Android_Data(TStamp As String, varianta As Integer, model_name As String) As Object
        Dim IDUser As Integer = getLoggedUserId()
        Try
            Select Case model_name
                Case "tblRegisterRestrictions"
                    Return dbContext.tblRegisterRestrictions.ToList
                Case "vwrr_PersTypeMini"
                    Return dbContext.vwrr_PersTypeMini.ToList
                Case "sp_ANDR_Campaign"
                    Return dbContext.sp_ANDR_Campaign(IDUser, varianta).ToList
                Case "sp_ANDR_CampMember"
                    Return dbContext.sp_ANDR_CampMember(IDUser, varianta).ToList
                Case "sp_ANDR_Get_Spisy"
                    Return dbContext.sp_ANDR_Get_Spisy(IDUser, TStamp).ToList
                Case "sp_ANDR_Get_AllAddressOfDebitor"
                    Return dbContext.sp_ANDR_Get_AllAddressOfDebitor(IDUser, TStamp).ToList
                Case "sp_ANDR_Get2_Addresses"
                    Return dbContext.sp_ANDR_Get2_Addresses(IDUser, TStamp).ToList
                Case "sp_ANDR_Object_3137_14"
                    Return dbContext.sp_ANDR_Object_3137_14(IDUser, TStamp).ToList
                Case "sp_DSHB_10_01"
                    Return dbContext.sp_DSHB_10_01(IDUser).OrderBy(Function(e) e.IDOrder).ToList
                Case "sp_DSHB_10_02"
                    Return dbContext.sp_DSHB_10_02(IDUser).ToList
                Case "sp_ANDR_B3_Bonita"
                    Return dbContext.sp_ANDR_B3_Bonita(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_DetailSpisu"
                    Return dbContext.sp_ANDR_B3_DetailSpisu(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_DohodyOUhrade"
                    Return dbContext.sp_ANDR_B3_DohodyOUhrade(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_Dokumentace"
                    Return dbContext.sp_ANDR_B3_Dokumentace(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_HistorieDohod"
                    Return dbContext.sp_ANDR_B3_HistorieDohod(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_HistorieSpisu"
                    Return dbContext.sp_ANDR_B3_HistorieSpisu(IDUser, TStamp).ToList
                Case "sp_ANDR_B4_HistorieSpisu"
                    Return dbContext.sp_ANDR_B4_HistorieSpisu(IDUser, TStamp, varianta).ToList
                Case "sp_ANDR_B3_ListAllFV"
                    Return dbContext.sp_ANDR_B3_ListAllFV(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_Osoby"
                    Return dbContext.sp_ANDR_B3_Osoby(IDUser, TStamp).ToList
                Case "sp_ANDR_Get_FVOsoby"
                    Return dbContext.sp_ANDR_Get_FVOsoby(IDUser, TStamp).ToList
                Case "sp_ANDR_B4_Osoby"
                    Return dbContext.sp_ANDR_B4_Osoby(IDUser, TStamp, varianta).ToList
                Case "sp_ANDR_B3_OsobyAddress"
                    Return dbContext.sp_ANDR_B3_OsobyAddress(IDUser, TStamp).ToList
                Case "sp_ANDR_B4_OsobyAddress"
                    Return dbContext.sp_ANDR_B4_OsobyAddress(IDUser, TStamp, varianta).ToList
                Case "sp_ANDR_B3_OsobyDalsiKontakt"
                    Return dbContext.sp_ANDR_B3_OsobyDalsiKontakt(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_OsobyEmail"
                    Return dbContext.sp_ANDR_B3_OsobyEmail(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_OsobyPhone"
                    Return dbContext.sp_ANDR_B3_OsobyPhone(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_OsobyRole"
                    Return dbContext.sp_ANDR_B3_OsobyRole(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_OsobyZam"
                    Return dbContext.sp_ANDR_B3_OsobyZam(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_OtherInfo"
                    Return dbContext.sp_ANDR_B3_OtherInfo(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_PlatbyDoslePo1OSN"
                    Return dbContext.sp_ANDR_B3_PlatbyDoslePo1OSN(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_PlatbyDoslePred1OSN"
                    Return dbContext.sp_ANDR_B3_PlatbyDoslePred1OSN(IDUser, TStamp)
                Case "sp_ANDR_B3_SpecifikaceDluhuFinUdaje"
                    Return dbContext.sp_ANDR_B3_SpecifikaceDluhuFinUdaje(IDUser, TStamp).ToList
                Case "sp_ANDR_B4_SpecifikaceDluhuFinUdaje"
                    Return dbContext.sp_ANDR_B4_SpecifikaceDluhuFinUdaje(IDUser, TStamp, varianta).ToList
                Case "sp_ANDR_B3_SpecifikaceDluhuVeritel"
                    Return dbContext.sp_ANDR_B3_SpecifikaceDluhuVeritel(IDUser, TStamp).ToList
                Case "sp_ANDR_B4_SpecifikaceDluhuVeritel"
                    Return dbContext.sp_ANDR_B4_SpecifikaceDluhuVeritel(IDUser, TStamp, varianta).ToList
                Case "sp_ANDR_B3_SpisyDluznika"
                    Return dbContext.sp_ANDR_B3_SpisyDluznika(IDUser, TStamp).ToList
                Case "sp_ANDR_B3_TerminyOSN"
                    Return dbContext.sp_ANDR_B3_TerminyOSN(IDUser, TStamp).ToList
                Case "sp_ANDR_Get_CreditorDetail"
                    Return dbContext.sp_ANDR_Get_CreditorDetail(IDUser, TStamp).ToList
                Case Else
                    Return Nothing
            End Select
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("API Android_Data = IDUser, " & IDUser, 40)
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return Nothing
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic> _
    Public Function Android_Init(TStamp As String, varianta As Integer) As Object
        Dim IDUser As Integer = getLoggedUserId()
        Try
            Dim TSt As New ObjectParameter("TStamp", GetType(Integer))
            dbContext.sp_ANDR_Get_LastTimeStamp(TSt)

            Dim result = New With {
                .TStamp = TSt.Value,
                .Tables = New With {
                .tblRegisterRestrictions = dbContext.tblRegisterRestrictions.ToList,
                .vwrr_PersTypeMini = dbContext.vwrr_PersTypeMini.ToList,
                .sp_ANDR_Campaign = dbContext.sp_ANDR_Campaign(IDUser, varianta).ToList,
                .sp_ANDR_CampMember = dbContext.sp_ANDR_CampMember(IDUser, varianta).ToList,
                .sp_ANDR_Get_Spisy = dbContext.sp_ANDR_Get_Spisy(IDUser, TStamp).ToList,
                .sp_ANDR_Get_AllAddressOfDebitor = dbContext.sp_ANDR_Get_AllAddressOfDebitor(IDUser, TStamp).ToList,
                .sp_ANDR_Get2_Addresses = dbContext.sp_ANDR_Get2_Addresses(IDUser, TStamp).ToList,
                .sp_ANDR_Object_3137_14 = dbContext.sp_ANDR_Object_3137_14(IDUser, TStamp).ToList,
                .sp_DSHB_10_01 = dbContext.sp_DSHB_10_01(IDUser).OrderBy(Function(e) e.IDOrder).ToList,
                .sp_DSHB_10_02 = dbContext.sp_DSHB_10_02(IDUser).ToList,
                .sp_ANDR_B3_Bonita = dbContext.sp_ANDR_B3_Bonita(IDUser, TStamp).ToList,
                .sp_ANDR_B3_DetailSpisu = dbContext.sp_ANDR_B3_DetailSpisu(IDUser, TStamp).ToList,
                .sp_ANDR_B3_DohodyOUhrade = dbContext.sp_ANDR_B3_DohodyOUhrade(IDUser, TStamp).ToList,
                .sp_ANDR_B3_Dokumentace = dbContext.sp_ANDR_B3_Dokumentace(IDUser, TStamp).ToList,
                .sp_ANDR_B3_HistorieDohod = dbContext.sp_ANDR_B3_HistorieDohod(IDUser, TStamp).ToList,
                .sp_ANDR_B3_HistorieSpisu = dbContext.sp_ANDR_B3_HistorieSpisu(IDUser, TStamp).ToList,
                .sp_ANDR_B3_ListAllFV = dbContext.sp_ANDR_B3_ListAllFV(IDUser, TStamp).ToList,
                .sp_ANDR_B3_Osoby = dbContext.sp_ANDR_B3_Osoby(IDUser, TStamp).ToList,
                .sp_ANDR_Get_FVOsoby = dbContext.sp_ANDR_Get_FVOsoby(IDUser, TStamp).ToList,
                .sp_ANDR_B3_OsobyAddress = dbContext.sp_ANDR_B3_OsobyAddress(IDUser, TStamp).ToList,
                .sp_ANDR_B3_OsobyDalsiKontakt = dbContext.sp_ANDR_B3_OsobyDalsiKontakt(IDUser, TStamp).ToList,
                .sp_ANDR_B3_OsobyEmail = dbContext.sp_ANDR_B3_OsobyEmail(IDUser, TStamp).ToList,
                .sp_ANDR_B3_OsobyPhone = dbContext.sp_ANDR_B3_OsobyPhone(IDUser, TStamp).ToList,
                .sp_ANDR_B3_OsobyRole = dbContext.sp_ANDR_B3_OsobyRole(IDUser, TStamp).ToList,
                .sp_ANDR_B3_OsobyZam = dbContext.sp_ANDR_B3_OsobyZam(IDUser, TStamp).ToList,
                .sp_ANDR_B3_OtherInfo = dbContext.sp_ANDR_B3_OtherInfo(IDUser, TStamp).ToList,
                .sp_ANDR_B3_PlatbyDoslePo1OSN = dbContext.sp_ANDR_B3_PlatbyDoslePo1OSN(IDUser, TStamp).ToList,
                .sp_ANDR_B3_PlatbyDoslePred1OSN = dbContext.sp_ANDR_B3_PlatbyDoslePred1OSN(IDUser, TStamp),
                .sp_ANDR_B3_SpecifikaceDluhuFinUdaje = dbContext.sp_ANDR_B3_SpecifikaceDluhuFinUdaje(IDUser, TStamp).ToList,
                .sp_ANDR_B3_SpecifikaceDluhuVeritel = dbContext.sp_ANDR_B3_SpecifikaceDluhuVeritel(IDUser, TStamp).ToList,
                .sp_ANDR_B3_SpisyDluznika = dbContext.sp_ANDR_B3_SpisyDluznika(IDUser, TStamp).ToList,
                .sp_ANDR_B3_TerminyOSN = dbContext.sp_ANDR_B3_TerminyOSN(IDUser, TStamp).ToList,
                .sp_ANDR_Get_CreditorDetail = dbContext.sp_ANDR_Get_CreditorDetail(IDUser, TStamp).ToList
              }
            }

            Return result
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("API Android_Init = IDUser, " & IDUser, 40)
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return Nothing
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic> _
    Public Function Android_SpSync(jsonString As String) As Object
        Dim IDUser As Integer = getLoggedUserId()
        Dim j As JavaScriptSerializer = New JavaScriptSerializer()
        Dim a As Object = j.Deserialize(Of Object)(jsonString)
        For Each i In a
            Try
                Dim cmd = i("Command")
                dbContext.Database.ExecuteSqlCommand(cmd)
            Catch ex As Exception
                While ex.InnerException IsNot Nothing
                    ex = ex.InnerException
                End While
                Dim err As New tblError
                err.ErrSource = Left("API Android_SpSync = IDUser, " & IDUser, 40)
                err.ErrText = Left(ex.Message, 400)
                err.ErrDate = Now
                dbContext.tblErrors.Add(err)
                dbContext.SaveChanges()
            End Try
        Next
        Return True
    End Function

    <HttpGet>
    <AuthorizationBasic> _
    Public Function Android_ObjSync(IDSpisu As Integer, jsonString As String) As Object
        Dim IDUser As Integer = getLoggedUserId()
        Try
            Dim j As JavaScriptSerializer = New JavaScriptSerializer()
            Dim a As Object = j.Deserialize(Of Object)(jsonString)
            Dim IDVisitReport = New ObjectParameter("IDVisitReport", GetType(Integer))
            Dim SumTxt = New ObjectParameter("SumTxt", GetType(String))
            Dim Ordering = 1
            Dim idz = Guid.NewGuid().ToString("d")

            dbContext.Database.ExecuteSqlCommand("DELETE FROM tblOSNUnfinished WHERE IDUser=" & IDUser)

            For Each i In a
                Dim obj = New JavaScriptSerializer().Serialize(i("Object"))

                Dim xml As String = JsonConvert.DeserializeXmlNode(obj).OuterXml.Trim()
                Dim doc As XDocument = XDocument.Parse(xml)
                doc...<object>.FirstOrDefault.AddFirst(New XElement("device", "tablet"))
                doc...<object>.FirstOrDefault.AddFirst(New XElement("idz", idz))

                Dim ele = doc...<object>.<source>.<files>
                If ele.Count > 0 Then
                    Dim files = <files></files>
                    For Each f As XElement In ele
                        files.Add(f.<file>.FirstOrDefault)
                    Next
                    ele.Remove()
                    doc...<object>.<source>.FirstOrDefault.Add(files)
                End If

                If i("Name") = "object_3131" Then
                    Dim x = 0
                End If

                Dim item As New tblOSNUnfinished
                item.IDUser = IDUser
                item.Ordering = Ordering
                item.Object = i("Name")
                item.ObjectXML = doc.ToString
                item.Finished = 1
                item.IDSpisu = IDSpisu
                item.IsSubObject = 0
                item.Head = 1
                item.rr_IDFVProcess = 1

                dbContext.tblOSNUnfinisheds.Add(item)
                dbContext.SaveChanges()

                Ordering = Ordering + 1
            Next

            dbContext.sp_Rec_Start(IDUser, 1, IDSpisu, IDVisitReport, SumTxt)

            Return New With {.SumTxt = SumTxt.Value, .IsError = False}
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("API Android_ObjSync = IDUser, " & IDUser, 40)
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return New With {.SumTxt = ex.Message, .IsError = True}
        End Try
    End Function

    <HttpPost>
    <AuthorizationBasic>
    Public Function Android_ObjectPhoto() As Object
        Try
            Dim parameters As System.Collections.Specialized.NameValueCollection = HttpContext.Current.Request.Params
            Dim f As HttpPostedFile = HttpContext.Current.Request.Files("file")

            Using db As New TRACEEntities
                Dim destination As String = Nothing
                Dim dir As String = Now.ToString("yyyyMM")
                Dim img_rr = db.tblRegisterRestrictions.FirstOrDefault(Function(e) e.Register = "rr_IMG_PATH")
                If img_rr IsNot Nothing Then
                    dir = Path.Combine(img_rr.Val, dir)
                    If Not Directory.Exists(dir) Then
                        Directory.CreateDirectory(dir)
                    End If
                    destination = Path.Combine(dir, f.FileName)
                Else
                    Return New With {.exception = "rr_IMG_PATH není definována.", .fullPath = Nothing}
                End If

                If System.IO.File.Exists(destination) Then
                    System.IO.File.Delete(destination)
                End If

                f.SaveAs(destination)
                Return New With {.exception = Nothing, .fullPath = destination}
            End Using
        Catch ex As Exception
            Dim IDUser As Integer = getLoggedUserId()
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("API Android_ObjectPhoto = IDUser, " & IDUser, 40)
            err.ErrText = Left("Error: " & ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return New With {.exception = ex.Message, .fullPath = Nothing}
        End Try
    End Function

    <HttpPost>
    <AuthorizationBasic>
    Public Function Android_Upload() As Object
        If HttpContext.Current.Request.Files.Count > 0 Then
            Try
                Dim files As HttpFileCollection = HttpContext.Current.Request.Files
                Dim form = HttpContext.Current.Request.Form
                For i As Integer = 0 To files.Count - 1
                    Dim file As HttpPostedFile = files(i)
                    Dim fname As String = form("name")
                    Using db As New TRACEEntities
                        Dim destination As String = Nothing
                        Dim dir As String = Now.ToString("yyyyMM")
                        Dim img_rr = db.tblRegisterRestrictions.FirstOrDefault(Function(e) e.Register = "rr_IMG_PATH")
                        If img_rr IsNot Nothing Then
                            dir = Path.Combine(img_rr.Val, dir)
                            If Not Directory.Exists(dir) Then
                                Directory.CreateDirectory(dir)
                            End If
                            destination = Path.Combine(dir, fname)
                        Else
                            Return New With {.exception = "rr_IMG_PATH není definována.", .fullPath = Nothing}
                        End If
                        If System.IO.File.Exists(destination) Then
                            System.IO.File.Delete(destination)
                        End If

                        file.SaveAs(destination)

                        Return New With {.error = Nothing, .fullPath = destination}
                    End Using
                Next
            Catch ex As Exception
                Dim IDUser As Integer = getLoggedUserId()
                While ex.InnerException IsNot Nothing
                    ex = ex.InnerException
                End While
                Return New With {.error = "API Android_Upload error IDUser: " & IDUser & ", message: " & ex.Message, .fullPath = Nothing}
            End Try
        End If


        'Try
        '    Dim f As HttpPostedFile = HttpContext.Current.Request.Files("file")
        '    Dim q = HttpContext.Current.Request.Form
        '    Dim ExpectedImagePrefix = "data:image/jpeg;base64,"
        '    Dim file = Nothing
        '    If Not String.IsNullOrEmpty(q("data")) Then
        '        file = q("data")
        '    End If
        '    Dim name = Now.ToString("yyyyMMddHHmmss")
        '    If Not String.IsNullOrEmpty(q("name")) Then
        '        name = q("name")
        '    End If
        '    If file IsNot Nothing Then
        '        If file.StartsWith(ExpectedImagePrefix) Then
        '            Dim base64 As String = file.Substring(ExpectedImagePrefix.Length)
        '            Dim data As Byte() = Convert.FromBase64String(base64.Replace(" ", "+"))
        '            Using db As New TRACEEntities
        '                Dim destination As String = Nothing
        '                Dim dir As String = Now.ToString("yyyyMM")
        '                Dim img_rr = db.tblRegisterRestrictions.FirstOrDefault(Function(e) e.Register = "rr_IMG_PATH")

        '                If img_rr IsNot Nothing Then
        '                    dir = Path.Combine(img_rr.Val, dir)
        '                    If Not Directory.Exists(dir) Then
        '                        Directory.CreateDirectory(dir)
        '                    End If
        '                    destination = Path.Combine(dir, name)
        '                Else
        '                    Return New With {.exception = "rr_IMG_PATH není definována.", .fullPath = Nothing}
        '                End If

        '                If System.IO.File.Exists(destination) Then
        '                    System.IO.File.Delete(destination)
        '                End If

        '                System.IO.File.WriteAllBytes(destination, data)

        '                Return New With {.error = Nothing, .fullPath = destination}
        '            End Using
        '        Else
        '            Return New With {.error = "Soubor není typu image/jpeg", .fullPath = Nothing}
        '        End If
        '    Else
        '        Return New With {.error = "Soubor neobsahuje žádná data", .fullPath = Nothing}
        '    End If
        'Catch ex As Exception
        '    Dim IDUser As Integer = getLoggedUserId()
        '    While ex.InnerException IsNot Nothing
        '        ex = ex.InnerException
        '    End While
        '    Dim err As New tblError
        '    err.ErrSource = Left("API Android_Upload = IDUser, " & IDUser, 40)
        '    err.ErrText = Left("Error: " & ex.Message, 400)
        '    err.ErrDate = Now
        '    dbContext.tblErrors.Add(err)
        '    dbContext.SaveChanges()
        '    Return New With {.exception = ex.Message, .fullPath = Nothing}
        'End Try
    End Function


    <HttpGet>
    Public Function GetIMGDestination() As String
        Try
            Using db As New TRACEEntities
                Dim dir As String = Now.ToString("yyyyMM")
                Dim img_rr = db.tblRegisterRestrictions.FirstOrDefault(Function(e) e.Register = "rr_IMG_PATH")
                If img_rr IsNot Nothing Then
                    dir = Path.Combine(img_rr.Val, dir)
                    If Not Directory.Exists(dir) Then
                        Directory.CreateDirectory(dir)
                    End If
                    Return dir
                Else
                    Dim IDUser As Integer = getLoggedUserId()
                    Dim err As New tblError
                    err.ErrSource = Left("API rr_IMG_PATH IDUser, " & IDUser, 40)
                    err.ErrText = Left("Error: rr_IMG_PATH nenalezen", 400)
                    err.ErrDate = Now
                    dbContext.tblErrors.Add(err)
                    dbContext.SaveChanges()
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            Dim IDUser As Integer = getLoggedUserId()
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = Left("API rr_IMG_PATH IDUser " & IDUser, 40)
            err.ErrText = Left("Error: " & ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return Nothing
        End Try
    End Function

    <HttpPost>
    <AuthorizationBasic>
    Public Function Android_Upload2() As Object

        Try
            If HttpContext.Current.Request.Files.Count > 0 Then
                Dim files As HttpFileCollection = HttpContext.Current.Request.Files
                Dim form = HttpContext.Current.Request.Form
                For i As Integer = 0 To files.Count - 1
                    Dim file As HttpPostedFile = files(i)
                    Dim destination As String = form("serverPath")
                    If System.IO.File.Exists(destination) Then
                        System.IO.File.Delete(destination)
                    End If

                    file.SaveAs(destination)
                Next
                Return New With {.error = Nothing, .fullPath = Nothing}
            Else
                Return New With {.error = Nothing, .fullPath = Nothing}
            End If
        Catch ex As Exception
            Dim IDUser As Integer = getLoggedUserId()
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Return New With {.error = "API Android_Upload error IDUser: " & IDUser & ", message: " & ex.Message, .fullPath = Nothing}
        End Try


    End Function

    <HttpGet>
    Public Function Android_Update()
        Dim p = System.Web.Hosting.HostingEnvironment.MapPath("~/Android")
        Dim di As New DirectoryInfo(p)
        Dim apk = di.GetFiles("*.apk").FirstOrDefault
        If apk IsNot Nothing Then
            Dim result As HttpResponseMessage = New HttpResponseMessage(HttpStatusCode.OK)
            Dim stream As New FileStream(apk.FullName, FileMode.Open, FileAccess.Read)
            result.Content = New StreamContent(stream)
            result.Content.Headers.ContentType = New MediaTypeHeaderValue("application/vnd.android.package-archive")
            Return result
        End If
        Return Nothing
    End Function

    <HttpGet>
    Public Function Android_CheckUpdate(version As String)
        Dim path = System.Web.Hosting.HostingEnvironment.MapPath("~/Android/version.xml")
        Dim xml = XDocument.Load(path)
        Dim cur_code = CInt(version.Replace(".", ""))
        Dim new_code = CInt(xml.Root.Element("version").Value.Replace(".", ""))
        Return New With {.deviceCode = cur_code, .serverCode = new_code, .newVersion = xml.Root.Element("version").Value}
    End Function

    <HttpGet>
    Public Function Android_FileExists(IDSpisyDocument As Integer) As Object
        Using dbContext
            Dim file = dbContext.tblSpisyDocuments.FirstOrDefault(Function(e) e.IDSpisyDocument = IDSpisyDocument)
            If file IsNot Nothing Then
                If System.IO.File.Exists(file.DocuLink) Then
                    'soubor nalezen
                    Return New With {.exception = Nothing}
                Else
                    'soubor nenalezen ve slozce
                    Dim err As New tblError
                    err.ErrSource = "API Android_FileExists"
                    err.ErrText = Left("Soubor nenalezen: " & file.DocuLink, 400)
                    err.ErrDate = Now
                    dbContext.tblErrors.Add(err)
                    dbContext.SaveChanges()
                    Return New With {.exception = "Server EOS nenalezl soubor '" & file.DocuLink & "'."}
                End If
            Else
                'soubor nenalezen v databazi
                Dim err As New tblError
                err.ErrSource = "API Android_FileExists"
                err.ErrText = Left("Soubor nenalezen v databázi ", 400)
                err.ErrDate = Now
                dbContext.tblErrors.Add(err)
                dbContext.SaveChanges()
                Return New With {.exception = "Soubor v databázi nebyl nalezen"}
            End If
        End Using
    End Function

    <HttpGet>
    <AuthorizationBasic> _
    Public Function Android_DocuDownload(ID As Integer)
        Dim result As HttpResponseMessage
        Try
            Using dbContext
                Dim file = dbContext.tblSpisyDocuments.FirstOrDefault(Function(e) e.IDSpisyDocument = ID)
                If file IsNot Nothing Then
                    Dim stream As New FileStream(file.DocuLink, FileMode.Open, FileAccess.Read)
                    result = New HttpResponseMessage(HttpStatusCode.OK)
                    result.Content = New StreamContent(stream)
                Else
                    result = New HttpResponseMessage(HttpStatusCode.NotFound)
                    result.Content = Nothing
                End If
            End Using
            Return result
        Catch ex As Exception
            result = New HttpResponseMessage(HttpStatusCode.NotFound)
            result.Content = Nothing
            Return result
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function Android_SendServiceMail(body As String) As Object
        Try
            Dim mail As New MailMessage()
            mail.From = New MailAddress("petrnovak81@seznam.cz", "TRACE Android") 'od koho
            mail.To.Add("novak@agilo.cz") 'komu
            mail.Subject = "TRACE Android"
            mail.Body = body
            mail.IsBodyHtml = True

            Dim client As New SmtpClient()
            client.Host = "smtp.seznam.cz"
            client.Port = "465"
            client.EnableSsl = False
            client.UseDefaultCredentials = True
            client.Credentials = New System.Net.NetworkCredential("petrnovak81@seznam.cz", "8106105458")
            client.Send(mail)
            Return "ok"
        Catch ex As Exception
            While ex.InnerException IsNot Nothing
                ex = ex.InnerException
            End While
            Dim err As New tblError
            err.ErrSource = "API Android_SendServiceMail"
            err.ErrText = Left(ex.Message, 400)
            err.ErrDate = Now
            dbContext.tblErrors.Add(err)
            dbContext.SaveChanges()
            Return ex.Message
        End Try
    End Function

    <HttpGet>
    <AuthorizationBasic>
    Public Function XAMARIN_Login() As Integer
        Dim IDUser As Integer = getLoggedUserId()
        Return IDUser
    End Function
End Class
