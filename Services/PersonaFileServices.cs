using Bibliote.Models;
using Bibliote.Interface;
using System.Text.Json;

namespace Bibliote.Services
{
    public class PersonaFileService : IPersonaService
    {
        
        private readonly IFileStorageService _fileStorageService;
        private readonly string _filePath = "Data/personas.json";

        public PersonaFileService(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public Persona Add(Persona persona)
        {
            var json = _fileStorageService.Read(_filePath);
            var personas = JsonSerializer.Deserialize<List<Persona>>(json) ?? new List<Persona>();
            persona.Id = personas.Any() ? personas.Max(p => p.Id) + 1 : 1;
            personas.Add(persona);
            json = JsonSerializer.Serialize(personas);
            _fileStorageService.Write(_filePath, json);
            return persona;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Persona> GetAll()
        {
            
            //Leo el contenido del archivo
            var json = _fileStorageService.Read(_filePath);
            //Deserializo el Json en una lista de Personas si es nulo retorna una lista vacia
            return JsonSerializer.Deserialize<List<Persona>>(json) ?? new List<Persona>();
        }

        public Persona GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Persona Update(Persona persona, int id)
        {
            throw new NotImplementedException();
        }
    }
}