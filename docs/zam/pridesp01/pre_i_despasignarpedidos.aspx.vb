Imports System.Data.OleDb         ' Required'
' Imports System
' Imports System.Data
' Imports System.Data.SqlClient
' Imports System.Configuration
' Imports System.Collections
' Imports System.Web
' Imports System.Web.Security
' Imports System.Web.UI
' Imports System.Web.UI.WebControls
' Imports System.Web.UI.WebControls.WebParts
' Imports System.Web.UI.HtmlControls
' Imports Ajax

Partial Class pridesp01_pre_i_despasignarpedidos
    Inherits System.Web.UI.Page

#Region "Propiedades"

    Public strImgTractor, strImgRemolque1, strImgDolly, strImgRemolque2 As String
    Public bolCierraVentana As Boolean = False
    Public strOpcionGral As String = ""
    Public bolValidaKit As Boolean = False
    'Protected WithEvents txtHdnIndice As System.Web.UI.HtmlControls.HtmlInputHidden
    Private iBR As New net_b_despextended.pre_b_despasignarpedido
    Private iBROperador As New net_b_zamclases.net_b_clasepersonalcategorias
    Private lSegCtrl As New net_b_extended.net_b_login
    Private iuoBRUnidad As New net_b_metaclases.net_b_mclaseunidad
    Private luo_br_layout As New net_b_servicios.net_b_layouts
    Private iuoAsignacion As New net_b_zamclases.net_b_claseasignacionpedido
    Private ddt_datos_vista As New Data.DataTable
    Public lstrMultiCia As String = "", lstrValidaCapCarga As String = "", lstrValidaFianza As String = ""
    Dim luoParm As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
    Public KGCargar As Decimal = 0, M3Cargar As Decimal = 0
    Public CapacidadM3 As Decimal = 0, CapacidadKG As Decimal = 0
    Dim strRemDest As String = "N"
#End Region

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim arrListaPedidos As New ArrayList
            Dim arrListaPedidosAreas As New ArrayList
            Dim ldtFechas As New Data.DataTable
            Me.ValidaSesionUsuarios()
            Ajax.Utility.RegisterTypeForAjax(GetType(pridesp01_pre_i_despasignarpedidos))
            Me.txtFechaDefault.Text = Application("DateIISTimeFormat")

            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Response.Redirect(Application("myRoot") & "/relogin.aspx")
            End If
            Me.txtIdGrid.Text = Request("IdGrid")
            'Me.txtRutaDesc.Attributes.Add("Readonly", "Readonly")
            Me.lblError.Visible = False
            Me.lblErrorUP1.Visible = False
            Dim intConfig As Integer = 1
            Dim lbolFechSugerida As Boolean

            'iBR.str_log = New net_objestandar.str_log(Session("conn").ToString)
            iBR.str_log = New net_objestandar.str_log(ConfigurationManager.AppSettings("strConn").ToString)
            iBR.AsignacionClass.str_log = iBR.str_log
            iBROperador.str_log = iBR.str_log
            Session("strConn") = iBR.str_log
            'Aplica Seguridad al proceso de Asignación de Pedidos id_unico = 1354
            If lSegCtrl.ValidarPermisoAVentana(Session("UserName"), 1352, iBR.str_log) = False Then
                Response.Redirect(Application("myRoot") & "/segctrl/faltanpermisos.htm")
            End If
            If Page.IsPostBack = False Then
                lstrValidaFianza = luoParm.GetParametro("validafianza", iBR.str_log, False)
                ' lstrValidaFianza = "s"
                If UCase(lstrValidaFianza) = "S" Then
                    Me.DivFianza1.Style.Item(System.Web.UI.HtmlTextWriterStyle.Visibility) = "visible"
                    Me.DivFianza2.Style.Item(System.Web.UI.HtmlTextWriterStyle.Visibility) = "visible"
                End If

                'Valida si es DINET para cambio de Etiquetas
                luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                Dim strDINET As String = ""
                strDINET = luoParm.GetParametro("dinet", iBR.str_log, False)

                If strDINET = "S" Then
                    Me.lblOperador1.Text = "Conductor 1"
                    Me.lblOperador2.Text = "Conductor 2"
                Else
                    Me.lblOperador1.Text = "Operador 1"
                    Me.lblOperador2.Text = "Operador 2"
                End If

                strImgTractor = "../Imagenes/spacer.GIF"
                strImgRemolque1 = "../Imagenes/spacer.GIF"
                strImgDolly = "../Imagenes/spacer.GIF"
                strImgRemolque2 = "../Imagenes/spacer.GIF"

                'Put user code to initialize the page here
                iBR.AsignacionClass.Area = Session("vg_area")
                iBR.AsignacionClass.Ingreso = Session("UserName")
                iBR.AsignacionClass.Fecha_ingreso = Date.Now

                Me.wdcInicioViaje.DisplayModeFormat = Application("DateTimeFormat")
                Me.wdcInicioViaje.EditModeFormat = Application("DateTimeMask")
                Me.wdcFinViaje.DisplayModeFormat = Application("DateTimeFormat")
                Me.wdcFinViaje.EditModeFormat = Application("DateTimeMask")

                'Llama a la función que obtiene el parámetro de captura de Kit
                iBR.ValidaCapturarKit()

                'Si no envia el id_asignacion,
                If Request("ParmAsignHdn") Is Nothing Then

                    'Pasa la lista de pedidos a un arreglo
                    iBR.PasarAArreglo(Request("Lista"), "[;]", arrListaPedidos, iBR.str_log)
                    iBR.PasarAArreglo(Request("Lista2"), "[;]", arrListaPedidosAreas, iBR.str_log)

                    'Se guarda la informacion del Listado de Areas y Listado de Pedidos.
                    Me.txtListaPedidos.Text = Request("Lista")
                    Me.txtListaPedidosAreas.Text = Request("Lista2")

                    'Obtiene la información de las Fechas del o los Pedidos para sugerirlos en las
                    'Fechas de Inicio y Fin de Viaje para la Asignación

                    'Se envian como argumentos la lista de los Pedidos de los cuales va a obtener
                    'las fechas para la asignación y la estructura del LOG como referencia.
                    ldtFechas = iBR.GetFechaIniFinViaje(Request("Lista2"), Request("Lista"), iBR.str_log)
                    If ldtFechas.Rows.Count > 0 Then
                        lbolFechSugerida = True
                        'Asigna la Fecha Inicio de Viaje de la Asignación
                        If Not ldtFechas.Rows(0).Item("f_carfin_prog") Is DBNull.Value Then
                            Me.wdcInicioViaje.Value = ldtFechas.Rows(0).Item("f_carfin_prog")
                            Me.wdcInicioViaje.Text = ldtFechas.Rows(0).Item("f_carfin_prog")
                        End If
                        'Asigna la Fecha de Fin de Viaje de la Asignación
                        If Not ldtFechas.Rows(0).Item("f_desfin_prog") Is DBNull.Value Then
                            Me.wdcFinViaje.Value = ldtFechas.Rows(0).Item("f_desfin_prog")
                            Me.wdcFinViaje.Text = ldtFechas.Rows(0).Item("f_desfin_prog")
                        End If
                    End If

                    'Obtiene las propiedades del nuevo viaje
                    iBR.AbrirNuevo(iBR.AsignacionClass.Area, arrListaPedidos, arrListaPedidosAreas, Request("Unidad"))

                    'Obtiene configuracion default
                    If iBR.AsignacionClass.Remolque1.Length > 0 Then
                        intConfig = intConfig + 1
                    End If
                    If iBR.AsignacionClass.Remolque2.Length > 0 Then
                        intConfig = intConfig + 1
                    End If

                    'Busca el parametro de Multicompania MILAC, Folio : 15491
                    lstrMultiCia = luoParm.GetParametro("despmulticompania", iBR.str_log, False)
                    If UCase(lstrMultiCia) = "S" Then
                        Try
                            'Valida la informacion de los Pedidos y la Unidad, se envian como argumentos el Listado
                            'de Pedidos, el Listado de Areas, la Unidad y la estructura del LOG como referencia.
                            iBR.ValidaCompaniaPedidosUnidad(arrListaPedidos, arrListaPedidosAreas, iBR.AsignacionClass.Tractor, iBR.str_log)
                        Catch ex As Exception
                            Me.DivGuardar.Style.Item(System.Web.UI.HtmlTextWriterStyle.Display) = "none"
                            Throw ex
                        End Try
                    End If

                Else 'En caso de recibir el id_asignacion, abre la asignacion solicitada
                    Me.txt_hdAsignacion.Text = Request("ParmAsignHdn")
                    iBR.AsignacionClass.GetAsignacion(Request("ParmAsignHdn"), iBR.AsignacionClass, iBR.str_log)
                    intConfig = iBR.AsignacionClass.Id_configuracionviaje
                    Me.txtNumAsignacion.Text = iBR.AsignacionClass.Num_Asignacion
                    Me.hdnStatus.Value = iBR.AsignacionClass.Status_Asignacion
                    'Valida que si la Asignación ya tiene un Viaje, NO se pueda
                    'editar la información de los datos de la asignación.
                    If Request("ParmEdit") = "0" Then
                        Me.DivGuardar.Style.Item(System.Web.UI.HtmlTextWriterStyle.Display) = "none"
                        'Me.btnGuardar.Visible = False
                    Else
                        Me.DivGuardar.Style.Item(System.Web.UI.HtmlTextWriterStyle.Display) = "block"
                        'Me.btnGuardar.Visible = True
                    End If

                    'Cambios STI 23/12/2011
                    Dim luoParam As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                    Dim lstrParam2 As String
                    lstrParam2 = UCase(luoParam.GetParametro("remolquesempalmados", iBR.str_log, False))
                    If iBR.AsignacionClass.Remolque1 <> Nothing And lstrParam2 = "S" Then
                        Me.Img50.Visible = True
                    End If
                End If
                'Se llena la pantalla con la información de la Asignación
                Me.txtRuta.Text = iBR.AsignacionClass.Ruta
                If iBR.AsignacionClass.Ruta <> 0 Then
                    'Se llama a la función que valida la Ruta, se le envia como argumento
                    'el campo de la Descripción de la Ruta como referencia
                    iBR.ValidaRuta(iBR.AsignacionClass.Ruta, iBR.str_log, Me.txtRutaDesc.Text)
                End If
                If Request("ParmAsignHdn") Is Nothing And lbolFechSugerida = True Then
                    If Not ldtFechas.Rows(0).Item("f_carfin_prog") Is DBNull.Value Then
                        iBR.AsignacionClass.F_prog_ini_viaje = ldtFechas.Rows(0).Item("f_carfin_prog")
                        Me.wdcInicioViaje.Value = ldtFechas.Rows(0).Item("f_carfin_prog")
                    Else
                        iBR.AsignacionClass.F_prog_ini_viaje = Today
                        Me.wdcInicioViaje.Value = Today
                    End If
                    If Not ldtFechas.Rows(0).Item("f_desfin_prog") Is DBNull.Value Then
                        iBR.AsignacionClass.F_prog_fin_viaje = ldtFechas.Rows(0).Item("f_desfin_prog")
                        Me.wdcFinViaje.Value = ldtFechas.Rows(0).Item("f_desfin_prog")
                    Else
                        iBR.AsignacionClass.F_prog_fin_viaje = Today
                        Me.wdcFinViaje.Value = Today
                    End If

                Else
                    Me.wdcInicioViaje.Value = iBR.AsignacionClass.F_prog_ini_viaje
                    'Me.wdcInicioViaje.Text = iBR.AsignacionClass.F_prog_ini_viaje
                    Me.wdcFinViaje.Value = iBR.AsignacionClass.F_prog_fin_viaje
                    'Me.wdcFinViaje.Text = iBR.AsignacionClass.F_prog_fin_viaje
                End If

                'Se agrega la validación del parámetro de SU TRANSPORTE para la validación del Armado
                'emartinez 02-ENERO-2009
                luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                Dim lstrParam As String = ""
                'Se llama a la función GetParametro, se envian como argumentos el nombre del
                'parámetro, la estructura del LOG como referencia y una variable que indica
                'si se valida o no que existe el parámetro en la base de datos. emartinez 02-ENE-2009
                lstrParam = luoParm.GetParametro("CAMBIOS_SUTRANSPORTE", iBR.str_log, False)
                If lstrParam = "S" Then Me.txtHdnValidaArmado.Value = 0
                If lstrParam = "N" Then Me.txtHdnValidaArmado.Value = 1

                'En caso de que el valor sea TRUE muestra la información
                'para capturar el kit
                If iBR.CapturarKit = True Then
                    Me.DivKit.Style.Item(System.Web.UI.HtmlTextWriterStyle.Display) = "block"
                    'Me.tblkit.Visible = True
                Else
                    Me.DivKit.Style.Item(System.Web.UI.HtmlTextWriterStyle.Display) = "none"
                    'Me.tblkit.Visible = False
                End If
                Me.txtKit.Text = iBR.AsignacionClass.Kit
                Me.bolValidaKit = iBR.CapturarKit
                Me.txtIngreso.Text = iBR.AsignacionClass.Ingreso
                Me.txtHrsEstandar.Text = iBR.AsignacionClass.HrsEstandar
                Me.txtUnidad.Text = iBR.AsignacionClass.Tractor
                Me.txtUnidadOriginal.Text = iBR.AsignacionClass.Tractor
                Me.txtLineaRem1.Text = iBR.AsignacionClass.LineaRem1
                Me.txtLineaRem1Original.Text = iBR.AsignacionClass.LineaRem1
                Me.txtRemolque1.Text = iBR.AsignacionClass.Remolque1
                Me.txtRemolque1Original.Text = iBR.AsignacionClass.Remolque1
                Me.txtDolly.Text = iBR.AsignacionClass.Dolly
                Me.txtLineaRem2.Text = iBR.AsignacionClass.LineaRem2
                Me.txtLineaRem2Original.Text = iBR.AsignacionClass.LineaRem2
                Me.txtRemolque2.Text = iBR.AsignacionClass.Remolque2
                Me.txtRemolque2Original.Text = iBR.AsignacionClass.Remolque2
                Me.txtObservaciones.Text = iBR.AsignacionClass.Observaciones
                Me.txtOperador1.Text = iBR.AsignacionClass.Operador1
                Me.txtOperador1Original.Text = iBR.AsignacionClass.Operador1
                'Se valida la información del Operador, se envian como argumentos
                'un valor para identificar si se valida el Operador 1 o el
                'Operador 2 y de referencia en campo del Nombre del Operador
                iBR.ValidaOperador(1, Me.txtOperador1Nombre.Text)


                'Muestra los datos del Operador 2
                Me.txtOperador2.Text = iBR.AsignacionClass.Operador2
                Me.txtOperador2Original.Text = iBR.AsignacionClass.Operador2
                iBR.ValidaOperador(2, Me.txtOperador2Nombre.Text)
                'Me.txtOperador2Nombre.Text = "SIN OPERADOR"
                Me.txtSeguimiento.Text = iBR.AsignacionClass.SeguimientoNombreCorto
                Me.txtSeguimientoDesc.Text = iBR.AsignacionClass.SeguimientoDesc
                Me.ddlConfigViaje.SelectedValue = intConfig
                Session("ActualizaAsignacion") = True

' -- ================== Diff ======================================== --
                ' NOTE Change behavior
                Dim numOperador as String = Me.txtOperador1.Text
                Me.lblOutputOp.Text = driverLicense(numOperador)
