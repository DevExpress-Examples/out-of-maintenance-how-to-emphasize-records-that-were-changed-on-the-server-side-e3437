<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128539848/11.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3437)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [BusinessObject.cs](./CS/WebSite/App_Code/BusinessObject.cs) (VB: [BusinessObject.vb](./VB/WebSite/App_Code/BusinessObject.vb))
* [DataItem.cs](./CS/WebSite/App_Code/DataItem.cs) (VB: [DataItem.vb](./VB/WebSite/App_Code/DataItem.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to emphasize records that were changed on the server side
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3437/)**
<!-- run online end -->


<p>It is possible to refresh the grid content using a time interval. However, in cases when some records were changed on the server side, it is hard to distinguish what rows were updated.<br />
The example illustrates how to highlight changed records using<strong> jQuery effects</strong>.</p><p><strong>See a</strong><strong>lso</strong><strong>:</strong><br />
<a href="http://community.devexpress.com/blogs/aspnet/archive/2011/06/30/web-design-tip-how-to-add-jquery-yellow-fade-effect-to-asp-net-gridview.aspx"><u>Web Design Tip: How-To Add jQuery Yellow Fade Effect to ASP.NET GridView</u></a></p>


<h3>Description</h3>

<p>The example uses a timer with <i>20 sec</i> interval. When the grid is refreshed, its visible page is transferred to the client side. Client-side scripts examine the difference between rows and then highlight them.<br />
The data source structure uses the <i>&quot;lock&quot;</i> field, which is increased during each record update. The client-side code compares the <i>&quot;lock&quot;</i> field values of records with same indices. If the comparison result is <i>&quot;false&quot;</i>, we highlight records.</p><p>In complex scenarios, when the order of records can be changed, the demonstrated approach might stop working.</p><p>Since all values are stored in a Session, it is possible to open the same demo in two tabs and see how the grid on the first tab behaves when records of the grid in the second tab are edited.</p>

<br/>


