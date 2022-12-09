namespace PhysicValuesLib.Values;

public class Energy : IValue
{
    private double Value { get; set; }
    private string? From { get; set; }
    private string? To { get; set; }

    private string _valueName = "Энергия";


    public double GetConvertedValue(double value, string from, string to)
    {
        Value = value;
        From = from;
        To = to;
        ToSi();
        ToRequired();
        return Value;
    }


    public List<string> GetMeasureList()
    {
        List<string> list = new List<string>();
        foreach (var str in _coeff)
        {
            list.Add(str.Key);
        }
        return list;
    }


    public void ToRequired()
    {
        Value /= _coeff[To];
    }


    public void ToSi()
    {
        Value *= _coeff[From];
    }

    public string GetValueName()
    {
        return _valueName;
    }

    private Dictionary<string, double> _coeff = new Dictionary<string, double>()
    {
        { "Килоджоуль",    1           },
        { "Мегаджоуль",    1000        },
        { "Джоуль",        0.001       },
        { "Мегакалорий",   4186.799941 },
        { "Килокалорий",   4.1868      },
        { "Калорий",       0.004187    },
    };
}
