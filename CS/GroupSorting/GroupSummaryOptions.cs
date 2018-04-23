// Developer Express Code Central Example:
// How to apply sorting by Summary along with sorting by the Column.
// 
// This example shows how to sort group summary items along with the column that
// the summary is aligned with.
// To add this functionality, you can use the
// proposed helper class (GroupSummaryOptions) in your solution. Just set the
// attached property of the Grid to "True".
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4611

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Grid;

namespace GridControlOptions {
    public class GroupSummaryOptions {
        #region Attached Properties

        #region SortGroupSummaryWithColumn
        public static bool GetSortGroupSummaryWithColumn(DependencyObject obj) {
            return (bool)obj.GetValue(SortGroupSummaryWithColumnProperty);
        }
        public static void SetSortGroupSummaryWithColumn(DependencyObject obj, bool value) {
            obj.SetValue(SortGroupSummaryWithColumnProperty, value);
        }
        public static readonly DependencyProperty SortGroupSummaryWithColumnProperty =
            DependencyProperty.RegisterAttached("SortGroupSummaryWithColumn", typeof(bool), typeof(GroupSummaryOptions), new PropertyMetadata(false));
        #endregion

        #region AlreadyHandled
        static bool GetAlreadyHandled(DependencyObject obj) {
            return (bool)obj.GetValue(AlreadyHandledProperty);
        }
        static void SetAlreadyHandled(DependencyObject obj, bool value) {
            obj.SetValue(AlreadyHandledProperty, value);
        }
        static readonly DependencyProperty AlreadyHandledProperty =
            DependencyProperty.RegisterAttached("AlreadyHandled", typeof(bool), typeof(GroupSummaryOptions), new PropertyMetadata(false));
        #endregion

        #endregion

        static GroupSummaryOptions() {
            EventManager.RegisterClassHandler(typeof(GridControl), GridControl.StartSortingEvent, new RoutedEventHandler(OnGridControlStartSorting));
        }

        static void OnGridControlStartSorting(object sender, RoutedEventArgs e) {
            GridControl Grid = (GridControl)sender;
            if (!GetSortGroupSummaryWithColumn(Grid) ||
                GetAlreadyHandled(Grid))
                return;
            SetAlreadyHandled(Grid, true);

            foreach (GridSortInfo sortInfo in Grid.SortInfo) {
                GridSummaryItem summaryItem = FindGridSummaryItem(Grid, sortInfo.FieldName);
                if (summaryItem != null) {
                    ArrayList groupedColumns = GetGroupedColumns(Grid);
                    ArrayList newSortInfoList = new ArrayList();
                    foreach (GridColumn col in groupedColumns) {
                        GridGroupSummarySortInfo groupSummaryInfo = FindGridGroupSummarySortInfo(Grid, summaryItem.FieldName);
                        if (groupSummaryInfo != null &&
                            groupSummaryInfo.SortOrder == sortInfo.SortOrder)
                            continue;

                        GridGroupSummarySortInfo newSortInfo = new GridGroupSummarySortInfo(summaryItem,
                                                                                            col.FieldName,
                                                                                            sortInfo.SortOrder);
                        newSortInfoList.Add(newSortInfo);
                        e.Handled = true;
                    }
                    Grid.GroupSummarySortInfo.AddRange((GridGroupSummarySortInfo[])newSortInfoList.ToArray(typeof(GridGroupSummarySortInfo)));
                    continue;
                }
            }

            SetAlreadyHandled(Grid, false);
        }

        static GridGroupSummarySortInfo FindGridGroupSummarySortInfo(GridControl Grid, string FieldName) {
            foreach (GridGroupSummarySortInfo sortInfo in Grid.GroupSummarySortInfo)
                if (sortInfo.SummaryItem.FieldName == FieldName)
                    return sortInfo;

            return null;
        }
        static GridSummaryItem FindGridSummaryItem(GridControl Grid, string FieldName) {
            foreach (GridSummaryItem SummaryItem in Grid.GroupSummary)
                if (SummaryItem.FieldName == FieldName)
                    return SummaryItem;

            return null;
        }

        static ArrayList GetGroupedColumns(GridControl Grid) {
            ArrayList result = new ArrayList();

            foreach (GridColumn col in Grid.Columns)
                if (col.GroupIndex > -1)
                    result.Add(col);

            result.Sort(new GridColumnGroupComparer());
            return result;
        }

        class GridColumnGroupComparer : IComparer {
            int IComparer.Compare(object x, object y) {
                return ((GridColumn)x).GroupIndex.CompareTo(((GridColumn)y).GroupIndex);
            }
        }
    }
}
