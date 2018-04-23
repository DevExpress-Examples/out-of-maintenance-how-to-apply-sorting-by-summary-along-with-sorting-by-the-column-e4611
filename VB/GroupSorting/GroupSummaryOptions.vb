Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports DevExpress.Xpf.Grid

Namespace GridControlOptions
    Public Class GroupSummaryOptions
#Region "Attached Properties"

#Region "SortGroupSummaryWithColumn"
        Public Shared Function GetSortGroupSummaryWithColumn(ByVal obj As DependencyObject) As Boolean
            Return CBool(obj.GetValue(SortGroupSummaryWithColumnProperty))
        End Function
        Public Shared Sub SetSortGroupSummaryWithColumn(ByVal obj As DependencyObject, ByVal value As Boolean)
            obj.SetValue(SortGroupSummaryWithColumnProperty, value)
        End Sub
        Public Shared ReadOnly SortGroupSummaryWithColumnProperty As DependencyProperty = DependencyProperty.RegisterAttached("SortGroupSummaryWithColumn", GetType(Boolean), GetType(GroupSummaryOptions), New PropertyMetadata(False))
#End Region

#Region "AlreadyHandled"
        Private Shared Function GetAlreadyHandled(ByVal obj As DependencyObject) As Boolean
            Return CBool(obj.GetValue(AlreadyHandledProperty))
        End Function
        Private Shared Sub SetAlreadyHandled(ByVal obj As DependencyObject, ByVal value As Boolean)
            obj.SetValue(AlreadyHandledProperty, value)
        End Sub
        Private Shared ReadOnly AlreadyHandledProperty As DependencyProperty = DependencyProperty.RegisterAttached("AlreadyHandled", GetType(Boolean), GetType(GroupSummaryOptions), New PropertyMetadata(False))
#End Region

#End Region

        Shared Sub New()
            EventManager.RegisterClassHandler(GetType(GridControl), GridControl.StartSortingEvent, New RoutedEventHandler(AddressOf OnGridControlStartSorting))
        End Sub

#Region "OnGridControlStartSorting"
        Private Shared Sub OnGridControlStartSorting(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim Grid As GridControl = CType(sender, GridControl)
            If (Not GetSortGroupSummaryWithColumn(Grid)) OrElse GetAlreadyHandled(Grid) Then
                Return
            End If
            SetAlreadyHandled(Grid, True)

            For Each sortInfo As GridSortInfo In Grid.SortInfo
                Dim summaryItem As GridSummaryItem = FindGridSummaryItem(Grid, sortInfo.FieldName)
                If summaryItem IsNot Nothing Then
                    Dim groupedColumns As ArrayList = GetGroupedColumns(Grid)
                    Dim newSortInfoList As New ArrayList()
                    For Each col As GridColumn In groupedColumns
                        Dim groupSummaryInfo As GridGroupSummarySortInfo = FindGridGroupSummarySortInfo(Grid, summaryItem.FieldName)
                        If groupSummaryInfo IsNot Nothing AndAlso groupSummaryInfo.SortOrder = sortInfo.SortOrder Then
                            Continue For
                        End If

                        Dim newSortInfo As New GridGroupSummarySortInfo(summaryItem, col.FieldName, sortInfo.SortOrder)
                        newSortInfoList.Add(newSortInfo)
                        e.Handled = True
                    Next col
                    Grid.GroupSummarySortInfo.AddRange(CType(newSortInfoList.ToArray(GetType(GridGroupSummarySortInfo)), GridGroupSummarySortInfo()))
                    Continue For
                End If
            Next sortInfo

            SetAlreadyHandled(Grid, False)
        End Sub

        Private Shared Function FindGridGroupSummarySortInfo(ByVal Grid As GridControl, ByVal FieldName As String) As GridGroupSummarySortInfo
            For Each sortInfo As GridGroupSummarySortInfo In Grid.GroupSummarySortInfo
                If sortInfo.SummaryItem.FieldName = FieldName Then
                    Return sortInfo
                End If
            Next sortInfo

            Return Nothing
        End Function
        Private Shared Function FindGridSummaryItem(ByVal Grid As GridControl, ByVal FieldName As String) As GridSummaryItem
            For Each SummaryItem As GridSummaryItem In Grid.GroupSummary
                If SummaryItem.FieldName = FieldName Then
                    Return SummaryItem
                End If
            Next SummaryItem

            Return Nothing
        End Function

        Private Shared Function GetGroupedColumns(ByVal Grid As GridControl) As ArrayList
            Dim result As New ArrayList()

            For Each col As GridColumn In Grid.Columns
                If col.GroupIndex > -1 Then
                    result.Add(col)
                End If
            Next col

            result.Sort(New GridColumnGroupComparer())
            Return result
        End Function

        Private Class GridColumnGroupComparer
            Implements IComparer
            Private Function IComparer_Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
                Return (CType(x, GridColumn)).GroupIndex.CompareTo((CType(y, GridColumn)).GroupIndex)
            End Function
        End Class
#End Region
    End Class
End Namespace
