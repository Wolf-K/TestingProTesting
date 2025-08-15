using ArcGIS.Desktop.Catalog;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;

namespace TestAddIn
{
  internal class TestButton : Button
  {
    protected override async void OnClick()
    {
      // Create and configure the OpenItemDialog to select a folder
      var openItemDialog = new OpenItemDialog
      {
        Title = "Select a folder to add to the project",
        MultiSelect = false,
        Filter = ItemFilters.Folders // Only allow folder selection
      };

      // Show the dialog and get the selected item
      var ok = openItemDialog.ShowDialog();
      if (!ok.Value || openItemDialog.Items.Count == 0)
        return; // Exit if no folder is selected

      var selectedFolder = openItemDialog.Items[0].Path;

      // Add the selected folder as a connection to the current ArcGIS Pro project
      await QueuedTask.Run(() =>
      {
        var folderConnection = ItemFactory.Instance.Create(selectedFolder, ItemFactory.ItemType.PathItem);
        Project.Current.AddItem((IProjectItem)folderConnection);
      });
    }
  }
}
