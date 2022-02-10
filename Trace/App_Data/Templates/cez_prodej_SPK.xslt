<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
        <body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
          <div style="height:1040px;">
            <p style="text-align:center;font-size:14pt;">
              <b>Uznání dluhu a dohoda o zaplacení dluhu</b>
            </p>
            <br />
            <br />
            <p style="margin: 0cm; margin-bottom: .0001pt;">ČEZ Prodej, a.s.,   IČ: 272 32 433, DIČ: CZ 27232433</p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">se sídlem Praha 4, Duhová 1/425, PSČ 140 53 </p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">
              bankovní spojení: <xsl:value-of select="UZSK/AccountNumber" />/<xsl:value-of select="UZSK/BankCode" />
            </p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">zapsaná v obchodním rejstříku vedeném Městským soudem v Praze, oddíl B</p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">zastoupená na základě plné moci ze dne 13.7.2015 společností</p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">EOS KSI Česká republika, s.r.o., IČ 25117483, DIČ CZ699003397, se sídlem Novodvorská 994, 142 21 Praha 4</p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">
              dále jen  <b>„Věřitel“</b>
            </p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">a</p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">
              <xsl:value-of select="UZSK/PersName" /><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersSurname" />, IČ/nar. <xsl:value-of select="UZSK/PersIC"/>/<xsl:value-of select="ms:format-date(UZSK/PersBirthDate, 'dd. MM. yyyy')"></xsl:value-of>
            </p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">
              sídlo/bytem <xsl:value-of select="UZSK/PersStreetHouseNum"/>, <xsl:value-of select="UZSK/PersZipCode"/><xsl:text> </xsl:text><xsl:value-of select="UZSK/PersCity"/>
            </p>
            <p style="margin: 0cm; margin-bottom: .0001pt;">
              dále jen  <b>„Dlužník“</b>
            </p>
            <p style="text-align:center;margin: 0cm; margin-bottom: .0001pt;">
              <b>I.</b>
            </p>
            <p style="text-align:center;margin: 0cm; margin-bottom: .0001pt;">
              <b>Uznání dluhu</b>
            </p>
            <p style="margin-top:6.0pt;text-align:justify">Dlužník prohlašuje, že uzavřel s Věřitelem smlouvu/y k níže uvedenému/ým odběrnému/ým místu/ům (dále jen Smlouva), podle které/ých mu Věřitel řádně dodával komoditu/poskytoval službu a byl povinen Věřiteli zaplatit sjednanou cenu.</p>
            <p style="margin-top:6.0pt;text-align:justify">Dlužník prohlašuje, že mu Věřitel podle Smlouvy řádně vyúčtoval cenu za dodávku komodity/poskytnuté služby, případně smluvní pokutu/y fakturou (fakturami):</p>
            
              <table border="1" cellspacing="0" cellpadding="6" style="width:100%;">
                <thead>
                  <tr>
                    <td>Odběrné místo</td>
                    <td>Variabilní symbol</td>
                    <td>Datum splatnosti</td>
                    <td>Fakturovaná částka</td>
                    <td>Výše doplatku</td>
                  </tr>
                </thead>
                <tbody>
                  <xsl:if test="UZSK/CEZ">
                  <xsl:for-each select="UZSK/CEZ/tblSpisyPrintInfoCEZ">
                    <tr>
                      <td>
                        <xsl:value-of select="CEZ_SuplyPlace" />
                      </td>
                      <td>
                        <xsl:value-of select="CEZ_VariableSymbol" />
                      </td>
                      <td>
                        <xsl:value-of select="ms:format-date(CEZ_DueDate, 'dd. MM. yyyy')" />
                      </td>
                      <td>
                        <xsl:value-of select="format-number(CEZ_AmountTotal, '#.00')" />
                      </td>
                      <td>
                        <xsl:value-of select="format-number(CEZ_AmountSupplement, '#.00')" />
                      </td>
                    </tr>
                  </xsl:for-each>
                  </xsl:if>
                </tbody>
              </table>
            <p style="margin-top:6.0pt;text-align:justify">
              Dlužník měl tedy uhradit částku <xsl:value-of select="UZSK/Principal"/> Kč. Dlužník doplatek uvedený ve faktuře (fakturách) k datu její splatnosti neuhradil a nestalo se tak ani později.
            </p>
            <p style="margin-top:6.0pt;text-align:justify">Protože Dlužník nesplnil řádně a včas svou povinnost ze shora uvedeného závazkového vztahu, prohlašuje, že má vůči Věřiteli následující nesplněný dluh, který co do důvodu a výše uznává v níže uvedeném rozsahu a zavazuje se Věřiteli zaplatit:</p>
            <p style="margin-top:6.0pt;text-align:justify">
              a) částku ve výši <xsl:value-of select="UZSK/Principal"/> Kč, tj. dluh z neuhrazené faktury/faktur
            </p>
            <p style="margin-top:6.0pt;text-align:justify">b) úroky z prodlení naběhlé ode dne následujícího po dni splatnosti jednotlivých faktur do zaplacení. Úroky z prodlení jsou zahrnuty ve splátkách.</p>
          </div>

          <div>
            <p style="text-align:center;margin: 0cm; margin-bottom: .0001pt;">
              <b>II.</b>
            </p>
            <!--maly titulek-->
            <p style="text-align:center;margin: 0cm; margin-bottom: .0001pt;">
              <b>Dohoda o splátkách dluhu</b>
            </p>
            <!--maly titulek-->
            <p style="margin-top:6.0pt;text-align:justify">
              <span>&#160;&#160;&#160;&#160;</span>
              <b>Dlužník a Věřitel uzavírají tuto dohodu o zaplacení dluhu:</b>
            </p>
            <!--odstavec-->

            <p>1. Dlužník se zavazuje dluh specifikovaný shora v části I. Věřiteli zaplatit postupně v následujících splátkách poskytovaných pod sankcí ztráty výhody splátek:</p>
            <table border="1" cellspacing="0" cellpadding="6" style="width:100%;">
              <tbody>
                <tr>
                  <td style="text-align:center;">
                    <b>Pořadí splátky</b>
                  </td>
                  <td style="text-align:center;">
                    <b>Výše splátky</b>
                  </td>
                  <td style="text-align:center;">
                    <b>Datum splatnosti splátky</b>
                  </td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
                <tr>
                  <td>&#160;</td>
                  <td>&#160;</td>
                  <td>&#160;</td>
                </tr>
              </tbody>
            </table>
            <p>Celkem k úhradě vč. úroků z prodlení ………………… Kč.</p>
            <p>
              2. Splátky budou hrazeny na účet Věřitele číslo <xsl:value-of select="UZSK/AccountNumber" />/<xsl:value-of select="UZSK/BankCode" />, pod variabilním symbolem <xsl:value-of select="UZSK/VariableSymbol"/>. Současně Dlužník a Věritel se dohodli, že v případě, kdy nebude řádně a včas uhrazena kterákoli ze splátek, stává se dnem splatnosti neuhrazené splátky splatný celý zbytek dluhu.
            </p>
            <p>3. Dlužník a Věřitel se dohodli, že splněním dluhu ve splátkách nezaniká právo Věřitele na zaplacení úroku z prodlení.</p>
            <p>4. Účastníci této Dohody prohlašují, že k ní přistoupili po vzájemném, vážném, srozumitelném a určitém projednání, a že její obsah odpovídá skutečnému stavu věci a je výrazem jejich pravé a svobodné vůle, což potvrzují svými podpisy (svých oprávněných zástupců).</p>
            <p style="text-align:justify;margin: 0cm; margin-bottom: .0001pt;">&#160;</p>
            <!--break-->
            <table border="0" cellspacing="0" cellpadding="0" style="width:100%;">
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">
                  V Praze dne <xsl:value-of select="ms:format-date(UZSK/SYS_Date, 'dd. MM. yyyy')"/>
                </td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">V ..........................................&#160;dne ....................</td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-right:0cm;margin-bottom:0cm;margin-bottom:.0001pt;">Za Věřitele:</p>
                </td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-right:0cm;margin-bottom:0cm;margin-bottom:.0001pt;">Za Dlužníka:</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">
                  <img width="131" height="73" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAIMAAABJCAYAAAAe7pW0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAABIxSURBVHhe7d13qG3F9QfwbSwxxq7R2F/sJYrG3rGRWLESQp4Nie0foyiIgqIiiIooiCgKCjYUREQNxoYVa6JGE0tMLImxd2PURO/vfsb3vYznd84959x77vP57vnCsNvs2TNrfWetNbNnnzPPyCiaSeLLL79svve97zXzzDNPOf7vf/9btvPPP3/ZwhdffFHyzDfffOXYYz/99NPmhz/84djxV199VfaVI287/O9//ytb5fz73/8eu3+6gjzIwpYevv/973/jfCvIOXpqzTMQMgBFRoG1wlSwVbn/+c9/SqWdy+NTwU5wD3K1a+B0h071+eefN0sssUTz/vvvF7kutthizYcfftgsssgiY7KNrDt1tIFZhvF6M6KorHzzzjtvs8ACC5Rt8MknnzSvv/5689Zbb5WGuabH/+AHP2hmzJjRLLrooiVfmKwc92jwEE1Rei0LMtR5llpqqVln/j+ovbUDTpoMFIQEIYLiKMvWOS5jwQUXLNcCxHjmmWeaP/zhD81f//rXch2DNcgWCVgB97/99tvN2muv3Wy66abluDZttTWartApFl544SLzf/zjH81yyy1XrC63rFOl07XKyrF7alc+MDcBCk+8QGGSYw/8+OOPmyeffLJ54oknCnNXXHHFZuWVV25++tOfFjIstNBC5b7gs88+K6S5/fbbSyP33nvvZtVVVy3lIEzytBJtuoIl0InefPPNIqPVV1+96AMZqBg5gFXu5JIHRgbFYFtt/oM77rijeeCBB5qll1669PCf/OQnxYTV/l/F3Q/O1xU+7bTTmq233rrZeeedS08A5EGGVhJNN7CUZK/DXXrppc31119fOtsaa6zRXHHFFWOEAB1TfqRph0nb2JibViKIAR599NHm4IMPbu6///5m2223bQ4//PBmiy22aJZZZpnS6yUKTYU1SEIE5bkO9j/66KOyryHMIpM33YkAGaXdfPPNzZVXXtkcddRRzZ133lk61P7779/cc889JaiEuIT0/1jxMbAMk8WoMksKRs36yOWXXz5y6KGHjowSYWQ0wJl1ZWRktGfP2hsZGVXyrL2v90cbVtIoe2edHRkZJcTIZZddNjJKrJHRypcEo8PKcm2I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" />
                </td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt"></td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-right:0cm;margin-bottom:0cm;margin-bottom:.0001pt;">Jakub Novotný, manažer inkasního oddělení</p>
                  <p style="margin-top:6.0pt;margin-right:0cm;margin-bottom:0cm;margin-bottom:.0001pt;">Za EOS KSI Česká republika, s.r.o.</p>
                </td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-right:0cm;margin-bottom:0cm;margin-bottom:.0001pt;">………………………………………………........</p>
                  <p style="margin-top:6.0pt;margin-right:0cm;margin-bottom:0cm;margin-bottom:.0001pt;">jméno, příjmení</p>
                </td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
              </tr>
              <tr>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">&#160;</td>
                <td valign="top" style="padding:0cm 5.4pt 0cm 5.4pt">
                  <p style="margin-top:6.0pt;margin-right:0cm;margin-bottom:0cm;margin-bottom:.0001pt;">………………………………………………........</p>
                  <p style="margin-top:6.0pt;margin-right:0cm;margin-bottom:0cm;margin-bottom:.0001pt;">podpis (razítko)</p>
                </td>
              </tr>
            </table>
          </div>
        </body>
      </html>
</xsl:template>
</xsl:stylesheet>