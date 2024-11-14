using GreenDiamond.Application.DTOs.GreenDiamond;

namespace GreenDiamond.Application.Interface.GreenDiamond
{
    public interface IClotheDisplayService
    {
        Task<ClotheDisplayDto> GetClotheDisplayById(int id);

        Task<ClotheDisplayListDto> GetAllClotheDisplay(int page, int pageSize, string search);

        Task<int> Save(ClotheDisplayDto clotheDisplay);

        Task<bool> Delete(int id);
    }
}
