'------------------------------------------------------------------------------
' <auto-generated>
'    Tento kód byl generován ze šablony.
'
'    Ruční změny tohoto souboru mohou způsobit neočekávané chování v aplikaci.
'    Ruční změny tohoto souboru budou přepsány, pokud bude kód vygenerován znovu.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class sp_B3_DetailSpisu_Result
    Public Property IDSpisu As Integer
    Public Property ACC As String
    Public Property ActualDebit As Nullable(Of Double)
    Public Property CreditorName As String
    Public Property Principal As Nullable(Of Double)
    Public Property Interest As Nullable(Of Double)
    Public Property Costs As Nullable(Of Double)
    Public Property YetPaid As Nullable(Of Double)
    Public Property rr_Currency As String
    Public Property CurrencyTxt As String
    Public Property CreditorAlias As String
    Public Property KindOfEnforcement As String
    Public Property AccountNumber As String
    Public Property BankCode As String
    Public Property VariableSymbol As String
    Public Property SpecificSymbol As String
    Public Property CreditorAddrFull As String
    Public Property CreditorStreet As String
    Public Property CreditorHouseNum As String
    Public Property CreditorCity As String
    Public Property CreditorZipCode As String
    Public Property LastPaymentDate As Nullable(Of Date)
    Public Property LastPaymentAmountReal As Nullable(Of Double)
    Public Property LastCallDate As Nullable(Of Date)
    Public Property LastCallText As String
    Public Property TaskForIP As String
    Public Property FileAction As String
    Public Property PardonCampaign As Boolean
    Public Property MaxCountPayments As Nullable(Of Short)
    Public Property VisitDateD1Max As Nullable(Of Date)
    Public Property DateOSNMax As Nullable(Of Date)
    Public Property DateOSNPlan As Nullable(Of Date)
    Public Property VisitDateReceiveFromMother As Nullable(Of Date)
    Public Property VisitDateSentToMother As Nullable(Of Date)
    Public Property DateReturnToCreditor As Nullable(Of Date)
    Public Property DateLapse As Nullable(Of Date)
    Public Property DateSignSKUZ As Nullable(Of Date)
    Public Property MaxCommission As Nullable(Of Double)
    Public Property FirstVisitFee As Nullable(Of Double)
    Public Property SumPaymentFromVisits As Nullable(Of Double)
    Public Property IDCreditor As Nullable(Of Integer)
    Public Property DOHL As String
    Public Property ActualActions As String
    Public Property MsgForRecipient As String

End Class
