<?xml version="1.0" encoding="UTF-8" ?>
<html xsl:version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" style="margin:0;padding:0;width: 100%;">
<body style="margin:0;padding:0">
  <table style="width:100%;font-family: Arial;font-size: 12px; border-collapse: collapse;background-color: white;">
    <tr>
      <td valign="top" rowspan="2" style="padding:4px;"><h2><i>PŘÍLOHA K FAKTUŘE</i></h2></td>
      <td></td>
      <td style="padding:4px;text-align:right;font-size: 1.17em;font-weight: bold;">Měsíc fakturace:</td>
      <td style="padding:4px;text-align:right;font-size: 1.17em;font-weight: bold;">
        <xsl:value-of select="source/head/period" />
      </td>
    </tr>
    <tr>
      <td></td>
      <td style="padding:4px;text-align:right;font-size: 1.17em;font-weight: bold;">Celkem k fakturaci:</td>
      <td style="padding:4px;text-align:right;font-size: 1.17em;font-weight: bold;">
        <xsl:variable name="total" select="sum(//*[local-name()='table']/*[local-name()='row']/*[local-name()='Fee'])"/>
        <xsl:value-of select="format-number($total, '# ##0.00')"/>
      </td>
    </tr>
    <tr>
      <td valign="bottom" style="padding:4px;">
        <span>Inspektor: </span>
        <span>
          <h3>
            <xsl:value-of select="source/head/name" />
          </h3>
        </span>
      </td>
      <td></td>
      <td style="padding:4px;text-align:right;font-size: 1.17em;font-weight: bold;">Den fakturace:</td>
      <td style="padding:4px;text-align:right;font-size: 1.17em;font-weight: bold;">
        <xsl:value-of select="source/head/datum" />
      </td>
    </tr>
    <tr>
      <td></td>
      <td style="padding:4px;text-align:right"></td>
      <td style="padding:4px;text-align:right">
        
      </td>
    </tr>
  </table>

  <xsl:for-each select="source/table">
    <table style="margin-top: 20px;width:100%;font-family: Arial;font-size: 12px; border-collapse: collapse;background-color: white;">
      <tr style="background: #e5e5e5">
        <td style="color: #808080;padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;text-align:center;">
          <div>Příjmení,</div>
          <div>Jméno</div>
        </td>
        <td style="color: #808080;padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;text-align:center;">Věřitel</td>
        <td style="color: #808080;padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;width:60px;text-align:center;">
          <div>Číslo</div>
          <div>spisu</div>
        </td>
        <td style="color: #808080;padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;text-align:center;">Typ položky</td>
        <td style="color: #808080;padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;width:70px;text-align:center;">Datum</td>
        <td style="color: #808080;padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;width:70px;text-align:center;">
          <div>Platba</div>
          <div>(v Kč)</div>
        </td>
        <td style="color: #808080;padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;width:50px;text-align:center;">
          <div>Provize</div>
          <div>(v %)</div>
        </td>
        <td style="color: #808080;padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;border-right: 1px solid #808080;width:70px;text-align:center;">
          <div>Provize/</div>
          <div>Paušál</div>
          <div>(v Kč)</div>
        </td>
      </tr>
      <xsl:for-each select="row">
        <tr>
          <td style="padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;">
            <xsl:value-of select="Name" />
          </td>
          <td style="padding:4px;text-align:center;border-top: 1px solid #808080;border-left: 1px solid #808080;">
            <xsl:value-of select="CreditorAlias" />
          </td>
          <td style="padding:4px;text-align:center;border-top: 1px solid #808080;border-left: 1px solid #808080;">
            <xsl:value-of select="ACC" />
          </td>
          <td style="padding:4px;border-top: 1px solid #808080;border-left: 1px solid #808080;">
            <xsl:value-of select="TypeFeeTxt" />
          </td>
          <td style="padding:4px;text-align:right;border-top: 1px solid #808080;border-left: 1px solid #808080;">
            <xsl:value-of select="DateCreated" />
          </td>
          <td style="padding:4px;text-align:right;border-top: 1px solid #808080;border-left: 1px solid #808080;">
            <xsl:value-of select="format-number(Base, '# ##0.00')" />
          </td>
          <td style="padding:4px;text-align:center;border-top: 1px solid #808080;border-left: 1px solid #808080;">
            <xsl:value-of select="format-number(PercentFee, '0.00')" />%
          </td>
          <td style="padding:4px;text-align:right;border-top: 1px solid #808080;border-left: 1px solid #808080;border-right: 1px solid #808080;">
            <xsl:value-of select="format-number(Fee, '# ##0.00')" />
          </td>
        </tr>
      </xsl:for-each>
      <tr>
        <td style="border-top: 1px solid #808080;"></td>
        <td style="border-top: 1px solid #808080;"></td>
        <td style="border-top: 1px solid #808080;"></td>
        <td style="border-top: 1px solid #808080;"></td>
        <td colspan="3" style="text-align:right;padding:4px;border-top: 2px solid black;border-bottom: 2px solid black;border-left: 2px solid black;">
          <b>
        <xsl:if test="position() = 1">
          Paušál - celkem (v Kč):
        </xsl:if>
        <xsl:if test="position() > 1">
          Provize - celkem (v Kč):
        </xsl:if>
        </b>
        </td>
        <td style="text-align:right;padding:4px;border: 2px solid black;">
          <b>
            <xsl:value-of select="format-number(sum(row/Fee), '# ##0.00')"/>
          </b>
        </td>
      </tr>
    </table>
  </xsl:for-each>
</body>
</html>
