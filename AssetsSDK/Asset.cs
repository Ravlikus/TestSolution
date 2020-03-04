using System;
using System.Collections.Generic;
using System.Text;

namespace AssetsSDK
{
    public abstract class Asset
    {
        public abstract bool CanAddFields { get; set; }
        public abstract Dictionary<string,Field> Fields { get; set; }
        public virtual bool ValidateFields()
        {
            foreach (var required in RequiredFields)
            {
                if (!Fields.ContainsKey(required.Key) ||
                    Fields[required.Key].GetType()!=required.Value)
                {
                    return false;
                }
            }
            return true;
        }
        public abstract Dictionary<string, Type> RequiredFields { get; protected set; }
    }

    public class BankMoneyAsset : Asset
    {
        public override bool CanAddFields { get; set; } = false;
        public override Dictionary<string, Field> Fields { get; set; } = new Dictionary<string, Field>();

        public override Dictionary<string, Type> RequiredFields { get; protected set; } =
            new Dictionary<string, Type>
            {
                { "Имя",typeof(StringField) },
                { "Банк", typeof(StringField) },
                { "Номер счёта", typeof(StringField) },
                { "Значение", typeof(CurrencyField) }
            };

        public override string ToString()
        {
            var name = ((StringField)Fields["Имя"]).Value;
            var account = ((StringField)Fields["Номер счёта"]).Value;
            var bank = ((StringField)Fields["Банк"]).Value;
            var value = ((CurrencyField)Fields["Значение"]).Value.ToString();
            return $"{name}: На счету №{account} в {bank} {value}.";
        }

    }

    public class OtherMoneyAsset : Asset
    {
        public override bool CanAddFields { get; set; } = false;
        public override Dictionary<string, Type> RequiredFields { get; protected set; } =
            new Dictionary<string, Type>
            {
                { "Имя",typeof(StringField) },
                { "Значение", typeof(CurrencyField) }
            };
        public override Dictionary<string, Field> Fields { get; set; } = new Dictionary<string, Field>();
        public override string ToString()
        {
            var value = ((CurrencyField)Fields["Значение"]).Value;
            return $"{Fields["Имя"].ToString()}: {value}.";
        }
    }

    public class NonMoneyAsset : Asset
    {
        public override bool CanAddFields { get; set; } = true;
        public override Dictionary<string, Type> RequiredFields { get; protected set; } =
            new Dictionary<string, Type>
            {
                { "Имя",typeof(StringField) },
                { "Начальная балансовая стоимость",typeof(CurrencyField) },
                { "Остаточная балансовая стоимость",typeof(CurrencyField) },
                { "Оценочная стоимость",typeof(CurrencyField) }
            };
        public override Dictionary<string, Field> Fields {get;set;} = new Dictionary<string, Field>();
        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var field in Fields)
            {
                if (RequiredFields.ContainsKey(field.Key))
                {
                    result.Append($", {field.Value}");
                }
                else
                {
                    result.Append($",{field.Key}  {field.Value}");
                }
            }
            result.Remove(0, 2);
            result.Append(".");
            return result.ToString();
        }

    }

}
