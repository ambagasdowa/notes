<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pre_i_despasignarpedidos.aspx.vb"

    Inherits="pridesp01_pre_i_despasignarpedidos" %>

<html>

<head>

    <title>Asignación</title>

    <link href="../css/textos.css" type="text/css" rel="stylesheet">



<script language="javascript">

// -- =============================== Add ========================================== --

function validaOperator(){
// 	var response;
	alert(document.getElementById('txtOperador1').value);
	
// 	pridesp01_pre_i_despasignarpedidos.GetData(numberOp,GetData_CallBack);
};



function GetData(numberOp) {

	var response;
	pridesp01_pre_i_despasignarpedidos.GetData(numberOp,GetData_CallBack);

}



function GetData_CallBack(response) {



  var response=response.value;

  // alert(response);

  // document.getElementById('node-id').innerHTML = response;



  var pieces = response.split(",");

  var blocks = parseInt(pieces[0]);

  var restDays = pieces[1];

  var namae = pieces[2];

  var id_operador = pieces[3];

  var folio = pieces[4];

  var vence = pieces[5];

  // alert("block => " + blocks);

  // alert(typeof(blocks));

  // alert(vence);



  	if(blocks == 0) {

    alert("Licencia expirada desde " + restDays + " dias");

    document.getElementById("btnGuarda").disabled = true;

    // lblError.innerText = "";

    lblErrorAjax.innerText = "Licencia del operador "+ namae +" expirada desde " + restDays + " dias";

	} else if (blocks == 1) {

    alert("Licencia Vence en " + restDays + " dias");

    document.getElementById("btnGuarda").disabled = true;

    // lblError.innerText = "";

    lblErrorAjax.innerText = "La Licencia del Operador tiene menos de 10 dias para vencer";

  } else if (blocks == 2) {

    alert("Licencia sin Actualizar");

    document.getElementById("btnGuarda").disabled = true;

    // lblError.innerText = "";

    lblErrorAjax.innerText = "La Licencia del Operador necesita Actualizarse";

  } else if (blocks == 3) { // Entre 10 y 30 dias

    alert("Licencia Vence en " + restDays + " dias");

    // if button is disabled just enable

    if (document.getElementById("btnGuarda").disabled == true) {

      document.getElementById("btnGuarda").disabled = false;

    }

    document.getElementById('txtOperador1Nombre').length=0;

    document.getElementById('txtOperador1Nombre').value=namae;

    // lblError.innerText = "";

    lblErrorAjax.innerText = "La Licencia del Operador Vence en " + restDays + " dias";

  } else if (blocks == 4) {

    alert("El Operador esta dado de Baja");

    document.getElementById("btnGuarda").disabled = true;

    // lblError.innerText = "";

    lblErrorAjax.innerText = "El Operador " + namae + " esta dado de baja";

	} else { // mayor a un mes

    // if button is disabled just enable

    if (document.getElementById("btnGuarda").disabled == true) {

      document.getElementById("btnGuarda").disabled = false;

    }

    // Clear current data

		document.getElementById('txtOperador1Nombre').length=0;

    // set the new value

    document.getElementById('txtOperador1Nombre').value=namae;

    lblErrorAjax.innerText = ""

    // lblError.innerText = ""

	}

} // NOTE End Callback

    // -- =============================== NOTE Add  END========================================== --



    function BuscaRemDes(as_campo, as_descr, as_domi, as_plazac, as_idplaza) {

        var strURL; var winCliente;

        strURL = '../busqueda_estandar.aspx?Search=/srv_i_busquedas/ctrlsearch_clientes.ascx&Campo=' + as_campo + '&Descr=' + as_descr + '&Dom=' + as_domi + '&PlazaC=' + as_plazac + '&Opc=C' + '&IdPlaza=' + as_idplaza;

        winCliente = window.open(strURL, 'BuscaRemDes', 'width=640,height=480,status=no,scrollbars=no');

        winCliente.focus();

    }

    // -- =============================== check this ========================================== --

    function ValidaRemitente(intRemitente) {

        if (intRemitente == "") {

            document.form1.txtRemitente.value = ""

            document.form1.txtRemitenteNom.value = ""

            document.form1.txtRemitenteDom.value = ""

            document.form1.txtPlazaOrigenNom.value = ""

            document.form1.txtOrigen.value = ""

            lblErrorAjax.innerText = "Favor de capturar un dato en el campo Remitente"

            return;

        }

        else

        { pridesp01_pre_i_despasignarpedidos.ValidaRemitente(intRemitente,Remitente_CallBack); }

    }

    function Remitente_CallBack(response) {

        if (response.error != null) { return; }

        if (response.value[0] == 'Error') {

            document.form1.txtRemitente.value = ""

            document.form1.txtRemitenteNom.value = ""

            document.form1.txtRemitenteDom.value = ""

            document.form1.txtPlazaOrigenNom.value = ""

            document.form1.txtOrigen.value = ""

            lblErrorAjax.innerText = response.value[1]

        }

        else {

            document.form1.txtRemitente.value = response.value[0]

            document.form1.txtRemitenteNom.value = response.value[1]

            lblErrorAjax.innerText = ""

        }

    }

    // -- =============================== check this ========================================== --

    function ValidaDestinatario(valor) {

        pridesp01_pre_i_despasignarpedidos.ValidaDestinatario(valor,Destinatario_CallBack);

    }

               function Destinatario_CallBack(response)

            {

             if (response.error != null){return;}

                if (response.value[0] == 'Error')

                    {

                      lblErrorAjax.innerText = response.value[1]

                      document.form1.txtDestinatario.value = ""

                      document.form1.txtDestinatarioNom.value = ""

                      document.form1.txtDestinatarioDom.value = ""

                      document.form1.txtPlazaDestinoNom.value = ""

                      document.form1.txtDestino.value = ""

                     }

                else

                {

                    document.form1.txtDestinatario.value = response.value[0]

                    document.form1.txtDestinatarioNom.value = response.value[1]

                    lblErrorAjax.innerText = ""

                }

             }



</script>

    <style type="text/css">

        .style1

        {

            height: 26px;

        }

        .style2

        {

            height: 22px;

        }

    </style>

</head>