' -- ================== Diff ======================================== --

                'Obtener el parametro nomodificaremolque que deshabilita los campos de remolque1 y 2 así como sus busquedas.
                'Cambios STI 15/11/11
                Dim strParam As String
                luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                strParam = luoParm.GetParametro("nomodificaremolque", iBR.str_log, False)
                'Si se encuentra el parametro de STI
                If UCase(strParam) = "S" Then
                    If arrListaPedidos.Count = 0 Then
                        Me.txtRemolque1.Enabled = False
                        Me.txtRemolque2.Enabled = False
                        Me.ImgSearchRem1.Disabled = True
                        Me.ImgSearchRem2.Disabled = True
                    ElseIf arrListaPedidos(0) <> "vacio" Then
                        Me.txtRemolque1.Enabled = False
                        Me.txtRemolque2.Enabled = False
                        Me.ImgSearchRem1.Disabled = True
                        Me.ImgSearchRem2.Disabled = True
                    End If
                End If

            End If

            'Establece las imagenes
            If Trim(Me.txtUnidad.Text) <> "" Then
                Me.strImgTractor = "../Imagenes/tractor.JPG"
            Else
                Me.strImgTractor = "../Imagenes/spacer.GIF"
            End If
            If Trim(Me.txtRemolque1.Text) <> "" Then
                strImgRemolque1 = "../Imagenes/remolque.JPG"
            Else
                strImgRemolque1 = "../Imagenes/spacer.GIF"
            End If
            If Trim(Me.txtDolly.Text) <> "" Then
                strImgDolly = "../Imagenes/dolly.JPG"
            Else
                strImgDolly = "../Imagenes/spacer.GIF"
            End If
            If Trim(Me.txtRemolque2.Text) <> "" Then
                strImgRemolque2 = "../Imagenes/remolque.JPG"
            Else
                strImgRemolque2 = "../Imagenes/spacer.GIF"
            End If

            'Se Valida que la Unidad no tenga una Orden de Servicio Abierta, se envian como
            'argumentos la Unidad y la estructura del LOG como referencia,emartinez 11-AGO-2009
            luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            Dim lstrMsgUnidad As String = ""
            Dim lintValorParam As Integer = 0
            Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
            luoUnidad.ValidaOrdenServicioUnidad(Me.txtUnidad.Text, iBR.str_log, lstrMsgUnidad, False)
            'Se llama a la función GetParametro, se envian como argumentos el nombre del
            'parámetro, la estructura del LOG como referencia y una variable que indica
            'si se valida o no que existe el parámetro en la base de datos. emartinez 02-ENE-2009
            lintValorParam = luoParm.GetParametroNumerico("despvalidaordenserviciounidad", iBR.str_log, False)
            Select Case lintValorParam
                Case 0  'No se encuentra el parámetro, no valida
                Case 1, 2  'Valida y muestra mensaje, peermite continuar
                    If lstrMsgUnidad.Length > 0 Then
                        Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad
                        Me.lblError.Visible = True
                    End If
            End Select

            'Se Valida que la Unidad no tenga una Orden de Servicio Abierta, se envian como argumentos la Unidad
            '   y la estructura del LOG como referencia, si el parametro esta activo, muestra el mensaje, permite continuar.
            '   Jdlcruz, GASA 28-Nov-2012, Folio: 17747.
            Dim lstrValidaOrden As String = ""
            lstrValidaOrden = luoParm.GetParametro("ValidaOrden_Mantenimiento", iBR.str_log, False)
            If lstrValidaOrden = "S" Then
                Dim lstrMsgUnidad2 As String = ""
                'Valida sobre el Remolque1 y LineaRemolque1, tanto propias americanas y americanas.
                If Me.txtRemolque1.Text <> "" And Me.txtLineaRem1.Text = "" Then
                    luoUnidad.ValidaOrdenServicioUnidad(Me.txtRemolque1.Text, iBR.str_log, lstrMsgUnidad2, False)

                    If Me.lblError.Text <> "" And lstrMsgUnidad2.Length > 0 Then
                        lstrMsgUnidad2 = lstrMsgUnidad2.Replace("La Unidad", "El Remolque")
                        Me.lblError.Text = Me.lblError.Text & " y " & lstrMsgUnidad2
                    ElseIf lstrMsgUnidad2.Length > 0 Then
                        Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad2
                        Me.lblError.Visible = True
                    End If
                ElseIf Me.txtRemolque1.Text <> "" And Me.txtLineaRem1.Text <> "" Then
                    luoUnidad.ValidaOrdenServicioUnidadLinea(Me.txtRemolque1.Text, Me.txtLineaRem1.Text, iBR.str_log, lstrMsgUnidad2, False)

                    If Me.lblError.Text <> "" And lstrMsgUnidad2.Length > 0 Then
                        Me.lblError.Text = Me.lblError.Text & " y " & lstrMsgUnidad2
                    ElseIf lstrMsgUnidad2.Length > 0 Then
                        Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad2
                        Me.lblError.Visible = True
                    End If
                End If
                'Valida sobre el Remolque2 y LineaRemolque2, tanto propias americanas y americanas.
                If Me.txtRemolque2.Text <> "" And Me.txtLineaRem2.Text = "" Then
                    luoUnidad.ValidaOrdenServicioUnidad(Me.txtRemolque2.Text, iBR.str_log, lstrMsgUnidad2, False)

                    If Me.lblError.Text <> "" And lstrMsgUnidad2.Length > 0 Then
                        lstrMsgUnidad2 = lstrMsgUnidad2.Replace("La Unidad", "El Remolque")
                        Me.lblError.Text = Me.lblError.Text & " y " & lstrMsgUnidad2
                    ElseIf lstrMsgUnidad2.Length > 0 Then
                        Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad2
                        Me.lblError.Visible = True
                    End If
                ElseIf Me.txtRemolque2.Text <> "" And Me.txtLineaRem2.Text <> "" Then
                    luoUnidad.ValidaOrdenServicioUnidadLinea(Me.txtRemolque2.Text, Me.txtLineaRem2.Text, iBR.str_log, lstrMsgUnidad2, False)

                    If Me.lblError.Text <> "" And lstrMsgUnidad2.Length > 0 Then
                        Me.lblError.Text = Me.lblError.Text & " y " & lstrMsgUnidad2
                    ElseIf lstrMsgUnidad2.Length > 0 Then
                        Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad2
                        Me.lblError.Visible = True
                    End If
                End If

            End If

            'HRFF 13/11/2012 Se valida si es Viaje Vacio y que admita los controles de Remitente y Destinatario en esta pantalla
            strRemDest = luoParm.GetParametro("desp_ViajeV_RemDest", iBR.str_log, False)
            Dim bol_RemYDest As Boolean = False
            If strRemDest = "S" Then

                Dim EnabledRemolque As Boolean = True
                Dim EnabledRemolque2 As Boolean = True

                If Request("ParmAsignHdn") Is Nothing Then
                    If Request("Lista") = "vacio[;]" Then
                        tblRemDest.Style.Add("display", "block")
                        bol_RemYDest = True
                        lblRemDestHabil.Text = "1"
                    Else
                        If iBR.AsignacionClass.Remolque1.Length > 0 Then
                            EnabledRemolque = False
                        End If
                        If iBR.AsignacionClass.Remolque2.Length > 0 Then
                            EnabledRemolque2 = False
                        End If
                    End If
                Else
                        Dim dtPedidosAsig As New Data.DataTable
                        dtPedidosAsig = iBR.GetPedidosDeUnaAsignacion(Request("ParmAsignHdn"), iBR.str_log)

                        If dtPedidosAsig.Rows.Count = 0 Then
                            tblRemDest.Style.Add("display", "block")
                            bol_RemYDest = True
                            lblRemDestHabil.Text = "1"
                        ElseIf dtPedidosAsig.Rows.Count = 1 Then
                            If dtPedidosAsig.Rows(0)("status_pedido").ToString() = "4" And dtPedidosAsig.Rows(0)("observaciones").ToString().Contains("Repo/Colocación") = True Then
                                tblRemDest.Style.Add("display", "block")
                                bol_RemYDest = True
                                lblRemDestHabil.Text = "1"
                            Else
                            If iBR.AsignacionClass.Remolque1.Length > 0 Then
                                EnabledRemolque = False
                            End If
                            If iBR.AsignacionClass.Remolque2.Length > 0 Then
                                EnabledRemolque2 = False
                            End If
                            End If
                        Else
                        If iBR.AsignacionClass.Remolque1.Length > 0 Then
                            EnabledRemolque = False
                        End If
                        If iBR.AsignacionClass.Remolque2.Length > 0 Then
                            EnabledRemolque2 = False
                        End If
                        End If
                End If
                FianzaRetornada.Value = "S"

                If IsPostBack = False Then
                    txtLineaRem1.Enabled = EnabledRemolque
                    txtRemolque1.Enabled = EnabledRemolque
                    ImgSearchRem1.Visible = EnabledRemolque
                    Img5.Visible = EnabledRemolque

                    txtLineaRem2.Enabled = EnabledRemolque2
                    txtRemolque2.Enabled = EnabledRemolque2
                    ImgSearchRem2.Visible = EnabledRemolque2
                    Img7.Visible = EnabledRemolque2
                End If
            End If

            If bol_RemYDest = True Then
                'Agregar valores a los campos de Remitente y Destinatario
                If iBR.AsignacionClass.Id_remitente <> "0" Then
                    Me.txtRemitente.Text = iBR.AsignacionClass.Id_remitente
                    Me.txtRemitenteNom.Text = iBR.GetNombreById(iBR.AsignacionClass.Id_remitente, iBR.str_log)
                End If
                If iBR.AsignacionClass.Id_destinatario <> "0" Then
                    Me.txtDestinatario.Text = iBR.AsignacionClass.Id_destinatario
                    Me.txtDestinatarioNom.Text = iBR.GetNombreById(iBR.AsignacionClass.Id_destinatario, iBR.str_log)
                End If
            End If

            Dim luoTracto As New net_b_zamclasesextended.net_b_claseunidadextended
            luoTracto.GetUnidad("T", Me.txtUnidad.Text, iBR.str_log)
            Me.idFlota.Text = luoTracto.IdFlota

            'Se obtiene la información del parámetro "Validacion de Carga Asignada vs. Capacidad del Vehiculo"
            'Folio : 16715, emartinez 07/Jun/2012, Proyecto : TMS DINET Fase 1
            luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            Me.lstrValidaCapCarga = luoParm.GetParametro("despvalidacargavscapacidad", iBR.str_log, False)
            If Me.lstrValidaCapCarga = "S" Then
                Me.hfDINET.Text = "1"
                Me.txtHdnParCapCarga.Value = "S"
                'Dim luoTracto As New net_b_zamclasesextended.net_b_claseunidadextended
                Dim luoRem1 As New net_b_zamclasesextended.net_b_claseunidadextended
                Dim luoRem2 As New net_b_zamclasesextended.net_b_claseunidadextended
                Dim luoDolly As New net_b_zamclasesextended.net_b_claseunidadextended
                Me.trInfoCapacidadCarga.Visible = True
                Me.trConfigMTC.Visible = True
                'Se envian los datos del Listado de Areas y Pedidos, la Unidad, Remolque 1, Dolly
                'y Remolque 2 para obtener la configuracion.
                Dim decTotalM3 As Decimal = 0
                If Trim(Me.txtUnidad.Text) <> "" Then
                    'luoTracto.GetUnidad("T", Me.txtUnidad.Text, iBR.str_log)
                    Me.txtTipoUTracto.Text = luoTracto.TipoUnidadDesc
                    Me.txtIdTipoUTracto.Text = luoTracto.TipoUnidad

                    'Obtiene la capacidad de Volumen del tipo de unidad
                    iBR.GetCapacidadUnidadVolumen(luoTracto.TipoUnidad, iBR.str_log, decTotalM3)
                End If
                If Trim(Me.txtRemolque1.Text) <> "" Then
                    luoRem1.GetUnidad("R", Me.txtRemolque1.Text, iBR.str_log)
                    Me.txtTipoURem1.Text = luoRem1.TipoUnidadDesc
                    Me.txtIdTipoUR1.Text = luoRem1.TipoUnidad
                    'Obtiene la capacidad de Volumen del tipo de unidad
                    iBR.GetCapacidadUnidadVolumen(luoRem1.TipoUnidad, iBR.str_log, decTotalM3)
                End If
                If Trim(Me.txtDolly.Text) <> "" Then
                    luoDolly.GetUnidad("D", Me.txtDolly.Text, iBR.str_log)
                    Me.txtTipoUDolly.Text = luoDolly.TipoUnidadDesc
                    Me.txtIdTipoUD.Text = luoDolly.TipoUnidad
                    'Obtiene la capacidad de Volumen del tipo de unidad
                    iBR.GetCapacidadUnidadVolumen(luoDolly.TipoUnidad, iBR.str_log, decTotalM3)
                End If
                If Trim(Me.txtRemolque2.Text) <> "" Then
                    luoRem1.GetUnidad("R", Me.txtRemolque2.Text, iBR.str_log)
                    Me.txtTipoURem1.Text = luoRem1.TipoUnidadDesc
                    Me.txtIdTipoUR1.Text = luoRem1.TipoUnidad
                    'Obtiene la capacidad de Volumen del tipo de unidad
                    iBR.GetCapacidadUnidadVolumen(luoRem1.TipoUnidad, iBR.str_log, decTotalM3)
                End If
                'Se llama a la funcion que obtiene la informacion del Volumen y Peso de los Productos
                'de los Pedidos para validar la Capacidad de Carga del armado , emartinez 19/Jun/2012
                'Folio : , DINET
                If Request("ParmAsignHdn") Is Nothing Then
                    iBR.ObtienePesoVolumenPedidos(arrListaPedidosAreas, arrListaPedidos, Me.KGCargar, Me.M3Cargar, iBR.str_log)
                Else
                    iBR.ObtienePesoVolumenPedidos(iBR.AsignacionClass.ListaPedidosAreas, iBR.AsignacionClass.ListaPedidos, Me.KGCargar, Me.M3Cargar, iBR.str_log)
                End If
                Me.txtCargaKG.Text = Format(Me.KGCargar, "###,##0.00")
                Me.txtCargarM3.Text = Format(Me.M3Cargar, "###,##0.00")
                Try
                    'Se llama a la funcion que Obtiene la Capacidad de Carga del Armado, se envian como argumentos
                    'el Tipo de Unidad del Tractor, el Tipo de Unidad del Remolque1, el Tipo de Unidad del Dolly,
                    'el Tipo de Unidad del Remolque2,
                    'Dim luoCC As New net_b_operacionesV8.ed_b_despcapacidadcarga
                    Dim strDescMTC As String = ""
                    'luoCC.InicializaEstructuraDelLog(1, iBR.str_log)
                    'iBR.CapacidadCarga.id_unidad = Me.txtIdTipoUTracto.Text
                    'iBR.CapacidadCarga.id_remolque_1 = Me.txtIdTipoUR1.Text
                    'iBR.CapacidadCarga.id_dolly = Me.txtIdTipoUD.Text
                    'iBR.CapacidadCarga.id_remolque_2 = Me.txtIdTipoUR2.Text
                    iBR.GetCapacidadCargaArmado(CInt(Me.txtIdTipoUTracto.Text), CInt(Me.txtIdTipoUR1.Text), CInt(Me.txtIdTipoUR2.Text), CInt(Me.txtIdTipoUD.Text), Me.CapacidadKG, Me.CapacidadM3, strDescMTC, iBR.str_log)
                    If strDescMTC <> "" Then
                        Me.lblConfigMTC.Text = Me.lblConfigMTC.Text & strDescMTC
                    Else
                        Me.lblConfigMTC.Text = Me.lblConfigMTC.Text & "No Existe"
                    End If
                    Me.CapacidadM3 = decTotalM3
                    Me.txtCapacidadKG.Text = Format(Me.CapacidadKG, "###,##0.00")
                    Me.txtCapacidadM3.Text = Format(Me.CapacidadM3, "###,##0.00")
                Catch ex As Exception
                    Me.DivGuardar.Style.Item(System.Web.UI.HtmlTextWriterStyle.Display) = "none"
                    Throw ex
                End Try
                'Hace la validacion de la Capacidad de Carga vs. Capacidad de Vehiculo
                If (Me.KGCargar > Me.CapacidadKG) Or (Me.M3Cargar > Me.CapacidadM3) Then
                    Me.DivGuardar.Style.Item(System.Web.UI.HtmlTextWriterStyle.Display) = "none"
                    Throw New Exception("La Capacidad de Carga o de Volumen es menor a la Capacidad de Carga registrada en el Catálogo de Configuración de MTC o el Volumen configurado en el Tipo de Unidad.")
                Else
                    Me.DivGuardar.Style.Item(System.Web.UI.HtmlTextWriterStyle.Display) = "block"
                End If
            Else
                Me.txtHdnParCapCarga.Value = ""
                Me.trInfoCapacidadCarga.Visible = False
                Me.trConfigMTC.Visible = False
            End If

            'Obtiene la fianza de los Remolques Americanos y Propios Americanos
            Dim iuo_br As New net_b_despextended.pre_b_despfianza
            Dim intNacRem1 As Integer = 0
            Dim intNacRem2 As Integer = 0
            If UCase(lstrValidaFianza) = "S" Then
                'Obtengo la nacionalidad del remolque1, cuando es propio y no tiene linea.
                'Jdlcruz, GASA 29-Nov-2012, Folio: 17748
                If Me.txtLineaRem1.Text = "" And Me.txtRemolque1.Text <> "" Then
                    intNacRem1 = luoUnidad.GetRemolqueNacionalidad(Me.txtRemolque1.Text, iBR.str_log)
                End If

                If ((Me.txtLineaRem1.Text <> "" And Me.txtRemolque1.Text <> "") Or intNacRem1 = 2) Then
                    Dim intControl As Integer = 0
                    intControl = luoUnidad.GetRemolqueControlActivo(Me.txtLineaRem1.Text, Me.txtRemolque1.Text, iBR.str_log)
                    iuo_br.AbreVentanaFianza(intControl, Me.txtFianza1.Text, Nothing, Nothing, "", iBR.str_log)
                End If
            End If
            If UCase(lstrValidaFianza) = "S" Then
                'Obtengo la nacionalidad del remolque2, cuando es propio y no tiene linea.
                'Jdlcruz, GASA 29-Nov-2012, Folio: 17748.
                If Me.txtLineaRem2.Text = "" And Me.txtRemolque2.Text <> "" Then
                    intNacRem2 = luoUnidad.GetRemolqueNacionalidad(Me.txtRemolque2.Text, iBR.str_log)
                End If

                If ((Me.txtLineaRem2.Text <> "" And Me.txtRemolque2.Text <> "") Or intNacRem2 = 2) Then
                    Dim intControl As Integer = 0
                    intControl = luoUnidad.GetRemolqueControlActivo(Me.txtLineaRem2.Text, Me.txtRemolque2.Text, iBR.str_log)
                    iuo_br.AbreVentanaFianza(intControl, Me.txtFianza2.Text, Nothing, Nothing, "", iBR.str_log)
                End If
            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.lblError.Visible = True
        End Try

    End Sub


    ' NOTE Add Check if the "Licencia  de Conducir " is valid
    Public Shared Function driverLicense(ByVal intOperador As Integer) as String
    ' -- =========================================================================================== --
    ' --  Procedimiento de conexion a la base de datos usando la definicion en web.config'
    ' -- =========================================================================================== --
