﻿using OnMed.Desktop.Pages;
using OnMed.Dtos.Constants;
using OnMed.ViewModel.Appointments;
using OnMed.ViewModel.Categories;
using System;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for PatientComponent.xaml
/// </summary>
public partial class PatientComponent : UserControl
{
    public PatientComponent()
    {
        InitializeComponent();
    }
    public void SetData(AppointmentViewModel viewModel)
    {
        if(!string.IsNullOrEmpty(viewModel.UserImagePath))
        {
            string imageUrl = BaseUrlConstants.BASE_URL + "/" + viewModel.UserImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            patientImage.ImageSource = new BitmapImage(imageUri);
        }

        patientName.Content = viewModel.UserFullName;
        patientPhone.Content = viewModel.UserPhoneNumber;
        doctorName.Content = viewModel.DoctorFullName;
        if (viewModel.UserIsMale)
            patientGender.Content = "Erkak";
        else
            patientGender.Content = "Ayol";
    }
}
