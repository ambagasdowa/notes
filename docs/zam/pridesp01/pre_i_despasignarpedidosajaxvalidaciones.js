//Nombre    : pre_i_despasignarpedidosajaxvalidaciones.js
//Objetivo  : Funcionalidad
var astrcontrol;

function modifunidad() {
    if (document.form1.txtUnidad.value == '') {
        document.form1.imgTracto.src = '../Imagenes/spacer.GIF';
    }else{
        document.form1.imgTracto.src = '../Imagenes/tractor.JPG';
    }
}

function modifrem1() {
    if (document.form1.txtRemolque1.value == '') {
        document.form1.imgRemolque1.src = '../Imagenes/spacer.GIF';
    }else{
        document.form1.imgRemolque1.src = '../Imagenes/remolque.JPG';
    }
}

function modifdolly() {
    if (document.form1.txtDolly.value == '') {
        document.form1.imgDolly.src = '../Imagenes/spacer.GIF';
    }else{
        document.form1.imgDolly.src = '../Imagenes/dolly.JPG';
    }
}

function modifrem2() {
    if (document.form1.txtRemolque2.value == '') {
        document.form1.imgRemolque2.src = '../Imagenes/spacer.GIF';
    }else{
        document.form1.imgRemolque2.src = '../Imagenes/remolque.JPG';
    }
}

function BuscaTractor() {
    var strURL; var winUnidad;
    var ParCC = document.getElementById('txtHdnParCapCarga').value;
    strURL = '../busqueda_estandar.aspx?Search=/srv_i_busquedas/ctrlsearch_unidadesdisp.ascx&field=form1.txtUnidad&Opc=ASIGN&CapCarga=' + ParCC;
    winUnidad = window.open(strURL, 'Busqueda', 'width=640,height=480,status=no,scrollbars=no');
    winUnidad.ventanaReferencia = window;
    winUnidad.Referencia = document.form1.txtUnidad;
}

function BuscaLinea(as_campo) {
    var strURL; var winBuscLinea;
    strURL = '../busqueda_estandar.aspx?Search=/srv_i_busquedas/ctrlsearch_lineas.ascx&Campo=' + as_campo;
    winBuscLinea = window.open(strURL, 'Busqueda', 'width=640,height=480,top=150,left=150,status=no,scrollbars=yes');
    winBuscLinea.focus();
}

function EditarFianza(as_linea,as_remolque,num_rem,bolabrefianza) {
    var strURL; var winFianza; var arrControl = new Array()
    var astrpedido = ''; var arrNacionalidad = new Array()
    //Obtengo la nacionalidad del Remolque cuando no tiene Linea para saber si es propio Americano.
    //Jdlcruz, GASA 29-Nov-2012, Folio: 17748
    if (as_linea == '') {
        arrNacionalidad = pridesp01_pre_i_despasignarpedidos.GetNacionalidadRemolque(as_remolque);

        if (arrNacionalidad.error != null) {
            alert("Error:" + arrNacionalidad.error);
            return;
        }

        if (arrNacionalidad.value[0] == 'Error') {
            document.getElementById('lblErrorAjax').innerHTML = arrNacionalidad.value[1];
            return arrControl;
        }
    }
    else {
        arrNacionalidad[0] = 0
    }

    //si es remolque americano valida la fianza
    if (as_linea != '' || arrNacionalidad.value[0] == 2) {
        var astrasigna = document.getElementById('txt_hdAsignacion').value
        if (astrasigna == '') {
            astrasigna = '0'
            var rowIndex; var oRow;
            rowIndex = window.opener.igtbl_getGridById('uwgPedidos').ActiveRow
            oRow = window.opener.igtbl_getRowById(rowIndex)
            if (oRow != null) {
               astrpedido = '' + oRow.getCellFromKey("id_pedido").getValue();
            }
         }
         arrControl = pridesp01_pre_i_despasignarpedidos.GetControlRemolque(as_linea, as_remolque, astrasigna, astrpedido);
        if (arrControl.error != null) {
            alert("Error:" + arrControl.error);
            return;
        }
        var aidcontrol = ''
        aidcontrol = '' + arrControl.value[0]
        astrcontrol = aidcontrol;
        if (arrControl.error != null) { return; }
        if (arrControl.value[0] != 'Error') {
            if (bolabrefianza == true) {
                strURL = 'pre_i_despfianza.aspx?NumRem=' + num_rem + '&Control=' + aidcontrol;
                winFianza = window.open(strURL, 'FianzaControl', 'width=500,height=320,status=no,scrollbars=no,left=100,top=100');
                winFianza.focus();
            }
        }
        else {
            document.getElementById('lblErrorAjax').innerHTML = arrControl.value[1];
            return arrControl;
        }
    }
    else {
        return arrControl;
    }
    return arrControl;
}

function BuscaOperador(as_campo, as_descr) {
    var strURL; var winOperador;
    strURL = '../busqueda_estandar.aspx?Search=/srv_i_busquedas/ctrlsearch_personalxtipo.ascx&Campo=' + as_campo + '&Descr=' + as_descr + '&TipoE=O';
     winOperador = window.open(strURL, 'BuscaOperador', 'width=640,height=480,top=150,left=150,status=no,scrollbars=no');
    // winOperador = window.showModalDialog(strURL, 'BuscaOperador', 'dialogWidth=640px,dialogHeight=480px,dialogTop=150px,dialogLeft=150px,status=no,scroll=no,resizable=on');
     winOperador.focus();

//    alert(winOperador);

//     for(var propt in winOperador) {
// //      alert(propt);
//       alert( propt + ' => ' +  winOperador[propt]);//logs "Sim
// 
//       if (propt == 'opener' || propt == 'event' || propt == 'document') {
// 
//         var tra = winOperador[propt];
//         for ( var ext in  tra ) {
//             alert(propt + ' => ' +  ext + ' => ' + tra[ext]);
//         }
// 
//       } // propt and event 
// 
//      if (propt == 'document') {
//         var tra = winOperador[propt];
//         for ( var ext in  tra ) {
//             alert(propt + ' => ' +  ext + ' => ' + tra[ext]);     
//         }
//      }
// 
//     }

}

function BuscaRuta(as_campo, as_desc) {
    var strURL; var winRuta;
    strURL = '../busqueda_estandar.aspx?Search=/srv_i_busquedas/ctrlsearch_rutas.ascx&Campo=' + as_campo + '&Desc=' + as_desc;
    winRuta = window.open(strURL, 'Ruta', 'width=640,height=480,top=150,left=150,status=no,scrollbars=no');
    winRuta.focus();
}


function BuscaRemolque(as_rem, as_linea) {
    var strURL; var winBuscRem;
    var ParCC = document.getElementById('txtHdnParCapCarga').value;
    strURL = '../busqueda_estandar.aspx?Search=/srv_i_busquedas/ctrlsearch_remolques.ascx&Rem=' + as_rem + '&Linea=' + as_linea + '&Opc=ASIGN&CapCarga=' + ParCC;
    winBuscRem = window.open(strURL, 'BuscaRem', 'width=640,height=510,status=no,scrollbars=yes');
    winBuscRem.focus();
}

function BuscaDolly(as_campo) {
    var strURL; var winDolly;
    var ParCC = document.getElementById('txtHdnParCapCarga').value;
    strURL = '../busqueda_estandar.aspx?Search=/srv_i_busquedas/ctrlsearch_unidades.ascx&Campo=' + as_campo + '&Tipo=D&Opc=ASIGN&CapCarga=' + ParCC;
    winDolly = window.open(strURL, 'BuscaDolly', 'width=640,height=480,top=150,left=150,status=0,scrollbars=0');
    winDolly.focus();
}

function BuscaKit() {
    var strURL; var winKit;
    strURL = '../busquedas/busqueda_kitunidad.aspx';
    winKit = window.open(strURL, 'BuscaKit', 'width=640,height=480,top=150,left=150,status=0,scrollbars=0');
    winKit.focus();
}

function wibSalir_Click(oButton, oEvent) {
    window.close();
}

//Valida Kit
function ValidaKit(strKit) {
    if (strKit == '') {
        document.getElementById("txtKit").value = '';
    }else{
        pridesp01_pre_i_despasignarpedidos.ValidaKit(strKit, Kit_CallBack);
    }
}

