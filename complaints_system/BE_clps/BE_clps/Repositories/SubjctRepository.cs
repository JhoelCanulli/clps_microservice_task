using BE_clps.Models;

namespace BE_clps.Repositories
{
    public class SubjctRepository : ICrudRepository<Subjct>
    {
        #region context, logger
        private readonly ILogger _logger;
        private readonly Context _context;

        public SubjctRepository(Context context, ILogger<SubjctRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        #endregion

        public bool Create(Subjct entity)
        {
            try
            {
                _context.Subjcts.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public bool DeleteByCode(string code)
        {
            try
            {
                Subjct? temp = GetByCode(code);
                if (temp != null)
                {
                    _context.Subjcts.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public IEnumerable<Subjct>? GetAll()
        {
            try
            {
                return _context.Subjcts.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new List<Subjct>();
        }

        public Subjct? GetByCode(string code)
        {
            try
            {
                return _context.Subjcts.FirstOrDefault(s => s.DocumentSub == code);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public bool UpdateByCode(string code, Subjct entity)
        {
            try
            {
                Subjct? temp = GetByCode(code);
                if (temp != null)
                {
                    _context.Subjcts.Update(entity);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
