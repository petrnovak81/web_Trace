Public Class SqlRoleProvider
    Inherits RoleProvider

    Public Overrides Sub AddUsersToRoles(usernames() As String, roleNames() As String)

    End Sub

    Public Overrides Property ApplicationName As String

    Public Overrides Sub CreateRole(roleName As String)

    End Sub

    Public Overrides Function DeleteRole(roleName As String, throwOnPopulatedRole As Boolean) As Boolean

#Disable Warning BC42353 ' Funkce DeleteRole nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce DeleteRole nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?

    Public Overrides Function FindUsersInRole(roleName As String, usernameToMatch As String) As String()

#Disable Warning BC42105 ' Funkce FindUsersInRole nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce FindUsersInRole nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function GetAllRoles() As String()

#Disable Warning BC42105 ' Funkce GetAllRoles nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce GetAllRoles nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function GetRolesForUser(username As String) As String()
        Using db As New TRACEEntities
            Dim allroles As String() = Nothing
            Dim user = db.tblUsers.FirstOrDefault(Function(e) e.UserLogin = username)
            If user IsNot Nothing Then
                Dim IDRole As String = db.tblRoles.FirstOrDefault(Function(x) x.IDRole = user.IDRole).IDRole.ToString
                Return New String() {IDRole}
            Else
                Return New String() {"0"}
            End If
        End Using
    End Function

    Public Overrides Function GetUsersInRole(roleName As String) As String()

#Disable Warning BC42105 ' Funkce GetUsersInRole nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce GetUsersInRole nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function IsUserInRole(username As String, roleName As String) As Boolean

#Disable Warning BC42353 ' Funkce IsUserInRole nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce IsUserInRole nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?

    Public Overrides Sub RemoveUsersFromRoles(usernames() As String, roleNames() As String)

    End Sub

    Public Overrides Function RoleExists(roleName As String) As Boolean

#Disable Warning BC42353 ' Funkce RoleExists nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce RoleExists nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?


End Class
