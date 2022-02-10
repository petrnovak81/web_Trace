Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class RouteConfig
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute("Default",
                        "{controller}/{action}/{id}",
                        New With {
    .controller = "Home",
    .action = "Dashboard",
    .id = UrlParameter.Optional
}, New String() {"Trace.Controllers"})


        'routes.MapRoute( _
        '    name:="Default", _
        '    url:="{controller}/{action}/{id}", _
        '    defaults:=New With {.controller = "Home", .action = "Dashboard", .id = UrlParameter.Optional} _
        ')
    End Sub
End Class