
Imports QRCoder
Imports System.Drawing.Imaging
Imports System.Drawing

Public Class QRGenerator

    Private pictureBoxQRCode As New System.Windows.Forms.PictureBox

    Public Function RenderQrCode(ByVal qrValue As String, ByVal level As String, ByVal outputFile As String) As Boolean
        Try
            'Dim level As String = comboBoxECC.SelectedItem.ToString()
            Dim eccLevel As QRCodeGenerator.ECCLevel = CType((If(level = "L", 0, If(level = "M", 1, If(level = "Q", 2, 3)))), QRCodeGenerator.ECCLevel)

            Using qrGenerator As QRCodeGenerator = New QRCodeGenerator()

                Using qrCodeData As QRCodeData = qrGenerator.CreateQrCode(qrValue, eccLevel)

                    'pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(20, Color.Black, Color.White, GetIconBitmap(), 15)

                    Using qrCode As QRCode = New QRCode(qrCodeData)
                        pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(20, Color.Black, Color.White, Nothing, 15)
                        Me.pictureBoxQRCode.Size = New System.Drawing.Size(pictureBoxQRCode.Width, pictureBoxQRCode.Height)
                        Me.pictureBoxQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
                        pictureBoxQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                    End Using
                End Using
            End Using

            pictureBoxQRCode.BackgroundImage.Save(outputFile, ImageFormat.Jpeg)
            Return True
        Catch ex As Exception

            Return False
        End Try

    End Function

    'Private Function GetIconBitmap() As Bitmap
    '    Dim img As Bitmap = Nothing

    '    If iconPath.Text.Length > 0 Then

    '        Try
    '            img = New Bitmap(iconPath.Text)
    '        Catch __unusedException1__ As Exception
    '        End Try
    '    End If

    '    Return img
    'End Function

End Class
