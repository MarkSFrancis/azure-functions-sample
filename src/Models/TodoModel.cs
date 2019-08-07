using System;

namespace AzureFunctionsSample.Models
{
    public class TodoModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CompletedOn { get; set; }
    }
}
