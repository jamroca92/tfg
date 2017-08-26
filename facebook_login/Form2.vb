Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Modificar")
        ComboBox1.Items.Add("Pulsar")

        '    Dim nom As String = Nom_Fich & ".txt"
        '    If IO.File.Exists(nom) Then
        '        Dim sr As New System.IO.StreamReader(nom)
        '        Dim cadena As String
        '        Dim Separadores As String()
        '        Dim num As Integer = 1

        '        While (sr.EndOfStream = False)
        '            cadena = sr.ReadLine
        '            Separadores = cadena.Split("|")
        '            ejecutar(Separadores, num)
        '            num = num + 1

        '        End While
        '        sr.Close()
        '    End If
        'End Sub

        'Public Sub ejecutar(separadores() As String, num As Integer)
        '    Dim MyLabel As Label = New Label()
        '    Dim etiqueta As Label = New Label()
        '    Dim tag As Label = New Label()
        '    Dim MyCombo As ComboBox = New ComboBox()
        '    Dim combo As ComboBox = New ComboBox()
        '    Dim texto As TextBox = New TextBox()
        '    Dim button As Button = New Button()
        '    Dim boton As Button = New Button()
        '    MyLabel.Location = New Point(Label1.Location.X, 52 + num * 40)
        '    MyCombo.Location = New Point(ComboBox1.Location.X + 80, 52 + num * 40)
        '    etiqueta.Location = New Point(Label2.Location.X + 80, 52 + num * 40)
        '    combo.Location = New Point(ComboBox2.Location.X + 100, 52 + num * 40)
        '    tag.Location = New Point(Label3.Location.X + 80, 52 + num * 40)
        '    texto.Location = New Point(TextBox1.Location.X + 150, 52 + num * 40)
        '    button.Location = New Point(Button1.Location.X + 180, 52 + num * 40)
        '    boton.Location = New Point(button.Location.X + 80, 52 + num * 40)
        '    texto.Visible = False
        '    button.Text = "MODIFICAR"
        '    boton.Text = "ELIMINAR"
        '    MyLabel.Name = "MyLabel" & (num + 1)
        '    MyCombo.Name = "MyCombo" & (num + 1)
        '    etiqueta.Name = "etiqueta" & (num + 1)
        '    combo.Name = "combo" & (num + 1)
        '    tag.Name = "tag" & (num + 1)
        '    texto.Name = "texto" & (num + 1)
        '    button.Name = "button" & (num + 1)
        '    boton.Name = "boton" & (num + 1)
        '    MyCombo.Items.Add("Modificar")
        '    MyCombo.Items.Add("Pulsar")




        '    MyLabel.Text = "Quiero"
        '    For Each items As Object In Variables.Items
        '        combo.Items.Add(items)
        '    Next
        '    For Each items As Object In Enlaces.Items
        '        combo.Items.Add(items)
        '    Next
        '    Me.Controls.Add(MyLabel)
        '    Me.Controls.Add(MyCombo)
        '    Me.Controls.Add(etiqueta)
        '    Me.Controls.Add(combo)
        '    Me.Controls.Add(tag)
        '    Me.Controls.Add(texto)
        '    Me.Controls.Add(button)
        '    Me.Controls.Add(boton)
        '    Dim Indice As String
        '    Dim id As String
        '    Dim tagname As String
        '    Dim Name As String
        '    Dim valor As String
        '    Dim index As Integer
        '    Indice = separadores(0)



        '    If (Indice = "M") Then
        '        id = separadores(1).Substring(4)
        '        tagname = separadores(3).Substring(5)
        '        Name = separadores(2).Substring(6)
        '        valor = separadores(4)
        '        index = separadores(5)
        '        MyCombo.SelectedItem = "Modificar"
        '        etiqueta.Text = "la variable"
        '        tag.Text = "con el valor"
        '        combo.SelectedIndex = index
        '        texto.Visible = True
        '        texto.Text = valor

        '    ElseIf (Indice = "P") Then
        '        MyCombo.SelectedItem = "Pulsar"
        '        etiqueta.Text = "el boton"
        '        MessageBox.Show(combo.Items.Count)
        '        index = separadores(2)
        '        combo.SelectedIndex = index
        '    End If
        'End Sub



    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Modificar" Then
            Label2.Visible = True
            Label2.Text = "la variable "

        ElseIf ComboBox1.SelectedItem = "Pulsar" Then
            Label2.Visible = True
            Label2.Text = " el boton"
        End If
        ComboBox2.Visible = True
        For Each items As Object In Variables.Items
            ComboBox2.Items.Add(items)
        Next
        For Each items As Object In Enlaces.Items
            ComboBox2.Items.Add(items)
        Next
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Modificar" Then
            Label3.Text = "con el valor"
            Label3.Visible = True
            TextBox1.Visible = True
        End If
        Button1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nom As String = Nom_Fich & ".txt"
        Dim sw As New System.IO.StreamWriter(nom, True)
        If (ComboBox1.SelectedItem = "Modificar") Then
            sw.WriteLine("M|" & ComboBox2.SelectedItem & "|" & TextBox1.Text & "|" & ComboBox2.SelectedIndex)
        End If
        If (ComboBox1.SelectedItem = "Pulsar") Then
            sw.WriteLine("P|" & ComboBox2.SelectedItem & "|" & ComboBox2.SelectedIndex)
        End If
        sw.Close()
        Me.Close()

    End Sub


End Class