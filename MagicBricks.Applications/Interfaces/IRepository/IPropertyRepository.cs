using MagicBricks.Domain.Entities;
using MagicBricks.Domain.Enums;

namespace MagicBricks.Applications.Interfaces.IRepository
{
    public interface IPropertyRepository
    {
        Task<Property> GetPropertyByID(int id);

        Task<List<Property>> GetAllProperty();

        Task<Property> AddProperty(Property property);

        Task<Property> UpdateProperty(Property property);

        Task<bool> DeleteProperty(int id);

        Task<List<Property>> GetAllSelectedCategory(PropertyCategory propertyCategory);


    }
}
