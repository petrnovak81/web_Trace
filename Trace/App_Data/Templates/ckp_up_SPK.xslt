<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
<body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
        <div style="height:1040px;">
          <p style="text-align:center;font-size:18pt;margin: 0cm; margin-bottom: .0001pt;">
            <b>Uznání dluhu a dohoda o způsobu úhrady dlužné částky</b>
          </p>
          <!--velky titulek-->
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p>
          <!--break-->
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">
            Já <xsl:value-of select="UZSK/PersName" /><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersSurname" />, bytem <xsl:value-of select="UZSK/PersStreetHouseNum" />, <xsl:value-of select="UZSK/PersZipCode" /><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersCity" /> uznávám tímto svůj dluh vůči věřiteli Česká kancelář pojistitelů, Na Pankráci 1724/129, 140 00 Praha 4 (věřitel zastoupen společností EOS KSI Česká republika, s. r.o. Novodvorská 994, 142 21 Praha 4, IČO: 25117483), ke dni <xsl:value-of select="ms:format-date(UZSK/SYS_Date, 'dd. MM. yyyy')" /> ve výši <xsl:value-of select="UZSK/ActualDebit" /> Kč (slovy: <xsl:value-of select="UZSK/AmountByWords" /> korun českých, <xsl:value-of select="UZSK/AmountByWordsHal" /> haléřů)  včetně úroků z prodlení, které narůstají až do úplného uhrazení jistiny.
          </p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">
            Důvodem vzniku dluhu je neuhrazení příspěvku nepojištěných ve smyslu § 24c zákona č. 168/1999 Sb., ve znění pozdějších předpisů, který mám povinnost uhradit v důsledku toho, že v období od <xsl:value-of select="UZSK/ACC_comment13" /> do <xsl:value-of select="UZSK/ACC_comment14" /> nebylo k vozidlu <xsl:value-of select="UZSK/ACC_comment17" />, VIN <xsl:value-of select="UZSK/ACC_comment27" /> sjednáno povinné pojištění odpovědnosti.
          </p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">
            Uvedený dluh uznávám co do důvodu a výše a zavazuji se jej zaplatit v měsíčních splátkách s 1. ve výši ………..…. Kč (navýšena o poplatek 200 Kč za vystavení splátkového kalendáře) splatnou dne ………… a dále pak v měsíčních splátkách ve výši ………..…. Kč splatných vždy ke každému ……. dni v měsíci nebo následující pracovní den na číslo účtu <xsl:value-of select="UZSK/BankCode" />, pod variabilním symbolem <xsl:value-of select="UZSK/VariableSymbol" /> až do úplného zaplacení.
          </p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Beru na vědomí a souhlasím s tím, že při nesplacení byť jedné splátky se stává den následující po dni splatnosti nesplacené splátky splatným celý dluh a věřitel bude uplatňovat své nároky soudní cestou.</p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px; margin-bottom:0">
            <B>Dlužník</B>
          </p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px; margin-top: 0;">
            <xsl:value-of select="UZSK/PersName" />
            <xsl:text> </xsl:text>
            <xsl:value-of select="UZSK/PersSurname" />
          </p>

          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px;">Jméno a příjmení ...................................................  nar. .....................................</p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;margin-top:40">adresa .................................................................................................................</p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">telefon .................................................................................................................</p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">podpis ................................................  V ...................................  dne .................</p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Jméno a příjmení ...................................................  nar. .....................................</p>
          <p style="text-align:justify;margin: 0cm; font-family:'Arial',serif;font-size:13pt;margin: 20px;margin-bottom:0">
            <B>Věřitel</B>
          </p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;margin-top:0">Česká kancelář pojistitelů</p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;margin-top:60">EOS KSI Česká republika,s.r.o.na základě plné moci</p>

        </div>


        <div>
          <!--A4-->
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px;">
            <B>Příloha - rozpis splátek k uznání dluhu s dohodou o plnění ve splátkách</B>
          </p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px">Věřitel: Česká kancelář pojistitelů, Na Pankráci 1724/129, 140 00 Praha 4, IČ: 70099618</p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px">
            Dlužník: <xsl:value-of select="UZSK/PersName" /><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersSurname" />, <xsl:value-of select="UZSK/PersStreetHouseNum" />, <xsl:value-of select="UZSK/PersZipCode" /><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersCity" />
          </p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: 0; font-family:'Arial',serif;font-size:13pt;margin: 20px; margin-bottom: 0">
            Údaje pro platbu: číslo účtu <xsl:value-of select="UZSK/BankCode" />
          </p>
          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin-top: 0; margin-left: 150px">
            variabilní symbol <xsl:value-of select="UZSK/VariableSymbol" />
          </p>

          <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p>
          <!--break-->
          <table border="1" cellspacing="0" cellpadding="6" style="width:100%;">
            <tbody>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center; font-family:'Arial',serif;font-size:13pt">
                    <b>Pořadí splátky</b>
                  </p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center; font-family:'Arial',serif;font-size:13pt">
                    <b>Výše splátky</b>
                  </p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center; font-family:'Arial',serif;font-size:13pt">
                    <b>Datum splatnosti splátky</b>
                  </p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
                <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </body></html>
</xsl:template>
</xsl:stylesheet>