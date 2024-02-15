using AutoMapper;
using MagicBricks.Applications.Interfaces.IRepository;
using MagicBricks.Domain.Entities;
using MagicBricks.Domain.Enums;
using MagicBricks.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
namespace MagicBricks_Clone.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {

        private readonly IPropertyRepository _propertyRepository;
        private readonly ILogger<AuthenticateController> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public PropertyController(IPropertyRepository propertyRepository, ILogger<AuthenticateController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _propertyRepository = propertyRepository;
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }


        [HttpGet("GetAllProperty")]
        public async Task<IActionResult> GetAllProperties()
        {
            _logger.LogInformation(" GetAllProperty");
            var getAllProerties = await _propertyRepository.GetAllProperty();
            return Ok(getAllProerties);

        }

        [HttpPost("AddProperty")]

        public async Task<IActionResult> AddProperty(Property propertyDTO)
        {
            _logger.LogInformation(" AddProperty");
            //  var mappingProperty = _mapper.Map<Property>(propertyDTO);
            if (propertyDTO == null) { throw new ArgumentNullException(nameof(propertyDTO)); }
            var addnewProperty = await _propertyRepository.AddProperty(propertyDTO);
            return Ok(addnewProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost("DeleteProperty")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            _logger.LogInformation(" DeleteProperty");
            if (id <= 0) { throw new ArgumentNullException(nameof(id)); }
            var addnewProperty = await _propertyRepository.DeleteProperty(id);
            return Ok(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost("UpdateProperty")]
        public async Task<IActionResult> UpdateProperty(Property property)
        {
            _logger.LogInformation(" UpdateProperty");
            if (property == null) { throw new ArgumentNullException(nameof(property)); }
            var addnewProperty = await _propertyRepository.UpdateProperty(property);
            return Ok(addnewProperty);
        }


        [HttpPost("GetSlectedCategory")]
        public async Task<IActionResult> GetCatageory([FromForm] PropertyCategory propertyCategory)
        {
            _logger.LogInformation(" UpdateProperty");
            if (propertyCategory == null) { throw new ArgumentNullException(nameof(propertyCategory)); }
            var addnewProperty = await _propertyRepository.GetAllSelectedCategory(propertyCategory);
            return Ok(addnewProperty);
        }

        [HttpPost("uploadImageinDb")]
        public async Task<IActionResult> UploadImageinDb(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("Image file is required.");

            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                // Save image bytes to the database
                var property = new Property
                {
                    ImageData = memoryStream.ToArray()
                };
                _context.properties.Add(property);
                await _context.SaveChangesAsync();
            }

            return Ok("Image uploaded successfully.");
        }
    }


}

