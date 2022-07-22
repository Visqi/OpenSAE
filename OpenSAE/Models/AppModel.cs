﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenSAE.Properties;
using OpenSAE.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static OpenSAE.Behaviors.TreeViewSelectionBehavior;

namespace OpenSAE.Models
{
    /// <summary>
    /// Main model for the app
    /// </summary>
    public class AppModel : ObservableObject
    {
        private const string FileFormatFilter = "Symbol art files (*.saml,*.sar)|*.saml;*.sar|SAML symbol art (*.saml)|*.saml|SAR symbol art (*.sar)|*.sar";
        private const double DefaultSymbolUnitWidth = 240;
        private const double MinimumSymbolUnitWidth = 24;
        private const double MaximumSymbolUnitWidth = 320;

        private readonly IDialogService _dialogService;
        private SymbolArtModel? _currentSymbolArt;
        private SymbolArtItemModel? _selectedItem;
        private bool _applyToneCurve;
        private bool _guideLinesEnabled;
        private double _displaySymbolUnitWidth = DefaultSymbolUnitWidth;

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
                    ZoomPercentage = 100;
                    SaveCommand.NotifyCanExecuteChanged();
                    SaveAsCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Currently selected item (group, layer, SA root)
        /// </summary>
        public SymbolArtItemModel? SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value))
                {
                    CurrentItemCommand.NotifyCanExecuteChanged();
                    RotateCurrentItemCommand.NotifyCanExecuteChanged();
                    OnPropertyChanged(nameof(SelectedItemIsLayer));
                }
            }
        }

        /// <summary>
        /// If the tone curve mapping is enabled to better approximate how colors look in-game
        /// </summary>
        public bool ApplyToneCurve
        {
            get => _applyToneCurve;
            set => SetProperty(ref _applyToneCurve, value);
        }

        /// <summary>
        /// If guide lines should be shown for the center of the symbol art
        /// </summary>
        public bool GuideLinesEnabled
        {
            get => _guideLinesEnabled;
            set => SetProperty(ref _guideLinesEnabled, value);
        }

        public double DisplaySymbolUnitWidth
        {
            get => _displaySymbolUnitWidth;
            set
            {
                if (SetProperty(ref _displaySymbolUnitWidth, value))
                {
                    OnPropertyChanged(nameof(ZoomPercentage));
                }
            }
        }

        public double ZoomPercentage
        {
            get => DefaultSymbolUnitWidth / _displaySymbolUnitWidth * 100;
            set
            {
                DisplaySymbolUnitWidth = DefaultSymbolUnitWidth * value / 100;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplaySymbolUnitWidth));
            }
        }

        public IsChildOfPredicate HierarchyPredicate { get; } = SymbolArtItemModel.IsChildOf;

        public bool SelectedItemIsLayer => SelectedItem is SymbolArtLayerModel;

        public string AppTitle
        {
            get
            {
                if (CurrentSymbolArt != null)
                {
                    return $"{CurrentSymbolArt.Name} - OpenSAE Symbol Art Editor";
                }
                else
                {
                    return "OpenSAE Symbol Art Editor";
                }
            }
        }

        public SymbolListModel SymbolsList { get; }

        public ICommand NewFileCommand { get; }

        public ICommand OpenFileCommand { get; }

        public RelayCommand SaveCommand { get; }

        public RelayCommand SaveAsCommand { get; }

        public RelayCommand<string> CurrentItemCommand { get; }

        public RelayCommand<string> RotateCurrentItemCommand { get; }

        public RelayCommand<string> ChangeSettingCommand { get; }

        public RelayCommand<string> ZoomCommand { get; set; }

        public ICommand ExitCommand { get; }

        public AppModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            SymbolsList = new SymbolListModel();
            RecentFiles = Settings.Default.RecentFiles != null ? new ObservableCollection<string>(Settings.Default.RecentFiles.ToEnumerable()!) : new ObservableCollection<string>();
            ApplyToneCurve = Settings.Default.ApplyToneCurve;

            OpenFileCommand = new RelayCommand<string>(OpenFile_Implementation);
            NewFileCommand = new RelayCommand(NewFile_Implementation);
            ExitCommand = new RelayCommand(() => ExitRequested?.Invoke(this, EventArgs.Empty));
            SaveCommand = new RelayCommand(Save_Implementation, () => CurrentSymbolArt != null);
            SaveAsCommand = new RelayCommand(SaveAs_Implementation, () => CurrentSymbolArt != null);

            CurrentItemCommand = new RelayCommand<string>(CurrentItemActionCommand_Implementation, (arg) => SelectedItem != null);
            RotateCurrentItemCommand = new RelayCommand<string>(RotateCurrentItemCommand_Implementation, (_) => SelectedItem != null);
            ChangeSettingCommand = new RelayCommand<string>(ChangeSetting_Implementation);
            ZoomCommand = new RelayCommand<string>(Zoom_Implementation);
        }

        private void Zoom_Implementation(string? obj)
        {
            if (obj == null)
            {
                ZoomPercentage = 100;
            }
            else
            {
                var newValue = DisplaySymbolUnitWidth + double.Parse(obj);

                if (newValue < MinimumSymbolUnitWidth)
                    DisplaySymbolUnitWidth = MinimumSymbolUnitWidth;
                else if (newValue > MaximumSymbolUnitWidth)
                    DisplaySymbolUnitWidth = MaximumSymbolUnitWidth;
                else
                    DisplaySymbolUnitWidth = newValue;
            }
        }

        private void ChangeSetting_Implementation(string? operation)
        {
            switch (operation)
            {
                case "toneCurve":
                    ApplyToneCurve = !ApplyToneCurve;
                    break;

                case "guideLines":
                    GuideLinesEnabled = !GuideLinesEnabled;
                    break;
            }
        }

        private void RotateCurrentItemCommand_Implementation(string? angle)
        {
            if (SelectedItem == null || angle == null)
                return;

            SelectedItem.Rotate(double.Parse(angle) / 180 * Math.PI);
        }

        private void CurrentItemActionCommand_Implementation(string? operation)
        {
            if (SelectedItem == null)
                return;

            switch (operation)
            {
                case "toggleVisibility":
                    SelectedItem.Visible = !SelectedItem.Visible;
                    break;

                case "deselect":
                    SelectedItem = null;
                    break;

                case "delete":
                    SelectedItem.Delete();
                    SelectedItem = null;
                    break;

                case "flipX":
                    SelectedItem.FlipX();
                    break;

                case "flipY":
                    SelectedItem.FlipY();
                    break;

                case "addLayer":
                    // find group to add layer to - may be current item, it's parent
                    // or possibly the root symbol art
                    SymbolArtGroupModel targetGroup =
                        SelectedItem as SymbolArtGroupModel
                        ?? SelectedItem.Parent as SymbolArtGroupModel
                        ?? CurrentSymbolArt!;

                    var newLayer = new SymbolArtLayerModel("Symbol", targetGroup);

                    if (SelectedItem is SymbolArtLayerModel)
                    {
                        // if selected item is a layer, add the new layer before it
                        targetGroup.Children.Insert(targetGroup.Children.IndexOf(SelectedItem), newLayer);
                    }
                    else
                    {
                        // and if it is a group, add the layer as the first
                        targetGroup.Children.Insert(0, newLayer);
                    }

                    SelectedItem = newLayer;
                    break;

                case "addGroup":
                    SymbolArtGroupModel parentGroup =
                        SelectedItem as SymbolArtGroupModel
                        ?? SelectedItem.Parent as SymbolArtGroupModel
                        ?? CurrentSymbolArt!;

                    var newGroup = new SymbolArtGroupModel("Group", parentGroup);

                    var parentIndex = parentGroup.Children.IndexOf(SelectedItem);
                    if (parentIndex != -1)
                    {
                        parentGroup.Children.Insert(parentIndex, newGroup);
                    }
                    else
                    {
                        parentGroup.Children.Add(newGroup);
                    }

                    SelectedItem = newGroup;
                    break;

                case "duplicate":
                    if (SelectedItem.Parent == null)
                        return;

                    var duplicate = SelectedItem.Duplicate(SelectedItem.Parent);

                    var currentIndex = SelectedItem.Parent.Children.IndexOf(SelectedItem);

                    SelectedItem.Parent.Children.Insert(currentIndex, duplicate);
                    break;
            }
        }

        private void NewFile_Implementation()
        {
            CurrentSymbolArt = new SymbolArtModel();
            SelectedItem = CurrentSymbolArt;
        }

        public bool RequestExit()
        {
            Settings.Default.RecentFiles = RecentFiles.ToStringCollection();
            Settings.Default.ApplyToneCurve = ApplyToneCurve;
            Settings.Default.GuideLinesEnabled = GuideLinesEnabled;

            return true;
        }

        public ObservableCollection<string> RecentFiles { get; }

        private void OpenFile_Implementation(string? filename)
        {
            if (filename == null)
            {
                filename = _dialogService.BrowseOpenFile("Open existing symbol art file", FileFormatFilter);

                if (filename == null)
                    return;
            }

            try
            {
                CurrentSymbolArt = new SymbolArtModel(filename);
                SelectedItem = CurrentSymbolArt;
            }
            catch (Exception ex)
            {
                _dialogService.ShowErrorMessage("Error opening file", "Unable to open the selected symbol art file.", ex);
            }

            int recentPos = RecentFiles.IndexOf(filename);

            if (recentPos != -1)
            {
                RecentFiles.RemoveAt(recentPos);
            }

            RecentFiles.Insert(0, filename);

            while (RecentFiles.Count > Settings.Default.MaxRecentFiles)
            {
                RecentFiles.RemoveAt(RecentFiles.Count - 1);
            }
        }

        private void Save_Implementation()
        {
            if (CurrentSymbolArt == null)
                return;

            if (string.IsNullOrEmpty(CurrentSymbolArt.FileName))
            {
                SaveAs_Implementation();
            }
            else
            {
                try
                {
                    CurrentSymbolArt.Save();
                }
                catch (Exception ex)
                {
                    _dialogService.ShowErrorMessage("Error saving file", "Unable to save the symbol art file.", ex);
                }
            }
        }

        private void SaveAs_Implementation()
        {
            if (CurrentSymbolArt == null)
                return;

            string? filename = _dialogService.BrowseSaveFile("Save symbol art file", FileFormatFilter, CurrentSymbolArt.FileName);

            if (filename == null)
                return;

            try
            {
                CurrentSymbolArt.SaveAs(filename, System.IO.Path.GetExtension(filename).ToLower() switch
                {
                    ".saml" => Core.SymbolArtFileFormat.SAML,
                    ".sar" => Core.SymbolArtFileFormat.SAR,
                    _ => throw new Exception("Unsupported file extension")
                });
            }
            catch (Exception ex)
            {
                _dialogService.ShowErrorMessage("Error saving file", "Unable to save the symbol art file.", ex);
            }
        }
    }
}
