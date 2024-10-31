using Robbochinni.Driver.Mag.ValueObjects;
using System.Runtime.CompilerServices;

namespace Robbochinni.Driver.Mag.Output
{
    public class Result
    {
        public int StatusCode { get; protected set; }
        public bool IsSucess { get; protected set; }
        public Message? Message { get; protected set; }
        public object? Payload { get; protected set; }

        public Result SetMessage(string Message)
        {
            this.Message = new Message(Message);
            return this;
        }

        public Result SetPayload(object Payload)
        {
            this.Payload = Payload;
            return this;
        }


    }

    public class Success : Result
    {
        public Success()
        {
            StatusCode = 200;
            IsSucess = true;
        }
    }

    public class Error : Result
    {
        public Error()
        {
            IsSucess = false;
        }
        public Result SetStatusCode(int Code)
        {
            StatusCode = Code;
            return this;
        }

        public Result SetException(Exception Ex)
        {
            SetStatusCode(500)
                .SetMessage(Ex.Message);

            return this;
        }

    }

    public class ResultBuilder
    {
        public Success? Success => new Success();
        public Error? Error => new Error();
    }
}