function Kit_CallBack(response) {
    if (response.error != null) { return; }
    if (response.value[0] == 'Error') {
        document.getElementById("txtRemolque1").value = ""
        document.getElementById("txtDolly").value = ""
        document.getElementById("txtRemolque2").value = ""
        document.getElementById("txtKit").value = ""
        document.getElementById("txtUnidad").value = ""
        document.getElementById("txtKit").focus();
        lblErrorAjax.innerText = response.value[1]
    }else {
        document.getElementById("txtRemolque1").value = response.value[0]
        document.getElementById("txtDolly").value = response.value[1]
        document.getElementById("txtRemolque2").value = response.value[2]
        document.getElementById("txtUnidad").value = response.value[3]
        lblErrorAj.ax.innerText = ""
    }
    modifrem1()
    modifrem2()
    modifunidad()
}

//Valida Ruta
function ValidaRuta(intRuta, strUnidad, dFecha) {
    if (intRuta == '') {
        document.getElementById("txtRuta").value = '';
    }else {
        dFecha = FormatoFecha(dFecha, document.getElementById('txtFechaDefault').value)
        pridesp01_pre_i_despasignarpedidos.ValidaRuta(intRuta, strUnidad, dFecha, Ruta_CallBack);
    }
}

function Ruta_CallBack(response) {
    if (response.error != null) { return; }
    if (response.value[0] == 'Error') {
        document.getElementById("txtRuta").focus();
        document.getElementById("txtRuta").value = ""
        document.getElementById("txtRutaDesc").value = ""
        lblErrorAjax.innerText = response.value[1]
    }else {
        document.getElementById("txtRutaDesc").value = response.value[0]
        lblErrorAjax.innerText = ""
    }
}

//Valida Operador
function ValidaOperador(intOperador, NoOperador) {
    if (intOperador == '') {
        switch (NoOperador) {
            case 1:
                document.getElementById("txtOperador1Nombre").value = ""
                break;
            case 2:
                document.getElementById("txtOperador2Nombre").value = ""
                break;
            default:
        }
    }else{
        pridesp01_pre_i_despasignarpedidos.ValidaOperador(intOperador, NoOperador, Operador_CallBack);
    }
}

function Operador_CallBack(response) {
    if (response.error != null) { return; }
    if (response.value[0] == 'Error') {
        switch (response.value[2]) {
            case 1:
                document.getElementById("txtOperador1").focus();
                document.getElementById("txtOperador1").value = '';
                document.getElementById("txtOperador1Nombre").value = ""
                break;
            case 2:
                document.getElementById("txtOperador2").value = '';
                document.getElementById("txtOperador2Nombre").value = ""
                document.getElementById("txtOperador2").focus();
                break;
            default:
        }
    lblErrorAjax.innerText = response.value[1]
    }else {
        switch (response.value[0]) {
            case 1:
                document.getElementById("txtOperador1Nombre").value = response.value[1]
                break;
            case 2:
                document.getElementById("txtOperador2Nombre").value = response.value[1]
                break;
            default:
        }
        lblErrorAjax.innerText = ""
    }
}

//Valida Seguimiento
function ValidaSeguimiento(strSeguimiento) {
    if (strSeguimiento == '') {
        document.getElementById("txtSeguimiento").value = '';
        document.getElementById("txtSeguimientoDesc").value = '';
    }else{
        pridesp01_pre_i_despasignarpedidos.ValidaSeguimiento(strSeguimiento, Seguimiento_CallBack);
    }
}

function Seguimiento_CallBack(response) {
    if (response.error != null) { return; }
    if (response.value[0] == 'Error') {
        document.getElementById("txtSeguimiento").value = ""
        document.getElementById("txtSeguimiento").focus();
        document.getElementById("txtSeguimientoDesc").value = ""
        lblErrorAjax.innerText = response.value[1]
    }else{
        document.getElementById("txtSeguimientoDesc").value = response.value[0]
        lblErrorAjax.innerText = ""
    }
}

//Valida Hora
function ValidaHora(strHora, strHraInicio) {
    if (strHora == '') {
        strHora = '0'
    }else {
        strHraInicio = FormatoFecha(strHraInicio, document.getElementById('txtFechaDefault').value)
        pridesp01_pre_i_despasignarpedidos.ValidaHora(strHora, strHraInicio, Hora_CallBack);
    }
}

function Hora_CallBack(response) {
    if (response.error != null) { return; }
    if (response.value[0] == 'Error') {
        lblErrorAjax.innerText = response.value[1]
    }else{
        igedit_getById('wdcFinViaje').setText(response.value[0]);
        lblErrorAjax.innerText = ""
    }
}

//Valida Fechas
function ValidaFechas(strHoraIni, strHoraFin) {
    strHoraIni = FormatoFecha(strHoraIni, document.getElementById('txtFechaDefault').value)
    strHoraFin = FormatoFecha(strHoraFin, document.getElementById('txtFechaDefault').value)
    pridesp01_pre_i_despasignarpedidos.ValidaFechas(strHoraIni, strHoraFin, Fecha_CallBack);
}

function FormatoFecha(fecha, format) {
    if (document.getElementById('txtFechaDefault').value == '') {
        alert("Es posible que experimente problemas con los campos de las fechas, favor de configurar correctamente en el archivo de configuración el strDateIISTimeFormat y strDateIISFormat indicando el formato de fecha de tu servicio de IIS")
    }
    var strSubArray;
    strSubArray = fecha.split("/")
    switch (format) {
        case 'dd/MM/yyyy HH:mm':
            fecha = strSubArray[0] + "/" + strSubArray[1] + "/" + strSubArray[2]
            break;
        case 'MM/dd/yyyy HH:mm':
            fecha = strSubArray[1] + "/" + strSubArray[0] + "/" + strSubArray[2]
            break;
        default:
    }
    return fecha;
}

function Fecha_CallBack(response) {
    if (response.error != null) { return; }
    if (response.value[0] == 'Error') {
        lblErrorAjax.innerText = response.value[1]
    }else {
        document.getElementById('txtHrsEstandar').value = response.value[0]
        lblErrorAjax.innerText = ""
    }
}

function ValidaUnidad(unidad) {
    try {
        if (unidad == '') {
            if (document.getElementById("txtUnidad") != null) {
                document.getElementById("txtUnidad").value = '';
                if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                    document.getElementById('txtIdTipoUTracto').value = 0;
                    document.getElementById('txtTipoUTracto').value = '';
                }
                modifunidad()
                if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                    ObtieneCapacidadCarga();
                }
            }
        }else {
            var aint_id_asigna = document.getElementById("txt_hdAsignacion").value;
            var astrListaP = document.getElementById("txtListaPedidos").value;
            var astrListaPA = document.getElementById("txtListaPedidosAreas").value;
            if (aint_id_asigna == '') { aint_id_asigna = '0'; }
            pridesp01_pre_i_despasignarpedidos.ValidaUnidad(unidad, aint_id_asigna, astrListaP, astrListaPA, Unidad_CallBack);
            setFocus('txtRemolque1');
            modifunidad();
        }
    } catch (e) {
        alert("Error Ajax:" + e.message);
    }
}

function Unidad_CallBack(response) {
    try {
        if (response.error != null) {
            alert("Error Ajax:" + response.error); return;
        }
        if (response.value[0] == 'Error') {
            if (document.getElementById("txtUnidad") != null) {
                document.getElementById("txtUnidad").focus();
                document.getElementById("txtUnidad").value = '';
                if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                    document.getElementById('txtIdTipoUTracto').value = 0;
                    document.getElementById('txtTipoUTracto').value = '';
                    //ObtieneCapacidadCarga();
                }
                lblErrorAjax.innerText = response.value[1]
            }
        } else {
            if (response.value[0] == "Advertencia") {
                lblErrorAjax.innerText = response.value[0]
            } else {
                lblErrorAjax.innerText = ""
            }
            if (response.value[0] == "InfoTipoUnidad") {
                document.getElementById('txtIdTipoUTracto').value = response.value[1]
                document.getElementById('txtTipoUTracto').value = response.value[2]
                ObtieneCapacidadCarga();
            } else {
                lblErrorAjax.innerText = ""
            }
        }
    } catch (e) {
        alert("Error Ajax:" + e.message);
    }
}

