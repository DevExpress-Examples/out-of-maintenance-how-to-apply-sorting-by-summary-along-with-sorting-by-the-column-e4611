# How to apply sorting by Summary along with sorting by the Column


<p>This example shows how to sort group summary items along with the column that the summary is aligned with.</p>
<p>To add this functionality, you can use the proposed helper class (GroupSummaryOptions) in your solution. Just set the attached property of the Grid to "True".<br /><br /></p>
<p>Note that currently, DXGrid doesn't support sorting by multiple summaries in a single column out of the box. To implement it manually, handle the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfGridGridControl_CustomColumnSorttopic">CustomColumnSort</a> event.</p>

<br/>


