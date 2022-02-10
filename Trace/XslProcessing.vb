Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO

Public Class XslProcessing
    Public Function XslTransfer(xml As String, xslFile As String) As String
        Dim xdoc As XmlDocument = New XmlDocument()
        'xml = CleanInvalidXmlChars(xml)
        xdoc.LoadXml(xml)

        Dim processor As New XslCompiledTransform()
        processor.Load(xslFile)
        Using writer = New StringWriter()
            processor.Transform(xdoc.CreateNavigator(), Nothing, writer)
            Return writer.ToString()
        End Using
    End Function


    Public Function CleanInvalidXmlChars(xml As String) As String
        Dim re As String = "[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]"
        Return Regex.Replace(xml, re, "")
    End Function

End Class
