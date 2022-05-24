using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorfullStack.Shared
{
    public class SinhVienTT
    {
        public int Id { get; set; }
        public string Tinh { get;set; } = string.Empty;
        public string HoTen { get;set; } = string.Empty;
        public int NgaySinh { get; set; } 
        public int ThangSinh { get; set; }
        public int NamSinh { get; set; } 
        public string IDNumber { get; set; } = string.Empty;
        public string Truong { get; set; } = string.Empty;
        public string Lop { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public Status? Status { get; set; }
        public int StatusId { get; set; }

    }
}
