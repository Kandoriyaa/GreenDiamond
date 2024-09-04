using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Interface.GreenDiamond;
using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.UnitOfWork;

namespace GreenDiamond.Application.Service.GreenDiamond
{
    public class ClassOfTradeService : IClassOfTradeService
    {
        private readonly IUnitOfWorkGreenDiamond _unitOfWorkGD;

        public ClassOfTradeService(IUnitOfWorkGreenDiamond unitOfWorkGreenDiamond)
        {
            _unitOfWorkGD = unitOfWorkGreenDiamond;
        }

        public async Task<ClassOfTradeListDto> GetAllClassOfTrade(int page, int pageSize, string search)
        {
            var (classOfTrade, totalCount) = await _unitOfWorkGD.ClassOfTradeRepository.GetAllAsync(page, pageSize, search);

            var Opstion = classOfTrade.Select(classOfTrades => new ClassOfTradeDto
            {
                TradeCode = classOfTrades.TradeCode,
                TradeDesc = classOfTrades.TradeDesc,
                IsActive = classOfTrades.IsActive,
                IsDeleted = classOfTrades.IsDeleted,
                CreatedDate = classOfTrades.CreatedDate.GetValueOrDefault(),
                ModifiedDate = classOfTrades.ModifiedDate.GetValueOrDefault()
            });

            ClassOfTradeListDto classOfTradesList = new ClassOfTradeListDto();
            classOfTradesList.classOfTradeDtoinfo = Opstion.ToList();
            classOfTradesList.TotalRecords = totalCount;

            return await Task.FromResult(classOfTradesList);
        }

        public async Task<ClassOfTradeDto> GetClassOfTradeById(string id)
        {
            var Opstion = await _unitOfWorkGD.ClassOfTradeRepository.GetByIdAsync(id);

            var program = new ClassOfTradeDto
            {
                TradeCode = Opstion.TradeCode,
                TradeDesc = Opstion.TradeDesc,
                IsActive = Opstion.IsActive,
                IsDeleted = Opstion.IsDeleted,
                CreatedDate = Opstion.CreatedDate.GetValueOrDefault(),
                ModifiedDate = Opstion.ModifiedDate.GetValueOrDefault()
            };

            return await Task.FromResult(program);
        }

        public async Task<string> Save(ClassOfTradeDto classOfTradeDto)
        {
            var classOfTrade = await _unitOfWorkGD.ClassOfTradeRepository.GetByIdAsync(classOfTradeDto.TradeCode);

            if (classOfTrade == null)
            {
                classOfTrade = new ClassOfTrade();
                SetClassOfTradeProperties(classOfTrade, classOfTradeDto, isNew: true);
                await _unitOfWorkGD.ClassOfTradeRepository.AddAsync(classOfTrade);
            }
            else
            {
                SetClassOfTradeProperties(classOfTrade, classOfTradeDto, isNew: false);
                await _unitOfWorkGD.ClassOfTradeRepository.UpdateAsync(classOfTrade);
            }

            await _unitOfWorkGD.CommitAsync();

            return classOfTrade.TradeCode;
        }

        private void SetClassOfTradeProperties(ClassOfTrade classOfTrade, ClassOfTradeDto classOfTradeDto, bool isNew)
        {
            classOfTrade.TradeCode = classOfTradeDto.TradeCode;
            classOfTrade.TradeDesc = classOfTradeDto.TradeDesc;
            classOfTrade.IsActive = classOfTradeDto.IsActive;
            classOfTrade.IsDeleted = classOfTradeDto.IsDeleted;

            if (isNew)
            {
                classOfTrade.CreatedBy = 1;
                classOfTrade.CreatedDate = DateTime.Now;
            }
            else
            {
                classOfTrade.ModifiedBy = 1;
                classOfTrade.ModifiedDate = DateTime.Now;
            }
        }

        public async Task<bool> Delete(string id)
        {
            var Opstion = await _unitOfWorkGD.ClassOfTradeRepository.GetByIdAsync(id);

            if (Opstion != null)
            {
                Opstion.IsDeleted = true;
                await _unitOfWorkGD.CommitAsync();
                return true;

            }
            return false;
        }
    }
}
