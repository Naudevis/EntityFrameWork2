using EntityFrameWork2.BaseDeDatos;
using EntityFrameWork2.Modelo;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Trabajando con EntityFrameWork");

Start:
try
{
    int option = 1;
    while (option !=0)
    {
        Console.WriteLine("Seleccione una opción del menú");
        Console.WriteLine("[1]: Registrar una unidad de medicion nueva");
        Console.WriteLine("[2]: Buscar una unidad de medición");
        Console.WriteLine("[3]: Para eliminar una unidad de medición");
        Console.WriteLine("[4]: Mostrar todas las unidades de medición");
        Console.WriteLine("[0]: Salir");
        option= Convert.ToInt32(Console.ReadLine()); //acá capturamos la opción del usuario
        switch (option)
        {
            case 1: //En caso de registrar
                Console.WriteLine("Ingresa el identificador de la unidad de medición");
                int id= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingresa el nombre de la unidad de medición a crear");
                string name= Console.ReadLine();

                using (var context = new AppDbContext())
                {
                    CreateMeasurementUnit(context, id, name); //Método
                }

                    Console.ReadKey();
                break;
            case 2: //En caso de buscar
                using (var context = new AppDbContext())
                {
                    Console.WriteLine("Ingresa el ID: ");
                    int MeasurementUnitIDSearch = Convert.ToInt32(Console.ReadLine());
                    SearchMeasurementUnit(context, MeasurementUnitIDSearch);
                }
                   

                
                break;
            case 3: //En caso de eliminar
                using (var context = new AppDbContext())
                {
                    Console.WriteLine("Ingresa el ID que deseas eliminar: ");
                    int MeasurementUnitIdDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteMeasurementUnit(context, MeasurementUnitIdDelete);
                }

                break;
            case 4: //En caso de querer mostrar todos los paises de la base de datos
                
                using (var context = new AppDbContext())
                {
                    ListMeasurementUnit(context);
                }

                break;
            case 0://En caso de querer salir del sistema
                Console.WriteLine("Saliendo del sistema....");
                Thread.Sleep(10000);
                break;
            default:
               Console.WriteLine("Opción no contemplada dentro del menú");
                break;
        }
    }
}
catch(Exception ex)
{
    Console.Clear();
    Console.WriteLine(ex.Message);
    Thread.Sleep(15000);
    Console.Clear();
    goto Start;
}

void DeleteMeasurementUnit(AppDbContext context, int measurementUnitIdDelete)
{
    Measurement_Unit MeasurementUnitDelete = context.Measurement_Unit.Find(measurementUnitIdDelete);
    if (MeasurementUnitDelete != null)
    {
        context.Remove(MeasurementUnitDelete);
        context.SaveChanges();  
        Console.WriteLine($"Se ha eliminado la unidad de medición con el id: {measurementUnitIdDelete}");    
    }
    else
    {
        Console.WriteLine($"No se encontró la unidad de medición con el id {measurementUnitIdDelete}");
    }
}

void ListMeasurementUnit(AppDbContext context)
{
    List<Measurement_Unit> measurement_UnitsList = context.Measurement_Unit.ToList();
    foreach (var MeasurementUnitElement in measurement_UnitsList)
    {
        Console.WriteLine(MeasurementUnitElement.GetAllMeasurementUnitInformation());
    }
    Console.ReadKey();
}

void SearchMeasurementUnit(AppDbContext context, int measurementUnitIDSearch)
{
    Measurement_Unit MeasurementUnitFounded = context.Measurement_Unit.Find(measurementUnitIDSearch);
    if (MeasurementUnitFounded !=null)
    {
        Console.WriteLine(MeasurementUnitFounded.GetAllMeasurementUnitInformation());
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"No se encontró la unidad de medición con el id{measurementUnitIDSearch}");
    }
}

void CreateMeasurementUnit(AppDbContext context, int id, string? name)
{
    
    //Creamos un objeto (instancia) y le enviamos los valores para posteriormente guardarlos en la tabla
    var measurementUnit = new Measurement_Unit { Measurement_ID = id, Measurement = name };
    context.Add(measurementUnit); //Le enviamos la clase al contexto
    context.SaveChanges();//y le decimos que aplique los cambios (que se escriban en la base de datos)
    Console.Clear() ;
    Console.WriteLine("Se aplicaron los cambios!");
    Thread.Sleep(10000);

}