<body leftmargin="5" topmargin="5" onload="Load()">

  <div class="">

    <asp:Label id="lblOutputOp" runat="server" style="display:none;"></asp:Label>

  </div>

    <form id="form1" method="post" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">

        </asp:ScriptManager>

        <div id="contenido">

            <table border="0">

                <tr>

                    <td colspan="1">

                        <table style="background-position: right center; background-repeat: no-repeat" height="30"

                            background="../Imagenes/backs/fondoCh.gif" border="0">

                            <tr>

                                <td>

                                    Num. Asignación</td>

                                <td width="120">

                                    <asp:TextBox ID="txtNumAsignacion" TabIndex="-1" runat="server" CssClass="FechaHora"

                                        ReadOnly="True" Height="20px" BackColor="Transparent"></asp:TextBox></td>

                            </tr>

                        </table>

                    </td>

                    <td>

                        <table>

                             <tr>

                                <td>

                                    <input id="hdnStatus" type="hidden" style="width: 15px; height: 15px" runat="server" />

                                </td>

                             </tr>

                        </table>

                    </td>

                    <td>

                        <table border="0">

                            <tr>

                                <td>

                                </td>

                                <td>

                                    <div id="DivConfigViaje" style="display: none">

                                        <asp:DropDownList ID="ddlConfigViaje" TabIndex="50" runat="server" CssClass="labels">

                                            <asp:ListItem Value="1">Unidad Motriz</asp:ListItem>

                                            <asp:ListItem Value="2">Sencillo</asp:ListItem>

                                            <asp:ListItem Value="3">Full</asp:ListItem>

                                            <asp:ListItem Value="0">Sin Asignar</asp:ListItem>

                                        </asp:DropDownList>

                                    </div>

                                </td>

                                <td>

                                </td>

                            </tr>

                        </table>

                    </td>

                    <td width = "325" align="right">

                        <input id="txtHdnParCapCarga" runat=server type="hidden" />

                    </td>

                </tr>

                <tr>

                    <td colspan="3">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

                            <ContentTemplate>

                                <table style="background-position: right center; background-repeat: no-repeat" height="30"

                                    background="../Imagenes/backs/FONDOMdGde2.gif" border="0">

                                    <tr>

                                        <td width="50">

                                            Ruta</td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsNum(event);" ID="txtRuta" TabIndex="10" runat="server"

                                                CssClass="ID" MaxLength="9" onchange="ValidaRuta(this.value,document.form1.txtUnidad.value,igedit_getById('wdcInicioViaje').getText())"

                                                Height="20px" AutoPostBack="false"></asp:TextBox>&nbsp;

                                            <asp:TextBox ID="txtRutaDesc" TabIndex="-1" runat="server" CssClass="desc" ReadOnly="True"

                                                BackColor="Transparent" Height="20px" Width="200px"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvRuta" runat="server" Display="Dynamic" ControlToValidate="txtRuta"

                                                ErrorMessage="Favor de capturar un dato en el campo Ruta">*</asp:RequiredFieldValidator>

                                            <asp:CompareValidator ID="cvRuta" runat="server" Display="Dynamic" ControlToValidate="txtRuta"

                                                ErrorMessage="El dato capturado en el campo Ruta no es del tipo de dato válido."

                                                Type="Integer" Operator="DataTypeCheck">*</asp:CompareValidator>

                                            <asp:CustomValidator ID="cusvRuta" runat="server" Display="Dynamic" ControlToValidate="txtRuta"

                                                ErrorMessage="Dato inválido en el campo Ruta">*</asp:CustomValidator></td>

                                        <td>

                                            <img id="btnBuscarJefeFlota" style="cursor: hand" onclick="BuscaRuta('form1.txtRuta','form1.txtRutaDesc');"

                                                alt="Buscar Ruta" src="../Imagenes/BTbusc2.gif" align="absMiddle"></td>

                                    </tr>

                                </table>

                                <table border="0" width="100%">

                                    <tr>

                                        <td valign="top">

                                            <table style="background-position: right center; background-repeat: no-repeat" height="31"

                                                background="../Imagenes/backs/fondoCh.gif" border="0">

                                                <tr>

                                                    <td>

                                                        Inicio Viaje</td>

                                                    <td>

                                                        <igtxt:WebDateTimeEdit ID="wdcInicioViaje" TabIndex="20" runat="server" CssClass="FechaHora"

                                                            Height="20px">

                                                            <ClientSideEvents ValueChange="ValidaFechas(igedit_getById('wdcInicioViaje').getText(),igedit_getById('wdcFinViaje').getText())" />

                                                        </igtxt:WebDateTimeEdit>

                                                    </td>

                                                    <td>

                                                    </td>

                                                </tr>

                                            </table>

                                        </td>

                                        <td valign="top">

                                            <table style="background-position: right center; background-repeat: no-repeat" height="31"

                                                background="../Imagenes/backs/fondoCh.gif" border="0" class="style1">

                                                <tr>

                                                    <td width="70" align="right" class="style2">

                                                        Fin Viaje</td>

                                                    <td class="style2">

                                                        <igtxt:WebDateTimeEdit ID="wdcFinViaje" TabIndex="30" runat="server" CssClass="FechaHora"

                                                            Height="20px">

                                                            <ClientSideEvents ValueChange="ValidaFechas(igedit_getById('wdcInicioViaje').getText(),igedit_getById('wdcFinViaje').getText())" />

                                                        </igtxt:WebDateTimeEdit>

                                                    </td>

                                                    <td class="style2">

                                                    </td>

                                                </tr>

                                            </table>

                                        </td>

                                        <td valign="top">

                                            <table style="background-position: right center; background-repeat: no-repeat" height="31"

                                                background="../Imagenes/backs/fondoCh.gif" border="0">

                                                <tr>

                                                    <td width="70">

                                                        Hrs. Estandar</td>

                                                    <td>

                                                        <asp:TextBox onkeypress="return IsNum(event);" ID="txtHrsEstandar" TabIndex="40"

                                                            runat="server" CssClass="FechaFiltro" MaxLength="7" onchange="ValidaHora(this.value,igedit_getById('wdcInicioViaje').getText())"

                                                            Height="20px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvHrsEstandar" runat="server"

                                                                ControlToValidate="txtHrsEstandar" ErrorMessage="Favor de capturar un dato en el campo Hrs. Estandar">*</asp:RequiredFieldValidator></td>

                                                </tr>

                                            </table>

                                        </td>

                                    </tr>

                                </table>

                                <asp:Label ID="lblErrorUP1" runat="server" CssClass="labelop" ForeColor="Red" Visible="False"></asp:Label>

                            </ContentTemplate>

                            <Triggers>

                                <asp:AsyncPostBackTrigger ControlID="wdcInicioViaje" EventName="ValueChange" />

                                <asp:AsyncPostBackTrigger ControlID="wdcFinViaje" EventName="ValueChange" />

                                <asp:AsyncPostBackTrigger ControlID="txtHrsEstandar" EventName="TextChanged" />

                            </Triggers>

                        </asp:UpdatePanel>

                    </td>

                     <td width = "325" align="right" valign= "bottom" >

                        <img id="Img50" style="cursor: hand" Height="25" src="../imagenes/add_hover.gif" Width="25" onclick = "AgregaTraslado();" runat="server" visible="false" />

                    </td>

                </tr>

            </table>



            <asp:TextBox ID="lblRemDestHabil" runat="server" style="display:none" Text="0"></asp:TextBox>

            <table id="tblRemDest" style="display:none;" width="840px" runat="server" cellpadding="0" cellspacing="0" border="0">

                <tr>

                    <td align="left">

                        <div style="display:none;">

                            <asp:TextBox ID="txtOrigen" runat="server" TabIndex="-1" Width="5px"></asp:TextBox></div>

                        <table border="0" cellpadding="0" cellspacing="0">

                            <tr>

                                <td colspan="2">

                                    <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/fondoMdGde.gif);

                                        background-repeat: no-repeat">

                                        <tr>

                                            <td width="60">

                                                Remitente</td>

                                            <td>

                                                <asp:TextBox ID="txtRemitente" onchange="ValidaRemitente(this.value);" onkeypress="return IsInt(event);"

                                                    runat="server" Height="20px" CssClass="ID" TabIndex="41" MaxLength="9"></asp:TextBox>

                                                <asp:TextBox ID="txtRemitenteNom" runat="server" CssClass="desc" Width="250px" TabIndex="-1" Height="20"

                                                    BackColor="Transparent"></asp:TextBox></td>

                                            <td>

                                                <asp:RequiredFieldValidator ID="rfvRemitente" runat="server" ControlToValidate="txtRemitente"

                                                    Display="Dynamic" ErrorMessage="Debe capturar un dato en el campo Remitente">*</asp:RequiredFieldValidator><asp:CompareValidator

                                                        ID="cvRemitente" runat="server" ControlToValidate="txtRemitente" Display="Dynamic"

                                                        ErrorMessage="El dato capturado en el campo Remitente no es válido." Operator="DataTypeCheck"

                                                        Type="Integer">*</asp:CompareValidator>

                                                <img id="imgBuscRem" onclick="BuscaRemDes('form1.txtRemitente','form1.txtRemitenteNom','form1.txtRemitenteDom','form1.txtPlazaOrigenNom','form1.txtOrigen');"

                                                    alt="Buscar Remitente" name="imgBuscRem" src="../imagenes/BTBusc2.gif" style="cursor: hand"

                                                    title="Buscar Remitente" />

                                            </td>

                                        </tr>

                                    </table>

                                </td>

                            </tr>

                            <tr style="display:none">

                                <td>

                                    Plaza</td>

                                <td>

                                    <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/fondoMdGde.gif);

                                        background-repeat: no-repeat">

                                        <tr>

                                            <td>

                                                <asp:TextBox ID="txtPlazaOrigenNom" runat="server" CssClass="labelop" Width="320px"

                                                    TabIndex="-1" BackColor="Transparent"></asp:TextBox>

                                            </td>

                                            <td>

                                            </td>

                                        </tr>

                                    </table>

                                </td>

                            </tr>

                            <tr style="display:none">

                                <td>

                                    Domicilio</td>

                                <td>

                                    <asp:TextBox ID="txtRemitenteDom" runat="server" CssClass="labelop" Width="320px"

                                        TabIndex="-1" Height="30px" Rows="3" TextMode="MultiLine"></asp:TextBox></td>

                            </tr>

                            <tr style="display:none">

                                <td>

                                    Recoger En</td>

                                <td>

                                    <asp:TextBox ID="txtRecogerEn" onkeydown="TextCount(this,240);" onkeyup="TextCount(this,240);"

                                        runat="server" CssClass="labelop" Rows="3" TextMode="MultiLine" Width="320px"

                                        Height="30px" TabIndex="5"></asp:TextBox></td>

                            </tr>

                        </table>

                    </td>

                </tr>

                <tr>

                    <td align="left">

                                            <div style="display:none;">

                            <asp:TextBox ID="txtDestino" runat="server" TabIndex="-1" Width="5px"></asp:TextBox></div>

                        <table border="0" cellpadding="0" cellspacing="0">

                            <tr>

                                <td colspan="2">

                                    <table style="background-position: right center; background-image: url(../imagenes/backs/fondoMdGde.gif);

                                        background-repeat: no-repeat">

                                        <tr>

                                            <td width="60">

                                                Destinatario</td>

                                            <td>

                                                <asp:TextBox ID="txtDestinatario" onkeypress="return IsInt(event);" runat="server" Height="20"

                                                    CssClass="ID" onchange="ValidaDestinatario(this.value);" TabIndex="42" MaxLength="9"></asp:TextBox>

                                                <asp:TextBox ID="txtDestinatarioNom" runat="server" CssClass="desc" Width="250px" Height="20"

                                                    TabIndex="-1" BackColor="Transparent"></asp:TextBox></td>

                                            <td>

                                                <asp:RequiredFieldValidator ID="rfvDestinatario" runat="server" ControlToValidate="txtDestinatario"

                                                    Display="Dynamic" ErrorMessage="Debe capturar un dato en el campo Destinatario">*</asp:RequiredFieldValidator><asp:CompareValidator

                                                        ID="cvDestinatario" runat="server" ControlToValidate="txtDestinatario" Display="Dynamic"

                                                        ErrorMessage="El dato capturado en el campo Destinatario no es válido." Operator="DataTypeCheck">*</asp:CompareValidator>

                                                <img id="imgBuscDes" onclick="BuscaRemDes('form1.txtDestinatario','form1.txtDestinatarioNom','form1.txtDestinatarioDom','form1.txtPlazaDestinoNom','form1.txtDestino');"

                                                    alt="Buscar Destinatario" name="imgBuscDes" src="../imagenes/BTBusc2.gif" style="cursor: hand"

                                                    title="Buscar Destinatario" /></td>

                                        </tr>

                                    </table>

                                </td>

                            </tr>

                            <tr style="display:none">

                                <td>

                                    Plaza</td>

                                <td align="left" style="width: 341px">

                                    <table cellspacing="0" cellpadding="0" border="0" style="background-position: right center;

                                        background-image: url(../imagenes/backs/fondoMdGde.gif); background-repeat: no-repeat"

                                        height="30">

                                        <tr>

                                            <td>

                                                <asp:TextBox ID="txtPlazaDestinoNom" runat="server" CssClass="labelop" Width="320px"

                                                    TabIndex="-1" BackColor="Transparent"></asp:TextBox>

                                            </td>

                                            <td width="5">

                                            </td>

                                        </tr>

                                    </table>

                                </td>

                            </tr>

                            <tr style="display:none">

                                <td>

                                    Domicilio</td>

                                <td style="width: 341px">

                                    <asp:TextBox ID="txtDestinatarioDom" runat="server" CssClass="labelop" Width="320px"

                                        TabIndex="-1" Height="30px" Rows="3" TextMode="MultiLine"></asp:TextBox></td>

                            </tr>

                            <tr style="display:none">

                                <td>

                                    Entregar En</td>

                                <td style="width: 341px">

                                    <asp:TextBox ID="txtEntregarEn" onkeydown="TextCount(this,240);" onkeyup="TextCount(this,240);"

                                        runat="server" CssClass="labelop" Rows="3" TextMode="MultiLine" Width="320px"

                                        Height="30px" TabIndex="7"></asp:TextBox></td>

                            </tr>

                        </table>

                    </td>

                </tr>

            </table>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                <ContentTemplate>

                    <table>

                        <tr>

                            <td id="TD1" runat="server">

                            <div id="DivKit" runat="server" style="display:none">

                            <table id="tblkit" border="0" runat="server" style="background-position: right center;

                                    background-image: url(../imagenes/backs/FondoCH.gif); background-repeat: no-repeat"

                                    height="30">

                                    <tr>

                                        <td width="50">

                                            No. Kit</td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsStr(event);" ID="txtKit" TabIndex="50" runat="server"

                                                CssClass="IDvch" MaxLength="10" onchange="ValidaKit(this.value);" Height="20px"></asp:TextBox>

                                            <asp:CompareValidator ID="Comparevalidator1" runat="server" Display="Dynamic" ControlToValidate="txtKit"

                                                ErrorMessage="El dato capturado en el campo No. Kit no es del tipo de dato válido."

                                                Operator="DataTypeCheck">*</asp:CompareValidator><asp:CustomValidator ID="cusvKit"

                                                    runat="server" Display="Dynamic" ControlToValidate="txtKit" ErrorMessage="Dato inválido en el campo No. Kit">*</asp:CustomValidator></td>

                                        <td style="color: #000000">

                                            <img id="ImgKit" style="cursor: hand" onclick="BuscaKit();" alt="Buscar Kit" src="../Imagenes/BTbusc2.gif"

                                                align="absMiddle"></td>

                                        <td style="color: #000000">

                                        </td>

                                    </tr>

                                </table>

                                </div>

                            </td>

                            <td colspan="3" style="color: #000000">

                                <img id="imgTracto" alt="" src="<%= strImgTractor %>"><img id="imgRemolque1" alt=""

                                    src="<%= strImgRemolque1 %>"><img id="imgDolly" alt="" src="<%= strImgDolly %>"><img

                                        id="imgRemolque2" alt="" src="<%= strImgRemolque2 %>"></td>

                        </tr>

                        <tr style="color: #000000">

                            <td valign="top">

                                <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                    <tr>

                                        <td width="50">

                                            Tractor</td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsStr(event);" ID="txtUnidad" onblur="modifunidad();"

                                                TabIndex="60" runat="server" CssClass="IDvch" MaxLength="10" Height="20px" onchange="ValidaUnidad(this.value)"></asp:TextBox></td>

                                        <td>

                                            <asp:CompareValidator ID="cvUnidad" runat="server" Display="Dynamic" ControlToValidate="txtUnidad"

                                                ErrorMessage="El dato capturado en el campo Unidad no es del tipo de dato válido."

                                                Operator="DataTypeCheck">*</asp:CompareValidator><asp:CustomValidator ID="cusvUnidad"

                                                    runat="server" Display="Dynamic" ControlToValidate="txtUnidad" ErrorMessage="Dato inválido en el campo Unidad">*</asp:CustomValidator>

                                            <img id="Img3" style="cursor: hand" onclick="BuscaTractor();" alt="Buscar Tractor"

                                                src="../Imagenes/BTbusc2.gif" align="absMiddle"></td>

                                        <td>

                                        </td>

                                    </tr>

                                </table>

                                <div id="DivFianza1" runat="server" style="visibility:hidden">

                                <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                <tr>

                                <td>Fianza 1</td>

                                <td colspan="2">

                                    <asp:TextBox runat="server" ID="txtFianza1" ReadOnly="true" Height="20px"  CssClass="IDvch"></asp:TextBox>

                                </td>

                                 <td>

                                <img id="img1" style="cursor: hand" onclick="EditarFianza(document.getElementById('txtLineaRem1').value,document.getElementById('txtRemolque1').value,'1',true);"

                                alt="Editar Fianza" src="../Imagenes/editar.gif" align="absMiddle"></td>

                                </tr>

                                </table>

                                </div>

                            </td>

                            <td>

                                <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                    <tr>

                                        <td width="85">

                                            Línea Rem. 1</td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsStr(event);" ID="txtLineaRem1" TabIndex="70" runat="server"

                                                CssClass="IDvch" MaxLength="10" onchange="ValidaLineasyRemolques(this.value,document.getElementById('txtRemolque1').value,1);"

                                                Height="20px"></asp:TextBox>

                                            <asp:CompareValidator ID="cvLineaRem1" runat="server" Display="Dynamic" ControlToValidate="txtLineaRem1"

                                                ErrorMessage="El dato capturado en el campo Linea Rem. 1 no es del tipo de dato válido."

                                                Operator="DataTypeCheck">*</asp:CompareValidator><asp:CustomValidator ID="cusvLineaRem1"

                                                    runat="server" Display="Dynamic" ControlToValidate="txtLineaRem1" ErrorMessage="Dato inválido en el campo Linea Rem. 1">*</asp:CustomValidator></td>

                                        <td style="color: #000000">

                                            <img id="Img5" style="cursor: hand" onclick="BuscaLinea('form1.txtLineaRem1');" alt="Buscar Línea Remolque"

                                                src="../Imagenes/BTbusc2.gif" align="absMiddle" runat="server"></td>

                                        <td style="color: #000000">

                                        </td>

                                    </tr>

                                </table>

                                <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat; color: #000000;">

                                    <tr>

                                        <td width="85">

                                            Remolque 1</td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsStr(event);" ID="txtRemolque1" onchange="ValidaLineasyRemolques(document.getElementById('txtLineaRem1').value,this.value,1);"

                                                onblur="modifrem1();" TabIndex="80" runat="server" CssClass="IDvch" MaxLength="20"

                                                Height="20px"></asp:TextBox>

                                            <asp:CompareValidator ID="cvRemolque1" runat="server" Display="Dynamic" ControlToValidate="txtRemolque1"

                                                ErrorMessage="El dato capturado en el campo Remolque 1 no es del tipo de dato válido."

                                                Operator="DataTypeCheck">*</asp:CompareValidator><asp:CustomValidator ID="cusvRemolque1"

                                                    runat="server" Display="Dynamic" ControlToValidate="txtRemolque1" ErrorMessage="Dato inválido en el campo Remolque 1">*</asp:CustomValidator></td>

                                        <td style="color: #000000">

                                            <img id="ImgSearchRem1" style="cursor: hand" onclick="BuscaRemolque('form1.txtRemolque1','form1.txtLineaRem1');"

                                                alt="Buscar Remolque 1" src="../Imagenes/BTbusc2.gif" align="absMiddle" runat="server"></td>

                                        <td style="color: #000000">

                                        </td>

                                    </tr>

                                </table>

                            </td>

                            <td valign="top" style="color: #000000">

                                <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                    <tr>

                                        <td>

                                            Dolly</td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsStr(event);" ID="txtDolly" onblur="modifdolly();"

                                                TabIndex="90" runat="server" onchange="ValidaDolly(this.value);" CssClass="IDvch"

                                                MaxLength="10" Height="20px"></asp:TextBox>

                                            <asp:CompareValidator ID="cvDolly" runat="server" Display="Dynamic" ControlToValidate="txtDolly"

                                                ErrorMessage="El dato capturado en el campo Dolly no es del tipo de dato válido."

                                                Operator="DataTypeCheck">*</asp:CompareValidator><asp:CustomValidator ID="cusvDolly"

                                                    runat="server" Display="Dynamic" ControlToValidate="txtDolly" ErrorMessage="Dato inválido en el campo Dolly">*</asp:CustomValidator></td>

                                        <td style="color: #000000">

                                            <img id="imgBDolly" style="cursor: hand" onclick="BuscaDolly('form1.txtDolly');"

                                                alt="Buscar Dolly" src="../Imagenes/BTbusc2.gif" align="absMiddle" name="imgBDolly"></td>

                                        <td style="color: #000000">

                                        </td>

                                    </tr>

                                </table>

                                 <div id="DivFianza2" runat="server" style="visibility:hidden">

                                 <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                <tr>

                                <td><a>Fianza 2 </a></td>

                                <td colspan="2">

                                    <asp:TextBox runat="server" ID="txtFianza2" ReadOnly="true"  Height="20px" CssClass="IDvch"></asp:TextBox>

                                </td>

                                <td>  <img id="img2" style="cursor: hand" onclick="EditarFianza(document.getElementById('txtLineaRem2').value,document.getElementById('txtRemolque2').value,'2',true);"

                                alt="Editar Fianza" src="../Imagenes/editar.gif" align="absMiddle"></td>

                                </tr>

                                </table>

                                 </div>

                            </td>

                            <td valign="top" style="color: #000000">

                                <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                    <tr>

                                        <td width="85">

                                            Línea Rem 2</td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsStr(event);" ID="txtLineaRem2" TabIndex="100" runat="server"

                                                CssClass="IDvch" MaxLength="10" onchange="ValidaLineasyRemolques(this.value,document.getElementById('txtRemolque2').value,2);"

                                                Height="20px"></asp:TextBox>

                                            <asp:CompareValidator ID="cvLineaRem2" runat="server" Display="Dynamic" ControlToValidate="txtLineaRem2"

                                                ErrorMessage="El dato capturado en el campo Linea Rem. 2 no es del tipo de dato válido."

                                                Operator="DataTypeCheck">*</asp:CompareValidator><asp:CustomValidator ID="cusvLineaRem2"

                                                    runat="server" Display="Dynamic" ControlToValidate="txtLineaRem2" ErrorMessage="Dato inválido en el campo Linea Rem. 2">*</asp:CustomValidator></td>

                                        <td style="color: #000000">

                                            <img id="Img7" style="cursor: hand" onclick="BuscaLinea('form1.txtLineaRem2');" alt="Buscar Línea Remolque"

                                                src="../Imagenes/BTbusc2.gif" align="absMiddle" runat="server"></td>

                                        <td style="color: #000000">

                                        </td>

                                    </tr>

                                </table>

                                <table border="0" style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat; color: #000000;">

                                    <tr>

                                        <td width="85">

                                            Remolque 2</td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsStr(event);" ID="txtRemolque2" onblur="modifrem2();"

                                                TabIndex="110" onchange="ValidaLineasyRemolques(document.getElementById('txtLineaRem2').value,this.value,2);"

                                                runat="server" CssClass="IDvch" MaxLength="20" Height="20px"></asp:TextBox>

                                            <asp:CompareValidator ID="cvRemolque2" runat="server" Display="Dynamic" ControlToValidate="txtRemolque2"

                                                ErrorMessage="El dato capturado en el campo Remolque 2 no es del tipo de dato válido."

                                                Operator="DataTypeCheck">*</asp:CompareValidator><asp:CustomValidator ID="cusvRemolque2"

                                                    runat="server" Display="Dynamic" ControlToValidate="txtRemolque2" ErrorMessage="Dato inválido en el campo Remolque 2">*</asp:CustomValidator></td>

                                        <td style="color: #000000">

                                            <img id="ImgSearchRem2" style="cursor: hand" onclick="BuscaRemolque('form1.txtRemolque2','form1.txtLineaRem2');"

                                                alt="Buscar Remolque 2" src="../Imagenes/BTbusc2.gif" align="absMiddle" runat="server"></td>

                                        <td style="color: #000000">

                                        </td>

                                    </tr>

                                </table>

                            </td>

                        </tr>

                        <tr id=trInfoCapacidadCarga runat=server>

                            <td align=right>

                                <table id=tblTUTracto style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                    <tr>

                                        <td align="left">Tipo</td>

                                        <td>

                                            <asp:TextBox ID="txtTipoUTracto" runat="server" CssClass="IDvch" Height="20px"

                                                ReadOnly="True" Width="120px" TabIndex="-1" BackColor="Transparent"></asp:TextBox>

                                        </td>

                                        <td>

                                            <div style="visibility:hidden">

                                                <asp:TextBox ID="txtIdTipoUTracto" runat="server"

                                                    Width="20px" CssClass="IDvch">0</asp:TextBox></div>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                            <td align=right>

                                <table border=0 id=tblTURem1 style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                    <tr>

                                        <td width="85" align="right">Tipo</td>

                                        <td>

                                            <asp:TextBox ID="txtTipoURem1" runat="server" CssClass="IDvch" Height="20px"

                                                ReadOnly="True" Width="120px" TabIndex="-1" BackColor="Transparent"></asp:TextBox>

                                        </td>

                                        <td>

                                            <div style="visibility:hidden">

                                                <asp:TextBox ID="txtIdTipoUR1" runat="server"

                                                    Width="20px" CssClass="IDvch">0</asp:TextBox></div>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                            <td align=right>

                                <table border=0 id=tblTUDolly runat=server style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                    <tr>

                                        <td>Tipo</td>

                                        <td>

                                            <asp:TextBox ID="txtTipoUDolly" runat="server" ReadOnly="True" TabIndex="-1"

                                                Width="120px" CssClass="IDvch" Height="20px" BackColor="Transparent"></asp:TextBox>

                                        </td>

                                        <td>

                                            <div style="visibility:hidden">

                                                <asp:TextBox ID="txtIdTipoUD" runat="server"

                                                    Width="20px" CssClass="IDvch">0</asp:TextBox></div>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                            <td align=right>

                                <table border=0 id=tblTURem2 runat=server style="background-position: right center; background-image: url(../imagenes/backs/FondoCH.gif);

                                    background-repeat: no-repeat">

                                    <tr>

                                        <td>Tipo</td>

                                        <td>

                                            <asp:TextBox ID="txtTipoURem2" runat="server" CssClass="IDvch" Height="20px"

                                                ReadOnly="True" TabIndex="-1" Width="120px" BackColor="Transparent"></asp:TextBox>

                                        </td>

                                        <td>

                                            <div style="visibility:hidden">

                                                <asp:TextBox ID="txtIdTipoUR2" runat="server"

                                                    Width="20px" CssClass="IDvch">0</asp:TextBox></div>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                        </tr>

                        <tr id=trConfigMTC runat=server>

                            <td align=center><asp:Label ID="lblConfigMTC" runat="server" Text="Configuración MTC: "></asp:Label></td>

                            <%--<td align=center>Configuraci&oacute;n MTC</td>--%>

                            <td align=right>

                                <table border=0 cellpadding=0 cellspacing=0>

                                    <tr>

                                        <td></td>

                                        <td align=center>Capacidad M3</td>

                                        <td align=center>M3 Cargar</td>

                                    </tr>

                                    <tr>

                                        <td></td>

                                        <td>

                                            <asp:TextBox ID="txtCapacidadM3" runat="server" CssClass="IDvch" Height="20px"

                                                ReadOnly="True"></asp:TextBox>

                                        </td>

                                        <td>

                                            <asp:TextBox ID="txtCargarM3" runat="server" CssClass="IDvch" Height="20px"

                                                ReadOnly="True"></asp:TextBox>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                            <td align=right>

                                <table border=0 cellpadding=0 cellspacing=0>

                                    <tr>

                                        <td></td>

                                        <td align=center>Capacidad KG</td>

                                        <td align=center>KG Cargar</td>

                                    </tr>

                                    <tr>

                                        <td></td>

                                        <td>

                                            <asp:TextBox ID="txtCapacidadKG" runat="server" CssClass="IDvch" Height="20px"

                                                ReadOnly="True"></asp:TextBox>

                                        </td>

                                        <td>

                                            <asp:TextBox ID="txtCargaKG" runat="server" CssClass="IDvch" Height="20px"

                                                ReadOnly="True"></asp:TextBox>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                            <td align=right>

                                <table cellpadding=0 cellspacing=0 id=tblInfoPallets style="visibility:hidden" border=0>

                                    <tr>

                                        <td></td>

                                        <td align=center>Capacidad Pallets</td>

                                        <td align=center>Pallets Cargar</td>

                                    </tr>

                                    <tr>

                                        <td></td>

                                        <td>

                                            <asp:TextBox ID="txtCapacidadPallets" runat="server" CssClass="IDvch"

                                                Height="20px"></asp:TextBox>

                                        </td>

                                        <td>

                                            <asp:TextBox ID="txtCargaPallets" runat="server" CssClass="IDvch" Height="20px"></asp:TextBox>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                        </tr>

                        <tr style="color: #000000">

                            <td colspan="2">

                                <table id="Table3" style="background-position: right center; background-repeat: no-repeat"

                                    height="31" cellspacing="1" cellpadding="1" background="../Imagenes/backs/FONDOMdGde2.gif"

                                    border="0">

                                    <tr>

                                        <td width="60">

                                          <asp:Label ID="lblOperador1" runat="server" CssClass="labelop" Font-Size="8pt"></asp:Label>

                                        </td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsInt(event);" ID="txtOperador1" TabIndex="120" runat="server"

                                                CssClass="ID" MaxLength="9" onchange="GetData(this.value);" Height="20px">

                                            </asp:TextBox>&nbsp;



                                            <asp:TextBox

                                                    ID="txtOperador1Nombre" TabIndex="-1" runat="server" CssClass="desc" ReadOnly="True"

                                                    Width="200px" Height="20px" BackColor="Transparent">

                                            </asp:TextBox>&nbsp;



                                            <img id="imgBscaOperador"

                                                        style="cursor: hand" onclick="BuscaOperador('form1.txtOperador1','form1.txtOperador1Nombre');"

                                                        alt="Buscar Operador 1" src="../Imagenes/BTbusc2.gif" align="absMiddle">

                                            
                                           <img id="btnValidOp" style="cursor: hand" title="ValidaOp" onclick="GetData(document.getElementById('txtOperador1').value);" />
                                            

                                              <asp:RequiredFieldValidator ID="rfvOperador1" runat="server" Display="Dynamic" ControlToValidate="txtOperador1"

                                                ErrorMessage="Favor de capturar un dato en el campo Operador 1">

                                                  *

                                              </asp:RequiredFieldValidator>



                                              <asp:CompareValidator

                                                    ID="cvOperador1" runat="server" Display="Dynamic" ControlToValidate="txtOperador1"

                                                    ErrorMessage="El dato capturado en el campo Operador 1 no es del tipo de dato válido."

                                                    Type="Integer" Operator="DataTypeCheck">

                                                    *

                                              </asp:CompareValidator>



                                              <asp:CustomValidator

                                                        ID="cusvOperador1" runat="server" Display="Dynamic" ControlToValidate="txtOperador1"

                                                        ErrorMessage="El Operador no existe">

                                                *

                                              </asp:CustomValidator>



                                          </td>

                                        <td>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                            <td colspan="2" align="right">

                                <table id="TableOp2" style="background-position: right center; background-repeat: no-repeat;

                                    background-image: url(../Imagenes/backs/FONDOMdGde2.gif);" height="31" cellspacing="1"

                                    cellpadding="1" border="0">

                                    <tr>

                                        <td width="60"><asp:Label ID="lblOperador2" runat="server" CssClass="labelop" Font-Size="8pt"></asp:Label></td>

                                        <td>

                                            <asp:TextBox onkeypress="return IsInt(event);" ID="txtOperador2" TabIndex="130" runat="server"

                                                CssClass="ID" MaxLength="9" onchange="ValidaOperador(this.value,2);" Height="20px"></asp:TextBox>&nbsp;<asp:TextBox

                                                    ID="txtOperador2Nombre" TabIndex="-1" runat="server" CssClass="desc" ReadOnly="True"

                                                    Width="200px" Height="20px" BackColor="Transparent"></asp:TextBox>&nbsp;<img id="imgBscaOperador2"

                                                        style="cursor: hand" onclick="BuscaOperador('form1.txtOperador2','form1.txtOperador2Nombre');"

                                                        alt="Buscar Operador 2" src="../Imagenes/BTbusc2.gif" align="absMiddle"><asp:CompareValidator

                                                            ID="cvOperador2" runat="server" Display="Dynamic" ControlToValidate="txtOperador2"

                                                            ErrorMessage="El dato capturado en el campo Operador 2 no es del tipo de dato válido."

                                                            Type="Integer" Operator="DataTypeCheck">*</asp:CompareValidator><asp:CustomValidator

                                                                ID="cusvOperador2" runat="server" Display="Dynamic" ControlToValidate="txtOperador2"

                                                                ErrorMessage="El Operador 2 no existe">*</asp:CustomValidator></td>

                                        <td>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                        </tr>

                        <tr>

                            <td colspan="2">

                                <table id="Table7" style="background-position: right center; background-image: url(../Imagenes/backs/FONDOMdGde2.gif);

                                    background-repeat: no-repeat;" cellspacing="1" cellpadding="1" border="0" height="31">

                                    <tr>

                                        <td width="60">

                                            <asp:Label ID="lblSeguimiento" runat="server">Seguimiento</asp:Label>

                                        </td>

                                        <td>

                                            <asp:TextBox ID="txtSeguimiento" TabIndex="140" runat="server" CssClass="ID" MaxLength="9"

                                                onchange="ValidaSeguimiento(this.value);" Height="20px"></asp:TextBox>

                                            &nbsp;<asp:TextBox ID="txtSeguimientoDesc" TabIndex="-1" runat="server" CssClass="desc"

                                                ReadOnly="True" Width="200px" Height="20px" BackColor="Transparent"></asp:TextBox>

                                            &nbsp;<img

                                                    id="imgBscaSeguimiento" style="cursor: hand" onclick="BuscaSeguimiento();" alt="Buscar Seguimiento"

                                                    src="../Imagenes/BTbusc2.gif" align="absMiddle">

                                            <asp:CompareValidator ID="cvSeguimiento" runat="server" Display="Dynamic" ControlToValidate="txtSeguimiento"

                                                ErrorMessage="El dato capturado en el campo Seguimiento no es del tipo de dato válido."

                                                Operator="DataTypeCheck">*</asp:CompareValidator><asp:RequiredFieldValidator ID="rfvSeguimiento"

                                                    runat="server" ErrorMessage="Debe capturar un dato en el campo Seguimiento" ControlToValidate="txtSeguimiento"

                                                    Display="Dynamic">*</asp:RequiredFieldValidator><asp:CustomValidator ID="cusvSeguimiento"

                                                        runat="server" ErrorMessage="El Seguimiento no existe en la base de datos." ControlToValidate="txtSeguimiento"

                                                        Display="Dynamic">*</asp:CustomValidator></td>

                                        <td>

                                        </td>

                                    </tr>

                                </table>

                            </td>

                            <td colspan="2">

                            </td>

                        </tr>

                        <tr>

                            <td colspan="3">

                                <table style="width: 500px; height: 58px" cellspacing="1" cellpadding="1" border="0">

                                    <tr>

                                        <td>

                                            <p align="right">

                                                <asp:Label ID="Label1" runat="server">Observaciones</asp:Label></p>

                                        </td>

                                        <td style="background-position: right center; background-repeat: no-repeat" width="490"

                                            background="../Imagenes/backs/FONDOObs.gif" height="60">

                                            <asp:TextBox onkeypress="return IsStr(event);" onpaste="PasteStr(this);" ID="txtObservaciones"

                                                onkeydown="TextCount(this,250);" onkeyup="TextCount(this,250);" TabIndex="150"

                                                runat="server" CssClass="labels" MaxLength="255" Width="478px" TextMode="MultiLine"

                                                Rows="3" Height="46px"></asp:TextBox>&nbsp;</td>

                                    </tr>

                                </table>

                            </td>

                            <td valign="top" align="right">

                                <table style="background-position: right center; background-repeat: no-repeat" height="31"

                                    background="../Imagenes/backs/fondoCh.gif" border="0">

                                    <tr>

                                        <td width="70" align="right">

                                            Ingresó</td>

                                        <td>

                                            <asp:TextBox ID="txtIngreso" TabIndex="-1" runat="server" CssClass="IDVch" ReadOnly="True"

                                                Height="20px" BackColor="Transparent"></asp:TextBox>&nbsp;</td>

                                    </tr>

                                </table>

                            </td>

                        </tr>

                        <tr>

                            <td colspan="4">

                                <asp:Label ID="lblError" runat="server" CssClass="LabelError" Visible="False"></asp:Label>

                                <%--<asp:Label ID="lblErrorAjax" runat="server" CssClass="LabelError"></asp:Label>--%>

                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>

                        </tr>

                        <tr>

                            <td colspan="4">

                            <asp:Label ID="lblErrorAjax" runat="server" CssClass="LabelError"></asp:Label>

                        </tr>

                    </table>

                </ContentTemplate>

            </asp:UpdatePanel>

            <table>

                <tr>

                    <td>

                        <table>

                            <tr>

                                <td valign="top">

                                    &nbsp;</td>

                                <td valign="top">

                                  <%--  <asp:ImageButton ID="btnGuardar" AccessKey="G" TabIndex="160" runat="server" ImageUrl="../Imagenes/GUARDAR_b.gif"

                                        AlternateText="Guardar información (Alt+G)" ToolTip="Guardar información (Alt+G)">

                                    </asp:ImageButton>--%>

                                    <div id="DivGuardar" runat="server" style="display:block;">

                                    <img id="btnGuarda" style="cursor: hand" title="Guardar" src="../Imagenes/GUARDAR_b.gif"

                                        onclick="Guardar();" />

                                        </div>

                                </td>

                                <td valign="bottom">

                                    <igtxt:WebImageButton ID="wibSalir" runat="server" AccessKey="S" AutoSubmit="False"

                                        CausesValidation="False" ToolTip="Regresar al listado (Alt+S)" TabIndex="170">

                                        <Appearance>

                                            <Image AlternateText="Regresar al listado (Alt+S)" Url="../imagenes/B_salir_z.gif" />

                                           <ButtonStyle BackColor="Transparent" BorderStyle="None" BorderWidth="0px" Cursor="Hand">

                                                <BorderDetails ColorLeft="Transparent" ColorTop="Transparent" ColorRight="Transparent" ColorBottom="Transparent" StyleLeft="None" StyleRight="None" StyleTop="None" StyleBottom="None">

                                                </BorderDetails>

                                            </ButtonStyle>

                                            <InnerBorder StyleBottom="None" StyleLeft="None" StyleRight="None" StyleTop="None" />

                                        </Appearance>

                                        <ClientSideEvents Click="wibSalir_Click" />

                                        <Alignments VerticalAll="Bottom" />

                                    </igtxt:WebImageButton>

                                </td>

                            </tr>

                        </table>

                    </td>

                </tr>

            </table>

            <br />

            <div style="visibility: hidden">

                <asp:TextBox ID="txtOperador1Original" runat="server" CssClass="ID" Visible="False"

                    BackColor="Transparent" Height="20px"></asp:TextBox><asp:TextBox ID="txtOperador2Original"

                        runat="server" CssClass="ID" Visible="False" BackColor="Transparent" Height="20px"></asp:TextBox><input

                            class="ID" id="Hidden1" type="hidden" name="txtHdnIndice" runat="server" style="height: 20px">&nbsp;

                <input class="ID" id="txtHdnValidaArmado" type="hidden" name="txtHdnValidaArmado"

                    runat="server" style="height: 20px" value="1">

                <table border="0">

                    <tr>

                        <td>

                            <igtbl:UltraWebGrid ID="uwgPaso" runat="server" Width="100%" Height="80px">

                                <DisplayLayout AutoGenerateColumns="False" AllowSortingDefault="Yes" RowHeightDefault="5px"

                                    Version="3.00" SelectTypeRowDefault="Single" AllowColumnMovingDefault="OnServer"

                                    HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"

                                    EnableInternalRowsManagement="True" Name="uwgPaso" CellClickActionDefault="RowSelect"

                                    NoDataMessage="No hay registros a desplegar">

                                    <Pager PrevText="Anterior" NextText="Siguiente" PageSize="50" AllowPaging="True"

                                        StyleMode="ComboBox">

                                    </Pager>

                                    <HeaderStyleDefault BorderWidth="0px" BorderStyle="Solid" Height="25px" CssClass="TRHead"

                                        Font-Bold="True">

                                    </HeaderStyleDefault>

                                    <GroupByRowStyleDefault HorizontalAlign="Left">

                                    </GroupByRowStyleDefault>

                                    <FrameStyle Width="100%" Height="80px" Wrap="True">

                                    </FrameStyle>

                                    <GroupByBox Prompt="Arrastre aqu&#237; las columnas para crear grupos">

                                    </GroupByBox>

                                    <SelectedHeaderStyleDefault BackColor="#804040">

                                    </SelectedHeaderStyleDefault>

                                    <SelectedRowStyleDefault CssClass="TRRowSel">

                                    </SelectedRowStyleDefault>

                                    <RowAlternateStyleDefault CssClass="TRRowAlt">

                                    </RowAlternateStyleDefault>

                                    <RowStyleDefault Wrap="True" CssClass="TRRow">

                                    </RowStyleDefault>

                                    <Images ImageDirectory="../imagenes/WebGrid3/">

                                    </Images>

                                    <ActivationObject BorderColor="" BorderWidth="">

                                    </ActivationObject>

                                </DisplayLayout>

                                <Bands>

                                    <igtbl:UltraGridBand>

                                        <Columns>

                                            <igtbl:UltraGridColumn Key="id_unidad" Width="70px" CellButtonDisplay="Always" BaseColumnName="id_unidad"

                                                AllowResize="Fixed">

                                                <Header Caption="Unidad">

                                                </Header>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_remolque1" Width="75px" BaseColumnName="id_remolque1">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Remolque 1">

                                                    <RowLayoutColumnInfo OriginX="1" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="1" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="nombre_status_viaje" Width="120px" BaseColumnName="nombre_status_viaje">

                                                <Header Caption="Status Viaje">

                                                    <RowLayoutColumnInfo OriginX="2" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="2" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="no_viaje" Width="75px" BaseColumnName="no_viaje">

                                                <CellStyle Font-Bold="True" HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="No. Viaje">

                                                    <RowLayoutColumnInfo OriginX="3" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="3" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="MensajesNuevos" Width="25px" BaseColumnName="MensajesNuevos">

                                                <CellStyle VerticalAlign="Top" Font-Bold="True" HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="M">

                                                    <RowLayoutColumnInfo OriginX="4" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="4" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="AlarmasNuevas" Width="25px" Format=" " BaseColumnName="AlarmasNuevas">

                                                <CellStyle VerticalAlign="Top" Font-Bold="True" HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="A">

                                                    <RowLayoutColumnInfo OriginX="5" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="5" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="Pend" Width="35px" Format="" BaseColumnName="Pend">

                                                <CellStyle Font-Bold="True" HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="VP">

                                                    <RowLayoutColumnInfo OriginX="6" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="6" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="viajeactual" Width="15px" Hidden="True" BaseColumnName="viajeactual">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Desp">

                                                    <RowLayoutColumnInfo OriginX="7" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="7" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="f_ini_status" Width="120px" BaseColumnName="f_ini_status">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="F. Status">

                                                    <RowLayoutColumnInfo OriginX="8" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="8" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="desp_status_nombre" Width="90px" Hidden="True" BaseColumnName="desp_status_nombre">

                                                <Header Caption="Status Unidad">

                                                    <RowLayoutColumnInfo OriginX="9" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="9" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="num_asignacion" Width="90px" BaseColumnName="num_asignacion">

                                                <CellStyle Font-Bold="True" HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Num. Asignaci&#243;n">

                                                    <RowLayoutColumnInfo OriginX="10" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="10" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="tiempos" Width="25px" BaseColumnName="tiempos">

                                                <CellStyle Font-Bold="True">

                                                </CellStyle>

                                                <Header Caption="Mod.">

                                                    <RowLayoutColumnInfo OriginX="11" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="11" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="siguiente" Width="25px" BaseColumnName="siguiente">

                                                <CellStyle Cursor="Hand">

                                                </CellStyle>

                                                <Header Caption="Sig.">

                                                    <RowLayoutColumnInfo OriginX="12" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="12" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="Remitente" Width="225px" BaseColumnName="Remitente">

                                                <Header Caption="Remitente">

                                                    <RowLayoutColumnInfo OriginX="13" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="13" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="Destinatario" Width="225px" BaseColumnName="Destinatario">

                                                <Header Caption="Destinatario">

                                                    <RowLayoutColumnInfo OriginX="14" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="14" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="mostrar_operador2" Width="25px" AllowGroupBy="No" CellButtonDisplay="Always"

                                                BaseColumnName="mostrar_operador2" AllowResize="Fixed">

                                                <Header>

                                                    <RowLayoutColumnInfo OriginX="15" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="15" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="operadorunidad" Width="200px" BaseColumnName="operadorunidad">

                                                <Header Caption="Operador">

                                                    <RowLayoutColumnInfo OriginX="16" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="16" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="tipo_serv" Width="45px" BaseColumnName="tipo_serv">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Tipo Serv.">

                                                    <RowLayoutColumnInfo OriginX="17" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="17" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_linearem1" Width="75px" BaseColumnName="id_linearem1">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="L&#237;nea Rem. 1">

                                                    <RowLayoutColumnInfo OriginX="18" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="18" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_dolly" Width="75px" BaseColumnName="id_dolly">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Dolly">

                                                    <RowLayoutColumnInfo OriginX="19" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="19" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_linearem2" Width="75px" BaseColumnName="id_linearem2">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="L&#237;nea Rem. 2">

                                                    <RowLayoutColumnInfo OriginX="20" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="20" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_remolque2" Width="75px" BaseColumnName="id_remolque2">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Remolque 2">

                                                    <RowLayoutColumnInfo OriginX="21" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="21" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="plaza_origen" Width="170px" BaseColumnName="plaza_origen">

                                                <Header Caption="Origen">

                                                    <RowLayoutColumnInfo OriginX="22" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="22" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="plaza_destino" Width="170px" BaseColumnName="plaza_destino">

                                                <Header Caption="Destino">

                                                    <RowLayoutColumnInfo OriginX="23" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="23" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="posicion" Width="220px" BaseColumnName="posicion">

                                                <Header Caption="Posici&#243;n">

                                                    <RowLayoutColumnInfo OriginX="24" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="24" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="posdate" Width="100px" BaseColumnName="posdate">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="F. Posici&#243;n">

                                                    <RowLayoutColumnInfo OriginX="25" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="25" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="f_prog_ini_viaje" Width="100px" BaseColumnName="f_prog_ini_viaje">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="F. Ini. Prog.">

                                                    <RowLayoutColumnInfo OriginX="26" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="26" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="fecha_real_viaje" Width="100px" BaseColumnName="fecha_real_viaje">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="F. Ini. Real">

                                                    <RowLayoutColumnInfo OriginX="27" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="27" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="f_prog_fin_viaje" Width="100px" BaseColumnName="f_prog_fin_viaje">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="F. Fin Prog.">

                                                    <RowLayoutColumnInfo OriginX="28" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="28" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="observacionesviaje" Width="200px" BaseColumnName="observacionesviaje">

                                                <Header Caption="Obs. Viaje">

                                                    <RowLayoutColumnInfo OriginX="29" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="29" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_area" Hidden="True" BaseColumnName="id_area">

                                                <Header Caption="id_area">

                                                    <RowLayoutColumnInfo OriginX="30" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="30" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="UltimoDestino" Width="170px" BaseColumnName="UltimoDestino">

                                                <Header Caption="&#218;ltimo Destino">

                                                    <RowLayoutColumnInfo OriginX="31" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="31" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="zonanombre" BaseColumnName="zonanombre">

                                                <Header Caption="Zona">

                                                    <RowLayoutColumnInfo OriginX="32" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="32" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="operadorviaje" Hidden="True" BaseColumnName="operadorviaje">

                                                <Header Caption="operadorviaje">

                                                    <RowLayoutColumnInfo OriginX="33" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="33" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="fecha_servicio_sig" Width="60px" BaseColumnName="fecha_servicio_sig">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Dias p/ Mtto.">

                                                    <RowLayoutColumnInfo OriginX="34" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="34" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="fecha_disponible" BaseColumnName="fecha_disponible">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Fecha Disponible">

                                                    <RowLayoutColumnInfo OriginX="35" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="35" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="fecha_sale_vac" Width="80px" BaseColumnName="fecha_sale_vac">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Dias Vacaciones">

                                                    <RowLayoutColumnInfo OriginX="36" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="36" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="no_circula" Width="60px" BaseColumnName="no_circula">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="D&#237;a No Circula">

                                                    <RowLayoutColumnInfo OriginX="37" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="37" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="placas" Width="60px" BaseColumnName="placas">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Placas Unidad">

                                                    <RowLayoutColumnInfo OriginX="38" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="38" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="fecha_venclicencia" Width="60px" BaseColumnName="fecha_venclicencia">

                                                <CellStyle HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Vence Licencia">

                                                    <RowLayoutColumnInfo OriginX="39" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="39" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="tipo_licencia" BaseColumnName="tipo_licencia">

                                                <Header Caption="Tipo Licencia">

                                                    <RowLayoutColumnInfo OriginX="40" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="40" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="operadorunidad2" Width="200px" BaseColumnName="operadorunidad2">

                                                <Header Caption="Operador 2">

                                                    <RowLayoutColumnInfo OriginX="41" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="41" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="no_guia" Hidden="True" BaseColumnName="no_guia">

                                                <Header Caption="no_guia">

                                                    <RowLayoutColumnInfo OriginX="42" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="42" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="num_guia" BaseColumnName="num_guia">

                                                <CellStyle Font-Bold="True" HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Num. Gu&#237;a">

                                                    <RowLayoutColumnInfo OriginX="43" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="43" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="mostrar_guias" Width="25px" AllowGroupBy="No" CellButtonDisplay="Always"

                                                AllowResize="Fixed">

                                                <Header>

                                                    <RowLayoutColumnInfo OriginX="44" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="44" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="CantGuias" Hidden="True" AllowGroupBy="No" CellButtonDisplay="Always"

                                                BaseColumnName="CantGuias" AllowResize="Fixed">

                                                <Header Caption="">

                                                    <RowLayoutColumnInfo OriginX="45" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="45" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_pedido" BaseColumnName="id_pedido">

                                                <CellStyle Font-Bold="True" HorizontalAlign="Center">

                                                </CellStyle>

                                                <Header Caption="Pedido">

                                                    <RowLayoutColumnInfo OriginX="46" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="46" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="mostrar_pedidos" Width="25px" AllowGroupBy="No" CellButtonDisplay="Always"

                                                AllowResize="Fixed">

                                                <Header>

                                                    <RowLayoutColumnInfo OriginX="47" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="47" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="CantPedidos" Hidden="True" AllowGroupBy="No" CellButtonDisplay="Always"

                                                BaseColumnName="CantPedidos" AllowResize="Fixed">

                                                <Header Caption="">

                                                    <RowLayoutColumnInfo OriginX="48" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="48" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_responsable" Hidden="True" BaseColumnName="id_responsable">

                                                <Header Caption="id_responsable">

                                                    <RowLayoutColumnInfo OriginX="49" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="49" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="tipo_operacion" Width="120px" BaseColumnName="tipo_operacion">

                                                <Header Caption="Tipo Operaci&#243;n">

                                                    <RowLayoutColumnInfo OriginX="50" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="50" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_asignacion" Hidden="True" BaseColumnName="id_asignacion">

                                                <Header Caption="id_asignacion">

                                                    <RowLayoutColumnInfo OriginX="51" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="51" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="status_asignacion" Hidden="True" BaseColumnName="status_asignacion">

                                                <Header Caption="status_asignacion">

                                                    <RowLayoutColumnInfo OriginX="52" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="52" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_personal" Hidden="True" BaseColumnName="id_personal">

                                                <Header Caption="No. Personal Viaje">

                                                    <RowLayoutColumnInfo OriginX="53" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="53" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="op_unidad" Hidden="True" BaseColumnName="op_unidad">

                                                <Header Caption="Op. Unidad">

                                                    <RowLayoutColumnInfo OriginX="54" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="54" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="duracion_aviso" Hidden="True" BaseColumnName="duracion_aviso">

                                                <Header Caption="duracion_aviso">

                                                    <RowLayoutColumnInfo OriginX="55" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="55" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="duracion_maxima" Hidden="True" BaseColumnName="duracion_maxima">

                                                <Header Caption="duracion_maxima">

                                                    <RowLayoutColumnInfo OriginX="56" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="56" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="color" Hidden="True" BaseColumnName="color">

                                                <Header Caption="color">

                                                    <RowLayoutColumnInfo OriginX="57" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="57" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="color_aviso" Hidden="True" BaseColumnName="color_aviso">

                                                <Header Caption="color_aviso">

                                                    <RowLayoutColumnInfo OriginX="58" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="58" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="color_maxima" Hidden="True" BaseColumnName="color_maxima">

                                                <Header Caption="color_maxima">

                                                    <RowLayoutColumnInfo OriginX="59" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="59" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="id_statusviaje" Hidden="True" BaseColumnName="id_statusviaje">

                                                <Header Caption="id_statusviaje">

                                                    <RowLayoutColumnInfo OriginX="60" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="60" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                            <igtbl:UltraGridColumn Key="f_status_unidad" Hidden="True" BaseColumnName="f_status_unidad">

                                                <Header Caption="f_status_unidad">

                                                    <RowLayoutColumnInfo OriginX="61" />

                                                </Header>

                                                <Footer>

                                                    <RowLayoutColumnInfo OriginX="61" />

                                                </Footer>

                                            </igtbl:UltraGridColumn>

                                        </Columns>

                                        <AddNewRow View="NotSet" Visible="NotSet">

                                        </AddNewRow>

                                    </igtbl:UltraGridBand>

                                </Bands>

                            </igtbl:UltraWebGrid></td>

                    </tr>

                </table>

            </div>

            <div style="display: none">

                <asp:TextBox ID="txtRespValOrigCont" runat="server">0</asp:TextBox>

                <asp:TextBox ID="txtUnidadOriginal" runat="server" CssClass="ID" BackColor="Transparent"

                    Height="20px"></asp:TextBox>

                <asp:TextBox ID="txtLineaRem1Original" runat="server" CssClass="ID" BackColor="Transparent"

                    Height="20px"></asp:TextBox>

                <asp:TextBox ID="txtRemolque1Original" runat="server" CssClass="ID" BackColor="Transparent"

                    Height="20px"></asp:TextBox>

                <asp:TextBox ID="txtLineaRem2Original" runat="server" CssClass="ID" BackColor="Transparent"

                    Height="20px"></asp:TextBox>

                <asp:TextBox ID="txtRemolque2Original" runat="server" CssClass="ID" BackColor="Transparent"

                    Height="20px"></asp:TextBox>

                <asp:TextBox ID="txt_hdAsignacion" runat="server"></asp:TextBox>

                <asp:TextBox ID="txtAsignacion2" runat="server"></asp:TextBox>

                <asp:TextBox ID="txtFechaDefault" runat="server" Width="8px"></asp:TextBox>

                <asp:TextBox ID="RequestArea" runat="server"></asp:TextBox>

                <asp:TextBox ID="RequestViaje" runat="server"></asp:TextBox>

                <asp:TextBox ID="txtIdGrid" runat="server" Width="10px"></asp:TextBox>

                <asp:TextBox ID="txtListaPedidosAreas" runat="server" CssClass="ID"></asp:TextBox>

                <asp:TextBox ID="txtListaPedidos" runat="server" CssClass="ID"></asp:TextBox>

                <asp:TextBox ID="txtActualiza" runat="server" CssClass="ID" Width="0px"></asp:TextBox>

                <asp:TextBox ID="hfDINET" runat="server" Text="0"></asp:TextBox>

                <asp:TextBox id="idFlota" name="idflota" runat="server" />

                <input type="hidden" runat="server" id="FianzaRetornada" name="FianzaRetornada"  />

            </div>

        </div>

    </form>

             <script language="javascript" src='<%= String.Concat(Application("myRoot")) %>/js/validaciones.js'

        type="text/javascript"></script>

  <script language="javascript" src='<%= String.Concat(Application("myRoot")) %>/pridesp01/pre_i_despasignarpedidosajaxvalidaciones.js'

        type="text/javascript"></script>



        <script type="text/javascript">

            window.onload = function () {



            var raspon = document.getElementById("lblOutputOp").innerHTML;


                var response = raspon;

                var pieces = response.split(",");

                var blocks = parseInt(pieces[0]);

                var restDays = pieces[1];

                var namae = pieces[2];

                var id_operador = pieces[3];

                var folio = pieces[4];

                var vence = pieces[5];



              	if(blocks == 0) {

                  alert("Licencia expirada desde " + restDays + " dias");

                  document.getElementById("btnGuarda").disabled = true;

                  // lblError.innerText = "";

                  lblErrorAjax.innerText = "Licencia del operador "+ namae +" expirada desde " + restDays + " dias";

              	} else if (blocks == 1) {

                  alert("Licencia Vence en " + restDays + " dias");

                  document.getElementById("btnGuarda").disabled = true;

                  // lblError.innerText = "";

                  lblErrorAjax.innerText = "La Licencia del Operador tiene menos de 10 dias para vencer";

                } else if (blocks == 2) {

                  alert("Licencia sin Actualizar");

                  document.getElementById("btnGuarda").disabled = true;

                  // lblError.innerText = "";

                  lblErrorAjax.innerText = "La Licencia del Operador necesita Actualizarse";

                } else if (blocks == 3) { // Entre 10 y 30 dias

                  alert("Licencia Vence en " + restDays + " dias");

                  // if button is disabled just enable

                  if (document.getElementById("btnGuarda").disabled == true) {

                    document.getElementById("btnGuarda").disabled = false;

                  }

                  document.getElementById('txtOperador1Nombre').length=0;

                  document.getElementById('txtOperador1Nombre').value=namae;

                  // lblError.innerText = "";

                  lblErrorAjax.innerText = "La Licencia del Operador Vence en " + restDays + " dias";

                } else if (blocks == 4) {

                  alert("El Operador esta dado de Baja");

                  document.getElementById("btnGuarda").disabled = true;

                  // lblError.innerText = "";

                  lblErrorAjax.innerText = "El Operador " + namae + " esta dado de baja";

              	} else { // mayor a un mes

                  // if button is disabled just enable

                  if (document.getElementById("btnGuarda").disabled == true) {

                    document.getElementById("btnGuarda").disabled = false;

                  }

                  // Clear current data

              		document.getElementById('txtOperador1Nombre').length=0;

                  // set the new value

                  document.getElementById('txtOperador1Nombre').value=namae;

                  lblErrorAjax.innerText = ""

              	}

                
            }

        </script>

</body>

</html>