' <asp:TextBox ID="dlistEmployee" onchange="display();" runat="server" cssClass="desc" ReadOnly="True" width="200px" height="20px" BackColor="Transparent"></asp:TextBox>
' NOTE Check this
        Dim connectionString As String
        Dim connection As OleDbConnection
        connectionString = ConfigurationManager.AppSettings("strConn").ToString
        connection = New OleDbConnection(connectionString)
        Dim folio,vence,cdays,id_operador,namae,validations,restDays,block,estado As String
        id_operador = intOperador
        ' Try
          Dim sqlcmd As OleDbCommand = connection.CreateCommand
          Dim rdr2 As OleDbDataReader

          sqlcmd.CommandText = "select nombre,folio_licencia,fecha_venclicencia,estado from personal_personal where id_personal = " & id_operador
            connection.Open()
          ' Me.txtgetConnection.Text = "Connected to OLEDB Database  !!"
          rdr2 = sqlcmd.ExecuteReader
              While rdr2.Read()
                  ' Response.Write(rdr2.Item("folio_licencia"))
                  namae = rdr2.Item("nombre")

                  If rdr2.Item("folio_licencia") is DBNull.Value Then
                    folio = ""
                  Else
                    folio = rdr2.Item("folio_licencia")
                  End If

                  estado = rdr2.Item("estado")

                  If rdr2.Item("fecha_venclicencia") is DBNull.Value then
                   vence = ""
                   restDays = ""
                  Else
                    vence = rdr2.Item("fecha_venclicencia")
                    restDays = DateDiff(DateInterval.Day, Date.Today, rdr2.Item("fecha_venclicencia"))
                  End If
              End While
          connection.Close()

          if estado = "A" Then
            If restDays <= 0 OR restDays = "" Then
              block = "0"
            Else If restDays > 0 and restDays < 10 Then
              block = "1"
            Else If restDays = "" Then
              block = "2"
            Else If restDays >= 10 AND restDays < 30
              block = "3"
            End If
          Else
              block = "4"
          End If
            validations = block & "," & restDays & "," & namae & "," & id_operador & "," & folio & "," & vence
          Return validations
        ' Catch ex As Exception
          ' Me.txtgetConnection.Text = "Could not connect to database " & ex.ToString
        ' End Try
    ' -- =========================================================================================== --
    End Function


    'Llama a la función que Guarda la información
    'Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGuardar.Click
    '    If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
    '        Response.Redirect(Application("myRoot") & "/relogin.aspx")
    '    End If
    '    Salvar()
    '    'Me.bolCierraVentana = True
    'End Sub

    Public Sub Salvar()
        Try
            If Not Page.IsValid Then Return

            'Se asigna la Unidad 0 cuando no se ha capturado algún dato en el campo
            'de Tractor, fecha de modificación del código 15-Dic-2004 emartinez
            If Trim(Me.txtUnidad.Text) = "" Then Me.txtUnidad.Text = "0"
            'fin de la modificación

            If Me.txtUnidad.Text <> "0" Then
                Dim luoParm As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                Dim lstrMsgUnidad As String = ""
                Dim lintValorParam As Integer = 0
                Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
                luoUnidad.ValidaOrdenServicioUnidad(Me.txtUnidad.Text, iBR.str_log, lstrMsgUnidad, False)
                'Se llama a la función GetParametro, se envian como argumentos el nombre del
                'parámetro, la estructura del LOG como referencia y una variable que indica
                'si se valida o no que existe el parámetro en la base de datos. emartinez 02-ENE-2009
                lintValorParam = luoParm.GetParametroNumerico("despvalidaordenserviciounidad", iBR.str_log, False)
                Select Case lintValorParam
                    Case 0  'No valida
                    Case 1  'Valida y muestra mensaje, permite continuar
                        If lstrMsgUnidad.Length > 0 Then
                            Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad
                            Me.lblError.Visible = True
                        End If
                    Case 2  'Valida y NO permite continuar
                        If lstrMsgUnidad.Length > 0 Then
                            Throw New Exception(lstrMsgUnidad)
                        End If
                End Select
            End If

            'Si ya ejecuto el proceso de actualizar sale del proceso e inicializa la variable
            'para cerrar la pantalla a True
            If Session("ActualizaAsignacion") = False Then
                bolCierraVentana = True
                Return
            End If

            'Si no envia el id_asignacion,
            If Request("ParmAsignHdn") Is Nothing Then
                'Se ingresa la información de la Nueva Asignación
                Call Ingresar()

                'Se inicializa la variable para que no ejecute la misma accion al
                'dar dos veces click al botón de guardar
                Session("ActualizaAsignacion") = False

                iBR.SetSeguimientoActual(Me.txtUnidad.Text, iBR.str_log, True)

            Else
                'Actualiza la información de la Asignación
                Call Update()
                'Se inicializa la variable para que ejecute la misma accion al
                'dar dos veces click al botón de guardar
                Session("ActualizaAsignacion") = False

                'Se actualiza el Seguimiento
                iBR.SetSeguimientoActual(Me.txtUnidad.Text, iBR.str_log, True)
                'En caso de que haya cambiado de unidad
                If Me.txtUnidad.Text <> Me.txtUnidadOriginal.Text Then
                    'Se actualiza la información de la Unidad Original
                    iBR.SetSeguimientoActual(Me.txtUnidadOriginal.Text, iBR.str_log, True)
                End If
            End If

            Me.txtLineaRem1Original.Text = iBR.AsignacionClass.LineaRem1
            Me.txtRemolque1Original.Text = iBR.AsignacionClass.Remolque1
            Me.txtLineaRem2Original.Text = iBR.AsignacionClass.LineaRem2
            Me.txtRemolque2Original.Text = iBR.AsignacionClass.Remolque2

            bolCierraVentana = True

        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.lblError.Visible = True
        End Try

    End Sub

    Public Sub Ingresar()
        Dim arrListaPedidos As New ArrayList
        Dim arrListaPedidosAreas As New ArrayList
        Dim arrListaPedidosPK As New ArrayList

        iBR.AsignacionClass.Area = Session("vg_area")
        iBR.AsignacionClass.Ingreso = Session("UserName")
        iBR.AsignacionClass.Fecha_ingreso = Date.Now

        'Pasa la lista de pedidos a un arreglo
        iBR.PasarAArreglo(Request("Lista"), "[;]", arrListaPedidos, iBR.str_log)
        iBR.PasarAArreglo(Request("Lista2"), "[;]", arrListaPedidosAreas, iBR.str_log)
        iBR.PasarAArreglo(Request("Lista3"), "[;]", arrListaPedidosPK, iBR.str_log)

        iBR.AsignacionClass.Ruta = Me.txtRuta.Text
        iBR.AsignacionClass.F_prog_ini_viaje = Me.wdcInicioViaje.Value
        iBR.AsignacionClass.F_prog_fin_viaje = Me.wdcFinViaje.Value
        iBR.AsignacionClass.Ingreso = Me.txtIngreso.Text
        iBR.AsignacionClass.HrsEstandar = Me.txtHrsEstandar.Text
        iBR.AsignacionClass.Kit = Me.txtKit.Text
        If Trim(Me.txtUnidad.Text) = "" Then
            iBR.AsignacionClass.Tractor = "0"
        Else
            iBR.AsignacionClass.Tractor = Me.txtUnidad.Text
        End If
        iBR.AsignacionClass.LineaRem1 = Me.txtLineaRem1.Text
        iBR.AsignacionClass.Remolque1 = Me.txtRemolque1.Text
        iBR.AsignacionClass.Dolly = Me.txtDolly.Text
        iBR.AsignacionClass.LineaRem2 = Me.txtLineaRem2.Text
        iBR.AsignacionClass.Remolque2 = Me.txtRemolque2.Text
        If Not Request("Flota") Is Nothing Then
            If IsNumeric(Request("Flota")) Then
                iBR.AsignacionClass.Id_Flota = Request("Flota")
            End If
        End If
        iBR.AsignacionClass.Id_configuracionviaje = Me.ddlConfigViaje.SelectedValue

        'inicializa el valor del  operador 1 en caso de que sea vacio lo pone como cero
        If Trim(Me.txtOperador1.Text) = "" Then
            iBR.AsignacionClass.Operador1 = 0
        Else
            iBR.AsignacionClass.Operador1 = Me.txtOperador1.Text
        End If

        'inicializa el valor del  operador 2 en caso de que sea vacio lo pone como cero
        If Trim(Me.txtOperador2.Text) = "" Then
            iBR.AsignacionClass.Operador2 = 0
        Else
            iBR.AsignacionClass.Operador2 = Me.txtOperador2.Text
        End If

        If Trim(Me.txtObservaciones.Text) = "" Then
            iBR.AsignacionClass.Observaciones = ""
        Else
            iBR.AsignacionClass.Observaciones = Me.txtObservaciones.Text
        End If

        iBR.ListaPedidos = arrListaPedidos
        iBR.ListaPedidosAreas = arrListaPedidosAreas
        iBR.ListaPedidosPK = arrListaPedidosPK
        Me.txtNumAsignacion.Text = iBR.AsignacionClass.Viaje

        iBR.AsignacionClass.SeguimientoNombreCorto = Me.txtSeguimiento.Text

        'Se agrega la validación del parámetro de SU TRANSPORTE para actualizar la Fecha Recibido en
        'los Pedidos de la Asignación, emartinez 30-MARZO-2009
        Dim luoParam As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
        Dim lstrParam As String = ""
        'Se llama a la función GetParametro, se envian como argumentos el nombre del
        'parámetro, la estructura del LOG como referencia y una variable que indica
        'si se valida o no que existe el parámetro en la base de datos.
        lstrParam = luoParam.GetParametro("CAMBIOS_SUTRANSPORTE", iBR.str_log, False)
        If lstrParam = "S" Then iBR.AsignacionClass.ActualizaFechaRecibido = True
        iBR.CrearAsignacion(Me.txtLineaRem1Original.Text, Me.txtRemolque1Original.Text, Me.txtLineaRem2Original.Text, Me.txtRemolque2Original.Text)

    End Sub

    Public Sub Update()

        iBR.AsignacionClass.GetAsignacion(Request("ParmAsignHdn"), iBR.AsignacionClass, iBR.str_log)

        iBR.AsignacionClass.Ruta = Me.txtRuta.Text
        iBR.AsignacionClass.F_prog_ini_viaje = Me.wdcInicioViaje.Value
        iBR.AsignacionClass.F_prog_fin_viaje = Me.wdcFinViaje.Value
        If Trim(Me.txtUnidad.Text) = "" Then
            iBR.AsignacionClass.Tractor = "0"
        Else
            iBR.AsignacionClass.Tractor = Me.txtUnidad.Text
        End If
        iBR.AsignacionClass.LineaRem1 = Me.txtLineaRem1.Text
        iBR.AsignacionClass.Remolque1 = Me.txtRemolque1.Text
        iBR.AsignacionClass.Dolly = Me.txtDolly.Text
        iBR.AsignacionClass.LineaRem2 = Me.txtLineaRem2.Text
        iBR.AsignacionClass.Remolque2 = Me.txtRemolque2.Text
        iBR.AsignacionClass.Id_configuracionviaje = Me.ddlConfigViaje.SelectedValue
        iBR.AsignacionClass.Kit = Me.txtKit.Text

        'inicializa el valor del  operador 1 en caso de que sea vacio lo pone como cero
        If Trim(Me.txtOperador1.Text) = "" Then
            iBR.AsignacionClass.Operador1 = 0
        Else
            iBR.AsignacionClass.Operador1 = Me.txtOperador1.Text
        End If

        'inicializa el valor del  operador 2 en caso de que sea vacio lo pone como cero
        If Trim(Me.txtOperador2.Text) = "" Then
            iBR.AsignacionClass.Operador2 = 0
        Else
            iBR.AsignacionClass.Operador2 = Me.txtOperador2.Text
        End If

        If Trim(Me.txtObservaciones.Text) = "" Then
            iBR.AsignacionClass.Observaciones = ""
        Else
            iBR.AsignacionClass.Observaciones = Me.txtObservaciones.Text
        End If

        Me.txtNumAsignacion.Text = iBR.AsignacionClass.Num_Asignacion

        iBR.AsignacionClass.SeguimientoNombreCorto = Me.txtSeguimiento.Text
        iBR.SalvarEdicion(Me.txtLineaRem1Original.Text, Me.txtRemolque1Original.Text, Me.txtLineaRem2Original.Text, Me.txtRemolque2Original.Text, iBR.str_log)
    End Sub

    Private Sub cusvInicioViaje_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            If Not IsDate(Me.wdcInicioViaje.Value) Then
                Throw New Exception("El dato capturado en Fecha Inicio Viaje debe ser una fecha válida")
            End If

            args.IsValid = True
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
            args.IsValid = False
        End Try
    End Sub

    Private Sub cusvFinViaje_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            If Not IsDate(Me.wdcFinViaje.Value) Then
                Throw New Exception("El dato capturado en Fecha Fin Viaje debe ser una fecha válida")
            End If

            args.IsValid = True
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
            args.IsValid = False
        End Try
    End Sub

    Private Sub cusvRuta_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvRuta.ServerValidate
        Try

            If Trim(Me.txtRuta.Text) = "" Then Me.txtRuta.Text = "0"
            ''iBR.ValidaRutaAsignacion(Me.txtRutaDesc.Text)
            iBR.ValidaOrigenRutaAsignacion(Me.txtRuta.Text, Me.txtUnidad.Text, Me.wdcInicioViaje.Value, iBR.AsignacionClass.Asignacion, Me.txtRespValOrigCont.Text, Me.txtRutaDesc.Text, iBR.str_log)
            iBR.AsignacionClass.Ruta = Me.txtRuta.Text
            args.IsValid = True
        Catch ex As Exception
            Me.txtRutaDesc.Text = ""
            lblError.Text = ex.Message
            Me.cusvRuta.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    'Función que valida la información del Kit
    Protected Sub cusvKit_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvKit.ServerValidate
        Try
            iBR.ValidaKit(Trim(Me.txtKit.Text), Trim(Me.txtUnidad.Text), Trim(Me.txtRemolque1.Text), Trim(Me.txtDolly.Text), Trim(Me.txtRemolque2.Text), iBR.str_log)
            args.IsValid = True
        Catch ex As Exception
            Me.txtKit.Text = ""
            lblError.Text = ex.Message
            Me.cusvUnidad.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    'Función que valida la información del Tractor
    Private Sub cusvUnidad_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvUnidad.ServerValidate
        Try
            If Trim(Me.txtUnidad.Text) = "" Then Me.txtUnidad.Text = "0"
            iBR.AsignacionClass.Tractor = Me.txtUnidad.Text
            iBR.ValidaTractor()
            If Me.txtUnidad.Text <> "0" Then
                Dim luoParm As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                Dim lstrMsgUnidad As String = ""
                Dim lintValorParam As Integer = 0
                Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
                luoUnidad.ValidaOrdenServicioUnidad(Me.txtUnidad.Text, iBR.str_log, lstrMsgUnidad, False)
                'Se llama a la función GetParametro, se envian como argumentos el nombre del
                'parámetro, la estructura del LOG como referencia y una variable que indica
                'si se valida o no que existe el parámetro en la base de datos. emartinez 02-ENE-2009
                lintValorParam = luoParm.GetParametroNumerico("despvalidaordenserviciounidad", iBR.str_log, False)
                Select Case lintValorParam
                    Case 0  'No se encuentra el parámetro, no valida
                    Case 1, 2  'Valida y muestra mensaje, peermite continuar
                        If lstrMsgUnidad.Length > 0 Then
                            Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad
                            Me.lblError.Visible = True
                        End If
                End Select
            End If
            args.IsValid = True
        Catch ex As Exception
            Me.cusvUnidad.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    'Valida la información del Remolque 1
    Private Sub cusvRemolque1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvRemolque1.ServerValidate
        Try
            'Según la opción no valida el Armado para el caso de madrinas
            If Me.txtHdnValidaArmado.Value = 0 Then Exit Sub

            iBR.AsignacionClass.str_log = iBR.str_log
            iBR.AsignacionClass.LineaRem1 = Me.txtLineaRem1.Text
            iBR.AsignacionClass.Remolque1 = Me.txtRemolque1.Text
            iBR.ValidaRemolque1()
            args.IsValid = True
        Catch ex As Exception
            Me.cusvRemolque1.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    'Valida la información del Remolque 2
    Private Sub cusvRemolque2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvRemolque2.ServerValidate
        Try
            'Según la opción no valida el Armado para el caso de madrinas
            If Me.txtHdnValidaArmado.Value = 0 Then Exit Sub

            iBR.AsignacionClass.Remolque1 = Me.txtRemolque1.Text
            iBR.AsignacionClass.LineaRem1 = Me.txtLineaRem1.Text
            iBR.AsignacionClass.Dolly = Me.txtDolly.Text

            iBR.AsignacionClass.LineaRem2 = Me.txtLineaRem2.Text
            iBR.AsignacionClass.Remolque2 = Me.txtRemolque2.Text
            iBR.ValidaRemolque2()
            args.IsValid = True
        Catch ex As Exception
            Me.cusvRemolque2.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    'Función que Valida los datos del Dolly
    Private Sub cusvDolly_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvDolly.ServerValidate
        Try
            'Según la opción no valida el Armado para el caso de madrinas
            If Me.txtHdnValidaArmado.Value = 0 Then Exit Sub

            'Valida la información del Dolly
            iBR.AsignacionClass.Dolly = Me.txtDolly.Text
            iBR.ValidaDolly()
            args.IsValid = True
        Catch ex As Exception
            Me.cusvDolly.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    'Valida la información de la Línea del Remolque
    Private Sub cusvLineaRem1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvLineaRem1.ServerValidate
        Try
            'Según la opción no valida el Armado para el caso de madrinas
            If Me.txtHdnValidaArmado.Value = 0 Then Exit Sub

            iBR.AsignacionClass.str_log = iBR.str_log

            iBR.AsignacionClass.LineaRem1 = Me.txtLineaRem1.Text
            iBR.AsignacionClass.Remolque1 = Me.txtRemolque1.Text
            iBR.ValidaRemolque1()
            args.IsValid = True
        Catch ex As Exception
            Me.cusvLineaRem1.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    Private Sub cusvLineaRem2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvLineaRem2.ServerValidate
        Try
            'Según la opción no valida el Armado para el caso de madrinas
            If Me.txtHdnValidaArmado.Value = 0 Then Exit Sub

            iBR.AsignacionClass.Remolque1 = Me.txtRemolque1.Text
            iBR.AsignacionClass.LineaRem1 = Me.txtLineaRem1.Text
            iBR.AsignacionClass.Dolly = Me.txtDolly.Text

            iBR.AsignacionClass.LineaRem2 = Me.txtLineaRem2.Text
            iBR.AsignacionClass.Remolque2 = Me.txtRemolque2.Text
            iBR.ValidaRemolque2()
            args.IsValid = True
        Catch ex As Exception
            Me.cusvLineaRem2.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    'Se le aplica formato a las columnas del WebGrid de paso para refrescar la información en la
    'pantalla de Asignación de Viajes y Control de Viajes
    Private Sub uwgPaso_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles uwgPaso.InitializeLayout
        e.Layout.Bands(0).Columns.FromKey("posdate").Format = Application("DateTimeFormat")
        e.Layout.Bands(0).Columns.FromKey("f_prog_ini_viaje").Format = Application("DateTimeFormat")
        e.Layout.Bands(0).Columns.FromKey("fecha_real_viaje").Format = Application("DateTimeFormat")
        e.Layout.Bands(0).Columns.FromKey("f_prog_fin_viaje").Format = Application("DateTimeFormat")
        e.Layout.Bands(0).Columns.FromKey("fecha_disponible").Format = Application("DateTimeFormat")
        e.Layout.Bands(0).Columns.FromKey("f_ini_status").Format = Application("DateTimeFormat")
    End Sub

    Private Sub uwgPaso_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.RowEventArgs) Handles uwgPaso.InitializeRow
        Dim intDiasMtto, intDiasVac, intDiaVenceLic As Integer
        Dim intFIniProg, intFIniReal1, intFFinProg As Integer

        'Columna de Mensajes Nuevos
        If e.Row.Cells.FromKey("MensajesNuevos").Value <= 0 Then
            e.Row.Cells.FromKey("MensajesNuevos").Style.BackgroundImage = "../Imagenes/mensajewritegrid.gif"
            e.Row.Cells.FromKey("MensajesNuevos").Value = DBNull.Value
        End If

        'Columna de AlarmasNuevas
        If e.Row.Cells.FromKey("AlarmasNuevas").Value <= 0 Then
            e.Row.Cells.FromKey("AlarmasNuevas").Style.BackgroundImage = "../Imagenes/spacer.GIF"
            e.Row.Cells.FromKey("AlarmasNuevas").Style.Cursor = Infragistics.WebUI.[Shared].Cursors.NotSet
        Else
            e.Row.Cells.FromKey("AlarmasNuevas").Title = "Mostrar Alarmas de la Unidad"
        End If

        'Columna del Viajes Pendientes
        If e.Row.Cells.FromKey("Pend").Value > 0 Then
            e.Row.Cells.FromKey("Pend").Style.ForeColor = Drawing.Color.MediumBlue
            e.Row.Cells.FromKey("Pend").Title = "Mostrar Viajes Pendientes"
        Else
            e.Row.Cells.FromKey("Pend").Style.Cursor = Infragistics.WebUI.[Shared].Cursors.NotSet
        End If

        If e.Row.Cells.FromKey("status_asignacion").Value = 1 Then
            e.Row.Cells.FromKey("num_asignacion").Style.ForeColor = Drawing.Color.Red
        End If

        If e.Row.Cells.FromKey("no_viaje").Value > 0 Then
            e.Row.Cells.FromKey("operadorunidad").Value = e.Row.Cells.FromKey("operadorviaje").Value
            e.Row.Cells.FromKey("no_viaje").Title = "Editar Viaje"
        Else
            e.Row.Cells.FromKey("tiempos").Style.BackgroundImage = "../Imagenes/spacer.GIF"
            e.Row.Cells.FromKey("siguiente").Style.BackgroundImage = "../Imagenes/spacer.GIF"
            e.Row.Cells.FromKey("no_viaje").Style.Cursor = Infragistics.WebUI.[Shared].Cursors.NotSet
        End If

        'Calcula los Dias para Mantenimiento de la Unidad
        If Not e.Row.Cells.FromKey("fecha_servicio_sig").Value = Nothing Then
            'Obtiene la diferencia de dias contra la fecha actual
            intDiasMtto = DateDiff(DateInterval.Day, Date.Today, e.Row.Cells.FromKey("fecha_servicio_sig").Value)
            e.Row.Cells.FromKey("fecha_servicio_sig").Text = intDiasMtto
            If intDiasMtto <= 0 Then
                e.Row.Cells.FromKey("fecha_servicio_sig").Style.ForeColor = Drawing.Color.Red
            End If
        End If

        'Calcula los Dias para Vacaciones del Operador
        If Not e.Row.Cells.FromKey("fecha_sale_vac").Value = Nothing Then
            'Obtiene la diferencia de dias contra la fecha actual
            intDiasVac = DateDiff(DateInterval.Day, Date.Today, e.Row.Cells.FromKey("fecha_sale_vac").Value)
            e.Row.Cells.FromKey("fecha_sale_vac").Text = intDiasVac
            If intDiasVac <= 0 Then
                e.Row.Cells.FromKey("fecha_sale_vac").Style.ForeColor = Drawing.Color.Red
            End If
        End If

        'Calcula los Dias para el Vencimiento de la Licencia
        If Not e.Row.Cells.FromKey("fecha_venclicencia").Value = Nothing Then
            'Obtiene la diferencia de dias contra la fecha actual
            intDiaVenceLic = DateDiff(DateInterval.Day, Date.Today, e.Row.Cells.FromKey("fecha_venclicencia").Value)
            e.Row.Cells.FromKey("fecha_venclicencia").Text = intDiaVenceLic
            If intDiaVenceLic <= 0 Then
                e.Row.Cells.FromKey("fecha_venclicencia").Style.ForeColor = Drawing.Color.Red
            End If
        End If

        'Obtiene la información del Operador 2, si existe, entonces muestra un
        'icono a un lado del Nombre del Operador para señalar que el Viaje
        'cuenta con 2 operadores
        If Not e.Row.Cells.FromKey("operadorunidad2").Value = Nothing Then
            e.Row.Cells.FromKey("mostrar_operador2").Style.BackgroundImage = "../Imagenes/ico11.gif"
        End If

        ''Muestra la información de las Fechas e indica si hay atraso
        If Not e.Row.Cells.FromKey("f_prog_ini_viaje").Value = Nothing Then
            'Compara la Fecha Inicio Programada con la Fecha Actual
            intFIniProg = DateDiff(DateInterval.Day, Date.Today, e.Row.Cells.FromKey("f_prog_ini_viaje").Value)
            If intFIniProg <= 0 Then
                'Muestra la Fecha Ini. Prog.
                e.Row.Cells.FromKey("f_prog_ini_viaje").Style.ForeColor = Drawing.Color.Red
            End If
        End If

        'Compara la Fecha Ini.Real
        If Not e.Row.Cells.FromKey("fecha_real_viaje").Value = Nothing Then
            'Compara la Fecha Ini. Real contra la Fecha Ini. Prog
            If Not e.Row.Cells.FromKey("f_prog_ini_viaje").Value = Nothing Then
                intFIniReal1 = DateDiff(DateInterval.Day, e.Row.Cells.FromKey("f_prog_ini_viaje").Value, e.Row.Cells.FromKey("fecha_real_viaje").Value)
                If intFIniReal1 <= 0 Then
                    e.Row.Cells.FromKey("fecha_real_viaje").Style.ForeColor = Drawing.Color.Red
                End If
            End If

            'Compara la Fecha Ini Real contra la Fecha Actual
            intFIniReal1 = DateDiff(DateInterval.Day, Date.Today, e.Row.Cells.FromKey("fecha_real_viaje").Value)
            If intFIniReal1 <= 0 Then
                e.Row.Cells.FromKey("fecha_real_viaje").Style.ForeColor = Drawing.Color.Red
            End If
        End If

        'Compara la Fecha Fin Prog. contra la Fecha Actual
        If Not e.Row.Cells.FromKey("f_prog_fin_viaje").Value = Nothing Then
            intFFinProg = DateDiff(DateInterval.Day, Date.Today, e.Row.Cells.FromKey("f_prog_fin_viaje").Value)
            If intFFinProg <= 0 Then
                e.Row.Cells.FromKey("f_prog_fin_viaje").Style.ForeColor = Drawing.Color.Red
            End If
        End If

        ''Asigna el color al estatus del viaje
        ''Detecta el caso de que el estatus este atrasado o en aviso
        If e.Row.Cells.FromKey("id_statusviaje").Value <> Nothing Then
            'e.Row.Cells.FromKey("nombre_status_viaje").Style.Cursor = Infragistics.WebUI.[Shared].Cursors.Hand
            'e.Row.Cells.FromKey("nombre_status_viaje").Title = "Mostrar Bitácora de Status"
            If e.Row.Cells.FromKey("duracion_aviso").Value <> Nothing Then
                Dim intMinutosAviso As Integer = iBR.ConvertirAMinutos(e.Row.Cells.FromKey("duracion_aviso").Value)
                Dim intMinutosMaxima As Integer = iBR.ConvertirAMinutos(e.Row.Cells.FromKey("duracion_maxima").Value)
                If DateDiff(DateInterval.Minute, e.Row.Cells.FromKey("f_ini_status").Value, Date.Now) >= intMinutosMaxima Then
                    e.Row.Cells.FromKey("nombre_status_viaje").Style.ForeColor = Drawing.Color.FromArgb(CInt("&H" & e.Row.Cells.FromKey("color_maxima").Value))
                    e.Row.Cells.FromKey("nombre_status_viaje").Style.Font.Bold = True
                ElseIf DateDiff(DateInterval.Minute, e.Row.Cells.FromKey("f_ini_status").Value, Today.Now) >= intMinutosAviso Then
                    e.Row.Cells.FromKey("nombre_status_viaje").Style.ForeColor = Drawing.Color.FromArgb(CInt("&H" & e.Row.Cells.FromKey("color_aviso").Value))
                    e.Row.Cells.FromKey("nombre_status_viaje").Style.Font.Bold = True
                Else
                    e.Row.Cells.FromKey("nombre_status_viaje").Style.ForeColor = Drawing.Color.FromArgb(CInt("&H" & e.Row.Cells.FromKey("color").Value))
                    e.Row.Cells.FromKey("nombre_status_viaje").Style.Font.Bold = False
                End If
                e.Row.Cells.FromKey("nombre_status_viaje").Style.Font.Italic = False
            Else
                e.Row.Cells.FromKey("nombre_status_viaje").Style.ForeColor = Drawing.Color.Red
                e.Row.Cells.FromKey("nombre_status_viaje").Style.Font.Italic = True
                e.Row.Cells.FromKey("nombre_status_viaje").Style.Font.Bold = True
            End If
        Else
            e.Row.Cells.FromKey("nombre_status_viaje").Value = e.Row.Cells.FromKey("desp_status_nombre").Value
            e.Row.Cells.FromKey("nombre_status_viaje").Style.ForeColor = Drawing.Color.Red
            e.Row.Cells.FromKey("nombre_status_viaje").Style.Font.Italic = True
            e.Row.Cells.FromKey("nombre_status_viaje").Style.Font.Bold = False
            e.Row.Cells.FromKey("f_ini_status").Value = e.Row.Cells.FromKey("f_status_unidad").Value
        End If

        'Muestra la información del la Guía
        With e.Row.Cells
            If Not .FromKey("num_guia").Value = Nothing Then
                If .FromKey("CantGuias").Value = 1 Then
                    .FromKey("num_guia").Title = "Mostrar Guía del Viaje"
                ElseIf .FromKey("CantGuias").Value > 1 Then
                    .FromKey("num_guia").Title = "Mostrar Guías del Viaje"
                    .FromKey("mostrar_guias").Style.BackgroundImage = "../Imagenes/variasguias.gif"
                End If
                .FromKey("num_guia").Style.Cursor = Infragistics.WebUI.[Shared].Cursors.Hand
            End If

            'Muestra la información del Pedido
            If Not .FromKey("id_pedido").Value = Nothing Then
                If .FromKey("CantPedidos").Value = 1 Then
                    .FromKey("id_pedido").Title = "Mostrar Pedido del Viaje"

                ElseIf .FromKey("CantPedidos").Value > 1 Then
                    .FromKey("id_pedido").Title = "Mostrar Pedidos del Viaje"
                    .FromKey("mostrar_pedidos").Style.BackgroundImage = "../Imagenes/variospedidos.gif"
                End If
                .FromKey("id_pedido").Style.Cursor = Infragistics.WebUI.[Shared].Cursors.Hand
            End If
        End With

        'Inicializa el tipo de Servicio del pedido
        Select Case e.Row.Cells.FromKey("tipo_serv").Value
            Case "E"
                e.Row.Cells.FromKey("tipo_serv").Text = "Expo."
            Case "I"
                e.Row.Cells.FromKey("tipo_serv").Text = "Impo."
            Case "D"
                e.Row.Cells.FromKey("tipo_serv").Text = "Dom."
            Case Else
                e.Row.Cells.FromKey("tipo_serv").Text = ""
        End Select
    End Sub

    'Valida la información del Operador 1
    Private Sub cusvOperador1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvOperador1.ServerValidate
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Response.Redirect(Application("myRoot") & "/relogin.aspx")
            End If

            Dim lds As New Data.DataSet
            If Trim(Me.txtOperador1.Text) = "" Then Me.txtOperador1.Text = "0"
            iBR.AsignacionClass.Operador1 = Me.txtOperador1.Text
            'Se llama a la función que valida los datos del Operador, se envian como
            'argumentos un identificador para validar el operador 1 o el operador 2
            'y como referencia el campo del Nombre del operador
            iBR.ValidaOperador(1, Me.txtOperador1Nombre.Text)
            iBROperador.GetDatosOperador(Trim(Me.txtOperador1.Text), lds, iBROperador.str_log)
            args.IsValid = True
        Catch ex As Exception
            Me.txtOperador1Nombre.Text = ""
            lblError.Text = ex.Message
            Me.cusvOperador1.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    'Valida la información del Operador 2
    Private Sub cusvOperador2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvOperador2.ServerValidate
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Response.Redirect(Application("myRoot") & "/relogin.aspx")
            End If
            Dim lds As New Data.DataSet
            'No se requiere capturar el Operador 2
            If Trim(Me.txtOperador2Nombre.Text) = "" Then Me.txtOperador2Nombre.Text = "0"
            iBR.AsignacionClass.Operador2 = Me.txtOperador2.Text
            'Se llama a la función que valida la información del Operador 2, se envian
            'como argumentos el operador a validar 1 o 2 y el campo del Nombre del Operador
            'como referencia para regresar la información.
            iBR.ValidaOperador(2, Me.txtOperador2Nombre.Text)
            iBROperador.GetDatosOperador(Trim(Me.txtOperador2.Text), lds, iBROperador.str_log)
            args.IsValid = True
        Catch ex As Exception
            Me.txtOperador2Nombre.Text = ""
            lblError.Text = ex.Message
            Me.cusvOperador2.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    Private Sub txtRemolque2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemolque2.TextChanged

    End Sub

    'Valida el Tipo de Seguimiento seleccionado, emartinez 04-Jul-2007
    Private Sub cusvSeguimiento_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusvSeguimiento.ServerValidate
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Response.Redirect(Application("myRoot") & "/relogin.aspx")
            End If
            'Se valida el Tipo de Seguimiento, se llama a la función ValidaSeguimiento
            'se envian como argumentos el Nombre Corto del Seguimiento, la estructura
            'del LOG como referencia y el Campo de la Descripción del Seguimiento como
            'referencia, emartinez 04-Jul-2007
            iBR.ValidaSeguimiento(Me.txtSeguimiento.Text, iBR.str_log, Me.txtSeguimientoDesc.Text)
            args.IsValid = True
        Catch ex As Exception
            Me.cusvSeguimiento.ErrorMessage = ex.Message
            args.IsValid = False
        End Try
    End Sub

    Protected Sub txtHrsEstandar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim ldtHoras As New DateTime
            ldtHoras = Me.wdcInicioViaje.Value
            Me.wdcFinViaje.Value = ldtHoras.AddHours(Me.txtHrsEstandar.Text)
            ScriptManager.GetCurrent(Page).SetFocus(Me.txtKit)
        Catch ex As Exception
            Me.lblErrorUP1.Visible = True
            Me.lblErrorUP1.Text = ex.Message
        End Try
    End Sub

    Protected Sub txtUnidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnidad.TextChanged
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Response.Redirect(Application("myRoot") & "/relogin.aspx")
            End If
            If Trim(Me.txtUnidad.Text) = "" Then Me.txtUnidad.Text = "0"
            iBR.AsignacionClass.Tractor = Me.txtUnidad.Text
            iBR.ValidaTractor()
            If Me.txtUnidad.Text <> "0" Then
                Dim luoParm As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                Dim lstrMsgUnidad As String = ""
                Dim lintValorParam As Integer = 0
                Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
                luoUnidad.ValidaOrdenServicioUnidad(Me.txtUnidad.Text, iBR.str_log, lstrMsgUnidad, False)
                'Se llama a la función GetParametro, se envian como argumentos el nombre del
                'parámetro, la estructura del LOG como referencia y una variable que indica
                'si se valida o no que existe el parámetro en la base de datos. emartinez 02-ENE-2009
                lintValorParam = luoParm.GetParametroNumerico("despvalidaordenserviciounidad", iBR.str_log, False)
                Select Case lintValorParam
                    Case 0  'No se encuentra el parámetro, no valida
                    Case 1, 2  'Valida y muestra mensaje, peermite continuar
                        If lstrMsgUnidad.Length > 0 Then
                            Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad
                            Me.lblError.Visible = True
                        End If
                End Select
            End If
            'Valida y obtiene la información del Operador
            Me.txtOperador1.Text = iBR.AsignacionClass.Operador1
            'Se llama a la función que valida los datos del Operador, se envian como
            'argumentos un identificador para validar el operador 1 o el operador 2
            'y como referencia el campo del Nombre del operador
            iBR.ValidaOperador(1, Me.txtOperador1Nombre.Text)
            ScriptManager.GetCurrent(Page).SetFocus(Me.txtLineaRem1)
        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub txtKit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKit.TextChanged
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Response.Redirect(Application("myRoot") & "/relogin.aspx")
            End If
            Dim strKit(4) As String
            strKit(0) = Trim(Me.txtKit.Text)
            iBR.GetUnidadesKit(strKit, iBR.str_log)
            Me.txtRemolque1.Text = strKit(2)
            Me.txtDolly.Text = strKit(3)
            Me.txtRemolque2.Text = strKit(4)

        Catch ex As Exception
            Me.txtRemolque1.Text = ""
            Me.txtDolly.Text = ""
            Me.txtRemolque2.Text = ""
            Me.lblError.Visible = True
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    'Se valida y obtiene la información de la Ruta, emartinez 15-JULIO-2009
    Protected Sub txtRuta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Response.Redirect(Application("myRoot") & "/relogin.aspx")
            End If
            If Trim(Me.txtRuta.Text) = "" Then Me.txtRuta.Text = "0"
            ''iBR.ValidaRutaAsignacion(Me.txtRutaDesc.Text)
            iBR.ValidaOrigenRutaAsignacion(Me.txtRuta.Text, Me.txtUnidad.Text, Me.wdcInicioViaje.Value, iBR.AsignacionClass.Asignacion, Me.txtRespValOrigCont.Text, Me.txtRutaDesc.Text, iBR.str_log)
            iBR.AsignacionClass.Ruta = Me.txtRuta.Text
            ScriptManager.GetCurrent(Page).SetFocus(Me.wdcInicioViaje)
        Catch ex As Exception
            Me.txtRutaDesc.Text = ""
            Me.lblErrorUP1.Visible = True
            Me.lblErrorUP1.Text = ex.Message
        End Try
    End Sub


