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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;

namespace GroupSorting {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

    }
}
