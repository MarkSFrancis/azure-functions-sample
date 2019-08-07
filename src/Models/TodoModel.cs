using System;
using System.ComponentModel.DataAnnotations;

namespace AzureFunctionsSample.Models
{
    public class TodoModel
    {
        public TodoModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? CompletedOn { get; set; }
    }
}
