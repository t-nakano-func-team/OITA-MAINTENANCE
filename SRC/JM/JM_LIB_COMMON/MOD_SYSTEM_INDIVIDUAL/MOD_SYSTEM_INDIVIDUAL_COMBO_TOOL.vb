﻿Public Module MOD_SYSTEM_INDIVIDUAL_COMBO_TOOL

#Region "JM_M_KIND"
    Public Sub SUB_SYSTEM_COMMBO_JM_M_KIND(
    ByRef CMB_COMBO_BOX As Object,
    ByVal ENM_CODE_FLAG As ENM_JM_M_KIND_CODE_FLAG,
    Optional ByVal BLN_VIEW_NULL As Boolean = False,
    Optional ByVal STR_NAME_ALL As String = "",
    Optional ByVal STR_CODE_KIND_IN As String = ""
    )

        Call SUB_END_COMBO_KIND(CMB_COMBO_BOX) '渡されたコンボを初期化(データリンクなどの破棄)

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("CODE_KIND AS CODE," & Environment.NewLine)
            Call .Append("NAME_KIND AS NAME" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_M_KIND" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("CODE_FLAG=" & ENM_CODE_FLAG & Environment.NewLine)
            If Not (STR_CODE_KIND_IN = "") Then
                Call .Append("AND CODE_KIND IN(" & STR_CODE_KIND_IN & ")" & Environment.NewLine)
            End If
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("CODE_FLAG,CODE_KIND" & Environment.NewLine)
        End With

        Dim SDR_READER As SqlClient.SqlDataReader 'データリーダー
        SDR_READER = Nothing '初期化
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            SDR_READER = Nothing
            Exit Sub
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Exit Sub
        End If

        Dim STR_COMBO_STRING() As srtLComboDataArray
        ReDim STR_COMBO_STRING(-1)

        Dim INT_LOOP_INDEX As Integer
        INT_LOOP_INDEX = 0

        If BLN_VIEW_NULL Then
            ReDim STR_COMBO_STRING(0)
            INT_LOOP_INDEX += 1
            ReDim Preserve STR_COMBO_STRING(INT_LOOP_INDEX)
            ReDim STR_COMBO_STRING(INT_LOOP_INDEX).strLOneRecord(1)
            With STR_COMBO_STRING(INT_LOOP_INDEX)
                .strLOneRecord(0) = -1
                .strLOneRecord(1) = STR_NAME_ALL
            End With
        End If

        Do While SDR_READER.Read
            INT_LOOP_INDEX += 1
            ReDim Preserve STR_COMBO_STRING(INT_LOOP_INDEX)
            ReDim STR_COMBO_STRING(INT_LOOP_INDEX).strLOneRecord(1)
            With STR_COMBO_STRING(INT_LOOP_INDEX)
                .strLOneRecord(0) = CInt(SDR_READER.Item("CODE"))
                .strLOneRecord(1) = CStr(SDR_READER.Item("NAME"))
            End With
        Loop

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim DAT_COMBO_ITEM As clsGComboBoxData
        For i = 1 To UBound(STR_COMBO_STRING)
            DAT_COMBO_ITEM = New clsGComboBoxData(STR_COMBO_STRING(i).strLOneRecord, Nothing, 1)
            CMB_COMBO_BOX.Items.Add(DAT_COMBO_ITEM)
            DAT_COMBO_ITEM = Nothing
        Next

        ReDim STR_COMBO_STRING(0)
        Erase STR_COMBO_STRING
    End Sub
#End Region

#Region "JM_M_CONNECTION"
    Public Sub SUB_SYSTEM_COMMBO_JM_M_CONNECTION(
    ByRef CMB_COMBO_BOX As Object,
    Optional ByVal BLN_VIEW_NULL As Boolean = False,
    Optional ByVal STR_NAME_ALL As String = ""
    )
        Call SUB_END_COMBO_KIND(CMB_COMBO_BOX) '渡されたコンボを初期化(データリンクなどの破棄)

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("CODE_CONNECTION AS CODE," & Environment.NewLine)
            Call .Append("NAME_CONNECTION AS NAME" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("JM_M_CONNECTION" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("CODE_CONNECTION" & Environment.NewLine)
        End With

        Dim SDR_READER As SqlClient.SqlDataReader 'データリーダー
        SDR_READER = Nothing '初期化
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            SDR_READER = Nothing
            Exit Sub
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Exit Sub
        End If

        Dim STR_COMBO_STRING() As srtLComboDataArray
        ReDim STR_COMBO_STRING(-1)

        Dim INT_LOOP_INDEX As Integer
        INT_LOOP_INDEX = 0

        If BLN_VIEW_NULL Then
            ReDim STR_COMBO_STRING(0)
            INT_LOOP_INDEX += 1
            ReDim Preserve STR_COMBO_STRING(INT_LOOP_INDEX)
            ReDim STR_COMBO_STRING(INT_LOOP_INDEX).strLOneRecord(1)
            With STR_COMBO_STRING(INT_LOOP_INDEX)
                .strLOneRecord(0) = -1
                .strLOneRecord(1) = STR_NAME_ALL
            End With
        End If

        Do While SDR_READER.Read
            INT_LOOP_INDEX += 1
            ReDim Preserve STR_COMBO_STRING(INT_LOOP_INDEX)
            ReDim STR_COMBO_STRING(INT_LOOP_INDEX).strLOneRecord(1)
            With STR_COMBO_STRING(INT_LOOP_INDEX)
                .strLOneRecord(0) = CInt(SDR_READER.Item("CODE"))
                .strLOneRecord(1) = CStr(SDR_READER.Item("NAME"))
            End With
        Loop

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim DAT_COMBO_ITEM As clsGComboBoxData
        For i = 1 To UBound(STR_COMBO_STRING)
            DAT_COMBO_ITEM = New clsGComboBoxData(STR_COMBO_STRING(i).strLOneRecord, Nothing, 1)
            CMB_COMBO_BOX.Items.Add(DAT_COMBO_ITEM)
            DAT_COMBO_ITEM = Nothing
        Next

        ReDim STR_COMBO_STRING(0)
        Erase STR_COMBO_STRING
    End Sub
#End Region

End Module
