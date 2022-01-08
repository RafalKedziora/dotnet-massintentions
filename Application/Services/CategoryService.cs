namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public CategoryDto AddNewCategory(CreateCategoryDto newCategory)
        {
            if(string.IsNullOrEmpty(newCategory.Name))
            {
                throw new Exception("Category can not have an empty name.");
            }
            var category = _mapper.Map<Category>(newCategory);
            _categoryRepository.Add(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public void UpdateCategory(int id, UpdateCategoryDto updateCategory)
        {
            if(string.IsNullOrEmpty(updateCategory.Name))
            {
                throw new Exception("Category can not have an empty name.");
            }
            var existingCategory = _categoryRepository.GetById(id);
            var post = _mapper.Map(updateCategory, existingCategory);
            _categoryRepository.Update(post);
        }

        public void DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Delete(category);
        }
    }
}