function ObtieneCapacidadCarga() {
    try {
        var array = new Array();
        if (document.getElementById('lblError') != null) {
            document.getElementById('lblError').innerHTML = '';
        }
        if (document.getElementById('hfDINET').value != "1") {
            return;
        }
        var TUT = document.getElementById('txtIdTipoUTracto').value;
        var TUR1 = document.getElementById('txtIdTipoUR1').value;
        var TUD = document.getElementById('txtIdTipoUD').value;
        var TUR2 = document.getElementById('txtIdTipoUR2').value;
        array[0] = document.getElementById('txtUnidad').value;
        array[1] = document.getElementById('txtRemolque1').value;
        array[2] = document.getElementById('txtDolly').value;
        array[3] = document.getElementById('txtRemolque2').value;
        var PesoCargar = document.getElementById('txtCargaKG').value;
        var VolCargar = document.getElementById('txtCargarM3').value;
        pridesp01_pre_i_despasignarpedidos.ObtieneCapacidadCarga(TUT, TUR1, TUR2, TUD, PesoCargar, VolCargar, array, ObtieneCapacidadCarga_CallBack);
    } catch (e) {
        alert("Error Ajax:" + e.message);
    }
}

function ObtieneCapacidadCarga_CallBack(response) {
    try {
        if (response.error != null) {
            document.getElementById('lblConfigMTC').innerHTML = "Configuración MTC: ";
            alert("Error Ajax:" + response.error); return;
        }
        if (response.value[0] == 'Error') {
            lblErrorAjax.innerText = ""
            lblErrorAjax.innerText = "La Capacidad de Carga o de Volumen es menor a la Capacidad de Carga registrada en el Catálogo de Configuración de MTC o el Volumen configurado en el Tipo de Unidad."//response.value[1]
            var oGuardar = document.getElementById('DivGuardar');
            oGuardar.style.display = 'none';
            document.getElementById('txtCapacidadKG').value = response.value[1];
            document.getElementById('txtCapacidadM3').value = response.value[2];
            document.getElementById('txtIdTipoUTracto').value = response.value[4];
            document.getElementById('txtTipoUTracto').value = response.value[5];
            document.getElementById('txtIdTipoUR1').value = response.value[6];
            document.getElementById('txtTipoURem1').value = response.value[7];
            document.getElementById('txtIdTipoUR1').value = response.value[8];
            document.getElementById('txtTipoURem2').value = response.value[9];
            document.getElementById('txtIdTipoUD').value = response.value[10];
            document.getElementById('txtTipoUDolly').value = response.value[11];
            document.getElementById('lblConfigMTC').innerHTML = response.value[3];
        } else {
            lblErrorAjax.innerText = ""
            var oGuardar = document.getElementById('DivGuardar');
            oGuardar.style.display = 'block';
            if (response.value[0] == "InfoCapacidad") {
                document.getElementById('txtCapacidadKG').value = response.value[1];
                document.getElementById('txtCapacidadM3').value = response.value[2];
                document.getElementById('lblConfigMTC').innerHTML = response.value[3];
                document.getElementById('txtIdTipoUTracto').value = response.value[4];
                document.getElementById('txtTipoUTracto').value = response.value[5];
                document.getElementById('txtIdTipoUR1').value = response.value[6];
                document.getElementById('txtTipoURem1').value = response.value[7];
                document.getElementById('txtIdTipoUR1').value = response.value[8];
                document.getElementById('txtTipoURem2').value = response.value[9];
                document.getElementById('txtIdTipoUD').value = response.value[10];
                document.getElementById('txtTipoUDolly').value = response.value[11];
            }
        }
    } catch (e) {
        alert("Error Ajax:" + e.message);
    }
}

//Valida linea
function ValidaLineasyRemolques(strLinea, strRem, intRemNum) {
    try {
        var Arguments = new Array()
        if (strLinea == "" && strRem == "") {
            if (intRemNum == 1) {
                if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                    document.getElementById('txtIdTipoUR1').value = 0;
                    document.getElementById('txtTipoURem1').value = '';
                    ObtieneCapacidadCarga()
                }
            }
            if (intRemNum == 2) {
                if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                    document.getElementById('txtIdTipoUR2').value = 0;
                    document.getElementById('txtTipoURem2').value = '';
                    ObtieneCapacidadCarga()
                }
            }
            lblErrorAjax.innerText = ""
        }else {
            //txtLineaRem1
            if (document.getElementById('txtLineaRem1') == null || document.getElementById('txtLineaRem1') == 'undefined') {
                Arguments[0] = '';
            } else {
                Arguments[0] = document.getElementById('txtLineaRem1').value;
            }
            //txtRemolque1
            if (document.getElementById('txtRemolque1') == null || document.getElementById('txtRemolque1') == 'undefined') {
                Arguments[1] = '';
            } else {
                Arguments[1] = document.getElementById('txtRemolque1').value;
            }
            //txtDolly
            if (document.getElementById('txtDolly') == null || document.getElementById('txtDolly') == 'undefined') {
                Arguments[2] = '';
            } else {
                Arguments[2] = document.getElementById('txtDolly').value;
            }
            //txtRemolque2
            if (document.getElementById('txtRemolque2') == null || document.getElementById('txtRemolque2') == 'undefined') {
                Arguments[3] = '';
            } else {
                Arguments[3] = document.getElementById('txtRemolque2').value;
            }
            pridesp01_pre_i_despasignarpedidos.ValidaLineasyRemolques(strLinea, strRem, intRemNum, Arguments, ValidaLineasyRemolques_CallBack);
        }
    } catch (e) {
        alert("Error Ajax:" + e.message);
    }
}

function ValidaLineasyRemolques_CallBack(response) {
    if (response.error != null) { alert("Error Ajax:" + response.error); return; }
    if (response.value[0] == 'Error') {
        lblErrorAjax.innerText = response.value[1]
        if (response.value[2] == 1) {
            document.getElementById('txtFianza1').value = ''
            setFocus('txtRemolque1')
            if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                document.getElementById('txtIdTipoUR1').value = 0;
                document.getElementById('txtTipoURem1').value = '';
            }
            modifrem1()
            if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                //ObtieneCapacidadCarga()
            }
        } else {
            document.getElementById('txtFianza2').value = ''
            setFocus('txtRemolque2')
            if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                document.getElementById('txtIdTipoUR2').value = 0;
                document.getElementById('txtTipoURem2').value = '';
            }
            modifrem2()
            if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                //ObtieneCapacidadCarga()
            }
        }
    } else {
        lblErrorAjax.innerText = ""
        if (response.value[0] == 1) {
            if (response.value[1] == "InfoRem1") {
                document.getElementById('txtIdTipoUR1').value = response.value[2]
                document.getElementById('txtTipoURem1').value = response.value[3]
                document.getElementById('txtFianza1').value = response.value[4]
            }
            setFocus('txtDolly')
            modifrem1()
            if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                ObtieneCapacidadCarga();
            }
            document.getElementById('txtFianza1').value = response.value[4]
        } else {
            if (response.value[1] == "InfoRem2") {
                document.getElementById('txtIdTipoUR2').value = response.value[2]
                document.getElementById('txtTipoURem2').value = response.value[3]
                document.getElementById('txtFianza2').value   = response.value[4]
            }
            setFocus('txtOperador1')
            modifrem2()
            if (document.getElementById('txtHdnParCapCarga').value == 'S') {
                ObtieneCapacidadCarga();
            }
            document.getElementById('txtFianza2').value = response.value[4]
        }
    }
}

//Valida Dolly
function ValidaDolly(dolly) {
    if (dolly != '') {
        pridesp01_pre_i_despasignarpedidos.ValidaDolly(dolly, Dolly_CallBack);
    }
}

function Dolly_CallBack(response) {
    if (response.error != null) { alert("Error Ajax:" + response.error); return; }
    if (response.value[0] == 'Error') {
        document.getElementById('txtDolly').focus();
        document.getElementById('txtDolly').value = ""
        lblErrorAjax.innerText = response.value[1]
        if (document.getElementById('txtHdnParCapCarga').value == 'S') {
            document.getElementById('txtIdTipoUD').value = 0;
            document.getElementById('txtTipoUDolly').value = '';
        }
        setFocus('txtDolly')
        if (document.getElementById('txtHdnParCapCarga').value == 'S') {
            //ObtieneCapacidadCarga();
        }
    } else {
        if (response.value[0] == "InfoTipoUnidad") {
            document.getElementById('txtIdTipoUD').value = response.value[1]
            document.getElementById('txtTipoUDolly').value = response.value[2]

        } else {
            lblErrorAjax.innerText = ""
        }
        setFocus('txtRemolque2')
        if (document.getElementById('txtHdnParCapCarga').value == 'S') {
            ObtieneCapacidadCarga();
        }
    }
}

function setFocus(id) {
    try {
        var oCampo = document.getElementById(id);
        if (oCampo != null) {
            oCampo.focus();
        }
    } catch (e) {
        alert(e.message);
    }
}

