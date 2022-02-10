<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
        <body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
<div>
                     <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->
                <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->
                <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->
                <p style="text-align:left;font-family:'Arial',serif; font-size:18pt;margin: 20; margin-bottom: .0001pt;"><b>UZNÁNÍ ZÁVAZKU</b></p> <!--velky titulek-->
                <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->
                <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Tímto uznávám co do důvodu i výše, v souladu s příslušnými právními předpisy, svůj dluh vůči věřiteli</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;"><B>EOS Investment Česká republika, s.r.o.</B>, Novodvorská 994, 142 21 Praha 4, IČ: 014 11 641</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">v částce <B><xsl:value-of select="UZSK/ActualDebit"/></B> Kč včetně příslušenství, které narůstá až do úplného uhrazení jistiny.</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Výše uvedený dluh uznávám co do důvodu, tak i výše a zavazuji se jej zaplatit v plném rozsahu na základě smlouvy č. <xsl:value-of select="UZSK/CustomerID2"/> navýšený o příslušenství, které bude dopočteno ke dni úhrady.</p>


            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; ; margin-top: 100px"><B>Jméno a příjmení:</B> ................................................................  <B>nar.:</B> ..................................</p>
            <p  style="text-align:justify;margin: 0cm; margin-top: 60; font-family:'Arial',serif;font-size:13pt; margin: 20px; margin-top: 50px"><B>Adresa:</B>............................................................................................................................</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; margin-top: 50px"><B>Podpis:</B> ........................................................  <B>V</B> ................................  <B>dne</B> .......................</p>

                        <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;"><B>Spisová značka: <xsl:value-of select="UZSK/ACC"/>
                      </B></p>


            </div>
        </body></html>
</xsl:template>
</xsl:stylesheet>