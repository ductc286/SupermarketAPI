using System;
using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Core.Entities
{
    public class EndOfShift
    {
        [Key]
        public int EndOfShiftId { get; set; }

        public int StaffId { get; set; }

        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public byte TotalHours { get; set; }

        public bool IsApproved { get; set; }

        public long TotalMoney { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual Staff Staff { get; set; }
    }

    public enum WorkTime
    {
        two = 2, four = 4, six = 6, eight = 8
    }
}
