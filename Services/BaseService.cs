using System.Collections.Generic;
using HermanosK.Observers;

namespace HermanosK.Services
{
    public abstract class BaseService<T> : ISubject<T>
    {
        private readonly List<HermanosK.Observers.IObserver<T>> _observers = new();

        public void Attach(HermanosK.Observers.IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void Detach(HermanosK.Observers.IObserver<T> observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(T data)
        {
            foreach (var observer in _observers)
            {
                observer.Update(data);
            }
        }
    }
}
