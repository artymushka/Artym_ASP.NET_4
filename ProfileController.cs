

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Library
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    string filePath = $"user{id}.json";

                    if (System.IO.File.Exists(filePath))
                    {
                        string userData = System.IO.File.ReadAllText(filePath);
                        var userProfile = JsonSerializer.Deserialize<UserProfileModel>(userData);
                        return Ok(userProfile);
                    }
                    else
                    {
                        _logger.LogWarning($"File not found for user with ID {id}");
                        return NotFound();
                    }
                }
                else
                {
                    return Content("Welcome to library");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request");
                return StatusCode(500);
            }
        }
    }
}


