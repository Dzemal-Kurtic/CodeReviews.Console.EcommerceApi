using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DzemalKurtic.DTOs.Category.Request;

public record CreateCategoryDto([Required] string Name);

