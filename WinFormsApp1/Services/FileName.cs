using PryamolineynostWF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Services
{
    public static class FileDialog
    {
        private static string SaveFileDialog(FileFormat format)
        {
            var saveFileDialog = new SaveFileDialog();

            switch (format)
            {
                case FileFormat.PDF:
                    saveFileDialog.Filter = @"PDF|*.pdf";
                    saveFileDialog.Title = @"Select PDF file";
                    break;
                case FileFormat.JSON:
                    saveFileDialog.Filter = @"JSON|*.json";
                    saveFileDialog.Title = @"Select JSON file";
                    break;
            }

            saveFileDialog.ShowDialog();

            return saveFileDialog.FileName;
        }

        private static string GetSaveFileName(FileFormat format)
        {
            var saveFileDialog = new SaveFileDialog();

            switch (format)
            {
                case FileFormat.PDF:
                    saveFileDialog.Filter = @"PDF|*.pdf";
                    saveFileDialog.Title = @"Select PDF file";
                    break;
                case FileFormat.JSON:
                    saveFileDialog.Filter = @"JSON|*.json";
                    saveFileDialog.Title = @"Select JSON file";
                    break;
            }

            saveFileDialog.ShowDialog();

            return saveFileDialog.FileName;
        }
    }
}