function MuestraCargando(bolMuestra) {
    if (bolMuestra) {
        try {
            _backgroundElement.style.display = 'block';
            _backgroundElement.style.position = 'absolute';
            _backgroundElement.style.left = '0px';
            _backgroundElement.style.top = '0px';
            var clientBounds = this._getClientBounds(); //obtiene las medidas del navegador.
            var clientWidth = clientBounds.width;
            var clientHeight = clientBounds.height;
            _backgroundElement.style.width = Math.max(Math.max(document.documentElement.scrollWidth, document.body.scrollWidth), clientWidth) + 'px';
            _backgroundElement.style.height = Math.max(Math.max(document.documentElement.scrollHeight, document.body.scrollHeight), clientHeight) + 'px';
            var intCentro = Math.max(Math.max(document.documentElement.scrollHeight, document.body.scrollHeight), clientHeight) / 2
            _backgroundElement.style.zIndex = 10000;
            _backgroundElement.innerHTML = '<div  style="padding-top:' + intCentro + 'px;" align="center"><img src="../imagenes/loading.gif" /><div><h3>Por favor espere, cargando...</h3></div></div>';
            _backgroundElement.className = "Bground";
        } catch (e) {

        }
    }else {
        _backgroundElement.style.display = 'none';
    }
}

//OBTIENE LA INFORAMCIÓN DEL ALTO Y ANCHO DEL NAVEGADOR.
function _getClientBounds() {
    var clientWidth;
    var clientHeight;
    switch (Sys.Browser.agent) {
        case Sys.Browser.InternetExplorer:
            clientWidth = document.documentElement.clientWidth;
            clientHeight = document.documentElement.clientHeight;
            break;
        case Sys.Browser.Safari:
            clientWidth = window.innerWidth;
            clientHeight = window.innerHeight;
            break;
        case Sys.Browser.Opera:
            clientWidth = Math.min(window.innerWidth, document.body.clientWidth);
            clientHeight = Math.min(window.innerHeight, document.body.clientHeight);
            break;
        default:  // Sys.Browser.Firefox, etc.
            clientWidth = Math.min(window.innerWidth, document.documentElement.clientWidth);
            clientHeight = Math.min(window.innerHeight, document.documentElement.clientHeight);
            break;
    }
    return new Sys.UI.Bounds(0, 0, clientWidth, clientHeight);
}

