Imports System.Runtime.CompilerServices
Imports System.IO
Imports System.Resources
Imports System.Reflection
Imports Newtonsoft.Json
Imports System.Web.Script.Serialization

Public Module HelpersExtensions
    <Extension()> _
    Public Function FileRender(ByVal helper As HtmlHelper, path As String) As IHtmlString
        Dim physicalPath = HttpContext.Current.Server.MapPath(path)
        If File.Exists(physicalPath) Then
            Return New MvcHtmlString(File.ReadAllText(physicalPath))
        End If
        Return Nothing
    End Function

    <Extension()> _
    Public Function AutoLogOfDelay(ByVal helper As HtmlHelper) As Integer
        Return My.Settings.AutoLogOffDelay
    End Function

    <Extension()> _
    Public Function Culture(ByVal helper As HtmlHelper) As String
        Return System.Globalization.CultureInfo.CurrentCulture.Name
    End Function

    <Extension()> _
    Public Function CurAction(ByVal helper As HtmlHelper) As String
        Return helper.ViewContext.RouteData.Values("Action").ToString()
    End Function

    <Extension()> _
    Public Function CurController(ByVal helper As HtmlHelper) As String
        Return helper.ViewContext.RouteData.Values("Controller").ToString()
    End Function

    <Extension()> _
    Public Function Settings(ByVal helper As HtmlHelper, key As String) As Object
        Dim value = My.Settings.Item(key)
        Dim type = value.GetType
        Select Case type
            Case GetType(System.Collections.Specialized.StringCollection)
                value = New JavaScriptSerializer().Serialize(value)
        End Select
        Return value
    End Function

    Public Structure kendoTemplate
        Dim common As String
        Dim style As String
    End Structure

    <Extension()> _
    Public Function KendoCss(ByVal helper As HtmlHelper) As Object
        Dim kendo As HttpCookie = HttpContext.Current.Request.Cookies("kendoTemplate")
        Dim style As kendoTemplate
        If kendo Is Nothing Then
            style = New kendoTemplate With {.common = "kendo.common-material.min.css", .style = "agiloforeos.min.css"}
        Else
            style = JsonConvert.DeserializeObject(Of kendoTemplate)(CStr(kendo.Value))
        End If
        Return style
    End Function
End Module



