Public Module MOD_SYSTEM_INDIVIDUAL_SHOW_SEARCH

End Module

#Region "オーナー検索"
Public Module MOD_SYSTEM_INDIVIDUAL_SHOW_SEARCH_OWNER
    Private Const CST_APPL_NAME As String = "オーナー検索"

    Public Function FUNC_SHOW_SYSTEM_INDIVIDUAL_SEARCH_OWNER(
    ByRef INT_CODE_OWNER As Integer,
    ByVal SNG_FONT_SIZE As Single,
    Optional ByVal BLN_VIEW_INVALID As Boolean = False
    ) As Boolean


        Dim FRM_SHOW As FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER
        FRM_SHOW = New FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER
        If SNG_FONT_SIZE = 0.0 Then
            SNG_FONT_SIZE = FRM_SHOW.Font.Size
        End If
        FRM_SHOW.Font = New System.Drawing.Font(FRM_SHOW.Font.Name, SNG_FONT_SIZE)
        FRM_SHOW.Text = CST_APPL_NAME

        Call FRM_SHOW.ShowDialog()

        INT_CODE_OWNER = FRM_SHOW.RET_CODE

        Dim BLN_RET As Boolean
        BLN_RET = Not (FRM_SHOW.RET_SEARCH_CANCEL)

        Call FRM_SHOW.Dispose()

        Return BLN_RET

    End Function

End Module

#End Region

#Region "契約検索"
Public Module MOD_SYSTEM_INDIVIDUAL_SHOW_SEARCH_CONTRACT
    Private Const CST_APPL_NAME As String = "契約検索"

    Public Function FUNC_SHOW_SYSTEM_INDIVIDUAL_SEARCH_CONTRACT(
    ByRef SRT_NS_CONTRACT As SRT_NUMBER_SERIAL_CONTRACT,
    ByVal SNG_FONT_SIZE As Single,
    Optional ByVal BLN_VIEW_INVALID As Boolean = False
    ) As Boolean


        Dim FRM_SHOW As FRM_SYSTEM_INDIVIDUAL_SEARCH_CONTRACT
        FRM_SHOW = New FRM_SYSTEM_INDIVIDUAL_SEARCH_CONTRACT
        If SNG_FONT_SIZE = 0.0 Then
            SNG_FONT_SIZE = FRM_SHOW.Font.Size
        End If
        FRM_SHOW.Font = New System.Drawing.Font(FRM_SHOW.Font.Name, SNG_FONT_SIZE)
        FRM_SHOW.Text = CST_APPL_NAME

        Call FRM_SHOW.ShowDialog()

        SRT_NS_CONTRACT = FRM_SHOW.RET_CODE

        Dim BLN_RET As Boolean
        BLN_RET = Not (FRM_SHOW.RET_SEARCH_CANCEL)

        Call FRM_SHOW.Dispose()

        Return BLN_RET

    End Function

End Module

#End Region