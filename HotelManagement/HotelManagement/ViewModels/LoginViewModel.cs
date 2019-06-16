namespace HotelManagement
{
    public class LoginViewModel : ViewModelBase
    {
        public UnauthenticatedUserCommand UnauthenticatedUserCommand { get; }
        public LoginCommand LoginCommand { get; }
        public ExitCommand ExitCommand { get; }
        public RegisterCommand RegisterCommand { get; }
        public UpdateUserCommand  UpdateUserCommand { get; }

        public LoginViewModel()
        {
            UnauthenticatedUserCommand = new UnauthenticatedUserCommand();
            LoginCommand = new LoginCommand();
            ExitCommand = new ExitCommand();
            RegisterCommand = new RegisterCommand();
            UpdateUserCommand = new UpdateUserCommand();
        }
    }
}
