using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
 
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly DataAccess dataAccess;
 
    public CustomerController(DataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }
 
    [HttpGet("GetAllCustomers")]
    public IActionResult GetAllCustomers()
    {
        try
        {
            var customers = dataAccess.GetAllCustomers();
            return Ok(customers);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
 
    [HttpPost("CreateCustomer")]
    public IActionResult CreateCustomer([FromBody] Customer customer)
    {
        try
        {
            dataAccess.CreateCustomer(customer);
            return Ok("Customer created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
 
    [HttpPost("UpdateCustomer")]
    public IActionResult UpdateCustomer([FromBody] Customer customer)
    {
        try
        {
            dataAccess.UpdateCustomer(customer);
            return Ok("Customer updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
 
    [HttpDelete("DeleteCustomer/{userId}")]
    public IActionResult DeleteCustomer(Guid userId)
    {
        try
        {
            dataAccess.DeleteCustomer(userId);
            return Ok("Customer deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}
