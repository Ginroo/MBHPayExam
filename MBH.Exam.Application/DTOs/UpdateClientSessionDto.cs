using System.ComponentModel.DataAnnotations;

namespace MBH.Exam.Application.DTOs;

public class UpdateClientSessionDto
{
    [Required(ErrorMessage = "Client name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Client name must be between 1 and 100 characters")]
    public string ClientName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Session date is required")]
    public DateTime SessionDate { get; set; }

    [Required(ErrorMessage = "Session type is required")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Session type must be between 1 and 50 characters")]
    public string SessionType { get; set; } = string.Empty;

    [Required(ErrorMessage = "Provider name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Provider name must be between 1 and 100 characters")]
    public string ProviderName { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
    public string Notes { get; set; } = string.Empty;
}
