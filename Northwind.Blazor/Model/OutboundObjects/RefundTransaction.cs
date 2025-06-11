using System.ComponentModel.DataAnnotations;

namespace Northwind.Blazor.Model.OutboundObjects
{
    public class RefundTransaction
    {
        [Required]
        public string? RequestId { get; set; }
        [Required]
        public string? OrderId { get; set; }

        public bool Sale { get; set; } = true;
        public bool Capture { get; set; } = false;

    }
}
