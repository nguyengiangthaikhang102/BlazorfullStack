namespace BlazorfullStack.Client.Services.SinhVienServices
{
    public interface ISinhVienService
    {
        List<SinhVienTT> SinhVienTTss { get; set; }
        List<Status> Statuss { get; set; }
        Task GetStatuss();
        Task GetSinhVienTTss();
        Task<SinhVienTT> GetSingleSinhVien(int id);
    }
}
