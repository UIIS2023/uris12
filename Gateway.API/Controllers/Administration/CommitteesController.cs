﻿using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Administration;

/// <summary>
/// Represents the API endpoint for managing committees and their members.
/// </summary>
[ApiExplorerSettings(GroupName = "Administration")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class CommitteesController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Represents a controller for managing committees.
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public CommitteesController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_ADMINISTRATION")}/api/Committees");
    }

    /// <summary>
    /// Returns a list of all committees.
    /// </summary>
    /// <returns>A list of committees</returns>
    /// <response code="200">The committees were successfully retrieved.</response>
    [HttpGet]
    public Task<IActionResult> GetCommittees()
        => serviceProxy.Get();

    /// <summary>
    /// Returns the details of a specific committee.
    /// </summary>
    /// <param name="id">The ID of the committee</param>
    /// <returns>The details of the committee</returns>
    /// <response code="200">The committee was successfully retrieved.</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetCommittee(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates the specified committee with the given changes.
    /// </summary>
    /// <param name="id">The ID of the committee to update</param>
    /// <param name="requestModel">The changes to apply to the committee</param>
    /// <returns>The updated committee</returns>
    /// <response code="204">The committee was successfully updated.</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PatchCommittee(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Updates the specified member of a committee with the given changes.
    /// </summary>
    /// <param name="id">The ID of the committee to update the member for</param>
    /// <param name="memberId">The ID of the member to update</param>
    /// <param name="patchModel">The changes to apply to the member</param>
    /// <returns>The updated member</returns>
    /// <response code="204">The member was successfully updated.</response>
    [HttpPatch("{id}/members/{memberId}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PatchCommitteeMember(Guid id, Guid memberId, object patchModel)
        => serviceProxy.Patch($"{id}/members/{memberId}", patchModel);

    /// <summary>
    /// Creates a new committee.
    /// </summary>
    /// <param name="postModel">The model for creating a committee.</param>
    /// <returns>The created committee.</returns>
    /// <response code="201">The committee was created successfully.</response>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PostCommittee(object postModel)
        => serviceProxy.Post(postModel);

    /// <summary>
    /// Creates a new committee member for a committee.
    /// </summary>
    /// <param name="id">The ID of the committee to which the member belongs.</param>
    /// <param name="postModel">The model for creating a committee member.</param>
    /// <returns>The created committee member.</returns>
    /// <response code="201">The committee member was created successfully.</response>
    [HttpPost("{id}/members")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> PostCommitteeMember(Guid id, object postModel)
        => await serviceProxy.Post(postModel, $"{id}/members");

    /// <summary>
    /// Deletes a committee by ID.
    /// </summary>
    /// <param name="id">The ID of the committee to delete.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    /// <response code="204">The committee was deleted successfully.</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> DeleteCommittee(string id)
        => serviceProxy.Delete(id);

    /// <summary>
    /// Deletes a committee member by ID.
    /// </summary>
    /// <param name="id">The ID of the committee to which the member belongs.</param>
    /// <param name="memberId">The ID of the member to delete.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    /// <response code="204">The committee member was deleted successfully.</response>
    /// <response code="404">The committee member was not found.</response>
    [HttpDelete("{id}/members/{memberId}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> DeleteCommitteeMember(Guid id, Guid memberId)
        => serviceProxy.Delete($"{id}/members/{memberId}");
}
