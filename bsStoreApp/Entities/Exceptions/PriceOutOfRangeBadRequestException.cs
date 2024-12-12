namespace Entities.Exceptions
{
    public abstract partial class BadRequestException
    {
        public class PriceOutOfRangeBadRequestException : BadRequestException
        {
            public PriceOutOfRangeBadRequestException() : base("Maksimum ücret 10 ile 1000 arasında olmalı.")
            {
            }
        }
    }
}
