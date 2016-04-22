
Option Explicit On 
'Option Strict On

Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections

Public Class IMAppartmentRoomAmenities
    Inherits IMAppartmentRooms


#Region "PrivateVariables"

    Private lAmenityID As Long
    Private lNoOfAmenitiesOfThisType As Long
    Private strAmenityDescription As String
    Private lAmenityTypeID As Long
    Private dtDateCreated As Date

#End Region


#Region "Properties"

    Public Property AmenityID() As Long

        Get
            Return lAmenityID
        End Get

        Set(ByVal Value As Long)
            lAmenityID = Value
        End Set

    End Property

    Public Property NoOfAmenitiesOfThisType() As Long

        Get
            Return lNoOfAmenitiesOfThisType
        End Get

        Set(ByVal Value As Long)
            lNoOfAmenitiesOfThisType = Value
        End Set

    End Property

    Public Property AmenityDescription() As String

        Get
            Return strAmenityDescription
        End Get

        Set(ByVal Value As String)
            strAmenityDescription = Value
        End Set

    End Property

    Public Property AmenityTypeID() As Long

        Get
            Return lAmenityTypeID
        End Get

        Set(ByVal Value As Long)
            lAmenityTypeID = Value
        End Set

    End Property

    Public Shadows Property DateCreated() As Date

        Get
            Return dtDateCreated
        End Get

        Set(ByVal Value As Date)
            dtDateCreated = Value
        End Set

    End Property

#End Region


#Region "GeneralProcedures"

    '[Gets the next invoice number
    Private Function CalculateNextRoomAmenityID() As Long

        Try
            Dim lReturnValue As Long

            Dim objLogin As IMLogin = New IMLogin

            With objLogin
                lReturnValue = _
                    .ReturnMaxLongValue(strOrgAccessConnString, _
                    "SELECT Count(AmenityID) FROM AppartmentRoomAmenities " & _
                        "WHERE RoomID = " & RoomID & " AND ApprtmentID = " & _
                        AppartmentID & " AND BuildingID = " & BuildingID)

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

    Private Shadows Function Save(ByVal DisplayErrorMessages As Boolean, _
        ByVal DisplayConfirmation As Boolean, _
            ByVal DisplayFailure As Boolean, _
                ByVal DisplaySuccess As Boolean) As Boolean

        Dim strSaveQuery As String
        Dim datSaved As DataSet = New DataSet
        Dim bSaveSuccess As Boolean
        Dim objLogin As IMLogin = New IMLogin
        Dim strInsertInto As String

        Try

            If AppartmentID = 0 Or BuildingID = 0 Or _
                RoomID = 0 Or lAmenityTypeID = 0 Then

                If DisplayErrorMessages = True Then

                    ReturnError += "Please provide the following details in" & _
                " order to save the Appartment's details: " & _
                Chr(10) & "1. Appartment Number " & _
                Chr(10) & "2. The Building housing the appartment " & _
                Chr(10) & "2. The Room Containing the Amenity " & _
                Chr(10) & "2. The Amenity that you want to link to the room "

                End If

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If



            If Find("SELECT * FROM AppartmentRoomAmenities " & _
                " WHERE (BuildingID = " & BuildingID & _
                " AND AppartmentID = " & AppartmentID & _
                " AND RoomID = " & RoomID & _
                " AND AmenityTypeID = " & lAmenityTypeID & " )", _
                False) = False Then

                Update("UPDATE AppartmentRoomAmenities SET " & _
                "NoOfAmenitiesOfThisType = " & lNoOfAmenitiesOfThisType & _
                ",AmenityDescription = '" & strAmenityDescription & _
                "',AmenityTypeID = " & lAmenityTypeID & _
                ",BuildingID = " & BuildingID _
                , True, True, True, True)

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If


            strInsertInto = "INSERT INTO AppartmentRoomAmenities (" & _
                "RoomID" & _
                "NoOfAmenitiesOfThisType," & _
                "AmenityDescription," & _
                "AmenityTypeID," & _
                "AppartmentID," & _
                "BuildingID," & _
                    ") VALUES "

            strSaveQuery = strInsertInto & _
                    "(" & RoomID & _
                    "," & lNoOfAmenitiesOfThisType & _
                    "," & strAmenityDescription & _
                    ",'" & lAmenityTypeID & _
                    "'," & AppartmentID & _
                    "," & BuildingID & _
                            ")"

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bSaveSuccess = objLogin.ExecuteQuery _
                (strOrgAccessConnString, strSaveQuery, datSaved)


            objLogin.CloseDb()

            If bSaveSuccess = True Then
                If DisplaySuccess = True Then
                    ReturnSuccess += "Appartment Amenity's Details Saved Successfully."

                End If
            Else

                If DisplayFailure = True Then
                    ReturnError = "'Save Appartment Amenity' action failed." & _
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


    Public Shadows Function Find(ByVal strQuery As String, _
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
                        Return False
                        Exit Function

                    End If

                    'Whether to fill properties with values or not
                    If ReturnStatus = True Then

                        For Each myDataRows In myDataTables.Rows

                            AppartmentID = _
                                  myDataRows("AppartmentID")
                            BuildingID = _
                                myDataRows("BuildingID")
                            lAmenityID = _
                                myDataRows("AmenityID")
                            lAmenityTypeID = _
                                myDataRows("AmenityTypeID")
                            strAmenityDescription = _
                                myDataRows("AmenityDescription")
                            lNoOfAmenitiesOfThisType = _
                                myDataRows("NoOfAmenitiesOfThisType")
                            dtDateCreated = _
                                myDataRows("DateCreated")

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


    Public Shadows Function Delete() As Boolean

        Try

            Dim strDeleteQuery As String
            Dim datDelete As DataSet = New DataSet
            Dim bDelSuccess As Boolean
            Dim objLogin As IMLogin = New IMLogin

            strDeleteQuery = "DELETE * FROM AppartmentRooms " & _
            " WHERE RoomID = " & RoomID & _
            " AND BuildingID = " & BuildingID & _
            " AND AppartmentID = " & AppartmentID & _
            " AND AmenityID = " & lAmenityID

            If AppartmentID = 0 Or BuildingID = 0 Or _
                RoomID = 0 Or lAmenityID = 0 Then

                ReturnError += "You must provide the Room, Appartment, " & _
                "Building, and the Amenity itself in order to delete the Amenity's details"
                Exit Function
            End If

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bDelSuccess = objLogin.ExecuteQuery(strOrgAccessConnString, _
                strDeleteQuery, datDelete)

            objLogin.CloseDb()

            If bDelSuccess = True Then
                ReturnSuccess += "Room Amenity's details deleted"
                Return True
            Else

                ReturnError += "'Delete Room Amenity's' action failed"


            End If

            datDelete = Nothing
            objLogin = Nothing

        Catch ex As Exception

        End Try

    End Function

    Public Shadows Function Update(ByVal strUpQuery As String, _
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

                        ReturnSuccess += "Room Amenity's record " & _
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
