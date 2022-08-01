public class UseItemCallback {
    public enum ResultType {
        Success,
        Failed
    }
    
    public ResultType Result { get; private set; }

    public UseItemCallback(ResultType result) => Result = result;
}
