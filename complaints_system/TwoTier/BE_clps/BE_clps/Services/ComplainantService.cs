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

        #region crud
        //IEnumerable<T>? GetAll();
        //T? GetByCode(string code);
        //bool Create(T entity);
        //bool UpdateByCode(string code, T entity);
        //bool DeleteByCode(string code);

        //public bool Create(ComplainantDTO cnantDTO)
        #endregion
    }
}
