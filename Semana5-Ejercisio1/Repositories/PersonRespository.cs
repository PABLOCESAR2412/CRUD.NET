using System;
using System.Collections.Generic;
using System.Text;

namespace Semana5_Ejercisio1.Repositories
{
    public class PersonRespository
    {
        // Ruta de la base de datos
        string _dbPath;
        // Conexión a la base de datos SQLite
        private SQLite.SQLiteConnection _conn;
        // Mensaje de estado para informar sobre las operaciones realizadas
        public string StatusMessage { get; set; }
        // Constructor que recibe la ruta de la base de datos
        public PersonRespository(string path)
        {
            _dbPath = path;
        }

        // Inicializa la conexión a la base de datos y crea la tabla si no existe
        private void Init()
        {
            if (_conn != null)
                return;
            _conn = new SQLite.SQLiteConnection(_dbPath);
            _conn.CreateTable<Models.Persona>();
        }

        // GET
        // Agrega una nueva persona a la base de datos
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                result = _conn.Insert(new Models.Persona { Name = name });
                StatusMessage = string.Format("{0} record(s) añadidos [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Fallo al agregar {0}. Error: {1}", name, ex.Message);
            }
        }

        // 
        // Obtiene la lista de todas las personas en la base de datos
        public List<Models.Persona> GetAllPersonsList()
        {
            try
            {
                Init();
                return _conn.Table<Models.Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Fallo al leer personas. Error: {0}", ex.Message);
            }
            return new List<Models.Persona>();
        }

        //Delete 
        // Elimina una persona de la base de datos por su ID
        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var personToDelete = _conn.Find<Models.Persona>(id);
                if (personToDelete != null)
                {
                    _conn.Delete(personToDelete);
                    StatusMessage = string.Format("Persona con ID {0} eliminada correctamente.", id);
                }
                else
                {
                    StatusMessage = string.Format("No se encontró persona con ID {0}.", id);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Fallo al eliminar persona con ID {0}. Error: {1}", id, ex.Message);
            }
        }


        //Update
        // Actualiza el nombre de una persona en la base de datos por su ID
        public void UpdatePerson(int id, string newName)
        {
            try
            {
                Init();
                var personToUpdate = _conn.Find<Models.Persona>(id);
                if (personToUpdate != null)
                {
                    personToUpdate.Name = newName;
                    _conn.Update(personToUpdate);
                    StatusMessage = string.Format("Persona con ID {0} actualizada correctamente.", id);
                }
                else
                {
                    StatusMessage = string.Format("No se encontró persona con ID {0}.", id);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Fallo al actualizar persona con ID {0}. Error: {1}", id, ex.Message);
            }
        }


    }
}
