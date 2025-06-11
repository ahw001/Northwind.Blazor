using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.Blazor.Services.DTOs
{
    public class SessionStateDto
    {
        public Guid Id { get; set; }

        public string SerializedData { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
