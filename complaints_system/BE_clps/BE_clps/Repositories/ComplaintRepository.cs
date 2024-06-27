using BE_clps.Models;

namespace BE_clps.Repositories
{
    public class ComplaintRepository : ICrudRepository<Complaint>
    {
        #region context, logger
        private readonly ILogger _logger;
        private readonly Context _context;

        public ComplaintRepository(Context context, ILogger<ComplaintRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        #endregion

        public bool Create(Complaint entity)
        {
            try
            {
                _context.Complaints.Add(entity);
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
                Complaint? temp = GetByCode(code);
                if (temp != null)
                {
                    _context.Complaints.Remove(temp);
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

        public IEnumerable<Complaint>? GetAll()
        {
            try
            {
                return _context.Complaints.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new List<Complaint>();
        }

        public Complaint? GetByCode(string code)
        {
            try
            {
                return _context.Complaints.FirstOrDefault(c => c.ComplaintNumber == code);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public bool UpdateByCode(string code, Complaint entity)
        {
            try
            {
                Complaint? temp = GetByCode(code);
                if (temp != null)
                {
                    _context.Complaints.Update(entity);
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
