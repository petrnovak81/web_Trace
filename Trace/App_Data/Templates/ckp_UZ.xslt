<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
<body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
          <div>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p>
            <!--break-->
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p>
            <!--break-->
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p>
            <!--break-->
            <p style="text-align:left;font-family:'Arial',serif;font-size:18pt;margin: 20; margin-bottom: .0001pt;">
              <b>UZNÁNÍ DLUHU</b>
            </p>
            <!--velky titulek-->
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p>
            <!--break-->
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Tímto uznávám co do důvodu i výše, v souladu s příslušnými právními předpisy, svůj dluh vůči věřiteli</p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">
              <B>Česká kancelář pojistitelů, Na Pankráci 1724/129, 140 00 Praha 4, IČ: 70099618</B>
            </p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">
              v částce <B>
                <xsl:value-of select="UZSK/ActualDebit" />
              </B> Kč, která je složena z jistiny ve výši <xsl:value-of select="UZSK/Principal" /> Kč a příslušenství ve výši <xsl:value-of select="UZSK/InterPenal" /> Kč sestávajícího ze zákonného úroku z prodlení vyčísleného ke dni <xsl:value-of select="UZSK/SYS_Date" /> a nákladů spojených s uplatněním pohledávky.
            </p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">
              Důvodem vzniku tohoto dluhu je má povinnost zaplatit dle § 24 odst. 9 zák. č. 168/1999 Sb., v platném znění, České kanceláři pojistitelů finanční částku, kterou tato vyplatila z garančního fondu v souvislosti se škodní událostí č. <xsl:value-of select="UZSK/CustomerID" />, ze dne <xsl:value-of select="UZSK/ACC_comment23" />.
            </p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Výše uvedený dluh se zavazuji zaplatit včetně úroků z prodlení, které budou dopočteny ke dni úhrady jistiny.</p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; ; margin-top: 100px">
              <B>Jméno a příjmení: ................................................................  nar.: ..................................</B>
            </p>
            <p style="text-align:justify;margin: 0cm; margin-top: 60; font-family:'Arial',serif;font-size:13pt; margin: 20px; margin-top: 50px">
              <B>Adresa:............................................................................................................................</B>
            </p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; margin-top: 50px">
              <B>Podpis: ........................................................  V ................................  dne .......................</B>
            </p>
          </div>
        </body></html>
</xsl:template>
</xsl:stylesheet>