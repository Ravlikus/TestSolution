using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AssetsSDK;

namespace AssetsInterface
{
    public partial class EditForm : Form
    {
        private Asset _currentAsset;
        private List<Asset> _assets;
        private bool _updated = false;
        private bool _canAddFields = false;
        private bool _fieldsInitialized = false;
        private int _heightCounter = 50;
        public EditForm(List<Asset> assets)
        {
            _assets = assets;
            InitializeComponent();
        }

        public bool AddAsset()
        {
            var result = ShowDialog();
            return _updated;
        }

        public bool EditAsset(Asset editedAsset)
        {
            AssetTypeCB.Enabled = false;
            ShowExistingAsset(editedAsset);
            ShowDialog();
            return _updated;
        }

        private void AssetTypeCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_fieldsInitialized)
            {
                AssetTypeCB.Enabled = false;
                if (AssetTypeCB.SelectedItem.ToString() == "Актив банковского счёта")
                {
                    var asset = new BankMoneyAsset();
                    ShowNewAsset(asset);
                }
                else if (AssetTypeCB.SelectedItem.ToString() == "Денежный актив")
                {
                    var asset = new OtherMoneyAsset();
                    ShowNewAsset(asset);
                }
                else
                {
                    var asset = new NonMoneyAsset();
                    ShowNewAsset(asset);
                }
            }
        }

        private void ShowNewAsset(Asset asset)
        {
            _canAddFields = asset.CanAddFields;
            _currentAsset = asset;
            _assets.Add(asset);
            foreach (var required in asset.RequiredFields)
            {
                Control fieldControl;
                if (required.Value == typeof(CurrencyField))
                {
                    var field = new CurrencyField();
                    field.Name = required.Key;
                    fieldControl = new CurrencyControl(field);
                }
                else
                {
                    var field = new StringField();
                    field.Name = required.Key;
                    fieldControl = new CommonFieldControl(field);
                    ((CommonFieldControl)fieldControl).FieldNameBlocked = true;
                }
                fieldControl.Location = new Point(15, _heightCounter);
                _heightCounter += fieldControl.Size.Height + 5;
                Controls.Add(fieldControl);
                Height = _heightCounter + fieldControl.Size.Height +10;
            }
            if (_canAddFields)
            {
                AddEmptyField();
            }
        }

        private void ShowExistingAsset(Asset asset)
        {
            _fieldsInitialized = true;
            _currentAsset = asset;
            if (asset is BankMoneyAsset)
            {
                AssetTypeCB.SelectedItem = "Актив банковского счёта";
            }
            else if (asset is OtherMoneyAsset)
            {
                AssetTypeCB.SelectedItem = "Денежный актив";
            }
            else AssetTypeCB.SelectedItem = "Неденежный актив";
            _canAddFields = asset.CanAddFields;
            foreach (var pair in asset.Fields)
            {
                Control fieldControl;
                if (pair.Value is CurrencyField)
                {
                    fieldControl = new CurrencyControl((CurrencyField)pair.Value);
                }
                else
                {
                    fieldControl = new CommonFieldControl((StringField)pair.Value);
                }
                fieldControl.Location = new Point(15, _heightCounter);
                _heightCounter += fieldControl.Size.Height + 5;
                Controls.Add(fieldControl);
                Height = _heightCounter + fieldControl.Size.Height + 10;
            }
            if (_canAddFields)
            {
                AddEmptyField();
            }
        }

        private void AddEmptyField()
        {
            var nextField = new StringField();
            var addedControl = new CommonFieldControl(nextField);
            addedControl.FieldNameBlocked = false;
            addedControl.AfterTextChangedMethod = AddEmptyField;
            addedControl.Location = new Point(15, _heightCounter);
            _heightCounter += addedControl.Size.Height + 5;
            Controls.Add(addedControl);
            Height = _heightCounter + 10 + addedControl.Size.Height;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (AssetTypeCB.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип актива");
                return;
            }
            var validated = true;
            foreach (var control in Controls)
            {
                if (control is CommonFieldControl)
                {
                    var currentControl = (CommonFieldControl)control;
                    if (!currentControl.IsValid() && currentControl.AfterTextChangedMethod == null)
                    {
                        validated = false;
                    }
                }
                else if (control is CurrencyControl)
                {
                    if (!((CurrencyControl)control).IsValid())
                    {
                        validated = false;
                    }
                }
            }
            if (validated)
            {
                foreach (var control in Controls)
                {
                    if (control is CommonFieldControl && 
                        ((CommonFieldControl)control).AfterTextChangedMethod == null)
                    {
                        var field = ((CommonFieldControl)control).GetField();
                        if (_currentAsset.Fields.ContainsKey(field.Name))
                        {
                            _currentAsset.Fields[field.Name] = field;
                        }
                        else _currentAsset.Fields.Add(field.Name, field);
                    }
                    else if (control is CurrencyControl)
                    {
                        var field = ((CurrencyControl)control).GetField();
                        if (_currentAsset.Fields.ContainsKey(field.Name))
                        {
                            _currentAsset.Fields[field.Name] = field;
                        }
                        else _currentAsset.Fields.Add(field.Name, field);
                    }
                }
                _updated = true;
                Close();
            }
            else MessageBox.Show("Перед сохранением заполните все поля");
        }
    }
}
