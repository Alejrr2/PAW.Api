using Microsoft.EntityFrameworkCore;
using PAW.Architecture.Exceptions;
using PAW.Models;



namespace PAW.Data.Repository;

/// <summary>
/// Interface for basic repository operations.
/// </summary>
/// <typeparam name="P">The type of entity.</typeparam>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new entity asynchronously.
    /// </summary>
    /// <param name="Product">The entity to be created.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> CreateAsync(Product product);

    /// <summary>
    /// Deletes an existing entity asynchronously.
    /// </summary>
    /// <param name="product">The entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(Product product);

    /// <summary>
    /// Reads all entities of type T asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
    Task<IEnumerable<Product>> ReadProductsAsync();

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="product">The entity to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateAsync(Product product);

    /// <summary>
    /// Updates multiple entities asynchronously.
    /// </summary>
    /// <param name="products">The collection of entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<Product> products);

    /// <summary>
    /// Checks if an entity exists asynchronously.
    /// </summary>
    /// <param name="product">The entity to check for existence.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating if the entity exists.</returns>
    Task<bool> ExistsAsync(Product product);
    
    //Jala los datos desde la base de datos

}

/// <summary>
/// Base class for repository operations.
/// </summary>
/// <typeparam name="P">Entity type.</typeparam>
public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    private readonly ProductDbContext _context;
    protected ProductDbContext DbContext => _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryBase{P}"/> class.
    /// </summary>
    public ProductRepository()
    {
        _context = new ProductDbContext();
    }

    /// <summary>
    /// Creates an entity of type T asynchronously.
    /// </summary>
    /// <param name="product">The entity to be saved in the database.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> CreateAsync(Product product)
    {
        try
        {
            await _context.AddAsync(product);
            return await SaveAsync();
        }
        catch (Exception ex)
        {
            throw new PAWException(ex);
        }
    }

    /// <summary>
    /// Updates an existing entity of type T asynchronously.
    /// </summary>
    /// <param name="product">The entity to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> UpdateAsync(Product product)
    {
        try
        {
            _context.Update(product);
            return await SaveAsync();
        }
        catch (Exception ex)
        {
            throw new PAWException(ex);
        }
    }

    /// <summary>
    /// Updates multiple entities of type T asynchronously.
    /// </summary>
    /// <param name="products">The collection of entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> UpdateManyAsync(IEnumerable<Product> products)
    {
        try
        {
            _context.UpdateRange(products);
            return await SaveAsync();
        }
        catch (Exception ex)
        {
            throw new PAWException(ex);
        }
    }

    /// <summary>
    /// Deletes an entity of type T asynchronously.
    /// </summary>
    /// <param name="product">The entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> DeleteAsync(Product product)
    {
        try
        {
            _context.Remove(product);
            return await SaveAsync();
        }
        catch (Exception ex)
        {
            throw new PAWException(ex);
        }
    }

    /// <summary>
    /// Reads all entities of type T asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
    public async Task<IEnumerable<Product>> ReadProductsAsync()
    {
        try
        {
            return await ReadAsync();
        }
        catch (Exception ex)
        {
            throw new PAWException(ex);
        }
    }

    /// <summary>
    /// Checks if an entity of type T exists asynchronously.
    /// </summary>
    /// <param name="product">The entity to check for existence.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating if the entity exists.</returns>
    public async Task<bool> ExistsAsync(Product product)
    {
        try
        {
            var items = await ReadAsync();
            return items.Any(x => x.Equals(product));
        }
        catch (Exception ex)
        {
            throw new PAWException(ex);
        }
    }

    /// <summary>
    /// Saves changes to the database asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    protected async Task<bool> SaveAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}



