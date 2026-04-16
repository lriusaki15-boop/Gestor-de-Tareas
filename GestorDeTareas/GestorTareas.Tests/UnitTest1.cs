using GestorDeTareas.Tareas_Json;
namespace GestorTareas.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // ARRANGE
            //enum PrioridadTarea { Baja, Media, Alta }
            //enum EstadoTarea { Pendiente, EnProgreso, Completada, Cancelada }

            var t1 = new List<TareaDto> {new TareaDto(1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), DateTime.Today.AddDays(2),null, TareaDto.PrioridadTarea.Baja, TareaDto.EstadoTarea.Pendiente, null, null),
            new TareaDto(2, "Tarea 2", "Tarea nueva que a ver que pasa 2","Matata Reyes", DateTime.Today.AddDays(2), DateTime.Today.AddDays(3), null, TareaDto.PrioridadTarea.Media, TareaDto.EstadoTarea.EnProgreso, null, null),
            new TareaDto(3, "Tarea 3", "Tarea nueva que a ver que pasa 3","Extin Thor", DateTime.Today.AddDays(3), DateTime.Today.AddDays(4), null, TareaDto.PrioridadTarea.Baja, TareaDto.EstadoTarea.Completada, null, null) };
            

            // ACT
            
        }
    }
}
