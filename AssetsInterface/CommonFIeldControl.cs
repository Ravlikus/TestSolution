using System;
using System.Windows.Forms;
using AssetsSDK;

namespace AssetsInterface
{
    public partial class CommonFieldControl : UserControl
    {
        private StringField _field;
        public delegate void OnValidation();
        public OnValidation AfterTextChangedMethod;

        public bool FieldNameBlocked
        {
            get
            {
                return NameTB.Enabled;
            }
            set
            {
                NameTB.Enabled = !value;
            }
        }

        public CommonFieldControl(StringField field)
        {
            InitializeComponent();
            _field = field;
            NameTB.Text = field.Name;
            if (field.Value != null)
            {
                ValueTB.Text = field.Value;
            }
        }

        public StringField GetField()
        {
            _field.Value = ValueTB.Text;
            _field.Name = NameTB.Text;
            return _field;
        }
        public bool IsValid()
        {
            if (NameTB.Text == ""|| ValueTB.Text == "")
                return false;
            return true;
        }

        private void NameTB_TextChanged(object sender, EventArgs e)
        {
            AfterTextChangedMethod?.Invoke();
            AfterTextChangedMethod = null;
        }

        private void ValueTB_TextChanged(object sender, EventArgs e)
        {
            AfterTextChangedMethod?.Invoke();
            AfterTextChangedMethod = null;
        }
    }
}
