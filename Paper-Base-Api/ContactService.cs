namespace Paper_Base_Api;

public class ContactService
{
    public static IList<Contact> Contacts = new List<Contact>()
    {
        new ()
        {
            First = "John Doe",
            Avatar = "http://avatar.pl",
            Last = "Doe",
            Twitter = "twitter",
            Notes = "cos"
        }
    };

    public void Add(Contact contact)
    {
        Contacts.Add(contact);
    }

    public void Remove(Guid id)
    {
        var contactToDelete = Contacts.First(x=>x.Id == id);
        Contacts.Remove(contactToDelete);
    }
    
    public void Update(Guid id, Contact contact)
    {
        var contactToDelete = Contacts.First(x=>x.Id == id);
        var updated = contactToDelete with
        {
            Id = id,
            First = contact.First, Last = contact.Last, Twitter = contact.Twitter,
            Avatar = contact.Avatar, Notes = contact.Notes
        };
        
        Remove(id);
        Add(updated);
    }

    public IEnumerable<Contact> GetAll()
        => Contacts;
}

public record Contact
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string First { get; init; }
    public string Last { get; init; }
    public string Twitter { get; init; }
    public string Avatar { get; init; }
    public string Notes { get; init; }
}

