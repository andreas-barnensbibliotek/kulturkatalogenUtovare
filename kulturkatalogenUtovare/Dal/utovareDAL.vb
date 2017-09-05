Public Class utovareDAL
    Private _connectionString As String = "Data Source=.\SQLEXPRESS;Initial Catalog=dnndev_v902.me;Persist Security Info=True;User ID=dnndev_v902.me;Password=L0rda1f"
    'Private _connectionString As String = "Data Source=DE-1896;Initial Catalog=kulturkatalogenDB;User ID=kulturkatalogenDB;Password=L0rda1f"
    Private _linqObj As New utovareLinqDataContext(_connectionString)


    Public Function getUsername(name As String) As List(Of utovareDetailInfo)
        Dim ret As New List(Of utovareDetailInfo)


        Dim usr = From e In _linqObj.kk_aj_tbl_Utovares
                  Where e.Organisation.Contains(name)
                  Select e

        For Each itm In usr
            Dim tmp As New utovareDetailInfo
            tmp.Adress = itm.Adress
            tmp.Efternamn = itm.Efternamn
            tmp.Epost = itm.Epost
            tmp.Fornamn = itm.Fornamn
            tmp.Kommun = itm.Kommun
            tmp.Organisation = itm.Organisation
            tmp.Ort = itm.Ort
            tmp.Postnr = itm.Postnr
            tmp.Telefon = itm.Telefonnummer
            tmp.UtovarID = itm.UtovarID
            tmp.Weburl = itm.Hemsida
            tmp.Bild = itm.Bild
            tmp.Beskrivning = itm.Ovrigt

            ret.Add(tmp)
        Next

        Return ret
    End Function

    Public Function getutovareDetails(utovarid As Integer) As utovareDetailInfo
        Dim ret As New utovareDetailInfo

        Dim itm = (From e In _linqObj.kk_aj_tbl_Utovares
                   Where e.UtovarID = utovarid
                   Select e).Single

        ret.Adress = itm.Adress
        ret.Efternamn = itm.Efternamn
        ret.Epost = itm.Epost
        ret.Fornamn = itm.Fornamn
        ret.Kommun = itm.Kommun
        ret.Organisation = itm.Organisation
        ret.Ort = itm.Ort
        ret.Postnr = itm.Postnr
        ret.Telefon = itm.Telefonnummer
        ret.UtovarID = itm.UtovarID
        ret.Weburl = itm.Hemsida
        ret.Bild = itm.Bild
        ret.Beskrivning = itm.Ovrigt
        Return ret
    End Function

    Public Function getFreeSearchUtovare(searchstr As String) As List(Of utovareDetailInfo)
        Dim ret As New List(Of utovareDetailInfo)

        Dim usr = From e In _linqObj.kk_aj_proc_searchUtovareAll(searchstr)
                  Select e

        For Each itm In usr
            Dim tmp As New utovareDetailInfo
            tmp.Adress = itm.Adress
            tmp.Efternamn = itm.Efternamn
            tmp.Epost = itm.Epost
            tmp.Fornamn = itm.Fornamn
            tmp.Kommun = itm.Kommun
            tmp.Organisation = itm.Organisation
            tmp.Ort = itm.Ort
            tmp.Postnr = itm.Postnr
            tmp.Telefon = itm.Telefonnummer
            tmp.UtovarID = itm.UtovarID
            tmp.Weburl = itm.Hemsida
            tmp.Bild = itm.Bild
            tmp.Beskrivning = itm.Ovrigt

            ret.Add(tmp)
        Next


        Return ret
    End Function
    Public Function getAllUtovare() As List(Of utovareDetailInfo)
        Dim ret As New List(Of utovareDetailInfo)

        Dim usr = From e In _linqObj.kk_aj_tbl_Utovares
                  Select e

        For Each itm In usr
            Dim tmp As New utovareDetailInfo
            tmp.Adress = itm.Adress
            tmp.Efternamn = itm.Efternamn
            tmp.Epost = itm.Epost
            tmp.Fornamn = itm.Fornamn
            tmp.Kommun = itm.Kommun
            tmp.Organisation = itm.Organisation
            tmp.Ort = itm.Ort
            tmp.Postnr = itm.Postnr
            tmp.Telefon = itm.Telefonnummer
            tmp.UtovarID = itm.UtovarID
            tmp.Weburl = itm.Hemsida
            tmp.Bild = itm.Bild
            tmp.Beskrivning = itm.Ovrigt

            ret.Add(tmp)
        Next


        Return ret
    End Function
    Public Function checkIfUtovareExist(epost As String, ort As String) As Boolean
        Dim ret As Boolean = False

        If (From e In _linqObj.kk_aj_tbl_Utovares
            Where e.Epost = epost And e.Ort = ort
            Select e).Any Then
            ret = True
        End If

        Return ret
    End Function
    Public Function getUtovareByFormSearch(epost As String, postnr As String) As List(Of utovareDetailInfo)
        Dim ret As New List(Of utovareDetailInfo)

        Dim usr = From e In _linqObj.kk_aj_proc_FormUtovareSearch(epost, postnr)
                  Select e

        For Each itm In usr
            Dim tmp As New utovareDetailInfo
            tmp.Adress = itm.Adress
            tmp.Efternamn = itm.Efternamn
            tmp.Epost = itm.Epost
            tmp.Fornamn = itm.Fornamn
            tmp.Kommun = itm.Kommun
            tmp.Organisation = itm.Organisation
            tmp.Ort = itm.Ort
            tmp.Postnr = itm.Postnr
            tmp.Telefon = itm.Telefonnummer
            tmp.UtovarID = itm.UtovarID
            tmp.Weburl = itm.Hemsida
            tmp.Bild = itm.Bild
            tmp.Beskrivning = itm.Ovrigt

            ret.Add(tmp)
        Next


        Return ret
    End Function

