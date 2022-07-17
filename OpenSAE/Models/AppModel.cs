﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenSAE.Core.SAML;
using OpenSAE.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenSAE.Models
{
    /// <summary>
    /// Main model for the app
    /// </summary>
    public class AppModel : ObservableObject
    {
        private readonly IDialogService _dialogService;
        private SymbolArtModel? _currentSymbolArt;
        private SymbolArtItemModel? _selectedItem;

        public event EventHandler? ExitRequested;

        /// <summary>
        /// Currently opened Symbol Art
        /// </summary>
        public SymbolArtModel? CurrentSymbolArt
        {
            get => _currentSymbolArt;
            set
            {
                if (SetProperty(ref _currentSymbolArt, value))
                {
                    OnPropertyChanged(nameof(AppTitle));
                }
            }
        }

        /// <summary>
        /// Currently selected item (group, layer, SA root)
        /// </summary>
        public SymbolArtItemModel? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public string AppTitle
        {
            get
            {
                var title = "OpenSAE Symbol Art Editor";

                if (CurrentSymbolArt != null)
                {
                    title += $" - {CurrentSymbolArt.Name}";
                }

                return title;
            }
        }

        public ICommand NewFileCommand { get; }

        public ICommand OpenFileCommand { get; }

        public ICommand ExitCommand { get; }

        public AppModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            OpenFileCommand = new RelayCommand(OpenFile_Implementation);
            NewFileCommand = new RelayCommand(NewFile_Implementation);
            ExitCommand = new RelayCommand(() => ExitRequested?.Invoke(this, EventArgs.Empty));
        }

        private void NewFile_Implementation()
        {
            CurrentSymbolArt = new SymbolArtModel();
            SelectedItem = CurrentSymbolArt;
        }

        public bool RequestExit()
        {
            return true;
        }

        private void OpenFile_Implementation()
        {
            string? filename = _dialogService.BrowseOpenFile("Open existing symbol art file", "SAML symbol art (*.saml)|*.saml");

            if (filename == null)
                return;

            try
            {
                using var fs = File.OpenRead(filename);
                CurrentSymbolArt = new SymbolArtModel(SamlLoader.LoadFromStream(fs));
                SelectedItem = CurrentSymbolArt;
            }
            catch (Exception ex)
            {
                _dialogService.ShowErrorMessage("Error opening file", "Unable to open the selected symbol art file.", ex);
            }
        }
    }
}