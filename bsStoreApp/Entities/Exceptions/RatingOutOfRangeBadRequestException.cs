namespace Entities.Exceptions
{
    public abstract partial class BadRequestException
    {
        public class RatingOutOfRangeBadRequestException : BadRequestException
        {
            public RatingOutOfRangeBadRequestException() : base("Rating 1 ile 5 arasında olmalı.")
            {
            }
        }
    }
}
