﻿using Microsoft.Extensions.Primitives;

namespace SoftwareCenter.Entities;

public record SoftwareItemEntity(Guid Id, string Title, string Publisher, SupportTechEntity? SupportTech = null);

public record SupportTechEntity(Guid Id, string Name, string EmailAddress);
