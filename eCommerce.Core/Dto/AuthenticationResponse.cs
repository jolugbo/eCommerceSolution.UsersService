using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Dto;

public record AuthenticationResponse
(
Guid UserId,
string? Email,
string? PersonName,
string? Gender,
string? Token,
    bool Success
)
{
    public AuthenticationResponse() : this(default, default, default, default, default, default) { 
    
    }
};
