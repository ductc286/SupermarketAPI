using Supermarket.Core.Comon;
using Supermarket.Core.Utilities;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.GenericRepository;
using SupermarketAPI.DataAccessLayer.IRepositories;
using SupermarketAPI.DataAccessLayer.Repositories;
using Supperket.BLL.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supperket.BLL.Business
{
    public class PurchaseBillBusiness : IPurchaseBillBusiness
    {
        private readonly IPurchaseBillRepository _purchaseBillRepository;
        private readonly IPurchaseBillDetailRepository _purchaseBillDetailRepository;
        public PurchaseBillBusiness(IPurchaseBillRepository purchaseBillRepository, IPurchaseBillDetailRepository purchaseBillDetailRepository)
        {
            _purchaseBillRepository = purchaseBillRepository;
            _purchaseBillDetailRepository = purchaseBillDetailRepository;
        }
        public bool Add(PurchaseBillViewModel entity)
        {
            var purchaseBill = entity.MapToPuchaseBill();
            purchaseBill.PurchaseBillId = IdUtilities.GenerateByTimeSpan();
            purchaseBill.CreatedDate = DateTime.Now;
            purchaseBill.StaffId = StaffGlobal.StaffId;
            _purchaseBillRepository.Add(purchaseBill);

            //purchaseBill.PurchaseBillDetails = new List<PurchaseBillDetail>();
            //var purchaseBillDetails = new List<PurchaseBillDetail>();
            foreach (var item in entity.PurchaseBillDetailViewModels)
            {
                var purchaseBillDetail = item.MapToPurchaseBillDetail();
                purchaseBillDetail.PurchaseBillId = purchaseBill.PurchaseBillId;
                _purchaseBillDetailRepository.Add(purchaseBillDetail);
            }
            
            return true;
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseBill> GetAll()
        {
            return _purchaseBillRepository.GetAll().OrderByDescending(p => p.CreatedDate).ToList();
        }

        public PurchaseBill GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(PurchaseBillViewModel entity)
        {
            var purchaseBill = entity.MapToPuchaseBill();
            var newPurchaseBillDetails = new List<PurchaseBillDetail>();
            foreach (var item in entity.PurchaseBillDetailViewModels)
            {
                var purchaseBillDetail = item.MapToPurchaseBillDetail();
                purchaseBillDetail.PurchaseBillId = purchaseBill.PurchaseBillId;
                newPurchaseBillDetails.Add(purchaseBillDetail);
            }
            _purchaseBillRepository.Update(purchaseBill);
            var oldPurchaseBillDetails = _purchaseBillDetailRepository.FindAll(pd => pd.PurchaseBillId == entity.PurchaseBillId).ToList();
            if (oldPurchaseBillDetails != null)
            {
                var deletePurchaseBillDetails = oldPurchaseBillDetails.Where(op => !newPurchaseBillDetails.Any(p => p.Id == op.Id));
                var addPurchaseBillDetails = newPurchaseBillDetails.Where(p => !oldPurchaseBillDetails.Any(op => op.Id == p.Id));
                var updatePurchaseBillDetails = newPurchaseBillDetails.Where(p => oldPurchaseBillDetails.Any(op => op.Id == p.Id));
                _purchaseBillDetailRepository.DeleteRange(deletePurchaseBillDetails);
                _purchaseBillDetailRepository.AddRange(addPurchaseBillDetails);
                _purchaseBillDetailRepository.UpdateRange(updatePurchaseBillDetails);

            }
            return true;
        }
    }
}
