public interface ICanAttack {
    public float AttackRange { get; }
    public void Attack(IDamageable target);
}
