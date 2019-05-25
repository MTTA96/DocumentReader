using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;

namespace DocumentReader.Views.UCs
{
    /// <summary>
    /// Interaction logic for DocumentViewerControl.xaml
    /// </summary>
    public partial class DocumentViewerControl : UserControl
    {

        private string folderPath;
        private string[] filesPath;
        private int currentReadingFileIndex = 0;

        public DocumentViewerControl()
        {
            InitializeComponent();
        }

        /// ACTIONS

        private void btnSelectWord_Click(object sender, RoutedEventArgs e)
        {
            // Initialize an OpenFileDialog 
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter and RestoreDirectory 
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;

            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Word documents(*.doc;*.docx)|*.doc;*.docx";

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                if (openFileDialog.FileName.Length > 0)
                {
                    spinner.Visibility = Visibility.Visible;
                    handleSelectedFileFromDialog(openFileDialog.FileName);
                }
            }
        }

        private void btnNextFile_Click(object sender, RoutedEventArgs e)
        {
            if (filesPath != null)
            {
                if (currentReadingFileIndex < filesPath.Length - 1)
                {
                    spinner.Visibility = Visibility.Visible;
                    currentReadingFileIndex++;
                    updateButtonState();
                    displayFile(filesPath[currentReadingFileIndex]);
                }
            }
        }

        private void btnPreviousFile_Click(object sender, RoutedEventArgs e)
        {
            if (filesPath != null)
            {
                if (currentReadingFileIndex > 0)
                {
                    spinner.Visibility = Visibility.Visible;
                    currentReadingFileIndex--;
                    updateButtonState();
                    displayFile(filesPath[currentReadingFileIndex]);
                }
            }

        }

        /// SUPPORT FUNC

        private void handleSelectedFileFromDialog(string selectedFileName)
        {

            folderPath = Directory.GetParent(selectedFileName).FullName;
            filesPath = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".doc") || s.EndsWith(".docx")).ToArray();
            Array.Reverse(filesPath);

            txbSelectedWordFile.Text = selectedFileName;

            filesPath.FirstOrDefault(x => x == selectedFileName);
            for (int i = 0; i <= filesPath.Length - 1; i++)
            {
                if (filesPath[i] == selectedFileName)
                {
                    currentReadingFileIndex = i;
                    updateButtonState();
                    displayFile(filesPath[currentReadingFileIndex]);
                    return;
                }
            }

            spinner.Visibility = Visibility.Hidden;

        }

        private void displayFile(string filePath)
        {
            string wordDocument = filePath;
            if (string.IsNullOrEmpty(wordDocument) || !File.Exists(wordDocument))
            {
                MessageBox.Show("The file is invalid. Please select an existing file again.");
            }
            else
            {
                string convertedXpsDoc = string.Concat(System.IO.Path.GetTempPath(), "\\", Guid.NewGuid().ToString(), ".xps");
                XpsDocument xpsDocument = ConvertWordToXps(wordDocument, convertedXpsDoc);
                if (xpsDocument == null)
                {
                    spinner.Visibility = Visibility.Hidden;
                    return;
                }

                txbSelectedWordFile.Text = filePath;
                documentviewWord.Document = xpsDocument.GetFixedDocumentSequence();
            }
        }

        private XpsDocument ConvertWordToXps(string wordFilename, string xpsFilename)
        {
            // Create a WordApplication and host word document 
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            try
            {
                wordApp.Documents.Open(wordFilename);

                // To Invisible the word document 
                wordApp.Application.Visible = false;

                // Minimize the opened word document 
                wordApp.WindowState = WdWindowState.wdWindowStateMinimize;

                Document doc = wordApp.ActiveDocument;

                doc.SaveAs(xpsFilename, WdSaveFormat.wdFormatXPS);

                XpsDocument xpsDocument = new XpsDocument(xpsFilename, FileAccess.Read);
                return xpsDocument;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs, The error message is  " + ex.ToString());
                return null;
            }
            finally
            {
                wordApp.Documents.Close();
                ((_Application)wordApp).Quit(WdSaveOptions.wdDoNotSaveChanges);
                spinner.Visibility = Visibility.Hidden;
            }
        }

        private void updateButtonState()
        {

            if (currentReadingFileIndex != 0 && currentReadingFileIndex != filesPath.Length - 1)
            {
                btnNext.IsEnabled = true;
                btnPrevious.IsEnabled = true;
            }
            else if (currentReadingFileIndex == 0)
            {
                btnNext.IsEnabled = true;
                btnPrevious.IsEnabled = false;
            }
            else
            {
                btnNext.IsEnabled = false;
                btnPrevious.IsEnabled = true;
            }
        }
    }
}
