using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.DAL.Context;
using HotCatCafe.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotCatCafe.BLL.Repositories.Concretes.BaseConcretes
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HotCatCafeContext _context;
        private DbSet<T> _entities;

        public BaseRepository(HotCatCafeContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<string> Create(T entity)
        {
            try
            {
                entity.Status = Model.Enums.DataStatus.INSERTED;
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return "Kayıt İşlemi Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string>? Delete(T entity)
        {
            try
            {
                entity.Status = Model.Enums.DataStatus.DELETED;
                await Update(entity);
                return "Silme İşlemi Başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> DestroyData(T entity)
        {
            _entities.Remove(entity);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return "Veri Kalıcı Olarak Silindi";
            }
            else
            {
                return "Veri Silinirken Bir Hata Meydana Geldi";
            }
        }

        public IEnumerable<T> GetActives()
        {
            return _entities.Where(x => x.IsActive == true).ToList();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetByID(int id)
        {
           
                var entity = _entities.Find(id);
                if (entity==null)
                {
                    throw new Exception($"ID :{id} ile veri bulunamadı.");
                }
                return entity;
          
          
        }

        public IEnumerable<T> GetPassives()
        {
            return _entities.Where(x => x.IsActive == false).ToList();
        }

        public async Task<string> Update(T entity)
        {
            string result = "";

            switch (entity.Status)
            {
                case Model.Enums.DataStatus.INSERTED:
                    entity.Status = Model.Enums.DataStatus.UPDATED;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    result = "Veri Güncellendi";
                    break;
                case Model.Enums.DataStatus.UPDATED:

                    entity.Status = Model.Enums.DataStatus.UPDATED;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    result = "Veri Güncellendi";
                    break;
                case Model.Enums.DataStatus.DELETED:
                    entity.Status = Model.Enums.DataStatus.DELETED;

                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    result = "Veri Güncellendi";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
