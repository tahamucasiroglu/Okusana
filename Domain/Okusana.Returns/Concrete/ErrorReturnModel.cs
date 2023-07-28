using Okusana.Returns.Base;

namespace Okusana.Returns.Concrete
{
    public sealed record ErrorReturnModel<T> : ReturnModelBase<T>
    {
        public ErrorReturnModel() : base(false, null, default, null) { }
        public ErrorReturnModel(string? Message) : base(false, Message, default, null) { }
        public ErrorReturnModel(T? Data) : base(false, null, Data, null) { }
        public ErrorReturnModel(string? Message, T? Data) : base(false, Message, Data, null) { }
        public ErrorReturnModel(Exception? Exception) : base(false, null, default, Exception) { }
        public ErrorReturnModel(string? Message, Exception? Exception) : base(false, Message, default, Exception) { }
        public ErrorReturnModel(T? Data, Exception? Exception) : base(false, null, Data, Exception) { }
        public ErrorReturnModel(string? Message, T? Data, Exception? Exception) : base(false, Message, Data, Exception) { }
    }
}
