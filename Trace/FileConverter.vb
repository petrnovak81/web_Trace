Imports iTextSharp.tool.xml
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.tool.xml.html
Imports iTextSharp.tool.xml.pipeline.html
Imports iTextSharp.text.pdf
Imports iTextSharp.tool.xml.pipeline.css
Imports iTextSharp.tool.xml.parser
Imports iTextSharp.tool.xml.pipeline.end
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Itenso.Rtf.Interpreter
Imports Itenso.Rtf.Converter.Image
Imports Itenso.Rtf
Imports Itenso.Rtf.Support
Imports Itenso.Rtf.Converter.Html
Imports Itenso.Rtf.Parser
Imports iTextSharp.text.html.simpleparser
Imports Image = iTextSharp.text.Image
Imports iTextSharp.text.html

Public Class FileConverter

    Public Function concatAndAddContent(ByVal pdfByteContent As List(Of Byte())) As Byte()
        Using ms = New MemoryStream()

            Using doc = New Document()

                Using copy = New PdfSmartCopy(doc, ms)
                    doc.Open()

                    For Each p In pdfByteContent

                        Using reader = New PdfReader(p)
                            copy.AddDocument(reader)
                        End Using
                    Next

                    doc.Close()
                End Using
            End Using

            Return ms.ToArray()
        End Using
    End Function

    Public Function MergePDF(PDF As List(Of String), password As String) As Byte()
        Using ms As New MemoryStream()
            Using doc As New Document()
                Using copy As New PdfCopy(doc, ms)
                    If password IsNot Nothing Then
                        Dim pwd() As Byte = System.Text.Encoding.UTF8.GetBytes(password)
                        copy.SetEncryption(pwd, pwd, PdfWriter.ALLOW_PRINTING, PdfWriter.ENCRYPTION_AES_128)
                    End If
                    doc.Open()

                    For i As Integer = 0 To PDF.Count - 1
                        Dim reader As New PdfReader(PDF(i))
                        Dim n As Integer = reader.NumberOfPages
                        Dim page As Integer = 0
                        While page < n
                            copy.AddPage(copy.GetImportedPage(reader, System.Threading.Interlocked.Increment(page)))
                        End While

                        reader.Close()
                    Next

                End Using
            End Using

            Return ms.ToArray()
        End Using
    End Function

    Public Function HTMLtoPDF(htmlString As String, psize As String, rotate As Boolean, margin As Drawing.Rectangle) As Byte()
        Dim bytes As Byte()
        Dim doc As New Document
        Select Case psize.ToUpper
            Case "A4"
                If rotate Then
                    doc = New Document(PageSize.A4.Rotate, margin.Left, margin.Right, margin.Top, margin.Bottom)
                Else
                    doc = New Document(PageSize.A4, margin.Left, margin.Right, margin.Top, margin.Bottom)
                End If
            Case "A5"
                If rotate Then
                    doc = New Document(PageSize.A5.Rotate, margin.Left, margin.Right, margin.Top, margin.Bottom)
                Else
                    doc = New Document(PageSize.A5, margin.Left, margin.Right, margin.Top, margin.Bottom)
                End If
            Case Else
                doc = New Document(PageSize.A4, margin.Left, margin.Right, margin.Top, margin.Bottom)
        End Select
        Using ms As New MemoryStream()
            Using doc
                Using writer = PdfWriter.GetInstance(doc, ms)
                    writer.PageEvent = New PdfPageHelper
                    writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_7)
                    writer.CompressionLevel = PdfStream.BEST_COMPRESSION

                    writer.CloseStream = False
                    doc.Open()

                    Dim tagProcessors = DirectCast(Tags.GetHtmlTagProcessorFactory(), DefaultTagProcessorFactory)
                    tagProcessors.RemoveProcessor(HTML.Tag.IMG)
                    tagProcessors.AddProcessor(HTML.Tag.IMG, New iTextImageTagProcessor())

                    Dim HtmlContext As New HtmlPipelineContext(New CssAppliersImpl(New XMLWorkerFontProvider()))
                    HtmlContext.SetAcceptUnknown(True).AutoBookmark(True).SetTagFactory(tagProcessors)

                    Dim charset = Encoding.UTF8

                    Dim CSSResolver As ICSSResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(True)

                    Dim Pipeline As IPipeline = New CssResolverPipeline(CSSResolver, New HtmlPipeline(HtmlContext, New PdfWriterPipeline(doc, writer)))

                    Dim Worker As XMLWorker = New XMLWorker(Pipeline, True)

                    Dim Parser As XMLParser = New XMLParser(True, Worker, charset)

                    Parser.Parse(New StringReader(htmlString))

                    doc.Close()
                End Using
            End Using
            bytes = ms.ToArray()
        End Using

        Return bytes
    End Function

    Public Function RTFtoPDF(rtf As String, psize As String, rotate As Boolean, margin As Drawing.Rectangle) As Byte()
        Dim html = RTFtoHTML(rtf)
        Return HTMLtoPDF(html, psize, rotate, margin)
    End Function

    Public Function RTFtoHTML(rtf As String) As String
        Dim rtfStructure As IRtfGroup = ParseRtf(rtf)
        If rtfStructure Is Nothing Then
            Return String.Empty
        End If

        ' interpreter logger
        Dim interpreterLogger As RtfInterpreterListenerFileLogger = Nothing
        If Not String.IsNullOrEmpty(Nothing) Then
            interpreterLogger = New RtfInterpreterListenerFileLogger(Nothing)
        End If

        ' image converter
        Dim imageAdapter As New RtfVisualImageAdapter(ImageFormat.Jpeg)
        Dim imageConvertSettings As New RtfImageConvertSettings(imageAdapter)
        imageConvertSettings.ScaleImage = True
        ' scale images
        Dim imageConverter As New RtfImageConverter(imageConvertSettings)

        ' rtf interpreter
        Dim interpreterSettings As New RtfInterpreterSettings()
        Dim rtfDocument As IRtfDocument = RtfInterpreterTool.BuildDoc(rtfStructure, interpreterSettings, interpreterLogger, imageConverter)

        ' html converter
        Dim htmlConvertSettings As New RtfHtmlConvertSettings()
        htmlConvertSettings.ConvertScope = RtfHtmlConvertScope.Content
        Dim htmlConverter As New RtfHtmlConverter(rtfDocument)
        Return htmlConverter.Convert()
    End Function

    Private Function ParseRtf(fileName As String) As IRtfGroup
        Dim rtfStructure As IRtfGroup
        Using stream As FileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim structureBuilder As New RtfParserListenerStructureBuilder()
            Dim parser As New RtfParser(structureBuilder)
            parser.IgnoreContentAfterRootGroup = True
            ' support WordPad documents
            If Not String.IsNullOrEmpty(Nothing) Then
                parser.AddParserListener(New RtfParserListenerFileLogger(Nothing))
            End If
            parser.Parse(New RtfSource(stream))
            rtfStructure = structureBuilder.StructureRoot
        End Using
        Return rtfStructure
    End Function

    Public Function HTMtoIMAGE(html As String, width As Integer, height As Integer) As Byte()
        Dim img As New Bitmap(width, height, PixelFormat.Format64bppPArgb)
        'Dim point As New PointF(0, 0)
        Dim maxSize As SizeF = New System.Drawing.SizeF(width, height)
        HtmlRenderer.HtmlRender.Render(Graphics.FromImage(img), html)

        Dim ms = New MemoryStream()
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Use appropriate format here
        Return ms.ToArray()
    End Function

