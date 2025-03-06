using ServicePratice.Data.Models;

namespace ServicePratice.Services
{
    using Interfaces;

    public class UserVerificationService : IVerificationService<User>
    {
        public async Task<bool> CompareEntities(User currentUser, User dbUser)
        {
            if (currentUser != null && currentUser.HashedPassword == dbUser.HashedPassword)
                return true;
            else
                return false;
        }
    }
}
