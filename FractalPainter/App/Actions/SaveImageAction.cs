using System.IO;
using System.Windows.Forms;
using FractalPainting.Infrastructure;

namespace FractalPainting.App.Actions
{
	public class SaveImageAction : IUiAction, INeed<IImageDirectoryProvider>, INeed<IImageHolder>
	{
		private IImageDirectoryProvider imageDirectoryProvider;
		private IImageHolder imageHolder;
		public string Category => "����";
		public string Name => "���������...";
		public string Description => "��������� ����������� � ����";

		public void Perform()
		{
			var dialog = new OpenFileDialog
			{
				CheckFileExists = false,
				Multiselect = false,
				InitialDirectory = Path.GetFullPath(imageDirectoryProvider.ImagesDirectory)
				
			};
			var res = dialog.ShowDialog();
			if (res == DialogResult.OK)
				imageHolder.SaveImage(dialog.FileName);
		}

		public void SetDependency(IImageDirectoryProvider dependency)
		{
			imageDirectoryProvider = dependency;
		}

		public void SetDependency(IImageHolder dependency)
		{
			imageHolder = dependency;
		}
	}

}