End Class

Public Class iTextImageTagProcessor
    Inherits iTextSharp.tool.xml.html.Image
    Public Overrides Function [End](ctx As IWorkerContext, tag As Tag, currentContent As IList(Of IElement)) As IList(Of IElement)
        Dim attributes As IDictionary(Of String, String) = tag.Attributes
        Dim src As String = attributes.FirstOrDefault(Function(w) w.Key = "src").Value

        If String.IsNullOrEmpty(src) Then
            Return New List(Of IElement)(1)
        End If

        If src.StartsWith("data:image/", StringComparison.InvariantCultureIgnoreCase) Then
            ' data:[<MIME-type>][;charset=<encoding>][;base64],<data>
            Dim base64Data = src.Substring(src.IndexOf(",") + 1)
            Dim imagedata = Convert.FromBase64String(base64Data)
            Dim image = iTextSharp.text.Image.GetInstance(imagedata)

            Dim list = New List(Of IElement)()
            Dim htmlPipelineContext = GetHtmlPipelineContext(ctx)
            list.Add(GetCssAppliers().Apply(New Chunk(DirectCast(GetCssAppliers().Apply(image, tag, htmlPipelineContext), iTextSharp.text.Image), 0, 0, True), tag, htmlPipelineContext))
            Return list
        Else
            Return MyBase.[End](ctx, tag, currentContent)
        End If
    End Function
End Class

Public Class PdfPageHelper
    Inherits PdfPageEventHelper


    Public Overrides Sub OnEndPage(ByVal writer As PdfWriter, ByVal document As Document)

        Dim cb As PdfContentByte = writer.DirectContent()
        Dim bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
        Dim pageN As Integer = writer.PageNumber
        Dim text As String = "Stránka " & pageN
        Dim pageSize = document.PageSize

        cb.BeginText()
        cb.SetFontAndSize(bf, 8)
        cb.SetTextMatrix(pageSize.GetLeft(20), pageSize.GetBottom(20))
        cb.ShowText(text)
        cb.EndText()

        'Dim cb As PdfContentByte = writer.DirectContent()
        'cb.SaveState()
        'Dim text As String = writer.PageNumber
        'Dim textBase As Single = document.Bottom() - 20
        'cb.BeginText()
        'cb.ShowText(text)
        'cb.EndText()
        ''cb.RestoreState()
        'document.NewPage()
    End Sub
End Class