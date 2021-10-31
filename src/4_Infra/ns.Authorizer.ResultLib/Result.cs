namespace ns.Authorizer.ResultLib
{
    public class Result<TType>
    {
        private Result(TType valueObject, bool isSuccess)
        {
            ValueObject = valueObject;

            IsSuccess = isSuccess;
            IsFailure = !isSuccess;
        }

        public TType ValueObject { get; private set; }

        public bool IsSuccess { get; private set; }

        public bool IsFailure { get; private set; }

        public static Result<TType> Ok()
        {
            return new Result<TType>(default, true);
        }

        public static Result<TType> Ok(TType value)
        {
            return new Result<TType>(value, true);
        }

        public static Result<TType> Fail()
        {
            return new Result<TType>(default, false);
        }

        public static Result<TType> Fail(TType value)
        {
            return new Result<TType>(value, false);
        }
    }

    public class Result<TOk, TFail>
    {
        private Result(TOk ok, TFail fail, bool isSuccess, bool isFailure)
        {
            OkObject = ok;
            FailObject = fail;

            IsSuccess = isSuccess;
            IsFailure = isFailure;
        }

        public TOk OkObject { get; private set; }

        public TFail FailObject { get; private set; }

        public bool IsSuccess { get; private set; }

        public bool IsFailure { get; private set; }

        public static Result<TOk, TFail> Ok(TOk ok)
        {
            return new Result<TOk, TFail>(ok, default, true, false);
        }

        public static Result<TOk, TFail> OkWithFail(TOk ok, TFail fail)
        {
            return new Result<TOk, TFail>(ok, fail, true, true);
        }

        public static Result<TOk, TFail> Fail(TFail fail)
        {
            return new Result<TOk, TFail>(default, fail, false, true);
        }
    }
}
