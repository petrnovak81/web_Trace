Set xmlDoc = _
  CreateObject("Microsoft.XMLDOM")  
  
Set objRoot = _
  xmlDoc.createElement("application_info")  
xmlDoc.appendChild objRoot  

Set objName = _
  xmlDoc.createElement("name")  
objName.Text = "TRACE"
objRoot.appendChild objName  

d = FormatDateTime(Now(),2) & " " & FormatDateTime(Now(),4)

Set objDate = _
  xmlDoc.createElement("last_build")  
objDate.Text = d
objRoot.appendChild objDate  

Set WshShell = CreateObject("WScript.Shell")
xmlDoc.Save (WshShell.CurrentDirectory & "..\..\App_Data\build.xml")
Set WshShell = Nothing
