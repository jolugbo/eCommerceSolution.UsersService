using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Dto;

public record UserDTO(
    Guid UserId,
    string Email,
    string PersonName   ,
    string Gender
);
