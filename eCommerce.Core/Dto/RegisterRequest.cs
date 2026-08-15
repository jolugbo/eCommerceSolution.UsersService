using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Dto;

public record RegisterRequest
(
 string? Email,
 string? Password,
 string? PersonName,
 GenderOptions Gender );
