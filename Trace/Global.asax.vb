' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()

        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(Sub(config)
                                          config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                          WebApiConfig.Register(config)
                                      End Sub)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)

        ViewEngines.Engines.Clear()
        ViewEngines.Engines.Add(New RazorViewEngine())
    End Sub

    Sub Application_BeginRequest(sender As Object, e As EventArgs)
        Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("EOSL")
        If cookie IsNot Nothing AndAlso cookie.Value <> "" Then
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(cookie.Value)
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(cookie.Value)
        Else
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("cs-CZ")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("cs-CZ")
        End If
    End Sub
End Class
