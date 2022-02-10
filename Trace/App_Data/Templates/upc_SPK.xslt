<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
        <body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
<div>
                <p style="text-align:left;font-family:'Arial',serif; font-size:18pt;margin: 20; margin-bottom: .0001pt;"><b>UZNÁNÍ DLUHU A ZPŮSOBU ÚHRADY</b></p> <!--velky titulek-->
                <br />
                <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Já <xsl:value-of select="UZSK/PersName"/><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersSurname"/>, bytem <xsl:value-of select="UZSK/PersStreetHouseNum"/>, <xsl:value-of select="UZSK/PersZipCode"/><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersCity"/> uznávám tímto svůj dluh co do důvodu a výše vůči společnosti UPC Česká republika, s.r.o. (věřitel zastoupen společností EOS KSI Česká republika, s. r.o. Novodvorská 994, 142 21 Praha 4, IČO: 25117483), jehož výše ke dni <xsl:value-of select="ms:format-date(UZSK/SYS_Date, 'dd. MM. yyyy')"/> činí <B><xsl:value-of select="UZSK/ActualDebit"/> Kč</B> (slovy: <xsl:value-of select="UZSK/AmountByWords"/> korun českých, <xsl:value-of select="UZSK/AmountByWordsHal"/> haléřů) včetně příslušenství, které narůstá až do úplného uhrazení jistiny.</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Důvodem vzniku dluhu je neuhrazení dlužné částky, k jejímuž zaplacení jsem povinen/povinna na základě smlouvy č. <xsl:value-of select="UZSK/CustomerID"/> uzavřené s UPC Česká republika, s.r.o..</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Uvedený dluh uznávám co do důvodu a výše a zavazuji se jej zaplatit v měsíčních splátkách s 1. ve výši ………..…. Kč splatnou dne ………… a dále pak v měsíčních splátkách ve výši ………..…. Kč splatných vždy ke každému ……. dni v měsíci nebo následující pracovní den na číslo účtu <xsl:value-of select="UZSK/BankCode"/>, pod variabilním symbolem <xsl:value-of select="UZSK/VariableSymbol"/> až do úplného zaplacení.</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;">Beru na vědomí a souhlasím s tím, že při nesplacení byť jedné splátky se stává den následující po dni splatnosti nesplacené splátky splatným celý dluh a věřitel bude uplatňovat své nároky soudní cestou.</p>


            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; ; margin-top: 100px"><B>Jméno a příjmení:</B> ................................................................  <B>nar.:</B> ..................................</p>
            <p  style="text-align:justify;margin: 0cm; margin-top: 60; font-family:'Arial',serif;font-size:13pt; margin: 20px; margin-top: 50px"><B>Adresa:</B>............................................................................................................................</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px; margin-top: 50px"><B>Podpis:</B> ........................................................  <B>V</B> ................................  <B>dne</B> .......................</p>

                        <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px;"><B>Spisová značka: <xsl:value-of select="UZSK/ACC"/></B></p>
            </div>


            <div class="page" style="width:21cm;height:29.7cm;page:auto">
                <!--A4-->
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt; margin: 20px;"><B>Příloha - rozpis splátek k uznání dluhu s dohodou o plnění ve splátkách</B></p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px"><B>Věřitel:</B>UPC Česká republika, s.r.o., Závišova 502/5, 140 00 Praha 4, IČ: 00562262</p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin: 20px"><B>Dlužník:</B> <xsl:value-of select="UZSK/PersName"/><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersSurname"/>, bytem <xsl:value-of select="UZSK/PersStreetHouseNum"/>, <xsl:value-of select="UZSK/PersZipCode"/><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersCity"/></p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: 0; font-family:'Arial',serif;font-size:13pt;margin: 20px; margin-bottom: 0"><B>Údaje pro platbu:</B> číslo účtu <xsl:value-of select="UZSK/BankCode"/></p>
            <p  style="text-align:justify;margin: 0cm; margin-bottom: .0001pt; font-family:'Arial',serif;font-size:13pt;margin-top: 0; margin-left: 160px">variabilní symbol <xsl:value-of select="UZSK/VariableSymbol"/></p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p> <!--break-->

                        <table border="1" cellspacing="0" cellpadding="0" style="border-collapse:collapse;border:none; margin-left: 20px">
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
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                    <td valign="top" style="width:160.1pt;border:solid windowtext 1.0pt;padding:0.1cm 5.4pt 0cm 5.4pt"><p style="margin-top:6.0pt;margin-bottom:.0001pt;text-align:center;">&#160;</p></td>
                                </tr>
                            </tbody>
                        </table>
            </div>
        </body></html>
</xsl:template>
</xsl:stylesheet>