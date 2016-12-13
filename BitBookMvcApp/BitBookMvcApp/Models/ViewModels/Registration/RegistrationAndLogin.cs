namespace BitBookMvcApp.Models.ViewModels.Registration
{
    public class RegistrationAndLogin
    {
        public int Id { get; set; }
        public Models.ViewModels.Registration.Registration Registration { get; set; }
        public Login Login { get; set; }
    }
}