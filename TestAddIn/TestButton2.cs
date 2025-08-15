using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Core;

namespace TestAddIn
{
  internal class TestButton2 : Button
  {
    protected override void OnClick()
    {
      // Retrieves the URI of the current ArcGIS Pro project file (*.aprx)
      var projectUri = Project.Current?.URI;

      // Convert the URI to a local file path if needed
      var projectFilePath = projectUri != null ? new System.Uri(projectUri).LocalPath : null;

      // projectFilePath now contains the full path to the current .aprx file
    }
  }
}
