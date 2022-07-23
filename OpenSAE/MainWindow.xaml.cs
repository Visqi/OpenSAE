﻿using Microsoft.Win32;
using OpenSAE.Core;
using OpenSAE.Core.SAML;
using OpenSAE.Models;
using OpenSAE.Properties;
using OpenSAE.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenSAE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppModel _model;

        private bool _treeViewDrag;
        private DependencyObject? _treeViewClickSource;
        private Point? _treeViewClickPoint;
        private SymbolArtItemModel? _treeViewDraggingItem;

        public MainWindow()
        {
            InitializeComponent();

            _model = new AppModel(new DialogService(this));
            _model.ExitRequested += (_, __) => Close();

            DataContext = _model;

            Width = Settings.Default.WindowWidth;
            Height = Settings.Default.WindowHeight;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_model.RequestExit())
            {
                e.Cancel = true;
            }

            Settings.Default.WindowWidth = Width;
            Settings.Default.WindowHeight = Height;
            Settings.Default.Save();
        }

        private void mainWindow_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data is IDataObject dataObject)
            {
                var files = (string[]?)dataObject.GetData(DataFormats.FileDrop);

                if (files?.Length == 1)
                {
                    e.Effects |= DragDropEffects.Copy;
                    e.Handled = true;
                }
            }
        }

        private void mainWindow_Drop(object sender, DragEventArgs e)
        {
            if (e.Data is IDataObject dataObject)
            {
                var files = (string[]?)dataObject.GetData(DataFormats.FileDrop);

                if (files?.Length == 1)
                {
                    _model.OpenFileCommand.Execute(files[0]);
                    e.Handled = true;
                }
            }
        }

        private void TreeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.OriginalSource is DependencyObject obj && FindParent<TreeViewItem>(obj) is TreeViewItem && _treeViewDraggingItem != null)
            {
                e.Effects = e.KeyStates.HasFlag(DragDropKeyStates.ControlKey) ? DragDropEffects.Copy : DragDropEffects.Move;
                e.Handled = true;
            }
        }

        private void TreeView_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && _treeViewDrag)
            {
                // ensure that a drag operation is intended by measuring how far
                // the mouse has moved since the button was pressed
                Point currentPosition = e.GetPosition(this);
                if ((_treeViewClickPoint - currentPosition)?.Length > 15)
                {
                    var treeViewItem = FindParent<TreeViewItem>(_treeViewClickSource!);

                    if (treeViewItem == null || treeViewItem.DataContext is not SymbolArtItemModel item)
                        return;

                    _treeViewDraggingItem = item;
                    _treeViewDrag = false;

                    DragDrop.DoDragDrop(treeView, nameof(SymbolArtItemModel), DragDropEffects.Move | DragDropEffects.Copy);
                }
            }
        }

        private void TreeView_Drop(object sender, DragEventArgs e)
        {
            if (e.OriginalSource is DependencyObject obj && FindParent<TreeViewItem>(obj) is TreeViewItem treeViewItem && _treeViewDraggingItem != null)
            {
                if (treeViewItem?.DataContext is SymbolArtItemModel targetItem)
                {
                    var stringContent = e.Data.GetData(DataFormats.StringFormat) as string;

                    if (stringContent != nameof(SymbolArtItemModel))
                        return;

                    if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                    {
                        _treeViewDraggingItem.CopyTo(targetItem);
                    }
                    else
                    {
                        _treeViewDraggingItem.MoveTo(targetItem);
                    }
                }
            }
        }

        private void treeView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DependencyObject obj && FindParent<TreeViewItem>(obj) is not null)
            {
                _treeViewClickSource = obj;
                // save the point the mouse was clicked
                _treeViewClickPoint = e.GetPosition(this);
                _treeViewDrag = true;
            }
            else
            {
                _treeViewDrag = false;
            }
        }

        public static T? FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
            {
                // we didn't find it
                return null;
            }

            return parentObject as T ?? FindParent<T>(parentObject);
        }
    }
}
