using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Domain.Models;
using WoodWorkshop.Domain.Services;
using WoodWorkshop.Models.PostModels;
using WoodWorkshop.Models.ViewModels;

namespace WoodWorkshop.Controllers
{
    public class EpoxyController
    {
        private readonly EpoxyService _epoxyService;
        private readonly IMapper _mapper;

        public EpoxyController()
        {
            _epoxyService = new EpoxyService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EpoxyPostModel, EpoxyModel>().ReverseMap();
                cfg.CreateMap<EpoxyViewModel, EpoxyModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateWoodFurnitureRequest(EpoxyPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Type))
                throw new System.Exception("Invalid Type");

            var epoxyModel = _mapper.Map<EpoxyModel>(model);

            _epoxyService.CreateFurnitureRequest(epoxyModel);
        }

    }
}

