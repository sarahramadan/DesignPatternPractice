namespace ObserverPattern
{
    // try using the IObservable<T> and IObserver<T> that implement observer pattern

    public class WeatherData
    {
        public float Tempreature { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
    }

    public class WeatherDisplay1 : IObserver<WeatherData>
    {
        IDisposable disposable;

        public void Register(IObservable<WeatherData> observable)
        {
            disposable = observable.Subscribe(this);
        }
        public void UnRegister()
        {
            disposable?.Dispose();
        }
        public void OnCompleted()
        {
            Console.WriteLine("End od subscription");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(WeatherData value)
        {
            Console.WriteLine($"Disply 1 : {value.Tempreature.ToString()} : {value.Tempreature}");
        }
    }
    public class WeatherDisplay2 : IObserver<WeatherData>
    {
        IDisposable disposable;

        public void Register(IObservable<WeatherData> observable)
        {
            disposable = observable.Subscribe(this);
        }
        public void UnRegister()
        {
            disposable?.Dispose();
        }
        public void OnCompleted()
        {
            Console.WriteLine("End od subscription");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(WeatherData value)
        {
            Console.WriteLine($"Disply 2 : {value.Pressure.ToString()} : {value.Pressure}");
        }
    }
    public class WeatherStation : IObservable<WeatherData>
    {
        private readonly List<IObserver<WeatherData>> observers;
        public WeatherStation()
        {
            observers = new List<IObserver<WeatherData>>();
        }
        /// <summary>
        /// register new observer to get notiifcation
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscribe(observers, observer);
        }
        public void Notify(WeatherData value)
        {
            foreach (var item in observers)
            {
                item.OnNext(value);
            }
        }
        public void EndNotification()
        {
            foreach (var item in observers)
            {
                item.OnCompleted();
            }
        }
    }
    public class Unsubscribe : IDisposable
    {
        private List<IObserver<WeatherData>> _observers;
        private IObserver<WeatherData> _unsubscribeObserver;
        public Unsubscribe(List<IObserver<WeatherData>> observers, IObserver<WeatherData> source)
        {
            _observers = observers;
            _unsubscribeObserver = source;
        }
        public void Dispose()
        {
            if (_observers.Contains(_unsubscribeObserver))
            {

                _observers.Remove(_unsubscribeObserver);
            }
        }
    }

    public class Run
    {
        public void Init()
        {
            var weatherStation = new WeatherStation();
            var display1 = new WeatherDisplay1();
            var display2 = new WeatherDisplay2();

            display1.Register(weatherStation);
            display2.Register(weatherStation);

            weatherStation.Notify(new WeatherData() { Tempreature = 26, Humidity = 10, Pressure = 30 });
            weatherStation.Notify(new WeatherData() { Tempreature = 27, Humidity = 11, Pressure = 30 });

            display1.UnRegister();
            weatherStation.Notify(new WeatherData() { Tempreature = 25, Humidity = 9, Pressure = 30 });

        }

    }
}
