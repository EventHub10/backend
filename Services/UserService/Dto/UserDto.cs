namespace backend.Services.UserServices.Dto
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
    }
}
