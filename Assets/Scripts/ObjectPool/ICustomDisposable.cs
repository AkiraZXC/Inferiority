using System;

namespace ObjectPool
{
    public interface ICustomDisposable : IDisposable
    {
        Action OnDispose { get; set; }
    }
}