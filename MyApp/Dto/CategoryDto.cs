namespace MyApp.Dto
{
    public class GetCategoryDto

    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetCategoryByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetGiftDto> Gifts { get; set; }

    }

    public class CreateCategoryDto
    {
        public string Name { get; set; }
    }

    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
