namespace GymApi.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException() : 
        base("Chave estrangeira não encontrada")
    {}
}
