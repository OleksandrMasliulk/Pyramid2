using System;

public interface IHaveSanity {
    public int MaxSanity { get; }
    public void ModifySanity(int amount);
    public event Action<int> OnSanityChanged;
}
