﻿using System;

namespace TodoApp.Shared.Models
{
    public class TodoModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool Done { get; set; }
    }
}
