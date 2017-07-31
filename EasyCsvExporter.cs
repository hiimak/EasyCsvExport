using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace EasyCsvExporter
{
    class CsvExport
    {

        private string filePath;
        private string clmnSeperator;
        private bool hasClmnHeader;
        private Thread export;


        public string FilePath { get => filePath; set => filePath = value; }
        public bool HasClmnHeader { get => hasClmnHeader; set => hasClmnHeader = value; }
        public string ClmnSeperator { get => clmnSeperator; set => clmnSeperator = value; }

        /// <summary>
        /// Saves a CSV File from a DataTable as a new Thread
        /// </summary>
        /// <param name="data"></param>
        public void ExportCSVAsync(DataTable data)
        {
            export = new Thread(() => ExportCsv(data));
            export.Start();
        }

        /// <summary>
        /// Saves a CSV File from a DataTable
        /// </summary>
        /// <param name="data"></param>
        public void ExportCsv(DataTable data)
        {
            SaveFileDialog save = new SaveFileDialog();

            string filter = "CSV file (*.csv)|*.csv";

            save.Filter = filter;
            save.ShowDialog();

            if (save.FileName != null)
            {
                FilePath = save.FileName;

                if (save.OverwritePrompt)
                {
                    File.WriteAllText(FilePath, string.Empty);
                }

                StreamWriter writer = File.AppendText(FilePath);

                if (HasClmnHeader)
                {
                    string header = "";
                    foreach (DataColumn clmn in data.Columns)
                    {
                        header += clmn.ColumnName + ClmnSeperator;
                    }
                    writer.WriteLine(header);
                }

                for (int i = 0; i <= data.Rows.Count-1; i++)
                {
                    string cellvalue = "";

                    for (int j = 0; j <= data.Columns.Count-1; j++)
                    {
                        cellvalue += data.Rows[i][j].ToString() + ClmnSeperator;
                    }
                    writer.WriteLine(cellvalue);
                }
                Console.WriteLine("Export CSV File: " + FilePath); 
                writer.Close();
            }
        }

        /// <summary>
        /// Saves a CSV File from a string[][] as a new Thread
        /// </summary>
        /// <param name="data"></param>
        public void ExportCSVAsync(string[][] data)
        {
            export = new Thread(() => ExportCsv(data));
            export.Start();
        }

        /// <summary>
        /// Saves a CSV File from a string[][]
        /// </summary>
        /// <param name="data"></param>
        public void ExportCsv(string[][] data)
        {

        }

        /// <summary>
        /// Saves a CSV File from a multidimensional int array
        /// </summary>
        /// <param name="data"></param>
        public void ExportCsv(int[][] data)
        {

        }

        /// <summary>
        /// Saves a CSV File from a string[][] as a new Thread
        /// </summary>
        /// <param name="data"></param>
        public void ExportCSVAsync(int[][] data)
        {
            export = new Thread(() => ExportCsv(data));
            export.Start();
        }

        /// <summary>
        /// Saves a CSV File from a double[][]
        /// </summary>
        /// <param name="data"></param>
        public void ExportCsv(double[][] data)
        {

        }

        /// <summary>
        /// Saves a CSV File from a double[][] as a new Thread
        /// </summary>
        /// <param name="data"></param>
        public void ExportCSVAsync(double[][] data)
        {
            export = new Thread(() => ExportCsv(data));
            export.Start();
        }

        /// <summary>
        /// Saves a CSV File from a generic List
        /// </summary>
        /// <param name="data"></param>
        public void ExportCsv<T>(List<T> data)
        {

        }

        /// <summary>
        /// Saves a CSV File from a generic List as a new Thread
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public void ExportCSVAsync<T>(List<T> data)
        {
            export = new Thread(() => ExportCsv(data));
            export.Start();
        }

    }
}
