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

Partial Public Class tblSpisyDocument
    Public Property IDSpisyDocument As Integer
    Public Property IDSpisu As Integer
    Public Property IDSrcSpisyDocument As Nullable(Of Long)
    Public Property rr_DocumentKind As Byte
    Public Property DocuSentDate As Nullable(Of Date)
    Public Property DocuSentComment As String
    Public Property DocuPrintPDF As String
    Public Property DocuPrintSelected As Boolean
    Public Property DocuLink As String
    Public Property GPSLat As String
    Public Property GPSLng As String
    Public Property IDVisitReport As Nullable(Of Integer)
    Public Property TStamp As Byte()
    Public Property rr_Journal As Byte

End Class
