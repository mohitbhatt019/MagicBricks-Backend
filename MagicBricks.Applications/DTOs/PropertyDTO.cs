using MagicBricks.Domain.Enums;

namespace MagicBricks.Applications.DTOs
{
    public class PropertyDTO
    {

        public int Id { get; set; }

        public string PropertyName { get; set; }

        public string PropertyPrice { get; set; }

        public string PropertyLocation { get; set; }

        public bool IsTreading { get; set; }

        public bool IsVerified { get; set; }

        public string Images { get; set; }

        public string PropertyPictures { get; set; }

        public DateTime PropertyAdvertisementDate { get; set; }

        public string PropertyArea { get; set; }

        public string PropertyDescription { get; set; }

        public PropertyCategory propertyCategory { get; set; }
        public bool IsFavorite { get; set; }

        public string ApplicationUserId { get; set; }


    }
}
