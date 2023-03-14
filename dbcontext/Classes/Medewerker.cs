namespace dbcontext.Classes
{
    public class Medewerker
    {
        public int Id { get; set; }
        public int TalentManager_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int Radius { get; set; }
        public string Uitstroomrichting { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
    }
    public class Medewerker_NoId
    {
        public int TalentManager_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int Radius { get; set; }
        public string Uitstroomrichting { get; set; }
        public string Photo { get; set; }
        public string ProfileText { get; set; }
    }
}