#Region "Valida Campos"

    'Valida Kit
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
        Public Function ValidaKit(ByVal strKit As String) As ArrayList
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Throw New Exception("Su Sesión a terminado, favor de iniciar nuevamente en el modulo.")
            End If
            Dim arraylist As New ArrayList
            iBR.str_log = Session("strConn")
            Dim strArrKit(4) As String
            Dim strUnidad, strRem1, strRem2, strDolly As String
            strUnidad = ""
            strRem1 = ""
            strRem2 = ""
            strDolly = ""
            'strArrKit(0) = Trim(strKit)
            'iBR.GetUnidadesKit(strArrKit, iBR.str_log)
            iBR.ValidaKit(Trim(strKit), strUnidad, strRem1, strDolly, strRem2, iBR.str_log)
            arraylist.Add(strRem1) ' txtRemolque1
            arraylist.Add(strDolly) 'txtDolly
            arraylist.Add(strRem2) 'txtRemolque2
            arraylist.Add(strUnidad) 'txtUnidad


            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

    'Valida Ruta
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
        Public Function ValidaRuta(ByVal intRuta As Integer, ByVal strUnidad As String, ByVal dteFecha As String) As ArrayList
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Throw New Exception("Su Sesión a terminado, favor de iniciar nuevamente en el modulo.")
            End If
            Dim arraylist As New ArrayList
            iBR.str_log = Session("strConn")

            If Trim(intRuta) = "" Then intRuta = 0
            Dim strRuta As String = ""
            iBR.ValidaOrigenRutaAsignacion(intRuta, strUnidad, CDate(dteFecha), iBR.AsignacionClass.Asignacion, "0", strRuta, iBR.str_log)
            arraylist.Add(strRuta)
            iBR.AsignacionClass.Ruta = intRuta

            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function


    ' NOTE Create a Test
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
        Public Function GetData(ByVal numberOp as String) As String
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Throw New Exception("Su Sesión a terminado, favor de iniciar nuevamente en el modulo.")
            End If
              Dim resultValidation As String  = driverLicense(numberOp)
              Return resultValidation
            ' End If
        Catch ex As Exception
          Return "Error"
        End Try
    End Function

    'Valida Operador
    ' <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    '    Public Function ValidaOperador(ByVal intOperador As Integer, ByVal intNoOperador As Integer) As ArrayList
    '     Try
    '         If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
    '             Throw New Exception("Su Sesión a terminado, favor de iniciar nuevamente en el modulo.")
    '         End If
    '
    '         Dim arraylist As New ArrayList
    '         iBR.str_log = Session("strConn")
    '         iBROperador.str_log = Session("strConn")
    '         Dim strOperador As String = ""
    '
    '         Dim lds As New Data.DataSet
    '         If Trim(intOperador) = "" Then intOperador = 0
    '         If intNoOperador = 1 Then
    '             iBR.AsignacionClass.Operador1 = intOperador
    '             iBR.ValidaOperador(1, strOperador)
    '             arraylist.Add(1) '0
    '         ElseIf intNoOperador = 2 Then
    '             iBR.AsignacionClass.Operador2 = intOperador
    '             iBR.ValidaOperador(2, strOperador)
    '             arraylist.Add(2) '0
    '         End If
    '         iBROperador.GetDatosOperador(Trim(intOperador), lds, iBROperador.str_log)
    '         arraylist.Add(strOperador) '1
    '         Return arraylist
    '
    '     Catch ex As Exception
    '         Dim arraylist As New ArrayList
    '         arraylist.Add("Error")
    '         arraylist.Add(ex.Message)
    '         arraylist.Add(intNoOperador)
    '         Return arraylist
    '         Throw ex
    '     End Try
    ' End Function

    'Valida Seguimiento
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
        Public Function ValidaSeguimiento(ByVal strSeguimiento As String) As ArrayList
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Throw New Exception("Su Sesión a terminado, favor de iniciar nuevamente en el modulo.")
            End If
            Dim arraylist As New ArrayList
            iBR.str_log = Session("strConn")
            Dim strSegDesc As String = ""

            iBR.ValidaSeguimiento(strSeguimiento, iBR.str_log, strSegDesc)

            arraylist.Add(strSegDesc)

            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

    'Valida Hora
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
        Public Function ValidaHora(ByVal strHoraEst As String, ByVal strHoraInicio As String) As ArrayList
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Throw New Exception("Su Sesión a terminado, favor de iniciar nuevamente en el modulo.")
            End If
            Dim arraylist As New ArrayList
            iBR.str_log = Session("strConn")

            Dim ldtHoras As New DateTime
            If IsDate(strHoraInicio) = False Then Throw New Exception("Favor de capturar una fecha valida en el campo de fecha inicio viaje.")
            ldtHoras = CDate(strHoraInicio)
            arraylist.Add(ldtHoras.AddHours(strHoraEst)) 'Me.wdcFinViaje.Value

            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

    'Valida Unidad
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
       Public Function ValidaUnidad(ByVal strUnidad As String, ByVal aintIdAsignacion As Integer, ByVal astrListaPedidos As String, ByVal astrListaPedidosAreas As String) As ArrayList
        Try
            Dim arraylist As New ArrayList
            Dim luo_BR As New net_b_despextended.pre_b_despcrearviaje
            Dim luoParm As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            Dim lstrMsgUnidad As String = ""
            Dim lintValorParam As Integer = 0
            Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
            luo_BR.str_log = Session("strConn")
            luo_BR.ViajeClass.Tractor = strUnidad.ToUpper
            luo_BR.ValidaTractor()

            luoUnidad.ValidaOrdenServicioUnidad(luo_BR.ViajeClass.Tractor, luo_BR.str_log, lstrMsgUnidad, True)
            lintValorParam = luoParm.GetParametroNumerico("despvalidaordenserviciounidad", luo_BR.str_log, False)
            Select Case lintValorParam
                Case 0  'No se encuentra el parámetro, no valida
                Case 1, 2  'Valida y muestra mensaje, permite continuar
                    If lstrMsgUnidad.Length > 0 Then
                        arraylist.Add("Advertencia")
                        arraylist.Add("ADVERTENCIA : " & lstrMsgUnidad)
                    End If
            End Select

            'Valida la informacion de la Asignacion y la Unidad.
            lstrMultiCia = luoParm.GetParametro("despmulticompania", luo_BR.str_log, False)
            If UCase(lstrMultiCia) = "S" Then
                If aintIdAsignacion = 0 Then
                    'Obtiene la validacion con la informacion de las Areas y los Pedidos.
                    Dim larrListaP As New ArrayList
                    Dim larrListaPA As New ArrayList
                    'Pasa la lista de pedidos a un arreglo
                    luo_BR.PasarAArreglo(astrListaPedidos, "[;]", larrListaP, luo_BR.str_log)
                    luo_BR.PasarAArreglo(astrListaPedidosAreas, "[;]", larrListaPA, luo_BR.str_log)
                    'Valida la informacion de los Pedidos y la Unidad, se envian como argumentos el Listado
                    'de Pedidos, el Listado de Areas, la Unidad y la estructura del LOG como referencia.
                    iBR.ValidaCompaniaPedidosUnidad(larrListaP, larrListaPA, strUnidad, luo_BR.str_log)
                Else
                    'Obtiene la validacion directamente con la informacion de la Asignacion
                    luo_BR.ValidaCompaniaAsignacionUnidad(aintIdAsignacion, strUnidad, luo_BR.str_log)
                End If
            End If

            'Obtiene la informacion del parametro de Validacion de Capacidad de Carga vs. Capacidad del Vehiculo
            'Folio : 16715, Proyecto : TMS DINET Fase 1, emartinez 11/Jun/2012
            luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            Me.lstrValidaCapCarga = luoParm.GetParametro("despvalidacargavscapacidad", luo_BR.str_log, False)
            If Me.lstrValidaCapCarga = "S" Then
                luoUnidad.GetUnidad("T", strUnidad, luo_BR.str_log)
                'Obtiene la informacion del Tipo de Unidad, Descripcion del Tipo de Unidad del Tractor
                arraylist.Add("InfoTipoUnidad")
                arraylist.Add(luoUnidad.TipoUnidad)
                arraylist.Add(luoUnidad.TipoUnidadDesc)
            End If

            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

    'Valida Remolques y Lineas
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    Public Function ValidaLineasyRemolques(ByVal strLinea As String, ByVal strRemolque As String, ByVal intRemNum As Integer, ByVal strArguments As String()) As ArrayList
        'remNum = indica el numero de remolque a validar.
        Try
            Dim adtRemolque As New Data.DataTable
            Dim arraylist As New ArrayList
            Dim luo_BR As New net_b_despextended.pre_b_despcrearviaje
            Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
            luo_BR.str_log = Session("strConn")
            luo_BR.ViajeClass.str_log = luo_BR.str_log
            'Se agregan los parametros que se usaran en el array que regresa al javascript
            'Esto para que siempre coincidan con su respectivo valor
            arraylist.Add("") '0 intRemNum
            arraylist.Add("") '1 InfoRem
            arraylist.Add("") '2 TipoUnidad
            arraylist.Add("") '3 TipoUnidadDesc
            arraylist.Add("") '4 fianza

            'strArguments(0) = LineaRem1
            'strArguments(1) = Remolque1
            'strArguments(2) = Dolly
            'strArguments(3) = Remolque2
            arraylist(0) = intRemNum '0
            If intRemNum = 1 Then
                luo_BR.ViajeClass.LineaRem1 = strLinea
                luo_BR.ViajeClass.Remolque1 = strRemolque
                luo_BR.ValidaRemolque1(adtRemolque)
                'Obtiene la informacion del parametro de Validacion de Capacidad de Carga vs. Capacidad del Vehiculo
                'Folio : 16715, Proyecto : TMS DINET Fase 1, emartinez 11/Jun/2012
                luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                Me.lstrValidaCapCarga = luoParm.GetParametro("despvalidacargavscapacidad", luo_BR.str_log, False)
                If Me.lstrValidaCapCarga = "S" Then
                    luoUnidad.GetUnidad("R", strLinea, strRemolque, luo_BR.str_log)
                    'Obtiene la informacion del Tipo de Unidad, Descripcion del Tipo de Unidad del Tractor
                    arraylist(1) = "InfoRem1"               '1
                    arraylist(2) = luoUnidad.TipoUnidad     '2
                    arraylist(3) = luoUnidad.TipoUnidadDesc '3
                End If
            Else    'entra cuando va a validar el remolque 2
                luo_BR.ViajeClass.LineaRem1 = strArguments(0)
                luo_BR.ViajeClass.Remolque1 = strArguments(1)
                luo_BR.ViajeClass.Dolly = strArguments(2)
                luo_BR.ViajeClass.Remolque2 = strArguments(3)
                luo_BR.ViajeClass.LineaRem2 = strLinea
                luo_BR.ViajeClass.Remolque2 = strRemolque
                luo_BR.ValidaRemolque2(adtRemolque)
                'Obtiene la informacion del parametro de Validacion de Capacidad de Carga vs. Capacidad del Vehiculo
                'Folio : 16715, Proyecto : TMS DINET Fase 1, emartinez 11/Jun/2012
                luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
                Me.lstrValidaCapCarga = luoParm.GetParametro("despvalidacargavscapacidad", luo_BR.str_log, False)
                If Me.lstrValidaCapCarga = "S" Then
                    luoUnidad.GetUnidad("R", strLinea, strRemolque, luo_BR.str_log)
                    'Obtiene la informacion del Tipo de Unidad, Descripcion del Tipo de Unidad del Tractor
                    arraylist(1) = "InfoRem2"                   '1
                    arraylist(2) = luoUnidad.TipoUnidad         '2
                    arraylist(3) = luoUnidad.TipoUnidadDesc     '3
                End If
            End If

            'Obtiene la fianza del remolque
            If Not adtRemolque Is Nothing Then
                If adtRemolque.Rows.Count > 0 Then
                    'la fianza solo aplica para remolques americanos
                    If strLinea.Length > 0 Then
                        arraylist(4) = adtRemolque.Rows(0).Item("num_fianzas")
                    End If
                End If
            End If

            Return arraylist
        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            arraylist.Add(intRemNum)
            Return arraylist
            Throw ex
        End Try
    End Function

    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    Public Function GetControlRemolque(ByVal strLinea As String, ByVal strRemolque As String, ByVal strAsignacion As String, ByVal astrPedido As String) As ArrayList
        Try
            Dim arraylist As New ArrayList
            Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
            luoUnidad.str_log = Session("strConn")
            Dim intControl As Integer = 0
            Dim strTipoServ As String = ""
            Dim strStatusFianza As String = ""
            intControl = luoUnidad.GetRemolqueControlActivo(strLinea, strRemolque, luoUnidad.str_log)

            strStatusFianza = luoUnidad.GetStatusFianzaRemolqueControl(intControl, luoUnidad.str_log)

            Dim ldtPedidos As New Data.DataTable
            'Obtiene el tipo de servicio del pedido de la asignacion
            ldtPedidos = iuoAsignacion.GetInfoPedidoAsignacion(strAsignacion, luoUnidad.str_log)

            'Si no esta activo el remolque, si es impo no continua

            If Not ldtPedidos Is Nothing Then
                If ldtPedidos.Rows.Count > 0 Then
                    strTipoServ = UCase(ldtPedidos.Rows(0).Item("tipo_serv"))
                    If intControl = 0 Then
                        '   Se valida que el tipo de servicio tambien sea "E", Jdlcruz, GASA 29-Nov-2012, Folio: 17748.
                        If UCase(ldtPedidos.Rows(0).Item("tipo_serv")) = "I" Or UCase(ldtPedidos.Rows(0).Item("tipo_serv")) = "E" Then
                            Throw New Exception("El Remolque " & strRemolque & " no se encuentra activo.")
                        End If
                    End If
                Else
                    'Obtiene el pedido que se esta asignando
                    If IsNumeric(astrPedido) Then
                        Dim ipedido As New net_b_zamclases.net_b_clasepedido
                        ipedido.GetDatosPedido(Session("vg_area"), CInt(astrPedido), luoUnidad.str_log)
                        strTipoServ = UCase(ipedido.tipo_serv)
                        If intControl = 0 Then
                            '   Se valida que el tipo de servicio tambien sea "E", Jdlcruz, GASA 29-Nov-2012, Folio: 17748.
                            If UCase(ipedido.tipo_serv) = "I" Or UCase(ipedido.tipo_serv) = "E" Then
                                Throw New Exception("El Remolque " & strRemolque & " no se encuentra activo.")
                            End If
                        End If
                    End If
                End If
            End If

            arraylist.Add(intControl)
            arraylist.Add(strTipoServ)

            arraylist.Add(strStatusFianza)

            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function
    'Funcion para obtener la nacionalidad del Remolque cuando es propio y no cuenta con id_linea.
    'Jdlcruz, GASA 29-Nov-2012, Folio: 17748
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    Public Function GetNacionalidadRemolque(ByVal strRemolque As String) As ArrayList
        Try
            Dim arraylist As New ArrayList
            Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
            luoUnidad.str_log = Session("strConn")
            Dim intNacionalidad As Integer = 0
            Dim strTipoServ As String = ""
            intNacionalidad = luoUnidad.GetRemolqueNacionalidad(strRemolque, luoUnidad.str_log)

            arraylist.Add(intNacionalidad)

            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

    'Valida Dolly
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
       Public Function ValidaDolly(ByVal strDolly As String) As ArrayList
        Try
            Dim arraylist As New ArrayList
            Dim luo_BR As New net_b_despextended.pre_b_despcrearviaje
            Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
            luo_BR.str_log = Session("strConn")
            luo_BR.ViajeClass.Dolly = strDolly
            luo_BR.ValidaDolly()
            'Obtiene la informacion del parametro de Validacion de Capacidad de Carga vs. Capacidad del Vehiculo
            'Folio : 16715, Proyecto : TMS DINET Fase 1, emartinez 11/Jun/2012
            luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            Me.lstrValidaCapCarga = luoParm.GetParametro("despvalidacargavscapacidad", luo_BR.str_log, False)
            If Me.lstrValidaCapCarga = "S" Then
                luoUnidad.GetUnidad("D", strDolly, luo_BR.str_log)
                'Obtiene la informacion del Tipo de Unidad, Descripcion del Tipo de Unidad del Tractor
                arraylist.Add("InfoTipoUnidad")
                arraylist.Add(luoUnidad.TipoUnidad)
                arraylist.Add(luoUnidad.TipoUnidadDesc)
            End If
            Return arraylist
        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

    'ValidaFechas
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
        Public Function ValidaFechas(ByVal strHoraIni As String, ByVal strHoraFin As String) As ArrayList
        Try
            If Session("UserName") Is Nothing Or Session("vg_area") Is Nothing Then
                Throw New Exception("Su Sesión a terminado, favor de iniciar nuevamente en el modulo.")
            End If
            Dim arraylist As New ArrayList
            iBR.str_log = Session("strConn")

            Dim ldecHoras As Decimal = 0
            Dim ldecMin As Decimal = 0
            If IsDate(strHoraIni) = False Then Throw New Exception("Favor de capturar una fecha valida en el campo de fecha inicio viaje.")
            If IsDate(strHoraFin) = False Then Throw New Exception("Favor de capturar una fecha valida en el campo de fecha fin viaje.")
            ldecHoras = DateDiff(DateInterval.Hour, CDate(strHoraIni), CDate(strHoraFin))
            ldecMin = DateDiff(DateInterval.Minute, CDate(strHoraIni), CDate(strHoraFin))
            ldecMin = ldecMin - (ldecHoras * 60)
            arraylist.Add(ldecHoras + ldecMin / 100)

            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

    'Obtiene la Capacidad de Carga del Armado de Vehiculos
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    Public Function ObtieneCapacidadCarga(ByVal intTipoUTracto As String, ByVal intTipoUR1 As String, ByVal intTipoUR2 As String, ByVal intTipoUDolly As String, ByVal PesoACargar As String, ByVal VolACargar As String, ByVal Array() As String) As ArrayList
        Try
            Dim arraylist As New ArrayList
            Dim strDescripcion As String = "Configuración MTC: "
            Dim strUnidad As String = ""
            Dim strIdTipoUnidad As String = "0"
            Dim strRem1 As String = ""
            Dim strIdTipoRem1 As String = "0"
            Dim strRem2 As String = ""
            Dim strIdTipoRem2 As String = "0"
            Dim strDolly As String = ""
            Dim strIdTipoDolly As String = "0"
            Dim luoTracto As New net_b_zamclasesextended.net_b_claseunidadextended
            Dim luoRem1 As New net_b_zamclasesextended.net_b_claseunidadextended
            Dim luoRem2 As New net_b_zamclasesextended.net_b_claseunidadextended
            Dim luoDolly As New net_b_zamclasesextended.net_b_claseunidadextended
            iBR.str_log = Session("strConn")
            Try
                'Se llama a la funcion que Obtiene la Capacidad de Carga del Armado, se envian como argumentos
                'el Tipo de Unidad del Tractor, el Tipo de Unidad del Remolque1, el Tipo de Unidad del Dolly,
                'el Tipo de Unidad del Remolque2,
                Dim decTotalM3 As Decimal = 0
                If Array(0) <> "" And Array(0) <> "0" Then
                    'Obtiene el nombre del Tipo de Unidad
                    luoTracto.GetUnidad("T", Array(0), iBR.str_log)
                    'Obtiene la capacidad de Volumen del tipo de unidad
                    iBR.GetCapacidadUnidadVolumen(luoTracto.TipoUnidad, iBR.str_log, decTotalM3)
                    strUnidad = luoTracto.TipoUnidadDesc
                    strIdTipoUnidad = CStr(luoTracto.TipoUnidad)
                End If
                If Array(1) <> "" And Array(1) <> "0" Then
                    'Obtiene el nombre del Tipo de Unidad
                    luoRem1.GetUnidad("R", Array(1), iBR.str_log)
                    'Obtiene la capacidad de Volumen del tipo de unidad
                    iBR.GetCapacidadUnidadVolumen(luoRem1.TipoUnidad, iBR.str_log, decTotalM3)
                    strRem1 = luoRem1.TipoUnidadDesc
                    strIdTipoRem1 = CStr(luoRem1.TipoUnidad)
                End If
                If Array(2) <> "" And Array(2) <> "0" Then
                    'Obtiene el nombre del Tipo de Unidad
                    luoDolly.GetUnidad("D", Array(2), iBR.str_log)
                    'Obtiene la capacidad de Volumen del tipo de unidad
                    iBR.GetCapacidadUnidadVolumen(luoDolly.TipoUnidad, iBR.str_log, decTotalM3)
                    strDolly = luoDolly.TipoUnidadDesc
                    strIdTipoDolly = CStr(luoDolly.TipoUnidad)
                End If
                If Array(3) <> "" And Array(3) <> "0" Then
                    'Obtiene el nombre del Tipo de Unidad
                    luoRem2.GetUnidad("R", Array(3), iBR.str_log)
                    'Obtiene la capacidad de Volumen del tipo de unidad
                    iBR.GetCapacidadUnidadVolumen(luoRem2.TipoUnidad, iBR.str_log, decTotalM3)
                    strRem2 = luoRem2.TipoUnidadDesc
                    strIdTipoRem2 = CStr(luoRem2.TipoUnidad)
                End If

                Dim strDescMTC As String = ""
                iBR.GetCapacidadCargaArmado(strIdTipoUnidad, strIdTipoRem1, strIdTipoRem2, strIdTipoDolly, Me.CapacidadKG, Me.CapacidadM3, strDescMTC, iBR.str_log)
                If strDescMTC <> "" Then
                    strDescripcion = strDescripcion & strDescMTC
                Else
                    strDescripcion = "Configuración MTC: No Existe"
                End If

                Me.CapacidadM3 = decTotalM3
                Me.KGCargar = CDec(PesoACargar)
                Me.M3Cargar = CDec(VolACargar)

                'Hace la validacion de la Capacidad de Carga vs. Capacidad de Vehiculo
                If (Me.KGCargar > Me.CapacidadKG) Or (Me.M3Cargar > Me.CapacidadM3) Then
                    arraylist.Add("Error")                              '0
                    'Throw New Exception("La Capacidad de Carga es menor a la Capacidad registrada en el Catálogo de Configuración de MTC.")
                Else
                    arraylist.Add("InfoCapacidad")                      '0
                End If
                'Regresa la informacion de la Capacidad de Carga del Vehiculo
                arraylist.Add(Format(Me.CapacidadKG, "###,##0.00"))     '1
                arraylist.Add(Format(Me.CapacidadM3, "###,##0.00"))     '2
                arraylist.Add(strDescripcion)                           '3
                'Envía la descripcion de los remolques
                arraylist.Add(strIdTipoUnidad)                          '4
                arraylist.Add(strUnidad)                                '5
                arraylist.Add(strIdTipoRem1)                            '6
                arraylist.Add(strRem1)                                  '7
                arraylist.Add(strIdTipoRem2)                            '8
                arraylist.Add(strRem2)                                  '9
                arraylist.Add(strIdTipoDolly)                           '10
                arraylist.Add(strDolly)                                 '11
                Return arraylist
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

