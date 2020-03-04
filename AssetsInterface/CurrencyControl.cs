using System.Windows.Forms;
using AssetsSDK;

namespace AssetsInterface
{
    public partial class CurrencyControl : UserControl
    {
        private CurrencyField _field;
        public CurrencyControl(CurrencyField field)
        {
            _field = field;
            InitializeComponent();
            InitializeCurrencies();
            ValueNumeric.Maximum = decimal.MaxValue;
            ValueNumeric.Minimum = decimal.MinValue;
            FieldName.Text = field.Name;
            if (field.Value != null)
            {
                ValueNumeric.Value = (decimal)field.Value.Value;
                CurrencyCB.SelectedItem = field.Value.Currency;
            }
            else _field.Value = new CurencyValue();
        }

        private void InitializeCurrencies()
        {
            foreach (var currencyInst in Currency.GetAllCurrencies())
            {
                CurrencyCB.Items.Add(currencyInst);
            }
        }

        public CurrencyField GetField()
        {
            _field.Value.Value = (double)ValueNumeric.Value;
            _field.Value.Currency = (Currency)CurrencyCB.SelectedItem;
            return _field;
        }

        public bool IsValid()
        {
            if (ValueNumeric.Value == 0
                || CurrencyCB.SelectedItem == null)
                return false;
            return true;
        }
    }
}
