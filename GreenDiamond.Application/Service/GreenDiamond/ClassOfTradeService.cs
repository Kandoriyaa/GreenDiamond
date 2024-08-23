using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Interface.GreenDiamond;
using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.UnitOfWork;

namespace GreenDiamond.Application.Services
{
    public class ClassOfTradeService : IClassOfTradeService
    {
        private readonly IUnitOfWorkGreenDiamond _unitOfWorkErp;

        public ClassOfTradeService(IUnitOfWorkGreenDiamond unitOfWorkErp)
        {
            _unitOfWorkErp = unitOfWorkErp;
        }


        public async Task<ClassOfTradeListDto> GetAllClassOfTrade(int page, int pageSize, string search)
        {
            var (classOfTrade, totalCount) = await _unitOfWorkErp.ClassOfTradeRepository.GetAllAsync(page, pageSize, search);

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
            var Opstion = await _unitOfWorkErp.ClassOfTradeRepository.GetByIdAsync(id);

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
            var classOfTrade = await _unitOfWorkErp.ClassOfTradeRepository.GetByIdAsync(classOfTradeDto.TradeCode);

            if (classOfTrade == null)
            {
                classOfTrade = new ClassOfTrade();
                SetClassOfTradeProperties(classOfTrade, classOfTradeDto, isNew: true);
                await _unitOfWorkErp.ClassOfTradeRepository.AddAsync(classOfTrade);
            }
            else
            {
                SetClassOfTradeProperties(classOfTrade, classOfTradeDto, isNew: false);
                await _unitOfWorkErp.ClassOfTradeRepository.UpdateAsync(classOfTrade);
            }

            await _unitOfWorkErp.CommitAsync();

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
                classOfTrade.CreatedBy = classOfTradeDto.CreatedBy;
                classOfTrade.CreatedDate = classOfTradeDto.CreatedDate;
            }
            else
            {
                classOfTrade.ModifiedBy = classOfTradeDto.ModifiedBy;
                classOfTrade.ModifiedDate = classOfTradeDto.ModifiedDate;
            }
        }

        public async Task<bool> Delete(string id)
        {
            var Opstion = await _unitOfWorkErp.ClassOfTradeRepository.GetByIdAsync(id);

            if (Opstion != null)
            {
                Opstion.IsDeleted = true;
                await _unitOfWorkErp.CommitAsync();
                return true;

            }
            return false;
        }
    }
}
