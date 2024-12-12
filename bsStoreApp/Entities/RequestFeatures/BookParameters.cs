namespace Entities.RequestFeatures
{
    public class BookParameters : RequestParameters 
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = 1000; //Bir kitabın max fiyatını 1000 olarak API kurgularken belirlemiştik.
        public bool ValidPriceRange => MaxPrice > MinPrice;

        public String? SearchTerm { get; set; }

        public BookParameters()
        {
            OrderBy = "id"; //OrderBy query boş ise varsayılan olarak "id" göre sıralama yapılacak.
        }
    }
}
