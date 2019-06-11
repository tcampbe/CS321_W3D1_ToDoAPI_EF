using System;
using System.ComponentModel.DataAnnotations;

namespace CS321_W3D1_ToDoAPI_EF.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 2)]
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public DateTime DueDate { get; set; }
    }
}