#Region "Utovare detail CRUD"

    Public Function addutovareDetails(utovareDetails As utovareDetailInfo) As Integer
        Dim ret As New utovareDetailInfo
        Dim UtovarID As Integer
        Dim newitm As New kk_aj_tbl_Utovare
        Try
            newitm.Adress = utovareDetails.Adress
            newitm.Efternamn = utovareDetails.Efternamn
            newitm.Epost = utovareDetails.Epost
            newitm.Fornamn = utovareDetails.Fornamn
            newitm.Kommun = utovareDetails.Kommun
            newitm.Organisation = utovareDetails.Organisation
            newitm.Ort = utovareDetails.Ort
            newitm.Postnr = utovareDetails.Postnr
            newitm.Telefonnummer = utovareDetails.Telefon
            newitm.Hemsida = utovareDetails.Weburl
            newitm.Bild = utovareDetails.Bild
            newitm.Ovrigt = utovareDetails.Beskrivning

            _linqObj.kk_aj_tbl_Utovares.InsertOnSubmit(newitm)
            _linqObj.SubmitChanges()

            UtovarID = newitm.UtovarID
        Catch ex As Exception
            UtovarID = 0
        End Try

        Return UtovarID
    End Function

    Public Function editUtovaredetails(utovareDetails As utovareDetailInfo) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.kk_aj_tbl_Utovares
                      Where e.UtovarID = utovareDetails.UtovarID
                      Select e

            For Each itm In upd
                itm.Adress = utovareDetails.Adress
                itm.Efternamn = utovareDetails.Efternamn
                itm.Epost = utovareDetails.Epost
                itm.Fornamn = utovareDetails.Fornamn
                itm.Kommun = utovareDetails.Kommun
                itm.Organisation = utovareDetails.Organisation
                itm.Ort = utovareDetails.Ort
                itm.Postnr = utovareDetails.Postnr
                itm.Telefonnummer = utovareDetails.Telefon
                itm.Hemsida = utovareDetails.Weburl
                itm.Bild = utovareDetails.Bild
                itm.Ovrigt = utovareDetails.Beskrivning
            Next

            _linqObj.SubmitChanges()
            ret = True

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    Public Function DeleteUtvaredetail(utovarid As Integer) As Boolean
        Dim deleted As Boolean = False
        Try
            Dim itm = From c In _linqObj.kk_aj_tbl_Utovares
                      Where c.UtovarID = utovarid
                      Select c

            For Each i In itm
                _linqObj.kk_aj_tbl_Utovares.DeleteOnSubmit(i)
            Next

            _linqObj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function

#End Region
End Class
