Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports System.Net.Http.Headers

Public Class WebApiConfig
    Public Shared Sub Register(ByVal config As HttpConfiguration)
        'config.EnableCors()

        config.Routes.MapHttpRoute(
                                             name:="ServiceApi",
                                             routeTemplate:="api/{controller}/{action}/{id}",
                                             defaults:=New With {.id = UrlParameter.Optional}
                                         )
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(New MediaTypeHeaderValue("text/html"))
    End Sub
End Class