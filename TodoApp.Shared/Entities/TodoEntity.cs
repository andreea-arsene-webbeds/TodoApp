using System;

namespace TodoApp.Shared.Entities
{
    public class TodoEntity
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool Done { get; set; }
    }
}
