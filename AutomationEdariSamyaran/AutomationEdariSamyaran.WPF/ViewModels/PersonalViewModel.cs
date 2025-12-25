using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutomationEdariSamyaran.WPF.Common;
using AutomationEdariSamyaran.WPF.Converter;
using AutomationEdariSamyaran.WPF.Enums;
using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using Microsoft.Win32;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class PersonalViewModel : ObservableObject
    {

        [ObservableProperty]
        private PersonalDto _personal = new PersonalDto();
        [ObservableProperty] private string? _photoPath;
        [ObservableProperty] private FormType _formType;
        private readonly RestApiService _apiService;

        public List<MaritalStatus> MaritalStatusList { get; }
        [ObservableProperty]
        private MaritalStatus selectedMaritalStatus = MaritalStatus.Single;
        public PersonalViewModel()
        {
            _apiService = new RestApiService();
            MaritalStatusList = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().ToList();
            FormType = FormType.New;
             SelectedMaritalStatus = MaritalStatusConverter.ToMaritalStatus(Personal.MaritalStatus) ?? MaritalStatus.Single;
        }

        public PersonalViewModel(PersonalDto? inputPersonalDto)
        {
            _apiService = new RestApiService();
            MaritalStatusList = Enum.GetValues(typeof(MaritalStatus)).Cast<MaritalStatus>().ToList();
            Personal = inputPersonalDto ?? new PersonalDto();
            SelectedMaritalStatus = (MaritalStatus)MaritalStatusConverter.NormalizeMaritalStatus(inputPersonalDto.MaritalStatus);
            FormType = FormType.Edit;
        }

        [RelayCommand]
        private async Task Save()
        {

            CreatePersonalCommand command = new CreatePersonalCommand
            {
                Address = Personal.Address,
                BankAccountNumber = Personal.BankAccountNumber,
                BankName = Personal.BankName,
                BirthCity = Personal.BirthCity,
                BirthDate = Personal.BirthDate,
                BirthProvince = Personal.BirthProvince,
                Email = Personal.Email,
                EmergencyContactPhone = Personal.EmergencyContactPhone,
                EmploymentEndDate = Personal.EmploymentEndDate,
                PersonalCode = Personal.PersonalCode,
                EmploymentStartDate = Personal.EmploymentStartDate,
                FullName = Personal.FullName,
                NationalCode = Personal.NationalCode,
                IdDepartment = Personal.IdDepartment,
                IdPosition = Personal.IdPosition,
                InsuranceNumber = Personal.InsuranceNumber,
                IsActive = Personal.IsActive,
                NumberOfChildren = Personal.NumberOfChildren,
                Phone = Personal.Phone,
               MaritalStatus = MaritalStatusConverter.ToMaritalStatus(Personal.MaritalStatus) 
            };



            if (FormType == FormType.New)
            {
                try
                {
                    var created = await _apiService.CreatePersonalAsync(command);

                    AppMessage.CustomMessage($"پرسنل {created.FullName} ذخیره شد!", "تایید", MyColors.GreenYellow);
                }
                catch (ValidationException ve)
                {
                    AppMessage.CustomMessage(ve.Message, "خطای اعتبارسنجی", MyColors.Red);
                }
                catch (Exception e)
                {
                    AppMessage.CustomMessage(e.Message, "خطا", MyColors.Red);
                }

            }
            else if (FormType == FormType.Edit)
            {
                AppMessage.CustomMessage($"پرسنل {Personal.FullName} ذخیره شد!", "تایید", MyColors.GreenYellow);
            }
        }

        [RelayCommand]
        private void Cancel(Window window)
        {
            window?.Close();
        }

        [RelayCommand]
        private void SelectPhoto()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == true)
            {
                PhotoPath = dlg.FileName;
                _personal.PhotoPath = _photoPath;
            }
        }


    }


    public enum FormType
    {
        Edit,
        New
    }
}
