using Patterns.Architactural_Patterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Architactural_Patterns
{
    public interface IEvent
    {
        DateTime OccurredOn { get; }
    }

   //UserCreatedEvent sınıfı, bir kullanıcının oluşturulması olayını temsil eder.
   // UserId, UserName ve OccurredOn özellikleri olayın detaylarını tutar.
   // Yapıcı(constructor) metot, olayın meydana geldiği zamanı(OccurredOn) ve kullanıcı bilgilerini(UserId, UserName) ayarlar.
    public class UserCreatedEvent : IEvent
    {
        public DateTime OccurredOn { get; private set; }
        public int UserId { get; private set; }
        public string UserName { get; private set; }

        public UserCreatedEvent(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
            OccurredOn = DateTime.UtcNow;
        }
    }

    // EventStore sınıfı, olayları saklamak ve yönetmek için kullanılır.
    // _events listesi olayları tutar
    // save metodu yeni olayı listeye ekler
    public class EventStore
    {
        private readonly List<IEvent> _events = new List<IEvent>();

        public void Save(IEvent @event)
        {
            _events.Add(@event);
        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            return _events;
        }
    }
}
