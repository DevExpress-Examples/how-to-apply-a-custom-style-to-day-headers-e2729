Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Data

Namespace WpfApplication1
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			Dim style As Style = CType(Me.FindResource("DateHeaderStyle"), Style)
			schedulerControl1.DayView.DateHeaderStyle = style
			schedulerControl1.WorkWeekView.DateHeaderStyle = style
		End Sub
	End Class

	Public Class DateTimeToShortDateStringConverter
		Implements IValueConverter
        Public Function Convert(ByVal value As Object, ByVal targetType As Type, _
                                ByVal parameter As Object, _
                                ByVal culture As System.Globalization.CultureInfo) _
                            As Object Implements IValueConverter.Convert
            If value Is Nothing Then
                Return Nothing
            End If
            Dim dateTimeValue As DateTime = CDate(value)

            Dim param As String = If(parameter IsNot Nothing, parameter.ToString(), String.Empty)
            If param = String.Empty Then
                param = "MM/dd"
            End If

            Return dateTimeValue.ToString(param)
        End Function
        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, _
                                    ByVal parameter As Object, _
                                    ByVal culture As System.Globalization.CultureInfo) _
                                As Object Implements IValueConverter.ConvertBack
            Return Nothing
        End Function
	End Class
End Namespace
