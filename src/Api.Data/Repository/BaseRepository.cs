using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
  public class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
    protected readonly MyContext _context;

    private readonly DbSet<T> _dataSet;

    public BaseRepository(MyContext context)
    {
        _context = context;

        _dataSet = _context.Set<T>();

    }

    public async Task<bool> ExistAsync (Guid id)
    {
        return await _dataSet.AnyAsync(p => p.Id.Equals(id));
    }


    public async Task<bool> DeleteAsync(Guid id)
    {
      try
      {
          var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

          if (result == null)
          {
              return false;
          }
          else
          {
              _dataSet.Remove(result);

              await _context.SaveChangesAsync();
          }
      }
      catch (System.Exception ex)
      {

          throw ex;
      }

      return true;
    }

    public async Task<T> InsertAsync(T item)
    {
      try
      {
          if (item.Id == Guid.Empty)
          {
              item.Id = Guid.NewGuid();
          }

          item.CreatedAt = DateTime.UtcNow;

          _dataSet.Add(item);

          await _context.SaveChangesAsync();
      }
      catch (System.Exception ex)
      {
          throw ex;
      }

      return item;
    }

    public async Task<T> SelectAsync(Guid id)
    {
      try
      {
          return await _dataSet.FirstOrDefaultAsync(p => p.Id.Equals(id));
      }
      catch (System.Exception ex)
      {

          throw ex;
      }
    }

    public async Task<IEnumerable<T>> SelectAsync()
    {
      try
      {
          return await _dataSet.ToListAsync();
      }
      catch (System.Exception ex)
      {

          throw ex;
      }
    }

    public async Task<T> UpdateAsync(T item)
    {
      try
      {
          var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

          if (result == null)
          {
              return null;
          }
          else
          {
              item.UpdatedAt = DateTime.UtcNow;

              item.CreatedAt = result.CreatedAt;

              _context.Entry(result).CurrentValues.SetValues(item);

              await _context.SaveChangesAsync();
          }
      }
      catch (System.Exception ex)
      {

          throw ex;
      }

      return item;
    }
  }
}