' NOTE CurrentWork
' --=========================================================================== --
    'Valida Remitente
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    Public Function ValidaRemitente(ByVal intRemitente As Integer) As ArrayList
        Try
            If Session("strConn") Is Nothing Then
                Throw New Exception("su sesión a terminado, favor de iniciar sesión nuevamente en el modulo.")
            End If
            Dim arraylist As New ArrayList
            iBR.str_log = Session("strConn")
            iBR.AsignacionClass.Id_remitente = intRemitente
            arraylist.Add(iBR.AsignacionClass.Id_remitente)           '0
            arraylist.Add(iBR.GetNombreById(iBR.AsignacionClass.Id_remitente, iBR.str_log))           '1
            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function
' --=========================================================================== --
    'Valida Destinatario
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    Public Function ValidaDestinatario(ByVal intDestinatario As Integer) As ArrayList
        Try
            If Session("strConn") Is Nothing Then
                Throw New Exception("su sesión a terminado, favor de iniciar sesión nuevamente en el modulo.")
            End If
            Dim arraylist As New ArrayList
            iBR.str_log = Session("strConn")
            iBR.AsignacionClass.Id_destinatario = intDestinatario
            arraylist.Add(iBR.AsignacionClass.Id_destinatario)           '0
            arraylist.Add(iBR.GetNombreById(iBR.AsignacionClass.Id_destinatario, iBR.str_log))           '1
            Return arraylist

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            Return arraylist
            Throw ex
        End Try
    End Function

