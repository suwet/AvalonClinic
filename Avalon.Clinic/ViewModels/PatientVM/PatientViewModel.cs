using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;
using Avalon.Clinic.ViewModels.M_yearVM;
using Avalon.Clinic.ViewModels.M_monthVM;
using Avalon.Clinic.ViewModels.M_dayVM;
using System.Net.NetworkInformation;
using Avalon.Clinic.ViewModels.BloodGroupVM;
using System.ComponentModel.DataAnnotations;

namespace Avalon.Clinic.ViewModels.PatientVM
{
	public partial class PatientViewModel : ReactiveViewModelBase
	{
		private Int32  _id;  
    
		private String  _idcard;  
    
		private String  _firstname;  
    
		private String  _lastname;  
    
		private String  _email;  
    
		private String  _address;  
    
		private DateTime  _birthdate;  
    
		private String  _mobliephone;  
    
		private Int32  _age;

        private String _sex = "man";  
    
		private Int32  _bloodgroupid;  
    
		private String  _chronicdisease;  
    
		private String  _ocipation;  
    
		private String  _nationality;  
    
		private DateTime  _createddate;  
    
		private DateTime  _modifielddate;  
    
		private String  _remark;  
    
		private String  _active;  

        private List<M_yearViewModel> _years = new List<M_yearViewModel>();
        private List<M_monthViewModel> _months = new List<M_monthViewModel>();
        private List<M_dayViewModel> _days = new List<M_dayViewModel>();
        private List<BloodGroupViewModel> _bloodGroups = new List<BloodGroupViewModel>();

        private string _bloodgroupname;
        ////////////////////////////
        public Int32  Id  
 		{
		   get=> _id;
		   set => this.RaiseAndSetIfChanged(ref _id,value);
		}

        [Required]
        public String  IDCard  
 		{
		   get=> _idcard;
		   set => this.RaiseAndSetIfChanged(ref _idcard,value);
		}
        [Required]
        public String  FirstName  
 		{
		   get=> _firstname;
		   set => this.RaiseAndSetIfChanged(ref _firstname,value);
		}

        [Required]
        public String  LastName  
 		{
		   get=> _lastname;
		   set => this.RaiseAndSetIfChanged(ref _lastname,value);
		}

        public String  Email  
 		{
		   get=> _email;
		   set => this.RaiseAndSetIfChanged(ref _email,value);
		} 
    
		public String  Address  
 		{
		   get=> _address;
		   set => this.RaiseAndSetIfChanged(ref _address,value);
		} 
    
		public DateTime  BirthDate  
 		{
		   get=> _birthdate;
		   set => this.RaiseAndSetIfChanged(ref _birthdate,value);
		} 
    
		public String  MobliePhone  
 		{
		   get=> _mobliephone;
		   set => this.RaiseAndSetIfChanged(ref _mobliephone,value);
		} 
    
		public Int32  Age  
 		{
		   get=> _age;
		   set => this.RaiseAndSetIfChanged(ref _age,value);
		} 
    
		public String  Sex  
 		{
		   get=> _sex;
		   set => this.RaiseAndSetIfChanged(ref _sex,value);
		} 
    
		public Int32  BloodGroupId  
 		{
		   get=> _bloodgroupid;
		   set => this.RaiseAndSetIfChanged(ref _bloodgroupid,value);
		} 
    
		public String  ChronicDisease  
 		{
		   get=> _chronicdisease;
		   set => this.RaiseAndSetIfChanged(ref _chronicdisease,value);
		} 
    
		public String  Ocipation  
 		{
		   get=> _ocipation;
		   set => this.RaiseAndSetIfChanged(ref _ocipation,value);
		} 
    
		public String  Nationality  
 		{
		   get=> _nationality;
		   set => this.RaiseAndSetIfChanged(ref _nationality,value);
		} 
    
		public DateTime  CreatedDate  
 		{
		   get=> _createddate;
		   set => this.RaiseAndSetIfChanged(ref _createddate,value);
		} 
    
		public DateTime  ModifieldDate  
 		{
		   get=> _modifielddate;
		   set => this.RaiseAndSetIfChanged(ref _modifielddate,value);
		} 
    
		public String  Remark  
 		{
		   get=> _remark;
		   set => this.RaiseAndSetIfChanged(ref _remark,value);
		} 
    
		public String  Active  
 		{
		   get=> _active;
		   set => this.RaiseAndSetIfChanged(ref _active,value);
		}

        /// <summary>
        ///  Extra property
        /// </summary>
        public  List<M_yearViewModel> Years 
        {
            get => _years;
            set => this.RaiseAndSetIfChanged(ref _years, value);
        }

        public List<M_monthViewModel> Months
        {
            get => _months;
            set => this.RaiseAndSetIfChanged(ref _months, value);
        }

        public List<M_dayViewModel> Days 
        {
            get => _days;
            set => this.RaiseAndSetIfChanged(ref _days, value);
        }

        public List<BloodGroupViewModel> BloodGroups
        {
            get => _bloodGroups;
            set => this.RaiseAndSetIfChanged(ref _bloodGroups, value);
        }
        public string BloodGroupName {
            get => _bloodgroupname;
            set => this.RaiseAndSetIfChanged(ref _bloodgroupname,value);
        }
    }
}
