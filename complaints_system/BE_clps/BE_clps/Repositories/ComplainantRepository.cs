using BE_clps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_clps.Repositories
{
    public class ComplainantRepository : ICrudRepository<Complainant>
    {
        #region context, logger
        private readonly ILogger _logger;
        private readonly Context _context;

        public ComplainantRepository(Context context, ILogger<ComplainantRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        #endregion
        
        //#region singleton
        //private static ComplainantRepository? _instance;
        //public static ComplainantRepository GetInstance()
        //{
        //    if (_instance == null)
        //        _instance = new ComplainantRepository();
        //    return _instance;
        //}

        //private ComplainantRepository() { }
        //#endregion
        public bool Create(Complainant entity)
        {
            try
            {
                _context.Complainants.Add(entity);
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
                Complainant? temp = GetByCode(code);
                if (temp != null)
                {
                    _context.Complainants.Remove(temp);
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

        public IEnumerable<Complainant>? GetAll()
        {
            try
            {
                return _context.Complainants.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new List<Complainant>();
        }

        public Complainant? GetByCode(string code)
        {
            try
            {
                return _context.Complainants.FirstOrDefault(cnant => cnant.DocumentCnant == code);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public bool UpdateByCode(string code, Complainant entity)
        {
            try
            {
                Complainant? temp = GetByCode(code);
                if (temp != null)
                {
                    _context.Complainants.Update(entity);
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
