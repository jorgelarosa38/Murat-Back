namespace Project.Models
{
    public class User : Base
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string Names { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Estate { get; set; }
        public int TotalRecords { get; set; }
        public int AddUserId { get; set; }
        public int UpdUserId { get; set; }
        public string Password { get; set; }
    }
}
