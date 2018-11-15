<!-- default file list -->
*Files to look at*:

* [Window1.xaml](./CS/Window1.xaml) (VB: [Window1.xaml.vb](./VB/Window1.xaml.vb))
* [Window1.xaml.cs](./CS/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/Window1.xaml.vb))
<!-- default file list end -->
# How to create the CellStyle runtime (via code)


<p>In this sample, a new style for the View is created in code and assigned after columns are populated. </p>


<h3>Description</h3>

<p>Starting with v16.1, we made the Office2016White theme a default theme of our controls (see:&nbsp;<a href="https://www.devexpress.com/Support/Center/VersionHistory/BreakingChanges?id=BC3420">BC3420</a>). Since TableView's CellStyle is theme-dependent, you need to use GridRowThemeKeyExtension's ThemeName to use a correct BaedOn theme resource.&nbsp;<br><br>See also:&nbsp;<br><a data-ticket="T152867">T152867 - How to use CellStyle in different themes</a></p>

<br/>


