using DevStore.Domain.Events;
namespace DevStore.Domain.Entities;
public class Sale
{
    private readonly List<SaleItem> _items = new();
    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();
    public Guid Id { get; } = Guid.NewGuid();
    public string SaleNumber { get; private set; }
    public DateTime Date { get; private set; }
    public Guid CustomerId { get; }
    public string CustomerName { get; }
    public Guid BranchId { get; }
    public string BranchName { get; }
    public bool IsCancelled { get; private set; }
    public decimal Total => _items.Sum(i => i.Total);

    private readonly List<object> _events = new();
    public IReadOnlyCollection<object> DomainEvents => _events.AsReadOnly();
    void AddEvent(object e) => _events.Add(e);
    public void ClearEvents() => _events.Clear();

    private Sale() { }

    public Sale(string saleNumber, DateTime date, Guid customerId, string customerName, Guid branchId, string branchName)
    {
        SaleNumber = saleNumber; Date = date; CustomerId = customerId; CustomerName = customerName; BranchId = branchId; BranchName = branchName;
        AddEvent(new SaleCreatedEvent(Id));
    }

    public void AddItem(Guid prodId, string name, int qty, decimal price)
    {
        var item = new SaleItem(prodId, name, qty, price);
        _items.Add(item);
        AddEvent(new ItemAddedEvent(Id, item.Id));
    }

    public void ReplaceItems(IEnumerable<SaleItem> items)
    {
        _items.Clear();
        _items.AddRange(items);
        AddEvent(new SaleModifiedEvent(Id));
    }

    public void Cancel()
    {
        if (IsCancelled) return;
        IsCancelled = true;
        AddEvent(new SaleCancelledEvent(Id));
    }

    public void CancelItem(Guid itemId)
    {
        var it = _items.First(i => i.Id == itemId);
        it.Cancel();
        AddEvent(new ItemCancelledEvent(Id, itemId));
    }
}
