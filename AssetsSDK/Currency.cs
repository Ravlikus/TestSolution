using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssetsSDK
{

    public abstract class Currency
    {
        public abstract string Abbreviation { get; protected set; }

        public virtual string NameInCase(int number)
        {
            return Abbreviation;
        }

        public static List<Currency> GetAllCurrencies()
        {
            var currencyInstances = Assembly
                .GetExecutingAssembly()
                .GetTypes().Where(x => x.BaseType == typeof(Currency))
                .Select(x => (Currency)x.GetConstructor(new Type[] { }).Invoke(new object[] { }));
            return currencyInstances.ToList();
        }

        public override string ToString()
        {
            return Abbreviation;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Currency)) return false;
            var comparedCurrency = (Currency)obj;
            return Abbreviation.Equals(comparedCurrency.Abbreviation);
        }

        public static bool operator ==(Currency a, Currency b)
        {
            return a.Abbreviation == b.Abbreviation;
        }
        public static bool operator !=(Currency a, Currency b)
        {
            return a.Abbreviation != b.Abbreviation;
        }
    }

    public class USDCurrency : Currency
    {
        public override string Abbreviation { get; protected set; } = "USD";

        public override string NameInCase(int number)
        {
            var firstDigit = number % 10;
            var secondDigit = number % 100 / 10;
            if (secondDigit == 1 || firstDigit > 4 || firstDigit == 0)
            {
                return "долларов";
            }
            else if (firstDigit > 1)
            {
                return "доллара";
            }
            else return "доллар";
        }
    }

    public class RUBCurrency:Currency
    {
        public override string Abbreviation { get; protected set; } = "RUB";

        public override string NameInCase(int number)
        {
            var firstDigit = number % 10;
            var secondDigit = number % 100 / 10;
            if (secondDigit == 1 || firstDigit > 4 || firstDigit == 0)
            {
                return "рублей";
            }
            else if (firstDigit > 1)
            {
                return "рубля";
            }
            else return "рубль";
        }

    }

    public static class CurrencyConverter
    {
        public static Currency GetCurrencyFromAbbreviation(string abbreviation)
        {
            var currencies = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.BaseType == typeof(Currency))
                .Select(x=>(Currency)x.GetConstructor(new Type[] { }).Invoke(new object[] { }));
            return currencies.Where(x => x.Abbreviation == abbreviation).First();
        }
    }

    public class CurencyValue
    {
        public Currency Currency;
        public double Value;

        public override string ToString()
        {
            return $"{Value} {Currency.NameInCase((int)Value)}";
        }

        public CurencyValue() { }

        public CurencyValue(Currency currency, double value)
        {
            Currency = currency;
            Value = (double)value;
        }
    }
}
