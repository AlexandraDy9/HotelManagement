namespace HotelManagement
{
    public class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public bool IsDeleted { get; set; }

        public User() { }
    }
}
