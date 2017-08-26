Imports System.Threading
Imports System.Windows.Forms

Public Class Form1
    Private pageready As Boolean = False
    Dim label_id As Label = New Label()
    Dim label_id_valor As Label = New Label()
    Dim label_name As Label = New Label()
    Dim label_name_valor As Label = New Label()
    Dim label_tag As Label = New Label()
    Dim label_tag_valor As Label = New Label()
    Dim label_value As Label = New Label()
    Dim label_value_valor As Label = New Label()
    Dim label_outer As Label = New Label()
    Dim label_outer_valor As Label = New Label()


    Private Sub WaitForPageLoad()
        AddHandler Browser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not pageready
            Application.DoEvents()
        End While
        pageready = False
    End Sub
    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If Browser.ReadyState = WebBrowserReadyState.Complete Then
            pageready = True
            RemoveHandler Browser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)

        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Browser.Visible = True

        Browser.ScriptErrorsSuppressed = True
        ListBox1.Items.Clear()

        label_id.Location = New Point(850, 400)
        label_id.Text = "ID: "
        label_id_valor.Location = New Point(1000, 400)

        label_name.Location = New Point(850, 450)
        label_name.Text = "NAME: "
        label_name_valor.Location = New Point(1000, 450)

        label_tag.Location = New Point(850, 500)
        label_tag.Text = "TAG: "
        label_tag_valor.Location = New Point(1000, 500)


        label_value.Location = New Point(850, 550)
        label_value.Text = "Valor: "
        label_value_valor.Location = New Point(1000, 550)


        label_outer.Location = New Point(850, 600)
        label_outer.Text = "Texto: "
        label_outer_valor.Location = New Point(1000, 600)

        Browser.Navigate(TextBox3.Text)





    End Sub

    Private Sub listBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick


        Dim cad_completa As String()
        Dim outer As String
        Dim id As String
        Dim tag As String
        Dim Name As String
        cad_completa = ListBox1.SelectedItem.ToString().Split("|")

        If cad_completa.Length = 2 Then


            outer = cad_completa(0)
            tag = cad_completa(1).Substring(5)

            Dim doc As HtmlElementCollection = Browser.Document.All

            For Each elem As HtmlElement In doc

                If outer = elem.OuterText And tag = elem.TagName Then
                    elem.Focus()


                    label_id_valor.Text = elem.Id
                    If (String.IsNullOrEmpty(elem.Id)) Then
                        label_id_valor.Text = "{Vacio}"
                    End If
                    label_name_valor.Text = elem.Name
                    If (String.IsNullOrEmpty(elem.Name)) Then
                        label_name_valor.Text = "{Vacio}"
                    End If
                    label_tag_valor.Text = elem.TagName
                    If (String.IsNullOrEmpty(elem.TagName)) Then
                        label_tag_valor.Text = "{Vacio}"
                    End If
                    label_value_valor.Text = elem.GetAttribute("value")
                    If (String.IsNullOrEmpty(elem.GetAttribute("value"))) Then
                        label_value_valor.Text = "{Vacio}"
                    End If
                    label_outer_valor.Text = elem.OuterText
                    If (String.IsNullOrEmpty(elem.OuterText)) Then
                        label_outer_valor.Text = "{Vacio}"
                    End If

                End If
            Next
        End If

        If cad_completa.Length = 3 Then


            id = cad_completa(0).Substring(4)
            tag = cad_completa(2).Substring(5)
            Name = cad_completa(1).Substring(6)
            Dim doc As HtmlElementCollection = Browser.Document.All

            For Each elem As HtmlElement In doc

                If id = elem.Id And Name = elem.Name And tag = elem.TagName Then


                    elem.Focus()

                    label_id_valor.Text = elem.Id
                    If (String.IsNullOrEmpty(elem.Id)) Then
                        label_id_valor.Text = "{Vacio}"
                    End If
                    label_name_valor.Text = elem.Name
                    If (String.IsNullOrEmpty(elem.Name)) Then
                        label_name_valor.Text = "{Vacio}"
                    End If
                    label_tag_valor.Text = elem.TagName
                    If (String.IsNullOrEmpty(elem.TagName)) Then
                        label_tag_valor.Text = "{Vacio}"
                    End If
                    label_value_valor.Text = elem.GetAttribute("value")
                    If (String.IsNullOrEmpty(elem.GetAttribute("value"))) Then
                        label_value_valor.Text = "{Vacio}"
                    End If
                    label_outer_valor.Text = elem.OuterText
                    If (String.IsNullOrEmpty(elem.OuterText)) Then
                        label_outer_valor.Text = "{Vacio}"
                    End If

                End If
            Next
        End If
        Me.Controls.Add(label_id)
        Me.Controls.Add(label_id_valor)
        Me.Controls.Add(label_name)
        Me.Controls.Add(label_name_valor)
        Me.Controls.Add(label_tag)
        Me.Controls.Add(label_tag_valor)
        Me.Controls.Add(label_value)
        Me.Controls.Add(label_value_valor)
        Me.Controls.Add(label_outer)
        Me.Controls.Add(label_outer_valor)

    End Sub


    Private Sub webBrowser1_Navigating(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs) Handles Browser.Navigating
        ListBox1.Items.Clear()



    End Sub
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles Browser.DocumentCompleted

        Dim doc As HtmlElementCollection

        doc = Browser.Document.All
        MessageBox.Show(Browser.Document.All.Count)
        For Each elem As HtmlElement In doc

            If String.IsNullOrEmpty(elem.Id) And String.IsNullOrEmpty(elem.Name) Then
                ListBox1.Items.Add(elem.OuterText + "|" + "Tag: " + elem.TagName)

            Else
                ListBox1.Items.Add("ID: " + elem.Id + "|" + "NAME: " + elem.Name + "|" + "Tag: " + elem.TagName)
            End If
        Next
        MessageBox.Show(ListBox1.Items.Count)

        ListBox1.Sorted = True
        ListBox1.HorizontalScrollbar = True

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Module1.Variables = ListBox1

        Module1.Nom_Fich = TextBox3.Text

        Form2.Show()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not System.IO.File.Exists(TextBox3.Text & ".txt") Then
            MessageBox.Show("No existe fichero de configuración para esa página")

        Else

            Dim sr As New System.IO.StreamReader(TextBox3.Text & ".txt")
            Dim cadena As String
            Dim Separadores As String()

            While (sr.EndOfStream = False)
                cadena = sr.ReadLine
                Separadores = cadena.Split("|")
                ejecutar(Separadores)


            End While
            sr.Close()
        End If

    End Sub

    Private Sub ejecutar(separadores() As String)

        Dim Indice As String
        Dim id As String
        Dim tag As String
        Dim Name As String
        Dim valor As String
        Indice = separadores(0)


        If (Indice = "M") Then
            MessageBox.Show("Esperando")
            id = separadores(1).Substring(4)
            tag = separadores(3).Substring(5)
            Name = separadores(2).Substring(6)
            valor = separadores(4)
            Dim doc As HtmlElementCollection = Browser.Document.All


            For Each elem As HtmlElement In doc

                If id = elem.Id And Name = elem.Name And tag = elem.TagName Then

                    If Browser.ReadyState = WebBrowserReadyState.Complete Then
                        elem.SetAttribute("value", valor)
                    End If


                End If
            Next


        ElseIf (Indice = "P") Then
            If separadores.Length > 3 Then
                id = separadores(1).Substring(4)
                tag = separadores(3).Substring(5)
                Name = separadores(2).Substring(6)

                Dim doc As HtmlElementCollection = Browser.Document.All

                For Each elem As HtmlElement In doc

                    If id = elem.Id And Name = elem.Name And tag = elem.TagName Then
                        If Browser.ReadyState = WebBrowserReadyState.Complete Then
                            elem.InvokeMember("click")
                        End If

                    End If

                Next

            ElseIf separadores.Length = 3 Then
                valor = separadores(1)

                Dim doc As HtmlElementCollection = Browser.Document.All

                For Each elem As HtmlElement In doc
                    If (elem.OuterText = valor) Then
                        If Browser.ReadyState = WebBrowserReadyState.Complete Then
                            elem.InvokeMember("click")
                        End If
                    End If
                Next
            End If
        End If



    End Sub
End Class
