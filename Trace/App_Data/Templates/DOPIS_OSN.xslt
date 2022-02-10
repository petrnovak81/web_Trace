<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <xsl:template match="/">
      <html  xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs" lang="cs">
      <body style="font-family:Arial, Helvetica, sans-serif;font-size:11pt;">
        <div style="height:1040px;">
          <p style="margin:0;font-size:7.5pt;color:#9C301A;">EOS KSI Česká republika, s.r.o.</p>
          <p style="margin-top:3px;font-size:7.5pt;color:#666366;">Novodvorská 994  CZ-142 21  Praha 4</p>
          <div style="margin-top:22px;">
            <xsl:value-of select="LETTER/PERSNAME"/>
            <xsl:text> </xsl:text>
            <xsl:value-of select="LETTER/PERSSURNAME"/>
            <br />
            <xsl:value-of select="LETTER/PERSSTREET"/>
            <xsl:text> </xsl:text>
            <xsl:value-of select="LETTER/PERSHOUSENUM"/>
            <br />
            <xsl:value-of select="LETTER/PERSZIPCODE"/>
            <xsl:text> </xsl:text>
            <xsl:value-of select="LETTER/PERSCITY"/>
          </div>
          <div style="margin-top:56px;">
            Číslo jednací: <b><xsl:value-of select="LETTER/ACC"/></b>
          </div>
          <h2 style="margin-top:50px;margin-bottom:0;text-align:center;font-size:18pt;">OSOBNÍ NÁVŠTĚVA</h2>
          <h2 style="margin-top:14px;text-align:center;font-size:12pt;">ZA ÚČELEM ÚHRADY DLUŽNÉ ČÁSTKY</h2>
          <p style="margin-top:22px;">
            <b>
              u <xsl:value-of select="LETTER/CREDITORALIAS"/>
            </b>
          </p>
          <p style="margin-top:33px;line-height:26px;">Vážený/á pane/paní, jelikož jste doposud nereagoval/a na naše telefonické a písemné výzvy, navštívil Vás na této adrese náš <b>inkasní inspektor</b>, aby s Vámi učinil mimosoudní dohodu o vyrovnání Vašeho závazku.</p>
          <p style="margin-top:33px;line-height:26px;">
            Bohužel se mu nepodařilo Vás osobně zastihnout, proto Vás žádáme, abyste provedl/a úhradu dlužné částky <b style="text-decoration:underline;">
              ve výši <xsl:value-of select="LETTER/ACTUALDEBIT"/><xsl:text> </xsl:text><xsl:value-of select="LETTER/CURRENCYTXT"/> a to nejpozději do 7 dnů</b> od obdržení tohoto dopisu.
          </p>
          <table style="width:100%;">
            <tr>
              <td style="text-decoration:underline;padding-bottom:8px;">PLATEBNÍ ÚDAJE</td>
              <td style="padding-bottom:8px;"></td>
              <td style="padding-bottom:8px;"></td>
              <td style="padding-bottom:8px;"></td>
           </tr>
            <tr>
              <td style="padding-bottom:8px;">
                <b>číslo účtu: </b>
              </td>
              <td style="padding-bottom:8px;">
                <xsl:value-of select="LETTER/BANKNUM"/>
              </td>
              <td style="padding-bottom:8px;">
                <b>variabilní symbol: </b>
              </td>
              <td style="padding-bottom:8px;">
                <xsl:value-of select="LETTER/VARIABLESYMBOL"/>
              </td>
            </tr>
            <tr>
              <xsl:choose>
                <xsl:when test="LETTER/SPECIFIC_SYMBOL !=''">
                  <td style="padding-bottom:8px;">
                    <b>specifický symbol: </b>
                  </td>
                  <td style="padding-bottom:8px;">
                    <xsl:value-of select="LETTER/SPECIFIC_SYMBOL"/>
                  </td>
              </xsl:when>
                <xsl:otherwise>
                  <td style="padding-bottom:8px;"></td>
                  <td style="padding-bottom:8px;"></td>
                </xsl:otherwise>
              </xsl:choose>
              <xsl:choose>
             <xsl:when test="LETTER/RECIPIENT_MESSAGE !=''">
       <td style="padding-bottom:8px;">
         <b>zpráva pro příjemce: </b>
       </td>
       <td style="padding-bottom:8px;">
             <xsl:value-of select="LETTER/RECIPIENT_MESSAGE"/>
       </td>
            </xsl:when>
     <xsl:otherwise>
       <td style="padding-bottom:8px;"></td>
       <td style="padding-bottom:8px;"></td>
     </xsl:otherwise>
   </xsl:choose>
            </tr>
          </table>
          <p style="margin-top:33px;line-height:26px;">
            Případně jej okamžitě kontaktujte na níže uvedeném čísle a <b>sjednejte si osobní schůzku</b>, na které budou projednány podmínky úhrady uvedené dlužné částky.
          </p>
          <p style="margin-top:33px;line-height:26px;">Pokud nezareagujete ani na tuto výzvu, bude přistoupeno k další krokům vedoucím k vymožení dlužné částky.</p>
          <hr size="1" />
          <p>Osobní návštěva provedena dne ............................................................. v........... hod.</p>
          <p>Inspektorem pro osobní návštěvy: <b>
            <xsl:value-of select="LETTER/USERNAME"/>
          </b></p>
          <p>Kontakt: <xsl:value-of select="LETTER/USERMOBILEPHONE"/>, <xsl:value-of select="LETTER/USEREMAIL"/>
          </p>
          <hr size="2" />
          <table border="0" cellspacing="0" cellpadding="0" style='width: 100%;'>
            <tr style='page-break-inside: avoid; height: 49.6pt'>
              <td width="155" valign="top" style='width: 116.4pt; padding: 0cm 0cm 0cm 0cm; height: 49.6pt'>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt; color: #9C301A'>EOS KSI Česká republika, s.r.o.</span>
                  <span style='font-size: 7.5pt;  color: #666366; text-transform: uppercase;'></span>
                </p>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366; text-transform: uppercase;'>Novodvorská 994</span>
                  <span style='font-size: 7.5pt; font-family: "Helvetica Linotype","sans-serif";'></span>
                </p>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt; font-family: "Helvetica Linotype","sans-serif";'>
                    CZ-142 <span>21 Praha</span> 4
                  </span>
                </p>
              </td>
              <td width="37" valign="top" style='width: 27.55pt; padding: 0cm 0cm 0cm 0cm; height: 49.6pt'>

              </td>
              <td width="127" valign="top" style='width: 94.95pt; padding: 0cm 0cm 0cm 0cm; height: 49.6pt'>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366'>Telefon</span>
                </p>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366'>+420 241 081 111</span>
                </p>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366'>
                    <span>Fax +420 241 081 110</span>
                    <span style='text-transform: uppercase;'></span>
                  </span>
                </p>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366; text-transform: uppercase;'>www.eos-ksi.cz</span>
                </p>
              </td>
              <td width="37" valign="top" style='width: 27.55pt; padding: 0cm 0cm 0cm 0cm; height: 49.6pt'>

              </td>
              <td width="192" valign="top" style='width: 143.95pt; padding: 0cm 0cm 0cm 0cm; height: 49.6pt'>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366'>
                    Registrováno v OR vedeném Městským<span style='text-transform: uppercase;'></span>
                  </span>
                </p>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366; text-transform: uppercase;'>Soudem v Praze, oddíl C, vložka 51150</span>
                </p>
              </td>
              <td width="37" valign="top" style='width: 27.55pt; padding: 0cm 0cm 0cm 0cm; height: 49.6pt'>

              </td>
              <td width="106" valign="top" style='width: 79.45pt; padding: 0cm 0cm 0cm 0cm; height: 49.6pt'>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366'>
                    IČ: 25 11 74 83<span style='text-transform: uppercase;'></span>
                  </span>
                </p>
                <p style='margin:0;margin-top:3px; '>
                  <span style='font-size: 7.5pt;  color: #666366; text-transform: uppercase;'>DIČ:CZ 699003397</span>
                </p>
              </td>
            </tr>
          </table>
        </div>
      </body></html>
  </xsl:template>
</xsl:stylesheet>