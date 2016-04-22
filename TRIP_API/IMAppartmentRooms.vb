
Option Explicit On 
'Option Strict On

Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections

Public Class IMAppartmentRooms
    Inherits IMAppartmentBuilding

#Region "PrivateVariables"

    Private lRoomID As Long
    Private lRoomTypeID As Long
    Private dbRoomFloorSize As Double
    Private dbRoomVolumeSize As Double
    Private dtDateCreated As Date
    Private strRoomDescription As String

    Private lRoomFloorTypeID As Long
    Private lRoomWallTypeID As Long
    Private lRoomPaintTypeID As Long
    Private strRoomPaintColor As String
    Private strRoomPaintDescription As String
    Private lRoomPictureDocumentID As Long

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

    Public Property RoomID() As Long

        Get
            Return lRoomID
        End Get

        Set(ByVal Value As Long)
            lRoomID = Value
        End Set

    End Property

    Public Property RoomFloorSize() As Double

        Get
            Return dbRoomFloorSize
        End Get

        Set(ByVal Value As Double)
            dbRoomFloorSize = Value
        End Set

    End Property

    Public Property RoomFloorTypeID() As Long

        Get
            Return lRoomFloorTypeID
        End Get

        Set(ByVal Value As Long)
            lRoomFloorTypeID = Value
        End Set

    End Property

    Public Property RoomWallType() As Long

        Get
            Return lRoomWallTypeID
        End Get

        Set(ByVal Value As Long)
            lRoomWallTypeID = Value
        End Set

    End Property

    Public Property RoomPaintType() As Long

        Get
            Return lRoomPaintTypeID
        End Get

        Set(ByVal Value As Long)
            lRoomPaintTypeID = Value
        End Set

    End Property

    Public Property RoomPaintColor() As String

        Get
            Return strRoomPaintColor
        End Get

        Set(ByVal Value As String)
            strRoomPaintColor = Value
        End Set

    End Property

    Public Property RoomPaintDescription() As String

        Get
            Return strRoomPaintDescription
        End Get

        Set(ByVal Value As String)
            strRoomPaintDescription = Value
        End Set

    End Property

    Public Property RoomPictureDocumentID() As Long

        Get
            Return lRoomPictureDocumentID
        End Get

        Set(ByVal Value As Long)
            lRoomPictureDocumentID = Value
        End Set

    End Property

    Public Property RoomVolumeSize() As Double

        Get
            Return dbRoomVolumeSize
        End Get

        Set(ByVal Value As Double)
            dbRoomVolumeSize = Value
        End Set

    End Property

    Public Property RoomDescription() As String

        Get
            Return strRoomDescription
        End Get

        Set(ByVal Value As String)
            strRoomDescription = Value
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