//Guardar
function Guardar() {
    
    if (document.getElementById('txtHdnValidaArmado').value == 1 && (document.getElementById('txtRemolque1').value != '' && document.getElementById('txtRemolque2').value != '' && document.getElementById("txtDolly").value == '')) {
        lblErrorAjax.innerText = 'Debe capturar un Dolly, ya que se tienen 2 remolques'
        return;
    }
    document.getElementById("btnGuarda").disabled = true;
    MuestraCargando(true)
    var Array1 = new Array(); var rowIndex;
    var oRow; var intAsignacion; var grid;
    if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
        rowIndex = window.opener.igtbl_getGridById('uwgUnidades').ActiveRow
        oRow = window.opener.igtbl_getRowById(rowIndex)
        grid = window.opener.igtbl_getGridById('uwgPedidos');
        Array1[16] = document.getElementById("idFlota").value; //window.opener.document.form1.WebPanel1_txtFlota.value
    } else {
        rowIndex = window.opener.opener.igtbl_getGridById('uwgUnidades').ActiveRow
        oRow = window.opener.opener.igtbl_getRowById(rowIndex)
        grid = window.opener.opener.igtbl_getGridById('uwgPedidos');
        Array1[16] = document.getElementById("idFlota").value; //window.opener.opener.document.form1.WebPanel1_txtFlota.value
    }
    if (oRow != null) {
        intAsignacion = oRow.getCellFromKey("id_asignacion").getValue();
    } else {
        intAsignacion = '';
    }
    Array1[0] = document.getElementById("txt_hdAsignacion").value
    document.getElementById("txtActualiza").value = document.getElementById("txt_hdAsignacion").value
    if (document.getElementById('txtUnidad').value == '') {
        document.getElementById('txtUnidad').value = '0'
    }
    Array1[1] = document.getElementById('txtUnidad').value;

    //Recorre los pedidos seleccionados
    if (grid != null) {
        var strLista = ""; var strLista2 = ""; var strLista3 = ""; var aiAreaUsuario
        var strURL; var winAsignar; var lRow;
        for (lRow in grid.SelectedRows) {
            var oRow2; var value;
            if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
                oRow2 = window.opener.igtbl_getRowById(lRow);
                aiAreaUsuario = window.opener.document.form1.txtAreaUsuario.value;
            } else {
                oRow2 = window.opener.opener.igtbl_getRowById(lRow);
                aiAreaUsuario = window.opener.opener.document.form1.txtAreaUsuario.value;
            }
            value = oRow2.getCellFromKey("id_pedido").getValue();
            if (value != null) { strLista = strLista + value + "[;]"; }
            value = oRow2.getCellFromKey("id_area").getValue();
            if (value != null) { strLista2 = strLista2 + value + "[;]"; }
            value = oRow2.getCellFromKey("id_pedidopk").getValue();
            if (value != null) { strLista3 = strLista3 + value + "[;]"; }
            if (oRow2.getCellFromKey("id_statusseg").getValue() != null) {
                var aiStatusSeg = oRow2.getCellFromKey("id_statusseg").getValue();
                if (aiStatusSeg == 5 && oRow2.getCellFromKey("id_area").getValue() != aiAreaUsuario) {
                    alert("El pedido tiene status Transbordo y debe pertenecer a la misma área del usuario para asignarlo nuevamente.");
                    return;
                }
            }
        }
        if (oRow2 == undefined) {
            var oRow3; var value; var continuaSinPedidos = false;
            if (grid.getActiveCell() == undefined)
            { continuaSinPedidos = true; }
            if (continuaSinPedidos == false) {
                oRow3 = grid.getActiveCell().Row;
                value = oRow3.getCellFromKey("id_pedido").getValue();
                if (value != null) { strLista = strLista + value + "[;]"; }
                value = oRow3.getCellFromKey("id_area").getValue();
                if (value != null) { strLista2 = strLista2 + value + "[;]"; }
                value = oRow3.getCellFromKey("id_pedidopk").getValue();
                if (value != null) { strLista3 = strLista3 + value + "[;]"; }
                if ((strLista == "") || (strLista2 == "") || (strLista3 == "")) {
                    alert("Debe seleccionar uno o mas Pedidos.");
                    return;
                }
            }
        }
    }
    Array1[2] = strLista;
    Array1[3] = strLista2;
    Array1[4] = strLista3;
    if (document.getElementById("txtRuta").value == '') {
        document.getElementById("txtRuta").value = '0';
    }
    Array1[5] = document.getElementById("txtRuta").value
    Array1[6] = FormatoFecha(igedit_getById('wdcInicioViaje').getText(), document.getElementById('txtFechaDefault').value)
    Array1[7] = FormatoFecha(igedit_getById('wdcFinViaje').getText(), document.getElementById('txtFechaDefault').value)
    Array1[8] = document.getElementById("txtIngreso").value
    if (document.getElementById("txtHrsEstandar").value == '') {
        document.getElementById("txtHrsEstandar").value = '0'
    }
    Array1[9] = document.getElementById("txtHrsEstandar").value
    Array1[10] = document.getElementById("txtKit").value
    Array1[11] = document.getElementById("txtLineaRem1").value
    Array1[12] = document.getElementById("txtRemolque1").value
    Array1[13] = document.getElementById("txtDolly").value
    Array1[14] = document.getElementById("txtLineaRem2").value
    Array1[15] = document.getElementById("txtRemolque2").value
    Array1[17] = document.getElementById("ddlConfigViaje").value;
    Array1[18] = document.getElementById("txtOperador1").value
    Array1[19] = document.getElementById("txtOperador2").value
    Array1[20] = document.getElementById("txtObservaciones").value
    Array1[21] = document.getElementById("txtSeguimiento").value
    Array1[22] = document.getElementById("txtLineaRem1Original").value
    Array1[23] = document.getElementById("txtRemolque1Original").value
    Array1[24] = document.getElementById("txtLineaRem2Original").value
    Array1[25] = document.getElementById("txtRemolque2Original").value
    Array1[26] = document.getElementById("txtUnidadOriginal").value
    Array1[27] = document.getElementById("txtFechaDefault").value
    document.form1.txtAsignacion2.value = intAsignacion;
    // Asignación seleccionada del grid Unidades de Despacho
    Array1[28] = document.form1.txtAsignacion2.value;
    //Se agrega la informacion de la Capacidad de Carga KG y M3, emartinez 20/Jun/2012
    if (document.getElementById('txtHdnParCapCarga').value == 'S') {
        Array1[29] = document.getElementById("txtCargarM3").value
        Array1[30] = document.getElementById("txtCargaKG").value
    } else {
        Array1[29] = "0"
        Array1[30] = "0"
    }

    Array1[31] = document.getElementById("txtRemitente").value;
    Array1[32] = document.getElementById("txtDestinatario").value;

    Array1[33] = document.getElementById("lblRemDestHabil").value;
        // Si esta el cambio de fianzas en la asignacion de pedidos, valida
           if (document.getElementById('DivFianza1').style.visibility == 'visible') {
                var arrFianza = new Array()
                var arrNacionalidad = new Array()
                //valida la fianza de los remolques americanos
                if (Array1[11] != '') { //Si tiene capturada Linea 1
                    // valida que el remolque este activo, siempre y cuando sea impo
                    arrFianza = EditarFianza(Array1[11], Array1[12], '1', false)
                    if (arrFianza.value[0] == 'Error') {
                         MuestraCargando(false);
                         document.getElementById("btnGuarda").disabled = false;
                         return;
                    }
                    else{
                        //Valida que este capturada la fianza
                        //Se agrega la validacion del tipo de servicio 'E', Jdlcruz, GASA 29-Nov-2012, Folio: 17748.
                        if (arrFianza.value[1] == 'I' || arrFianza.value[1] == 'E') {
                           if (document.getElementById('txtFianza1').value == '') {
                                document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' no tiene una fianza capturada. Favor de capturarla'
                                MuestraCargando(false);
                                document.getElementById("btnGuarda").disabled = false;
                                return;
                            }
                            else {
                                if (FianzaNoRtornada(arrFianza.value[2]) == false) {
                                    document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' tiene una fianza retornada. Favor de cambiarla'
                                    MuestraCargando(false);
                                    document.getElementById("btnGuarda").disabled = false;
                                    return;
                                }
                            }
                        }
                        else {
                            if (FianzaNoRtornada(arrFianza.value[2]) == false) {
                                document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' tiene una fianza retornada. Favor de cambiarla'
                                MuestraCargando(false);
                                document.getElementById("btnGuarda").disabled = false;
                                return;
                            }
                        }
                    }
                }
                if (Array1[14] != '') { //Si tiene capturada Linea 2
                        arrFianza =  EditarFianza(Array1[14], Array1[15], '1', false)
                        if (arrFianza.value[0] == 'Error') {
                             MuestraCargando(false);
                             document.getElementById("btnGuarda").disabled = false;
                             return;
                        }
                        else {
                            //Se agrega la validacion del tipo de servicio 'E', Jdlcruz, GASA 29-Nov-2012, Folio: 17748.
                            if (arrFianza.value[1] == 'I' || arrFianza.value[1] == 'E') {
                                 if (document.getElementById('txtFianza2').value == '') {
                                    document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[15] + ' no tiene una fianza capturada. Favor de capturarla'
                                    MuestraCargando(false);
                                    document.getElementById("btnGuarda").disabled = false;
                                    return;
                                }
                                else {
                                    if (FianzaNoRtornada(arrFianza.value[2]) == false) {
                                        document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' tiene una fianza retornada. Favor de cambiarla'
                                        MuestraCargando(false);
                                        document.getElementById("btnGuarda").disabled = false;
                                        return;
                                    }
                                }
                            }
                            else {
                                if (FianzaNoRtornada(arrFianza.value[2]) == false) {
                                    document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' tiene una fianza retornada. Favor de cambiarla'
                                    MuestraCargando(false);
                                    document.getElementById("btnGuarda").disabled = false;
                                    return;
                                }
                            }
                        }
                }

                //Obtengo la nacionalidad para validar la fianza de los remolques propios americanos.
                //Jdlcruz, GASA 29-Nov-2012, Folio: 17748.
                if (Array1[11] == '' && Array1[12] != '') { //Si no tiene capturada la Linea 1 y pero si capturado el remolque 1
                    //Obtengo la nacionalidad del remolque.
                    arrNacionalidad = pridesp01_pre_i_despasignarpedidos.GetNacionalidadRemolque(Array1[12]);
                    if (arrNacionalidad.error != null) {
                        alert("Error:" + arrNacionalidad.error);
                        return;
                    }
                    if (arrNacionalidad.value[0] != 'Error') {
                        //Si la nacionalidad es Americana (2) raliza la validacion de remolque activo y fianza obligada.
                        if (arrNacionalidad.value[0] == 2) {
                            // valida que el remolque este activo, siempre y cuando sea impo
                            arrFianza = EditarFianza(Array1[11], Array1[12], '1', false)
                            if (arrFianza.value[0] == 'Error') {
                                MuestraCargando(false);
                                document.getElementById("btnGuarda").disabled = false;
                                return;
                            }
                            else {
                                //Valida que este capturada la fianza
                                if (arrFianza.value[1] == 'I' || arrFianza.value[1] == 'E') {
                                    if (document.getElementById('txtFianza1').value == '') {
                                        document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' no tiene una fianza capturada. Favor de capturarla'
                                        MuestraCargando(false);
                                        document.getElementById("btnGuarda").disabled = false;
                                        return;
                                    }
                                    else {
                                        if (FianzaNoRtornada(arrFianza.value[2]) == false) {
                                            document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' tiene una fianza retornada. Favor de cambiarla'
                                            MuestraCargando(false);
                                            document.getElementById("btnGuarda").disabled = false;
                                            return;
                                        }
                                    }
                                }
                                else {
                                    if (FianzaNoRtornada(arrFianza.value[2]) == false) {
                                        document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' tiene una fianza retornada. Favor de cambiarla'
                                        MuestraCargando(false);
                                        document.getElementById("btnGuarda").disabled = false;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else {
                        document.getElementById('lblErrorAjax').innerHTML = arrNacionalidad.value[1];
                        return arrControl;
                    }
                }

                //Obtengo la nacionalidad para validar la fianza de los remolques propios americanos.
                //Jdlcruz, GASA 29-Nov-2012, Folio: 17748.
                if (Array1[14] == '' && Array1[15] != '') { //Si no tiene capturada la Linea 2 y pero si capturado el remolque 2
                    //Obtengo la nacionalidad del remolque.
                    arrNacionalidad = pridesp01_pre_i_despasignarpedidos.GetNacionalidadRemolque(Array1[15]);
                    if (arrNacionalidad.error != null) {
                        alert("Error:" + arrNacionalidad.error);
                        return;
                    }
                    if (arrNacionalidad.value[0] != 'Error') {
                        //Si la nacionalidad es Americana (2) raliza la validacion de remolque activo y fianza obligada.
                        if (arrNacionalidad.value[0] == 2) {
                            // valida que el remolque este activo, siempre y cuando sea impo
                            arrFianza = EditarFianza(Array1[14], Array1[15], '1', false)
                            if (arrFianza.value[0] == 'Error') {
                                MuestraCargando(false);
                                document.getElementById("btnGuarda").disabled = false;
                                return;
                            }
                            else {
                                //Valida que este capturada la fianza
                                if (arrFianza.value[1] == 'I' || arrFianza.value[1] == 'E') {
                                    if (document.getElementById('txtFianza1').value == '') {
                                        document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[15] + ' no tiene una fianza capturada. Favor de capturarla'
                                        MuestraCargando(false);
                                        document.getElementById("btnGuarda").disabled = false;
                                        return;
                                    }
                                    else {
                                        if (FianzaNoRtornada(arrFianza.value[2]) == false) {
                                            document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' tiene una fianza retornada. Favor de cambiarla'
                                            MuestraCargando(false);
                                            document.getElementById("btnGuarda").disabled = false;
                                            return;
                                        }
                                    }
                                }
                                else {
                                    if (FianzaNoRtornada(arrFianza.value[2]) == false) {
                                        document.getElementById('lblErrorAjax').innerText = 'El Remolque ' + Array1[12] + ' tiene una fianza retornada. Favor de cambiarla'
                                        MuestraCargando(false);
                                        document.getElementById("btnGuarda").disabled = false;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else {
                        document.getElementById('lblErrorAjax').innerHTML = arrNacionalidad.value[1];
                        return arrControl;
                    }
                }
            } // Termina cambio de fianzas
    pridesp01_pre_i_despasignarpedidos.Guardar(Array1, Guardar_CallBack);
}

function FianzaNoRtornada(statusFianza) {
    if (statusFianza == "R" && document.getElementById("FianzaRetornada").value == "S") {
        return false;
    }
    else {
        return true;
    }
}


function Guardar_CallBack(response) {
    if (response.error != null) { return; }
    if (response.value[0] == 'Error') {
        document.getElementById("btnGuarda").disabled = false;
        lblErrorAjax.innerText = response.value[1]
        MuestraCargando(false)
    } else {
        var rowIndex; var oRow; var oGriduwgUnidades;
        oGriduwgUnidades = null
        if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
            oGriduwgUnidades = window.opener.igtbl_getGridById("uwgUnidades")
            rowIndex = window.opener.igtbl_getGridById('uwgUnidades').ActiveRow
            oRow = window.opener.igtbl_getRowById(rowIndex)
        } else {
            oGriduwgUnidades = window.opener.opener.igtbl_getGridById("uwgUnidades")
            rowIndex = window.opener.opener.igtbl_getGridById('uwgUnidades').ActiveRow
            oRow = window.opener.opener.igtbl_getRowById(rowIndex)
        }
        try {
            //Actualiza el registro, Agregando otro registro o agrupando, según sea el caso
            if (response.value[1] == 'NuevoRow') {
                //Nuevo Row
                if (response.value[2] == 'Actualiza') {
                    if (oGriduwgUnidades.GroupByBox.groups.length == 0) {
                        //Agrega Nuevo Registro
                        window.opener.igtbl_addNew('uwgUnidades', 0);
                        rowIndex = window.opener.igtbl_getGridById('uwgUnidades').ActiveRow
                        oRow = window.opener.igtbl_getRowById(rowIndex)
                        oGriduwgUnidades.setActiveRow(oRow);
                        oRow.setSelected(true);
                        ColumnasUnidadesDB(response, oRow)
                        if (window.opener.igtbl_getGridById('uwgPedidos') != null) {
                            //Elimina Pedidos Asignados
                            window.opener.igtbl_getGridById('uwgPedidos').AllowDelete = 1 //Si
                            window.opener.igtbl_deleteSelRows('uwgPedidos');
                            window.opener.igtbl_getGridById('uwgPedidos').AllowDelete = 2 //No
                        }
                    } else {
                        //Agrega Nuevo Registro
                        if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
                            var oRowId = window.opener.igtbl_getGridById('uwgUnidades').oActiveRow.Id
                            var oRow = window.opener.igtbl_getRowById(oRowId)
                        } else {
                            var oRowId = window.opener.opener.igtbl_getGridById('uwgUnidades').oActiveRow.Id
                            var oRow = window.opener.opener.igtbl_getRowById(oRowId)
                        }
                        ColumnasUnidadesDB(response, oRow)
                        //Si tiene pedidos
                        if (response.value[3] > 0) {
                            if (window.opener.igtbl_getGridById('uwgPedidos') != null) {
                                window.opener.igtbl_getGridById('uwgPedidos').AllowDelete = 1 //Si
                                window.opener.igtbl_deleteSelRows('uwgPedidos');
                                window.opener.igtbl_getGridById('uwgPedidos').AllowDelete = 2 //No
                            }
                        }
                    }
                } else {
                    if (oGriduwgUnidades.GroupByBox.groups.length == 0) {
                        ColumnasUnidadesDB(response, oRow)
                    } else {
                        if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
                            var oRowId = window.opener.igtbl_getGridById('uwgUnidades').oActiveRow.Id
                            var oRow = window.opener.igtbl_getRowById(oRowId)
                        } else {
                            var oRowId = window.opener.opener.igtbl_getGridById('uwgUnidades').oActiveRow.Id
                            var oRow = window.opener.opener.igtbl_getRowById(oRowId)
                        }
                        ColumnasUnidadesDB(response, oRow)
                    }
                    //Elimina Pedidos Asignados
                    //Si tiene pedidos
                    if (response.value[3] > 0) {
                        window.opener.igtbl_getGridById('uwgPedidos').AllowDelete = 1 //Si
                        window.opener.igtbl_deleteSelRows('uwgPedidos');
                        window.opener.igtbl_getGridById('uwgPedidos').AllowDelete = 2 //No
                    }
                }
            } else {
                var var1; var1 = false;
                if (oGriduwgUnidades.GroupByBox.groups.length == 0) {
                    for (var intcont = 0; intcont < oGriduwgUnidades.Rows.length; ++intcont) {
                        oGriduwgUnidades.Rows.rows[intcont].getNextRow();
                        if (document.getElementById("txtActualiza").value == oGriduwgUnidades.Rows.rows[intcont].getCellFromKey('id_asignacion').getValue()) {
                            //Obtiene el Row del registro seleccionado desde la Pantalla de VP
                            rowIndex = oGriduwgUnidades.Rows.rows[intcont].Id
                            if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
                                oRow = window.opener.igtbl_getRowById(rowIndex)
                            } else {
                                oRow = window.opener.opener.igtbl_getRowById(rowIndex)
                            }
                            oGriduwgUnidades.setActiveRow(oRow);
                            oRow.setSelected(true);
                            var1 = true
                            break;
                        }
                    }
                } else {
                    var oGriduwgUnidades;
                    if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
                        oGriduwgUnidades = window.opener.igtbl_getGridById("uwgUnidades")
                    } else {
                        oGriduwgUnidades = window.opener.opener.igtbl_getGridById("uwgUnidades")
                    }
                    for (var intcont = 0; intcont < oGriduwgUnidades.Rows.length; ++intcont) {
                        if (oGriduwgUnidades.Rows.rows[intcont].ChildRowsCount >> 0) {
                            var oRows = oGriduwgUnidades.Rows
                            oRow = oRows.getRow(intcont);
                            var oChildRows = oRow.Rows;
                            for (j = 0; j < oChildRows.length; j++) {
                                oChildRow = oChildRows.getRow(j);
                                for (c = 0; c < oChildRow.Band.Columns.length; c++) {
                                    var cell = oChildRow.getCell(c);
                                    if (cell != null) {
                                        switch (oChildRow.Band.Columns[c].Key) {
                                            case 'id_asignacion':
                                                if (document.getElementById("txtActualiza").value == cell.getValue()) {
                                                    var oRow;
                                                    if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
                                                        oRow = window.opener.igtbl_getRowById(cell.Row.Id)
                                                    } else {
                                                        oRow = window.opener.opener.igtbl_getRowById(cell.Row.Id)
                                                    }
                                                    oGriduwgUnidades.setActiveRow(oRow);
                                                    oRow.setSelected(true);
                                                    var1 = true
                                                } else {
                                                    break;
                                                }
                                                break;
                                        } // cierra switch
                                    }
                                } //cierra for columnas
                            } //cierra for childrows
                        }
                    }
                }
                //Si no esta dentro del For es una unidad con Viajes agrupados, Actualiza sobre el mismo registro
                if (var1 == false) {
                    rowIndex = oGriduwgUnidades.ActiveRow
                    if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
                        oRow = window.opener.igtbl_getRowById(rowIndex)
                    } else {
                        oRow = window.opener.opener.igtbl_getRowById(rowIndex)
                    }
                }
                //Actualiza Columnas
                if (oGriduwgUnidades.GroupByBox.groups.length == 0) {
                    ColumnasUnidadesDB(response, oRow)
                } else {
                    if (var1 == false) {
                        if (document.getElementById('txtIdGrid').value == 'uwgUnidades') {
                            var oRowId = window.opener.igtbl_getGridById('uwgUnidades').oActiveRow.Id
                            var oRow = window.opener.igtbl_getRowById(oRowId)
                        } else {
                            var oRowId = window.opener.opener.igtbl_getGridById('uwgUnidades').oActiveRow.Id
                            var oRow = window.opener.opener.igtbl_getRowById(oRowId)
                        }
                    }
                    ColumnasUnidadesDB(response, oRow)
                }
                oRow.setSelected(true);
            }
        } catch (er) {
            alert("Error Ajax: " + er.message)
            window.close()
        }
        lblErrorAjax.innerText = ""
        document.getElementById("btnGuarda").disabled = false;
        MuestraCargando(false)
        window.close()
        if (document.getElementById('txtIdGrid').value != 'uwgUnidades') {
            window.opener.close()
        }
    }
}

function ColumnasUnidadesDB(response, oRow) {
    var strSubArray
    for (var i = 4; i < response.value.length; ++i) {
        strSubArray = response.value[i].split(",")
        if (strSubArray[2] == 'datetime') {
            oRow.getCellFromKey(strSubArray[0]).Value = strSubArray[1]
            oRow.getCellFromKey(strSubArray[0]).setValue(strSubArray[1])
        }
        //Inicializa Banderas
        else if (strSubArray[2] == 'bandera1') {
            if (strSubArray[3] > 0) {
                if (strSubArray[4] <= strSubArray[3] > 0) {
                    if (oRow.getCellFromKey("bandera1").Element != null) {
                        oRow.getCellFromKey("bandera1").Element.style.backgroundImage = "url(../Imagenes/controldeviajes/semaforo_verde.gif)"
                        oRow.getCellFromKey("bandera1").Column.Width = 30
                        oRow.getCellFromKey("bandera1").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera1").Column.Style = 'backgroundImage:url(../Imagenes/controldeviajes/semaforo_verde.gif);Width:30px;';
                        oRow.getCellFromKey("bandera1").value = ""
                    }
                }
                else if (strSubArray[4] >= strSubArray[3] && strSubArray[6] <= strSubArray[5]) {
                    if (oRow.getCellFromKey("bandera1").Element != null) {
                        oRow.getCellFromKey("bandera1").Element.style.backgroundImage = "url(../imagenes/MttoAmarillo.gif)"
                        oRow.getCellFromKey("bandera1").Column.Width = 30
                        oRow.getCellFromKey("bandera1").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera1").Column.Style = 'backgroundImage:url(../imagenes/MttoAmarillo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera1").value = ""
                    }
                }
                else {
                    if (oRow.getCellFromKey("bandera1").Element != null) {
                        oRow.getCellFromKey("bandera1").Element.style.backgroundImage = "url(../imagenes/MttoRojo.gif)"
                        oRow.getCellFromKey("bandera1").Column.Width = 30
                        oRow.getCellFromKey("bandera1").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera1").Column.Style = 'backgroundImage:url(../imagenes/MttoRojo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera1").value = ""
                    }
                }
            }
        }
        else if (strSubArray[2] == 'bandera2') {
            if (strSubArray[3] > 0) {
                if (strSubArray[4] <= strSubArray[3] > 0) {
                    if (oRow.getCellFromKey("bandera2").Element != null) {
                        oRow.getCellFromKey("bandera2").Element.style.backgroundImage = "url(../Imagenes/controldeviajes/semaforo_verde.gif)"
                        oRow.getCellFromKey("bandera2").Column.Width = 30
                        oRow.getCellFromKey("bandera2").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera2").Column.Style = 'backgroundImage:url(../Imagenes/controldeviajes/semaforo_verde.gif);Width:30px;';
                        oRow.getCellFromKey("bandera2").value = ""
                    }
                }
                else if (strSubArray[4] >= strSubArray[3] && strSubArray[6] <= strSubArray[5]) {
                    if (oRow.getCellFromKey("bandera2").Element != null) {
                        oRow.getCellFromKey("bandera2").Element.style.backgroundImage = "url(../imagenes/MttoAmarillo.gif)"
                        oRow.getCellFromKey("bandera2").Column.Width = 30
                        oRow.getCellFromKey("bandera2").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera2").Column.Style = 'backgroundImage:url(../imagenes/MttoAmarillo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera2").value = ""
                    }
                }
                else {
                    if (oRow.getCellFromKey("bandera2").Element != null) {
                        oRow.getCellFromKey("bandera2").Element.style.backgroundImage = "url(../imagenes/MttoRojo.gif)"
                        oRow.getCellFromKey("bandera2").Column.Width = 30
                        oRow.getCellFromKey("bandera2").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera2").Column.Style = 'backgroundImage:url(../imagenes/MttoRojo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera2").value = ""
                    }
                }
            }
        }
        else if (strSubArray[2] == 'bandera3') {
            if (strSubArray[3] > 0) {
                if (strSubArray[4] <= strSubArray[3] > 0) {
                    if (oRow.getCellFromKey("bandera3").Element != null) {
                        oRow.getCellFromKey("bandera3").Element.style.backgroundImage = "url(../Imagenes/controldeviajes/semaforo_verde.gif)"
                        oRow.getCellFromKey("bandera3").Column.Width = 30
                        oRow.getCellFromKey("bandera3").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera3").Column.Style = 'backgroundImage:url(../Imagenes/controldeviajes/semaforo_verde.gif);Width:30px;';
                        oRow.getCellFromKey("bandera3").value = ""
                    }
                }
                else if (strSubArray[4] >= strSubArray[3] && strSubArray[6] <= strSubArray[5]) {
                    if (oRow.getCellFromKey("bandera3").Element != null) {
                        oRow.getCellFromKey("bandera3").Element.style.backgroundImage = "url(../imagenes/MttoAmarillo.gif)"
                        oRow.getCellFromKey("bandera3").Column.Width = 30
                        oRow.getCellFromKey("bandera3").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera3").Column.Style = 'backgroundImage:url(../imagenes/MttoAmarillo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera3").value = ""
                    }
                }
                else {
                    if (oRow.getCellFromKey("bandera3").Element != null) {
                        oRow.getCellFromKey("bandera3").Element.style.backgroundImage = "url(../imagenes/MttoRojo.gif)"
                        oRow.getCellFromKey("bandera3").Column.Width = 30
                        oRow.getCellFromKey("bandera3").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera3").Column.Style = 'backgroundImage:url(../imagenes/MttoRojo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera3").value = ""
                    }
                }
            }
        }
        else if (strSubArray[2] == 'bandera4') {
            if (strSubArray[3] > 0) {
                if (strSubArray[4] <= strSubArray[3] > 0) {
                    if (oRow.getCellFromKey("bandera4").Element != null) {
                        oRow.getCellFromKey("bandera4").Element.style.backgroundImage = "url(../Imagenes/controldeviajes/semaforo_verde.gif)"
                        oRow.getCellFromKey("bandera4").Column.Width = 30
                        oRow.getCellFromKey("bandera4").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera4").Column.Style = 'backgroundImage:url(../Imagenes/controldeviajes/semaforo_verde.gif);Width:30px;';
                        oRow.getCellFromKey("bandera4").value = ""
                    }
                }
                else if (strSubArray[4] >= strSubArray[3] && strSubArray[6] <= strSubArray[5]) {
                    if (oRow.getCellFromKey("bandera4").Element != null) {
                        oRow.getCellFromKey("bandera4").Element.style.backgroundImage = "url(../imagenes/MttoAmarillo.gif)"
                        oRow.getCellFromKey("bandera4").Column.Width = 30
                        oRow.getCellFromKey("bandera4").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera4").Column.Style = 'backgroundImage:url(../imagenes/MttoAmarillo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera4").value = ""
                    }
                }
                else {
                    if (oRow.getCellFromKey("bandera4").Element != null) {
                        oRow.getCellFromKey("bandera4").Element.style.backgroundImage = "url(../imagenes/MttoRojo.gif)"
                        oRow.getCellFromKey("bandera4").Column.Width = 30
                        oRow.getCellFromKey("bandera4").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera4").Column.Style = 'backgroundImage:url(../imagenes/MttoRojo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera4").value = ""
                    }
                }
            }
        }
        else if (strSubArray[2] == 'bandera5') {
            if (strSubArray[3] > 0) {
                if (strSubArray[4] <= strSubArray[3] > 0) {
                    if (oRow.getCellFromKey("bandera5").Element != null) {
                        oRow.getCellFromKey("bandera5").Element.style.backgroundImage = "url(../Imagenes/controldeviajes/semaforo_verde.gif)"
                        oRow.getCellFromKey("bandera5").Column.Width = 30
                        oRow.getCellFromKey("bandera5").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera5").Column.Style = 'backgroundImage:url(../Imagenes/controldeviajes/semaforo_verde.gif);Width:30px;';
                        oRow.getCellFromKey("bandera5").value = ""
                    }
                }
                else if (strSubArray[4] >= strSubArray[3] && strSubArray[6] <= strSubArray[5]) {
                    if (oRow.getCellFromKey("bandera5").Element != null) {
                        oRow.getCellFromKey("bandera5").Element.style.backgroundImage = "url(../imagenes/MttoAmarillo.gif)"
                        oRow.getCellFromKey("bandera5").Column.Width = 30
                        oRow.getCellFromKey("bandera5").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera5").Column.Style = 'backgroundImage:url(../imagenes/MttoAmarillo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera5").value = ""
                    }
                }
                else {
                    if (oRow.getCellFromKey("bandera5").Element != null) {
                        oRow.getCellFromKey("bandera5").Element.style.backgroundImage = "url(../imagenes/MttoRojo.gif)"
                        oRow.getCellFromKey("bandera5").Column.Width = 30
                        oRow.getCellFromKey("bandera5").value = ""
                    }
                    else {
                        oRow.getCellFromKey("bandera5").Column.Style = 'backgroundImage:url(../imagenes/MttoRojo.gif);Width:30px;';
                        oRow.getCellFromKey("bandera5").value = ""
                    }
                }
            }
        }

        else if (strSubArray[2] == 'nombre_status_viaje') {
            if (strSubArray[4] != '') {
                if (strSubArray[4] != '' && strSubArray[5] != '') {
                    if (oRow.getCellFromKey("nombre_status_viaje").Element != null) {
                        if (strSubArray[5] > 0) {
                            oRow.getCellFromKey("nombre_status_viaje").Element.style.font.bold = true;
                        }
                        else if (strSubArray[4] > 0) {
                            oRow.getCellFromKey("nombre_status_viaje").Element.style.font.bold = true;
                        }
                        else {
                            oRow.getCellFromKey("nombre_status_viaje").Element.style.font.bold = false;
                        }
                        oRow.getCellFromKey("nombre_status_viaje").Element.style.font.italic = false;
                    }
                    else {
                        if (strSubArray[5] > 0) {
                            oRow.getCellFromKey("nombre_status_viaje").Column.Style = 'font-weight:bold;';
                        }
                        else if (strSubArray[4] > 0) {
                            oRow.getCellFromKey("nombre_status_viaje").Column.Style = 'font-weight:bold;';
                        }
                        else {
                            oRow.getCellFromKey("nombre_status_viaje").Column.Style = 'font-weight:bold;';
                        }
                        oRow.getCellFromKey("nombre_status_viaje").Column.Style = 'font-style:italic;';

                    }
                }
                else {
                    if (oRow.getCellFromKey("nombre_status_viaje").Element != null) {
                        oRow.getCellFromKey("nombre_status_viaje").Element.style.color = "red";
                        oRow.getCellFromKey("nombre_status_viaje").Element.style.font.italic = true;
                        oRow.getCellFromKey("nombre_status_viaje").Element.style.font.bold = true;
                    }
                    else {
                        oRow.getCellFromKey("nombre_status_viaje").Column.Style = 'font-weight:bold;color:red;font-style:italic;'
                    }
                }
            }
            oRow.getCellFromKey(strSubArray[0]).setValue(strSubArray[1])
        }

        else if (strSubArray[2] == 'no_viaje') {
            if (strSubArray[1] <= 0) {
                if (oRow.getCellFromKey("no_viaje").Element != null) {
                    oRow.getCellFromKey("no_viaje").Element.style.cursor = "auto";
                    oRow.getCellFromKey("no_viaje").Element.title = ""
                }
                else {
                    oRow.getCellFromKey("no_viaje").Column.Style = 'cursor:auto;';
                }
                oRow.getCellFromKey(strSubArray[0]).setValue(strSubArray[1])
            }
            else {
                oRow.getCellFromKey(strSubArray[0]).setValue(strSubArray[1])
            }
        }
        else if (strSubArray[2] == 'siguiente' && strSubArray[3] == 'Imagen') {
            if (oRow.getCellFromKey("siguiente").Element != null) {
                oRow.getCellFromKey("siguiente").Element.style.backgroundImage = "url(../Imagenes/controldeviajes/btnsiguientegrid.gif)"
                oRow.getCellFromKey("siguiente").Element.style.cursor = "hand";
            }
            else {
                oRow.getCellFromKey("siguiente").Column.Style = 'backgroundImage:url(../Imagenes/controldeviajes/btnsiguientegrid.gif);cursor:hand;';
            }
        }
        else if (strSubArray[2] == 'siguiente' && strSubArray[3] == 'SinImagen') {
            //No actualiza la imagen
            if (oRow.getCellFromKey("siguiente").Element != null) {
                oRow.getCellFromKey("siguiente").Element.style.backgroundImage = "url(../Imagenes/controldeviajes/spacer.GIF)"
                oRow.getCellFromKey("siguiente").Element.style.cursor = "auto";
            }
            else {
                oRow.getCellFromKey("siguiente").Column.Style = 'backgroundImage:url(../Imagenes/controldeviajes/spacer.GIF);cursor:auto;';
            }
        }
        else {
            oRow.getCellFromKey(strSubArray[0]).setValue(strSubArray[1])
        }
    }
}

