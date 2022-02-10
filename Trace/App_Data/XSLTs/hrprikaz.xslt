<?xml version="1.0" encoding="UTF-8" ?>
<html xsl:version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" style="margin:0;padding:0;width: calc(100% - 48px);">
<body style="margin:0;padding:0">
    <table style="width:100%;font-family: Arial;font-size: 12px; border-collapse: collapse;background-color: white;">
        <tbody>
            <tr>
                <td colspan="8">
                    <h3 style="color: #808080;">HROMADNÝ PŘÍKAZ K ÚHRADĚ</h3>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Číslo účtu plátce*</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Kód banky</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Celková částka</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Měna</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Datum splatnosti</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Konstantní symbol</td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:right;padding:4px;border: 1px solid #808080;border-left:2px solid #000000;border-top:2px solid #000000;border-bottom:2px solid #000000;">

                </td>
                <td style="text-align:center;padding:4px;border: 1px solid #808080;border-top:2px solid #000000;border-bottom:2px solid #000000;">

                </td>
                <td style="text-align:right;padding:4px;border: 1px solid #808080;border-top:2px solid #000000;border-bottom:2px solid #000000;">
                  <xsl:value-of select="format-number(source/header/SumAmountPickup, '# ##0.00')" />
                </td>
                <td style="padding:4px;border: 1px solid #808080;border-top:2px solid #000000;border-bottom:2px solid #000000;">
              <xsl:value-of select="source/header/CurrencyTxt" />
              </td>
                <td style="text-align:right;padding:4px;border: 1px solid #808080;border-top:2px solid #000000;border-bottom:2px solid #000000;">

                </td>
                <td style="text-align:right;padding:4px;border: 1px solid #808080;border-right:2px solid #000000;border-top:2px solid #000000;border-bottom:2px solid #000000;">

                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td colspan="6" style="color: #808080;padding:4px;">*V případě platby z účtu</td>
                <td></td>
            </tr>
            <tr>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">č.</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Číslo účtu plátce</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Kód banky</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Částka</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Měna</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Variabilní symbol</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Konstantní symbol</td>
              <td style="padding:4px;color: #808080;border: 1px solid #808080;text-align: center;">Specifický symbol</td>
            </tr>
          <xsl:for-each select="source/table/row">
            <xsl:variable name="index" select="position()"/>
            <tr>
              <td style="text-align:center;padding:4px;border: 1px solid #808080;">
                <xsl:value-of select="$index" />
              </td>
              <td style="text-align:right;padding:4px;border: 1px solid #808080;">
                <xsl:value-of select="AccountNumber" />
              </td>
              <td style="text-align:center;padding:4px;border: 1px solid #808080;">
                <xsl:value-of select="BankCode" />
              </td>
              <td style="text-align:right;padding:4px;border: 1px solid #808080;">
                <xsl:value-of select="format-number(AmountPickup, '# ##0.00')" />
              </td>
              <td style="padding:4px;border: 1px solid #808080;">
                <xsl:value-of select="CurrencyTxt" />
              </td>
              <td style="text-align:right;padding:4px;border: 1px solid #808080;">
                <xsl:value-of select="VariableSymbol" />
              </td>
              <td style="text-align:right;padding:4px;border: 1px solid #808080;">
                <xsl:value-of select="KonstantniSymbol" />
              </td>
              <td style="text-align:right;padding:4px;border: 1px solid #808080;">
                <xsl:value-of select="SpecificSymbol" />
              </td>
            </tr>
          </xsl:for-each>
            <tr>
                <td colspan="2" style="border-bottom: 1px dotted black;padding-top:48px;">V</td>
                <td></td>
                <td colspan="2" style="border-bottom: 1px dotted black;padding-top:48px;">dne</td>
                <td></td>
                <td colspan="2" style="border-bottom: 1px dotted black;padding-top:48px;"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td></td>
                <td colspan="2"></td>
                <td></td>
                <td colspan="2" style="text-align:center;padding-top:3px;">Razítko a podpis příkazce</td>
            </tr>
        </tbody>
    </table>
</body>
</html>
