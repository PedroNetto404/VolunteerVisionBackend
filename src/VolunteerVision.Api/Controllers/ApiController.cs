using Microsoft.AspNetCore.Mvc;

namespace VolunteerVision.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class ApiController;
