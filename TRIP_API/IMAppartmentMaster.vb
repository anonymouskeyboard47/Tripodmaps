
Option Explicit On 
'Option Strict On

Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections

Public Class IMAppartmentMaster
    Inherits IMAppartmentBuilding


#Region "PrivateVariables"

    Private strAppartmentNumber As String
    Private lAppartmetTypeID As Long
    Private dtAppartmentConstructed As Date
    Private dbAppartmentSize As Double
    Private lAppartmentNoOfExitDoors As Long
    Private dbAppartmentVolume As Double
    Private strAppartmentPicture As String
    Private dtDateCreated As Date
    Private lAppartmentNoOfWindows As Long
    Private strAppartmentHousingNumber As String
    Private strAppartmentDescription As String

#End Region


#Region "Properties"

    Public Property ReturnError() As Long

        Get
            Return ReturnError
        End Get

        Set(ByVal Value As Long)
            ReturnError = Value
        End Set

    End Property

    Public Property AppartmentNumber() As String

        Get
            Return strAppartmentNumber
        End Get

        Set(ByVal Value As String)
            strAppartmentNumber = Value
        End Set

    End Property

    Public Property AppartmetTypeID() As Long

        Get
            Return lAppartmetTypeID
        End Get

        Set(ByVal Value As Long)
            lAppartmetTypeID = Value
        End Set

    End Property

    Public Property AppartmentConstructed() As Date

        Get
            Return dtAppartmentConstructed
        End Get

        Set(ByVal Value As Date)
            dtAppartmentConstructed = Value
        End Set

    End Property

    Public Property AppartmentSize() As Double

        Get
            Return dbAppartmentSize
        End Get

        Set(ByVal Value As Double)
            dbAppartmentSize = Value
        End Set

    End Property

    Public Property AppartmentNoOfExitDoors() As Long

        Get
            Return lAppartmentNoOfExitDoors
        End Get

        Set(ByVal Value As Long)
            lAppartmentNoOfExitDoors = Value
        End Set

    End Property

    Public Property AppartmentVolume() As Double

        Get
            Return dbAppartmentVolume
        End Get

        Set(ByVal Value As Double)
            dbAppartmentVolume = Value
        End Set

    End Property

    Public Property AppartmentPicture() As String

        Get
            Return strAppartmentPicture
        End Get

        Set(ByVal Value As String)
            strAppartmentPicture = Value
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

    Public Property AppartmentNoOfWindows() As Long

        Get
            Return lAppartmentNoOfWindows
        End Get

        Set(ByVal Value As Long)
            lAppartmentNoOfWindows = Value
        End Set

    End Property

    Public Property AppartmentHousingNumber() As String

        Get
            Return strAppartmentHousingNumber
        End Get

        Set(ByVal Value As String)
            strAppartmentHousingNumber = Value
        End Set

    End Property

    Public Property AppartmentDescription() As String

        Get
            Return strAppartmentDescription
        End Get

        Set(ByVal Value As String)
            strAppartmentDescription = Value
        End Set

    End Property

#End Region


