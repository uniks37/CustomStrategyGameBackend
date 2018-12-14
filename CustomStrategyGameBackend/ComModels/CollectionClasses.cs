namespace CustomStrategyGameBackend.ComModels
{
    public class MessageWrapper<T>
    {
        public string MessageType { get { return typeof(T).FullName; } }
        public T Message { get; set; }
    }

    public class MessageWrapper
    {
        public string MessageType { get; set; }
        public object Message { get; set; }
    }

    public class LoginGamerInfo
    {
        private string uname, password;
        private bool remMe;

        public string Uname { get => uname; set => uname = value; }
        public string Password { get => password; set => password = value; }
        public bool RemMe { get => remMe; set => remMe = value; }

        public LoginGamerInfo(string uname, string password, bool remMe)
        {
            Uname = uname;
            Password = password;
            RemMe = remMe;
        }
    }

    public class RegisterGamerInfo
    {
        private string uname, password, emailId;

        public string Uname { get => uname; set => uname = value; }
        public string Password { get => password; set => password = value; }
        public string EmailId { get => emailId; set => emailId = value; }

        public RegisterGamerInfo(string uname, string password, string emailId)
        {
            Uname = uname;
            Password = password;
            EmailId = emailId;
        }
    }

    public class TokenInfo
    {
        private string tokenId;

        public TokenInfo(string tokenID)
        {
            TokenId = tokenID;
        }

        public string TokenId { get => tokenId; set => tokenId = value; }
    }

    public class TokenUname
    {
        private string uname, token_Id;

        public TokenUname(string uname, string token_Id)
        {
            Uname = uname;
            Token_Id = token_Id;
        }

        public string Uname { get => uname; set => uname = value; }
        public string Token_Id { get => token_Id; set => token_Id = value; }
    }

    public class RegistrationStatus
    {
        private int errorCode;
        private string errorMsg;

        public RegistrationStatus(int errorCode, string errorMsg)
        {
            ErrorCode = errorCode;
            ErrorMsg = errorMsg;
        }

        public int ErrorCode { get => errorCode; set => errorCode = value; }
        public string ErrorMsg { get => errorMsg; set => errorMsg = value; }
    }
}