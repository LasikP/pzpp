namespace nartyy.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="user",Password="admin",Roles="Admin"}
            };
    }
}
