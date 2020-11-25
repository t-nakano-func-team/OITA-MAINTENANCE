Public Module MOD_SYSTEM_INDIVISUAL_INITIALIZATION_FINALIZATION

#Region "外出変数"
    Public STR_FUNC_SYSTEM_INDIVISUAL_INITIALIZATION_MSG As String 'システム初期化処理のメッセージ
    Public STR_FUNC_SYSTEM_INDIVISUAL_FINALIZATION_MSG As String 'システム終了処理のメッセージ
#End Region

    Public Function FUNC_SYSTEM_INDIVISUAL_INITIALIZATION() As Boolean
        STR_FUNC_SYSTEM_INDIVISUAL_INITIALIZATION_MSG = ""

        If Not FUNC_GET_DB_VALUE() Then
            STR_FUNC_SYSTEM_INDIVISUAL_INITIALIZATION_MSG = "DB設定値の取得に失敗しました"
            Return False
        End If

        Return True
    End Function

#Region "内部処理"
    Private Function FUNC_GET_DB_VALUE() As Boolean
        INT_SYSTEM_INDIVIDUAL_NUMBER_USER = FUNC_GET_JM_M_USER_NUMBER_USER(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        If INT_SYSTEM_INDIVIDUAL_NUMBER_USER <= 0 Then
            Return False
        End If
        Return True
    End Function

#End Region
End Module
