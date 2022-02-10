<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
        <body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
<div>
                <p style="text-align:center;font-family:'Arial',serif; font-size:18pt;margin: 20; margin-bottom: .0001pt;"><b>Uznávací prohlášení</b></p> <!--velky titulek-->
                <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->

                <p  style="text-align:left;margin: 20px; margin-bottom: 0cm; font-family:'Arial',serif;font-size:13pt;"><B>Já, níže podepsaná-ý: </B><xsl:value-of select="UZSK/PersName"/><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersSurname"/>  </p>
                <p  style="text-align:left; margin: 20px;margin-bottom: 0cm; margin-top: 0cm;font-family:'Arial',serif;font-size:13pt;"><B>Bytem/sídlem: </B><xsl:value-of select="UZSK/PersStreetHouseNum"/>, <xsl:value-of select="UZSK/PersZipCode"/><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersCity"/>     </p>
                <p  style="text-align:left; margin: 20px;margin-bottom: 0cm; margin-top: 0cm; font-family:'Arial',serif;font-size:13pt;"><B>RČ/IČ: </B><xsl:value-of select="UZSK/PersRC"/></p>
<p  style="text-align:center;margin: 20px; margin-bottom: 0cm; font-family:'Arial',serif;font-size:13pt;"><B>uznávám tímto, že věřiteli</B></p>

<p  style="text-align:left;margin: 20px; margin-bottom: 0cm; font-family:'Arial',serif;font-size:13pt;"><B>společnosti Provident Financial, s.r.o.</B></p>
<p  style="text-align:left;margin: 20px; margin-bottom: 0cm; margin-top: 0cm;font-family:'Arial',serif;font-size:13pt;">se sídlem: Olbrachtova 9/2006, 140 00 Praha 4</p>
<p  style="text-align:left;margin: 20px; margin-bottom: 0cm; margin-top: 0cm;font-family:'Arial',serif;font-size:13pt;">	IČ: 25621351</p>
<p  style="text-align:left;margin: 20px; margin-bottom: 0cm; margin-top: 0cm;font-family:'Arial',serif;font-size:13pt;">	zapsané v Obchodním rejstříku vedeném Městským soudem v Praze, oddíl C, vložka 55523</p>
<p  style="text-align:center;margin: 0cm; margin-bottom: 0cm; font-family:'Arial',serif;font-size:13pt;margin: 20px;"><B>dlužím ke dni </B><xsl:value-of select="ms:format-date(UZSK/SYS_Date, 'dd. MM. yyyy')"/></p>
              <p  style="text-align:justify;margin: 20px; margin-bottom: 0cm; margin-top: 0cm; font-family:'Arial',serif;font-size:13pt;"><B>na pohledávce vzniklé z úvěru/ů číslo </B><xsl:value-of select="UZSK/PF_Agreement"/>,</p>
            <p  style="text-align:justify;margin: 20px; margin-bottom: 0cm; margin-top: 0cm; font-family:'Arial',serif;font-size:13pt;"><B>který/é mi poskytla společnost Provident Financial, s.r.o.</B></p>
            <p  style="text-align:center;margin: 20px; margin-bottom: 0cm; margin-top: 0cm; font-family:'Arial',serif;font-size:13pt;"><B>celkem částku: </B><xsl:value-of select="UZSK/ActualDebit"/> Kč.</p>
               <p  style="text-align:justify;margin: 20px; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;"><B>Tento závazek uznávám co do důvodu i výše a zavazuji se jej zaplatit v měsíčních splátkách ve výši ……………………………… Kč</B></p>
            <p  style="text-align:left;margin: 20px; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;"><B>počínaje …….. měsícem roku ......... vždy k ….... dni v měsíci </B></p>
            <p  style="text-align:left;margin: 20px; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;"><B>na účet číslo </B><xsl:value-of select="UZSK/AccountNumber"/>/<xsl:value-of select="UZSK/BankCode"/><B>, variabilní symbol </B><xsl:value-of select="UZSK/VariableSymbol"/></p>
               <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;"><B>Jsem si vědom(a) toho, že v případě nesplacení jedné splátky je věřitel oprávněn uplatňovat své právo soudní cestou.</B></p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; ; margin-top: 100px"><B>V ……………………………… dne ………………………………</B></p>

            <p  style="text-align:justify;margin: 20px; margin-top: 80pt; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; "><B>……………………………………….</B></p>
            <p  style="text-align:justify;margin: 20px; margin-bottom: .0001pt;  margin-top: .0001pt;   margin-left:80pt;font-family:'Arial',serif;font-size:13pt"><B>Podpis</B></p>
            </div>
        </body></html>
</xsl:template>
</xsl:stylesheet>