namespace CargoOrders.Data.Exceptions;

/// <summary>
/// Исключение, выбрасываемое в случае, если объект не найден
/// </summary>
public sealed class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message) 
    {
        
    }
}