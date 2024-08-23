using GreenDiamond.Application.DTOs.GreenDiamond;

namespace GreenDiamond.Application.Interface.GreenDiamond
{
    public interface IClassOfTradeService
    {
        Task<ClassOfTradeDto> GetClassOfTradeById(string id);

        Task<ClassOfTradeListDto> GetAllClassOfTrade(int page, int pageSize, string search);

        Task<string> Save(ClassOfTradeDto classOfTradeDto);

        Task<bool> Delete(string id);
    }
}
