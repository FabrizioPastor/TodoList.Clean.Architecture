using System.Collections.Generic;
using Shared.Domain.Bus.Event;

namespace Shared.Domain.ToDosItems.Domain
{
    public class ToDoItemCreatedDomainEvent : DomainEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        
        public ToDoItemCreatedDomainEvent(string id, string title, string description, bool isDone, string eventId = null, 
            string occurredOn = null) : base(id, eventId, occurredOn)
        {
            Title = title;
            Description = description;
            IsDone = isDone;
        }

        public ToDoItemCreatedDomainEvent()
        {
        }

        public override string EventName()
        {
            return "todoitem.created";
        }

        public override Dictionary<string, string> ToPrimitives()
        {
            return new Dictionary<string, string>
            {
                {"title", Title},
                {"description", Description},
                { "isDone", IsDone.ToString()}
            };
        }

        public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId, string occurredOn)
        {
            return new ToDoItemCreatedDomainEvent(aggregateId, body["title"], body["description"], 
                bool.Parse( body["isDone"]), eventId, occurredOn);
        }
    }
}