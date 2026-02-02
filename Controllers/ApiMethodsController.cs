using AbhiWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AbhiWeb.Controllers;

[ApiController]

[Route("[controller]")]

public class ApiMethodsController : ControllerBase

{

    private static readonly string[] Summaries = new[]

    {

        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"

    };

    // Method implementations go here

    [HttpGet]
    public IEnumerable<ApiMethodsmodel> Get()
    {

        var rng = new Random();

        return Enumerable.Range(1, 5).Select(index => new ApiMethodsmodel

        {

            Date = DateTime.Now.AddDays(index),

            TemperatureC = rng.Next(-20, 55),

            Summary = Summaries[rng.Next(Summaries.Length)]

        }).ToArray();

    }

    [HttpPost]
    public IActionResult Post([FromBody] ApiMethodsmodel forecast)
    {
        // Add data to storage (e.g., database)
        return Ok(forecast);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ApiMethodsmodel forecast)
    {
        // Update data for the given ID
        // Example: Find and update an item with a matching ID
        var existingForecast = new ApiMethodsmodel();
        existingForecast.Date = forecast.Date;
        existingForecast.TemperatureC = forecast.TemperatureC;
        existingForecast.Summary = forecast.Summary;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // Delete data for the given ID
        return NoContent();
    }
}