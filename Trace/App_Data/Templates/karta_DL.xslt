<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
      <body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
          <p style="text-align:center;font-size:14pt;">
            <b>KARTA DLUŽNÍKA/DLUHU</b>
          </p>
          <table border="0" style="margin-top:28px;width:100%;">
            <tr>
              <td style="width:200px;">
                <b style="font-size:12pt;">Č. spisu:</b>
              </td>
              <td>
                <b style="font-size:12pt;">
                  <xsl:value-of select="KartaDL/ACC"/>
                </b>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <b style="font-size:12pt;">
                  <xsl:value-of select="KartaDL/PERSNAME" /><xsl:text> </xsl:text><xsl:value-of select="KartaDL/PERSSURNAME" />, <xsl:value-of select="KartaDL/PERSSURNAME2" />
              </b>
              </td>
              <td></td>
            </tr>
            <tr style="height:20px;">
              <td></td>
              <td></td>
            </tr>
            <tr>
              <td>Datum narození/RČ:</td>
              <td>
                <xsl:value-of select="ms:format-date(KartaDL/PERSBIRTHDATE, 'dd. MM. yyyy')" />/<xsl:value-of select="KartaDL/PERSRC" />
            </td>
            </tr>
            <tr>
              <td>IČ:</td>
              <td>
                <xsl:value-of select="KartaDL/PERSIC" />
              </td>
            </tr>
            <tr>
              <td>Role osoby:</td>
              <td>
                <xsl:value-of select="KartaDL/PERSTYPETXT" />
              </td>
            </tr>
            <tr>
              <td>
                <b>Adresa k OSN:</b>
              </td>
              <td>
                <b>
                  <xsl:value-of select="KartaDL/PERSSTREET" /><xsl:text> </xsl:text><xsl:value-of select="KartaDL/PERSHOUSENUM" />, <xsl:value-of select="KartaDL/PERSCITY" />, <xsl:value-of select="KartaDL/PERSZIPCODE" />, Okres: <xsl:value-of select="KartaDL/PERSREGION" />
              </b>
              </td>
            </tr>
            <tr>
              <td>
                <b>Hlavní telefon DL:</b>
              </td>
              <td>
                <b>
                  <xsl:value-of select="KartaDL/PERSPHONE" />
                </b>
              </td>
            </tr>
            <tr>
              <td>Mail DL:</td>
              <td>
                <xsl:value-of select="KartaDL/PERSEMAIL" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <b>Počet spisů dl. v APP na daném IP: <xsl:value-of select="KartaDL/COUNTOFFILES" />
              </b>
              </td>
              <td></td>
            </tr>
            <tr style="height:20px;">
              <td></td>
              <td></td>
            </tr>
            <tr>
              <td colspan="2">
                <b>Aktuální dluh celkem:</b>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>Jistina:</td>
              <td>
                <xsl:value-of select='KartaDL/PRINCIPAL' /> Kč</td>
            </tr>
            <tr>
              <td>Úrok:</td>
              <td>
                <xsl:value-of select='KartaDL/INTEREST' /> Kč</td>
            </tr>
            <tr>
              <td>Náklady:</td>
              <td>
                <xsl:value-of select='KartaDL/COSTS' /> Kč</td>
            </tr>
            <tr>
              <td>
                <b>Celkem k úhradě:</b>
              </td>
              <td>
                <b>
                  <xsl:value-of select='KartaDL/ACTUALDEBIT' /> Kč</b>
              </td>
            </tr>
            <tr>
              <td>Dosud zaplaceno:</td>
              <td>
                <xsl:value-of select='KartaDL/YETPAID' /> Kč</td>
            </tr>
            <tr style="height:20px;">
              <td></td>
              <td></td>
            </tr>
            <tr>
              <td colspan="2">
                <b>Věřitel:</b>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>Jméno:</td>
              <td>
                <xsl:value-of select="KartaDL/CREDITORNAME" />
              </td>
            </tr>
            <tr>
              <td>Původní věřitel:</td>
              <td>
                <xsl:value-of select="KartaDL/REGISTERINFO" />
              </td>
            </tr>
            <tr>
              <td>Druh vymáhání:</td>
              <td>
                <xsl:value-of select="KartaDL/KINDOFENFORCEMENT" />
              </td>
            </tr>
            <tr style="height:20px;">
              <td></td>
              <td></td>
            </tr>
            <tr>
              <td>
                <b>Číslo účtu/Kód banky:</b>
              </td>
              <td>
                <b>
                  <xsl:value-of select="KartaDL/ACCOUNTNUMBER" />/<xsl:value-of select="KartaDL/BANKCODE" />
                </b>
              </td>
            </tr>
            <tr>
              <td>
                <b>Variabilní symbol:</b>
              </td>
              <td>
                <b><xsl:value-of select="KartaDL/VARIABLESYMBOL" /></b>
              </td>
            </tr>
            <xsl:if test="KartaDL/SPECIFICSYMBOL !=''">
              <tr>
                <td>Specifický symbol:</td>
                <td>
                  <xsl:value-of select="KartaDL/SPECIFICSYMBOL" />
                </td>
              </tr>
            </xsl:if>
            <xsl:if test="KartaDL/RECIPIENT_MESSAGE !=''">
              <tr>
                <td>Zpráva pro příjemce:</td>
                <td>
                  <xsl:value-of select="KartaDL/RECIPIENT_MESSAGE" />
                </td>
              </tr>
            </xsl:if>
            <tr style="height:20px;">
              <td></td>
              <td></td>
            </tr>
            <tr>
              <td>Datum poslední platby:</td>
              <td>
                <xsl:value-of select="ms:format-date(KartaDL/LASTPAYMENTDATE, 'dd. MM. yyyy')" />
              </td>
            </tr>
            <tr>
              <td>Výše poslední platby:</td>
              <td><xsl:value-of select='KartaDL/LASTPAYMENTAMOUNT' /> Kč</td>
            </tr>
            <tr>
              <td>
                <b>Pokyn pro inspektora:</b>
              </td>
              <td>
                <b>
                  <xsl:value-of select="KartaDL/TASKFORIP" />
                </b>
              </td>
            </tr>
            <tr>
              <td>
                <b>Odpouštěcí akce:</b>
              </td>
              <td>
                <b>
                  <xsl:value-of select="KartaDL/PARDONCAMPAIGN" />
                </b>
              </td>
            </tr>
            <tr>
              <td>Akce na spise:</td>
              <td>
                <xsl:value-of select="KartaDL/FILEACTION" />
              </td>
            </tr>
            <tr>
              <td>
                <b>Datum Vrácení věřiteli:</b>
              </td>
              <td>
                <b>
                  <xsl:value-of select="ms:format-date(KartaDL/DATERETURNTOCREDITOR, 'dd. MM. yyyy')" />
                </b>
              </td>
            </tr>
            <tr>
              <td>MAX počet splátek:</td>
              <td>
                <xsl:value-of select="KartaDL/MAXCOUNTPAYMENTS" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <b>
                  <span style="width:350px;float:left;">Termín pro vykonání první návštěvy: </span>
                  <xsl:value-of select="ms:format-date(KartaDL/VISITDATED1MAX, 'dd. MM. yyyy')" />
                </b>
              </td>
              <td></td>
            </tr>
            <tr>
              <td colspan="2">
                <b>
                  <span style="width:350px;float:left;">Termín pro vykonání opakované návštěvy: </span>
                  <xsl:value-of select="ms:format-date(KartaDL/VISITDATED1MAX, 'dd. MM. yyyy')" />
                </b>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>Datum poslední hovor:</td>
              <td>
                <xsl:value-of select="ms:format-date(KartaDL/LASTCALLDATE, 'dd. MM. yyyy')" />
              </td>
            </tr>
            <tr>
              <td valign="top">Text poslední hovor:</td>
              <td valign="top">
                <xsl:value-of select="KartaDL/LASTCALLTEXT" />
              </td>
            </tr>
            <tr>
              <td>Datum předání do EOS:</td>
              <td>
                <xsl:value-of select="ms:format-date(KartaDL/TAKEOVERDATE, 'dd. MM. yyyy')" />
              </td>
            </tr>
            <tr>
              <td>Datum Podpisu SK/UZ:</td>
              <td>
                <xsl:value-of select="ms:format-date(KartaDL/DATESIGNSKUZ, 'dd. MM. yyyy')" />
              </td>
            </tr>
          </table>
        </body></html>
</xsl:template>
</xsl:stylesheet>