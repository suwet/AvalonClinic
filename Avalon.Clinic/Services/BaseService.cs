using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;
using AutoMapper;
using Avalon.Clinic.Models;
using Avalon.Clinic.ViewModels.M_dayVM;
using Avalon.Clinic.ViewModels.PatientVM;
using Avalon.Clinic.ViewModels.M_yearVM;
using Avalon.Clinic.ViewModels.M_monthVM;
using Avalon.Clinic.ViewModels.BloodGroupVM;
using Avalon.Clinic.ViewModels.UsersVM;
using Avalon.Clinic.ViewModels.RoleVM;

namespace Avalon.Clinic.Services
{
	public  class BaseService
	{
		public MapperConfiguration MapConfig {get;set;}

		public BaseService()
		{
			// https://docs.automapper.org/en/stable/Configuration.html
			MapConfig = new MapperConfiguration(cfg => 
			{
				cfg.CreateMap<M_day,M_dayViewModel>();
				cfg.CreateMap<M_dayViewModel,M_day>();

                cfg.CreateMap<Patient, PatientViewModel>();
                cfg.CreateMap<PatientViewModel, Patient>();

                cfg.CreateMap<M_yearViewModel, M_year>();
                cfg.CreateMap<M_year, M_yearViewModel>();

                cfg.CreateMap<M_monthViewModel, M_month>();
                cfg.CreateMap<M_month, M_monthViewModel>();

                cfg.CreateMap<M_dayViewModel, M_day>();
                cfg.CreateMap<M_day, M_dayViewModel>();

                cfg.CreateMap<BloodGroupViewModel, BloodGroup>();
                cfg.CreateMap<BloodGroup, BloodGroupViewModel>();
                
                /* Users */
                cfg.CreateMap<UsersModel, UsersViewModel>();
                cfg.CreateMap<UsersViewModel, UsersModel>();

                cfg.CreateMap<RolesViewModel, Roles>();
                cfg.CreateMap<Roles, RolesViewModel>();
            }
			);

			TheMapper = new Mapper(MapConfig);
			//OrderDto dto = mapper.Map<DestinationType>(source);
		}

		public Mapper TheMapper {get;set;}

		public virtual void ConfigMapForService()
		{

		}
	}
}
