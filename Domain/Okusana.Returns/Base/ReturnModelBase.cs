using Okusana.Returns.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Returns.Base
{
    public record ReturnModelBase<T> : IReturnModel<T>
    {
        public bool Status { get; init; }
        public T? Data { get; init; }
        public string? Message { get; init; }
        public Exception? Exception { get; init; }

        public ReturnModelBase(bool Status, string? Message = null, T? Data = default, Exception? Exception = null)
        {
            this.Status = Status;
            this.Message = Message;
            this.Data = Data;
            this.Exception = Exception;
        }

        static public ReturnModelBase<TEntity> Create<TEntity>(bool Status, string? Message, TEntity? Data, Exception? Exception) => new ReturnModelBase<TEntity>(Status, Message, Data, Exception);
    }
}
