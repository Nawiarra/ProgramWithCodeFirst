using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data;
using WoodWorkshop.Data.Models;
using WoodWorkshop.Data.Repositories;
using WoodWorkshop.Domain.Models;

namespace WoodWorkshop.Domain.Services
{
    public class EpoxyService
    {
        private readonly EpoxyRepository _epoxyRepository;
        private readonly IMapper _mapper;

        public EpoxyService()
        {
            _epoxyRepository = new EpoxyRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EpoxyModel, Epoxy>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateFurnitureRequest(EpoxyModel model)
        {

            var existedEpoxy = _epoxyRepository.GetByType(model.Type);

            if (existedEpoxy != null)
            {
                throw new System.Exception("This epoxy type has already exist");
            }


            var epoxy = _mapper.Map<Epoxy>(model);

            _epoxyRepository.Create(epoxy);

        }

        
    }
}
