using BE_clps.Repositories;

namespace BE_clps.Services
{
    public class ComplainantService
    {
        #region repository
        private readonly ComplainantRepository _repository;

        public ComplainantService(ComplainantRepository repository)
        {
            _repository = repository;
        }
        #endregion

       
    }
}
