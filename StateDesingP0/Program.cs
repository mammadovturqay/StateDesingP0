using System;
using System.Collections.Generic;

// Memento nesnesi
public class Memento
{
    public string State { get; }

    public Memento(string state)
    {
        State = state;
    }
}

// Originator sınıfı
public class Originator
{
    private string state;

    public string State
    {
        get => state;
        set
        {
            state = value;
            Console.WriteLine($"State set to: {state}");
        }
    }

    public Memento Save()
    {
        Console.WriteLine("Saving state...");
        return new Memento(state);
    }

    public void Restore(Memento memento)
    {
        state = memento.State;
        Console.WriteLine($"State restored to: {state}");
    }
}

// Caretaker sınıfı
public class Caretaker
{
    private List<Memento> mementos = new List<Memento>();

    public void AddMemento(Memento memento)
    {
        mementos.Add(memento);
    }

    public Memento GetMemento(int index)
    {
        return mementos[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        originator.State = "State 1";
        caretaker.AddMemento(originator.Save());

        originator.State = "State 2";
        caretaker.AddMemento(originator.Save());

        originator.State = "State 3";

        // Geri alma işlemi
        originator.Restore(caretaker.GetMemento(1)); // State 2'ye geri dönülüyor
    }
}
