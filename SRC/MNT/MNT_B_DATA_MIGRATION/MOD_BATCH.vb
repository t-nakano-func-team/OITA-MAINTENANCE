Module MOD_BATCH

#Region "バッチ用・定数"
#End Region

#Region "バッチ用列挙定数"
    Private Enum ENM_XLSX_INDEX
        CODE_STORE = 1
        CODE_CLASS00 = 3
        CODE_CLASS01
        CODE_CLASS02
        CODE_GOODS

        CUR_INGAI_OLD = 8
        CUR_KUMIAI_OLD

        CUR_INGAI_PROSPECT = 12
        CUR_KUMIAI_PROSPECT

        CUR_INGAI_INPUT = 14
        CUR_KUMIAI_INPUT
    End Enum
#End Region

#Region "バッチ用・構造体"
    Public Structure SRT_BATCH_CONDITIONS 'バッチ条件
        Public FILE_PATH_GET As String

        Public DATE_DO_BATCH As DateTime
        Public FORM As Object
    End Structure

    Private Structure SRT_XLSX_INFO 'XLSXファイル構造
        Public CODE_STORE As Integer
        Public CODE_CLASS00 As Integer
        Public CODE_CLASS01 As Integer
        Public CODE_CLASS02 As Integer
        Public CODE_GOODS As Integer

        Public CUR_INGAI_OLD As Decimal
        Public CUR_KUMIAI_OLD As Decimal

        Public CUR_INGAI_PROSPECT As Decimal
        Public CUR_KUMIAI_PROSPECT As Decimal

        Public CUR_INGAI_INPUT As Decimal
        Public CUR_KUMIAI_INPUT As Decimal
        Public BLN_INGAI_INPUT As Boolean
        Public BLN_KUMIAI_INPUT As Boolean

        Public CUR_INGAI_SET As Decimal
        Public CUR_KUMIAI_SET As Decimal
    End Structure
#End Region

#Region "バッチ用・変数"
    Friend STR_FUNC_BATCH_MAIN_ERR_STR As String '最終エラー文字列
#End Region

    Friend Function FUNC_BACTH_MAIN(ByRef BLN_PUT As Boolean, ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS, ByRef INT_COUNT As Integer) As Boolean
        BLN_PUT = False
        INT_COUNT = 0

        Dim SRT_FILE() As SRT_XLSX_INFO
        ReDim SRT_FILE(0)

        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "Excelファイル読込中：" & SRT_CONDITIONS.FILE_PATH_GET & "")
        If Not FUNC_GET_FILE_DATA_FROM_XLSX(SRT_CONDITIONS.FILE_PATH_GET, SRT_FILE) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = "ファイルの読取に失敗しました。" & System.Environment.NewLine & SRT_CONDITIONS.FILE_PATH_GET
            Return False
        End If
        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "")


        Return True
    End Function

#Region "内部処理"
    Private Function FUNC_GET_FILE_DATA_FROM_XLSX(ByVal STR_FILE_PATH As String, ByRef SRT_FILE() As SRT_XLSX_INFO) As Boolean
        ReDim SRT_FILE(0)

        If Not FUNC_INIT_XLS(STR_FILE_PATH) Then
            Return False
        End If

        Dim INT_ROW As Integer

        INT_ROW = 0
        Do
            INT_ROW += 1
            If INT_ROW <= 1 Then 'ヘッダ読飛
                Continue Do
            End If

            Dim STR_TEMP As String
            STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CODE_STORE)
            If Not IsNumeric(STR_TEMP) Then
                Exit Do
            End If

            Dim INT_INDEX As Integer
            INT_INDEX = SRT_FILE.Length
            ReDim Preserve SRT_FILE(INT_INDEX)
            With SRT_FILE(INT_INDEX)
                .CODE_STORE = CInt(STR_TEMP)
                Try
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CODE_CLASS00)
                    .CODE_CLASS00 = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CODE_CLASS01)
                    .CODE_CLASS01 = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CODE_CLASS02)
                    .CODE_CLASS02 = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CODE_GOODS)
                    .CODE_GOODS = CInt(STR_TEMP)

                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CUR_INGAI_OLD)
                    .CUR_INGAI_OLD = CDec(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CUR_KUMIAI_OLD)
                    .CUR_KUMIAI_OLD = CDec(STR_TEMP)

                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CUR_INGAI_PROSPECT)
                    .CUR_INGAI_PROSPECT = CDec(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CUR_KUMIAI_PROSPECT)
                    .CUR_KUMIAI_PROSPECT = CDec(STR_TEMP)

                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CUR_INGAI_INPUT)
                    .BLN_INGAI_INPUT = IsNumeric(STR_TEMP)
                    If Not .BLN_INGAI_INPUT Then
                        .BLN_KUMIAI_INPUT = False
                    End If
                    .CUR_INGAI_INPUT = CDec(FUNC_VALUE_CONVERT_NUMERIC(STR_TEMP, 0))
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.CUR_KUMIAI_INPUT)
                    .BLN_KUMIAI_INPUT = IsNumeric(STR_TEMP)
                    .CUR_KUMIAI_INPUT = CDec(FUNC_VALUE_CONVERT_NUMERIC(STR_TEMP, 0))
                Catch ex As Exception
                    Call FUNC_END_XLS()
                    Return False
                End Try
            End With
        Loop

        Call FUNC_END_XLS()

        Return True
    End Function
#End Region

#Region "内部処理（汎用）"
    Private Sub SUB_PUT_GUIDE(ByRef OBJ_FORM As Object, ByVal STR_GUIDE As String)
        Call OBJ_FORM.SUB_PUT_PROGRESS_GUIDE(STR_GUIDE)
    End Sub
#End Region

End Module
