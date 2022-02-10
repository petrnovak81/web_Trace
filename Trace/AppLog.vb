Imports System.Reflection
Imports System.IO
Imports Newtonsoft.Json

Public Class AppLog
    Private Property AppDataPath As String
    Private Property XmlLogPath As String

    Public Class LogItem
        Sub New()
            Uid = Guid.NewGuid()
        End Sub

        Public Property Uid As Guid
        Public Property Status As String
        Public Property Message As String
        Public Property Params As Object()
    End Class

    Public Sub New()
        AppDataPath = HttpContext.Current.Server.MapPath("~/App_Data")
        XmlLogPath = AppDataPath & "\" & "AppLog.xml"
    End Sub

    Public Sub WriteLog(_LogItem As LogItem)
        Try
            Dim _StackTrace As New StackTrace
            Dim _MethodBase As MethodBase = _StackTrace.GetFrame(1).GetMethod()
            Dim _AppName As String = Assembly.GetExecutingAssembly.GetName().Name
            Dim _Reflected As String = _MethodBase.ReflectedType.Name
            Dim _Method As String = _MethodBase.Name
            Dim _ParamArray As List(Of XElement) = _MethodBase.GetParameters().Select(Function(e) New XElement("Param",
                                                                                                               New XAttribute("name", e.Name),
                                                                                                               New XAttribute("type", e.ParameterType.ToString),
                                                                                                               JsonConvert.SerializeObject(_LogItem.Params(_MethodBase.GetParameters.ToList.IndexOf(e)), Formatting.Indented))).ToList
            Dim _XElement As New XElement("MethodBase",
                                          New XAttribute("uid", _LogItem.Uid.ToString()),
                                          New XElement("Date", Date.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                          New XElement("Status", _LogItem.Status),
                                          New XElement("Method", _Reflected & "." & _Method),
                                          New XElement("ParamArray", _ParamArray),
                                          New XElement("Message", _LogItem.Message))
            Dim _XDoxument As XDocument
            If Not File.Exists(XmlLogPath) Then
                _XDoxument = New XDocument(New XElement("Application", New XAttribute("name", _AppName)))
                _XDoxument.Root.Add(_XElement)
            Else
                _XDoxument = XDocument.Load(XmlLogPath)
                _XDoxument.Root.Add(_XElement)
            End If
            _XDoxument.Save(XmlLogPath)
        Catch ex As Exception

        End Try
    End Sub
End Class
