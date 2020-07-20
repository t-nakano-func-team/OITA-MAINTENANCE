Module MOD_MAIN
    Private Const CST_APPL_NAME As String = "入金連携データ作成"
    Friend BLN_SHOW_SETTING As Boolean

    Public Sub MAIN(ByVal STR_COMMAND_LINE() As String)

        If Not FUNC_SYSTEM_TOTAL_INITIALIZATION(STR_COMMAND_LINE) Then
            Call MessageBox.Show(str_FUNC_SYSTEM_TOTAL_INITIALIZATION_MSG, CST_APPL_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        BLN_SHOW_SETTING = False
        Dim SNG_FONT_SIZE As Single
        SNG_FONT_SIZE = 0.0

        Do
            If BLN_SHOW_SETTING Then
                Call FUNC_SHOW_DIALOG_FONT_SETTING(SNG_FONT_SIZE)
                BLN_SHOW_SETTING = False
            End If

            Dim FRM_MAIN As Form
            FRM_MAIN = New FRM_MAIN
            Call SUB_SYSTEM_TOTAL_INIT_FONT(SNG_FONT_SIZE, FRM_MAIN.Font.Size)
            Dim SRT_PARAM As SRT_FORM_SETTING_PARAM
            With SRT_PARAM
                .TEXT = CST_APPL_NAME
                .FONT_SIZE = SNG_FONT_SIZE
                Erase .BACK_COLOR
                Call SUB_SET_FORM_SETTING_COLOR(.BACK_COLOR)
            End With
            Call SUB_INIT_FORM_SETTING(FRM_MAIN, SRT_PARAM)
            Call FRM_MAIN.ShowDialog()
            Call FRM_MAIN.Dispose()
            If Not BLN_SHOW_SETTING Then
                Exit Do
            End If
        Loop

        Call FUNC_SYSTEM_TOTAL_CALL_BACK_APPL()
        Call Application.DoEvents()

        Call FUNC_SYSTEM_TOTAL_FINALIZATION()
    End Sub

    Private Sub SUB_SET_FORM_SETTING_COLOR(ByRef SRT_BACK_COLOR() As System.Drawing.Color)

        ReDim SRT_BACK_COLOR(ENM_COLOR_SET_LEVEL.UBOUND)

        Dim STR_TEMP As String
        STR_TEMP = FUNC_SYSTEM_TOTAL_GET_APP_CONFIG(CST_SYSTEM_TOTAL_APP_CONFIG_STR_BCF)
        SRT_BACK_COLOR(ENM_COLOR_SET_LEVEL.FORM) = FUNC_GET_COLOR_FROM_STR(STR_TEMP)

        STR_TEMP = FUNC_SYSTEM_TOTAL_GET_APP_CONFIG(CST_SYSTEM_TOTAL_APP_CONFIG_STR_BCG)
        SRT_BACK_COLOR(ENM_COLOR_SET_LEVEL.GROUP) = FUNC_GET_COLOR_FROM_STR(STR_TEMP)

        STR_TEMP = FUNC_SYSTEM_TOTAL_GET_APP_CONFIG(CST_SYSTEM_TOTAL_APP_CONFIG_STR_BCP)
        SRT_BACK_COLOR(ENM_COLOR_SET_LEVEL.PANEL) = FUNC_GET_COLOR_FROM_STR(STR_TEMP)

        STR_TEMP = FUNC_SYSTEM_TOTAL_GET_APP_CONFIG(CST_SYSTEM_TOTAL_APP_CONFIG_STR_BCO)
        SRT_BACK_COLOR(ENM_COLOR_SET_LEVEL.OBJ) = FUNC_GET_COLOR_FROM_STR(STR_TEMP)

    End Sub
End Module
