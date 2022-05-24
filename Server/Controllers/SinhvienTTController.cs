using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorfullStack.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhvienTTController : ControllerBase
    {
        public static List<Status> statuss = new List<Status>
        {
            new Status { Id =0 ,Name ="Da gui"},
            new Status { Id =1 ,Name ="Chua gui"}
        };
        public static List<SinhVienTT> sinhVienTTs = new List<SinhVienTT>
        {
            new SinhVienTT{
                Id =1 ,
                Tinh ="Soc trang",
                HoTen = "nguyen giang thai khang",
                NgaySinh = 12,
                ThangSinh=1,
                NamSinh=2001,
                IDNumber="",
                Truong="THPT Tay Thanh",
                Lop="12c1",
                SoDienThoai="021554642",
                Status = statuss[0]

            },
             new SinhVienTT{
                Id =2 ,
                Tinh ="Soc trang",
                HoTen = "nguyen giang thai khang2",
                NgaySinh = 20,
                ThangSinh=4,
                NamSinh=2002,
                IDNumber="",
                Truong="THPT Ha Dong",
                Lop="12c1",
                SoDienThoai="0210000042",
                Status = statuss[1]

            },
        };
        [HttpGet]
        public async Task<ActionResult<List<SinhVienTT>>> GetSinhVienTTes()
        {
            return Ok(sinhVienTTs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVienTT>> GetSingleSinhVienTT(int id)
        {
            var sinhvien = sinhVienTTs.FirstOrDefault(h => h.Id == id);
            if(sinhvien == null)
            {
                return NotFound("Sinh Vien khon ton tai tren he thong. :/");

            }
            return Ok(sinhvien);

        }
    }
}