#End Region

    'Funcion que valida los datos antes de guardar la asignación
    Public Sub ValidaDatos(ByVal Array() As String)
        Try
            iBR.ValidaOrigenRutaAsignacion(Array(5), Array(1), CDate(Array(6)), iBR.AsignacionClass.Asignacion, "0", "", iBR.str_log)
            If Array(10) <> "" Then 'verificamos la información del kit
                iBR.ValidaKit(Trim(Array(10)), Trim(Array(1)), Trim(Array(12)), Trim(Array(13)), Trim(Array(14)), iBR.str_log)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Guardar
    <Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)> _
    Public Function Guardar(ByVal Array() As String) As ArrayList
        Try
            Dim luoMSG As New net_b_despextended.pre_b_despmensajes
            Dim luoParm As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            Dim luoUnidad As New net_b_zamclasesextended.net_b_claseunidadextended
            Dim iuo_bandera As New net_b_servicios.net_b_bandera
            Dim bolCommit As Boolean = False
            Dim ldt_unidades, ldtUnidades, ldt_datos_det, ddt_datos_bandera As New Data.DataTable
            Dim intVista, intNoViaje As Integer
            Dim lstrMsgUnidad As String = ""
            Dim strFormat As String = ""
            Dim lintValorParam As Integer = 0
            Dim ArrayReturn As New ArrayList
            'Conexión
            iBR.str_log = Session("strConn")

            luo_br_layout.str_log = Session("strConn")
            iuoAsignacion.str_log = Session("strConn")
            iuo_bandera.str_log = Session("strConn")
            'Se manda llamar el metodo que valida la información
            ValidaDatos(Array)

            If Array(33) = "1" Then
                If Array(31) = "" Then
                    Throw New Exception("Favor de Capturar el remitente")
                ElseIf Array(32) = "" Then
                    Throw New Exception("Favor de Capturar el destinatario")
                End If
            End If

            If Trim(Array(1)) = "" Then Array(0) = "0" 'txtUnidad
            If Trim(Array(1)) <> "0" Then
                luoUnidad.ValidaOrdenServicioUnidad(Trim(Array(0)), iBR.str_log, lstrMsgUnidad, False)
                'Se llama a la función GetParametro, se envian como argumentos el nombre del
                'parámetro, la estructura del LOG como referencia y una variable que indica
                'si se valida o no que existe el parámetro en la base de datos. emartinez 02-ENE-2009
                lintValorParam = luoParm.GetParametroNumerico("despvalidaordenserviciounidad", iBR.str_log, False)
                Select Case lintValorParam
                    Case 0  'No valida
                    Case 1  'Valida y muestra mensaje, permite continuar
                        If lstrMsgUnidad.Length > 0 Then
                            'Me.lblError.Text = "ADVERTENCIA : " & lstrMsgUnidad
                            'Me.lblError.Visible = True
                        End If
                    Case 2  'Valida y NO permite continuar
                        If lstrMsgUnidad.Length > 0 Then
                            Throw New Exception(lstrMsgUnidad)
                        End If
                End Select
            End If



            'Se Valida que la Unidad no tenga una Orden de Servicio Abierta, se envian como argumentos la Unidad
            '   y la estructura del LOG como referencia, si el parametro esta activo, muestra el mensaje, permite continuar.
            '   Jdlcruz, GASA 28-Nov-2012, Folio: 17747.
            Dim lstrValidaOrden As String = ""
            Dim lstrDetenerProceso As String = ""
            lstrValidaOrden = luoParm.GetParametro("ValidaOrden_Mantenimiento", iBR.str_log, False)
            If lstrValidaOrden = "S" Then
                lstrDetenerProceso = luoParm.GetParametro("ValidaOrden_DetenerProceso", iBR.str_log, False)
                Dim boolDetener As Boolean = False
                If lstrDetenerProceso = "S" Then
                    boolDetener = True
                End If

                Dim lstrMsgUnidad2 As String = ""
                'Valida sobre el Remolque1 y LineaRemolque1.
                If Trim(Array(12)) <> "" And Trim(Array(11)) = "" Then
                    luoUnidad.ValidaOrdenServicioUnidad(Trim(Array(12)), iBR.str_log, lstrMsgUnidad2, False)

                    If boolDetener = True Then
                        If lstrMsgUnidad2.Length > 0 Then
                            lstrMsgUnidad2 = lstrMsgUnidad2.Replace("La Unidad", "El Remolque")
                            Throw New Exception(lstrMsgUnidad2)
                        End If
                    End If
                ElseIf Trim(Array(12)) <> "" And Trim(Array(11)) <> "" Then
                    luoUnidad.ValidaOrdenServicioUnidadLinea(Trim(Array(12)), Trim(Array(11)), iBR.str_log, lstrMsgUnidad2, False)

                    If boolDetener = True Then
                        If lstrMsgUnidad2.Length > 0 Then
                            Throw New Exception(lstrMsgUnidad2)
                        End If
                    End If
                End If
                'Valida sobre el Remolque2 y LineaRemolque2.
                If Trim(Array(15)) <> "" And Trim(Array(14)) = "" Then
                    luoUnidad.ValidaOrdenServicioUnidad(Trim(Array(15)), iBR.str_log, lstrMsgUnidad2, False)

                    If boolDetener = True Then
                        If lstrMsgUnidad2.Length > 0 Then
                            lstrMsgUnidad2 = lstrMsgUnidad2.Replace("La Unidad", "El Remolque")
                            Throw New Exception(lstrMsgUnidad2)
                        End If
                    End If
                ElseIf Trim(Array(15)) <> "" And Trim(Array(14)) <> "" Then
                    luoUnidad.ValidaOrdenServicioUnidadLinea(Trim(Array(15)), Trim(Array(14)), iBR.str_log, lstrMsgUnidad2, False)

                    If boolDetener = True Then
                        If lstrMsgUnidad2.Length > 0 Then
                            Throw New Exception(lstrMsgUnidad2)
                        End If
                    End If
                End If

            End If

            'Si no envia el id_asignacion,
            If Trim(Array(0)) = "" Then  'Request("ParmAsignHdn") Is Nothing Then
                'Se ingresa la información de la Nueva Asignación
                Call Ingresar2(Array, ArrayReturn)
                iBR.SetSeguimientoActual(Trim(Array(1)), iBR.str_log, True, luoParm.GetParametro("ActSegTercero", iBR.AsignacionClass.str_log, False))
            Else
                'Actualiza la información de la Asignación
                Call Actualizar(Array, ArrayReturn)
                'Se actualiza el Seguimiento
                iBR.SetSeguimientoActual(Trim(Array(1)), iBR.str_log, True, luoParm.GetParametro("ActSegTercero", iBR.AsignacionClass.str_log, False))
                'En caso de que haya cambiado de unidad
                If Trim(Array(1)) <> Trim(Array(26)) Then
                    'Se actualiza la información de la Unidad Original
                    iBR.SetSeguimientoActual(Trim(Array(26)), iBR.str_log, True, luoParm.GetParametro("ActSegTercero", iBR.AsignacionClass.str_log, False))
                End If
            End If

            'Si no tiene Asignación, entonces se crea una nueva
            If Array(0) = "" Then
                'ArrayReturn.Add("NuevoRow") '1
                ArrayReturn.Item(1) = "NuevoRow"
                'Obtiene el nuevo id_asignacion
                Array(0) = iBR.AsignacionClass.Asignacion
            Else
                'ArrayReturn.Add("ActualizaRow") '1
                ArrayReturn.Item(1) = "ActualizaRow"
            End If

            'Se cruzan las fechas
            Select Case Array(27)
                Case "dd/MM/yyyy HH:mm"
                    strFormat = "MM/dd/yyyy HH:mm"
                Case "MM/dd/yyyy HH:mm"
                    strFormat = "dd/MM/yyyy HH:mm"
            End Select

            'Obtiene la vista en base al usuario
            luo_br_layout.id_ventana = 11
            luo_br_layout.idusuario = Session("UserName")
            ldt_unidades = luo_br_layout.ObtenerVistaUsuario()

            If ldt_unidades.Rows.Count = 1 Then
                Me.ColumnasUnidades(ldt_unidades.Rows(0).Item("id_vista"), Array(16), Array(0), Array(1), False, ldtUnidades)
                intVista = ldt_unidades.Rows(0).Item("id_vista")
                'vista del usuario
            ElseIf ldt_unidades.Rows.Count > 1 Then
                Me.ColumnasUnidades(ldt_unidades.Rows(1).Item("id_vista"), Array(16), Array(0), Array(1), False, ldtUnidades)
                intVista = ldt_unidades.Rows(1).Item("id_vista")
            ElseIf ldt_unidades.Rows.Count = 0 Then
                luo_br_layout.id_ventana = 11
                luo_br_layout.id_vista = 92
                ddt_datos_vista = luo_br_layout.ObtenerVista()
                luo_br_layout.id_vista = ddt_datos_vista.Rows(0).Item("id_vista")
                intVista = ddt_datos_vista.Rows(0).Item("id_vista")
                luo_br_layout.idusuario = Session("UserName")
                Me.ColumnasUnidades(ddt_datos_vista.Rows(0).Item("id_vista"), Array(16), Array(0), Array(1), False, ldtUnidades)
            End If

            If ldtUnidades.Rows.Count > 0 Then
                If ldtUnidades.Rows.Count = 1 Then
                    'ArrayReturn.Add("Agrupa") '2
                    ArrayReturn.Item(2) = "Agrupa" '2
                    'Si es la primer asignación deja la nueva que acaba de crear.
                    If Array(28) <> "null" Then
                        'Se asigna la Asignación Seleccionada, para que consulte por esta y no por la nueva Asignación.
                        Array(0) = Array(28)
                    End If
                ElseIf ldtUnidades.Rows.Count > 1 Then
                    'ArrayReturn.Add("Actualiza") '2
                    ArrayReturn.Item(2) = "Actualiza" '2
                End If

                'Consulta la Asignación del row seleccionado
                iuoAsignacion.GetAsignacionMaster(1, Array(0), Nothing, Nothing, iuoAsignacion, iuoAsignacion.str_log)
                ldtUnidades.Clear()
                'Consulta el registro seleccionado
                Me.ColumnasUnidades(intVista, Array(16), Array(0), Array(1), True, ldtUnidades)

                luo_br_layout.id_vista = intVista
                ldt_datos_det = luo_br_layout.ObtenerVistaDetalle()
                iuo_bandera.id_bandera = 1
                ddt_datos_bandera = iuo_bandera.ObtenerBanderasDetalleCompleto()

                If ldtUnidades.Rows.Count > 0 Then
                    'Valida posibles valores Null
                    If ldtUnidades.Rows(0).Item("duracion_aviso") Is DBNull.Value Then ldtUnidades.Rows(0).Item("duracion_aviso") = 0
                    If ldtUnidades.Rows(0).Item("duracion_maxima") Is DBNull.Value Then ldtUnidades.Rows(0).Item("duracion_maxima") = 0
                    If ldtUnidades.Rows(0).Item("id_statusviaje") Is DBNull.Value Then ldtUnidades.Rows(0).Item("id_statusviaje") = 0
                    If ldtUnidades.Rows(0).Item("no_viaje") Is DBNull.Value Then
                        intNoViaje = 0
                    Else
                        intNoViaje = ldtUnidades.Rows(0).Item("no_viaje")
                    End If

                    'Recorre las columnas del grid de Unidades
                    For Each registro As Data.DataRow In ldt_datos_det.Rows
                        Dim uwgColumn As New Infragistics.WebUI.UltraWebGrid.UltraGridColumn
                        Dim strCell As String
                        If Not ldtUnidades.Rows(0).Item(registro("alias")) Is DBNull.Value Then
                            Dim strFecha As String
                            If registro("tipo_dato") = "datetime" Then
                                strFecha = Format(ldtUnidades.Rows(0).Item(registro("alias")), strFormat)
                                strCell = registro("alias") & "," & strFecha & "," & registro("tipo_dato")
                            Else
                                Select Case registro("alias")
                                    Case "nombre_status_viaje"
                                        'Si no tiene viaje pone el estatus de la unidad
                                        If ldtUnidades.Rows(0).Item(registro("alias")) = "" Then
                                            ldtUnidades.Rows(0).Item(registro("alias")) = ldtUnidades.Rows(0).Item("desp_status_nombre")
                                        End If
                                        If ldtUnidades.Columns.Contains("id_statusviaje") = True And ldtUnidades.Columns.Contains("duracion_aviso") = True And ldtUnidades.Columns.Contains("duracion_maxima") = True Then
                                            strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & "nombre_status_viaje, " & CStr(ldtUnidades.Rows(0).Item("id_statusviaje")) & "," & CStr(ldtUnidades.Rows(0).Item("duracion_aviso")) & "," & CStr(ldtUnidades.Rows(0).Item("duracion_maxima"))
                                        Else
                                            strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & registro("alias")
                                        End If
                                    Case "bandera1"
                                        strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & "bandera1" & "," & ddt_datos_bandera.Rows.Count & "," & ddt_datos_bandera.Rows(0).Item("de") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & ddt_datos_bandera.Rows(1).Item("a") & "," & ddt_datos_bandera.Rows(1).Item("de")
                                    Case "bandera2"
                                        strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & "bandera2" & "," & ddt_datos_bandera.Rows.Count & "," & ddt_datos_bandera.Rows(3).Item("de") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & ddt_datos_bandera.Rows(4).Item("a") & "," & ddt_datos_bandera.Rows(4).Item("de")
                                    Case "bandera3"
                                        strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & "bandera3" & "," & ddt_datos_bandera.Rows.Count & "," & ddt_datos_bandera.Rows(6).Item("de") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & ddt_datos_bandera.Rows(7).Item("a") & "," & ddt_datos_bandera.Rows(7).Item("de")
                                    Case "bandera4"
                                        strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & "bandera4" & "," & ddt_datos_bandera.Rows.Count & "," & ddt_datos_bandera.Rows(9).Item("de") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & ddt_datos_bandera.Rows(10).Item("a") & "," & ddt_datos_bandera.Rows(10).Item("de")
                                    Case "bandera5"
                                        strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & "bandera5" & "," & ddt_datos_bandera.Rows.Count & "," & ddt_datos_bandera.Rows(12).Item("de") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & ddt_datos_bandera.Rows(13).Item("a") & "," & ddt_datos_bandera.Rows(13).Item("de")
                                    Case "siguiente"
                                        'Si tiene viaje asigna imagen de seguimiento sino no.
                                        If intNoViaje > 0 Then
                                            strCell = registro("alias") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & registro("alias") & "," & "Imagen"
                                        Else
                                            strCell = registro("alias") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & registro("alias") & "," & "SinImagen"
                                        End If
                                    Case Else
                                        strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & registro("alias")
                                End Select
                            End If
                        Else
                            If registro("alias") = "no_viaje" Then
                                strCell = registro("alias") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & registro("alias") & "," & ldtUnidades.Rows(0).Item("operadorviaje")
                            ElseIf registro("alias") = "siguiente" Then
                                strCell = registro("alias") & "," & ldtUnidades.Rows(0).Item(registro("alias")) & "," & registro("alias") & "," & "SinImagen"
                            ElseIf registro("alias") = "nombre_status_viaje" Then
                                'Si no tiene viaje pone el estatus de la unidad
                                If ldtUnidades.Rows(0).Item(registro("alias")) Is DBNull.Value Then
                                    ldtUnidades.Rows(0).Item(registro("alias")) = ldtUnidades.Rows(0).Item("desp_status_nombre")
                                End If
                                If ldtUnidades.Columns.Contains("id_statusviaje") = True And ldtUnidades.Columns.Contains("duracion_aviso") = True And ldtUnidades.Columns.Contains("duracion_maxima") = True Then
                                    strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & "nombre_status_viaje, " & CStr(ldtUnidades.Rows(0).Item("id_statusviaje")) & "," & CStr(ldtUnidades.Rows(0).Item("duracion_aviso")) & "," & CStr(ldtUnidades.Rows(0).Item("duracion_maxima"))
                                Else
                                    strCell = registro("alias") & "," & CStr(ldtUnidades.Rows(0).Item(registro("alias"))) & "," & registro("alias")
                                End If
                            Else
                                strCell = registro("alias") & "," & "" & "," & registro("tipo_dato") & "," & ""
                            End If
                        End If
                        ArrayReturn.Add(strCell)
                    Next
                End If
            End If
            'ArrayReturn(0) = Num_asignacion
            'ArrayReturn(1) = Indica si es un nuevo registro o si solo actualiza
            'ArrayReturn(2) = Indica si agrupa o agrega nuevo row
            'ArrayReturn(>2)= Parametros a Actualizar en Grid de Unidades
            Return ArrayReturn

        Catch ex As Exception
            Dim arraylist As New ArrayList
            arraylist.Add("Error")
            arraylist.Add(ex.Message)
            arraylist.Add(Array)
            Return arraylist
            Throw ex
        End Try
    End Function

    Public Sub Ingresar2(ByVal str() As String, ByRef strReturn As ArrayList)
        Dim arrListaPedidos As New ArrayList
        Dim arrListaPedidosAreas As New ArrayList
        Dim arrListaPedidosPK As New ArrayList
        Dim arraylistPedidos As New ArrayList
        Dim arraylistPedidosArea As New ArrayList
        Dim luo_BR As New net_b_despextended.pre_b_despcrearviaje
        iBR.AsignacionClass.Area = Session("vg_area")
        iBR.AsignacionClass.Ingreso = Session("UserName")
        iBR.AsignacionClass.Fecha_ingreso = Date.Now
        iBR.AsignacionClass.str_log = Session("strConn")
        luo_BR.str_log = iBR.AsignacionClass.str_log
        'Pasa la lista de pedidos a un arreglo
        iBR.PasarAArreglo(str(2), "[;]", arrListaPedidos, iBR.str_log) 'Lista 1
        iBR.PasarAArreglo(str(3), "[;]", arrListaPedidosAreas, iBR.str_log) 'Lista 2
        iBR.PasarAArreglo(str(4), "[;]", arrListaPedidosPK, iBR.str_log) 'Lista 3

        iBR.AbrirNuevo(iBR.AsignacionClass.Area, arrListaPedidos, arrListaPedidosAreas, str(1))

        iBR.AsignacionClass.Ruta = str(5) ' Me.txtRuta.Text
        iBR.AsignacionClass.F_prog_ini_viaje = CDate(str(6)) 'Me.wdcInicioViaje.Value
        iBR.AsignacionClass.F_prog_fin_viaje = CDate(str(7)) 'Me.wdcFinViaje.Value
        iBR.AsignacionClass.Ingreso = str(8) 'Me.txtIngreso.Text
        iBR.AsignacionClass.HrsEstandar = str(9) 'Me.txtHrsEstandar.Text
        iBR.AsignacionClass.Kit = str(10) 'Me.txtKit.Text
        If Trim(str(1)) = "" Then
            iBR.AsignacionClass.Tractor = "0"
        Else
            iBR.AsignacionClass.Tractor = str(1) ' Me.txtUnidad.Text
        End If
        If iBR.AsignacionClass.Tractor <> "0" Then
            'Busca el parametro de Multicompania MILAC, Folio : 15491
            luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            lstrMultiCia = luoParm.GetParametro("despmulticompania", iBR.str_log, False)
            If UCase(lstrMultiCia) = "S" Then
                'Valida la informacion de los Pedidos y la Unidad, se envian como argumentos el Listado
                'de Pedidos, el Listado de Areas, la Unidad y la estructura del LOG como referencia.
                iBR.ValidaCompaniaPedidosUnidad(arrListaPedidos, arrListaPedidosAreas, iBR.AsignacionClass.Tractor, iBR.str_log)
            End If
        End If

        iBR.AsignacionClass.LineaRem1 = str(11) 'Me.txtLineaRem1.Text
        iBR.AsignacionClass.Remolque1 = str(12) 'Me.txtRemolque1.Text
        iBR.AsignacionClass.Dolly = str(13) 'Me.txtDolly.Text
        iBR.AsignacionClass.LineaRem2 = str(14) 'Me.txtLineaRem2.Text
        iBR.AsignacionClass.Remolque2 = str(15) 'Me.txtRemolque2.Text

        If iBR.AsignacionClass.Dolly.Length > 0 And iBR.AsignacionClass.Remolque1.Length = 0 Then
            Throw New Exception("Debe capturar el remolque1 ó limpiar el campo de Dolly")
        End If

        If iBR.AsignacionClass.Remolque2.Length > 0 Then
            If iBR.AsignacionClass.Remolque1.Length = 0 Then
                Throw New Exception("No es posible capturar el Remolque 2 cuando no se ha capturado el Remolque 1")
            Else
                If iBR.AsignacionClass.Remolque2 = iBR.AsignacionClass.Remolque1 And iBR.AsignacionClass.LineaRem2 = iBR.AsignacionClass.LineaRem1 Then
                    Throw New Exception("El Remolque 2 debe ser diferente al Remolque 1.")
                End If
            End If
        End If

        If Trim(iBR.AsignacionClass.Remolque1) <> "" Or iBR.AsignacionClass.LineaRem1 <> "" Then
            iBR.ValidaRemolque(iBR.AsignacionClass.LineaRem1, iBR.AsignacionClass.Remolque1, iBR.str_log) 'valida si existe
        End If
        If Trim(iBR.AsignacionClass.Remolque2) <> "" Or iBR.AsignacionClass.LineaRem2 <> "" Then
            iBR.ValidaRemolque(iBR.AsignacionClass.LineaRem2, iBR.AsignacionClass.Remolque2, iBR.str_log) 'valida si existe
        End If
        If IsNumeric(str(16)) Then
            iBR.AsignacionClass.Id_Flota = str(16) 'txtFlota
        End If

        iBR.AsignacionClass.Id_configuracionviaje = str(17) 'Me.ddlConfigViaje.SelectedValue

        'inicializa el valor del  operador 1 en caso de que sea vacio lo pone como cero
        If Trim(str(18)) = "" Then
            iBR.AsignacionClass.Operador1 = 0
        Else
            iBR.AsignacionClass.Operador1 = Trim(str(18))
        End If

        'inicializa el valor del  operador 2 en caso de que sea vacio lo pone como cero
        If Trim(str(19)) = "" Then
            iBR.AsignacionClass.Operador2 = 0
        Else
            iBR.AsignacionClass.Operador2 = Trim(str(19))
        End If

        If iBR.AsignacionClass.Operador2 <> 0 Then
            If iBR.AsignacionClass.Operador2 = iBR.AsignacionClass.Operador1 Then
                Throw New Exception("No es posible capturar dos veces el mismo operador.")
            End If
        End If

        If Trim(str(20)) = "" Then
            iBR.AsignacionClass.Observaciones = ""
        Else
            iBR.AsignacionClass.Observaciones = Trim(str(20))
        End If

        iBR.ListaPedidos = arrListaPedidos
        iBR.ListaPedidosAreas = arrListaPedidosAreas
        iBR.ListaPedidosPK = arrListaPedidosPK

        If arrListaPedidos.Count = 0 Then
            arrListaPedidos.Add("vacio")
            iBR.ListaPedidos = arrListaPedidos
        End If

        strReturn.Add(iBR.AsignacionClass.Viaje) '0  'Me.txtNumAsignacion.Text =
        strReturn.Add("") '1
        strReturn.Add("") '2
        strReturn.Add(arrListaPedidosPK.Count) '3
        If Trim(str(21)) = "" Then
            Throw New Exception("Favor de seleccionar un tipo de seguimiento valido.")
        End If
        iBR.AsignacionClass.SeguimientoNombreCorto = Trim(str(21)) '= Me.txtSeguimiento.Text

        'Se agrega la validación del parámetro de SU TRANSPORTE para actualizar la Fecha Recibido en
        'los Pedidos de la Asignación, emartinez 30-MARZO-2009
        Dim luoParam As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
        Dim lstrParam As String = ""
        'Se llama a la función GetParametro, se envian como argumentos el nombre del
        'parámetro, la estructura del LOG como referencia y una variable que indica
        'si se valida o no que existe el parámetro en la base de datos.
        lstrParam = luoParam.GetParametro("CAMBIOS_SUTRANSPORTE", iBR.str_log, False)
        If lstrParam = "S" Then iBR.AsignacionClass.ActualizaFechaRecibido = True

        'Se agregan los datos de CapacidadKG y CapacidadM3, emartinez , 20/Jun/2012
        iBR.AsignacionClass.Capacidad_CargaM3 = str(29)
        iBR.AsignacionClass.Capacidad_CargaKG = str(30)

        If str(31) <> "" Then
            iBR.AsignacionClass.Id_remitente = str(31)
        Else
            iBR.AsignacionClass.Id_remitente = "0"
        End If

        If str(32) <> "" Then
            iBR.AsignacionClass.Id_destinatario = str(32)
        Else
            iBR.AsignacionClass.Id_destinatario = "0"
        End If

        'iBR.CrearAsignacion(Me.txtLineaRem1Original.Text, Me.txtRemolque1Original.Text, Me.txtLineaRem2Original.Text, Me.txtRemolque2Original.Text)
        iBR.CrearAsignacion(Trim(str(22)), Trim(str(23)), Trim(str(24)), Trim(str(25)))

    End Sub

    Public Sub Actualizar(ByVal str() As String, ByRef strReturn As ArrayList)
        Dim luo_BR As New net_b_despextended.pre_b_despcrearviaje
        iBR.AsignacionClass.GetAsignacion(str(0), iBR.AsignacionClass, iBR.str_log)
        luo_BR.str_log = iBR.str_log
        iBR.AsignacionClass.Ruta = str(5) 'Me.txtRuta.Text
        iBR.AsignacionClass.F_prog_ini_viaje = str(6) 'Me.wdcInicioViaje.Value
        iBR.AsignacionClass.F_prog_fin_viaje = str(7) 'Me.wdcFinViaje.Value

        If Trim(str(1)) = "" Then
            iBR.AsignacionClass.Tractor = "0"
        Else
            iBR.AsignacionClass.Tractor = str(1) 'Me.txtUnidad.Text
        End If

        'Se agrega la validacion de la Multicompania, valida la informacion de la Asignacion y la Unidad.
        If iBR.AsignacionClass.Tractor <> "0" Then
            luoParm = New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            lstrMultiCia = luoParm.GetParametro("despmulticompania", luo_BR.str_log, False)
            If UCase(lstrMultiCia) = "S" Then
                'Obtiene la validacion directamente con la informacion de la Asignacion, se envian como
                'argumentos la Asignacion, la Unidad y la estructura del LOG como referencia.
                luo_BR.ValidaCompaniaAsignacionUnidad(str(0), iBR.AsignacionClass.Tractor, luo_BR.str_log)
            End If
        End If

        iBR.AsignacionClass.LineaRem1 = str(11) 'Me.txtLineaRem1.Text
        iBR.AsignacionClass.Remolque1 = str(12) 'Me.txtRemolque1.Text
        iBR.AsignacionClass.Dolly = str(13) 'Me.txtDolly.Text
        iBR.AsignacionClass.LineaRem2 = str(14) 'Me.txtLineaRem2.Text
        iBR.AsignacionClass.Remolque2 = str(15) 'Me.txtRemolque2.Text
        iBR.AsignacionClass.Id_configuracionviaje = str(17) 'Me.ddlConfigViaje.SelectedValue
        iBR.AsignacionClass.Kit = str(10) 'Me.txtKit.Text

        If iBR.AsignacionClass.Dolly.Length > 0 And iBR.AsignacionClass.Remolque1.Length = 0 Then
            Throw New Exception("Debe capturar el remolque1 ó limpiar el campo de Dolly")
        End If

        If iBR.AsignacionClass.Remolque2.Length > 0 Then
            If iBR.AsignacionClass.Remolque1.Length = 0 Then
                Throw New Exception("No es posible capturar el Remolque 2 cuando no se ha capturado el Remolque 1")
            Else
                If iBR.AsignacionClass.Remolque2 = iBR.AsignacionClass.Remolque1 And iBR.AsignacionClass.LineaRem2 = iBR.AsignacionClass.LineaRem1 Then
                    Throw New Exception("El Remolque 2 debe ser diferente al Remolque 1.")
                End If
            End If
        End If
        If Trim(iBR.AsignacionClass.Remolque1) <> "" Or iBR.AsignacionClass.LineaRem1 <> "" Then
            iBR.ValidaRemolque(iBR.AsignacionClass.LineaRem1, iBR.AsignacionClass.Remolque1, iBR.str_log) 'valida si existe
        End If
        If Trim(iBR.AsignacionClass.Remolque2) <> "" Or iBR.AsignacionClass.LineaRem2 <> "" Then
            iBR.ValidaRemolque(iBR.AsignacionClass.LineaRem2, iBR.AsignacionClass.Remolque2, iBR.str_log) 'valida si existe)
        End If
        If IsNumeric(str(16)) Then
            iBR.AsignacionClass.Id_Flota = str(16) 'txtFlota
        End If
            'inicializa el valor del  operador 1 en caso de que sea vacio lo pone como cero
            If Trim(str(18)) = "" Then
                iBR.AsignacionClass.Operador1 = 0
            Else
                iBR.AsignacionClass.Operador1 = str(18) 'Me.txtOperador1.Text
            End If

            'inicializa el valor del  operador 2 en caso de que sea vacio lo pone como cero
            If Trim(str(19)) = "" Then
                iBR.AsignacionClass.Operador2 = 0
            Else
                iBR.AsignacionClass.Operador2 = str(19) 'Me.txtOperador2.Text
            End If

            If iBR.AsignacionClass.Operador2 <> 0 Then
                If iBR.AsignacionClass.Operador2 = iBR.AsignacionClass.Operador1 Then
                    Throw New Exception("No es posible capturar dos veces el mismo operador.")
                End If
            End If

            If Trim(str(20)) = "" Then
                iBR.AsignacionClass.Observaciones = ""
            Else
                iBR.AsignacionClass.Observaciones = str(20) 'Me.txtObservaciones.Text
            End If

        If str(31) <> "" Then
            iBR.AsignacionClass.Id_remitente = str(31)
        Else
            iBR.AsignacionClass.Id_remitente = "0"
        End If

        If str(32) <> "" Then
            iBR.AsignacionClass.Id_destinatario = str(32)
        Else
            iBR.AsignacionClass.Id_destinatario = "0"
        End If

        strReturn.Add(iBR.AsignacionClass.Num_Asignacion) '0
        strReturn.Add("") '1
        strReturn.Add("") '2
        strReturn.Add(0) '3

        iBR.AsignacionClass.SeguimientoNombreCorto = str(21) 'Me.txtSeguimiento.Text
        'iBR.SalvarEdicion(Me.txtLineaRem1Original.Text, Me.txtRemolque1Original.Text, Me.txtLineaRem2Original.Text, Me.txtRemolque2Original.Text, iBR.str_log)
        iBR.SalvarEdicion(Trim(str(22)), Trim(str(23)), Trim(str(24)), Trim(str(25)), iBR.str_log)
    End Sub

    Private Sub ColumnasUnidades(ByVal idvista As Integer, ByVal atxtFlota As Integer, ByVal aidAsignacion As Integer, ByVal stridUnidad As String, ByVal bolViajeActual As Boolean, ByRef ldtDatos As Data.DataTable)
        Dim ldt_datos_det As New Data.DataTable
        Dim ldt_datos_query As New Data.DataTable
        Dim lCount As Integer = 0

        luo_br_layout.id_vista = idvista
        luo_br_layout.str_log = Session("strConn")

        ldt_datos_det = luo_br_layout.ObtenerVistaDetalle()
        ldt_datos_query = luo_br_layout.ObtenerQuery()

        If ldt_datos_query.Rows.Count > 0 Then
            Dim luoParam As New net_b_zamclasesextended.net_b_clasegeneralparametrosextended
            Dim strParametro, strWhere, strFiltroArea As String
            Dim ldtFiltros As New Data.DataTable
            Dim luoVG As net_b_zam.net_b_appvariables = Session("AppVariables")
            strParametro = luoParam.GetParametro("CAMBIOS_SUTRANSPORTE", luo_br_layout.str_log, False)
            If ldt_datos_query.Rows(0).Item("dwhere") = "" Then
                ldt_datos_query.Rows(0).Item("dwhere") = " WHERE "
            End If

            If strParametro = "S" Then
                strFiltroArea = " ( ASI.id_area in ( " & CStr(luoVG.AreasUnidades) & " ) OR ASI.id_area IS NULL )"
            Else
                strFiltroArea = " ( mtto_unidades.id_area in ( " & CStr(luoVG.AreasUnidades) & " ) )"
            End If

            If bolViajeActual = False Then
                strWhere = ldt_datos_query.Rows(0).Item("dwhere") + " ( mtto_unidades.estatus = 'A' ) AND " & strFiltroArea & _
                                        " AND ( mtto_unidades.tipo = 'T' ) AND (trafico_viaje.viajeactual in ( 'S' )  OR trafico_viaje.viajeactual IS NULL )  "
                'Else
                '    strWhere = ldt_datos_query.Rows(0).Item("dwhere") + " ( mtto_unidades.estatus = 'A' ) AND " & strFiltroArea & _
                '                                          " AND ( mtto_unidades.tipo = 'T' ) AND trafico_viaje.viajeactual in ( 'S' ) "
            Else
                strWhere = ldt_datos_query.Rows(0).Item("dwhere") + " ASI.id_asignacion = " & aidAsignacion
            End If

            'Hace el select en base al id_asignacion
            'strWhere = strWhere & "AND  ASI.id_asignacion = " & aidAsignacion
            strWhere = strWhere & " AND  mtto_unidades.id_unidad = '" & stridUnidad & "'"
            ldtDatos = luo_br_layout.ObtenerQuery("SELECT " & ldt_datos_query.Rows(0).Item("dselect"), ldt_datos_query.Rows(0).Item("dfrom"), strWhere)

        End If

    End Sub

    Public Sub ArregloArray(ByVal strCampos As String, ByVal strIdentifica As String, ByRef Array As ArrayList, ByRef astr_log As net_objestandar.str_log)
        Dim intPosicion As Integer, intIndex As Integer
        Dim strValor As String
        Array = New ArrayList
        'Obtiene la primer Posición
        intPosicion = InStr(strCampos.Substring(intIndex), strIdentifica)
        Do
            If intPosicion = 0 Then Exit Do
            intPosicion = intPosicion - 1
            strValor = strCampos.Substring(intIndex, intPosicion)
            Array.Add(strValor)
            intIndex = intIndex + intPosicion + 1
            intPosicion = InStr(strCampos.Substring(intIndex), strIdentifica)
        Loop
    End Sub
    'Metodo que verifica si el usuario no es uno de los pendientes por sacar de la aplicación o si no
    'a perdido la sesión en la aplicación. VHORTEGÓN 16/DICIEMBRE/2009
    Public Sub ValidaSesionUsuarios()
        Try
            If Not ConfigurationManager.AppSettings("ControlarConWS") Is Nothing Then
                If Session("UserName") Is Nothing Then
                    Response.Redirect(Application("myRoot") & "/sesion_terminada.aspx?SesionEnd=1") 'REDIRECCIONAMOS A LA PANTALLA DEL LOGIN.
                End If
                'VERIFICAMOS SI NO ES UNO DE LOS USUARIOS PENDIENTES POR SACAR DE LA APLICACIÓN
                If Application("UserOPV6_Eliminar").rows.count > 0 Then
                    For Each lrow As Data.DataRow In Application("UserOPV6_Eliminar").rows
                        If UCase(lrow.Item("usuario_lis")) = UCase(Session("UserName")) And UCase(lrow.Item("equipo_nombre")) = UCase(Session("UserEquipo")) Then
                            lrow.Delete()     'LO ELIMINAMOS DEL LISATADO DE PENDIENTES DE ELIMINAR
                            Session("SesionEndBySystem") = "1"
                            Exit For
                        End If
                    Next
                End If
                'SI VIENE CON VALOR A 1 SIGNIFICA QUE ESTA PENDIENTE POR SACAR DEL SISTEMA.
                If Not Session("SesionEndBySystem") Is Nothing Then
                    If Session("SesionEndBySystem") = "1" Then
                        Session("SesionEndBySystem") = Nothing
                        'LO REDIRECCIONA A LA PAGINA DE AVISO QUE FUE TERMINADA SU SESIÓN POR EL ADMINISTRADOR DEL
                        'SISTEMA Y ABANDONA LA SESIÓN.
                        Response.Redirect(Application("myRoot") & "/sesion_terminada.aspx")
                    End If
                End If
            Else 'ENTRA CUANO NO LO VA A VALIDAR DESDE EL WS DEL CONTROL DE LAS LICENCIAS.
                If Session("UserName") Is Nothing Then
                    Response.Redirect(Application("myRoot") & "/sesion_terminada.aspx?SesionEnd=1") 'REDIRECCIONAMOS A LA PANTALLA DEL LOGIN.
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