function BuscaSeguimiento() {
    var strURL; var winBuscStatus;
    strURL = '../busquedas/busqueda_despseguimiento.aspx?Campo=form1.txtSeguimiento&Descr=form1.txtSeguimientoDesc';
    winBuscStatus = window.open(strURL, 'BuscaSeguimiento', 'width=640,height=480,status=no,scrollbars=no');
    winBuscStatus.ventanaReferencia = window;
    winBuscStatus.Referencia = document.form1.txtSeguimiento;
    winBuscStatus.ReferenciaDesc = document.form1.txtSeguimientoDesc;
}

function AgregaTraslado() {
    var strURL; var winTraslado;
    strURL = '../pridesp01/pre_i_desptrasladoequipo.aspx?ParmAsignHdn=' + document.getElementById("txt_hdAsignacion").value + '&ParmStatus=' + document.getElementById("hdnStatus").value + '&ParmRem1=' + document.getElementById("txtRemolque1").value + '&ParmRem2=' + document.getElementById("txtRemolque2").value + '&ParmLinRem1=' + document.getElementById("txtLineaRem1").value + '&ParmLinRem2=' + document.getElementById("txtLineaRem2").value;
    winTraslado = window.open(strURL, 'TrasladodeEquipo', 'width=750,height=380,status=no,scrollbars=no');
    winTraslado.focus();
}

