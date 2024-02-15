using MagicBricks.Applications.Interfaces.IRepository;
using MagicBricks.Domain.Entities;
using MagicBricks.Domain.Enums;
using MagicBricks.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MagicBricks.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Property> AddProperty(Property property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            var addProperty = await _context.properties.AddAsync(property);

            await _context.SaveChangesAsync();

            return property;
        }

        public async Task<bool> DeleteProperty(int id)
        {
            if (id <= 0) throw new ArgumentException(nameof(id));
            var propertyDetail = await _context.properties.FirstOrDefaultAsync(a => a.Id == id);
            _context.properties.Remove(propertyDetail);
            await _context.SaveChangesAsync();

            return true;
        }



        public async Task<List<Property>> GetAllProperty()
        {
            var getAllProperty = await _context.properties.ToListAsync();
            if (getAllProperty == null) { return null; }
            else
                return getAllProperty;
        }

        public async Task<List<Property>> GetAllSelectedCategory(PropertyCategory propertycategory)
        {
            var GetSlectedCategories = await _context.properties.Where(a => a.propertyCategory == propertycategory).ToListAsync();

            if (GetSlectedCategories == null || !GetSlectedCategories.Any()) { return null; }

            return GetSlectedCategories;
        }




        public async Task<Property> GetPropertyByID(int id)
        {
            if (id <= 0) throw new ArgumentException(nameof(id));
            var propertyDetail = await _context.properties.FirstOrDefaultAsync(a => a.Id == id);

            return propertyDetail;

        }

        public async Task<Property> UpdateProperty(Property property)
        {

            var data = await _context.properties.FirstOrDefaultAsync(a => a.Id == property.Id);

            Property property1 = data as Property;
            {
                property1.PropertyName = property.PropertyName;
                property1.PropertyPrice = property.PropertyPrice;
                property1.PropertyLocation = property.PropertyLocation;
                property1.IsTreading = property.IsTreading;
                property1.IsVerified = property.IsVerified;
                property1.Images = property.Images;
                property1.PropertyArea = property.PropertyArea;
                property1.IsFavorite = property.IsFavorite;

            }

            var updatedProperty = _context.properties.Update(property1);
            _context.SaveChangesAsync();
            return property;
        }


    }
}
