using System;

public interface IDamageable {
    public void TakeDamage(int damage);
    public event Action OnTakeDamage;
}