#Region "GeneralProcedures"

    '[Gets the next invoice number
    Private Function CalculateNextAppartmentID() As Long

        Try
            Dim lReturnValue As Long

            Dim objLogin As IMLogin = New IMLogin

            With objLogin
                lReturnValue = _
                    .ReturnMaxLongValue(strOrgAccessConnString, _
                    "SELECT Count(AppartmentID) FROM AppartmentBuilding " & _
                        "WHERE BuildingID = " & BuildingID)

            End With

            objLogin = Nothing

            Return lReturnValue + 1

        Catch ex As Exception
            ReturnError += ex.Message
        End Try

    End Function

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

            If Trim(strAppartmentNumber) = "" Or BuildingID = 0 Then

                If DisplayErrorMessages = True Then

                    ReturnError += "Please provide the following details in" & _
                " order to save the Appartment's details: " & _
                Chr(10) & "1. Appartment Number (The room number of the appartment) " & _
                Chr(10) & "2. Building the appartment belongs to "

                End If

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If



            If Find("SELECT * FROM AppartmentMaster " & _
                " WHERE (BuildingID = " & BuildingID & _
                " AND AppartmentNumber = '" & strAppartmentNumber & "')", _
                False) = False Then

                Update("UPDATE AppartmentMaster SET " & _
                " AppartmentTypeID = " & lAppartmetTypeID & _
                ",AppartmentConstructed = #" & dtAppartmentConstructed & _
                "#,AppartmentSize = " & dbAppartmentSize & _
                ",AppartmentNoOfExitDoors = " & lAppartmentNoOfExitDoors & _
                ",AppartmentVolume = " & dbAppartmentVolume & _
                ",AppartmentPicture = '" & strAppartmentPicture & _
                "',AppartmentNoOfWindows = " & lAppartmentNoOfWindows & _
                ",AppartmentHousingNumber = '" & strAppartmentHousingNumber & _
                ",AppartmentDescription = '" & strAppartmentDescription & _
                "'", True, True, True, True)

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If


            strInsertInto = "INSERT INTO FixedAssets (" & _
                "AppartmentID" & _
                "AppartmentNumber," & _
                "AppartmentTypeID," & _
                "AppartmentConstructed," & _
                "AppartmentSize," & _
                "AppartmentNoOfExitDoors," & _
                "AppartmentVolume," & _
                "AppartmentPicture," & _
                "AppartmentNoOfWindows," & _
                "AppartmentHousingNumber," & _
                "AppartmentDescription" & _
                    ") VALUES "

            strSaveQuery = strInsertInto & _
                    "(" & CalculateNextAppartmentID() & _
                    ",'" & strAppartmentNumber & _
                    "'," & lAppartmetTypeID & _
                    ",#" & AppartmentConstructed & _
                    "#," & dbAppartmentSize & _
                    "," & lAppartmentNoOfExitDoors & _
                    "," & dbAppartmentVolume & _
                    ",'" & strAppartmentPicture & _
                    "'," & lAppartmentNoOfWindows & _
                    ",'" & strAppartmentHousingNumber & _
                    "','" & strAppartmentDescription & _
                            "')"

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bSaveSuccess = objLogin.ExecuteQuery _
                (strOrgAccessConnString, strSaveQuery, datSaved)


            objLogin.CloseDb()

            If bSaveSuccess = True Then
                If DisplaySuccess = True Then
                    ReturnSuccess += "Appartment Details Saved Successfully."

                End If
            Else

                If DisplayFailure = True Then
                    ReturnError = "'Save Appartment' action failed." & _
            " Make sure all mandatory details are entered"

                End If

                objLogin = Nothing
                datSaved = Nothing

                Exit Function

            End If

            objLogin = Nothing
            datSaved = Nothing

            Return True

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
                    (strOrgAccessConnString, strQuery, _
                                                    datRetData)

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
                        Return False
                        Exit Function

                    End If

                    'Whether to fill properties with values or not
                    If ReturnStatus = True Then

                        For Each myDataRows In myDataTables.Rows

                            AppartmentID = _
                                  myDataRows("AppartmentID")
                            strAppartmentNumber = _
                                myDataRows("AppartmentNumber")
                            lAppartmetTypeID = _
                                myDataRows("AppartmetTypeID")
                            dtAppartmentConstructed = _
                                myDataRows("AppartmentConstructed")
                            dbAppartmentSize = _
                                myDataRows("AppartmentSize")
                            lAppartmentNoOfExitDoors = _
                                myDataRows("AppartmentNoOfExitDoors")

                            '=========================
                            dbAppartmentVolume = _
                                myDataRows("AppartmentVolume")
                            strAppartmentPicture = _
                                myDataRows("AppartmentPicture")
                            dtDateCreated = _
                                myDataRows("DateCreated")
                            lAppartmentNoOfWindows = _
                                myDataRows("AppartmentNoOfWindows")
                            strAppartmentHousingNumber = _
                                myDataRows("AppartmentHousingNumber")

                            '=========================
                            strAppartmentDescription = _
                                myDataRows("AppartmentDescription")

                        Next

                    End If

                Next
                Return True

            Else
                Return False

            End If

            datRetData = Nothing
            objLogin = Nothing

        Catch ex As Exception
            ReturnError += ex.Message.ToString

        End Try

    End Function


    Public Function Delete() As Boolean

        Try

            Dim strDeleteQuery As String
            Dim datDelete As DataSet = New DataSet
            Dim bDelSuccess As Boolean
            Dim objLogin As IMLogin = New IMLogin

            strDeleteQuery = "DELETE * FROM AppartmentMaster " & _
            " WHERE AppartmentID = " & AppartmentID & _
            " AND BuildingID = " & BuildingID

            If AppartmentID = 0 Or BuildingID = 0 Then

                ReturnError += "You must provide an Appartment and its Building " & _
                        "in order to delete the Appartment's details"
                Exit Function
            End If

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bDelSuccess = objLogin.ExecuteQuery(strOrgAccessConnString, _
                strDeleteQuery, datDelete)

            objLogin.CloseDb()

            If bDelSuccess = True Then
                ReturnSuccess += "Appartment details deleted"
                Return True
            Else

                ReturnError += "'Delete Appartment' action failed"


            End If

            datDelete = Nothing
            objLogin = Nothing

        Catch ex As Exception

        End Try

    End Function


    Public Function Update(ByVal strUpQuery As String, _
        ByVal DisplayErrorMessages As Boolean, _
            ByVal DisplayConfirmation As Boolean, _
                ByVal DisplayFailure As Boolean, _
                    ByVal DisplaySuccess As Boolean) As Boolean

        Try

            Dim strUpdateQuery As String
            Dim datUpdated As DataSet = New DataSet
            Dim bUpdateSuccess As Boolean
            Dim objLogin As IMLogin = New IMLogin

            strUpdateQuery = strUpQuery

            If AppartmentID <> 0 And BuildingID <> 0 Then

                objLogin.ConnectString = strOrgAccessConnString
                objLogin.ConnectToDatabase()

                bUpdateSuccess = objLogin.ExecuteQuery _
                    (strOrgAccessConnString, strUpdateQuery, datUpdated)

                objLogin.CloseDb()

                If bUpdateSuccess = True Then
                    If DisplaySuccess = True Then

                        ReturnSuccess += "Appartment's record " & _
                            "updated successfully"

                        Return True

                    End If

                End If

            End If

            objLogin = Nothing
            datUpdated = Nothing


        Catch ex As Exception

        End Try
    End Function

#End Region



End Class
