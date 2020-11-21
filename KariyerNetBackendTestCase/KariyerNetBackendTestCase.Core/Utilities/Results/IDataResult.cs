namespace KariyerNetBackendTestCase.Core.Utilities.Results
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }

        bool IsNullOrEmpty()
        {
            return Data == null;
        }

        bool IsNotNullOrEmpty()
        {
            return Data != null;
        }
    }
}
