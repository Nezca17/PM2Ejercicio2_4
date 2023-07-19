using Ejercicio2_4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_4.Controllers
{
    public class FirmasDB
    {
        readonly SQLiteAsyncConnection db;

        public FirmasDB(string dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            db.CreateTableAsync<Firma>();
        }

        public Task<int> guardarFirma(Firma firma)
        {
            if (firma.id != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {
                return db.InsertAsync(firma);
            }
        }

        public Task<List<Firma>> obtenerFirmas()
        {
            return db.Table<Firma>().ToListAsync();
        }

        public Task<Firma> obtenerFirma(int fId)
        {
            return db.Table<Firma>()
                .Where(i => i.id == fId)
                .FirstOrDefaultAsync();
        }

        public Task<int> borrarFirma(Firma firma)
        {
            return db.DeleteAsync(firma);
        }
    }
}
