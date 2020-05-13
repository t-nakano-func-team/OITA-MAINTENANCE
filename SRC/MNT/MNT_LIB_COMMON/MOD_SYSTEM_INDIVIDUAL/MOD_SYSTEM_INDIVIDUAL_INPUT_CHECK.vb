Public Module MOD_SYSTEM_INDIVIDUAL_INPUT_CHECK

    Public Enum ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK
        CHK_OK = 0 'チェックOK（エラーなし）
        CHK_ERR_NO_DATA 'データが存在しない
        CHK_ERR_DISABLED 'データが無効（入力不可）
        CHK_ERR_FROM_TO '大小関係が異常
        CHK_ERR_OVERLAP '重複
        CHK_ERR_INVALID '不正
    End Enum

    Public Function FUNC_GET_INPUT_CHECK_ERROR_MESSAGE(ByVal ENM_ERROR As ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK, ByVal STR_GUIDE_NAME As String) As String
        Dim STR_RET As String
        STR_RET = ""

        Dim STR_MESSAGE As String
        Select Case ENM_ERROR
            Case ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK.CHK_OK
                STR_RET = ""
            Case ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK.CHK_ERR_NO_DATA
                STR_MESSAGE = "存在しません。"
                If STR_GUIDE_NAME = "" Then
                    STR_RET = STR_MESSAGE
                Else
                    STR_RET = "入力された" & STR_GUIDE_NAME & "が" & STR_MESSAGE
                End If
            Case ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK.CHK_ERR_DISABLED
                STR_MESSAGE = "使用できません。"
                If STR_GUIDE_NAME = "" Then
                    STR_RET = STR_MESSAGE
                Else
                    STR_RET = "入力された" & STR_GUIDE_NAME & "は" & STR_MESSAGE
                End If
            Case ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK.CHK_ERR_FROM_TO
                STR_MESSAGE = "相関に誤りがあります。"
                If STR_GUIDE_NAME = "" Then
                    STR_RET = STR_MESSAGE
                Else
                    STR_RET = "" & STR_GUIDE_NAME & "の" & STR_MESSAGE
                End If
            Case ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK.CHK_ERR_OVERLAP
                STR_MESSAGE = "重複しています。"
                If STR_GUIDE_NAME = "" Then
                    STR_RET = STR_MESSAGE
                Else
                    STR_RET = "" & STR_GUIDE_NAME & "が" & STR_MESSAGE
                End If
            Case ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK.CHK_ERR_INVALID
                STR_MESSAGE = "不正です。"
                If STR_GUIDE_NAME = "" Then
                    STR_RET = STR_MESSAGE
                Else
                    STR_RET = "" & STR_GUIDE_NAME & "が" & STR_MESSAGE
                End If
            Case Else
                STR_MESSAGE = ""
                STR_RET = STR_MESSAGE
        End Select

        Return STR_RET
    End Function
End Module
