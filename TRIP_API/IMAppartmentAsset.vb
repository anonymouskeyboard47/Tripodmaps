
Option Explicit On 
'Option Strict On

Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections

Public Class IMAppartmentAsset


#Region "PrivateVariables"

    Private lFixedAssetID As Long
    Private lAppartmentID As Long

#End Region


#Region "Properties"

    Public Property AppartmentID() As Long

        Get
            Return lAppartmentID
        End Get

        Set(ByVal Value As Long)
            lAppartmentID = Value
        End Set

    End Property

    Public Property FixedAssetID() As Long

        Get
            Return lFixedAssetID
        End Get

        Set(ByVal Value As Long)
            lFixedAssetID = Value
        End Set

    End Property

#End Region


#Region "InitializationProcedures"

    Public Sub New()
        MyBase.New()
    End Sub

#End Region


#Region "DatabaseProcedures"

    Public Function Save(ByVal DisplayErrorMessages As Boolean, _
        ByVal DisplayConfirmation As Boolean, _
            ByVal DisplayFailure As Boolean, _
                ByVal DisplaySuccess As Boolean) As Boolean

        Dim strSaveQuery As String
        Dim datSaved As DataSet = New DataSet
        Dim bSaveSuccess As Boolean
        Dim objLogin As IMLogin = New IMLogin
        Dim strInsertInto As String


        Try

            If lFixedAssetID = 0 Or _
                lAppartmentID = 0 Then

                If DisplayErrorMessages = True Then

                    ReturnError += "Please provide the Fixed Asset and the Appartment that you want to save"

                End If

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If


            If Find("SELECT * FROM AppartmentAsset WHERE " & _
            "FixedAssetID = " & lFixedAssetID, False) = True Then

                Update("UPDATE AppartmentAsset SET " & _
                            "FixedAssetID = " & lFixedAssetID & _
                            " WHERE AppartmentID = " & lAppartmentID)

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If


            'If MsgBox(" Are you sure you want to add this Appartment?", _
            '            MsgBoxStyle.YesNo, _
            '            "iManagement - Add New Record?") = _
            '            MsgBoxResult.No Then

            '    datSaved = Nothing
            '    objLogin = Nothing
            '    Exit Function
            'End If


            strInsertInto = "INSERT INTO AppartmentAsset (" & _
                "FixedAssetID," & _
                "FixedAssetID" & _
                    ") VALUES "

            strSaveQuery = strInsertInto & _
                    "(" & lFixedAssetID & _
                    "," & lAppartmentID & _
                            ")"

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bSaveSuccess = objLogin.ExecuteQuery _
                (strOrgAccessConnString, strSaveQuery, datSaved)


            objLogin.CloseDb()

            If bSaveSuccess = True Then
                If DisplaySuccess = True Then

                    ReturnError += "Fixed Asset-Appartment Saved " & _
                    "Successfully."

                End If

                Return True

            Else

                If DisplayFailure = True Then

                    ReturnError += "'Save Fixed Asset-Appartment' action failed." & _
            " Make sure all mandatory details are entered."

                End If

                objLogin = Nothing
                datSaved = Nothing

                Exit Function

            End If

            objLogin = Nothing
            datSaved = Nothing


        Catch ex As Exception
            If DisplayErrorMessages = True Then
                ReturnError += ex.Message.ToString

            End If
        End Try

    End Function

    Public Function Find(ByVal strQuery As String, _
                        ByVal ReturnStatus As Boolean) As Boolean
        'Query must contain at least rows from Sequence

        Try

            Dim datRetData As DataSet = New DataSet
            Dim bQuerySuccess As Boolean
            Dim myDataTables As DataTable
            Dim myDataColumns As DataColumn
            Dim myDataRows As DataRow
            Dim objLogin As IMLogin = New IMLogin

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bQuerySuccess = objLogin.ExecuteQuery _
                    (strOrgAccessConnString, strQuery, datRetData)

            objLogin.CloseDb()

            If datRetData Is Nothing Then
                Exit Function
            End If

            If bQuerySuccess = True Then

                Dim i As Integer

                For Each myDataTables In datRetData.Tables

                    'Check if there is any data. If not exit
                    If myDataTables.Rows.Count = 0 Then

                        'Return a value indicating that the search was not successful
                        datRetData = Nothing
                        objLogin = Nothing

                        Return False
                        Exit Function

                    End If

                    'Whether to fill properties with values or not
                    If ReturnStatus = True Then

                        For Each myDataRows In myDataTables.Rows

                            lFixedAssetID = _
                                myDataRows("FixedAssetID")
                            lAppartmentID = _
                                myDataRows("AppartmentID")

                        Next
                    End If
                Next

                Return True

            End If



        Catch ex As Exception
            ReturnError += ex.Message.ToString

        End Try

    End Function

    Public Function Delete(Optional ByVal bDisplayError As Boolean = False, _
    Optional ByVal bDisplayConfirm As Boolean = False, _
    Optional ByVal bDisplaySuccess As Boolean = False) As Boolean

        Try

            Dim strDeleteQuery As String
            Dim datDelete As DataSet = New DataSet
            Dim bDelSuccess As Boolean
            Dim objLogin As IMLogin = New IMLogin

            If lFixedAssetID = 0 Then
                ReturnError += "Cannot Delete. Please select an " & _
                    "existing Building Detail"

                datDelete = Nothing
                objLogin = Nothing

                Exit Function
            End If

            'If bDisplayConfirm = True Then
            '    If MsgBox(" Are you sure you want to Delete this Appartment?", _
            '                             MsgBoxStyle.YesNo, _
            '                             "iManagement - Delete Record?") = _
            '                              MsgBoxResult.No Then

            '        datDelete = Nothing
            '        objLogin = Nothing
            '        Exit Function
            '    End If
            'End If


            strDeleteQuery = "DELETE * FROM AppartmentAsset WHERE " & _
            "FixedAssetID = " & lFixedAssetID

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bDelSuccess = objLogin.ExecuteQuery(strOrgAccessConnString, _
            strDeleteQuery, datDelete)

            objLogin.CloseDb()

            datDelete = Nothing
            objLogin = Nothing

            If bDelSuccess = True Then
                ReturnError += "Fixed Asset-to-Appartment Details Deleted"
                Return True
            Else

                ReturnError += "'Delete Fixed Asset-to-Appartment link' action failed"

            End If

        Catch ex As Exception

        End Try

    End Function

    Public Sub Update(ByVal strUpQuery As String)

        Try

            Dim strUpdateQuery As String
            Dim datUpdated As DataSet = New DataSet
            Dim bUpdateSuccess As Boolean
            Dim objLogin As IMLogin = New IMLogin

            strUpdateQuery = strUpQuery

            If lFixedAssetID <> 0 Then

                objLogin.ConnectString = strOrgAccessConnString
                objLogin.ConnectToDatabase()

                bUpdateSuccess = objLogin.ExecuteQuery _
                                (strOrgAccessConnString, _
                                    strUpdateQuery, datUpdated)

                objLogin.CloseDb()

                If bUpdateSuccess = True Then
                    ReturnError += "Fixed Asset-to-Appartment details updated Successfully"
                End If

            End If

            datUpdated = Nothing
            objLogin = Nothing


        Catch ex As Exception

        End Try

    End Sub

#End Region


End Class
