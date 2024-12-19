namespace Entities.Exceptions
{
    public sealed class ReviewNotFoundException : NotFoundException
    {
        public ReviewNotFoundException(int id) : base($"{id} id'li inceleme bulunamadı.")
        {
        }
    }
}

