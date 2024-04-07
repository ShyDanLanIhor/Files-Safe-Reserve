using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

/// <summary>
/// Interface for accessing virtual safe data.
/// </summary>
public interface IVirtualSafeRepository
{
    /// <summary>
    /// Retrieves a virtual safe by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the virtual safe.</param>
    /// <returns>The virtual safe model if found, otherwise null.</returns>
    public VirtualSafeModel GetById(Guid id);

    /// <summary>
    /// Retrieves a virtual safe by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the virtual safe.</param>
    /// <returns>The virtual safe model if found, otherwise null.</returns>
    public VirtualSafeModel GetById(string id);

    /// <summary>
    /// Retrieves all virtual safes.
    /// </summary>
    /// <returns>A list of all virtual safe models.</returns>
    public List<VirtualSafeModel> GetAll();

    /// <summary>
    /// Updates an existing virtual safe.
    /// </summary>
    /// <param name="model">The virtual safe model to update.</param>
    /// <returns>True if the update was successful, otherwise false.</returns>
    public bool Update(VirtualSafeModel model);

    /// <summary>
    /// Saves a new virtual safe.
    /// </summary>
    /// <param name="model">The virtual safe model to save.</param>
    /// <returns>True if the save was successful, otherwise false.</returns>
    public bool Save(VirtualSafeModel model);

    /// <summary>
    /// Deletes a virtual safe by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the virtual safe to delete.</param>
    /// <returns>True if the delete was successful, otherwise false.</returns>
    public bool DeleteById(Guid id);

    /// <summary>
    /// Deletes a virtual safe by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the virtual safe to delete.</param>
    /// <returns>True if the delete was successful, otherwise false.</returns>
    public bool DeleteById(string id);

    /// <summary>
    /// Deletes a virtual safe.
    /// </summary>
    /// <param name="model">The virtual safe model to delete.</param>
    /// <returns>True if the delete was successful, otherwise false.</returns>
    public bool Delete(VirtualSafeModel model);
}

