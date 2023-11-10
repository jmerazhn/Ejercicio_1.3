using Ejercicio_1._3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ejercicio_1._3
{
    public class PersonRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;

        private async void Init()
        {
            if (conn is not null)
                return;

            conn = new(_dbPath);
            await conn.CreateTableAsync<Persona>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public Task<int> StoreDatos(Persona datos)
        {
            if (datos.Id == 0)
            {
                return conn.InsertAsync(datos);
            }
            else
            {
                return conn.UpdateAsync(datos);
            }
        }

        public async Task<List<Persona>> GetAllPersonas()
        {
            try
            {
                Init();
                //return await conn.Table<Persona>().ToListAsync();
                return await conn.Table<Persona>().ToListAsync();

            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Failed to retrieve data. {0})", ex.Message);
            }

            return new List<Persona>();
        }

        public Task<Persona> GetListaDatos(int pid)
        {
            return conn.Table<Persona>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }


        public Task<int> DeleteDatos(Persona datos)
        {
            return conn.DeleteAsync(datos);
        }
    }
}
