using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DzemalKurtic.DTOs.Category.Request;

public record UpdateCategoryDto([property: Required] string Name);
