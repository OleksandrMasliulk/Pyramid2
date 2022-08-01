public interface IListenAxisInput {
    public float Horizontal { get; }
    public float Vertical { get; }
    public void ReadInput();
}
