namespace GymApi.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(): base(message: "O id não foi encontrado") { }
    }
}
