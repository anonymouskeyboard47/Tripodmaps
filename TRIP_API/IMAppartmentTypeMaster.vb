
Option Explicit On 
'Option Strict On

Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections

Public Class IMAppartmentTypeMaster


#Region "PrivateVariables"

    Private strAppartmentTypeName As String
    Private lAppartmentTypeID As Long
    Private strAppartmentTypeDescription As String
    Private dtDateCreated As String

#End Region


#Region "Properties"

    Public Property AppartmentTypeID() As Long

        Get
            Return lAppartmentTypeID
        End Get

        Set(ByVal Value As Long)
            lAppartmentTypeID = Value
        End Set

    End Property

    Public Property AppartmentTypeName() As String

        Get
            Return strAppartmentTypeName
        End Get

        Set(ByVal Value As String)
            strAppartmentTypeName = Value
        End Set

    End Property

    Public Property AppartmentTypeDescription() As String

        Get
            Return strAppartmentTypeDescription
        End Get

        Set(ByVal Value As String)
            strAppartmentTypeDescription = Value
        End Set

    End Property

    Public Property DateCreated() As Date

        Get
            Return dtDateCreated
        End Get

        Set(ByVal Value As Date)
            dtDateCreated = Value
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

            If Trim(strAppartmentTypeName) = "" Or _
                Trim(strAppartmentTypeDescription) = "" Then

                If DisplayErrorMessages = True Then

                    ReturnError += "Please provide both the Appartment " & _
                        "Type title and the Description for this title e.g. 'Fully Furnished' for the " & _
                            "title and 'This is an appartment that " & _
                                "has ready furniture'"

                End If

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If


            If Find("SELECT * FROM AppartmentBuilding WHERE " & _
            "AppartmentTypeID = " & lAppartmentTypeID, False) = True Then

                Update("UPDATE AppartmentBuilding SET " & _
                            " AppartmentTypeName = '" & _
                                strAppartmentTypeName & _
                            "' AppartmentTypeDescription = '" & _
                                strAppartmentTypeDescription & _
                            "' WHERE AppartmentTypeID = " & _
                                lAppartmentTypeID & _
                            " OR AppartmentTypeName = '" & _
                                strAppartmentTypeName & "'")

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


            strInsertInto = "INSERT INTO AppartmentBuilding (" & _
                "AppartmentTypeName," & _
                "AppartmentTypeDescription" & _
                    ") VALUES "

            strSaveQuery = strInsertInto & _
                    "('" & strAppartmentTypeName & _
                    "','" & strAppartmentTypeDescription & _
                            "')"

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bSaveSuccess = objLogin.ExecuteQuery _
                (strOrgAccessConnString, strSaveQuery, datSaved)


            objLogin.CloseDb()

            If bSaveSuccess = True Then
                If DisplaySuccess = True Then

                    ReturnError += "Appartment Type Saved Successfully."

                End If

                Return True

            Else

                If DisplayFailure = True Then

                    ReturnError += "'Save Appartment Type' action failed." & _
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

                            strAppartmentTypeName = _
                                myDataRows("AppartmentTypeName")
                            lAppartmentTypeID = _
                                myDataRows("AppartmentTypeID")
                            strAppartmentTypeDescription = _
                                myDataRows("AppartmentTypeDescription")
                            dtDateCreated = _
                                myDataRows("DateCreated")

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

            If lAppartmentTypeID = 0 Then
                ReturnError += "Cannot Delete. Please select an " & _
                    "existing Appartment Type Detail"

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


            strDeleteQuery = "DELETE * FROM AppartmentBuilding WHERE " & _
            "AppartmentTypeID = " & lAppartmentTypeID

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bDelSuccess = objLogin.ExecuteQuery(strOrgAccessConnString, _
            strDeleteQuery, datDelete)

            objLogin.CloseDb()

            datDelete = Nothing
            objLogin = Nothing

            If bDelSuccess = True Then

                ReturnError += "Appartment Type's Details Deleted"
                Return True

            Else

                ReturnError += "'Delete Appartment Type's action failed"

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

            If strAppartmentTypeName <> 0 Then

                objLogin.ConnectString = strOrgAccessConnString
                objLogin.ConnectToDatabase()

                bUpdateSuccess = objLogin.ExecuteQuery _
                                (strOrgAccessConnString, _
                                    strUpdateQuery, datUpdated)

                objLogin.CloseDb()

                If bUpdateSuccess = True Then
                    ReturnError += "Appartment Type's details updated " & _
                        "successfully"
                End If

            End If

            datUpdated = Nothing
            objLogin = Nothing


        Catch ex As Exception

        End Try

    End Sub

#End Region


End Class
