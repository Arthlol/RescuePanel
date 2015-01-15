using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace MvcApplication1.Models
{
     
        [MetadataType(typeof(AdministratorMeta))]
        [DisplayName("Профиль администратора")]
        public partial class Administrator
        {
            public class AdministratorMeta
            {
                [Key]
                [DisplayName("Идентификатор пользователя")]
                public int UserId { get; set; }

                [DisplayName("IP адрес")]
                public string IpAddress { get; set; }
            }
        }


        [MetadataType(typeof(CarMeta))]
        [DisplayName("Автомобиль")]
        public partial class Car
        {
            public class CarMeta
            {
                [Key]
                [DisplayName("Идентификатор автомобиля")]
                public int CarId { get; set; }

                [DisplayName("Госномер автомобиля")]
                public string CarNumber { get; set; }
                [DisplayName("Бренд автомобиля")]
                public string CarBrand { get; set; }
                [DisplayName("Модель автомобиля")]
                public string CarModel { get; set; }
                [DisplayName("Состояние автомобиля")]
                public string CarCondition { get; set; }

            }
        }

        [MetadataType(typeof(DriverMeta))]
        [DisplayName("Водитель")]
        public partial class Driver
        {
            public class DriverMeta
            {
                [Key]
                [DisplayName("Идентификатор водителя")]
                public int UserId { get; set; }
                [DisplayName("Идентификатор отряда")]
                public int EmergencyTeamId { get; set; }

                [DisplayName("Дата последней переаттестации")]
                [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
                public Nullable<System.DateTime> RecertificationDate { get; set; }

                [DisplayName("Номер медицинской книжки")]
                public string MedicalCertificateNum { get; set; }
                [DisplayName("Категория водительских прав")]
                public string DrivingLicenseCategory { get; set; }


            }
        }


        [MetadataType(typeof(EmergencyTeamMeta))]
        [DisplayName("Поисково-спасательный отряд")]
        public partial class EmergencyTeam
        {
            public class EmergencyTeamMeta
            {
                [Key]
                [DisplayName("Идентификатор отряда")]
                public int EmergencyTeamId { get; set; }

                [DisplayName("Дата сформирования отряда")]
                [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
                public Nullable<System.DateTime> CreateDate { get; set; }
            }
        }

        [MetadataType(typeof(EmergencyTeamDepartureMeta))]
        [DisplayName("Выезд поисково-спасательного отряда")]
        public partial class EmergencyTeamDeparture
        {
            public class EmergencyTeamDepartureMeta
            {
                [Key]
                [DisplayName("Идентификатор выезда")]
                public int DepartureId { get; set; }
                [DisplayName("Идентификатор заявки")]
                public int RequestId { get; set; }
                [DisplayName("Идентификатор поисково-спасательного отряда")]
                public int EmergencyTeamId { get; set; }
                [DisplayName("Идентификатор автомобиля")]
                public int CarId { get; set; }

                [DisplayName("Дата выезда")]
                [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
                public Nullable<System.DateTime> DepartureDate { get; set; }
            }
        }


        [MetadataType(typeof(EmployeeMeta))]
        [DisplayName("Сотрудник")]
        public partial class Employee
        {
            public class EmployeeMeta
            {
                [Key]
                [DisplayName("Идентификатор пользователя")]
                public int UserId { get; set; }
                [DisplayName("Идентификатор должности")]
                public int JobTitleId { get; set; }
                [DisplayName("Персональный номер")]
                public Nullable<int> PersonalNumber { get; set; }
                [DisplayName("Рабочий номер телефона")]
                public string WorkPhone { get; set; }
            }
        }


        [MetadataType(typeof(JobTitleMeta))]
        [DisplayName("Сотрудник")]
        public partial class JobTitle
        {
            public class JobTitleMeta
            {
                [Key]
                [DisplayName("Идентификатор должности")]
                public int JobTitleId { get; set; }
                [DisplayName("Название должности")]
                public string JobTitleName { get; set; }
                [DisplayName("Оклад")]
                public Nullable<decimal> Salary { get; set; }

            }
        }

        [MetadataType(typeof(OperatorMeta))]
        [DisplayName("Сотрудник")]
        public partial class Operator
        {
            public class OperatorMeta
            {
                [Key]
                [DisplayName("Идентификатор пользователя")]
                public int UserId { get; set; }

                [DisplayName("Рабочая смена")]
                public string WorkShift { get; set; }

                [DisplayName("Возможность работать сверх нормы")]
                public Nullable<bool> MayWorkOvertime { get; set; }

                [DisplayName("Домашний телефон")]
                public string HomePhone { get; set; }
            }
        }

        [MetadataType(typeof(RequestMeta))]
        [DisplayName("Заявка")]
        public partial class Request
        {
            public class RequestMeta
            {
                [Key]
                [DisplayName("Идентификатор заявки")]
                public int RequestId { get; set; }
                [DisplayName("Идентификатор оператора")]
                public int UserId { get; set; }
                [DisplayName("Идентификатор статуса заявки")]
                public int RequestStatusId { get; set; }
                [DisplayName("Идентификатор типа заявки")]
                public int RequestTypeId { get; set; }
                [DisplayName("Имя заявителя")]
                public string DeclarantName { get; set; }
                [DisplayName("Фамилия заявителя")]
                public string DeclarantLastName { get; set; }
                [DisplayName("Отчество заявителя")]
                public string DeclarantMiddleName { get; set; }
                [DisplayName("Дата подачи заявления")]
                [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
                public Nullable<System.DateTime> RequestDate { get; set; }
                [DisplayName("Контактный телефон заявителя")]
                public string DeclarantPhone { get; set; }
                [DisplayName("Адрес")]
                public string Address { get; set; }
                [DisplayName("Причина вызова")]
                public string RequestReason { get; set; }
                [DisplayName("Ложный вызов")]
                public Nullable<bool> FakeRequest { get; set; }
            }
        }

        [MetadataType(typeof(RequestStatusMeta))]
        [DisplayName("Статус заявки")]
        public partial class RequestStatus
        {
            public class RequestStatusMeta
            {
                [Key]
                [DisplayName("Идентификатор статуса заявки")]
                public int RequestStatusId { get; set; }
                [DisplayName("Наименование статуса заявки")]
                public string RequestStatusName { get; set; }
            }
        }


        [MetadataType(typeof(RequestTypeMeta))]
        [DisplayName("Тип заявки")]
        public partial class RequestType
        {
            public class RequestTypeMeta
            {
                [Key]
                [DisplayName("Тип заявки")]
                public int RequestTypeId { get; set; }
                [DisplayName("Наименование типа заявки")]
                public string RequestTypeName { get; set; }
            }
        }

        [MetadataType(typeof(RescueEquipmentSetMeta))]
        [DisplayName("Набор аварийно-спасательного оборудования")]
        public partial class RescueEquipmentSet
        {
            public class RescueEquipmentSetMeta
            {
                [Key]
                [DisplayName("Идентификатор набора")]
                public int RescueEquipmentSetId { get; set; }
                [DisplayName("Идентификатор автомобиля")]
                public int CarId { get; set; }
                [DisplayName("Количество предметов в наборе")]
                public Nullable<int> RescueEquipmentCount { get; set; }
                [DisplayName("Состояние набора")]
                public string RescueEquipmentCondition { get; set; }
                [DisplayName("Информация об оборудовании")]
                public string RescueEquipmentDescription { get; set; }
                [DisplayName("Предметно-функциональная классификация")]
                public string RescueEquipmentClassification { get; set; }
            }
        }

        [MetadataType(typeof(RescuerMeta))]
        [DisplayName("Спасатель")]
        public partial class Rescuer
        {
            public class RescuerMeta
            {
                [Key]
                [DisplayName("Идентификатор пользователя")]
                public int UserId { get; set; }
                [DisplayName("Идентификатор спасательного отряда")]
                public int EmergencyTeamId { get; set; }
                [DisplayName("Координатор группы")]
                public Nullable<bool> HeadOfGroup { get; set; }
                [DisplayName("Дата прохождения медкомиссии")]
                [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
                public Nullable<System.DateTime> MedicalBoardPassageDate { get; set; }
            }
        }

        [MetadataType(typeof(UserInformationMeta))]
        [DisplayName("Пользователь системы")]
        public partial class UserInformation
        {
            public class UserInformationMeta
            {
                [Key]
                [DisplayName("Идентификатор пользователя")]
                public int UserId { get; set; }
                [DisplayName("Фамилия")]
                public string LastName { get; set; }
                [DisplayName("Имя")]
                public string Name { get; set; }
                [DisplayName("Отчество")]
                public string MiddleName { get; set; }
                [DisplayName("Личный телефон")]
                public string PersonalPhone { get; set; }
                [DisplayName("День рождения")]
                [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
                public Nullable<System.DateTime> BirthDate { get; set; }
            }
        }

        [MetadataType(typeof(UserProfileMeta))]
        [DisplayName("Профиль пользователя системы")]
        public partial class UserProfile
        {
            public class UserProfileMeta
            {
                [Key]
                [DisplayName("Идентификатор пользователя")]
                public int UserId { get; set; }
                [Key]
                [DisplayName("Псевдоним пользователя")]
                public string UserName { get; set; }
            }
        }
    }
