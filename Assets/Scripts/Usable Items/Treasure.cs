[System.Serializable]
public class Treasure : Item {
    private int _value;
    public int Value => _value;

    public Treasure(TreasureSO so) : base(so) => this._value = so.value;
}