#Region "GeneralProcedures"

    '[Gets the next invoice number
    Private Function CalculateNextRoomID() As Long

        Try
            Dim lReturnValue As Long

            Dim objLogin As IMLogin = New IMLogin

            With objLogin
                lReturnValue = _
                    .ReturnMaxLongValue(strOrgAccessConnString, _
                    "SELECT Count(RoomID) FROM AppartmentRooms " & _
                        "WHERE AppartmentID = " & AppartmentID)

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

            If AppartmentID = 0 Or BuildingID = 0 Then

                If DisplayErrorMessages = True Then

                    ReturnError += "Please provide the following details in" & _
                " order to save the Appartment's details: " & _
                Chr(10) & "1. Appartment Number " & _
                Chr(10) & "2. The Building housing the appartment "

                End If

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If



            If Find("SELECT * FROM AppartmentRooms " & _
                " WHERE (BuildingID = " & BuildingID & _
                " AND AppartmentID = " & AppartmentID & _
                " AND RoomID = " & RoomID & ")", _
                False) = False Then

                Update("UPDATE AppartmentRooms SET " & _
                "RoomTypeID = " & lRoomTypeID & _
                ",RoomFloorSize = " & dbRoomFloorSize & _
                ",RoomVolumeSize = " & dbRoomVolumeSize & _
                ",RoomDescription = '" & strRoomDescription & _
                "',AppartmentID = " & AppartmentID & _
                ",BuildingID = " & BuildingID & _
                ",RoomFloorTypeID = " & lRoomFloorTypeID & _
                ",RoomWallTypeID = " & lRoomWallTypeID & _
                ",RoomPaintTypeID = " & lRoomPaintTypeID & _
                ",RoomPaintColor = '" & strRoomPaintColor & _
                "',RoomPaintDescription = '" & strRoomDescription & _
                "',RoomPictureDocumentID = " & lRoomPictureDocumentID _
                , True, True, True, True)

                objLogin = Nothing
                datSaved = Nothing

                Exit Function
            End If


            strInsertInto = "INSERT INTO AppartmentRooms (" & _
                "RoomTypeID" & _
                "RoomFloorSize," & _
                "RoomVolumeSize," & _
                "RoomDescription," & _
                "AppartmentID," & _
                "BuildingID," & _
                "RoomFloorTypeID," & _
                "RoomWallTypeID," & _
                "RoomPaintTypeID," & _
                "RoomPaintColor," & _
                "RoomPaintDescription," & _
                "RoomPictureDocumentID" & _
                    ") VALUES "

            strSaveQuery = strInsertInto & _
                    "(" & lRoomTypeID & _
                    "," & dbRoomFloorSize & _
                    "," & dbRoomVolumeSize & _
                    ",'" & strRoomDescription & _
                    "'," & AppartmentID & _
                    "," & BuildingID & _
                    "," & lRoomFloorTypeID & _
                    "," & lRoomWallTypeID & _
                    "," & lRoomPaintTypeID & _
                    ",'" & strRoomPaintColor & _
                    "','" & strRoomPaintDescription & _
                    "'," & lRoomPictureDocumentID & _
                            ")"

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bSaveSuccess = objLogin.ExecuteQuery _
                (strOrgAccessConnString, strSaveQuery, datSaved)


            objLogin.CloseDb()

            If bSaveSuccess = True Then
                If DisplaySuccess = True Then
                    ReturnSuccess += "Appartment Room Details Saved Successfully."

                End If
            Else

                If DisplayFailure = True Then
                    ReturnError = "'Save Appartment Room' action failed." & _
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
                            BuildingID = _
                                myDataRows("BuildingID")
                            lRoomID = _
                                myDataRows("RoomID")
                            lRoomTypeID = _
                                myDataRows("RoomTypeID")
                            dbRoomFloorSize = _
                                myDataRows("RoomFloorSize")
                            dbRoomVolumeSize = _
                                myDataRows("RoomVolumeSize")

                            '=========================
                            strRoomDescription = _
                                myDataRows("RoomDescription")
                            dtDateCreated = _
                                myDataRows("DateCreated")
                            lRoomFloorTypeID = _
                                myDataRows("RoomFloorTypeID")
                            lRoomWallTypeID = _
                                myDataRows("RoomWallTypeID")
                            lRoomPaintTypeID = _
                                myDataRows("RoomPaintTypeID")

                            '=========================
                            strRoomPaintColor = _
                                myDataRows("RoomPaintColor")
                            strRoomPaintDescription = _
                                myDataRows("RoomPaintDescription")
                            lRoomPictureDocumentID = _
                                myDataRows("RoomPictureDocumentID")

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

            strDeleteQuery = "DELETE * FROM AppartmentRooms " & _
            " WHERE RoomID = " & lRoomID & _
            " AND BuildingID = " & BuildingID & _
            " AND AppartmentID = " & AppartmentID

            If AppartmentID = 0 Or BuildingID = 0 Or lRoomID = 0 Then

                ReturnError += "You must provide the Room, Appartment and its Building " & _
                        "in order to delete the Appartment's details"
                Exit Function
            End If

            objLogin.ConnectString = strOrgAccessConnString
            objLogin.ConnectToDatabase()

            bDelSuccess = objLogin.ExecuteQuery(strOrgAccessConnString, _
                strDeleteQuery, datDelete)

            objLogin.CloseDb()

            If bDelSuccess = True Then
                ReturnSuccess += "Appartment's Room details deleted"
                Return True
            Else

                ReturnError += "'Delete Appartment's Room' action failed"


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

                        ReturnSuccess += "Appartment's Room record " & _
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