function wdcInicioViaje_ValueChange(oEdit, oldValue, oEvent) {
    //CambioValor('wdcInicioViaje');
}

function wdcFinViaje_ValueChange(oEdit, oldValue, oEvent) {
    //CambioValor('wdcFinViaje');
}

/*
CREA EL ELEMENTO DIV PARA OPACAR LA PANTALLA Y MOSTRAR MENSAJE DE CARGANDO
NO PERMITE MODIFICAR LA INFORMACIÓN HASTA QUE NO SE TERMINE DE REALIZAR EL PROCESO
*/
var _backgroundElement = document.createElement("div");
function Load() {
    $get("txtRuta").focus();
    $get("contenido").appendChild(_backgroundElement);
    if (document.layers) {
        document.captureEvents(Event.ONKEYPRESS);
    }
    document.onkeypress = CancelEnter;
}

function CancelEnter() {
    if (event.keyCode == 13) {
        return false;
    }
}


//function Test() {
//    try {
//        if (document.getElementById('lblError') != null) {
//            document.getElementById('lblError').innerHTML = '';
//        }
//        var TUT = document.getElementById('txtIdTipoUTracto').value;
//        var TUR1 = document.getElementById('txtIdTipoUR1').value;
//        var TUD = document.getElementById('txtIdTipoUD').value;
//        var TUR2 = document.getElementById('txtIdTipoUR2').value;
//        var PesoCargar = document.getElementById('txtCargaKG').value;
//        var VolCargar = document.getElementById('txtCargarM3').value;
//        pridesp01_pre_i_despasignarpedidos.ObtieneCapacidadCarga(TUT, TUR1, TUR2, TUD, PesoCargar, VolCargar, ObtieneCapacidadCarga_CallBack);
//    } catch (e) {
//        alert("Error Ajax:" + e.message);
//    }
//}

//function ObtieneCapacidadCarga_CallBack(response) {
//    try {
//        if (response.error != null) {
//            document.getElementById('lblConfigMTC').innerHTML = "Configuración MTC: ";
//            alert("Error Ajax:" + response.error); return;
//        }
//        if (response.value[0] == 'Error') {
//            lblErrorAjax.innerText = ""
//            lblErrorAjax.innerText = response.value[1]
//            var oGuardar = document.getElementById('DivGuardar');
//            oGuardar.style.display = 'none';
//            document.getElementById('txtCapacidadKG').value = 0;
//            document.getElementById('txtCapacidadM3').value = 0;
//            document.getElementById('lblConfigMTC').innerHTML = "Configuración MTC: ";
//        } else {
//            lblErrorAjax.innerText = ""
//            var oGuardar = document.getElementById('DivGuardar');
//            oGuardar.style.display = 'block';
//            if (response.value[0] == "InfoCapacidad") {
//                document.getElementById('txtCapacidadKG').value = response.value[1];
//                document.getElementById('txtCapacidadM3').value = response.value[2];
//                document.getElementById('lblConfigMTC').innerHTML = response.value[3];
//            }
//        }
//    } catch (e) {
//        alert("Error Ajax:" + e.message);
//    }
//}
