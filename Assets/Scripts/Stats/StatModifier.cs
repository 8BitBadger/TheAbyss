public enum StatModType
{
    Flat = 100,
    PercentAdd = 200,
    PercentMult = 300,
}

namespace StatSystem
{
    public class StatModifier
    {
        public readonly float value;
        public readonly StatModType type;
        public readonly int order;
        public readonly object source;

        public StatModifier(float _value, StatModType _type, int _order, object _source)
        {
            value = _value;
            type = _type;
            order = _order;
            source = _source;
        }

        public StatModifier(float _value, StatModType _type) : this(_value, _type, (int)_type) { }
        public StatModifier(float _value, StatModType _type, int _order) : this(_value, _type, _order, null) { }
        public StatModifier(float _value, StatModType _type, object _source) : this(_value, _type, (int)_type, _source) { }
    }
}