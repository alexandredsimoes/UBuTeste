using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUBus.Models;
using UBus.ViewModels;

namespace TesteUBus.Services.Mapping
{
    public class ViewModelToModelProfiler : Profile
    {
        public ViewModelToModelProfiler()
        {
            CreateMap<FuncionarioViewModel, Funcionario>().ReverseMap();
        }
    }
}
