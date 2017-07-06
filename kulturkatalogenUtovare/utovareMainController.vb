Public Class utovareMainController

    Private _dalobj As New utovareDAL

    Public Function getutovareAll() As List(Of utovareDetailInfo)
        Return _dalobj.getAllUtovare()
    End Function
    Public Function getutovarebyautocomplete(namn As String) As List(Of utovareDetailInfo)
        Return _dalobj.getUsername(namn)
    End Function

    Public Function getutovareDetail(utovarid As Integer) As utovareDetailInfo
        Return _dalobj.getutovareDetails(utovarid)
    End Function

    Public Function addutovare(utovardata As utovareDetailInfo) As utovareDetailInfo
        Dim retobj As New utovareDetailInfo
        If Not utovareExists(utovardata.Epost, utovardata.Ort) Then

            Dim nyttutovarid = _dalobj.addutovareDetails(utovardata)
            If nyttutovarid > 0 Then
                retobj = _dalobj.getutovareDetails(nyttutovarid)

            End If
        End If

        Return retobj

    End Function

    Public Function Editutovare(utovardata As utovareDetailInfo) As utovareDetailInfo
        Dim retobj As New utovareDetailInfo

        If _dalobj.editUtovaredetails(utovardata) Then
            retobj = _dalobj.getutovareDetails(utovardata.UtovarID)

        End If

        Return retobj

    End Function
    Public Function delutovare(utovarid As Integer) As Boolean

        Return _dalobj.DeleteUtvaredetail(utovarid)

    End Function
    Public Function getutovarebyFreesearch(searchstr As String) As List(Of utovareDetailInfo)
        Return _dalobj.getFreeSearchUtovare(searchstr)
    End Function


    Public Function utovareExists(epost As String, ort As String) As Boolean

        Return _dalobj.checkIfUtovareExist(epost, ort)
    End Function
End Class
