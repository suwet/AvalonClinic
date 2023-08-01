﻿using System.Text.RegularExpressions;
using Avalonia.Data;

namespace Avalon.Clinic.ViewModels
{
    public class TextFieldsViewModel : ViewModelBase
    {
        private string _numerics;

        public string Numerics
        {
            get => _numerics;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\d+([A-Za-z-+.']\d+)*$"))
                {
                    throw new DataValidationException("Invalid numerics");
                }

                _numerics = value;
                OnPropertyChanged();
            }
        }
    }
}