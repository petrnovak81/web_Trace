Public Class SqlMembershipProvider
    Inherits MembershipProvider

    Public Overrides Property ApplicationName As String

    Public Overrides Function CreateUser(username As String,
                                         password As String,
                                         email As String,
                                         passwordQuestion As String,
                                         passwordAnswer As String,
                                         isApproved As Boolean,
                                         providerUserKey As Object,
                                         ByRef status As MembershipCreateStatus) As MembershipUser

#Disable Warning BC42105 ' Funkce CreateUser nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce CreateUser nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function DeleteUser(username As String, deleteAllRelatedData As Boolean) As Boolean

#Disable Warning BC42353 ' Funkce DeleteUser nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce DeleteUser nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?

    Public Overrides ReadOnly Property EnablePasswordReset As Boolean
        Get

#Disable Warning BC42355 ' Vlastnost EnablePasswordReset nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost EnablePasswordReset nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides ReadOnly Property EnablePasswordRetrieval As Boolean
        Get

#Disable Warning BC42355 ' Vlastnost EnablePasswordRetrieval nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost EnablePasswordRetrieval nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides Function FindUsersByEmail(emailToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection

#Disable Warning BC42105 ' Funkce FindUsersByEmail nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce FindUsersByEmail nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function FindUsersByName(usernameToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection

#Disable Warning BC42105 ' Funkce FindUsersByName nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce FindUsersByName nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function GetAllUsers(pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection

#Disable Warning BC42105 ' Funkce GetAllUsers nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce GetAllUsers nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function GetNumberOfUsersOnline() As Integer

#Disable Warning BC42353 ' Funkce GetNumberOfUsersOnline nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce GetNumberOfUsersOnline nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?

    Public Overrides Function GetPassword(username As String, answer As String) As String

#Disable Warning BC42105 ' Funkce GetPassword nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce GetPassword nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overloads Overrides Function GetUser(providerUserKey As Object, userIsOnline As Boolean) As MembershipUser

#Disable Warning BC42105 ' Funkce GetUser nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce GetUser nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overloads Overrides Function GetUser(username As String, userIsOnline As Boolean) As MembershipUser

#Disable Warning BC42105 ' Funkce GetUser nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce GetUser nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function GetUserNameByEmail(email As String) As String

#Disable Warning BC42105 ' Funkce GetUserNameByEmail nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce GetUserNameByEmail nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function ChangePassword(username As String, oldPassword As String, newPassword As String) As Boolean

#Disable Warning BC42353 ' Funkce ChangePassword nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce ChangePassword nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?

    Public Overrides Function ChangePasswordQuestionAndAnswer(username As String, password As String, newPasswordQuestion As String, newPasswordAnswer As String) As Boolean

#Disable Warning BC42353 ' Funkce ChangePasswordQuestionAndAnswer nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce ChangePasswordQuestionAndAnswer nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?

    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts As Integer
        Get

#Disable Warning BC42355 ' Vlastnost MaxInvalidPasswordAttempts nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost MaxInvalidPasswordAttempts nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters As Integer
        Get

#Disable Warning BC42355 ' Vlastnost MinRequiredNonAlphanumericCharacters nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost MinRequiredNonAlphanumericCharacters nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides ReadOnly Property MinRequiredPasswordLength As Integer
        Get

#Disable Warning BC42355 ' Vlastnost MinRequiredPasswordLength nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost MinRequiredPasswordLength nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides ReadOnly Property PasswordAttemptWindow As Integer
        Get

#Disable Warning BC42355 ' Vlastnost PasswordAttemptWindow nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost PasswordAttemptWindow nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides ReadOnly Property PasswordFormat As MembershipPasswordFormat
        Get

#Disable Warning BC42355 ' Vlastnost PasswordFormat nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost PasswordFormat nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression As String
        Get

#Disable Warning BC42107 ' Vlastnost PasswordStrengthRegularExpression nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
        End Get
#Enable Warning BC42107 ' Vlastnost PasswordStrengthRegularExpression nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Property

    Public Overrides ReadOnly Property RequiresQuestionAndAnswer As Boolean
        Get

#Disable Warning BC42355 ' Vlastnost RequiresQuestionAndAnswer nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost RequiresQuestionAndAnswer nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides ReadOnly Property RequiresUniqueEmail As Boolean
        Get

#Disable Warning BC42355 ' Vlastnost RequiresUniqueEmail nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
        End Get
#Enable Warning BC42355 ' Vlastnost RequiresUniqueEmail nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Property

    Public Overrides Function ResetPassword(username As String, answer As String) As String

#Disable Warning BC42105 ' Funkce ResetPassword nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.
    End Function
#Enable Warning BC42105 ' Funkce ResetPassword nevrací hodnotu u všech cest kódu. V případě použití výsledku může při spuštění dojít k výjimce vyvolané odkazem s hodnotou Null.

    Public Overrides Function UnlockUser(userName As String) As Boolean

#Disable Warning BC42353 ' Funkce UnlockUser nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce UnlockUser nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?

    Public Overrides Sub UpdateUser(user As MembershipUser)

    End Sub

    Public Overrides Function ValidateUser(username As String, password As String) As Boolean

#Disable Warning BC42353 ' Funkce ValidateUser nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
    End Function
#Enable Warning BC42353 ' Funkce ValidateUser nevrací hodnotu na všech cestách kódu. Nechybí příkaz Return?
End Class
