using Mapster;
using Microsoft.AspNetCore.Mvc;
using TestApi.Context;
using TestApi.Dtos;
using TestApi.Entities;

namespace TestApi.Controller;
[ApiController]
[Route("api/v1.0/[controller]")]
public class Cont:ControllerBase
{
    private ApiContext _context;
    
    public Cont(ApiContext context)
    {
        _context = context;
    }
}