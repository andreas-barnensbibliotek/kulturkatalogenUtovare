Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports kulturkatalogenUtovare

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub testgetnamn()

        Dim obj As New utovareMainController
        Dim ret As List(Of utovareDetailInfo) = obj.getutovarebyFreesearch("ab")

        Dim retkoll As New List(Of utovareDetailInfo)

        retkoll = ret

    End Sub
    <TestMethod()> Public Sub testifiUserexist()

        Dim obj As New utovareMainController
        Dim ret As Boolean = obj.utovareExists("test@test.se", "Ulricefhamn")

        Dim retkoll As Boolean

        retkoll = ret

    End Sub
End Class