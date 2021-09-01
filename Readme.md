<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128648284/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4611)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [GroupSummaryOptions.cs](./CS/GroupSorting/GroupSummaryOptions.cs) (VB: [GroupSummaryOptions.vb](./VB/GroupSorting/GroupSummaryOptions.vb))
* [MainWindow.xaml](./CS/GroupSorting/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/GroupSorting/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/GroupSorting/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/GroupSorting/MainWindow.xaml.vb))
* [OrderHelper.cs](./CS/GroupSorting/OrderHelper.cs) (VB: [OrderHelper.vb](./VB/GroupSorting/OrderHelper.vb))
* [RandomStringHelper.cs](./CS/GroupSorting/RandomStringHelper.cs) (VB: [RandomStringHelper.vb](./VB/GroupSorting/RandomStringHelper.vb))
<!-- default file list end -->
# How to apply sorting by Summary along with sorting by the Column


<p>This example shows how to sort group summary items along with the column that the summary is aligned with.</p>
<p>To add this functionality, you can use the proposed helper class (GroupSummaryOptions) in your solution. Just set the attached property of the Grid to "True".<br /><br /></p>
<p>Note that currently, DXGrid doesn't support sorting by multiple summaries in a single column out of the box. To implement it manually, handle the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfGridGridControl_CustomColumnSorttopic">CustomColumnSort</a> event.</p>

<br/>


