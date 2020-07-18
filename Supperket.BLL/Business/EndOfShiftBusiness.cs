using Supermarket.Core.Comon;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DataAccessLayer.IRepositories;
using SupermarketAPI.DataAccessLayer.Repositories;
using Supperket.BLL.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supperket.BLL.Business
{
    public class EndOfShiftBusiness : IEndOfShiftBusiness
    {
        private readonly IEndOfShiftRepository _endOfShiftRepository;
        private readonly ISaleBillRepository _saleBillRepository;


        public EndOfShiftBusiness(IEndOfShiftRepository endOfShiftRepository, ISaleBillRepository saleBillRepository)
        {
            _endOfShiftRepository = endOfShiftRepository;
            _saleBillRepository = saleBillRepository;
        }
        public bool Add(EndOfShiftViewModel entity)
        {
            var endOfShift = entity.MapToEndOfShift();
            endOfShift.CreatedDate = DateTime.Now;
            //err
            //endOfShift.StaffId = StaffGlobal.CurrentStaff.StaffId;
            DateTime fromDatetime = new DateTime(endOfShift.CreatedDate.Year, endOfShift.CreatedDate.Month, endOfShift.CreatedDate.Day, entity.From, 0, 0);
            DateTime toDatetime = new DateTime(endOfShift.CreatedDate.Year, endOfShift.CreatedDate.Month, endOfShift.CreatedDate.Day, entity.To, 0, 0);
            //hanlder money
            long totalMoney = 0;
            try
            {
                totalMoney = _saleBillRepository.GetAll().Where(s => !s.IsAprroved && s.StaffId == endOfShift.StaffId
                    && s.CreatedDate >= fromDatetime && s.CreatedDate <= toDatetime)
                    .Sum(s => s.TotalMoney);
            }
            catch (Exception)
            {
            }
            endOfShift.TotalMoney = totalMoney;
            return _endOfShiftRepository.Add(endOfShift);
        }

        public void Approve(EndOfShift oldEntity)
        {
            var entity = _endOfShiftRepository.GetById(oldEntity.EndOfShiftId);
            if (entity == null)
            {
                return;
            }
            entity.IsApproved = true;
            _endOfShiftRepository.Update(entity);
            DateTime fromDatetime = new DateTime(entity.CreatedDate.Year, entity.CreatedDate.Month, entity.CreatedDate.Day, entity.From, 0, 0);
            DateTime toDatetime = new DateTime(entity.CreatedDate.Year, entity.CreatedDate.Month, entity.CreatedDate.Day, entity.To, 0, 0);

            var listSaleBill = _saleBillRepository.GetAll().Where(s => !s.IsAprroved
                && s.CreatedDate >= fromDatetime && s.CreatedDate <= toDatetime).ToList();
            //foreach (var item in listSaleBill)
            //{
            //    item.IsAprroved = true;
            //    _saleBillRepository.Update(item);
            //}
            
            for (int i = 0; i < listSaleBill.Count(); i++)
            {
                listSaleBill[i].IsAprroved = true;
                _saleBillRepository.Update(listSaleBill[i]);
            }
        }

        public bool Delete(EndOfShift entity)
        {
            return _endOfShiftRepository.Delete(entity);

        }

        public List<EndOfShift> GetAll()
        {
            if (StaffGlobal.CurrentStaff.StaffRole == (int)EStaffRole.Administrator)
            {
                return _endOfShiftRepository.GetAll().OrderByDescending(e => e.CreatedDate).ToList();
            }
            var staffId = StaffGlobal.CurrentStaff.StaffId;
            return _endOfShiftRepository.FindAll(e => e.StaffId == staffId).OrderByDescending(e => e.CreatedDate).ToList();
        }

        public bool Update(EndOfShiftViewModel entity)
        {
            var endOfShift = entity.MapToEndOfShift();
            endOfShift.CreatedDate = DateTime.Now;
            endOfShift.EndOfShiftId = StaffGlobal.CurrentStaff.StaffId;
            DateTime fromDatetime = new DateTime(endOfShift.CreatedDate.Year, endOfShift.CreatedDate.Month, endOfShift.CreatedDate.Day, entity.From, 0, 0);
            DateTime toDatetime = new DateTime(endOfShift.CreatedDate.Year, endOfShift.CreatedDate.Month, endOfShift.CreatedDate.Day, entity.To, 0, 0);
            //hanlder money
            var totalMoney = _saleBillRepository.GetAll().Where(s => !s.IsAprroved
                && s.CreatedDate >= fromDatetime && s.CreatedDate <= toDatetime)
                .Sum(s => s.TotalMoney);
            endOfShift.TotalMoney = totalMoney;
            return _endOfShiftRepository.Update(endOfShift);
        }
    }
}
