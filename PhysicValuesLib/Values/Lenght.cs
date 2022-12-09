namespace PhysicValuesLib.Values;

public class Lenght : IValue
{
    private double Value { get; set; }
    private string? From { get; set; }
    private string? To { get; set; }

    private string _valueName = "Длинна";


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
        { "Сантиметры",   1      },
        { "Метры",        100    },
        { "Километры",    100000 },
        { "Миллиметры",   0.1    },
        { "Дециметры",    10     },
    };
}