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
            [DisplayName("ID пользователя")]
            [Key]
            public int UserId { get; set; }

            [DisplayName("IP")]
            public string IpAddress { get; set; }
        }
    }

    [MetadataType(typeof(CarMeta))]
    [DisplayName("Автомобиль")]
    public partial class Car
    {
        public class CarMeta
        {
            [DisplayName("ID автомобиля")]
            [Key]
            public int CarId { get; set; }
            [DisplayName("Номер авто")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string CarNumber { get; set; }
            [DisplayName("Марка")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string CarBrand { get; set; }
            [DisplayName("Модель")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string CarModel { get; set; }
            [DisplayName("Состояние авто")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string CarCondition { get; set; }
        }
    }
    [MetadataType(typeof(DriverMeta))]
    [DisplayName("Профиль водителя")]
    public partial class Driver
    {
        public class DriverMeta
        {
            [DisplayName("ID автомобиля")]
            [Key]
            public int UserId { get; set; }
            [DisplayName("ID спасательной группы")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public int EmergencyTeamId { get; set; }
            [DisplayName("Дата переаттестации")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> RecertificationDate { get; set; }
            [DisplayName("Номер медкнижки")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string MedicalCertificateNum { get; set; }
            [DisplayName("Категория водительских прав")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string DrivingLicenseCategory { get; set; }
        }
    }

    [MetadataType(typeof(EmergencyTeamMeta))]
    [DisplayName("Профиль спасательной группы")]
    public partial class EmergencyTeam
    {
        public class EmergencyTeamMeta
        {
            [DisplayName("ID спасательной группы")]
            [Key]
            public int EmergencyTeamId { get; set; }
            [DisplayName("Дата создания")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> CreateDate { get; set; }
            [DisplayName("Название спасательной группы")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string EmergencyTeamName { get; set; }
        }
    }
    [MetadataType(typeof(EmergencyTeamDepartureMeta))]
    [DisplayName("Выезд поисково-спасательного отряда")]
    public partial class EmergencyTeamDeparture
    {
        public class EmergencyTeamDepartureMeta
        {
            [DisplayName("ID выезда")]
            [Key]
            public int EmergencyTeamDepartureId { get; set; }
            [DisplayName("ID заявки")]
            public int RequestId { get; set; }
            [DisplayName("ID спасательной группы")]
            public int EmergencyTeamId { get; set; }
            [DisplayName("ID автомобиля")]
            public int CarId { get; set; }
            [DisplayName("Дата выезда")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> DepartureDate { get; set; }
        }
    }

    [MetadataType(typeof(EmployeeMeta))]
    [DisplayName("Профиль сотрудника")]
    public partial class Employee
    {
        public class EmployeeMeta
        {
            [DisplayName("ID сотрудника")]
            [Key]
            public int UserId { get; set; }
            [DisplayName("ID должности")]
            public int JobTitleId { get; set; }
            [DisplayName("Персональный номер")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public Nullable<int> PersonalNumber { get; set; }
            [DisplayName("Рабочий телефон")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string WorkPhone { get; set; }
        }
    }

    [MetadataType(typeof(JobTitleMeta))]
    [DisplayName("Должность")]
    public partial class JobTitle
    {
        public class JobTitleMeta
        {
            [DisplayName("ID должности")]
            [Key]
            public int JobTitleId { get; set; }
            [DisplayName("Должность")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string JobTitleName { get; set; }
        }
    }
    [MetadataType(typeof(OperatorMeta))]
    [DisplayName("Профиль сотрудника")]
    public partial class Operator
    {
        public class OperatorMeta
        {
            [DisplayName("ID сотрудника")]
            [Key]
            public int UserId { get; set; }
            [DisplayName("Рабочая смена")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string WorkShift { get; set; }
            [DisplayName("Может работать сверх нормы")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public Nullable<bool> MayWorkOvertime { get; set; }
            [DisplayName("Домашний телефон")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string HomePhone { get; set; }
        }
    }

    [MetadataType(typeof(RequestMeta))]
    [DisplayName("Заявка")]
    public partial class Request
    {
        public class RequestMeta
        {
            [DisplayName("ID заявки")]
            [Key]
            public int RequestId { get; set; }
            [DisplayName("ID сотрудника")]
            public int UserId { get; set; }
            [DisplayName("ID статуса заявки")]
            public int RequestStatusId { get; set; }
            [DisplayName("ID типа заявки")]
            public int RequestTypeId { get; set; }
            [DisplayName("Имя заявителя")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string DeclarantName { get; set; }
            [DisplayName("Фамилия заявителя")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string DeclarantLastName { get; set; }
            [DisplayName("Отчество заявителя")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string DeclarantMiddleName { get; set; }
            [DisplayName("Дата заявки")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> RequestDate { get; set; }
            [DisplayName("Телефон заявителя")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string DeclarantPhone { get; set; }
            [DisplayName("Адрес")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string Address { get; set; }
            [DisplayName("Причина вызова")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string RequestReason { get; set; }
            [DisplayName("Ложный вызов")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public Nullable<bool> FakeRequest { get; set; }
        }
    }

    [MetadataType(typeof(RequestStatusMeta))]
    [DisplayName("Статус заявки")]
    public partial class RequestStatus
    {
        public class RequestStatusMeta
        {
            [DisplayName("ID статуса заявки")]
            [Key]
            public int RequestStatusId { get; set; }
            [DisplayName("Статус заявки")]
            public string RequestStatusName { get; set; }
        }
    }

    [MetadataType(typeof(RequestTypeMeta))]
    [DisplayName("Статус заявки")]
    public partial class RequestType
    {
        public class RequestTypeMeta
        {
            [DisplayName("ID типа заявки")]
            [Key]
            public int RequestTypeId { get; set; }
            [DisplayName("Тип заявки")]
            public string RequestTypeName { get; set; }
        }
    }

    [MetadataType(typeof(RescueEquipmentSetMeta))]
    [DisplayName("Набор оборудования")]
    public partial class RescueEquipmentSet
    {
        public class RescueEquipmentSetMeta
        {
            [DisplayName("ID набора")]
            [Key]
            public int RescueEquipmentSetId { get; set; }
            [DisplayName("ID машины")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public Nullable<int> CarId { get; set; }
            [DisplayName("Количество инструментов")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public Nullable<int> RescueEquipmentCount { get; set; }
            [DisplayName("Состояние инструментов")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string RescueEquipmentCondition { get; set; }
            [DisplayName("Описание")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string RescueEquipmentDescription { get; set; }
            [DisplayName("Предметная классификация")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string RescueEquipmentClassification { get; set; }
        }
    }

    [MetadataType(typeof(RescuerMeta))]
    [DisplayName("Профиль спасателя")]
    public partial class Rescuer
    {
        public  class RescuerMeta
        {
            [DisplayName("ID пользователя")]
            [Key]
            public int UserId { get; set; }
            [DisplayName("ID группы")]
            public int EmergencyTeamId { get; set; }
            [DisplayName("Координатор группы")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public Nullable<bool> HeadOfGroup { get; set; }
            [DisplayName("Дата последней медкомиссии")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> MedicalBoardPassageDate { get; set; }
        }
    }

    [MetadataType(typeof(UserInformationMeta))]
    [DisplayName("Информация о пользователе")]
    public partial class UserInformation
    {
        public class UserInformationMeta
        {
            [DisplayName("ID пользователя")]
            [Key]
            public int UserId { get; set; }
            [DisplayName("Фамилия")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string LastName { get; set; }
            [DisplayName("Имя")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string Name { get; set; }
            [DisplayName("Отчество")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string MiddleName { get; set; }
            [DisplayName("Личный телефон")]
            [DisplayFormat(NullDisplayText = "Не указано")]
            public string PersonalPhone { get; set; }
            [DisplayName("Дата рождения")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Не указана", ConvertEmptyStringToNull = true)]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> BirthDate { get; set; }
        }
    }
    [MetadataType(typeof(UserProfileMeta))]
    [DisplayName("Профиль пользователя")]
    public partial class UserProfile
    {
        public class UserProfileMeta
        {
            [DisplayName("ID пользователя")]
            [Key]
            public int UserId { get; set; }
            [DisplayName("Логин")]
            public string UserName { get; set; }
        }
    }
}