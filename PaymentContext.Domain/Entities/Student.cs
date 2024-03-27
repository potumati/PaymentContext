using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;


public class Student : Entity
{
    private readonly List<Subscription> _subscriptions;
    public Student(Name name, Document document, Email email)
    {

        Name = name;
        Document = document;
        Email = email;
        _subscriptions = [];
    }


    public Name? Name { get; private set; }
    public Document? Document { get; private set; }
    public Email? Email { get; private set; }
    public Address? Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();

    public void AddSubscription(Subscription subscription)
    {
        foreach (var sub in _subscriptions)
            sub.Inativate();

        _subscriptions.Add(subscription);

    }
}
