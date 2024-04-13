using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

/// <summary>
/// Represents a repository interface for managing virtual safes.
/// </summary>
public interface IVirtualSafeRepo
{
    /// <summary>
    /// Retrieves a virtual safe by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the virtual safe.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation, including the virtual safe if found.</returns>
    public Task<ValueResult<VirtualSafeModel>> GetById(Guid id);

    /// <summary>
    /// Retrieves a virtual safe by its string identifier.
    /// </summary>
    /// <param name="id">The string identifier of the virtual safe.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation, including the virtual safe if found.</returns>
    public Task<ValueResult<VirtualSafeModel>> GetById(string id);

    /// <summary>
    /// Retrieves all virtual safes.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all virtual safes.</returns>
    public Task<List<VirtualSafeModel>> GetAll();

    /// <summary>
    /// Updates a virtual safe.
    /// </summary>
    /// <param name="model">The virtual safe model to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Update(VirtualSafeModel model);

    /// <summary>
    /// Adds a new virtual safe.
    /// </summary>
    /// <param name="model">The virtual safe model to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Add(VirtualSafeModel model);

    /// <summary>
    /// Deletes a virtual safe by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the virtual safe to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    public Task<ResultEntity> DeleteById(Guid id);

    /// <summary>
    /// Deletes a virtual safe by its string identifier.
    /// </summary>
    /// <param name="id">The string identifier of the virtual safe to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    public Task<ResultEntity> DeleteById(string id);

    /// <summary>
    /// Deletes a virtual safe.
    /// </summary>
    /// <param name="model">The virtual safe model to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    public Task<ResultEntity> Delete(VirtualSafeModel model);
}


