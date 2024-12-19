namespace Entities.RequestFeatures
{
    public class ReviewParameters : RequestParameters 
    {
        public int? Rating { get; set; }
        public bool ValidRatingRange => (Rating >= 1 && Rating <= 5);
        public bool HasRating => Rating != 0 && Rating != null;

        public String? SearchTerm { get; set; }
        public String? UserId { get; set; }
        public int? BookId { get; set; }

        public ReviewParameters()
        {
            OrderBy = "id"; //OrderBy query boş ise varsayılan olarak "id" göre sıralama yapılacak.
        }
    }
}
