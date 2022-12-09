using PhysicValuesLib;

public class Speed : IValue
{
    private double Value { get; set; }
    private string? From { get; set; }
    private string? To { get; set; }

    private string _valueName = "Скорость";


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
        { "Метры в секунду",       1        },
        { "Километры в секунду",   1000     },
        { "Километры в час",       0.277778 },
        { "Метры в минуту",        0.016667 },

    };
}
