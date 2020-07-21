using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Comon;
using Supermarket.Core.Contants;
using Supermarket.Core.Utilities;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DataAccessLayer.IRepositories;
using Supperket.BLL.BaseBusiness;
using Supperket.BLL.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supperket.BLL.Business
{
    public class SaleBillBusiness : ServiceBase, ISaleBillBusiness
    {
        private readonly ISaleBillRepository _saleBillRepository;
        private readonly ISaleBillDetailRepository _saleBillDetailRepository;
        public SaleBillBusiness(ISaleBillRepository saleBillRepository, ISaleBillDetailRepository saleBillDetailRepository, MyDBContext db) : base(db)
        {
            _saleBillRepository = saleBillRepository;
            _saleBillDetailRepository = saleBillDetailRepository;
        }

        public bool Add(SaleBillViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var saleBill = entity.MapToSaleBill();
            saleBill.SaleBillId = IdUtilities.GenerateByTimeSpan();
            saleBill.CreatedDate = DateTime.Now;
            saleBill.StaffId = StaffGlobal.CurrentStaff.StaffId;
            _saleBillRepository.Add(saleBill);
            foreach (var item in entity.SaleBillDetailViewModels)
            {
                var saleBillDetail = item.MapToSaleBillDetail();
                saleBillDetail.SaleBillId = saleBill.SaleBillId;
                _saleBillDetailRepository.Add(saleBillDetail);
            }
                return true;
        }

        public bool Delete(SaleBill saleBill)
        {
            if (saleBill == null)
            {
                return false;
            }

            _saleBillRepository.Delete(saleBill);
            _saleBillDetailRepository.DeleteRange(saleBill.SaleBillDetails);
            
            return true;
        }

        public List<SaleBill> GetAll(string staffRole, int staffId)
        {
            if (string.IsNullOrEmpty(staffRole))
            {
                return null;
            }
            else if (staffRole == RoleConst.ADMIN)
            {
                return _db.SaleBills.AsQueryable().AsNoTracking().Include(s => s.SaleBillDetails).ThenInclude(sd => sd.Product).OrderByDescending(s => s.CreatedDate).ToList();
                //return _saleBillRepository.GetAll().OrderByDescending(s => s.CreatedDate).ToList();
            }
            else
            {
                return _db.SaleBills.AsQueryable().AsNoTracking().Where(s => s.StaffId == staffId).Include(s => s.SaleBillDetails).ThenInclude(sd => sd.Product).OrderByDescending(s => s.CreatedDate).ToList();
            }
        }

        public SaleBill GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(SaleBillViewModel entity)
        {

            var saleBill = entity.MapToSaleBill();
            var newSaleBillDetails = new List<SaleBillDetail>();
            foreach (var item in entity.SaleBillDetailViewModels)
            {
                var purchaseBillDetail = item.MapToSaleBillDetail();
                purchaseBillDetail.SaleBillId = saleBill.SaleBillId;
                newSaleBillDetails.Add(purchaseBillDetail);
            }
            _saleBillRepository.Update(saleBill);
            var oldSaleBillDetails = _saleBillDetailRepository.FindAll(pd => pd.SaleBillId == entity.SaleBillId);
            if (oldSaleBillDetails != null)
            {
                var deleteSaleBillDetails = oldSaleBillDetails.Where(op => !newSaleBillDetails.Any(p => p.Id == op.Id));
                var addSaleBillDetails = newSaleBillDetails.Where(p => !oldSaleBillDetails.Any(op => op.Id == p.Id));
                var updateSaleBillDetails = newSaleBillDetails.Where(p => oldSaleBillDetails.Any(op => op.Id == p.Id));
                _saleBillDetailRepository.DeleteRange(deleteSaleBillDetails);
                _saleBillDetailRepository.AddRange(addSaleBillDetails);
                _saleBillDetailRepository.UpdateRange(updateSaleBillDetails);

            }
            return true;
        }
    }
}
