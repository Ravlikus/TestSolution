using System.Collections.Generic;
using AssetsSDK;

namespace AssetsInterface
{
    public static class DataInitializer
    {
        public static List<Asset> GetInitializedAssets()
        {
            var result = new List<Asset>();
            result.Add(GetBankRubAsset());
            result.Add(GetBankUsdAsset());
            result.Add(GetOtherRubAsset());
            result.Add(GetOtherUsdAsset());
            result.Add(GetUsdNonMoneyAsset());
            result.Add(GetRubNonMoneyAsset());
            return result;

        }
        private static NonMoneyAsset GetUsdNonMoneyAsset()
        {
            var result = new NonMoneyAsset();
            var nameField = new StringField("Имя", "Картина Пикассо");
            result.Fields.Add(nameField.Name, nameField);
            var nbs = new CurrencyField("Начальная балансовая стоимость", new CurencyValue(Currency.GetAllCurrencies()[0], 1000000));
            result.Fields.Add(nbs.Name, nbs);
            var obs = new CurrencyField("Остаточная балансовая стоимость", new CurencyValue(Currency.GetAllCurrencies()[0], 1000000));
            result.Fields.Add(obs.Name, obs);
            var os = new CurrencyField("Оценочная стоимость", new CurencyValue(Currency.GetAllCurrencies()[0], 1000000));
            result.Fields.Add(os.Name, os);
            return result;
        }

        private static NonMoneyAsset GetRubNonMoneyAsset()
        {
            var result = new NonMoneyAsset();
            var nameField = new StringField("Имя", "Офис");
            result.Fields.Add(nameField.Name, nameField);
            var nbs = new CurrencyField("Начальная балансовая стоимость", new CurencyValue(Currency.GetAllCurrencies()[1], 1000000));
            result.Fields.Add(nbs.Name, nbs);
            var obs = new CurrencyField("Остаточная балансовая стоимость", new CurencyValue(Currency.GetAllCurrencies()[1], 1000000));
            result.Fields.Add(obs.Name, obs);
            var os = new CurrencyField("Оценочная стоимость", new CurencyValue(Currency.GetAllCurrencies()[1], 1000000));
            result.Fields.Add(os.Name, os);
            var additionalField = new StringField("Адресс", "Пушкинская 198");
            result.Fields.Add(additionalField.Name, additionalField);
            return result;
        }

        private static OtherMoneyAsset GetOtherRubAsset()
        {
            var result = new OtherMoneyAsset();
            var nameField = new StringField("Имя", "Заначка в книге в рублях");
            result.Fields.Add(nameField.Name, nameField);
            var value = new CurrencyField("Значение", new CurencyValue(Currency.GetAllCurrencies()[1], 1000));
            result.Fields.Add(value.Name, value);
            return result;
        }

        private static OtherMoneyAsset GetOtherUsdAsset()
        {
            var result = new OtherMoneyAsset();
            var nameField = new StringField("Имя", "Заначка под кроватью в долларах");
            result.Fields.Add(nameField.Name, nameField);
            var value = new CurrencyField("Значение", new CurencyValue(Currency.GetAllCurrencies()[0], 100));
            result.Fields.Add(value.Name, value);
            return result;
        }

        private static BankMoneyAsset GetBankRubAsset()
        {
            var result = new BankMoneyAsset();
            var nameField = new StringField("Имя", "Счёт в рублях");
            result.Fields.Add(nameField.Name, nameField);
            var bankField = new StringField("Банк", "Сбербанк");
            result.Fields.Add(bankField.Name, bankField);
            var account = new StringField("Номер счёта", "1");
            result.Fields.Add(account.Name, account);
            var value = new CurrencyField("Значение", new CurencyValue(Currency.GetAllCurrencies()[1], 1000000));
            result.Fields.Add(value.Name, value);
            return result;
        }

        private static BankMoneyAsset GetBankUsdAsset()
        {
            var result = new BankMoneyAsset();
            var nameField = new StringField("Имя", "Счёт в долларах");
            result.Fields.Add(nameField.Name, nameField);
            var bankField = new StringField("Банк", "Тинькофф банк");
            result.Fields.Add(bankField.Name, bankField);
            var account = new StringField("Номер счёта", "1");
            result.Fields.Add(account.Name, account);
            var value = new CurrencyField("Значение", new CurencyValue(Currency.GetAllCurrencies()[0], 10000));
            result.Fields.Add(value.Name, value);
            return result;
        }
    }
}
