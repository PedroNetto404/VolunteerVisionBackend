using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VolunteerVision.Application.Ports;
using VolunteerVision.Infra.Persistence;
using VolunteerVision.Infra.Security.Models;
using VolunteerVision.Infra.Security.Services;

namespace VolunteerVision.Infra;

public static class DepedencyInjection
{




    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        //TODO: implement the following code
        return app;
    }
}
