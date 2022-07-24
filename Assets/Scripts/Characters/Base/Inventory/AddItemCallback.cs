public class AddItemCallback 
{
    public enum ResultType
    {
        Success,
        Partially,
        Failed
    }

    public ResultType Result { get; }
    public int NotAddedCount { get; }

    public AddItemCallback(ResultType result)
    {
        Result = result;
        NotAddedCount = 0;
    }
    public AddItemCallback(ResultType result, int notAddedCount)
    {
        Result = result;
        NotAddedCount = notAddedCount;
    }
}
