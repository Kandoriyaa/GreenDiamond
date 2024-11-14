using GreenDiamond.Application.DTOs.GreenDiamond;
using GreenDiamond.Application.Helper;
using GreenDiamond.Application.Interface.File;
using GreenDiamond.Application.Interface.GreenDiamond;
using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.UnitOfWork;

namespace GreenDiamond.Application.Service.GreenDiamond
{
    public class ClotheDisplayService : IClotheDisplayService
    {
        private readonly IUnitOfWorkGreenDiamond _unitOfWorkGreenDiamond;
        private readonly IImageStorageService _imageStorageService;

        public ClotheDisplayService(IUnitOfWorkGreenDiamond unitOfWorkGreenDiamond, IImageStorageService imageStorageService)
        {
            _imageStorageService = imageStorageService;
            _unitOfWorkGreenDiamond = unitOfWorkGreenDiamond;
        }

        public async Task<ClotheDisplayListDto> GetAllClotheDisplay(int page, int pageSize, string search)
        {
            var (clothedisplayList, totalCount) = await _unitOfWorkGreenDiamond.ClotheDisplayRepository.GetAllAsync(page, pageSize, search);
            var Cloth = clothedisplayList.Select(cloths => new ClotheDisplayDto
            {
                Id = cloths.Id,
                ClotheName = cloths.ClotheName,
                Price = cloths.Price,
                Photo = _imageStorageService.GetImage(cloths.Photo, GlobalDeclaration._clothe_path),
                Discount = cloths.Discount,
                Discription = cloths.Discription,
                Manufacturer = cloths.Manufacturer,
                TypeOfMaterial = cloths.TypeOfMaterial,
                Quantity = cloths.Quantity,
                IsActive = cloths.IsActive,
                IsDeleted = cloths.IsDelete,
                CreatedBy = cloths.CreateBy,
                CreatedDate = cloths.CreateDate.GetValueOrDefault(),
                ModifiedBy = cloths.ModifiedBy,
                ModifiedDate = cloths.ModifiedDate,
            });
            ClotheDisplayListDto Result = new ClotheDisplayListDto();
            Result.clothedisplayDtoinfo = Cloth.ToList();
            Result.TotalRecords = totalCount;
            return await Task.FromResult(Result);
        }

        public async Task<ClotheDisplayDto> GetClotheDisplayById(int id)
        {
            var Cloth = await _unitOfWorkGreenDiamond.ClotheDisplayRepository.GetClotheIdAsync(id);
            var ClothDto = new ClotheDisplayDto
            {
                Id = Cloth.Id,
                ClotheName = Cloth.ClotheName,
                Price = Cloth.Price,
                Photo = _imageStorageService.GetImage(Cloth.Photo, GlobalDeclaration._clothe_path),
                Discount = Cloth.Discount,
                Discription = Cloth.Discription,
                Manufacturer = Cloth.Manufacturer,
                TypeOfMaterial = Cloth.TypeOfMaterial,
                Quantity = Cloth.Quantity,
                IsActive = Cloth.IsActive,
                IsDeleted = Cloth.IsDelete,
                CreatedBy = Cloth.CreateBy,
                CreatedDate = Cloth.CreateDate.GetValueOrDefault(),
                ModifiedBy = Cloth.ModifiedBy,
                ModifiedDate = Cloth.ModifiedDate,
            };
            return await Task.FromResult(ClothDto);
        }

        public async Task<int> Save(ClotheDisplayDto clotheDisplayDto)
        {
            var clotheDisplay = await _unitOfWorkGreenDiamond.ClotheDisplayRepository.GetClotheIdAsync(Convert.ToInt32(clotheDisplayDto.Id));
            if (clotheDisplay == null)
            {
                clotheDisplay = new Category();
                SetClotheProperties(clotheDisplay, clotheDisplayDto, isNew: true);
                await _unitOfWorkGreenDiamond.ClotheDisplayRepository.AddAsync(clotheDisplay);
            }
            else
            {
                SetClotheProperties(clotheDisplay, clotheDisplayDto, isNew: false);
                await _unitOfWorkGreenDiamond.ClotheDisplayRepository.UpdateAsync(clotheDisplay);
            }
            await _unitOfWorkGreenDiamond.CommitAsync();
            return clotheDisplay.Id;
        }

        private void SetClotheProperties(Category clotheDisplay, ClotheDisplayDto clotheDisplayDto, bool isNew)
        {
            clotheDisplay.Id = Convert.ToInt32(clotheDisplayDto.Id);
            clotheDisplay.ClotheName = clotheDisplayDto.ClotheName;
            clotheDisplay.Price = clotheDisplayDto.Price;
            clotheDisplay.Photo = string.IsNullOrEmpty(clotheDisplayDto.Photo) ? clotheDisplay.Photo : clotheDisplayDto.Photo;
            clotheDisplay.Discount = clotheDisplayDto.Discount;
            clotheDisplay.Discription = clotheDisplayDto.Discription;
            clotheDisplay.Manufacturer = clotheDisplayDto.Manufacturer;
            clotheDisplay.TypeOfMaterial = clotheDisplayDto.TypeOfMaterial;
            clotheDisplay.Quantity = clotheDisplayDto.Quantity;
            clotheDisplay.IsActive = clotheDisplayDto.IsActive;
            clotheDisplay.IsDelete = clotheDisplayDto.IsDeleted;

            if (isNew)
            {
                clotheDisplay.CreateDate = DateTime.Now;
                clotheDisplay.CreateBy = 1;
            }
            else
            {
                clotheDisplay.ModifiedBy = 1;
                clotheDisplay.ModifiedDate = DateTime.Now;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var Cloth = await _unitOfWorkGreenDiamond.ClotheDisplayRepository.GetClotheIdAsync(id);
            if (Cloth != null)
            {
                Cloth.IsDelete = true;
                Cloth.IsActive = false;
                await _unitOfWorkGreenDiamond.CommitAsync();
                return true;
            }
            return false;
        }
    }
}
