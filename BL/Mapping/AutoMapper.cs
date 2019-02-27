using AutoMapper;
using BL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Mapping
{
    public class AutoMapper
    {
        public static IMapper GetDefaultMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>()
                    .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                    .ForMember(c => c.ImageUrl, c => c.MapFrom(cd => cd.ImageUrl))
                    .ForMember(c => c.Name, c => c.MapFrom(cd => cd.Name))
                    .ForMember(c => c.Products, c => c.MapFrom(cd => cd.Products))
                    .ForMember(c => c.Description, c => c.MapFrom(cd => cd.Description));
                cfg.CreateMap<Category, CategoryDTO>()
                    .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                    .ForMember(c => c.ImageUrl, c => c.MapFrom(cd => cd.ImageUrl))
                    .ForMember(c => c.Name, c => c.MapFrom(cd => cd.Name))
                    .ForMember(c => c.Products, c => c.MapFrom(cd => cd.Products))
                    .ForMember(c => c.Description, c => c.MapFrom(cd => cd.Description));

                cfg.CreateMap<Option, OptionDTO>()
                    .ForMember(c => c.Name, c => c.MapFrom(cd => cd.Name))
                    .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id));
                cfg.CreateMap<OptionDTO, Option>()
                   .ForMember(c => c.Name, c => c.MapFrom(cd => cd.Name))
                   .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id));

                cfg.CreateMap<Order, OrderDTO>()
                    .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                    .ForMember(c => c.Comment, c => c.MapFrom(cd => cd.Comment))
                    .ForMember(c => c.User, c => c.MapFrom(cd => cd.User))
                    .ForMember(c => c.PaymentType, c => c.MapFrom(cd => cd.PaymentType))
                    .ForMember(c => c.Comment, c => c.MapFrom(cd => cd.Comment))
                    .ForMember(c => c.Products, c => c.MapFrom(cd => cd.ProductOrders.Select(po => po.Product)));

                cfg.CreateMap<OrderDTO, Order>()
                    .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                    .ForMember(c => c.Comment, c => c.MapFrom(cd => cd.Comment))
                    .ForMember(c => c.User, c => c.MapFrom(cd => cd.User))
                    .ForMember(c => c.PaymentType, c => c.MapFrom(cd => cd.PaymentType))
                    .ForMember(c => c.Comment, c => c.MapFrom(cd => cd.Comment))
                    .ForMember(c => c.ProductOrders, c => c.Ignore());

                cfg.CreateMap<Producer, ProducerDTO>()
                    .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                    .ForMember(c => c.Products, c => c.MapFrom(cd => cd.Products))
                    .ForMember(c => c.Name, c => c.MapFrom(cd => cd.Name))
                    .ForMember(c => c.Description, c => c.MapFrom(cd => cd.Description));

                cfg.CreateMap<ProducerDTO, Producer>()
                    .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                    .ForMember(c => c.Products, c => c.MapFrom(cd => cd.Products))
                    .ForMember(c => c.Name, c => c.MapFrom(cd => cd.Name))
                    .ForMember(c => c.Description, c => c.MapFrom(cd => cd.Description));

                cfg.CreateMap<Product, ProductDTO>()
                   .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                   .ForMember(c => c.Model, c => c.MapFrom(cd => cd.Model))
                   .ForMember(c => c.Price, c => c.MapFrom(cd => cd.Price))
                   .ForMember(c => c.Description, c => c.MapFrom(cd => cd.Description))
                   .ForMember(c => c.ProducerName, c => c.MapFrom(cd => cd.Producer.Name))
                   .ForMember(c => c.CategoryName, c => c.MapFrom(cd => cd.Category.Name))
                   .ForMember(c => c.NumberOfItems, c => c.MapFrom(cd => cd.NumberOfItems))
                   .ForMember(c => c.ProductImages, c => c.MapFrom(cd => cd.ProductImages))
                   .ForMember(c => c.Options, c => c.MapFrom(cd => cd.Options))
                   .ForMember(c => c.PriceWithDiscount, c => c.MapFrom(cd => cd.Price - (cd.Price * cd.Discount) / 100));

                cfg.CreateMap<ProductDTO, Product>()
                   .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                   .ForMember(c => c.Model, c => c.MapFrom(cd => cd.Model))
                   .ForMember(c => c.Price, c => c.MapFrom(cd => cd.Price))
                   .ForMember(c => c.Description, c => c.MapFrom(cd => cd.Description))
                   .ForMember(c => c.Producer, c => c.Ignore())
                   .ForMember(c => c.Category, c => c.Ignore())
                   .ForMember(c => c.NumberOfItems, c => c.MapFrom(cd => cd.NumberOfItems))
                   .ForMember(c => c.ProductImages, c => c.MapFrom(cd => cd.ProductImages))
                   .ForMember(c => c.Options, c => c.MapFrom(cd => cd.Options))
                   .ForMember(c => c.Discount, c => c.MapFrom(cd => cd.Discount));

                cfg.CreateMap<ProductImage, ProductImageDTO>()
                   .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                   .ForMember(c => c.ImageUrl, c => c.MapFrom(cd => cd.ImageUrl));

                cfg.CreateMap<ProductImageDTO, ProductImage>()
                   .ForMember(c => c.Id, c => c.MapFrom(cd => cd.Id))
                   .ForMember(c => c.ImageUrl, c => c.MapFrom(cd => cd.ImageUrl));

            }).CreateMapper();
        }
    }
}
