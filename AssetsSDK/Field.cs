namespace AssetsSDK
{
    public abstract class Field
    {
        public abstract string Name { get; set; }
    }

    public class StringField : Field
    {
        public override string Name { get; set; }
        public string Value;

        public override string ToString()
        {
            return Value;
        }

        public StringField() { }
        public StringField(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    public class CurrencyField : Field
    {
        public override string Name { get; set; }
        public CurencyValue Value;

        public CurrencyField() { }
        public CurrencyField(string name, CurencyValue value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name} { Value.ToString()}";
        }
    }
}
