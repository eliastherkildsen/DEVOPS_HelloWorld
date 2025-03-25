using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var language = LanguageService.Instance.GetLanguages();
        var response = Ok(new GetLanguageModel.Response { DefaultLanguage = language.DefaultLanguage, Languages = language.Languages });
        MonitoringService.Log.Debug("Returning response: {Response}", response);
        return response; 
    }
}