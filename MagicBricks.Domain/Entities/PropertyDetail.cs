

using MagicBricksWebAPI.Models.Enums;

namespace MagicBricks.Domain.Entities
{
    public class PropertyDetail
    {
        public int Id { get; set; }

        public Furnishing Furnishing { get; set; }

        public OwnerShipType OwnerShipType { get; set; }

        public Facing Facing { get; set; }

        public string MaintenanceCharges { get; set; }

        public string Landmark { get; set; }

        public string WaterAvailiability { get; set; }

        public string StatusElectricity { get; set; }

        public int PropertyID { get; set; }
        public Property property { get; set; }


    }
}
