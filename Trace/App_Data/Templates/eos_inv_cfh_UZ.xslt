<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
        <body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
<div>
                <!--A4-->
                     <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->
                <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->
                <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->
                <p style="text-align:left;font-family:'Arial',serif; font-size:18pt;margin: 20; margin-bottom: .0001pt;"><b>UZNÁNÍ ZÁVAZKU</b></p> <!--velky titulek-->
                <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->
                <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Uznávám tímto svůj dluh vůči společnosti <B>EOS Investment Česká republika, s.r.o.</B>, Novodvorská 994, 142 21  Praha 4, IČ: 01411641 jehož výše ke dni <xsl:value-of select="ms:format-date(UZSK/SYS_Date, 'dd. MM. yyyy')"/> činí <B><xsl:value-of select="UZSK/ActualDebit"/></B> Kč (slovy: <xsl:value-of select="UZSK/AmountByWords"/> korun českých, <xsl:value-of select="UZSK/AmountByWordsHal"/> haléřů) včetně příslušenství, které narůstá až do úplného uhrazení jistiny.</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Důvodem vzniku dluhu je neuhrazení dlužné částky, k jejímuž zaplacení jsem povinen / povinna na základě smlouvy o úvěru č. <xsl:value-of select="UZSK/CustomerID2"/> (č. ev. <xsl:value-of select="UZSK/CustomerID"/>) uzavřené s <xsl:value-of select="UZSK/RegisterInfo"/> dne <xsl:value-of select="UZSK/ACC_comment9"/>. Úvěr mi byl poskytnut na koupi zboží u společnosti HORNBACH BAUMARKT CS spol. s r.o., sídlem Chlumecká 2398, Praha 9 - Horní Počernice, PSČ 193 00.</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Uvedený dluh uznávám co do důvodu a výše a zavazuji se jej zaplatit v plném rozsahu včetně příslušenství, které narůstá až do úplného uhrazení jistiny a které bude dopočteno ke dni úhrady.</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; ; margin-top: 100px"><B>Jméno a příjmení:</B> ................................................................  <B>nar.:</B> ..................................</p>
            <p  style="text-align:justify;margin: 0cm; margin-top: 60; font-family:'Arial',serif;font-size:13pt; margin: 20px; margin-top: 50px"><B>Adresa:</B>............................................................................................................................</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; margin-top: 50px"><B>Podpis:</B> ........................................................  <B>V</B> ................................  <B>dne</B> .......................</p>

                        <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;"><B>Spisová značka: <xsl:value-of select="UZSK/ACC"/>
                      </B></p>


            </div>
        </body></html>
</xsl:template>
</xsl:stylesheet>