using AutoMapper;
using MultiShop.Catalog.Dtos.AboutDto;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ContactDto;
using MultiShop.Catalog.Dtos.FeatuesSliderDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Dtos.SpecialOffterDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();


            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();




            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();



            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            CreateMap<Product, ResultProductsWithCategory>().ReverseMap();



            CreateMap<FeaturesSlider, ResultFeaturesSliderDto>().ReverseMap();
            CreateMap<FeaturesSlider, CreateFeaturesSliderDto>().ReverseMap();
            CreateMap<FeaturesSlider, UpdateFeaturesSliderDto>().ReverseMap();
            CreateMap<FeaturesSlider, GetByIdFeaturesSliderDto>().ReverseMap();




            CreateMap<SpecialOffter, GetByIDSpecialOffterDto>().ReverseMap();
            CreateMap<SpecialOffter, CreateSpecialOffterDto>().ReverseMap();
            CreateMap<SpecialOffter, UpdateSpecialOffterDto>().ReverseMap();
            CreateMap<SpecialOffter, ResultSpecialOffterDto>().ReverseMap();

            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();



            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();


        }
    }
}
