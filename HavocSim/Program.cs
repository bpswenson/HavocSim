// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Test myTest = new Test();

BaseEvent ev = new EventOne<int>(myTest.DoIt, 5);

ev.Invoke();


public abstract class BaseEvent
{
    public abstract void Invoke();
}


class EventOne<T1> : BaseEvent
{
    public EventOne(Action<T1> ev, T1 v1) {
        _ev = ev;
        _v1 = v1;
    }

    public override void Invoke()
    {
        _ev(_v1);
    }

    private Action<T1> _ev;
    T1 _v1;
}


public class Test
{
    public void DoIt(int a)
    {
        Console.WriteLine("DoIt");
    }
}