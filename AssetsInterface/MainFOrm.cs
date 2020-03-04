using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AssetsSDK;

namespace AssetsInterface
{
    public partial class MainForm : Form
    {
        private List<Asset> _assets = new List<Asset>();
        public MainForm()
        {
            InitializeComponent();
            _assets = DataInitializer.GetInitializedAssets();
            UpdateAssets();
        }

        private void UpdateAssets() 
        {
            AssetsListBox.Items.Clear();
            foreach(var asset in _assets)
            {
                AssetsListBox.Items.Add(asset);
                var assetInStrLenght = GetStrLenInPixels(asset.ToString());
                if (assetInStrLenght > AssetsListBox.Width)
                {
                    AssetsListBox.HorizontalExtent = GetStrLenInPixels(asset.ToString()) - AssetsListBox.Width;
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var editForm = new EditForm(_assets);
            var isUpdated = editForm.AddAsset();
            if (isUpdated)
            {
                UpdateAssets(); 
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (AssetsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите актив, который хотите удалить");
            }
            else
            {
                var editForm = new EditForm(_assets);
                var isUpdated = editForm.EditAsset((Asset)AssetsListBox.SelectedItem);
                if (isUpdated)
                {
                    UpdateAssets();
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (AssetsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите актив, который хотите удалить");
            }
            else
            {
                _assets.RemoveAt(AssetsListBox.SelectedIndex);
                UpdateAssets();
            }
        }

        private int GetStrLenInPixels(string str)
        {
            var label = new Label();
            label.Text = str;
            return label.Width;
        }
    }
}
