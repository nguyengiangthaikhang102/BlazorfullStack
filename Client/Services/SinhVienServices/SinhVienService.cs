using System.Net.Http.Json;

namespace BlazorfullStack.Client.Services.SinhVienServices
{
    public class SinhVienService : ISinhVienService
    {
        private readonly HttpClient _http;

        public SinhVienService(HttpClient http)
        {
            _http = http;
        }
        public List<SinhVienTT> SinhVienTTss { get ; set ; } = new List<SinhVienTT>();
        public List<Status> Statuss { get; set; }=new List<Status>();

        public Task<SinhVienTT> GetSingleSinhVien(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetSinhVienTTss()
        {
            var result = await _http.GetFromJsonAsync<List<SinhVienTT>>("api/sinhvientt");
            if(result != null)
                SinhVienTTss = result;
        }

        public Task GetStatuss()
        {
            throw new NotImplementedException();
        }
    }
}
