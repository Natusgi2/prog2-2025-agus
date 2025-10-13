namespace Bibliote.Interface
{
    public interface IPreguntaService
    {
         public  Task<List<Pregunta>> GetPreguntasAsync();

    }   
    
}