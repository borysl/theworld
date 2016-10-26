using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TheWorld.ViewModels
{
    [DebuggerDisplay("{Name}({Email}) sends message {Message}")]
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Message { get; set; }
    }
}
